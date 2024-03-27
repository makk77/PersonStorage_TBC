using AutoMapper;
using MediatR;
using PersonStorage.Core.Application.DTOs;
using PersonStorage.Core.Application.Interfaces;

namespace PersonStorage.Core.Application.Features.People.Commands.Queries;

public class GetPersonByIdRequest : IRequest<GetPersonDTO>
{
    public int Id { get; set; }
    public GetPersonByIdRequest(int id) => this.Id = id;
}

public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdRequest, GetPersonDTO>
{
    private readonly IUnitOfWork unit;
    private readonly IMapper mapper;

    public GetPersonByIdHandler(IUnitOfWork unit, IMapper mapper) => (this.unit, this.mapper) = (unit, mapper);
    public async Task<GetPersonDTO> Handle(GetPersonByIdRequest request, CancellationToken cancellationToken)
    {
        var person = await unit.PersonRepository.GetById(request.Id);
        return mapper.Map<GetPersonDTO>(person);
    }
}
