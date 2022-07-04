using Assignment3_PRN211.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Assignment3_PRN211.Controllers
{
    public class CategoryController : Controller
    {
        MySaleDBContext db= new MySaleDBContext();
        public IActionResult CategoryList()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Delete(int id)
        {
            var category = db.Categories.Find(id);
            var products = (from p in db.Products
                           where p.CategoryId == id
                           select p).ToList();
            if(products.Count > 0) 
            {
                ViewBag.Mess = "Do not delete category" + category.CategoryName ;
                return RedirectToAction("CategoryList");
            } 
            else
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                return RedirectToAction("CategoryList");
            }
            
        }

        public IActionResult Update(int id)
        {
            var category = db.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(Category c)
        {
            db.Categories.Update(c);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category c)
        {
            db.Categories.Add(c);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}
