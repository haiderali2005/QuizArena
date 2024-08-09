using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizArena.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(15,MinimumLength =3,ErrorMessage ="Enter a valid name")]
        [DisplayName("Name")]
        public string Username { get; set; }
        [EmailAddress]
        [Required(ErrorMessage ="Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

    }
}
