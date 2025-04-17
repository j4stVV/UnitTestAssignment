using ASP.NETCoreMVCAssignment1.QuachVanViet.Enum;
using FluentAssertions;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Repository;
using TestProject.GlobalTestData;

namespace TestProject.PersonRepositoryTest;

public class UpdateTests
{
    private readonly IPersonRepository _personRepository;
    public UpdateTests()
    {
        _personRepository = new PersonRepository();
    }

    [Fact]
    public void Update_ValidPerson_ReplaceExistingPerson()
    {
        var mockPeople = TestData.ListPersonTest();
        _personRepository.MockData(mockPeople); 

        var existingPerson = mockPeople.First();
        var updatePerson = new Person
        {
            Id = existingPerson.Id,
            FirstName = "UpdatedFirstName",
            LastName = "UpdatedLastName",
            Gender = Gender.Male,
            DateOfBirth = new DateTime(1995, 5, 21),
            PhoneNumber = "0123456789",
            BirthPlace = "New York",
            IsGraduated = true
        };

        _personRepository.Update(updatePerson);

        var people = _personRepository.GetMockData();
        people.Should().HaveCount(10);
        people.Should().ContainSingle(p => p.Id == existingPerson.Id);
    }
}
