using PersonRegister.Core.Application.RequestsHelper.DTOs.Reports;

namespace PersonStorage.Core.Application.Interfaces.Reports;

public interface IPersonReport
{
    Task<List<PersonRelationAmountsDTO>> GetPersonRelationAmounts();
}
