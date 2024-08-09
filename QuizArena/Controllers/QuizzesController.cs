using Microsoft.AspNetCore.Mvc;
using QuizArena.Models;
using static System.Net.Mime.MediaTypeNames;

namespace QuizArena.Controllers
{
    public class QuizzesController : Controller
    {
        QuizAppDbContext con;
        IWebHostEnvironment env;
        public QuizzesController(QuizAppDbContext _con,IWebHostEnvironment _env)
        {
            this.con = _con;
            this.env = _env;
            
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = con.table_Quizzes.ToList();
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
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
            
        }
        [HttpPost]
        public IActionResult Create(Quiz _quiz,IFormFile QuizImage)
        {
            var filename = Path.GetFileName(QuizImage.FileName);
            var filepath = Path.Combine(env.WebRootPath, "quizimages", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            QuizImage.CopyTo(fs);
            con.table_Quizzes.Add(_quiz);
            _quiz.QuizImage = filename;
            con.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = con.table_Quizzes.Where(q => q.QuizId == id).FirstOrDefault();
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
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = con.table_Quizzes.Find(id);
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
          
        }
        [HttpPost]
        public IActionResult Edit(Quiz _quiz,IFormFile QuizImage)
        {
            var filename = Path.GetFileName(QuizImage.FileName);
            var filepath = Path.Combine(env.WebRootPath, "quizimages", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            QuizImage.CopyTo(fs);
            con.table_Quizzes.Update(_quiz);
            _quiz.QuizImage = filename;
            con.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                var data = con.table_Quizzes.Where(q => q.QuizId == id).FirstOrDefault();
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
            var data = con.table_Quizzes.Find(id);
            con.table_Quizzes.Remove(data);
            con.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
