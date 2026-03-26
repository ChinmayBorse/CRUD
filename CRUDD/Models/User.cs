using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUDD.Models
{
    public class Users
    {
        [Key]
        public int user_Id { get; set; }

        [Required]
        
        public string? username { get; set; }

        [Required]

        public string? email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be exactly 10 digits.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be numeric and 10 digits.")]

        public string? phone { get; set; }
    }
}
