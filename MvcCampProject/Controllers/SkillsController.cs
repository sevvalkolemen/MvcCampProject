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
    public class SkillsController : Controller
    {
        SkillManager sm = new SkillManager(new EfSkillDal());
        public ActionResult Index()
        {
            var values = sm.GetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Skill skill)
        {
            sm.SkillAdd(skill);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var value = sm.GetById(id);
            sm.SkillDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = sm.GetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Update(Skill skill)
        {
            sm.SkillUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}