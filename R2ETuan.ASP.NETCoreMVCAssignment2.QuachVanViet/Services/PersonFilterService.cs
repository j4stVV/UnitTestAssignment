using ASP.NETCoreMVCAssignment1.QuachVanViet.Enum;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;

namespace ASP.NETCoreMVCAssignment1.QuachVanViet.Services;

public class PersonFilterService : IPersonFilterService
{
    private readonly IPersonService _personService;
    public PersonFilterService(IPersonService personService)
    {
        _personService = personService;
    }
    public List<Person> FilterPeople(Filter filter = Filter.All)
    {
        return filter switch
        {
            Filter.Males => _personService.GetMaleMembers(),
            Filter.Oldest => new List<Person> { _personService.GetOldestMember() ?? new Person() },
            Filter.FullNames => _personService.GetFullNames(),
            Filter.Born2000 => _personService.GetBirthYear2000(),
            Filter.BornAfter2000 => _personService.GetBirthYearAfter2000(),
            Filter.BornBefore2000 => _personService.GetBirthYearBefore2000(),
            _ => _personService.ListAllPerson()
        };
    }
}
