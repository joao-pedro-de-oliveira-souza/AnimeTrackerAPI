using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeTracker.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [MaxLength(20, ErrorMessage = "Username exceed 20 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [MaxLength(250, ErrorMessage = "Username exceed 250 characters.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(100, ErrorMessage = "Password exceed 100 characters.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [NotMapped]
        public required string Password { get; set; }
    }
}
