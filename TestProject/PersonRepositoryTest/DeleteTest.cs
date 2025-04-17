using FluentAssertions;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Repository;
using TestProject.GlobalTestData;

namespace TestProject.PersonRepositoryTest;

public class DeleteTest
{
    private readonly IPersonRepository _personRepository;
    public DeleteTest()
    {
        _personRepository = new PersonRepository();
    }

    [Fact]
    public void Delete_ValidPerson_PersonDeletedInList()
    {
        var mockPeople = TestData.ListPersonTest();
        _personRepository.MockData(mockPeople);
        var personToDelete = mockPeople.First();
        _personRepository.Delete(personToDelete);
        var people = _personRepository.GetMockData();
        people.Should().HaveCount(9);
        people.Should().NotContain(p => p.Id == personToDelete.Id);
    }
}
