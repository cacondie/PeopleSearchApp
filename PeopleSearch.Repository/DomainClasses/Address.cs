using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Repository
{
    public class Address : IEntity
    {
        //[Key, Column("AddressId"),ForeignKey("Person")]
        [Key, Column("AddressId")]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(50)]
        public string Street1 { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(50)]
        public string City { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(50)]
        public string State { get; set; }

        [Column(TypeName="VARCHAR"), MaxLength(15)]
        public string PostalCode { get; set; }
        [Index]
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2} {3}", Street1, City, State, PostalCode);
        }

    }
}
