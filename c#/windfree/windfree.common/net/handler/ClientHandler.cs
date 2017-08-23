using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using windfree.common.net.message;

namespace windfree.common.net.handler
{
    class ClientHandler
    {
        TcpClient clientSock;
        public static Object lockObj = new Object();
      
        public ClientHandler(TcpClient sock)
        {
            this.clientSock = sock;
        }
        public void Start()
        {
            Thread th = new Thread(new ThreadStart(Run));
            th.Start();
        }

        private void Run()
        {
            while(true)
            {
                NetworkMessage msg = new NetworkMessage(this.clientSock);
                msg.ReadMessage();
                Console.Out.WriteLine("read message:" + msg.Message);
                if(msg.Message.Equals("q"))
                {
                    Console.Out.WriteLine("Receive terminate message");
                    Environment.Exit(0);
                } else
                {
                    string findstr = msg.Message;
                    string path = @"C:\workspace\ws.study\my.code.snippet\files";
                    string[] files = GetFiles(path);
                    StreamWriter sw = new StreamWriter(new FileStream(AppDomain.CurrentDomain.BaseDirectory + @"\result3.txt", FileMode.OpenOrCreate));


                    foreach (string file in files)
                    {
                        StreamReader sr = new StreamReader(new FileStream(file, FileMode.Open));
                        List<string> list = new List<string>();
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            list.Add(line);
                        }

                        int index = 0;
                        list.Sort();
                        index = list.BinarySearch(findstr);
                        if (index > 0)
                        {
                            sw.WriteLine(file + ":" + list[index]);
                            while ((index + 1 < list.Count()) && (index = list.BinarySearch(index + 1, 1, findstr, null)) > 0)
                            {
                                sw.WriteLine(file + ":" + list[index]);
                            }

                        }

                        list.Clear();

                        sr.Close();
                    }
                    sw.Close();
                }
                
            }

        }

        public string[] GetFiles(string path)
        {
            try
            {
                return Directory.GetFiles(path);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
