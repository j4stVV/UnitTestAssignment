using ASP.NETCoreMVCAssignment1.QuachVanViet.Enum;
using ASP.NETCoreMVCAssignment1.QuachVanViet.Helpers;
using System.ComponentModel.DataAnnotations;

namespace R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models
{
    public class Person
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First Name must be between 2 and 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name must be between 2 and 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        [PastDate(ErrorMessage = "Date of Birth must be in the past.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number must contain exactly 10 digits.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Birth Place is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Birth Place must be between 2 and 100 characters.")]
        public string BirthPlace { get; set; }
        public bool IsGraduated { get; set; }

        public Person() { }
        public Person(string firstName, string lastName, Gender gender, DateTime dateOfBirth, string phoneNumber, string birthPlace, bool isGraduated)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            BirthPlace = birthPlace;
            IsGraduated = isGraduated;
        }
    }
}
