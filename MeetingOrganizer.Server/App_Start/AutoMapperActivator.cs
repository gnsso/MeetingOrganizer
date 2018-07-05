using AutoMapper;
using MeetingOrganizer.Server.Entities;
using MeetingOrganizer.Server.Models;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MeetingOrganizer.Server.AutoMapperActivator), nameof(MeetingOrganizer.Server.AutoMapperActivator.Start))]

namespace MeetingOrganizer.Server
{
    public static class AutoMapperActivator
    {
        public static void Start()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Meeting, MeetingModel>();
                config.CreateMap<MeetingModel, Meeting>();
            });
        }
    }
}