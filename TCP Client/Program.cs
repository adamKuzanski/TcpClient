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
            do
            {
                Console.Clear();
                Console.WriteLine("Give the text ");
                string tekst = "";
                tekst = Console.ReadLine();
                Connect("127.0.0.1", tekst);
                Console.WriteLine("\nDONE\n");
            } while (switchOff);
        }

        private static void Connect(string server, string message)
        {         
            try
            {
                //----------------------------------Create a TcpClient----------------------------------
                // Port and server must be the same in Client and Server
                const int port = 13000;
                var client = new TcpClient(server, port);

                //----------------------------------Send a message to TCP Server----------------------------------
                var data = Encoding.ASCII.GetBytes(message);  

                // Get a client stream for reading and writing
                var stream = client.GetStream();

                // Send the message to the connected TcpServer. 

                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", message);


                ////----------------------------------Receive the TcpServer.response.----------------------------------
                //// Buffer to store the response bytes.
                //data = new byte[256];

                //// String to store the response ASCII representation.
                //var responseData = "";

                //// Read the first batch of the TcpServer response bytes.
                //var bytes = stream.Read(data, 0, data.Length);
                //responseData = Encoding.ASCII.GetString(data, 0, bytes);
                //Console.WriteLine("Received: {0}", responseData);

                // Close everything.
                stream.Close();
                client.Close();
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
