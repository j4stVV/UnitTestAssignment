using ASP.NETCoreMVCAssignment1.QuachVanViet.Enum;
using ClosedXML.Excel;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Repository;

namespace R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;
    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    public List<Person> ListAllPerson()
    {
        return _personRepository.GetAll();
    }
    public Person GetPersonById(Guid id)
    {
        var person = _personRepository.GetAll().FirstOrDefault(p => p.Id == id);
        if (person == null)
        {
            throw new ArgumentException("Person not found");
        }
        return person;
    }
    public void Create(Person person)
    {
        _personRepository.Create(person);
    }
    public void Update(Person person)
    {
        _personRepository.Update(person);
    }
    public void Delete(Guid id)
    {
        var person = _personRepository.GetAll().FirstOrDefault(p => p.Id == id);
        if (person == null)
        {
            throw new ArgumentException("Person not found");
        }
        _personRepository.Delete(person);
    }
    public List<Person> GetMaleMembers()
    {
        return _personRepository.GetAll().Where(c => c.Gender == Gender.Male).ToList();
    }
    public Person GetOldestMember()
    {
        var oldest = _personRepository.GetAll().OrderBy(c => c.DateOfBirth).FirstOrDefault();
        if (oldest == null)
        {
            throw new ArgumentException("No members found");
        }
        return oldest;
    }
    public List<Person> GetFullNames()
    {
        return _personRepository.GetAll().Select(p => new Person
        {
            FirstName = p.FirstName,
            LastName = p.LastName
        }).ToList();
    }
    public List<Person> GetBirthYear2000()
    {
        return _personRepository.GetAll().Where(c => c.DateOfBirth.Year == 2000).ToList();
    }
    public List<Person> GetBirthYearAfter2000()
    {
        return _personRepository.GetAll().Where(c => c.DateOfBirth.Year > 2000).ToList();
    }
    public List<Person> GetBirthYearBefore2000()
    {
        return _personRepository.GetAll().Where(c => c.DateOfBirth.Year < 2000).ToList();
    }
}
