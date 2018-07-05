using System.Web.Http;

using Unity.AspNet.WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MeetingOrganizer.Server.UnityWebApiActivator), nameof(MeetingOrganizer.Server.UnityWebApiActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(MeetingOrganizer.Server.UnityWebApiActivator), nameof(MeetingOrganizer.Server.UnityWebApiActivator.Shutdown))]

namespace MeetingOrganizer.Server
{
    public static class UnityWebApiActivator
    {
        public static void Start() 
        {
            var resolver = new UnityDependencyResolver(UnityConfig.Container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
        
        public static void Shutdown()
        {
            UnityConfig.Container.Dispose();
        }
    }
}