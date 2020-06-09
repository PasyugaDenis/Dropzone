using AutoMapper;
using DropZone.API.Infrastructure;
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
        private readonly IRepository _repository;

        public ParachuteController(IRepository repository)
        {
            _repository = repository;
        }

        //[Authorize]
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> GetParachute(long id)
        {
            try
            {
                var parachuteSystem = await _repository.GetAsync<ParachuteSystem>(id);

                var result = Mapper.Map<ParachuteSystemModel>(parachuteSystem);
                result.MainParachute = Mapper.Map<ParachuteModel>(parachuteSystem.MainParachute);
                result.ReserveParachute = Mapper.Map<ParachuteModel>(parachuteSystem.ReserveParachute);
                result.AAD = Mapper.Map<AADModel>(parachuteSystem.AAD);
                result.AAD.AADType = Mapper.Map<AADTypeModel>(parachuteSystem.AAD.AADType);
                result.Satchel = Mapper.Map<SatchelModel>(parachuteSystem.Satchel);

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
        public async Task<IHttpActionResult> GetParachutes()
        {
            try
            {
                var result = new List<ParachuteSystemModel>();
                var parachuteSystems = await _repository.GetAsync<ParachuteSystem>();

                foreach(var item in parachuteSystems)
                {
                    var model = Mapper.Map<ParachuteSystemModel>(item);
                    model.MainParachute = Mapper.Map<ParachuteModel>(item.MainParachute);
                    model.MainParachute.Manufacturer = Mapper.Map<ManufacturerModel>(item.MainParachute.Manufacturer);
                    model.ReserveParachute = Mapper.Map<ParachuteModel>(item.ReserveParachute);

                    result.Add(model);
                }

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
        public async Task<IHttpActionResult> EditParachute(ParachuteSystem model)
        {
            try
            {
                var parachuteSystem = await _repository.GetAsync<ParachuteSystem>(model.Id);
                var mainParachute = await _repository.GetAsync<Parachute>(model.MainParachuteId.Value);
                var reserveParachute = await _repository.GetAsync<Parachute>(model.ReserveParachuteId.Value);
                var aad = await _repository.GetAsync<AAD>(model.AADId.Value);
                var satchel = await _repository.GetAsync<Satchel>(model.SatchelId.Value);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[Authorize]
        [HttpPost]
        [Route("Create")]
        public async Task<IHttpActionResult> CreateParachute(ParachuteSystem model)
        {
            try
            {
                var parachuteSystem = await _repository.GetAsync<ParachuteSystem>(model.Id);
                var mainParachute = await _repository.GetAsync<Parachute>(model.MainParachuteId.Value);
                var reserveParachute = await _repository.GetAsync<Parachute>(model.ReserveParachuteId.Value);
                var aad = await _repository.GetAsync<AAD>(model.AADId.Value);
                var satchel = await _repository.GetAsync<Satchel>(model.SatchelId.Value);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}