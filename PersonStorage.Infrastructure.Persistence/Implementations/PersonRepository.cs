using Microsoft.EntityFrameworkCore;
using PersonRegister.Infrastructure.Database.Persistence.Context;
using PersonStorage.Core.Application.Commons.Paging;
using PersonStorage.Core.Application.DTOs.Attributes;
using PersonStorage.Core.Application.DTOs.Filtering;
using PersonStorage.Core.Application.Interfaces.Repositories;
using PersonStorage.Core.Domain.Enums;
using PersonStorage.Core.Domain.Models;
using PersonStorage.Infrastructure.Persistence.Extensions;
using System.Linq;

namespace PersonRegister.Infrastructure.Database.Persistence.Implementations;

internal class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(PersonDbContext context) : base(context) { }

    public async Task AddRelatedPerson(int personId, int relatedPersonId, PersonRelationType relationType)
    {
        var personRelation = new PersonRelation { PersonId = personId, RelatedPersonId = relatedPersonId, RelationType = relationType };
        await context.PersonRelations.AddAsync(personRelation);
    }

    public async Task AddRelatedPerson(int personId, Person relatedPerson, PersonRelationType relationType)
    {
        var personRelation = new PersonRelation { PersonId = personId, RelatedPerson = relatedPerson, RelationType = relationType };
        await context.PersonRelations.AddAsync(personRelation);
    }

    public override async Task<Person> GetById(int id)
    {
        var person = await context.People.Where(x => x.DateDeleted == null)
            .Include(x => x.City)
            .Include(x => x.Phones)
            .Include(x => x.RelatedPeople)
                .ThenInclude(x => x.RelatedPerson)
                    .ThenInclude(x => x.Phones)
            .FirstOrDefaultAsync(x => x.Id == id);

        return person;
    }

    public async Task<PersonRelation> GetrelationPerson(int personId, int relationPersoId)
    {
        var relationPerson = await context.PersonRelations.Where(x => x.PersonId == personId && x.RelatedPersonId == relationPersoId && x.DateDeleted == null)
            .FirstOrDefaultAsync();

        return relationPerson;
    }

    public async Task<PageResponse<Person>> GetAll(PageRequest pageRequest, PeopleFilter peopleFilter = null)
    {
        var query = context.People
         .Include(x => x.City)
         .Include(x => x.Phones)
         .Include(x => x.RelatedPeople)
             .ThenInclude(x => x.RelatedPerson)
                 .ThenInclude(x => x.Phones)
         .ApplyFilterParameters(peopleFilter);

        var data = await query.Skip(pageRequest.PageNumber - 1).Take(pageRequest.PageSize).ToListAsync();
        var count = await query.CountAsync();

        var res = new PageResponse<Person>
        {
            Data = data,
            CurrentPage = pageRequest.PageNumber,
            PageSize = pageRequest.PageSize,
            TotalCount = count
        };
        return res;
    }

    public async Task<PageResponse<Person>> GetQuickSerachData(PageRequest pageRequest, PeopleQuickFilter peopleFilter = null)
    {
        var query = context.People
         .Include(x => x.City)
         .Include(x => x.Phones)
         .Include(x => x.RelatedPeople)
             .ThenInclude(x => x.RelatedPerson)
                 .ThenInclude(x => x.Phones)
         .GetQuickSearchData(peopleFilter);

        var data = await query.Skip(pageRequest.PageNumber - 1).Take(pageRequest.PageSize).ToListAsync();
        var count = await query.CountAsync();

        var res = new PageResponse<Person>
        {
            Data = data,
            CurrentPage = pageRequest.PageNumber,
            PageSize = pageRequest.PageSize,
            TotalCount = count
        };
        return res;
    }

    public Task DeleteRelationPerosn(PersonRelation entity)
    {
        context.Set<PersonRelation>().Update(entity);
        return Task.CompletedTask;
    }
}

