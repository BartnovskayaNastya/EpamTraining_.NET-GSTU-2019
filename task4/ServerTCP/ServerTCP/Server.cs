using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerTCP
{
    public class Server
    {
        public delegate void GetMsgClient(string message);
        /// <summary>
        /// event for sending messege from client
        /// </summary>
        public event GetMsgClient GetMsgFromClient;

        public string IpAdress { get; private set; }
       
        public int Port { get; private set; }
        private IPEndPoint endPoint;
        private Socket socketTcp;

        /// <summary>
        /// Constructor for server
        /// </summary>
        /// <param name="port">port for connection</param>
        /// <param name="ipAdress">ipAdress for connection</param>
        public Server(int port = 11000, string ipAdress = "127.0.0.1")
        {
            Port = port;
            IpAdress = ipAdress;
            endPoint = new IPEndPoint(IPAddress.Parse(ipAdress), port);
            socketTcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketTcp.Bind(endPoint);
        }

        /// <summary>
        /// Method for waiting and get msg from clients
        /// </summary>
        /// <param name="count">amount of clients</param>
        public void ListenClients(int count)
        {
            socketTcp.Listen(count);

            while (true)
            {
                Socket listener = socketTcp.Accept();
                byte[] buffer = new byte[1024];
                var size = 0;
                StringBuilder data = new StringBuilder();

                do
                {
                    size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));

                }
                while (listener.Available > 0);

                byte[] msg = Encoding.UTF8.GetBytes("Successfully");
                listener.Send(msg);

                GetMsgFromClient?.Invoke("Massege is received");

                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }

        }



       

        

        


    }
}
