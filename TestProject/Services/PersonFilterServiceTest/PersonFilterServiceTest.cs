using ASP.NETCoreMVCAssignment1.QuachVanViet.Enum;
using ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using FluentAssertions;
using Moq;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using TestProject.GlobalTestData;

namespace TestProject.Services.PersonFilterServiceTest;

public class PersonFilterServiceTest
{
    private readonly Mock<IPersonService> _mockPersonService;
    private readonly IPersonFilterService _personFilterService;
    public PersonFilterServiceTest()
    {
        _mockPersonService = new Mock<IPersonService>();
        _personFilterService = new PersonFilterService(_mockPersonService.Object);
    }

    [Fact]
    public void FilterPeople_MaleMembers_ShouldReturnMaleMembers()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var maleMembers = mockPeople.Where(p => p.Gender == Gender.Male).ToList();
        _mockPersonService.Setup(repo => repo.GetMaleMembers()).Returns(maleMembers);

        // Act
        var result = _personFilterService.FilterPeople(Filter.Males);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(maleMembers.Count);
        result.Should().BeEquivalentTo(maleMembers);
    }

    [Fact]
    public void FilterPeople_OldestMember_ShouldReturnOldestMember()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var oldestMember = mockPeople.OrderBy(p => p.DateOfBirth).FirstOrDefault();
        _mockPersonService.Setup(repo => repo.GetOldestMember()).Returns(oldestMember);

        // Act
        var result = _personFilterService.FilterPeople(Filter.Oldest);

        // Assert
        result.Should().HaveCount(1);
        result.First().Should().BeEquivalentTo(oldestMember);
    }

    [Fact]
    public void FilterPeople_FullNames_ShouldReturnFullNames()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        _mockPersonService.Setup(repo => repo.GetFullNames()).Returns(mockPeople);

        // Act
        var result = _personFilterService.FilterPeople(Filter.FullNames);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(mockPeople.Count);
        result.Should().BeEquivalentTo(mockPeople);
    }

    [Fact]
    public void FilterPeople_Born2000_ShouldReturnPeopleBornIn2000()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var peopleBornIn2000 = mockPeople.Where(p => p.DateOfBirth.Year == 2000).ToList();
        _mockPersonService.Setup(repo => repo.GetBirthYear2000()).Returns(peopleBornIn2000);

        // Act
        var result = _personFilterService.FilterPeople(Filter.Born2000);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(peopleBornIn2000.Count);
        result.Should().BeEquivalentTo(peopleBornIn2000);
    }

    [Fact]
    public void FilterPeople_BornAfter2000_ShouldReturnPeopleBornAfter2000()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var peopleBornAfter2000 = mockPeople.Where(p => p.DateOfBirth.Year > 2000).ToList();
        _mockPersonService.Setup(repo => repo.GetBirthYearAfter2000()).Returns(peopleBornAfter2000);

        // Act
        var result = _personFilterService.FilterPeople(Filter.BornAfter2000);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(peopleBornAfter2000.Count);
        result.Should().BeEquivalentTo(peopleBornAfter2000);
    }

    [Fact]
    public void FilterPeople_BornBefore2000_ShouldReturnPeopleBornBefore2000()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var peopleBornBefore2000 = mockPeople.Where(p => p.DateOfBirth.Year < 2000).ToList();
        _mockPersonService.Setup(repo => repo.GetBirthYearBefore2000()).Returns(peopleBornBefore2000);
        // Act
        var result = _personFilterService.FilterPeople(Filter.BornBefore2000);
        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(peopleBornBefore2000.Count);
        result.Should().BeEquivalentTo(peopleBornBefore2000);
    }

    [Fact]
    public void FilterPeople_All_ShouldReturnAllPeople()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        _mockPersonService.Setup(repo => repo.ListAllPerson()).Returns(mockPeople);
        // Act
        var result = _personFilterService.FilterPeople(Filter.All);
        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(mockPeople.Count);
        result.Should().BeEquivalentTo(mockPeople);
    }
}
    
