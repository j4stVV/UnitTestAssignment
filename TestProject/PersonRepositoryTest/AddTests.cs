using ASP.NETCoreMVCAssignment1.QuachVanViet.Enum;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Repository;
using FluentAssertions;
using TestProject.GlobalTestData;

namespace TestProject.PersonRepositoryTest;

public class AddTests
{
    private readonly IPersonRepository _personRepository;
    public AddTests()
    {
        _personRepository = new PersonRepository();
    }
    [Fact]
    public void Add_ValidPerson_PersonAddedInList()
    {
        var person = new Person
        {
            FirstName = "Nam",
            LastName = "Tran",
            Gender = Gender.Male,
            DateOfBirth = new DateTime(1999, 3, 15),
            PhoneNumber = "0987654321",
            BirthPlace = "Da Nang",
            IsGraduated = false
        };
        _personRepository.MockData(TestData.ListPersonTest());

        _personRepository.Create(person);

        _personRepository.GetMockData()
            .Should().HaveCount(11);

        person.Id.Should().NotBeEmpty();
        person.Id.Should().NotBe(Guid.Empty);
    }
}
