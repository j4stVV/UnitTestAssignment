using ASP.NETCoreMVCAssignment1.QuachVanViet.Enum;
using ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Controllers;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;

namespace TestProject.Controllers;

public class CreateControllerTests
{
    private readonly Mock<IPersonService> _mockPersonService;
    private readonly Mock<IPersonFilterService> _mockPersonFilterService;
    private readonly RookiesController _controller;

    public CreateControllerTests()
    {
        _mockPersonService = new Mock<IPersonService>();
        _mockPersonFilterService = new Mock<IPersonFilterService>();
        _controller = new RookiesController(_mockPersonService.Object, _mockPersonFilterService.Object);
    }

    [Fact]
    public void Create_Get_ShouldReturnViewWithPersonModel()
    {
        // Act
        var result = _controller.Create();

        // Assert
        result.Should().BeOfType<ViewResult>();
        var viewResult = result as ViewResult;
        viewResult.ViewName.Should().Be("FormPerson");
        viewResult.Model.Should().BeOfType<Person>();
        var model = viewResult.Model as Person;
        model.Id.Should().Be(Guid.Empty);
        model.FirstName.Should().BeNull();
        model.LastName.Should().BeNull();
        model.Gender.Should().Be(Gender.Male); // Default enum value
        model.DateOfBirth.Should().Be(DateTime.MinValue);
        model.PhoneNumber.Should().BeNull();
        model.BirthPlace.Should().BeNull();
        model.IsGraduated.Should().BeFalse();
    }

    [Fact]
    public void Save_PostValidPerson_ShouldCallCreateAndRedirectToIndex()
    {
        // Arrange
        var validPerson = new Person
        {
            FirstName = "John",
            LastName = "Witch",
            Gender = Gender.Male,
            DateOfBirth = new DateTime(1990, 1, 1),
            PhoneNumber = "1234567890",
            BirthPlace = "Hanoi",
            IsGraduated = true
        };
        _controller.ModelState.Clear();

        // Act
        var result = _controller.Save(validPerson);

        // Assert
        _mockPersonService.Verify(service => service.Create(It.Is<Person>(p => p == validPerson)), Times.Once());
        result.Should().BeOfType<RedirectToActionResult>();
        var redirectResult = result as RedirectToActionResult;
        redirectResult.ActionName.Should().Be("Index");
    }

    [Fact]
    public void Save_PostInvalidPerson_ShouldReturnFormPersonView()
    {
        // Arrange
        var invalidPerson = new Person
        {
            FirstName = "",
            LastName = "",
            Gender = Gender.Male,
            DateOfBirth = new DateTime(1990, 1, 1),
            PhoneNumber = "",
            BirthPlace = "Hanoi",
            IsGraduated = true
        };
        _controller.ModelState.AddModelError("FirstName", "FirstName is required");
        _controller.ModelState.AddModelError("LastName", "LastName is required");
        _controller.ModelState.AddModelError("PhoneNumber", "PhoneNumber is required");

        // Act
        var result = _controller.Save(invalidPerson);

        // Assert
        _mockPersonService.Verify(service => service.Create(It.IsAny<Person>()), Times.Never());
        result.Should().BeOfType<ViewResult>();
        var viewResult = result as ViewResult;
        viewResult.ViewName.Should().Be("FormPerson");
        viewResult.Model.Should().BeSameAs(invalidPerson);

    }
}
