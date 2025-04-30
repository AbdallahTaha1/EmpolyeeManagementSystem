using System.ComponentModel.DataAnnotations;

namespace EMS.API.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string LastName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string Position { get; set; } = string.Empty;

    }
}
