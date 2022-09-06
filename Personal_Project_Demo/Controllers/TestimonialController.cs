using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personal_Project_Demo.Models;

namespace Personal_Project_Demo.Controllers
{
    public class TestimonialController : Controller
    {
        PersonalDbEntities personalDbEntities = new PersonalDbEntities();
        // GET: Testimonial
        public ActionResult Index()
        {
            var values = personalDbEntities.TblTestimonial.ToList();
            return View(values);
        }
        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonial p)
        {

            personalDbEntities.TblTestimonial.Add(p);
            personalDbEntities.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult AddTestimonial()
        {

            return View();

        }
        public ActionResult DeleteTestimonial(int id)
        {
            var value = personalDbEntities.TblTestimonial.Where(x => x.TestimonialID == id).FirstOrDefault();
            personalDbEntities.TblTestimonial.Remove(value);
            personalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditTestimonial(int id)
        {
            var value =personalDbEntities.TblTestimonial.Where(x => x.TestimonialID == id).FirstOrDefault();

            return View("EditTestimonial",value);

        }
        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial p)

        {
            var value = personalDbEntities.TblTestimonial.Where(x => x.TestimonialID == p.TestimonialID).FirstOrDefault();
           value.TestimonialName = p.TestimonialName;
            value.TestimonialImage = p.TestimonialImage;
            value.TestimonialTitle = p.TestimonialTitle;
           value.TestimonialDescription = p.TestimonialDescription;
            personalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}