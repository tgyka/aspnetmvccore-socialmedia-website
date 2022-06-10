using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.User;
using SocialMedia.Data;
using SocialMedia.Helper.Crypto;
using SocialMedia.Helper.File;
using SocialMedia.Model;
using SocialMedia.Web.Models;

namespace SocialMedia.Web.Controllers
{
    [Authorize]
    public class SettingController : Controller
    {
        private readonly int _userId;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IFileHelper _fileHelper;
        private readonly ICryptoHelper _cryptoHelper;
        private readonly IHostingEnvironment _environment;

        public SettingController(IHostingEnvironment environment, 
            IHttpContextAccessor httpContextAccessor,
            IUserService userService,
            IFileHelper fileHelper,
            ICryptoHelper cryptoHelper)
        {
            _httpContextAccessor = httpContextAccessor;
            _environment = environment;

            var cookievalue = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];
            _userId = Int32.Parse(cookievalue);

            _userService = userService;

            _fileHelper = fileHelper;
            _cryptoHelper = cryptoHelper;
        }

        public IActionResult Index()
        {
            try
            {
                var userModel = _userService.GetUser(_userId);
                return View(userModel);
            }
            catch(Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSettings(SettingsModel settings)
        {

            var userHasExist = await _userService.UserHasExist(settings.Username);

            if(userHasExist)
            {
                throw new Exception("Username has exist");
            }

            var userModel = new User();

            if (settings.Username != null)
                userModel.Username = settings.Username;

            if (settings.Name != null)
                userModel.Name = settings.Name;

            if (settings.Surname != null)
                userModel.Surname = settings.Surname;

            if (userModel.Password != null)
                userModel.Password = _cryptoHelper.Encrypt(settings.Password);

            if (settings.Email != null)
                userModel.Email = settings.Email;


            if (settings.Photo != null)
            {
                userModel.PhotoPath = await _fileHelper.UploadFile(_environment, settings.Photo);
            }

            userModel.Location = settings.Location;
            userModel.Bio = settings.Bio;

            await _userService.UpdateUser(userModel);


            return RedirectToAction("Index");
        }
    }
}