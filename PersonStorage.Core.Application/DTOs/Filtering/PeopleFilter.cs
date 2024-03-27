namespace PersonStorage.Core.Application.DTOs.Attributes;

public class PeopleFilter
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PeronalNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    public int CityId { get; set; }
    public string? City { get; set; }
    public bool? HasPhoto { get; set; } 
    public string? RelatedPersonFirstName { get; set; }
    public string? RelatedPersonLastName { get; set; }
    public string? RelatedPersonPn { get; set; }
}
