using AutoMapper;
using MediatR;
using PersonStorage.Core.Application.DTOs;
using PersonStorage.Core.Application.Interfaces;
using PersonStorage.Core.Domain.Enums;
using PersonStorage.Core.Domain.Models;

namespace PersonStorage.Core.Application.Features.People.Commands;

public class AddNewRelatedPersonRequest : IRequest
{
    public int PersonId { get; set; }
    public PersonRelationType RelationType { get; set; }
    public SetPersonDTO RelatedPerson { get; set; }
}

public class AddNewRelatedPersonHandler : IRequestHandler<AddNewRelatedPersonRequest>
{
    private readonly IUnitOfWork unit;
    private readonly IMapper mapper;

    public AddNewRelatedPersonHandler(IUnitOfWork unit, IMapper mapper) => (this.unit, this.mapper) = (unit, mapper);
    public async Task Handle(AddNewRelatedPersonRequest request, CancellationToken cancellationToken)
    {
        var newRelatedPerson = mapper.Map<Person>(request);
        await unit.PersonRepository.AddRelatedPerson(request.PersonId, newRelatedPerson, request.RelationType);
        await unit.SaveAsync();
    }
}