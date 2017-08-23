using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace windfree.common.net.message
{
    public class NetworkMessage
    {
        private const int HEADER_LENGTH = 6;
    
        private byte[] buffer;
        
        private MessageProtocol protocol = MessageProtocol.PERFORMANCE_DATA;
        private string message;
        private TcpClient sock;
        MemoryStream mStream = null;
        BinaryWriter binaryWriter = null;

        public NetworkMessage(TcpClient sock)
        {
            this.sock = sock;
            mStream = new MemoryStream();
            binaryWriter = new BinaryWriter(mStream, Encoding.UTF8);

        }

        public int DataLength
        {
            get;set;
        }

        public int HeaderLength
        {
            get;set;
        }

        public MessageProtocol Protocol
        {
            get { return protocol; }
            set { this.protocol = value; }
        }

        public string Message
        {
            get { return message; }
            set { this.message = value; }
        }

        public NetworkMessage()
        {
            
        }
        
        public void WriteInt(Int32 value)
        {
            binaryWriter.Write(IPAddress.HostToNetworkOrder(value));
        }

        public void WriteShort(Int16 value)
        {
            binaryWriter.Write(IPAddress.HostToNetworkOrder(value));
        }

        public void WriteString(String value)
        {
            binaryWriter.Write(value);
        }
        

        public void SendMessage()
        {
            //binaryWriter.Write(IPAddress.HostToNetworkOrder(this.message.Length));
            //binaryWriter.Write(IPAddress.HostToNetworkOrder((short)this.protocol));
            //binaryWriter.Write(this.message);
            byte[] buffer = mStream.ToArray();
            NetworkStream nStream = this.sock.GetStream();
            nStream.Write(buffer, 0, buffer.Length);
            
        }

        public void SendMessage(TcpClient sock)
        {
            MemoryStream mStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(mStream, Encoding.UTF8);

          //  writer.Write(IPAddress.HostToNetworkOrder(this.message.Length));
         //   writer.Write(IPAddress.HostToNetworkOrder((short)this.protocol));
            writer.Write(this.message);
            byte[] buffer = mStream.ToArray();

            NetworkStream nStream = sock.GetStream();
            nStream.Write(buffer, 0, buffer.Length);
        }

        public void ReadMessage()
        {
            try
            {
                NetworkStream nStream = this.sock.GetStream();
                BinaryReader reader = new BinaryReader(nStream);
                // this.DataLength = reader.ReadInt32();
                //  this.protocol = (MessageProtocol) reader.ReadInt16();
                this.message = reader.ReadString();
            } catch(Exception e)
            {

            }
        }

    }
}
