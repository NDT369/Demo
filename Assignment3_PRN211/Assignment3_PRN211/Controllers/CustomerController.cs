using Microsoft.AspNetCore.Mvc;
using Assignment3_PRN211.Models;
using System.Linq;

namespace Assignment3_PRN211.Controllers
{
    public class CustomerController : Controller
    {
        MySaleDBContext db = new MySaleDBContext();
        public IActionResult customerlist()
        {
            return View(db.Customers.ToList());
        }

        public IActionResult Delete(int id)
        {
           var customer =  db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("customerlist");
        }

        public IActionResult Update(int id)
        {
            var customer = db.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            db.Customers.Update(customer);
            db.SaveChanges();
            return RedirectToAction("customerlist");
;       }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("customerlist");
        }
    }
}
