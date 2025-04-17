using FluentAssertions;
using Moq;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Repository;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using TestProject.GlobalTestData;

namespace TestProject.Services.PersonServiceTest;

public class GetBirthYearAfter2000ServiceTests
{
    private readonly Mock<IPersonRepository> _mockPersonRepository;
    private readonly IPersonService _personService;

    public GetBirthYearAfter2000ServiceTests()
    {
        _mockPersonRepository = new Mock<IPersonRepository>();
        _personService = new PersonService(_mockPersonRepository.Object);
    }

    [Fact]
    public void GetBirthYearAfter2000Service_PeopleBornAfter2000_ShouldReturnCorrectCount()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var expectedCount = mockPeople.Count(p => p.DateOfBirth.Year > 2000);
        _mockPersonRepository.Setup(repo => repo.GetAll()).Returns(mockPeople);

        // Act
        var result = _personService.GetBirthYearAfter2000();

        // Assert
        result.Should().HaveCount(expectedCount);
    }

    [Fact]
    public void GetBirthYearAfter2000Service_NoPeopleBornAfter2000_ShouldReturnEmptyList()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest().Where(p => p.DateOfBirth.Year <= 2000).ToList();
        _mockPersonRepository.Setup(repo => repo.GetAll()).Returns(mockPeople);
        // Act
        var result = _personService.GetBirthYearAfter2000();
        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }
}
