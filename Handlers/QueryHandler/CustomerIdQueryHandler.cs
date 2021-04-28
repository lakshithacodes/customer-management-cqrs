using CustomerManagement.Contracts.QueryHandlers;
using CustomerManagement.Data;
using CustomerManagement.RequestModels.QueryRequests;
using CustomerManagement.ResponseModels.QueryResponses;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Handlers.QueryHandler
{
    public class CustomerIdQueryHandler : ICustomerIdQueryHandler
    {
        private readonly CustomerDbContext context;
        public CustomerIdQueryHandler(CustomerDbContext context)
        {
            this.context = context;
        }
        public async Task<CustomerIdQueryResponseModel> GetCustomerAsync(CustomerIdQueryRequestModel requestModel)
        {
            var result = await this.context.PersonalDetails.Where(p => p.Id == requestModel.CustomerId)
                        .FirstOrDefaultAsync();

            if (result!= null)
            {
                return new CustomerIdQueryResponseModel
                {
                    CustomerId = result.Id,
                    Name = $"{result.Title}.{result.Name}",
                    City = result.City
                };
            }

            return null;
        }
    }
}

