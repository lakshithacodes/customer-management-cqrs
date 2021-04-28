using CustomerManagement.Contracts.QueryHandlers;
using CustomerManagement.Data;
using CustomerManagement.ResponseModels.QueryResponses;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Handlers.QueryHandler
{
    public class AllCustomerQueryHandler : IAllCustomerQueryHandler
    {
        private readonly CustomerDbContext context;

        public AllCustomerQueryHandler(CustomerDbContext context)
        {
            this.context = context;
        }
        public async Task<List<AllCustomerQueryResponseModel>> GetAllAsync()
        {
            return await this.context.PersonalDetails.Select(s => new AllCustomerQueryResponseModel
            {
                CustomerId = s.Id,
                Name = $"{s.Title}.{s.Name }",
                City = s.City,
                LoyaltyPoints = s.LoyaltyPoints
            }).ToListAsync();
        }
    }
}
