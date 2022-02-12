using DatabaseApi.Dtos;
using DatabaseApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseApi.Controllers
{
    [Route("ctr_addr")]
    [ApiController]
    public class CustomersAddressesController : Controller
    {
        private readonly ICustomerAddressRepository repository;

        public CustomersAddressesController(ICustomerAddressRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomersAddress>> GetItemsAsync()
        {
            var items = await repository.GetItemsAsync();

            return items;
        }

        [HttpGet("{casId}")]
        public async Task<ActionResult<CustomersAddress>> GetSingleItemAsync(int casId)
        {
            var item = await repository.GetItemAsync(casId);

            if (item is null)
                return NotFound();

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<CustomersAddress>> CreateItemAsync(CreateCustomerAddressDto customersAddress)
        {
            CustomersAddress newCustomer = new()
            {
                CasId = customersAddress.CasId,
                City = customersAddress.City,
                CtrNumber = customersAddress.CtrNumber,
                PostalCode = customersAddress.PostalCode
            };

            var checkForExist = repository.CheckExistForCreating(customersAddress);

            if (checkForExist)
                return NotFound();

            var checkRealCtrNumber = repository.CheckForRealCtrNumber(customersAddress);

            if (!checkRealCtrNumber)
                return BadRequest();

            await repository.CreateItemAsync(newCustomer);

            return CreatedAtAction(nameof(CreateItemAsync), newCustomer);
        }

        [HttpDelete("{casId}")]
        public async Task<ActionResult> DeleteItemAsync(int casId)
        {
            var existingItem = repository.GetItemAsync(casId);

            if (existingItem is null)
                return NotFound();

            await repository.DeleteItemAsync(casId);

            return NoContent();
        }
    }
}
