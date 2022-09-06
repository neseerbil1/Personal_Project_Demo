using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personal_Project_Demo.Models;

namespace Personal_Project_Demo.Controllers
{
    public class EducationController : Controller
        
    {
        PersonalDbEntities personalDbEntities=new PersonalDbEntities();
        // GET: Education
        public ActionResult Index()
        {
            var values = personalDbEntities.TblEducation.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(TblEducation p)
        {
            personalDbEntities.TblEducation.Add(p);
            personalDbEntities.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            var values = personalDbEntities.TblEducation.Where(y => y.EducationID == id).FirstOrDefault();
            personalDbEntities.TblEducation.Remove(values);
            personalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditEducation(int id)
        {
            var value=personalDbEntities.TblEducation.Where(y => y.EducationID == id).FirstOrDefault();
            return View("EditEducation",value);
            
        }
        [HttpPost]
        public ActionResult UpdateEducation(TblEducation p)
        {
            var value = personalDbEntities.TblEducation.Where(y => y.EducationID == p.EducationID).FirstOrDefault();
           value.EducationTitle = p.EducationTitle; 
            value.EducationDate= p.EducationDate;   
            value.EducationDescription= p.EducationDescription;
            personalDbEntities.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}