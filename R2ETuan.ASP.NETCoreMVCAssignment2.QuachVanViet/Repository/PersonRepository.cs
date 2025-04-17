using ASP.NETCoreMVCAssignment1.QuachVanViet.Enum;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;

namespace R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Repository;

public class PersonRepository : IPersonRepository
{
    private List<Person> people = new()
    {
        new Person("John", "Smith", Gender.Male, new DateTime(1995, 5, 15), "555-0123", "New York", true),
        new Person("Emma", "Johnson", Gender.Female, new DateTime(1998, 9, 22), "555-0124", "London", false),
        new Person("Michael", "Brown", Gender.Male, new DateTime(1990, 12, 10), "555-0126", "Chicago", true),
        new Person("Alex", "Taylor", Gender.Other, new DateTime(1993, 12, 3), "555-0125", "Toronto", true),
        new Person("Sarah", "Lee", Gender.Female, new DateTime(2001, 1, 1), "555-0127", "Paris", false),
        new Person("Tom", "Wilson", Gender.Male, new DateTime(2002, 3, 15), "555-0128", "Berlin", false)
    };
    public List<Person> GetAll()
    {
        return people;
    }
    public void Create(Person person)
    {
        if (person.Id == Guid.Empty)
        {
            person.Id = Guid.NewGuid();
        }
        people.Insert(0, person);
    }   
    public void Update(Person person)
    {
        var index = people.FindIndex(p => p.Id == person.Id);
        people[index] = person;
    }
    public void Delete(Person person)
    {
        people.Remove(person);
    }
    public void MockData(List<Person> people)
    {
        this.people = people;
    }
    public List<Person> GetMockData()
    {
        return people;
    }
}
