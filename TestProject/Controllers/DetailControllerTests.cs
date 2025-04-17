using ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Controllers;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using TestProject.GlobalTestData;

namespace TestProject.Controllers;

public class DetailControllerTests
{
    private readonly Mock<IPersonService> _mockPersonService;
    private readonly Mock<IPersonFilterService> _mockPersonFilterService;
    private readonly RookiesController _controller;
    public DetailControllerTests()
    {
        _mockPersonService = new Mock<IPersonService>();
        _mockPersonFilterService = new Mock<IPersonFilterService>();
        _controller = new RookiesController(_mockPersonService.Object, _mockPersonFilterService.Object);
    }

    [Fact]
    public void Detail_ValidId_ShouldReturnDetailViewWithPerson()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var person = mockPeople.First();
        var validId = person.Id;
        _mockPersonService.Setup(repo => repo.GetPersonById(person.Id)).Returns(person);

        // Act
        var result = _controller.Details(person.Id);

        // Assert
        result.Should().BeOfType<ViewResult>();
        var viewResult = result as ViewResult;
        viewResult.Should().NotBeNull();
        viewResult.ViewName.Should().Be("Details");
        viewResult.Model.Should().BeOfType<Person>();
        viewResult.Model.Should().BeSameAs(person);
        _mockPersonService.Verify(service => service.GetPersonById(validId), Times.Once());
    }

    [Fact]
    public void Detail_InvalidId_ShouldReturnNotFound()
    {
        // Arrange
        var invalidId = Guid.NewGuid();
        _mockPersonService.Setup(repo => repo.GetPersonById(invalidId)).Returns((Person)null);
        // Act
        var result = _controller.Details(invalidId);
        // Assert
        result.Should().BeOfType<NotFoundResult>();
        _mockPersonService.Verify(service => service.GetPersonById(invalidId), Times.Once());
    }
}
