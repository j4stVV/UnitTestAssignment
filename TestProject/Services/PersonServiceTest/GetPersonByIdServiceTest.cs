using Moq;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Repository;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using TestProject.GlobalTestData;

namespace TestProject.Services.PersonServiceTest;

public class GetPersonByIdServiceTest
{
    private readonly Mock<IPersonRepository> _mockPersonRepository;
    private readonly IPersonService _personService;
    public GetPersonByIdServiceTest()
    {
        _mockPersonRepository = new Mock<IPersonRepository>();
        _personService = new PersonService(_mockPersonRepository.Object);
    }

    [Fact]
    public void GetPersonId_ValidId_ShouldReturnCorrectPerson()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var expectedPerson = mockPeople.First();

        _mockPersonRepository
            .Setup(repo => repo.GetAll())
            .Returns(mockPeople);

        // Act
        var result = _personService.GetPersonById(expectedPerson.Id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedPerson);
    }

    [Fact]
    public void GetPersonId_NonExistentId_ShouldThrowArgumentException()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var nonExistentId = Guid.NewGuid();
        _mockPersonRepository
            .Setup(repo => repo.GetAll())
            .Returns(mockPeople);
        // Act
        Action act = () => _personService.GetPersonById(nonExistentId);
        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("Person not found");
    }
}
