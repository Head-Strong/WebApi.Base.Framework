using System.ServiceProcess;

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
        }

        protected override void OnStop()
        {
        }
    }
}
