using PersonStorage.Core.Application.Commons;
using PersonStorage.Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonStorage.Core.Application.DTOs;

public class SetPersonDTO
{
    [Required(ErrorMessageResourceType = (typeof(Resources.ErrorTextsResources)), ErrorMessageResourceName = "NameRequired")]
    [MaxLength(50, ErrorMessageResourceType = (typeof(Resources.ErrorTextsResources)), ErrorMessageResourceName = "NameSymbolMaxCount")]
    [MinLength(2, ErrorMessageResourceType = (typeof(Resources.ErrorTextsResources)), ErrorMessageResourceName = "NameSymbolMinCount")]
    [RegularExpression("^[ა-ჰ]*$|^[a-zA-Z]*$", ErrorMessageResourceType = (typeof(Resources.ErrorTextsResources)), ErrorMessageResourceName = "NameOnlyGeorgianLatin")]
    public string FirstName { get; set; }

    [Required(ErrorMessageResourceType = (typeof(Resources.ErrorTextsResources)), ErrorMessageResourceName = "LastNameRequired")]
    [MaxLength(50, ErrorMessageResourceType = (typeof(Resources.ErrorTextsResources)), ErrorMessageResourceName = "NameSymbolMaxCount")]
    [MinLength(2, ErrorMessageResourceType = (typeof(Resources.ErrorTextsResources)), ErrorMessageResourceName = "NameSymbolMinCount")]
    [RegularExpression("^[ა-ჰ]*$|^[a-zA-Z]*$", ErrorMessageResourceType = (typeof(Resources.ErrorTextsResources)), ErrorMessageResourceName = "NameOnlyGeorgianLatin")]
    public string LastName { get; set; }
    public Gender Gender { get; set; }

    [StringLength(11, ErrorMessageResourceType = (typeof(Resources.ErrorTextsResources)), ErrorMessageResourceName = "PrivateNumberLength")]
    [RegularExpression("^[0-9]*$", ErrorMessageResourceType = (typeof(Resources.ErrorTextsResources)), ErrorMessageResourceName = "PrivateNumberOnlyIntegers")]
    public string PersonalNumber { get; set; }

    [Required(ErrorMessageResourceType = (typeof(Resources.ErrorTextsResources)), ErrorMessageResourceName = "BirthDateRequired")]
    [MinAgeAttribute(18, ErrorMessageResourceType = (typeof(Resources.ErrorTextsResources)), ErrorMessageResourceName = "PersonAgeMustBeGreater18")]
    public DateTime BirthDate { get; set; }
    public int CityId { get; set; }
    public IEnumerable<PhoneDTO> Phones { get; set; }
}
