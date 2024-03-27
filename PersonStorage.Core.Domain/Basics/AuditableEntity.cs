namespace PersonStorage.Core.Domain.Basics;
public class AuditableEntity
{
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime? LastUpdateDate { get; set; }
    public DateTime? DateDeleted { get; set; }
}