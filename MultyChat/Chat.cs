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
        IPAddress ip;
        int remoteport, selfport;
        int TTL;
        //Thread listenTread;
        bool isAlive = false;//to handle exit event
        //IPEndPoint ep;  
        //Socket senderSocket;
        string userName = "";
        string HOST = "235.5.5.1";

        public Chat()
        {
            InitializeComponent();
            remoteport = Convert.ToInt32(portInfo.Text);

            //can be changed to check on one comp
            selfport = 9005;//listen in this port
            TTL = 50;
            ip = IPAddress.Parse(HOST);
            
            //ep = new IPEndPoint(ip, port);
            //senderSocket = new Socket
            //    (AddressFamily.InterNetwork,
            //    SocketType.Dgram, 
            //    ProtocolType.Udp);

            //senderSocket.SetSocketOption
            //    (SocketOptionLevel.IP,
            //    SocketOptionName.MulticastTimeToLive,2);

            //senderSocket.SetSocketOption
            //    (SocketOptionLevel.IP, 
            //    SocketOptionName.AddMembership,
            //    new MulticastOption(ip));

            //listenTread = new Thread(new ThreadStart(Listen));
            //listenTread.IsBackground = true;

            //button states
            joinButton.Enabled = true;
            disconnectButton.Enabled = false;
            sendButton.Enabled = false;
        }

        private void joinButton_Click(object sender, EventArgs e)
        {

            userName = nickname.Text;
            nickname.ReadOnly = true;

            try
            {
                //must bing socket
                //IPEndPoint ipep = new IPEndPoint(IPAddress.Any, selfport);
                //MessageBox.Show(ipep.ToString());
                client = new UdpClient(selfport);
                
                client.JoinMulticastGroup(ip, TTL);
                Task listenTask = new Task(Listen);
                listenTask.Start();
                //listenTread.Start();
                string message = DateTime.Now.ToShortTimeString()
                    + ": " + nickname.Text + " connected";

                SendMessage(message);

                joinButton.Enabled = false;
                disconnectButton.Enabled = true;
                sendButton.Enabled = true;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "join");
            }
            //senderSocket.Connect(ep);
            //MessageBox.Show("Connection...");
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
            client.Send(data, data.Length, ip.ToString(), remoteport);
            Appendtext(message);
        }

        void Listen()
        {
            isAlive = true;
            try
            {
                while (isAlive)
                {
                    //Socket receiveSocket = 
                    //    new Socket(AddressFamily.InterNetwork,
                    //    SocketType.Dgram,
                    //    ProtocolType.Udp);
                    //receiveSocket.Bind(ipep);
                    ////senderSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2);
                    //receiveSocket.SetSocketOption
                    //    (SocketOptionLevel.IP, 
                    //    SocketOptionName.AddMembership, 
                    //    new MulticastOption(ip, IPAddress.Any));

                    IPEndPoint ipep = null;
                    byte[] buff = new byte[1024];
                    client.Receive(ref ipep);

                    string mes = Encoding.UTF8.GetString(buff);

                    Appendtext(mes);

                    //receiveSocket.Close();
                    //disconnect?
                }
            }
            catch (Exception ex)
            {
                if (!isAlive)
                    return;
                MessageBox.Show(ex.Message + "Listen");
               
            }
            
        }

        private void portInfo_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(portInfo.Text, out selfport);
        }

        void Appendtext(string message)
        {
            allMessages.Text += message + "\r\n";
        }

    }
}
