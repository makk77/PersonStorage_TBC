using PersonStorage.Core.Domain.Enums;
using PersonStorage.Core.Domain.Models;

namespace PersonStorage.Infrastructure.Persistence.Configurations.DataSeed;

internal static class PersonSeed
{
    internal static readonly Person MariamKurkumuli = new Person
    {
        Id = 1,
        FirstName = "Mariam",
        LastName = "Kurkumuli",
        PersonalNumber = "00000000000",
        BirthDate = DateTime.Now.AddYears(-25),
        Gender = Gender.Male,
        CityId = CitySeed.Mtsketa.Id,
        DateCreated = DateTime.Now,
        LastUpdateDate = null,
        DateDeleted = null
    };

    internal static readonly Person PavlePavliashvili = new Person
    {
        Id = 2,
        FirstName = "Pavle",
        LastName = "Pavliashvili",
        PersonalNumber = "11111111111",
        BirthDate = DateTime.Now.AddYears(-27),
        Gender = Gender.Male,
        CityId = CitySeed.Tbilisi.Id,
        DateCreated = DateTime.Now,
        LastUpdateDate = null,
        DateDeleted = null
    };

    internal static readonly Person NinoNinidze = new Person
    {
        Id = 3,
        FirstName = "Nino",
        LastName = "Ninidze",
        PersonalNumber = "22222222222",
        BirthDate = DateTime.Now.AddYears(-29),
        Gender = Gender.Female,
        CityId = CitySeed.Tbilisi.Id,
        DateCreated = DateTime.Now,
        LastUpdateDate = null,
        DateDeleted = null
    };

    internal static readonly Person MariamMariamidze = new Person
    {
        Id = 4,
        FirstName = "Mariam",
        LastName = "Mariamidze",
        PersonalNumber = "33333333333",
        BirthDate = DateTime.Now.AddYears(-19),
        Gender = Gender.Female,
        CityId = CitySeed.Kutaisi.Id,
        DateCreated = DateTime.Now,
        LastUpdateDate = null,
        DateDeleted = null
    };
}
