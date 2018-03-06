using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace MultyChat
{
    //using UdpClient instead of sockets
    public partial class Chat : Form
    {
        //use varialbles for all kind of life situations
        UdpClient client;
        IPAddress ip;                   //ip for multicast
        int receivePort = 9005;         //LOCALPORT Receiving port
        int sendPort;                   //REMOTEPORT Sending port
        int TTL = 20;                   //how many routers

        
        bool isAlive = false;           //if the task still alive
        
        string userName = "";           //user name
        string HOST = "235.5.5.1";      //multicast ip

        
        public Chat()
        {
            InitializeComponent();
            
            ip = IPAddress.Parse(HOST);
            
            joinButton.Enabled = true;
            disconnectButton.Enabled = false;
            sendButton.Enabled = false;
            Int32.TryParse(portInfo.Text, out sendPort);
        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            userName = nickname.Text;
            nickname.ReadOnly = true;

            try
            {
                client = new UdpClient(receivePort);
                
                client.JoinMulticastGroup(ip, TTL);

                Task listenTask = new Task(Listen);
                listenTask.Start();
                
                string message = DateTime.Now.ToShortTimeString()
                    + ": " + nickname.Text + " connected";

                SendMessage(message);

                joinButton.Enabled = false;
                disconnectButton.Enabled = true;
                sendButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " in Join");
            }
            
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            ExitChat();
        }

        private void ExitChat()
        {
            string message = DateTime.Now.ToShortTimeString() +": "+ userName + " left Chat";
            SendMessage(message);
          
            client.DropMulticastGroup(ip);

            isAlive = false;
            client.Close();

            joinButton.Enabled = true;
            disconnectButton.Enabled = false;
            sendButton.Enabled = false;
            nickname.ReadOnly = false;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string message = DateTime.Now.ToShortTimeString() + ": " + messageText.Text;
            SendMessage(message);
        }

        void SendMessage(string message)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            client.Send(data, data.Length, ip.ToString(), sendPort);
            Appendtext(message);
        }

        void Listen()
        {
            isAlive = true;
            try
            {
                while (isAlive)
                {
                    IPEndPoint ipep = null;
                    byte[] buff = client.Receive(ref ipep);
                    string mes = Encoding.UTF8.GetString(buff);
                    Appendtext(mes);
                }
            }
            catch(ObjectDisposedException)
            {
                if (!isAlive)
                    return;
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " IN LISTEN");
            }
            
        }

        private void portInfo_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(portInfo.Text, out sendPort);
        }

        void Appendtext(string message)
        {
            allMessages.Text += message + "\r\n";
        }

    }
}
