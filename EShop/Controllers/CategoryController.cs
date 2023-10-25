using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Btap2Entities db = new Btap2Entities();
        public ActionResult Index()
        {
            List<Category> category = db.Categories.ToList();
            return View(category);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                Category category1 = db.Categories.Find(category.id);
                if (category1 == null)
                {
                    return HttpNotFound();
                }
                category1.name = category.name;
                category1.nameVN = category.nameVN;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

            }
            return View(category);
        }
        public ActionResult Delete(int id)
        {
            var category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}