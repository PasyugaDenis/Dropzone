using DropZone.API.Infrastructure;
using DropZone.Core.Managers.AircraftManager;
using DropZone.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace DropZone.API.Controllers
{
    [RoutePrefix("DropZones")]
    public class AircraftController: BaseApiController
    {
        private readonly IAircraftManager _aircraftManager;

        public AircraftController(IAircraftManager aircraftManager)
        {
            _aircraftManager = aircraftManager;
        }

        //[Authorize]
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAircrafts()
        {
            try
            {
                var result = await _aircraftManager.GetAircraftsAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[Authorize]
        [HttpGet]
        [Route("DropZone/{id:long}")]
        public async Task<IHttpActionResult> GetDropZoneAircrafts(long id)
        {
            try
            {
                var result = await _aircraftManager.GetDropZoneAircraftsAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[Authorize]
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> GetAircraft(long id)
        {
            try
            {
                var result = await _aircraftManager.GetAircraftAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[Authorize]
        [HttpPost]
        [Route("Create")]
        public async Task<IHttpActionResult> CreateAircraft(AircraftModel model)
        {
            try
            {
                var result = await _aircraftManager.CreateAircraftAsync(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[Authorize]
        [HttpPost]
        [Route("Edit")]
        public async Task<IHttpActionResult> EditAircraft(AircraftModel model)
        {
            try
            {
                var result = await _aircraftManager.EditAircraftAsync(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[Authorize]
        [HttpPost]
        [Route("Delete")]
        public async Task<IHttpActionResult> DeleteAircraft(long id)
        {
            try
            {
                await _aircraftManager.DeleteAircraftAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}