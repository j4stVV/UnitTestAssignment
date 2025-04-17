using ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Controllers;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using TestProject.GlobalTestData;

namespace TestProject.Controllers;

public class EditControllerTests
{
    private readonly Mock<IPersonService> _mockPersonService;
    private readonly Mock<IPersonFilterService> _mockPersonFilterService;
    private readonly RookiesController _controller;
    public EditControllerTests()
    {
        _mockPersonService = new Mock<IPersonService>();
        _mockPersonFilterService = new Mock<IPersonFilterService>();
        _controller = new RookiesController(_mockPersonService.Object, _mockPersonFilterService.Object);
    }

    [Fact]
    public void Edit_ValidId_ShouldReturnFormPeronViewWithPerson()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var person = mockPeople.First();
        var validId = person.Id;
        _mockPersonService.Setup(repo => repo.GetPersonById(person.Id)).Returns(person);

        // Act
        var result = _controller.Edit(person.Id);
        result.Should().BeOfType<ViewResult>();
        var viewResult = result as ViewResult;
        viewResult.ViewName.Should().Be("FormPerson");
        viewResult.Model.Should().BeOfType<Person>();
        viewResult.Model.Should().BeSameAs(person);
        _mockPersonService.Verify(service => service.GetPersonById(validId), Times.Once());
    }

    [Fact]
    public void Edit_InvalidId_ShouldReturnNotFound()
    {
        // Arrange
        var invalidId = Guid.NewGuid();
        _mockPersonService.Setup(repo => repo.GetPersonById(invalidId)).Returns((Person)null);

        // Act
        var result = _controller.Edit(invalidId);

        // Assert
        result.Should().BeOfType<NotFoundResult>();
        _mockPersonService.Verify(service => service.GetPersonById(invalidId), Times.Once());
    }

    [Fact]
    public void Save_PostValidPersonAfterEdit_ShouldCallUpdateAndRedirectToIndex()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var existingPerson = mockPeople.First();
        var validEditedPerson = new Person
        {
            Id = existingPerson.Id,
            FirstName = "John",
            LastName = existingPerson.LastName,
            Gender = existingPerson.Gender,
            DateOfBirth = new DateTime(2003, 12, 23),
            PhoneNumber = "1234567890",
            BirthPlace = "Hanoi",
            IsGraduated = true
        };
        _controller.ModelState.Clear();

        // Act
        var result = _controller.Save(validEditedPerson);

        // Assert
        _mockPersonService.Verify(service => service.Update(It.Is<Person>(p => p.Id == validEditedPerson.Id)), Times.Once());
        result.Should().BeOfType<RedirectToActionResult>();
        var redirectResult = result as RedirectToActionResult;
        redirectResult.ActionName.Should().Be("Index");
    }

    [Fact]
    public void Save_PostInvalidPersonAfterEdit_ShouldReturnFormPersonView()
    {
        var mockPeople = TestData.ListPersonTest();
        var existingPerson = mockPeople.First();
        var invalidEditedPerson = new Person
        {
            Id = existingPerson.Id,
            FirstName = "",
            LastName = "",
            PhoneNumber = "",
            BirthPlace = ""
        };
        _controller.ModelState.AddModelError("FirstName", "First name is required.");
        _controller.ModelState.AddModelError("LastName", "Last name is required.");
        _controller.ModelState.AddModelError("PhoneNumber", "Phone number is required.");
        _controller.ModelState.AddModelError("BirthPlace", "Birth place is required.");

        // Act
        var result = _controller.Save(invalidEditedPerson);

        // Assert
        _mockPersonService.Verify(service => service.Update(It.IsAny<Person>()), Times.Never());
        result.Should().BeOfType<ViewResult>();
        var viewResult = result as ViewResult;
        viewResult.ViewName.Should().Be("FormPerson");
        viewResult.Model.Should().BeSameAs(invalidEditedPerson);
    }
}
