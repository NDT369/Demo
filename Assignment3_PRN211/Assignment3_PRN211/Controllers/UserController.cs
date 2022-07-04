using Microsoft.AspNetCore.Mvc;
using Assignment3_PRN211.Models;
using System.Linq;

namespace Assignment3_PRN211.Controllers
{
    public class UserController : Controller
    {
        MySaleDBContext  db = new MySaleDBContext();    
        public IActionResult UserList()
        {
            return View(db.Users.ToList());
        }

        public IActionResult Update(string account)
        {
           var user = db.Users.Find(account);
            return View(user);
        }

        [HttpPost]

        public IActionResult Update(User user)
        {
            db.Users.Update(user);
            db.SaveChanges();
            return RedirectToAction("UserList");
        }

        public IActionResult Delete(string account)
        {
            var user = db.Users.Find(account);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("UserList");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            var u = db.Users.Find(user.Account);
            if (u == null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("UserList");
            }
            else
            {
                ViewBag.Mess = "Account is already exists";
                return View();
            }
        }
    }
}
