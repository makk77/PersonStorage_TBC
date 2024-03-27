using AutoMapper;
using MediatR;
using PersonStorage.Core.Application.DTOs;
using PersonStorage.Core.Application.Interfaces;
using PersonStorage.Core.Domain.Models;

namespace PersonStorage.Core.Application.Features.People.Commands;

public class AddPersonRequest : SetPersonDTO, IRequest
{ }

public class AddPersonHandler : IRequestHandler<AddPersonRequest>
{
    private readonly IUnitOfWork unit;
    private readonly IMapper mapper;

    public AddPersonHandler(IUnitOfWork unit, IMapper mapper) => (this.unit, this.mapper) = (unit, mapper);

    public async Task Handle(AddPersonRequest request, CancellationToken cancellationToken)
    {
        var person = mapper.Map<Person>(request);
        await unit.PersonRepository.Create(person);
        await unit.SaveAsync();
    }
}
