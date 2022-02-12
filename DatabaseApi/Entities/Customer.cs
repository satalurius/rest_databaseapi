using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseApi
{
    public partial class Customer
    {
       public Customer()
        {
            CustomersAddresses = new HashSet<CustomersAddress>();
        }

        [Key]
        [Column("ctr_number")]
        
        public int CtrNumber { get; set; }
        
        public string Email { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        [Column("current_balance")]
        public decimal CurrentBalance { get; set; }

        public virtual ICollection<CustomersAddress> CustomersAddresses { get; set; }
    }
}
