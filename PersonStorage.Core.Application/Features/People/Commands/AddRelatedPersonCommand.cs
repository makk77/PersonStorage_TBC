using MediatR;
using PersonStorage.Core.Application.Interfaces;
using PersonStorage.Core.Domain.Enums;

namespace PersonStorage.Core.Application.Features.People.Commands;

public class AddRelatedPersonRequest : IRequest
{
    public int PersonId { get; set; }
    public int RelatedPersonId { get; set; }
    public PersonRelationType RelationType { get; set; }
}

public class AddRelatedPersonCommand : IRequestHandler<AddRelatedPersonRequest>
{
    private readonly IUnitOfWork unit;
    public AddRelatedPersonCommand(IUnitOfWork unit) => this.unit = unit;

    public async Task Handle(AddRelatedPersonRequest request, CancellationToken cancellationToken)
    {
        await unit.PersonRepository.AddRelatedPerson(request.PersonId, request.RelatedPersonId, request.RelationType);
        await unit.SaveAsync();
    }
}
