using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND_JSON
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string serverAddress = "http://localhost:8081";
            RunServer(serverAddress);
        }

        private static void RunServer(string serverAddress)
        {
            using (WebApp.Start<Startup>(serverAddress))
            {
                Console.Write("OWIN server started.");

                Console.ReadLine();
            }
        }
    }
}
