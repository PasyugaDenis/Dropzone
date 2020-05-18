using DropZone.Core.Managers.AuthorizationManager;
using DropZone.Core.Models;
using DropZone.API.Infrastructure;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace DropZone.API.Controllers
{
    [RoutePrefix("")]
    public class AccountController : BaseApiController
    {
        private readonly IAuthorizationManager _authorizationManager;

        public AccountController(
            IAuthorizationManager authorizationManager)
        {
            _authorizationManager = authorizationManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Authorize")]
        public async Task<IHttpActionResult> Authorize(UserModel model)
        {
            try
            {
                var authModel = await _authorizationManager.AuthorizeAsync(model.Email, model.Password);

                return Ok(authModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel model)
        {
            try
            {
                var authModel = await _authorizationManager.RegisterAsync(model);

                return Ok(authModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
