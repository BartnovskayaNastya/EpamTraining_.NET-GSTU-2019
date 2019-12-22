using ServerTCP;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerClientTCP
{
    class ServerHendler
    {
        /// <summary>
        /// List of client's masseges
        /// </summary>
        List<string> clientsMsg = new List<string>();

        Server server;

        /// <summary>
        /// Constructor for server event hendler
        /// </summary>
        /// <param name="server">server for subscrube</param>
        public ServerHendler(Server server)
        {
            this.server = server;
            EventServerHandler(server);
        }

        /// <summary>
        /// Method for adding massege in list of client's msg
        /// </summary>
        /// <param name="server">server event handler</param>
        public void EventServerHandler(Server server)
        {

            server.GetMsgFromClient += (massege) =>
            {
                clientsMsg.Add(massege);
            };
        }

    }
}
