using PersonStorage.Core.Domain.Basics;
using PersonStorage.Core.Domain.Enums;

namespace PersonStorage.Core.Domain.Models;
public class Person : AuditableEntity
{
    public Person()
    {
        Phones = new HashSet<Phone>();
        RelatedPeople = new HashSet<PersonRelation>();
    }
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public Gender Gender { get; set; }
    public string PersonalNumber { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public int CityId { get; set; }
    public City City { get; set; } = null!;
    public ICollection<Phone> Phones { get; set; }
    public string? PhotoPath { get; set; } 
    public ICollection<PersonRelation> RelatedPeople { get; set; }
}
