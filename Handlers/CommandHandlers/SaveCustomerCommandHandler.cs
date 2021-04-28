using CustomerManagement.Contracts.CommandHandlers;
using CustomerManagement.Data;
using CustomerManagement.Models;
using CustomerManagement.RequestModels.CommandRequests;
using System.Threading.Tasks;

namespace CustomerManagement.Handlers.CommandHandlers
{
    public class SaveCustomerCommandHandler : ISaveCustomerCommandHandler
    {
        private readonly CustomerDbContext context;

        public SaveCustomerCommandHandler(CustomerDbContext context)
        {
            this.context = context;
        }
        public async Task<int> SaveAsync(SaveCustomerRequestModel saveCustomerRequestModel)
        {
            var newCustomer = new PersonalDetails
            {
                Name = saveCustomerRequestModel.Name,
                Title = saveCustomerRequestModel.Title,
                City = saveCustomerRequestModel.City,
                LoyaltyPoints = saveCustomerRequestModel.LoyaltyPoints
            };

            this.context.PersonalDetails.Add(newCustomer);
            await this.context.SaveChangesAsync();
            return newCustomer.Id;
        }
    }
}
