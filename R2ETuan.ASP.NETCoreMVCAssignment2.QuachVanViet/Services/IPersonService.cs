using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;

namespace R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;

public interface IPersonService
{
    void Create(Person person);
    void Update(Person person);
    void Delete(Guid id);
    List<Person> GetMaleMembers();
    Person GetOldestMember();
    List<Person> GetFullNames();
    List<Person> GetBirthYear2000();
    List<Person> GetBirthYearAfter2000();
    List<Person> GetBirthYearBefore2000();
    List<Person> ListAllPerson();
    Person? GetPersonById(Guid id);
}
