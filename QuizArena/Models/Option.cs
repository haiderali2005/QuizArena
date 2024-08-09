using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizArena.Models
{
    public class Option
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Choose Question")]
        public int QuestionId { get; set; }
        [Required]
        [DisplayName("Option Text")]
        public string OptionText { get; set; }
        [Required]
        public bool IsCorrect { get; set; }
        public Question Question { get; set; }
    }
}
