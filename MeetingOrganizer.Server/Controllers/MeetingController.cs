using AutoMapper;
using MeetingOrganizer.Logging;
using MeetingOrganizer.Server.Entities;
using MeetingOrganizer.Server.Models;
using MeetingOrganizer.Server.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace MeetingOrganizer.Server.Controllers
{
    [RoutePrefix("api/meetings")]
    public class MeetingController : ApiController
    {
        private readonly IRepository<Meeting> meetingRepository;
        private readonly ILogger logger;

        public MeetingController(IRepository<Meeting> meetingRepository, ILogger logger)
        {
            this.meetingRepository = meetingRepository;
            this.logger = logger;
        }

        [HttpGet, Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var meetingEntites = await meetingRepository.GetAllAsync();
            logger.Log($"Getting all meetings (Count: {meetingEntites.Count})", Priority.Low);
            return Ok(Mapper.Map<IList<MeetingModel>>(meetingEntites));
        }

        [HttpGet, Route("{meetingId:int}")]
        public async Task<IHttpActionResult> Get(int meetingId)
        {
            if (await meetingRepository.ContainsAsync(meetingId))
            {
                var meetingEntity = await meetingRepository.GetAsync(meetingId);
                logger.Log($"Getting meeting with id: '{meetingId}'", Priority.Low);
                return Ok(Mapper.Map<MeetingModel>(meetingEntity));
            }

            logger.Log($"Meeting plan not found with id: '{meetingId}'", Priority.Medium);
            return NotFound();
        }
        
        [HttpPost, Route("plan")]
        public async Task<IHttpActionResult> Plan(MeetingModel meetingModel)
        {
            Validate(meetingModel);

            if (meetingModel == null || !ModelState.IsValid)
            {
                logger.Log("Cannot plan a meeting. See model state", Priority.High);
                return BadRequest(ModelState);
            }

            var meetingEntity = Mapper.Map<Meeting>(meetingModel);
            await meetingRepository.AddAsync(meetingEntity);

            logger.Log("Meeting planned successfully", Priority.Low);
            return Ok();
        }

        [HttpPost, Route("{meetingId:int}/delete")]
        public async Task<IHttpActionResult> Delete(int meetingId)
        {
            if (await meetingRepository.ContainsAsync(meetingId))
            {
                await meetingRepository.DeleteAsync(meetingId);
                logger.Log($"Meeting (id: {meetingId}) deleted successfully", Priority.Medium);
                return Ok();
            }

            return NotFound();
        }

        [HttpPost, Route("update")]
        public async Task<IHttpActionResult> Update(MeetingModel meetingModel)
        {
            Validate(meetingModel);

            if (meetingModel == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await meetingRepository.ContainsAsync(meetingModel.Id))
            {
                var meetingEntity = await meetingRepository.GetAsync(meetingModel.Id);
                Mapper.Map(meetingModel, meetingEntity);
                await meetingRepository.UpdateAsync(meetingEntity);
                logger.Log($"Meeting (id: {meetingModel.Id} updated successfully", Priority.Medium);
                return Ok(meetingModel);
            }

            return NotFound();
        }
    }
}
