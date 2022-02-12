using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DatabaseApi
{
    [Table("customers_addresses")]
    public partial class CustomersAddress
    {
        [Key]
        [Column("cas_id")]
        public int CasId { get; set; }
        public string City { get; set; }
        [Column("postal_code")]
        public string PostalCode { get; set; }

        [Column("ctr_number")]
        public int CtrNumber { get; set; }

        public virtual Customer CtrNumberNavigation { get; set; }
    }
}
