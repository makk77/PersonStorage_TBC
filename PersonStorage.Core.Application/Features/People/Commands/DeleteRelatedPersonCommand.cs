using MediatR;
using PersonStorage.Core.Application.Exceptions;
using PersonStorage.Core.Application.Interfaces;

namespace PersonStorage.Core.Application.Features.People.Commands;

public class DeleteRelatedPersonRequest : IRequest
{
    public int PersonId { get; set; }
    public int RelatedPersonId { get; set; }
}

public class DeleteRelatedPersonHandler : IRequestHandler<DeleteRelatedPersonRequest>
{
    private readonly IUnitOfWork unit;
    public DeleteRelatedPersonHandler(IUnitOfWork unit) => this.unit = unit;

    public async Task Handle(DeleteRelatedPersonRequest request, CancellationToken cancellationToken)
    {
        var personEntity = await unit.PersonRepository.GetrelationPerson(request.PersonId, request.RelatedPersonId);
        if (personEntity == null)
        {
            throw new NotFoundException("Person Not Faund");
        }

        personEntity.DateDeleted = DateTime.Now;

        await unit.PersonRepository.DeleteRelationPerosn(personEntity);
        await unit.SaveAsync();
    }
}
