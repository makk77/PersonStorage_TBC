using PersonStorage.Core.Domain.Basics;
using PersonStorage.Core.Domain.Enums;

namespace PersonStorage.Core.Domain.Models;
public class Phone : AuditableEntity
{
    public int Id { get; set; }
    public PhoneNumberType NumberType { get; set; }
    public string Number { get; set; } = null!;
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;
}