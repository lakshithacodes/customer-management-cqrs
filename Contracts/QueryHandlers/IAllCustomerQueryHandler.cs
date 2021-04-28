using CustomerManagement.ResponseModels.QueryResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.Contracts.QueryHandlers
{
    public interface IAllCustomerQueryHandler
    {
        Task<List<AllCustomerQueryResponseModel>> GetAllAsync();
    }
}
