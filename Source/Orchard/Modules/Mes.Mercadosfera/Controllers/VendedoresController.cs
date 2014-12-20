using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Core.Settings.Models;
using Orchard.Logging;
using Orchard.Mvc;
using Orchard.Mvc.Extensions;
using Orchard.Security;
using Orchard.Themes;
using Orchard.Users.Events;
using Orchard.Users.Models;
using Orchard.Users.Services;
using Orchard.Utility.Extensions;


namespace Mes.Mercadosfera.Controllers
{
     [Themed]
    public class VendedoresController : Controller {

         public ILogger Logger { get; set; }
         private readonly IOrchardServices _orchardServices;
         private readonly IMembershipService _membershipService;
         private readonly IUserService _userService;
         private readonly IUserEventHandler _userEventHandler;
         private readonly IAuthenticationService _authenticationService;

         public ActionResult Actualizar()
         {
             Logger.Error("Actualizar");
             return View("ModificarVendedor");
         }

         public ActionResult Registro()
         {
             Logger.Error("Registro");
             return View("RegistrarVendedor");
         }

         int MinPasswordLength
         {
             get
             {
                 return _membershipService.GetSettings().MinRequiredPasswordLength;
             }
         }

         public VendedoresController(IOrchardServices orchardServices, IMembershipService membershipService, IUserService userService, IUserEventHandler userEventHandler, IAuthenticationService authenticationService)
         {
             _orchardServices = orchardServices;
             _membershipService = membershipService;
             _userService = userService;
             _userEventHandler = userEventHandler;
             _authenticationService = authenticationService;
         }

         private bool ValidateRegistration(string userName, string email, string password, string confirmPassword)
         {
             bool validate = !String.IsNullOrEmpty(userName);

             if (String.IsNullOrEmpty(email))
             {
                // ModelState.AddModelError("email", T("You must specify an email address."));
                 validate = false;
             }
             else if (!Regex.IsMatch(email, UserPart.EmailPattern, RegexOptions.IgnoreCase))
             {
                 // http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx    
                // ModelState.AddModelError("email", T("You must specify a valid email address."));
                 validate = false;
             }

             if (!validate)
                 return false;

             if (!_userService.VerifyUserUnicity(userName, email))
             {
              //   ModelState.AddModelError("userExists", T("User with that username and/or email already exists."));
             }
             if (password == null || password.Length < MinPasswordLength)
             {
             //    ModelState.AddModelError("password", T("You must specify a password of {0} or more characters.", MinPasswordLength));
             }
             if (!String.Equals(password, confirmPassword, StringComparison.Ordinal))
             {
                // ModelState.AddModelError("_FORM", T("The new password and confirmation password do not match."));
             }
             return ModelState.IsValid;
         }

         [HttpPost]
         [AlwaysAccessible]
         [ValidateInput(false)]
         public ActionResult Registro(string userName, string email, string password, string confirmPassword)
         {
             // ensure users can register
             var registrationSettings = _orchardServices.WorkContext.CurrentSite.As<RegistrationSettingsPart>();
             if (!registrationSettings.UsersCanRegister)
             {
                 return HttpNotFound();
             }

             ViewData["PasswordLength"] = MinPasswordLength;

             if (ValidateRegistration(userName, email, password, confirmPassword))
             {
                 // Attempt to register the user
                 // No need to report this to IUserEventHandler because _membershipService does that for us
                 var user = _membershipService.CreateUser(new CreateUserParams(userName, password, email, null, null, false));

                 if (user != null)
                 {
                     if (user.As<UserPart>().EmailStatus == UserStatus.Pending)
                     {
                         var siteUrl = _orchardServices.WorkContext.CurrentSite.As<SiteSettings2Part>().BaseUrl;
                         if (String.IsNullOrWhiteSpace(siteUrl))
                         {
                             siteUrl = HttpContext.Request.ToRootUrlString();
                         }

                         _userService.SendChallengeEmail(user.As<UserPart>(), nonce => Url.MakeAbsolute(Url.Action("ChallengeEmail", "Account", new { Area = "Orchard.Users", nonce = nonce }), siteUrl));

                         _userEventHandler.SentChallengeEmail(user);
                      //   return RedirectToAction("ChallengeEmailSent");
                     }

                     if (user.As<UserPart>().RegistrationStatus == UserStatus.Pending)
                     {
                        // return RedirectToAction("RegistrationPending");
                     }

                     _authenticationService.SignIn(user, false /* createPersistentCookie */);
                     return Redirect("~/");
                 }

                // ModelState.AddModelError("_FORM", T(ErrorCodeToString(/*createStatus*/MembershipCreateStatus.ProviderError)));
             }

             // If we got this far, something failed, redisplay form
             var shape = _orchardServices.New.Register();
             return new ShapeResult(this, shape);
         }

    }
}