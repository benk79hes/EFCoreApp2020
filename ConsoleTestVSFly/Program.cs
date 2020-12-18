using System;
using System.Net.Http;

namespace ConsoleTestVSFly
{
    class Program
    {
        static void Main(string[] args)
        {
            var http = new HttpClient();
            var client = new swaggerClient("https://localhost:44390/", http);

        }
    }
}
