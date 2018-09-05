using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace F1ConsoleApp
{
    class Program
    {
        private const int listenPort = 20777;
        

        static void Main(string[] args)
        {
            /*
            Race race = new Race();
            using (StreamReader r = new StreamReader(@"C:\Users\Public\TestFolder\Race.txt"))
            {
                string json = r.ReadToEnd();
                race = JsonConvert.DeserializeObject<Race>(json);
            }

            foreach(UDPPacket r in race.race)
            {
                Console.WriteLine(r.M_lapDistance);
            }
            bool done = false;*/
            
                ///***************************
            
            bool done = false;
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
            
            byte[] receive_byte_array;
            try

            {
                Console.WriteLine("Waiting for broadcast");
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\Race.txt", true))
                {

                    while (!done)
                {                    
                    // this is the line of code that receives the broadcase message.
                    // It calls the receive function from the object listener (class UdpClient)
                    // It passes to listener the end point groupEP.
                    // It puts the data from the broadcast message into the byte array
                    // named received_byte_array.
                    // I don't know why this uses the class UdpClient and IPEndPoint like this.
                    // Contrast this with the talker code. It does not pass by reference.
                    // Note that this is a synchronous or blocking call.

                    receive_byte_array = listener.Receive(ref groupEP);
                    //var packet = BytesToStructure<UDPPacket>(receive_byte_array);
                    UDPPacket pack = new UDPPacket(receive_byte_array);
                    string output = JsonConvert.SerializeObject(pack);
                     file.WriteLine(output);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }
            
        }        
    }
}
