using DropZone.API.Infrastructure;
using DropZone.API.Models;
using DropZone.Core.Managers.UserManager;
using DropZone.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace DropZone.API.Controllers
{
    [RoutePrefix("Users")]
    public class UserController: BaseApiController
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        //[Authorize]
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> GetUser(long id)
        {
            try
            {
                var result = await _userManager.GetUserAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[Authorize]
        [HttpGet]
        [Route("JumpBook/{id:long}")]
        public async Task<IHttpActionResult> GetUserJumpBook(long id)
        {
            try
            {
                var result = await _userManager.GetUserJumpBookAsync(id);

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
        public async Task<IHttpActionResult> GetUsers()
        {
            try
            {
                var result = await _userManager.GetUsersAsync();

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
        public async Task<IHttpActionResult> GetDropZoneUsers(long id)
        {
            try
            {
                var result = await _userManager.GetDropZoneUsersAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[Authorize]
        [HttpGet]
        [Route("Sportsmen")]
        public async Task<IHttpActionResult> GetSportsmen()
        {
            try
            {
                var result = await _userManager.GetSportsmenAsync();

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
        public async Task<IHttpActionResult> EditUser(UserModel model)
        {
            try
            {
                var result = await _userManager.EditUserAsync(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[Authorize]
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(UserModel model)
        {
            try
            {
                await _userManager.ChangeUserPasswordAsync(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[Authorize]
        [HttpPost]
        [Route("Role/Edit")]
        public async Task<IHttpActionResult> EditRole(EditRoleModel model)
        {
            try
            {
                await _userManager.ChangeUserRoleAsync(model.UserId, model.RoleId);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[Authorize]
        [HttpPost]
        [Route("Delete")]
        public async Task<IHttpActionResult> DeleteUser(long userId)
        {
            try
            {
                await _userManager.DeleteUserAsync(userId);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}