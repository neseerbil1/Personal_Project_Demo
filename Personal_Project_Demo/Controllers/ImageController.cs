using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personal_Project_Demo.Models;

namespace Personal_Project_Demo.Controllers
{
    public class ImageController : Controller
    {
        PersonalDbEntities personalDbEntities = new PersonalDbEntities();
        // GET: Image
        public ActionResult Index()
        {
            var values = personalDbEntities.TblImage.ToList();
            return View(values);
        }
        [HttpPost]
        public ActionResult AddImage(TblImage p)
        {

            personalDbEntities.TblImage.Add(p);
            personalDbEntities.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult AddImage()
        {

            return View();

        }
        public ActionResult DeleteImage(int id)
        {
            var value = personalDbEntities.TblImage.Where(x => x.ImageID == id).FirstOrDefault();
            personalDbEntities.TblImage.Remove(value);
            personalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditImage(int id)
        {
            var value = personalDbEntities.TblImage.Where(x => x.ImageID == id).FirstOrDefault();

            return View(value);

        }
        public ActionResult UpdateImage(TblImage p)

        {
            var dnym = personalDbEntities.TblImage.Where(x => x.ImageID == p.ImageID).FirstOrDefault();
            dnym.ImageUrl = p.ImageUrl;
            dnym.ImageDescription = p.ImageDescription;
            personalDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}