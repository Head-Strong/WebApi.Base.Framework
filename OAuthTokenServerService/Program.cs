using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace OAuthTokenServerService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                new OAuthTokenServer()
            };

            ServiceBase.Run(servicesToRun);

            // Testing Purpose
            //var authServerUrl = @"http://localhost:9090";

            //using (WebApp.Start<Startup>(authServerUrl))
            //{
            //    Console.WriteLine("OAuth2 Server is Ready on ... " + authServerUrl);
            //    Console.WriteLine("Press [ENTER] to close the host!");
            //    Console.ReadLine();
            //}
        }
    }
}
