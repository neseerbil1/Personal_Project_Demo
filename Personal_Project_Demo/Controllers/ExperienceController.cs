using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personal_Project_Demo.Models;

namespace Personal_Project_Demo.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        PersonalDbEntities personalDbEntities=new PersonalDbEntities(); 
        public ActionResult Index()
        {
            var values=personalDbEntities.TblExperience.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(TblExperience p)
        {
            personalDbEntities.TblExperience.Add(p);
            personalDbEntities.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperience(int id)
        {
            var values = personalDbEntities.TblExperience.Where(y => y.ExperienceID == id).FirstOrDefault();
            personalDbEntities.TblExperience.Remove(values);
            personalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
       
        public ActionResult EditExperience(int id)
        {
            var value = personalDbEntities.TblExperience.Where(x => x.ExperienceID == id).FirstOrDefault();

            return View("EditExperience", value);

        }
        [HttpPost]
        public ActionResult UpdateExperience(TblExperience p)

        {
            var value = personalDbEntities.TblExperience.Where(x => x.ExperienceID == p.ExperienceID).FirstOrDefault();
            value.ExperienceTitle = p.ExperienceTitle;
           value.ExperienceDate = p.ExperienceDate;
            value.ExperienceDescription = p.ExperienceDescription;
            personalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}