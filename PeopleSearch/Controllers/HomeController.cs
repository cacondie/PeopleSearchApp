using PeopleSearch.DataLayer;
using PeopleSearch.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace PeopleSearch.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork _db;
        public HomeController()
        {
            _db = new UnitOfWork(new EntityContext());
        }
        public HomeController(IUnitOfWork _unit)
        {
            _db = _unit;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            //WriteSeedFileToLocalDrive();
            var model = _db.Persons.FindAll()
                                    .Take(10)
                                    .ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string search = null)
        {
            Thread.Sleep(5000);
            var model = _db.Persons
                .Find(p => search == null || p.LastName.StartsWith(search) || p.FirstName.StartsWith(search))
                .Take(25)
                .ToList();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Persons", model);
            }
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if(_db != null)
            {
                _db.Dispose();
            }
        }

        /// <summary>
        /// This is needed for seeding the database with the large dataset that I am wanting to use. 
        /// </summary>
        private void WriteSeedFileToLocalDrive()
        {
            string result = HttpContext.Server.MapPath("~/App_Data/SeedData.json");
            string localFile = string.Format("{0}\\PeopleSearch", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            var di = new System.IO.DirectoryInfo(localFile);
            var currentFi = new System.IO.FileInfo(result);
            if(!di.Exists)
            {
                di.Create();
            }
            var fi = new System.IO.FileInfo(string.Format("{0}\\{1}", di.FullName, "SeedData.json"));
            if(fi.Exists|| System.IO.File.Exists(fi.FullName))
            {
                fi.Delete();
            }
            currentFi.CopyTo(fi.FullName);
        }

    }
}