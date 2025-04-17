using FluentAssertions;
using Moq;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Repository;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using TestProject.Services.ServiceTestData;

namespace TestProject.Services.PersonServiceTest;

public class CreateServiceTest
{
    private readonly Mock<IPersonRepository> _mockPersonRepository;
    private readonly IPersonService _personService;

    public CreateServiceTest()
    {
        _mockPersonRepository = new Mock<IPersonRepository>();
        _personService = new PersonService(_mockPersonRepository.Object);
    }

    [Theory]
    [ClassData(typeof(PersonValidTestData))]
    public void Create_ValidPerson_ShouldCallRepositoryCreate(Person person)
    {
        // Arrange
        _mockPersonRepository.Setup(repo => repo.Create(It.IsAny<Person>()));
        // Act
        _personService.Create(person);
        // Assert
        _mockPersonRepository.Verify(repo => repo.Create(It.IsAny<Person>()), Times.Once);
    }
}
