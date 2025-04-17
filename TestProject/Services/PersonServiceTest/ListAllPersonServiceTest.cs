using FluentAssertions;
using Moq;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Repository;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using TestProject.GlobalTestData;

namespace TestProject.Services.PersonServiceTest;

public class ListAllPersonServiceTest
{
    private readonly Mock<IPersonRepository> _personRepository;
    private readonly IPersonService _personService;
    public ListAllPersonServiceTest()
    {
        _personRepository = new Mock<IPersonRepository>();
        _personService = new PersonService(_personRepository.Object);
    }

    [Fact]
    public void ListAllPerson_ShouldReturnAllPersons()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        _personRepository.Setup(repo => repo.GetAll()).Returns(mockPeople);
        // Act
        var result = _personService.ListAllPerson();
        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(mockPeople.Count);
        result.Should().BeEquivalentTo(mockPeople);
    }

    [Fact]
    public void ListAllPerson_EmptyList_ShouldReturnEmptyList()
    {
        // Arrange
        var mockPeople = new List<Person>();
        _personRepository.Setup(repo => repo.GetAll()).Returns(mockPeople);
        // Act
        var result = _personService.ListAllPerson();
        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }
}
