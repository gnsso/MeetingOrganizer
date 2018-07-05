using MeetingOrganizer.Logging;
using MeetingOrganizer.Server.Entities;
using MeetingOrganizer.Server.Repositories;
using System;

using Unity;

namespace MeetingOrganizer.Server
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer Container => container.Value;

        public static void RegisterTypes(IUnityContainer container)
        {
            // register repsitories
            container.RegisterType<IRepository<Meeting>, MeetingRepository>();

            // register logger
            container.RegisterType<ILogger, DebugLogger>();
        }
    }
}