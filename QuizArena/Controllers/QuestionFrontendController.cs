using Microsoft.AspNetCore.Mvc;
using QuizArena.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static System.Formats.Asn1.AsnWriter;
namespace QuizArena.Controllers
{
    public class QuestionFrontendController : Controller
    {
        private readonly QuizAppDbContext _context;

        public QuestionFrontendController(QuizAppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            if (HttpContext.Session.GetString("mysessionfrontend") == null)
            {
                return RedirectToAction("Login", "AuthenticationFrontend");
            }
            var questions = _context.table_Questions
                .Include(q => q.Options)
                .Where(i => i.QuizId == id) 
                .ToList();
            return View(questions);
        }
        [HttpPost]
        public IActionResult Submit(int[] questionIds, int[] optionIds)
        {
            if (questionIds == null || optionIds == null || questionIds.Length != optionIds.Length)
            {
                return BadRequest("Invalid form submission.");
            }

            int totalScore = 0;
            int totalQuestions = questionIds.Length;

            foreach (var questionId in questionIds)
            {
                var question = _context.table_Questions
                    .Include(q => q.Options)
                    .FirstOrDefault(q => q.QuestionId == questionId);

                if (question == null)
                {
                    continue;
                }

                var optionId = optionIds[Array.IndexOf(questionIds, questionId)];
                var selectedOption = question.Options.FirstOrDefault(o => o.Id == optionId);

                bool isCorrect = selectedOption != null && selectedOption.IsCorrect;
                int score = isCorrect ? 10 : 0;

                totalScore += score;

                var userProgress = new UserProgress
                {
                    QuizId = question.QuizId,
                    QuestionId = questionId,
                    SelectedOptionId = optionId,
                    Completed = true,
                    Score = score
                };

                _context.table_UserProgresses.Add(userProgress);
            }

            _context.SaveChanges();

            var quizResults = new QuizResults
            {
                TotalScore = totalScore,
                TotalQuestions = totalQuestions
            };

            _context.table_quizresults.Add(quizResults);
            _context.SaveChanges();

            return RedirectToAction("Results", new { id = quizResults.result_id });
        }

        public IActionResult Results(int id)
        {
            if (HttpContext.Session.GetString("mysessionfrontend") == null)
            {
                return RedirectToAction("Login", "AuthenticationFrontend");
            }
            var quizResults = _context.table_quizresults
                .FirstOrDefault(r => r.result_id == id);

            if (quizResults == null)
            {
                return NotFound();
            }
            if (HttpContext.Session.GetString("mysessionfrontend") != null)
            {
                ViewBag.users = HttpContext.Session.GetString("mysessionfrontend").ToString();
            }

            return View(quizResults);
        }
    }
}


