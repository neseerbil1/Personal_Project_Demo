using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personal_Project_Demo.Models;

namespace Personal_Project_Demo.Controllers
{
    public class FeatureController : Controller
    {
        PersonalDbEntities personalDbEntities = new PersonalDbEntities();
        // GET: Feature
        public ActionResult Index()
        {
            var values = personalDbEntities.TblFeature.ToList();
            return View(values);
        }
        [HttpPost]
        public ActionResult AddFeature(TblFeature p)
        {

            personalDbEntities.TblFeature.Add(p);
            personalDbEntities.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult AddFeature()
        {

            return View();

        }
        public ActionResult DeleteFeature(int id)
        {
            var value = personalDbEntities.TblFeature.Where(x => x.FeatureID == id).FirstOrDefault();
            personalDbEntities.TblFeature.Remove(value);
            personalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditFeature(int id)
        {
            var dnym = personalDbEntities.TblFeature.Where(x => x.FeatureID == id).FirstOrDefault();

            return View("EditFeature", dnym);

        }
        [HttpPost]
        public ActionResult UpdateFeature(TblFeature p)

        {
            var dnym = personalDbEntities.TblFeature.Where(x => x.FeatureID == p.FeatureID).FirstOrDefault();
            dnym.FeatureTitle = p.FeatureTitle;
            dnym.FeatureLogo = p.FeatureLogo;
            dnym.FeatureDescription = p.FeatureDescription;
            personalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}