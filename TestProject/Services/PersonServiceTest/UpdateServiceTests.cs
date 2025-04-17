using ASP.NETCoreMVCAssignment1.QuachVanViet.Enum;
using FluentAssertions;
using Moq;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Repository;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using TestProject.GlobalTestData;

namespace TestProject.Services.PersonServiceTest;

public class UpdateServiceTests
{
    private readonly Mock<IPersonRepository> _mockPersonRepository;
    private readonly IPersonService _personService;
    public UpdateServiceTests()
    {
        _mockPersonRepository = new Mock<IPersonRepository>();
        _personService = new PersonService(_mockPersonRepository.Object);
    }

    [Fact]
    public void Update_ValidPerson_ShouldUpdatePerson()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var personToUpdate = mockPeople.First();
        var updatedPerson = new Person
        {
            Id = personToUpdate.Id,
            LastName = "Updated Name",
            BirthPlace = "Ha Noi"
        };
        _mockPersonRepository.Setup(repo => repo.GetAll()).Returns(mockPeople);
        _mockPersonRepository.Setup(repo => repo.Update(It.IsAny<Person>()))
            .Callback<Person>(p =>
            {
                var index = mockPeople.FindIndex(x => x.Id == p.Id);
                if (index >= 0)
                {
                    mockPeople[index] = p;
                }
            });

        // Act
        _personService.Update(updatedPerson);

        // Assert
        _mockPersonRepository.Verify(repo => repo.Update(It.Is<Person>(p => p.Id == updatedPerson.Id)), Times.Once());
        var updatedPeople = _mockPersonRepository.Object.GetAll();
        updatedPeople.Should().HaveCount(10);
        var actualPerson = updatedPeople.First(p => p.Id == updatedPerson.Id);
        actualPerson.Should().BeEquivalentTo(updatedPerson);
    }

    [Fact]
    public void Update_NonExistentId_ShouldThrowArgumentException()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var nonExistentPerson = new Person
        {
            Id = Guid.NewGuid(),
            FirstName = "NonExistent",
            LastName = "Person",
            BirthPlace = "Unknown",
            Gender = Gender.Male,
            DateOfBirth = new DateTime(2000, 1, 1),
            IsGraduated = true
        };
        _mockPersonRepository.Setup(repo => repo.GetAll()).Returns(mockPeople);
        _mockPersonRepository.Setup(repo => repo.Update(It.IsAny<Person>()))
            .Callback<Person>(p =>
            {
                var index = mockPeople.FindIndex(x => x.Id == p.Id);
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            });

        // Act
        Action act = () => _personService.Update(nonExistentPerson);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
        _mockPersonRepository.Verify(repo => repo.Update(It.Is<Person>(p => p.Id == nonExistentPerson.Id)), Times.Once());
        var updatedPeople = _mockPersonRepository.Object.GetAll();
        updatedPeople.Should().HaveCount(10);
        updatedPeople.Should().BeEquivalentTo(mockPeople);

    }
}
