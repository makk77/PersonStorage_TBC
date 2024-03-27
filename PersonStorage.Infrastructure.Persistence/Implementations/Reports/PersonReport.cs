using Microsoft.EntityFrameworkCore;
using PersonRegister.Core.Application.RequestsHelper.DTOs.Reports;
using PersonRegister.Infrastructure.Database.Persistence.Context;
using PersonStorage.Core.Application.Interfaces.Reports;

namespace PersonRegister.Infrastructure.Database.Persistence.Implementations.Reports;

internal class PersonReport : IPersonReport
{
    private readonly PersonDbContext context;
    public PersonReport(PersonDbContext context) => this.context = context;

    public Task<List<PersonRelationAmountsDTO>> GetPersonRelationAmounts() =>
            (from p in context.People
             join r in context.PersonRelations
             on p.Id equals r.PersonId
             group r by new { p.Id, p.FirstName, p.LastName, p.PersonalNumber, r.RelationType, p.DateDeleted }
             into gr
             select new PersonRelationAmountsDTO
             {
                 Id = gr.Key.Id,
                 FirstName = gr.Key.FirstName,
                 LastName = gr.Key.LastName,
                 Pn = gr.Key.PersonalNumber,
                 RelationType = gr.Key.RelationType,
                 RelatedPeopleAmount = gr.Count(),
                 DateDeleted = gr.Key.DateDeleted
             }).Where(x => x.DateDeleted == null).ToListAsync();
}
