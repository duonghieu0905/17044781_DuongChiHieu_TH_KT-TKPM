﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = new WebClient().DownloadString("https://localhost:44389/api/student/getall");
            Console.WriteLine(json);
            Console.ReadLine();
        }
    }
}
