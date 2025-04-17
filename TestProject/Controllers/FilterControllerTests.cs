using ASP.NETCoreMVCAssignment1.QuachVanViet.Enum;
using ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Controllers;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using TestProject.GlobalTestData;

namespace TestProject.Controllers;

public class FilterControllerTests
{
    private readonly Mock<IPersonService> _mockPersonService;
    private readonly Mock<IPersonFilterService> _mockPersonFilterService;
    private readonly RookiesController _controller;
    public FilterControllerTests()
    {
        _mockPersonService = new Mock<IPersonService>();
        _mockPersonFilterService = new Mock<IPersonFilterService>();
        _controller = new RookiesController(_mockPersonService.Object, _mockPersonFilterService.Object);
    }

    [Fact]
    public void Index_FilterAll_ShouldReturnViewWithAllPeople()
    {
        //Arrange
        var mockPeople = TestData.ListPersonTest();
        _mockPersonFilterService.Setup(repo => repo.FilterPeople(Filter.All)).Returns(mockPeople);

        //Act
        var result = _controller.Index(Filter.All);

        //Assert
        result.Should().BeOfType<ViewResult>();
        var viewResult = result as ViewResult;
        viewResult.ViewName.Should().BeNull();
        viewResult.Model.Should().BeSameAs(mockPeople);
        viewResult.ViewData["filter"].Should().Be(Filter.All);
        _mockPersonFilterService.Verify(repo => repo.FilterPeople(Filter.All), Times.Once());
    }

    [Fact]
    public void Index_FilterMaleMembers_ShouldReturnViewWithMaleMembers()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var maleMembers = mockPeople.Where(p => p.Gender == Gender.Male).ToList();
        _mockPersonFilterService.Setup(service => service.FilterPeople(Filter.Males)).Returns(maleMembers);

        // Act  
        var result = _controller.Index(Filter.Males);

        // Assert
        result.Should().BeOfType<ViewResult>();
        var viewResult = result as ViewResult;
        viewResult.ViewName.Should().BeNull();
        viewResult.Model.Should().BeSameAs(maleMembers);
        viewResult.ViewData["filter"].Should().Be(Filter.Males);
        viewResult.Model.As<List<Person>>().Should().HaveCount(maleMembers.Count());
        viewResult.Model.As<List<Person>>().All(p => p.Gender == Gender.Male).Should().BeTrue();
        _mockPersonFilterService.Verify(service => service.FilterPeople(Filter.Males), Times.Once());
    }

    [Fact]
    public void Index_FilterOldestMember_ShouldReturnViewWithOldestMember()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var oldestMember = mockPeople.OrderBy(p => p.DateOfBirth).FirstOrDefault();
        _mockPersonFilterService.Setup(service => service.FilterPeople(Filter.Oldest)).Returns(new List<Person> { oldestMember });
        // Act
        var result = _controller.Index(Filter.Oldest);
        // Assert
        result.Should().BeOfType<ViewResult>();
        var viewResult = result as ViewResult;
        viewResult.ViewName.Should().BeNull();
        viewResult.Model.Should().BeEquivalentTo(new List<Person> { oldestMember });
        viewResult.ViewData["filter"].Should().Be(Filter.Oldest);
        _mockPersonFilterService.Verify(service => service.FilterPeople(Filter.Oldest), Times.Once());
    }

    [Fact]
    public void Index_FilterFullNames_ShouldReturnViewWithFullNames()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        _mockPersonFilterService.Setup(service => service.FilterPeople(Filter.FullNames)).Returns(mockPeople);
        // Act
        var result = _controller.Index(Filter.FullNames);
        // Assert
        result.Should().BeOfType<ViewResult>();
        var viewResult = result as ViewResult;
        viewResult.ViewName.Should().BeNull();
        viewResult.Model.Should().BeSameAs(mockPeople);
        viewResult.ViewData["filter"].Should().Be(Filter.FullNames);
        _mockPersonFilterService.Verify(service => service.FilterPeople(Filter.FullNames), Times.Once());
    }

    [Fact]
    public void Index_FilterPersonBonrnIn2000_ShouldReturnViewWithPersonBornIn2000()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var peopleBornIn2000 = mockPeople.Where(p => p.DateOfBirth.Year == 2000).ToList();
        _mockPersonFilterService.Setup(service => service.FilterPeople(Filter.Born2000)).Returns(peopleBornIn2000);
        // Act
        var result = _controller.Index(Filter.Born2000);
        // Assert
        result.Should().BeOfType<ViewResult>();
        var viewResult = result as ViewResult;
        viewResult.ViewName.Should().BeNull();
        viewResult.Model.Should().BeSameAs(peopleBornIn2000);
        viewResult.ViewData["filter"].Should().Be(Filter.Born2000);
        viewResult.Model.As<List<Person>>().Should().HaveCount(peopleBornIn2000.Count());
        viewResult.Model.As<List<Person>>().All(p => p.DateOfBirth.Year == 2000).Should().BeTrue();
        _mockPersonFilterService.Verify(service => service.FilterPeople(Filter.Born2000), Times.Once());
    }

    [Fact]
    public void Index_FilterPersonBonrnAfter2000_ShouldReturnViewWithPersonBornAfter2000()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var peopleBornAfter2000 = mockPeople.Where(p => p.DateOfBirth.Year > 2000).ToList();
        _mockPersonFilterService.Setup(service => service.FilterPeople(Filter.BornAfter2000)).Returns(peopleBornAfter2000);
        // Act
        var result = _controller.Index(Filter.BornAfter2000);
        // Assert
        result.Should().BeOfType<ViewResult>();
        var viewResult = result as ViewResult;
        viewResult.ViewName.Should().BeNull();
        viewResult.Model.Should().BeSameAs(peopleBornAfter2000);
        viewResult.ViewData["filter"].Should().Be(Filter.BornAfter2000);
        viewResult.Model.As<List<Person>>().Should().HaveCount(peopleBornAfter2000.Count());
        viewResult.Model.As<List<Person>>().All(p => p.DateOfBirth.Year >000).Should().BeTrue();
        _mockPersonFilterService.Verify(service => service.FilterPeople(Filter.BornAfter2000), Times.Once());
    }

    [Fact]
    public void Index_FilterPersonBonrnBefore2000_ShouldReturnViewWithPersonBornBefore2000()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var peopleBornBefore2000 = mockPeople.Where(p => p.DateOfBirth.Year < 2000).ToList();
        _mockPersonFilterService.Setup(service => service.FilterPeople(Filter.BornBefore2000)).Returns(peopleBornBefore2000);
        // Act
        var result = _controller.Index(Filter.BornBefore2000);
        // Assert
        result.Should().BeOfType<ViewResult>();
        var viewResult = result as ViewResult;
        viewResult.ViewName.Should().BeNull();
        viewResult.Model.Should().BeSameAs(peopleBornBefore2000);
        viewResult.ViewData["filter"].Should().Be(Filter.BornBefore2000);
        viewResult.Model.As<List<Person>>().Should().HaveCount(peopleBornBefore2000.Count());
        viewResult.Model.As<List<Person>>().All(p => p.DateOfBirth.Year < 2000).Should().BeTrue();
        _mockPersonFilterService.Verify(service => service.FilterPeople(Filter.BornBefore2000), Times.Once());
    }
}
