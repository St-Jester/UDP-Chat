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
        int LOCALPORT = 8001;         //LOCALPORT Receiving port
        int REMOTEPORT = 8001;            //REMOTEPORT Sending port
        int TTL = 20;                   //how many routers
        string userName = "";           //user name
        string HOST = "235.5.5.1";      //multicast ip

        bool isAlive = false;           //if the task still alive


        public Chat()
        {
            InitializeComponent();
            
            ip = IPAddress.Parse(HOST);
            
            joinButton.Enabled = true;
            disconnectButton.Enabled = false;
            sendButton.Enabled = false;

            Int32.TryParse(portInfo.Text, out REMOTEPORT);
            Int32.TryParse(receivePortInfo.Text, out LOCALPORT);

        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            userName = nickname.Text;
            nickname.ReadOnly = true;

            try
            {
                client = new UdpClient(LOCALPORT);
                
                client.JoinMulticastGroup(ip, TTL);

                Task listenTask = new Task(Listen);
                listenTask.Start();
                
                string message = userName + " " + DateTime.Now.ToShortTimeString()
                    + ": " +" connected";

                SendMessage(message);
                
                joinButton.Enabled = false;
                disconnectButton.Enabled = true;
                sendButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " IN JOIN");
            }
            
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            ExitChat();
        }

        private void ExitChat()
        {
            string message = userName + " " + DateTime.Now.ToShortTimeString() +": "+" left Chat";
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
            string message = userName +" "+ DateTime.Now.ToShortTimeString() + ": " + messageText.Text;
            SendMessage(message);
        }

        void SendMessage(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.Send(data, data.Length, HOST, REMOTEPORT);
           //Appendtext(message);
        }

        void Listen()
        {
            isAlive = true;
            try
            {
                while (isAlive)
                {
                    IPEndPoint remoteIP = new IPEndPoint(IPAddress.Any, REMOTEPORT);
                    byte[] buff = new byte[1024];
                    buff = client.Receive(ref remoteIP);
                    if (buff!=null)
                    {
                        string mes = Encoding.UTF8.GetString(buff);
                        Appendtext(mes);
                        //MessageBox.Show(userName + "Received");
                    }
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
            Int32.TryParse(portInfo.Text, out REMOTEPORT);
        }

        void Appendtext(string message)
        {
            char anchor = ' ';
            string UN = message.Split(anchor)[0];
            ListViewItem lvi = ChatView.Items.Add(UN);
            
            lvi.SubItems.Insert(1,new ListViewItem.ListViewSubItem(lvi, message));
            
            allMessages.Text = message + "\r\n" + allMessages.Text;
        }

        private void receivePortInfo_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(receivePortInfo.Text, out LOCALPORT);
        }
    }
}
