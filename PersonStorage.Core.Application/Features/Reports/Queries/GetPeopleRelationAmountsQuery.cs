using MediatR;
using PersonRegister.Core.Application.RequestsHelper.DTOs.Reports;
using PersonStorage.Core.Application.Interfaces;

namespace PersonStorage.Core.Application.Features.Reports.Queries;
public class GetPeopleRelationAmountsRequest : IRequest<IEnumerable<PersonRelationAmountsDTO>> { }

public class GetPeopleRelationAmountsHandler : IRequestHandler<GetPeopleRelationAmountsRequest, IEnumerable<PersonRelationAmountsDTO>>
{
    private readonly IUnitOfWork unit;
    public GetPeopleRelationAmountsHandler(IUnitOfWork unit) => this.unit = unit;

    public async Task<IEnumerable<PersonRelationAmountsDTO>> Handle(GetPeopleRelationAmountsRequest request, CancellationToken cancellationToken)
    {
        return await unit.PersonReport.GetPersonRelationAmounts();
    }
}
