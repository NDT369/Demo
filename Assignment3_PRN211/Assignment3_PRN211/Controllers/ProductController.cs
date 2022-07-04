using Assignment3_PRN211.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Assignment3_PRN211.Controllers
{
    public class ProductController : Controller
    {
        MySaleDBContext db = new MySaleDBContext();
        public IActionResult Index()
        {
            ViewBag.Categories = db.Categories;
            return View(db.Products.ToList());
        }
        [HttpPost]
        public IActionResult Index(int cateId)
        {
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.SelectedCateId = cateId;
            var products = db.Products.ToList();    
            if (cateId != 0)
            {
                products = (from p in db.Products
                                where p.CategoryId == cateId
                                select p).ToList();
            }
            return View(products);
        }

        public IActionResult Update(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product p)
        {
            db.Products.Update(p);
            db.SaveChanges(true);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var p = db.Products.Find(id);
            db.Products.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
