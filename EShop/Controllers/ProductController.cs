using EShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private Btap2Entities db = new Btap2Entities();
        public ActionResult Index()
        {
            List<Product> product = db.Products.ToList();
            return View(product);
        }
        public ActionResult Create()
        {
            var categories = db.Categories.ToList();
            ViewBag.CategoryId = new SelectList(categories, "id", "name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase upLoad)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                if (upLoad != null && upLoad.ContentLength > 0)
                {
                    int id = product.id; 
                    string _FileName = "";
                    int index = upLoad.FileName.LastIndexOf('.');
                    _FileName = "pr" + id.ToString() + upLoad.FileName.Substring(index);
                    string _path = Path.Combine(Server.MapPath("~/Upload"), _FileName);
                    upLoad.SaveAs(_path);
                    Product images = db.Products.FirstOrDefault(x => x.id == id);
                    if (images != null)
                    {
                        images.image = _FileName;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            var categories = db.Categories.ToList();
            ViewBag.CategoryId = new SelectList(categories, "id", "name");
            return View(product);
        }

        public ActionResult Edit(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = new SelectList(db.Categories, "id", "name");

            return View(product); 
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase upLoad)
        {
            if (ModelState.IsValid)
            {
                var product1 = db.Products.Find(product.id);
                if (product1 != null)
                {
                    db.Entry(product1).CurrentValues.SetValues(product);
                    if (upLoad != null && upLoad.ContentLength > 0)
                    {
                        string _FileName = "";
                        int index = upLoad.FileName.LastIndexOf('.');
                        _FileName = "pr" + product.id.ToString() + upLoad.FileName.Substring(index);
                        string _path = Path.Combine(Server.MapPath("~/Upload"), _FileName);
                        upLoad.SaveAs(_path);
                        product1.image = _FileName;
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "id", "name", product.categoryId);
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult SearchName(string searchTerm)
        {
            var products = db.Products
                .Where(p => p.name.Contains(searchTerm))
                .ToList();

            return View("Index", products);
        }
        public ActionResult Search(string searchTerm)
        {
            var filteredProducts = db.Products
                .Where(p => p.Category.name.Contains(searchTerm))
                .ToList();
        
            return View("Index", filteredProducts);
        }
    }
}
