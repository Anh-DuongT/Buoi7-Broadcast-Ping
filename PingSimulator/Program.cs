using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BtPing
{
    class Program
    {
        public static void LocalPingTimeout(string a)
        {
            Ping pingSender = new Ping();
            IPAddress address = IPAddress.Parse(a);

            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            int timeout = 10000;
            PingReply reply = pingSender.Send(address, timeout, buffer);

            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Address: {0}", reply.Address.ToString());
                Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
            }
            else
            {
                Console.WriteLine(reply.Status);
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Nhap IP: ");
            string a;
            a = Console.ReadLine();
            Console.WriteLine();
            LocalPingTimeout(a);
        }
    }
}
