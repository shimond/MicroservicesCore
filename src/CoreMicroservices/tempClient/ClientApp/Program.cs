﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using Polly;
//using Polly.Extensions.Http;

namespace ClientApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

       
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(host => host.AddJsonFile(Path.GetFullPath("../../services-url.json")))
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHttpClient<Worker>("a",x=>x.BaseAddress = new Uri("http://walla.co.il"));
                    //.AddPolicyHandler(GetPolicy());
                    services.AddHostedService<Worker>();
                });
    }
}
