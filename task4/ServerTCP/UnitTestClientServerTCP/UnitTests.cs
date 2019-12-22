using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ServerClientTCP;

namespace UnitTestClientServerTCP
{
    [TestClass]
    public class UnitTests
    {
        /// <summary>
        /// Method for testing translite
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {

            Client client = new Client();
            string msg = "Привет";
            client.SendMsg(msg);
            ClientHandler clientHandler = new ClientHandler(client);
            Assert.AreEqual(clientHandler.serverMsg, "Privet");
        }
    }
}
