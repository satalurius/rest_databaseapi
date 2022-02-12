using DatabaseApi.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseApi.Repositories
{
    public class SqlLiteDbCustomersAddressRepository : ICustomerAddressRepository
    {

        public async Task<IEnumerable<CustomersAddress>> GetItemsAsync()
        {
            using(var db = new DbAppContext())
            {
                var items = db.CustomersAddresses.ToList();

                return await Task.FromResult(items);
            }
        }
        public async Task<CustomersAddress> GetItemAsync(int casId)
        {
            using(var db = new DbAppContext())
            {
                var item = db.CustomersAddresses.Where(x => x.CasId == casId).FirstOrDefault();

                return await Task.FromResult(item);
            }
        }
        public async Task CreateItemAsync(CustomersAddress item)
        {
            using (var db = new DbAppContext())
            {
                await db.CustomersAddresses.AddAsync(item);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteItemAsync(int casId)
        {
            using (var db = new DbAppContext())
            {
                var item = db.CustomersAddresses.Where(x => x.CasId == casId).FirstOrDefault();

                db.CustomersAddresses.Remove(item);
                await db.SaveChangesAsync();
            }

        }

        public bool CheckExistForCreating(CreateCustomerAddressDto customersAddress)
        {
            using (var db = new DbAppContext())
            {
                bool check = db.CustomersAddresses.Any(x => x.CasId == customersAddress.CasId);

                return check;
            }
        }

        public bool CheckForRealCtrNumber(CreateCustomerAddressDto customersAddress)
        {

            // Если проверка положительная, то в таблице адресс, указаны правильные значения 
            using(var db = new DbAppContext())
            {
                var cusAddrDb = db.CustomersAddresses;
                var cus = db.Customers;

                bool check = cus.Any(x => x.CtrNumber == customersAddress.CtrNumber);

                return check;

            }
        }
    }
}
