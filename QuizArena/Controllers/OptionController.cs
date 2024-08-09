using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizArena.Models;

namespace QuizArena.Controllers
{
    public class OptionController : Controller
    {
        QuizAppDbContext con;
        public OptionController(QuizAppDbContext _con)
        {
            this.con = _con;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = con.table_Options.Include(q => q.Question).ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
           
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                List<Question> questions = con.table_Questions.ToList();
                ViewData["_question"] = questions;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
           
        }
        [HttpPost]
        public IActionResult Create(Option _option)
        {
            con.table_Options.Add(_option);
            con.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = con.table_Options.Include(q => q.Question).FirstOrDefault(q => q.Id == id);
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
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = con.table_Options.Include(q => q.Question).FirstOrDefault(q => q.Id == id);
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
            var data = con.table_Options.Find(id);
            con.table_Options.Remove(data);
            con.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                List<Question> questions = con.table_Questions.ToList();
                ViewData["_question"] = questions;
                var data = con.table_Options.Find(id);
                if (data== null)
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
        [HttpPost]
        public IActionResult Edit(int id,Option _option)
        {
            if (id !=_option.Id)
            {
                return NotFound();
            }
            con.table_Options.Update(_option);
            con.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
