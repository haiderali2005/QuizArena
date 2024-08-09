using Microsoft.CodeAnalysis.Options;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizArena.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [Required]
        [DisplayName("Choose Quiz")]
        public int QuizId { get; set; }
        [Required]
        [DisplayName("Question Text")]
        public string QuestionText { get; set; }
        public Quiz Quiz { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
