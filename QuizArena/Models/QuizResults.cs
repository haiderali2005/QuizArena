using System.ComponentModel.DataAnnotations;

namespace QuizArena.Models
{
    public class QuizResults
    {
        [Key]
        public int result_id { get; set; }
        public int? TotalScore { get; set; }
        public int? TotalQuestions { get; set; }
    }
}
