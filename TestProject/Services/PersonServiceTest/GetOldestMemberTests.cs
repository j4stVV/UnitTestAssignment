using FluentAssertions;
using Moq;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Repository;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using TestProject.GlobalTestData;

namespace TestProject.Services.PersonServiceTest;

public class GetOldestMemberTests
{
    private readonly Mock<IPersonRepository> _mockPersonRepository;
    private readonly IPersonService _personService;
    public GetOldestMemberTests()
    {
        _mockPersonRepository = new Mock<IPersonRepository>();
        _personService = new PersonService(_mockPersonRepository.Object);
    }

    [Fact]
    public void GetOldestMember_ShouldReturnOldestPerson()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var oldestPerson = mockPeople.OrderBy(p => p.DateOfBirth).First();
        _mockPersonRepository.Setup(repo => repo.GetAll()).Returns(mockPeople);

        // Act
        var result = _personService.GetOldestMember();
        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(oldestPerson);
    }

    [Fact]
    public void GetOldestMember_NoPeople_ShouldReturnNull()
    {
        // Arrange
        var mockPeople = new List<Person>();
        _mockPersonRepository.Setup(repo => repo.GetAll()).Returns(mockPeople);
        // Act
        Action action = () => _personService.GetOldestMember();
        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("No members found");
    }
}
