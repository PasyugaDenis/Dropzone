using DropZone.Core.Managers.AuthorizationManager;
using DropZone.Core.Models;
using DropZone.API.Infrastructure;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using DropZone.Core.Managers.DropZoneManager;
using DropZone.API.Models;

namespace DropZone.API.Controllers
{
    [RoutePrefix("DropZones")]
    public class DropZoneController: BaseApiController
    {
        private readonly IDropZoneManager _dropZoneManager;

        public DropZoneController(IDropZoneManager dropZoneManager)
        {
            _dropZoneManager = dropZoneManager;
        }

        //[Authorize]
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> GetDropZone(long id)
        {
            try
            {
                var result = await _dropZoneManager.GetDropZoneAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[Authorize]
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetDropZones()
        {
            try
            {
                var result = await _dropZoneManager.GetDropZonesAsync();

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
        public async Task<IHttpActionResult> CreateDropZone(CreateDropZoneModel model)
        {
            try
            {
                var result = await _dropZoneManager.CreateDropZoneAsync(model.DropZone, model.AdminEmail);

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
        public async Task<IHttpActionResult> EditDropZone(DropZoneModel model)
        {
            try
            {
                var result = await _dropZoneManager.EditDropZoneAsync(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}