using System.ComponentModel.DataAnnotations;

namespace ProiectColectiv.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        public bool isAdmin { get; set; }
    }
}