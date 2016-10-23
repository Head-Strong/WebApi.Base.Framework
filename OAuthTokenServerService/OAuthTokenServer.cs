using System.Configuration;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;

namespace OAuthTokenServerService
{
    public partial class OAuthTokenServer : ServiceBase
    {
        public OAuthTokenServer()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var url = ConfigurationManager.AppSettings["SelfHostUrl"];

            WebApp.Start<Startup>(url);
        }

        protected override void OnStop()
        {
        }
    }
}
