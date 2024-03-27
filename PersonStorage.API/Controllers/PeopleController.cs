using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonStorage.API.ActionFilters;
using PersonStorage.Core.Application.Commons.Paging;
using PersonStorage.Core.Application.DTOs;
using PersonStorage.Core.Application.DTOs.Attributes;
using PersonStorage.Core.Application.DTOs.Filtering;
using PersonStorage.Core.Application.Features.People.Commands;
using PersonStorage.Core.Application.Features.People.Commands.Queries;
using PersonStorage.Core.Application.Features.People.Queries;

namespace PersonRegister.WebApi.Controllers;

[Route("[controller]")]
[ValidationFilterAttribute]
public class PeopleController : ControllerBase
{
    private readonly IMediator mediator;
    public PeopleController(IMediator mediator) => this.mediator = mediator;

    [HttpPost]
    public async Task Create([FromBody] AddPersonRequest request)
    {
        await mediator.Send(request);
    }

    [HttpPut]
    public async Task Update([FromBody] UpdatePersonRequest request)
    {
        await mediator.Send(request);
    }

    [HttpDelete]
    public async Task Delete(int id)
    {
        var request = new DeletePersonRequest(id);
        await mediator.Send(request);
    }

    [HttpPut("related-person")]
    public async Task AddRelatedPerson([FromBody] AddRelatedPersonRequest request)
    {
        await mediator.Send(request);
    }

    [HttpPost("related-person")]
    public async Task AddNewRelatedPerson([FromBody] AddNewRelatedPersonRequest request)
    {
        await mediator.Send(request);
    }

    [HttpDelete("related-person")]
    public async Task DeleteRelatedPerson(DeleteRelatedPersonRequest request)
    {
        await mediator.Send(request);
    }

    [HttpGet("{id}")]
    public async Task<GetPersonDTO> Get(int id)
    {
        var request = new GetPersonByIdRequest(id);
        return await mediator.Send(request);
    }

    [HttpGet]
    public async Task<PageResponse<GetPersonDTO>> Get([FromQuery] PeopleFilter peopleFilter = null, [FromQuery] PageRequest pageRequest = null)
    {
        return await mediator.Send(new GetPeopleRequest(pageRequest, peopleFilter));
    }

    [HttpGet("quick-search")]
    public async Task<PageResponse<GetPersonDTO>> Get([FromQuery] PeopleQuickFilter peopleQuickFilter = null, [FromQuery] PageRequest pageRequest = null)
    {
        return await mediator.Send(new GetPeopleQuickRequest(pageRequest, peopleQuickFilter));
    }

    [HttpPost("upload-photo")]
    public async Task AddPhoto([FromForm] UploadPhotoRequest request)
    {
        await mediator.Send(request);
    }
}
