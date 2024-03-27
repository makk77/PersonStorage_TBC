using PersonStorage.Core.Application.Commons.Paging;
using PersonStorage.Core.Application.DTOs.Attributes;
using PersonStorage.Core.Application.DTOs.Filtering;
using PersonStorage.Core.Domain.Enums;
using PersonStorage.Core.Domain.Models;

namespace PersonStorage.Core.Application.Interfaces.Repositories;

public interface IPersonRepository : IRepository<Person>
{
    Task AddRelatedPerson(int personId, int relatedPersonId, PersonRelationType relationType);
    Task AddRelatedPerson(int personId, Person relatedPerson, PersonRelationType relationType);
    Task<PageResponse<Person>> GetAll(PageRequest pageRequest, PeopleFilter peopleFilter = null);
    Task<PersonRelation> GetrelationPerson(int personId, int relationPersoId);
    Task DeleteRelationPerosn(PersonRelation entity);
    Task<PageResponse<Person>> GetQuickSerachData(PageRequest pageRequest, PeopleQuickFilter peopleFilter = null);
}
