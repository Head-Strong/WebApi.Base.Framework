using System;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;
using WebApi.Custom.Configuration;

namespace WebApi.Owin.SelfHost
{
    public partial class OwinWindowsService : ServiceBase
    {
        public OwinWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var url = CustomConfigReader.SelfHostUrl;

            WebApp.Start<StartUp>(url);

        }

        protected override void OnStop()
        {

        }
    }
}
