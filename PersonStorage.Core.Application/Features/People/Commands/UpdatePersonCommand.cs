using AutoMapper;
using MediatR;
using PersonStorage.Core.Application.DTOs;
using PersonStorage.Core.Application.Exceptions;
using PersonStorage.Core.Application.Interfaces;
using PersonStorage.Core.Domain.Models;

namespace PersonStorage.Core.Application.Features.People.Commands;

public class UpdatePersonRequest : SetPersonDTO, IRequest
{
    public int Id { get; set; }
}

public class UpdatePersonHandler : IRequestHandler<UpdatePersonRequest>
{
    private readonly IUnitOfWork unit;
    private readonly IMapper mapper;

    public UpdatePersonHandler(IUnitOfWork unit, IMapper mapper) => (this.unit, this.mapper) = (unit, mapper);
    public async Task Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
    {
        var personEntity = await unit.PersonRepository.GetById(request.Id);
        if (personEntity == null)
        {
            throw new NotFoundException("Person Not Faund");
        }

        personEntity.FirstName = request.FirstName;
        personEntity.LastName = request.LastName;
        personEntity.PersonalNumber = request.PersonalNumber;
        personEntity.Gender = request.Gender;
        personEntity.CityId = request.CityId;
        personEntity.BirthDate = request.BirthDate;
        personEntity.LastUpdateDate = DateTime.Now;

        foreach (var n in personEntity.Phones)
        {
            n.DateDeleted = DateTime.Now;
        }

        foreach (var n in request.Phones)
        {
            personEntity.Phones.Add(new Phone
            {
                Number = n.Number,
                NumberType = n.NumberType,
                PersonId = personEntity.Id
            });
        }

        await unit.PersonRepository.Update(personEntity);
        await unit.SaveAsync();
    }
}