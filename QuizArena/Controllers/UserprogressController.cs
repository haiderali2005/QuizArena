using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizArena.Models;

namespace QuizArena.Controllers
{
    public class UserprogressController : Controller
    {
        QuizAppDbContext con;
        public UserprogressController(QuizAppDbContext _con)
        {
            this.con = _con;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = con.table_UserProgresses.Include(q => q.Quiz).ToList();
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
                List<Quiz> quizzes = con.table_Quizzes.ToList();
                ViewData["_quiz"] = quizzes;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
           
        }
        [HttpPost]
        public IActionResult Create(UserProgress progress)
        {

            con.table_UserProgresses.Add(progress);
            con.SaveChanges();
            return RedirectToAction("Index");


        }
        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = con.table_UserProgresses.Include(q => q.Quiz).FirstOrDefault(q => q.Id == id);
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
                var data = con.table_UserProgresses.Include(q => q.Quiz).FirstOrDefault(q => q.Id == id);
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
            var data = con.table_UserProgresses.Find(id);
            con.table_UserProgresses.Remove(data);
            con.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                List<Quiz> quizzes = con.table_Quizzes.ToList();
                ViewData["_quiz"] = quizzes;
                var data = con.table_UserProgresses.Find(id);
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
           
        }
        [HttpPost]
        public IActionResult Edit(UserProgress progress,int id)
        {
            if (id != progress.Id)
            {
                return NotFound();
            }
            con.table_UserProgresses.Update(progress);
            con.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
