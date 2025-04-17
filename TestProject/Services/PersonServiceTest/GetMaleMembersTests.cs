using ASP.NETCoreMVCAssignment1.QuachVanViet.Enum;
using FluentAssertions;
using Moq;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Repository;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using TestProject.GlobalTestData;

namespace TestProject.Services.PersonServiceTest;

public class GetMaleMembersTests
{
    private readonly Mock<IPersonRepository> _mockPersonRepository;
    private readonly IPersonService _personService;
    public GetMaleMembersTests()
    {
        _mockPersonRepository = new Mock<IPersonRepository>();
        _personService = new PersonService(_mockPersonRepository.Object);
    }

    [Fact]
    public void GetMaleMembers_ShouldReturnMaleMembersList()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var expectedCount = mockPeople.Count(p => p.Gender == Gender.Male);
        _mockPersonRepository.Setup(repo => repo.GetAll()).Returns(mockPeople);

        // Act
        var result = _personService.GetMaleMembers();

        // Assert
        result.Should().HaveCount(expectedCount);
    }

    [Fact]
    public void GetMaleMembers_NoPersonIsMale_ShouldReturnEmptyList()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest().Where(p => p.Gender != Gender.Male).ToList();
        _mockPersonRepository.Setup(repo => repo.GetAll()).Returns(mockPeople);

        // Act
        var result = _personService.GetMaleMembers();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }
}
