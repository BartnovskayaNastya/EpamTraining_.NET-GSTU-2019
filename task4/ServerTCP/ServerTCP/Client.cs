using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ServerClientTCP
{
    class Client
    {
        public string IpAdress { get; private set; }

        public int Port { get; private set; }
        private IPEndPoint endPoint;
        private Socket socketTcp;

        public Client(int port = 8079, string ipAdress = "127.0.0.1")
        {
            Port = port;
            IpAdress = ipAdress;
            endPoint = new IPEndPoint(IPAddress.Parse(ipAdress), port);
            socketTcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void GetMsg(string msg)
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

            socketTcp.Shutdown(SocketShutdown.Both);
            socketTcp.Close();

        }
    }
}
