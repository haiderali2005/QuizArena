using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizArena.Models
{
    public class Quiz
    {
        [Key]
        public int QuizId { get; set; }
        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Desciption")]
        public string Description { get; set; }
        [Required]
        public string QuizImage { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<UserProgress> userprogress_ { get; set; }
    }
}
