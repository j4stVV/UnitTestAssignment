using FluentAssertions;
using Moq;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Repository;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using TestProject.GlobalTestData;

namespace TestProject.Services.PersonServiceTest;

public class GetBirthYearBefore2000Tests
{
    private readonly Mock<IPersonRepository> _mockPersonRepository;
    private readonly IPersonService _personService;
    public GetBirthYearBefore2000Tests()
    {
        _mockPersonRepository = new Mock<IPersonRepository>();
        _personService = new PersonService(_mockPersonRepository.Object);
    }

    [Fact]
    public void GetBirthYearBefore2000_PeopleBornBefore2000_ShouldReturnCorrectCount()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var expectedCount = mockPeople.Count(p => p.DateOfBirth.Year < 2000);
        _mockPersonRepository.Setup(repo => repo.GetAll()).Returns(mockPeople);
        // Act
        var result = _personService.GetBirthYearBefore2000();
        // Assert
        result.Should().HaveCount(expectedCount);
    }

    [Fact]
    public void GetBirthYearBefore2000_NoPeopleBornBefore2000_ShouldReturnEmptyList()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest().Where(p => p.DateOfBirth.Year >= 2000).ToList();
        _mockPersonRepository.Setup(repo => repo.GetAll()).Returns(mockPeople);
        // Act
        var result = _personService.GetBirthYearBefore2000();
        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }
}
