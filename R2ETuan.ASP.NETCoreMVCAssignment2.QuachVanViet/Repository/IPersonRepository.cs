using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;

namespace R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Repository;

public interface IPersonRepository
{
    void Create(Person person);
    void Update(Person person);
    void Delete(Person person);
    List<Person> GetAll();
    void MockData(List<Person> people);
    List<Person> GetMockData();
}
