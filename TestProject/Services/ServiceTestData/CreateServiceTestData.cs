using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;
using System.Net;

namespace TestProject.Services.ServiceTestData;

public class PersonInvalidTestData : TheoryData<Person>
{
    public PersonInvalidTestData()
    {
        Add(new Person());
        Add(new Person()
        {
            FirstName = "Nguyen",
            LastName = "Nguyen",
            BirthPlace = "Hanoi",
            DateOfBirth = DateTime.Now,
            PhoneNumber = "0123456789",
            IsGraduated = true
        });
        Add(new Person()
        {
            FirstName = "",
            LastName = "Nguyen",
            BirthPlace = "",
            DateOfBirth = DateTime.Now,
            PhoneNumber = "",
            IsGraduated = true
        });
    }
}
public class PersonValidTestData : TheoryData<Person>
{
    public PersonValidTestData()
    {
        Add(new Person()
        {
            FirstName = "Trang",
            LastName = "Nguyen",
            BirthPlace = "Hanoi",
            DateOfBirth = new DateTime(2003, 07, 30),
            PhoneNumber = "0123456789",
            IsGraduated = true
        });
        Add(new Person()
        {
            FirstName = "Viet",
            LastName = "Quach",
            BirthPlace = "Hanoi",
            DateOfBirth = new DateTime(2003, 12, 23),
            PhoneNumber = "0123456789",
            IsGraduated = true
        });
    }
}
