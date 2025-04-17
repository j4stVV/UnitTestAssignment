using ASP.NETCoreMVCAssignment1.QuachVanViet.Enum;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;

namespace ASP.NETCoreMVCAssignment1.QuachVanViet.Services;

public interface IPersonFilterService
{
    List<Person> FilterPeople(Filter filter = Filter.All);
}
