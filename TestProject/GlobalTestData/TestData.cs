using ASP.NETCoreMVCAssignment1.QuachVanViet.Enum;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;

namespace TestProject.GlobalTestData;

public class TestData
{
    public static List<Person> ListPersonTest()
    {
        return new List<Person>
        {
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Alice",
                LastName = "Smith",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(2000, 5, 21),
                PhoneNumber = "0123456789",
                BirthPlace = "New York",
                IsGraduated = true
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Bob",
                LastName = "Johnson",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(1993, 8, 15),
                PhoneNumber = "0987654321",
                BirthPlace = "Los Angeles",
                IsGraduated = false
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Charlie",
                LastName = "Brown",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(1990, 2, 10),
                PhoneNumber = "1234567890",
                BirthPlace = "Chicago",
                IsGraduated = true
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Diana",
                LastName = "Prince",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(1994, 6, 30),
                PhoneNumber = "2345678901",
                BirthPlace = "San Francisco",
                IsGraduated = true
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Ethan",
                LastName = "Hunt",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(1992, 11, 5),
                PhoneNumber = "3456789012",
                BirthPlace = "Miami",
                IsGraduated = true
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Fiona",
                LastName = "Gallagher",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(2003, 3, 12),
                PhoneNumber = "4567890123",
                BirthPlace = "Boston",
                IsGraduated = false
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "George",
                LastName = "Miller",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(2004, 1, 25),
                PhoneNumber = "5678901234",
                BirthPlace = "Dallas",
                IsGraduated = true
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Hannah",
                LastName = "Lee",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(1997, 7, 19),
                PhoneNumber = "6789012345",
                BirthPlace = "Seattle",
                IsGraduated = false
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Ian",
                LastName = "Wright",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(1989, 4, 8),
                PhoneNumber = "7890123456",
                BirthPlace = "Phoenix",
                IsGraduated = true
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Jane",
                LastName = "Doe",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(2005, 9, 14),
                PhoneNumber = "8901234567",
                BirthPlace = "Denver",
                IsGraduated = false
            }
        };
    }
}
