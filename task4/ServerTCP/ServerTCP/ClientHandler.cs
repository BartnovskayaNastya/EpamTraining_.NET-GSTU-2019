using System;
using System.Collections.Generic;
using System.Text;

namespace ServerClientTCP
{
   public  class ClientHandler
    {
        /// <summary>
        /// Array of rusian letters
        /// </summary>
        string[] rusLettes = new string[] {"а", "б", "в","г","д","е","ё","ж","з","и","й","к","л","м","н","о","п",
                                            "р","с","т","у","ф","х","ц","ч","ш","щ","ъ","ы","ь","э","ю","я",
                                            "А", "Б", "В","Г","Д","Е","Ё","Ж","З","И","Й","К","Л","М","Н","О","П",
                                            "Р","С","Т","У","Ф","Х","Ц","Ч","Ш","Щ","Ъ","Ы","Ь","Э","Ю","Я", " "};
        /// <summary>
        /// Array of english letters
        /// </summary>
        string[] engLettes = new string[] {"a", "b", "v","g","d","e","e","j","z","i","i","k","l","m","n","o","p",
                                            "r","s","t","u","f","h","c","ch","sh","sh'","","","","e","yu","ya",
                                            "A", "B", "V","G","D","E","E","J","Z","I","I","K","L","M","N","O","P",
                                            "R","S","T","U","F","H","C","CH","SH","SH'","","","","E","YU","YA", " "};
        private Client client;

        public string serverMsg;

        /// <summary>
        /// Constructor for client event hendler
        /// </summary>
        /// <param name="client">client for subscrube</param>
        public ClientHandler(Client client)
        {
            this.client = client;
            EventClientHandler(client);

        }

        /// <summary>
        /// Method for getting massage by english letters
        /// </summary>
        /// <param name="client">client event handler</param>
        public void EventClientHandler(Client client)
        {
            client.GetMsgFromServer += delegate (string massege)
            {
                serverMsg = "";

                for (int i = 0; i < massege.Length; i++)
                {
                    for (int j = 0; j < rusLettes.Length; j++)
                    {
                        if (massege.Substring(i, 1) == rusLettes[j])
                        {
                            serverMsg += rusLettes[j];
                        }
                    }
                }
            };
        }

    }
}
 