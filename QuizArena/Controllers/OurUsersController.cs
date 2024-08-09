using Humanizer;
using Microsoft.AspNetCore.Mvc;
using QuizArena.Models;

namespace QuizArena.Controllers
{
    public class OurUsersController : Controller
    {
        QuizAppDbContext _con;
        public OurUsersController(QuizAppDbContext con)
        {
            this._con = con;
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
           
        }
        [HttpPost]
        public IActionResult Create(User _user)
        {
            _con.table_Users.Add(_user);
            _con.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = _con.table_Users.ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
          
        }
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = _con.table_Users.Where(q => q.UserId == id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Deletetwo(int id)
        {
            var data = _con.table_Users.Find(id);
            _con.table_Users.Remove(data);
            _con.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = _con.table_Users.Find(id);
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }

        }
        [HttpPost]
        public IActionResult Edit(User _user)
        {
            _con.table_Users.Update(_user);
            _con.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = _con.table_Users.Where(q => q.UserId == id).FirstOrDefault();
                if (data == null)
                {
                    return NotFound();
                }
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }

        }
    }
}
