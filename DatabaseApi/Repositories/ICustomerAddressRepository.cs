using DatabaseApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseApi.Repositories
{
    public interface ICustomerAddressRepository 
    {
        Task<IEnumerable<CustomersAddress>> GetItemsAsync();
        Task<CustomersAddress> GetItemAsync(int casId);

        Task CreateItemAsync(CustomersAddress item);
        Task DeleteItemAsync(int casId);
        bool CheckExistForCreating(CreateCustomerAddressDto customersAddress);
        bool CheckForRealCtrNumber(CreateCustomerAddressDto customersAddress);

    }
}
