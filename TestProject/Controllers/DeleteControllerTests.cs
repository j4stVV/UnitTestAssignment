using ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Controllers;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using TestProject.GlobalTestData;

namespace TestProject.Controllers;

public class DeleteControllerTests
{
    private readonly Mock<IPersonService> _mockPersonService;
    private readonly Mock<IPersonFilterService> _mockPersonFilterService;
    private readonly RookiesController _controller;

    public DeleteControllerTests()
    {
        _mockPersonService = new Mock<IPersonService>();
        _mockPersonFilterService = new Mock<IPersonFilterService>();
        _controller = new RookiesController(_mockPersonService.Object, _mockPersonFilterService.Object);
    }

    [Fact]
    public void Delete_ValidId_ShouldCallDeleteAndRedirectToConfirmation()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var person = mockPeople.First();
        var validId = person.Id;
        _mockPersonService.Setup(repo => repo.GetPersonById(validId)).Returns(person);
        _mockPersonService.Setup(repo => repo.Delete(validId));

        // Act
        var result = _controller.Delete(validId);

        // Assert
        _mockPersonService.Verify(service => service.GetPersonById(validId), Times.Once());
        _mockPersonService.Verify(service => service.Delete(validId), Times.Once());
        result.Should().BeOfType<RedirectToActionResult>();
        var redirectResult = result as RedirectToActionResult;
        redirectResult.ActionName.Should().Be("Confirmation");
    }

    [Fact]
    public void Delete_InvalidId_ShouldReturnNotFound()
    {
        // Arrange
        var invalidId = Guid.NewGuid(); // Assuming this ID does not exist
        _mockPersonService.Setup(repo => repo.GetPersonById(invalidId)).Returns((Person)null);
        // Act
        var result = _controller.Delete(invalidId);
        // Assert
        _mockPersonService.Verify(service => service.GetPersonById(invalidId), Times.Once());
        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public void Confirmation_ValidName_ShouldReturnConfirmationViewWithCorrectMessage()
    {
        // Arrange
        var name = "John Doe";
        var expectedMessage = $"Person {name} was removed from the list successfully!";

        // Act
        var result = _controller.Confirmation(name);
        
        // Assert
        result.Should().BeOfType<ViewResult>();
        var viewResult = result as ViewResult;
        viewResult.ViewName.Should().BeNull();
        viewResult.ViewData["Message"].Should().Be(expectedMessage);
    }
}
