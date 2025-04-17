using FluentAssertions;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Repository;
using TestProject.GlobalTestData;

namespace TestProject.PersonRepositoryTest;

public class GetAllTests
{
    private readonly IPersonRepository _personRepository;
    public GetAllTests()
    {
        _personRepository = new PersonRepository();
    }

    [Fact]
    public void GetAllPerson_ReturnAllPeronInList()
    {
        _personRepository.MockData(TestData.ListPersonTest());

        var result = _personRepository.GetAll();
        result.Should().HaveCount(TestData.ListPersonTest().Count());
    }
}
