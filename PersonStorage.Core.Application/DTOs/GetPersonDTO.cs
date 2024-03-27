using FluentValidation;
using PersonStorage.Core.Domain.Enums;

namespace PersonStorage.Core.Application.DTOs;

public class GetPersonDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public string PeronalNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public string City { get; set; }
    public int CityId { get; set; }
    public string PhotoPath { get; set; }
    public IEnumerable<PhoneDTO> Phones { get; set; }
    public IEnumerable<RelatedPersonDTO> RelatedPeople { get; set; }
}