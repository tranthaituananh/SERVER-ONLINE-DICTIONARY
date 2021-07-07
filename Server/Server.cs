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
        string input;
        string output;
        int wordCount = 1;
        char signalAdd = ':';
        char signalUpdate = '+';
        char signalDel = '-';
        string word;
        string mean;

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
                    input = Encoding.UTF8.GetString(data);
                    int check = Check();
                    if (check == 1)
                    {
                        string[] arr = input.Split(signalAdd);
                        word = arr[0];
                        mean = arr[1];
                    }
                    else if (check == 2)
                    {
                        string[] arr = input.Split(signalUpdate);
                        word = arr[0];
                        mean = arr[1];
                    }
                    else if (check == 3)
                    {
                        string[] arr = input.Split(signalDel);
                        word = arr[0];
                        mean = arr[1];
                    }
                    tbReceived.Text = input;
                    lvHistory.Items.Add(wordCount + ". " + input);
                    wordCount++;
                    backgroundWork.RunWorkerAsync();
                }
            }
            catch
            {
                MessageBox.Show("Client hasn't no response. Please try again !");
            }
        }

        int Check()
        {
            int temp = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == signalAdd)
                {
                    temp = 1;
                    break;
                }
                else if (input[i] == signalUpdate)
                {
                    temp = 2;
                    break;
                }
                else if (input[i] == signalDel)
                {
                    temp = 3;
                    break;
                }
            }
            return temp;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWork_DoWork(object sender, DoWorkEventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection dictionarydb = new MySql.Data.MySqlClient.MySqlConnection("Persist Security Info=False;server=localhost;database = " + tbDatabase.Text + ";uid=" + tbUid.Text + ";password=" + tbPassword.Text);
            MySqlCommand cmd = dictionarydb.CreateCommand();
            int check = Check();
            if (check == 1)
            {
                cmd.CommandText = "INSERT INTO tbl_edict (word, detail) VALUES ('" + word + "','" + mean + "')";
                cmd.CommandType = CommandType.Text;
                try
                {
                    dictionarydb.Open();
                }
                catch
                {
                    MessageBox.Show("Can't open your database !");
                }
                cmd.ExecuteNonQuery();
            }
            else if (check == 2)
            {
                cmd.CommandText = "UPDATE tbl_edict SET word = '" + word + "', detail = '" + mean + "' WHERE word = '" + word + "'";
                cmd.CommandType = CommandType.Text;
                try
                {
                    dictionarydb.Open();
                }
                catch
                {
                    MessageBox.Show("Can't open your database !");
                }
                cmd.ExecuteNonQuery();
            }
            else if (check == 3)
            {
                cmd.CommandText = "DELETE FROM tbl_edict WHERE word ='" + word + "'";
                cmd.CommandType = CommandType.Text;
                try
                {
                    dictionarydb.Open();
                }
                catch
                {
                    MessageBox.Show("Can't open your database !");
                }
                cmd.ExecuteNonQuery();
            }
            else
            {
                cmd.CommandText = "SELECT * from tbl_edict WHERE word='" + tbReceived.Text + "'";
                cmd.CommandType = CommandType.Text;
                try
                {
                    dictionarydb.Open();
                }
                catch
                {
                    MessageBox.Show("Can't open your database !");
                }
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
            int check = Check();
            if (output == null && check != 1 && check != 2 && check != 3)
            {
                output = "Not found !";
            }
            rtbResult.Text = "COMPLETED !\n" + output;
            SendData(client);
        }
    }
}
