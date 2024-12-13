using System.ComponentModel.DataAnnotations;

namespace UnitTestApp.Tests.ModelsValidationTests.Models
{
    internal class UserModel
    {
        [Required]
        [MinLength(3)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        public string LastName { get; set; } = string.Empty;

        [Range(18, 100)]
        public int Age { get; set; }
    }
}
