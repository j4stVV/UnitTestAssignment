using ASP.NETCoreMVCAssignment1.QuachVanViet.Helpers;
using ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Controllers;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using TestProject.GlobalTestData;

namespace TestProject.Controllers;

public class ExportToExcelControllerTest
{
    private readonly Mock<IPersonService> _mockPersonService;
    private readonly Mock<IPersonFilterService> _mockPersonFilterService;
    private readonly RookiesController _controller;
    public ExportToExcelControllerTest()
    {
        _mockPersonService = new Mock<IPersonService>();
        _mockPersonFilterService = new Mock<IPersonFilterService>();
        _controller = new RookiesController(_mockPersonService.Object, _mockPersonFilterService.Object);
    }

    [Fact]
    public void ExportToExcel_ValidInput_ShouldReturnFileResult()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        _mockPersonService.Setup(service => service.ListAllPerson()).Returns(mockPeople);
        var expectedExcelData = FileExport.ExportToExcel(mockPeople);
        // Act
        var result = _controller.ExportToExcel();
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<FileContentResult>();
        var fileResult = result as FileContentResult;
        fileResult.ContentType.Should().Be("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        fileResult.FileDownloadName.Should().Be("PeopleList.xlsx");
        _mockPersonService.Verify(service => service.ListAllPerson(), Times.Once());
    }
}
