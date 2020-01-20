using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Data;
using SocialMedia.Web.Models;

namespace SocialMedia.Web.Controllers
{
    public class SettingsController : Controller
    {
        SocialMediaDbContext _dbcontext;
        int UserId;
        IHttpContextAccessor _httpContextAccessor;

        private readonly IHostingEnvironment _environment;



        public SettingsController(IHostingEnvironment environment, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _environment = environment;

            _dbcontext = new SocialMediaDbContext();

            var cookievalue = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];
            UserId = Int32.Parse(cookievalue);
        }

        [Authorize]
        public IActionResult Index()
        {
            try
            {
                var model = _dbcontext.User.Single(c => c.Id == UserId);
                return View(model);
            }
            catch(Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult UpdateSettings(SettingsModel model)
        {
            try
            {

                string fileName = "";

                var user = _dbcontext.User.Single(c => c.Id == UserId);
                if (model.Username != null && _dbcontext.User.Where(c=> c.Username == model.Username).Count() == 0)
                    user.Username = model.Username;
                if (model.Name != null)
                    user.Name = model.Name;
                if (model.Surname != null)
                    user.Surname = model.Surname;
                if (model.Password != null)
                    user.Password = model.Password;
                if (model.Email != null)
                    user.Email = model.Email;


                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                    fileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, fileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    user.PhotoPath = fileName;

                }

                user.Location = model.Location;
                user.Bio = model.Bio;

                _dbcontext.SaveChanges();


                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}