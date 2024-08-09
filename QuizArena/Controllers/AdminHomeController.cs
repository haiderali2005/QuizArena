using Microsoft.AspNetCore.Mvc;
using QuizArena.Models;

namespace QuizArena.Controllers
{
    public class AdminHomeController : Controller
    {
        QuizAppDbContext con;
        public AdminHomeController(QuizAppDbContext _con)
        {
            this.con = _con;
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
    }
}
