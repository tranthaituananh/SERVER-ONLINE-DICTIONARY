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
        Socket client;
        string output;
        int wordCount = 1;

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
                IPEndPoint ipEndpoint = new IPEndPoint(IPAddress.Any, 9999);
                TcpListener tcpListener = new TcpListener(ipEndpoint);
                Thread thread = new Thread(() =>
                {
                    while (true)
                    {
                        tcpListener.Start();
                        client = tcpListener.AcceptSocket();
                        Thread receiveData = new Thread(ReceiveData);
                        receiveData.IsBackground = true;
                        receiveData.Start(client);
                    }
                });
                thread.IsBackground = true;
                thread.Start();
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
                byte[] data = Encoding.UTF8.GetBytes(output);
                client.Send(data);
                output = null;
            }
            catch
            {
                byte[] data = Encoding.UTF8.GetBytes("Not found !");
                client.Send(data);
            }
        }

        void ReceiveData(Object sender)
        {
            try
            {
                while (true)
                {
                    Socket client = sender as Socket;
                    byte[] data = new byte[1024];
                    client.Receive(data);
                    string input = Encoding.UTF8.GetString(data); 
                    tbReceived.Text = input;
                    lvSearchHistory.Items.Add(wordCount + ". " + input);
                    wordCount++;
                    backgroundWork.RunWorkerAsync();
                }
            }
            catch
            {
                MessageBox.Show("No data received from client. Please try again !");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWork_DoWork(object sender, DoWorkEventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection dictionarydb = new MySql.Data.MySqlClient.MySqlConnection("Persist Security Info=False;server=localhost;database=dictionarydb;uid=root;password=123456");
            MySqlCommand cmd = dictionarydb.CreateCommand();
            cmd.CommandText = "SELECT * from tbl_edict WHERE word='" + tbReceived.Text + "'";
            cmd.CommandType = CommandType.Text;
            try
            {
                dictionarydb.Open();
            }
            catch
            {
                MessageBox.Show("Cann't open your database !");
            }
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                output = output + reader[2].ToString() + "\n";
                break;
            }
            dictionarydb.Close();
        }

        private void backgroundWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            return;
        }

        private void backgroundWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            rtbResult.Clear();
            if (output == null)
            {
                output = "Not found !";
            }
            rtbResult.Text = output;
            SendData(client);
        }
    }
}
