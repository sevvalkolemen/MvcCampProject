using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCampProject.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutvalues = abm.GetList();
            return View(aboutvalues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult ChangeStatus(int id)
        {
            var aboutvalue = abm.GetById(id);
            if (aboutvalue.AboutStatus)
            {
                aboutvalue.AboutStatus = false;
            }
            else
            {
                aboutvalue.AboutStatus = true;
            }
            abm.AboutUpdate(aboutvalue);
            return RedirectToAction("Index");
        }
    }
}