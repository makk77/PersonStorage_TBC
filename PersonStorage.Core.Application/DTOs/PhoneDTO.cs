using PersonStorage.Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonStorage.Core.Application.DTOs;

public class PhoneDTO
{
    [MaxLength(50, ErrorMessage = "სიმბოლოების მაქსიმალური რაოდენობა არის 50.")]
    [MinLength(2, ErrorMessage = "სიმბოლოების მინიმალური რაოდენობა არის 2.")]
    public string Number { get; set; }
    public PhoneNumberType NumberType { get; set; }
}
