using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using windfree.common.net.handler;

namespace windfree.common.net.server
{
    public class SocketServer
    {
        TcpListener listener;
        bool running = false;

        public SocketServer()
        {
          
        }
        public void Start()
        {
            Thread th = new Thread(new ThreadStart(Run));
            th.Start();
        }

        public int Port
        {
            get;set;
        }
        

      

        private void Run()
        {
            try
            {
                IPAddress addr = IPAddress.Any;
                listener = new TcpListener(addr, this.Port);
                listener.Start();
                running = true;
                Console.Out.WriteLine("Server listen on port:" + this.Port);
                while (running)
                {
                    
                    TcpClient clientSock = listener.AcceptTcpClient();
                    ClientHandler handler = new ClientHandler(clientSock);
                    handler.Start();
                }
            }
            catch(ThreadInterruptedException e)
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
