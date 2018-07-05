using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeetingOrganizer.Client.Startup))]
namespace MeetingOrganizer.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
