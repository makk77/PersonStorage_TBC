using MediatR;
using PersonStorage.Core.Application.Exceptions;
using PersonStorage.Core.Application.Interfaces;

namespace PersonStorage.Core.Application.Features.People.Commands;

public class DeletePersonRequest : IRequest
{
    public DeletePersonRequest(int id) => this.Id = id;
    public int Id { get; set; }
}

public class DeletePersonHandler : IRequestHandler<DeletePersonRequest>
{
    private readonly IUnitOfWork unit;

    public DeletePersonHandler(IUnitOfWork unit) => this.unit = unit;

    public async Task Handle(DeletePersonRequest request, CancellationToken cancellationToken)
    {
        var personEntity = await unit.PersonRepository.GetById(request.Id);
        if (personEntity == null)
        {
            throw new NotFoundException("Person Not Faund");
        }

        personEntity.DateDeleted = DateTime.Now;
        foreach (var item in personEntity.RelatedPeople)
        {
            item.DateDeleted = DateTime.Now;
        }

        await unit.PersonRepository.Update(personEntity);
        await unit.SaveAsync();
    }
}
