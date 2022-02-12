using DatabaseApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseApi.Repositories
{
    public interface ICustomersRepository
    {
        Task<Customer> GetItemAsync(int ctrNumber);
        Task<IEnumerable<Customer>> GetItemsAsync();

        Task CreateItemAsync(Customer item);
        
        Task DeleteItemAsync(int ctrNumber);
        public bool CheckExistForCreating(CreateCustomerDto item);
        
    }
}
