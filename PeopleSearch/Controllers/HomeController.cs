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
        
        public ActionResult Index(string search = null)
        {
            if (_db is EntityContext)
            {
                WriteSeedFileToLocalDrive();
            }
            Thread.Sleep(2500);
            var model = _db.Persons
                .Find(p => search == null || p.LastName.Contains(search) || p.FirstName.Contains(search) || p.FirstName + " " + p.LastName==search)
                .Take(25)
                .OrderBy(p=>p.LastName)
                .ThenBy(p=>p.FirstName)
                .ToList();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Persons", model);
            }
            return View(model);
        }

        public ActionResult AutoComplete(string term)
        {
            var model = _db.Persons.Find(p => p.FirstName.Contains(term) || p.LastName.Contains(term))
                                    .Take(10)
                                    .Select(p => new { label = p.FullName });
            return Json(model, JsonRequestBehavior.AllowGet);
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
