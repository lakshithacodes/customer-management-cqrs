using CustomerManagement.Contracts.CommandHandlers;
using CustomerManagement.Contracts.QueryHandlers;
using CustomerManagement.RequestModels.CommandRequests;
using CustomerManagement.RequestModels.QueryRequests;
using CustomerManagement.ResponseModels.QueryResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ISaveCustomerCommandHandler saveCustomerCommandHandler;
        private readonly IAllCustomerQueryHandler allCustomerQueryHandler;
        private readonly ICustomerIdQueryHandler customerIdQueryHandler;

        public CustomerController(
            ISaveCustomerCommandHandler saveCustomerCommandHandler,
            IAllCustomerQueryHandler allCustomerQueryHandler, 
            ICustomerIdQueryHandler customerIdQueryHandler)
        {
            this.saveCustomerCommandHandler = saveCustomerCommandHandler;
            this.allCustomerQueryHandler = allCustomerQueryHandler;
            this.customerIdQueryHandler = customerIdQueryHandler;
        }

        [HttpPost]
        [Route("save-customer")]
        public async Task<IActionResult> SaveCustomerAsync(SaveCustomerRequestModel requestModel)
        {
            try
            {
                var result = await this.saveCustomerCommandHandler.SaveAsync(requestModel);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<List<AllCustomerQueryResponseModel>> GetAllCustomerAsync()
        {
            try
            {
                return await this.allCustomerQueryHandler.GetAllAsync();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("customer-id")]
        [ProducesResponseType(typeof(CustomerIdQueryResponseModel),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCustomerAsync([FromQuery] CustomerIdQueryRequestModel model)
        {
            try
            {
                var result = await this.customerIdQueryHandler.GetCustomerAsync(model);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound($"Customer Id '{model.CustomerId}' does not exists!!");
            }
            catch
            {
                throw;
            }
        }
    }
}
