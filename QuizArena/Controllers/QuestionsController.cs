using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizArena.Models;

namespace QuizArena.Controllers
{
    public class QuestionsController : Controller
    {
        QuizAppDbContext con;
        public QuestionsController(QuizAppDbContext _con)
        {
            this.con = _con;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = con.table_Questions.Include(q => q.Quiz).ToList();
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
        public IActionResult Create(Question ques)
        {     
           con.table_Questions.Add(ques);
           con.SaveChanges();
           return RedirectToAction("Index");  
        }
        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = con.table_Questions.Include(q => q.Quiz).FirstOrDefault(q => q.QuestionId == id);
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
                var data = con.table_Questions.Include(q => q.Quiz).FirstOrDefault(q => q.QuestionId == id);
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
         
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult Deletetwo(int id)
        {
            var data = con.table_Questions.Find(id);
            con.table_Questions.Remove(data);
            con.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                List<Quiz> quizzes = con.table_Quizzes.ToList();
                ViewData["_quiz"] = quizzes;
                var data = con.table_Questions.Find(id);
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
         
        }
        [HttpPost]
        public IActionResult Edit(Question ques)
        {
            con.table_Questions.Update(ques);
            con.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
