using ServerTCP;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerClientTCP
{
    class ServerHendler
    {

        List<string> clientsMsg = new List<string>();

        Server server;

        public ServerHendler(Server server)
        {
            this.server = server;
            EventServerHandler(server);
        }


        public void EventServerHandler(Server server)
        {

            server.GetMsgFromClient += (massege) =>
            {
                clientsMsg.Add(massege);
            };
        }

    }
}
