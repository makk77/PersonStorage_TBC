﻿using AutoMapper;
using PersonStorage.Core.Application.Commons.Paging;
using PersonStorage.Core.Application.DTOs;
using PersonStorage.Core.Application.Features.People.Commands;
using PersonStorage.Core.Domain.Models;

namespace PersonStorage.Core.Application.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap(typeof(PageResponse<>), typeof(PageResponse<>));

        CreateMap<PhoneDTO, Phone>();

        CreateMap<AddPersonRequest, Person>();

        CreateMap<UpdatePersonRequest, Person>();

        CreateMap<AddNewRelatedPersonRequest, Person>()
            .ForMember(entity => entity.FirstName, opt => opt.MapFrom(dto => dto.RelatedPerson.FirstName))
            .ForMember(entity => entity.LastName, opt => opt.MapFrom(dto => dto.RelatedPerson.LastName))
            .ForMember(entity => entity.Gender, opt => opt.MapFrom(dto => dto.RelatedPerson.Gender))
            .ForMember(entity => entity.PersonalNumber, opt => opt.MapFrom(dto => dto.RelatedPerson.PersonalNumber))
            .ForMember(entity => entity.BirthDate, opt => opt.MapFrom(dto => dto.RelatedPerson.BirthDate))
            .ForMember(entity => entity.CityId, opt => opt.MapFrom(dto => dto.RelatedPerson.CityId))
            .ForMember(entity => entity.Phones, opt => opt.MapFrom(dto => dto.RelatedPerson.Phones))
            .ForMember(entity => entity.Id, opt => opt.Ignore())
            .ForMember(entity => entity.RelatedPeople, opt => opt.Ignore())
            .ForMember(entity => entity.City, opt => opt.Ignore())
            .ForMember(entity => entity.PhotoPath, opt => opt.Ignore());

        CreateMap<Person, GetPersonDTO>()
            .ForMember(dto => dto.City, opt => opt.MapFrom(entity => entity.City.Name))
            .ForMember(dto => dto.RelatedPeople, opt => opt.MapFrom(entity => entity.RelatedPeople));

        CreateMap<Phone, PhoneDTO>();

        CreateMap<PersonRelation, RelatedPersonDTO>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(entity => entity.RelatedPerson.Id))
            .ForMember(dto => dto.FirstName, opt => opt.MapFrom(entity => entity.RelatedPerson.FirstName))
            .ForMember(dto => dto.LastName, opt => opt.MapFrom(entity => entity.RelatedPerson.LastName))
            .ForMember(dto => dto.Gender, opt => opt.MapFrom(entity => entity.RelatedPerson.Gender))
            .ForMember(dto => dto.PersonalNumber, opt => opt.MapFrom(entity => entity.RelatedPerson.PersonalNumber))
            .ForMember(dto => dto.BirthDate, opt => opt.MapFrom(entity => entity.RelatedPerson.BirthDate))
            .ForMember(dto => dto.CityId, opt => opt.MapFrom(entity => entity.RelatedPerson.CityId))
            .ForMember(dto => dto.City, opt => opt.MapFrom(entity => entity.RelatedPerson.City.Name))
            .ForMember(dto => dto.PhotoPath, opt => opt.MapFrom(entity => entity.RelatedPerson.PhotoPath))
            .ForMember(dto => dto.Phones, opt => opt.MapFrom(entity => entity.RelatedPerson.Phones));
    }
}
