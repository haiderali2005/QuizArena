using Microsoft.AspNetCore.Mvc;
using QuizArena.Models;

namespace QuizArena.Controllers
{
    public class QuizFrontendController : Controller
    {
        QuizAppDbContext con;
        public QuizFrontendController(QuizAppDbContext _con)
        {
            this.con = _con;
        }
        public IActionResult Index()
        {
            List<Quiz> quizzes = con.table_Quizzes.ToList();
            ViewData["quizes"]=quizzes;
            return View();
        }
    }
}
