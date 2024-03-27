using PersonStorage.Core.Domain.Basics;
using PersonStorage.Core.Domain.Enums;

namespace PersonStorage.Core.Domain.Models;
public class PersonRelation : AuditableEntity
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;
    public int RelatedPersonId { get; set; }
    public Person RelatedPerson { get; set; } = null!;
    public PersonRelationType RelationType { get; set; }
}
