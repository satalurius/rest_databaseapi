
using DatabaseApi.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseApi.Repositories
{
    public class SqlLiteDbCustomersRepository : ICustomersRepository
    {
        public async Task<IEnumerable<Customer>> GetItemsAsync()
        {
            using(var db = new DbAppContext())
            {
                var customers = db.Customers.ToList();

                return await Task.FromResult(customers);
            }
        }


        public async Task<Customer> GetItemAsync(int ctrNumber)
        {
            using(var db = new DbAppContext())
            {
                var item = db.Customers.Where(x => x.CtrNumber == ctrNumber).FirstOrDefault();

                return await Task.FromResult(item);
            }
        }

        public bool CheckExistForCreating(CreateCustomerDto item)
        {
            using (var db = new DbAppContext())
            {
                bool check = db.Customers.Any(x => x.CtrNumber == item.CtrNumber);
                
                return check;
            }
            
        }
        public async Task CreateItemAsync(Customer item)
        {
           using(var db = new DbAppContext())
            {            
                await db.Customers.AddAsync(item);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteItemAsync(int ctrNumber)
        {
            using (var db = new DbAppContext())
            {
                var item = db.Customers.Where(x => x.CtrNumber == ctrNumber).FirstOrDefault();
                db.Customers.Remove(item);
                await db.SaveChangesAsync();

            }
        }

    }
}
