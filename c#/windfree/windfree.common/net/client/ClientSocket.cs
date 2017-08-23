using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using windfree.common.net.message;
namespace windfree.common.net.client
{
    
    public class ClientSocket
    {
        TcpClient clientSock;
       // private Object thisLock = new Object();
        
        public ClientSocket()
        {
            clientSock = new TcpClient();
        }

        public string RemoteAddr
        {
            get;set;
        }

        public int RemotePort
        {
            get; set;
        }

        public bool IsConnect()
        {
            return this.clientSock.Connected;
        }

        public TcpClient GetSock()
        {
            return this.clientSock;
        }

        public bool Connect()
        {
            bool result = false;
            try
            {
                IPAddress addr = IPAddress.Parse(this.RemoteAddr);
                clientSock.Connect(addr, this.RemotePort);
                if (clientSock.Connected)
                {
                    Console.Out.WriteLine("Socket connect success.");
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
                result = false;
            }
            return result;

        }

        public void SendMessage(NetworkMessage msg)
        {
            msg.SendMessage();
        }
        

    }
}
