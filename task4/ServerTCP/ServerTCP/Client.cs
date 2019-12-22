using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ServerClientTCP
{
    public class Client
    {

        public delegate void GetMsgzServer(string message);
        /// <summary>
        /// event for sending messege from server
        /// </summary>
        public event GetMsgzServer GetMsgFromServer;

        public string IpAdress { get; private set; }

        public int Port { get; private set; }
        private IPEndPoint endPoint;
        private Socket socketTcp;

        /// <summary>
        /// Constructor for client
        /// </summary>
        /// <param name="port">Port of connection</param>
        /// <param name="ipAdress">ipAdress for connection</param>
        public Client(int port = 8079, string ipAdress = "127.0.0.1")
        {
            Port = port;
            IpAdress = ipAdress;
            endPoint = new IPEndPoint(IPAddress.Parse(ipAdress), port);
            socketTcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// Method for connection with server and sending masseges
        /// </summary>
        /// <param name="msg">Massege for server</param>
        public void SendMsg(string msg)
        {
            var data = Encoding.UTF8.GetBytes(msg);
            socketTcp.Connect(endPoint);
            socketTcp.Send(data);

            byte[] buffer = new byte[1024];
            var size = 0;
            StringBuilder serverAnswer = new StringBuilder();

            do
            {
                size = socketTcp.Receive(buffer);
                serverAnswer.Append(Encoding.UTF8.GetString(buffer, 0, size));

            }
            while (socketTcp.Available > 0);

            GetMsgFromServer?.Invoke("Massege is received");

            socketTcp.Shutdown(SocketShutdown.Both);
            socketTcp.Close();

        }
    }
}
