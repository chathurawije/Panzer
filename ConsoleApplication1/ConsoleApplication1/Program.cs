using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        TcpListener serverListner;
        TcpClient serv;
        Program(){
            try
            {
                serverListner = new TcpListener(IPAddress.Any, 7000);
                serverListner.Start();

                //serv = new TcpClient();
                //serv.Connect("localhost", 6000);
            }
            catch (Exception e)
            {
                Console.WriteLine();
            }

    }
     

        public static void Main(String[] args)
        {
            Program p = new Program();
            Thread a = new Thread(new ThreadStart(p.AI));
            a.Start();
            //p.sendMessage("JOIN#");
          while (true)
          {
              p.getMessage();
          }   
        }
        public void AI()
        {
            Program p = new Program();
            p.sendMessage("JOIN#");
            Thread.Sleep(25000);
            p.sendMessage("DOWN#");
            Thread.Sleep(1000);
            p.sendMessage("SHOOT#");
            Thread.Sleep(1000);
            p.sendMessage("SHOOT#");
            Thread.Sleep(1000);
            p.sendMessage("DOWN#");
            Thread.Sleep(1000);
            p.sendMessage("SHOOT#");
            Thread.Sleep(1000);
            p.sendMessage("SHOOT#");
            Thread.Sleep(1000);
            p.sendMessage("SHOOT#");
            Thread.Sleep(1000);
            p.sendMessage("SHOOT#");
            Thread.Sleep(1000);
            p.sendMessage("SHOOT#");
            Thread.Sleep(1000);

        }

        public void sendMessage(String str)
        {
            
            try
            {
                serv = new TcpClient();
                serv.Connect("localhost", 6000);
                //Console.WriteLine("enter the message");
                //String str = Console.ReadLine();
                NetworkStream stm = serv.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                stm.Write(ba, 0, ba.Length);
                Console.WriteLine("\nSent message#");
                stm.Close();
                serv.Close();
              
            }
            catch (Exception e)
            {  
                Console.WriteLine("Error..... " + e.StackTrace);
            }

        }

        

        public void getMessage()
        {
            String data;
            Byte[] bytes = new Byte[1024];
            TcpClient gameServer = serverListner.AcceptTcpClient();
            data = null;
            NetworkStream stream = gameServer.GetStream();

            int i;

            // Loop to receive all the data sent by the client.
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                // convert data bytes to a ASCII string.
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);  //Encode Byte into a String


                System.Console.WriteLine(data);

            }
            gameServer.Close();
            stream.Close();
        }
    }
}
