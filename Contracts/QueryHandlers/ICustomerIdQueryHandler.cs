using CustomerManagement.RequestModels.QueryRequests;
using CustomerManagement.ResponseModels.QueryResponses;
using System.Threading.Tasks;

namespace CustomerManagement.Contracts.QueryHandlers
{
    public interface ICustomerIdQueryHandler
    {
        Task<CustomerIdQueryResponseModel> GetCustomerAsync(CustomerIdQueryRequestModel requestModel);
    }
}

