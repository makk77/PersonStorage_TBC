using AutoMapper;
using MediatR;
using PersonStorage.Core.Application.Commons.Paging;
using PersonStorage.Core.Application.DTOs;
using PersonStorage.Core.Application.DTOs.Filtering;
using PersonStorage.Core.Application.Interfaces;

namespace PersonStorage.Core.Application.Features.People.Queries
{
    public class GetPeopleQuickRequest : IRequest<PageResponse<GetPersonDTO>>
    {
        public PageRequest PageRequest;
        public PeopleQuickFilter PeopleFilter;

        public GetPeopleQuickRequest(PageRequest pageRequest, PeopleQuickFilter peopleFilter) =>
                                (this.PageRequest, this.PeopleFilter) = (pageRequest, peopleFilter);
    }

    public class GetPeopleQuickRequestHandler : IRequestHandler<GetPeopleQuickRequest, PageResponse<GetPersonDTO>>
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public GetPeopleQuickRequestHandler(IUnitOfWork unit, IMapper mapper) => (this.unit, this.mapper) = (unit, mapper);
        public async Task<PageResponse<GetPersonDTO>> Handle(GetPeopleQuickRequest request, CancellationToken cancellationToken)
        {
            var people = await unit.PersonRepository.GetQuickSerachData(request.PageRequest, request.PeopleFilter);
            return mapper.Map<PageResponse<GetPersonDTO>>(people);
        }
    }
}
