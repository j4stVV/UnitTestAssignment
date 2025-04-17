using FluentAssertions;
using Moq;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Repository;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using TestProject.GlobalTestData;

namespace TestProject.Services.PersonServiceTest;

public class DeleteServiceTest
{
    private readonly Mock<IPersonRepository> _mockPersonRepository;
    private readonly IPersonService _personService;
    public DeleteServiceTest()
    {
        _mockPersonRepository = new Mock<IPersonRepository>();
        _personService = new PersonService(_mockPersonRepository.Object);
    }
    [Fact]
    public void Delete_ValidId_ShouldCallRepositoryDelete()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var personToDelete = mockPeople.First();
        _mockPersonRepository.Setup(repo => repo.GetAll()).Returns(mockPeople);
        _mockPersonRepository.Setup(repo => repo.Delete(It.IsAny<Person>()))
            .Callback<Person>(p => mockPeople.Remove(p));
        // Act
        _personService.Delete(personToDelete.Id);

        // Assert
        _mockPersonRepository.Verify(repo => repo.Delete(It.Is<Person>(p => p.Id == personToDelete.Id)), Times.Once());
        var updatedPeople = _mockPersonRepository.Object.GetAll();
        updatedPeople.Should().HaveCount(9);
        updatedPeople.Should().NotContain(p => p.Id == personToDelete.Id);
    }

    [Fact]
    public void Delete_NonExistentId_ShouldThrowArgumentException()
    {
        // Arrange
        var mockPeople = TestData.ListPersonTest();
        var nonExistentId = Guid.NewGuid();
        _mockPersonRepository.Setup(repo => repo.GetAll()).Returns(mockPeople);
        // Act
        Action act = () => _personService.Delete(nonExistentId);
        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("Person not found");
    }
}
