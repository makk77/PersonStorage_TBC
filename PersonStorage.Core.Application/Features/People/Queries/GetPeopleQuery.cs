using AutoMapper;
using MediatR;
using PersonStorage.Core.Application.Commons.Paging;
using PersonStorage.Core.Application.DTOs;
using PersonStorage.Core.Application.DTOs.Attributes;
using PersonStorage.Core.Application.Interfaces;

namespace PersonStorage.Core.Application.Features.People.Queries;
public class GetPeopleRequest : IRequest<PageResponse<GetPersonDTO>>
{
    public PageRequest PageRequest;
    public PeopleFilter PeopleFilter;

    public GetPeopleRequest(PageRequest pageRequest, PeopleFilter peopleFilter) =>
                            (this.PageRequest, this.PeopleFilter) = (pageRequest, peopleFilter);
}

public class GetPeopleHandler : IRequestHandler<GetPeopleRequest, PageResponse<GetPersonDTO>>
{
    private readonly IUnitOfWork unit;
    private readonly IMapper mapper;

    public GetPeopleHandler(IUnitOfWork unit, IMapper mapper) => (this.unit, this.mapper) = (unit, mapper);
    public async Task<PageResponse<GetPersonDTO>> Handle(GetPeopleRequest request, CancellationToken cancellationToken)
    {
        var people = await unit.PersonRepository.GetAll(request.PageRequest, request.PeopleFilter);
        return mapper.Map<PageResponse<GetPersonDTO>>(people);
    }
}
