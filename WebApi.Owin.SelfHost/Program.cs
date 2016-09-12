using System.ServiceProcess;

namespace WebApi.Owin.SelfHost
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
                new OwinWindowsService()
            };

            ServiceBase.Run(servicesToRun);
        }
    }
}
