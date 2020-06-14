using AutoMapper;
using DropZone.API.Infrastructure;
using DropZone.Core.Managers.ParachuteManager;
using DropZone.Core.Models;
using DropZone.Database.Models;
using DropZone.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace DropZone.API.Controllers
{
    [RoutePrefix("Parachutes")]
    public class ParachuteController : BaseApiController
    {
        private readonly IParachuteManager _parachuteManager;

        public ParachuteController(IParachuteManager parachuteManager)
        {
            _parachuteManager = parachuteManager;
        }

        [Authorize]
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> GetParachute(long id)
        {
            try
            {
                var result = await _parachuteManager.GetParachuteSystemAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetParachutes()
        {
            try
            {
                var result = await _parachuteManager.GetParachuteSystemsAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("Edit")]
        public async Task<IHttpActionResult> EditParachute(ParachuteSystemModel model)
        {
            try
            {
                var result = await _parachuteManager.EditParachuteSystemAsync(model, UserModel.Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("Create")]
        public async Task<IHttpActionResult> CreateParachute(ParachuteSystemModel model)
        {
            try
            {
                var result = await _parachuteManager.CreateParachuteSystemAsync(model, UserModel.Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}