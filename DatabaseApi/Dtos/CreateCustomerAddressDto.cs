using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseApi.Dtos
{
    public class CreateCustomerAddressDto
    {
        [Key]
        [Column("cas_id")]
        public int CasId { get; set; }
        public string City { get; set; }
        [Column("postal_code")]
        public string PostalCode { get; set; }

        [Column("ctr_number")]
        public int CtrNumber { get; set; }
    }
}
