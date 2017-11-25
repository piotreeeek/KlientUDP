using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace KlientUDP
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean done = false;
            Boolean exceptionThrow = false;

            Socket sendingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress sendToAdress = IPAddress.Parse("127.0.0.1");
            EndPoint sendingEndPoint = new IPEndPoint(sendToAdress, 3301);
            
            string reciveData;

            while (!done)
            {
                string textToSend = "siema";
                Console.WriteLine("Wysłano: " + textToSend);
                byte[] sendBuffer = Encoding.UTF8.GetBytes(textToSend);
                sendingSocket.SendTo(sendBuffer, sendingEndPoint);

                byte[] reciveByte = new byte[1024];
                int length = sendingSocket.ReceiveFrom(reciveByte, ref sendingEndPoint);
                reciveData = Encoding.UTF8.GetString(new List<byte>(reciveByte).GetRange(0, length).ToArray());
                Console.WriteLine("Odebrano: " + reciveData);

            }

            sendingSocket.Close();
        }
    }
}
