
using BluTimesheet.Authorization;
using BluTimesheet.Models.AuthenticationBidingModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BluTimesheet.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private ApplicationUserManager userManager;
        
        public AccountController()
        {
            this.userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        
        
        // POST api/Account/Logout
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }
               

        // POST api/Account/ChangePassword
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordModel model)
        {
            IdentityResult result = await userManager
                .ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword,model.NewPassword);

            return Ok(result);
        }

        // POST api/Account/SetPassword
        [Route("SetPassword")]
        public async Task<IHttpActionResult> SetPassword(SetPasswordModel model)
        {
            IdentityResult result = await userManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
            
            return Ok(result);
        }
                
        
        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterModel model)
        {
            var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

            IdentityResult result = await userManager.CreateAsync(user, model.Password);

            return Ok(result);
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Login(LoginModel model)
        {
            // This doen't count login failures towards lockout only two factor authentication
            // To enable password failures to trigger lockout, change to shouldLockout: true
            var result = await Request.GetOwinContext().Get<ApplicationSignInManager>()
                .PasswordSignInAsync(model.Email, model.Password, isPersistent: false, shouldLockout: false);

            return Ok(result);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
                userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helpers

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
        #endregion
    }
}
