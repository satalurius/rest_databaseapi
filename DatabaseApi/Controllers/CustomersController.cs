using DatabaseApi.Dtos;
using DatabaseApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseApi.Controllers
{
    [Route("customers")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomersRepository repository;

        public CustomersController(ICustomersRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetItemsAsync()
        {
            var items = await repository.GetItemsAsync();

            return items;
        }

        [HttpGet("{ctrNumber}")]
        public async Task<ActionResult<Customer>> GetSingleItemAsync(int ctrNumber)
        {
            var item = await repository.GetItemAsync(ctrNumber);

            if (item is null)
                return NotFound();

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<CreateCustomerDto>> CreateItemAsync(CreateCustomerDto createCustomer)
        {
            if (createCustomer.CtrNumber <= 0)
                return BadRequest();

            Customer customer = new()
            {
                CtrNumber = createCustomer.CtrNumber,
                FirstName = createCustomer.FirstName,
                LastName = createCustomer.LastName,
                Email = createCustomer.Email,
                CurrentBalance = createCustomer.CurrentBalance,
                PhoneNumber = createCustomer.PhoneNumber,
            };

            var checkForExist = repository.CheckExistForCreating(createCustomer);

            if (checkForExist == true)
                return NotFound();

            await repository.CreateItemAsync(customer);

            
            return CreatedAtAction(nameof(CreateItemAsync), customer);
        }


        [HttpDelete("{ctrNumber}")]
        public async Task<ActionResult> DeleteItem(int ctrNumber)
        {
            var existingItem = await repository.GetItemAsync(ctrNumber);

            if (existingItem is null)
                return NotFound();

            await repository.DeleteItemAsync(ctrNumber);

            return NoContent();
        }

        
    }
}
