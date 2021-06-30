using System;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Server
{
    public partial class Server : Form
    {
        IPEndPoint ipendpoint;
        Socket client;
        TcpListener tcplistener;
        string input;
        string output;

        public Server()
        {
            InitializeComponent();
            backgroundWork.WorkerReportsProgress = true;
            backgroundWork.WorkerSupportsCancellation = true;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnConnect_Click(object sender, System.EventArgs e)
        {
            try
            {
                //tạo 1 IP Endpoint mới
                ipendpoint = new IPEndPoint(IPAddress.Any, 9999);
                tcplistener = new TcpListener(ipendpoint);

                //tạo thread mới để nhận dữ liệu 
                //sử dụng arrow function để invok hàm chỉ khi ấn button, nếu không nó sẽ thành IIFE 
                Thread thread = new Thread(() =>
                {
                    while (true)
                    {
                        tcplistener.Start();
                        client = tcplistener.AcceptSocket();
                        Thread rec = new Thread(ReceiveData);
                        rec.IsBackground = true;
                        rec.Start(client);
                    }
                });

                thread.IsBackground = true;
                thread.Start();
                //nếu kết nối thành công thì hiển thị ra cho user
                MessageBox.Show("Successfully Connected !");

            }
            catch
            {
                MessageBox.Show("Can't connect, please try again later !");
            }
        }

        void SendData(Socket client)
        {
            try
            {
                //mã hóa chuỗi thành các byte để gửi 
                byte[] outputByte = Encoding.UTF8.GetBytes(output);
                client.Send(outputByte);

                //làm trống output, sẵn sàng nhận dữ liệu tiếp theo từ user 
                output = null;
            }
            catch
            {
                //nếu không nhận được gì => đã đứt kết nối
                MessageBox.Show("Word not found in database !");
            }
        }

        void ReceiveData(Object obj)
        {
            try
            {
                while (true)
                {
                    //nhận dữ liệu từ người dùng ở dạng byte
                    Socket client = obj as Socket;
                    byte[] clientMsg = new byte[1024];
                    client.Receive(clientMsg);

                    //mã hóa nó thành chuỗi
                    input = Encoding.UTF8.GetString(clientMsg);

                    //hiển thị vào danh sách đã nhận và màn hình trạng thái 
                    tbReceived.Text = input;
                    lvSearchHistory.Items.Add(input);
                    backgroundWork.RunWorkerAsync();
                }
            }
            catch
            {
                MessageBox.Show("No signal, please try again");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWork_DoWork(object sender, DoWorkEventArgs e)
        {
            //thiết lập connection mới cho mySQL 
            MySql.Data.MySqlClient.MySqlConnection dbConn = new MySql.Data.MySqlClient.MySqlConnection("Persist Security Info=False;server=localhost;database=dictionarydb;uid=root;password=123456");
            MySqlCommand cmd = dbConn.CreateCommand();

            //thiết lập câu lệnh truy vấn từ database 
            cmd.CommandText = "SELECT * from tbl_edict WHERE word='" + tbReceived.Text + "'";
            cmd.CommandType = CommandType.Text;

            // thử mở database 
            try
            {
                dbConn.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show("Cann't open database. Error: " + err);
                this.Close();
            }

            //đọc database và thực hiện truy vấn 
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //bỏ đi thành phần đầu và thứ 2, đọc từ vị trí thứ 3, vì 2 vị trí đầu là từ cần tìm, dữ liệu thừa 
                output += reader[2].ToString() + "\n";
                break;
            }


            //đóng database 
            dbConn.Close();
        }

        private void backgroundWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            return;
        }

        private void backgroundWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //hiển thị sau khi tìm kiếm hoàn tất 
            //gửi đi cho client 
            rtbResult.Text = "STATUS: DONE \n" + output;
            SendData(client);
        }
    }
}
