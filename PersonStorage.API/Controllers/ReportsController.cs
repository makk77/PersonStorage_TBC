using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonRegister.Core.Application.RequestsHelper.DTOs.Reports;
using PersonStorage.Core.Application.Features.Reports.Queries;

namespace PersonRegister.Presentation.WebApi.Controllers;

[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly IMediator mediator;
    public ReportsController(IMediator mediator) => this.mediator = mediator;

    [HttpGet("people-report")]
    public async Task<IEnumerable<PersonRelationAmountsDTO>> GetPeopleRelations()
    {
        var request = new GetPeopleRelationAmountsRequest();
        return await mediator.Send(request);
    }
}
