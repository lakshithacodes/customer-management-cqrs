using CustomerManagement.RequestModels.CommandRequests;
using System.Threading.Tasks;

namespace CustomerManagement.Contracts.CommandHandlers
{
    public interface ISaveCustomerCommandHandler
    {
        Task<int> SaveAsync(SaveCustomerRequestModel saveCustomerRequestModel);
    }
}
