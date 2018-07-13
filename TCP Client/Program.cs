using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TCP_Client
{
    class Program
    {
        private static bool switchOff = true;
        static void Main(string[] args)
        {
            const int port = 8080;
            var client = new TcpClient("127.0.0.1", port);
            var stream = client.GetStream();
            do
            {
                Console.WriteLine("Give the text ");
                string tekst = "";
                tekst = "1st client";
                var data = Encoding.ASCII.GetBytes(tekst);
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", tekst);
                Console.WriteLine("\nDONE\n");
                System.Threading.Thread.Sleep(500);
            } while (true);
            stream.Close();
            client.Close();
        }

        private static void Connect(string server, string message, TcpClient client)
        {         
            try
            {      
                 
                
               
                
                
                //client.Close();

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("!!!!!ERROR!!!!!");
                Console.WriteLine("Can't connect to server");
                //Console.WriteLine("SocketException: {0}", e);
            }
            catch (IOException e)
            {
                Console.WriteLine("!!!!!ERROR!!!!!");
                Console.WriteLine("Lost connection with server");
            }
            finally
            {
                ConsoleKeyInfo key;
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Press y");
                    key = Console.ReadKey();

                } while (key.KeyChar != 'y' && key.KeyChar != 'Y' && key.KeyChar != 'n' && key.KeyChar != 'N');

                if (key.KeyChar == 'n' || key.KeyChar == 'N')
                {
                    switchOff = false;
                }
                
            }
        }
    }
}
