using FluentAssertions;
using Moq;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Repository;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using TestProject.GlobalTestData;

namespace TestProject.Services.PersonServiceTest;

public class GetFullNameTests
{
    private readonly Mock<IPersonRepository> _mockPersonRepository;
    private readonly IPersonService _personService;
    public GetFullNameTests()
    {
        _mockPersonRepository = new Mock<IPersonRepository>();
        _personService = new PersonService(_mockPersonRepository.Object);
    }

    [Fact]
    public void GetFullName_ShouldReturnCorrectFullNames()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        _mockPersonRepository.Setup(repo => repo.GetAll()).Returns(mockPeople);
        var expectedFullNames = mockPeople.Select(p => $"{p.FirstName} {p.LastName}").ToList();

        // Act
        var result = _personService.GetFullNames();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(mockPeople.Count);
        result.Should().BeEquivalentTo(mockPeople.Select(p => new Person
        {
            FirstName = p.FirstName,
            LastName = p.LastName
        }));
    }
}
