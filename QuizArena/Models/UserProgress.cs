using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizArena.Models
{
    public class UserProgress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Choose Quiz")]
        public int QuizId { get; set; } 
        [Required]
        public int QuestionId { get; set; } 
        public int? SelectedOptionId { get; set; } 
        [Required]
        public bool Completed { get; set; }
        public int Score { get; set; }
        public Quiz Quiz { get; set; }
        public Question Question { get; set; }
        public Option SelectOption { get; set; }
    }
}
