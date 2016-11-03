using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Repository
{
    public class Interest : IEntity
    {
        [Key, Column("InterestId")]
        public int Id { get; set; }
        [Index]
        public int PersonId { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(50),Required]
        public string InterestName { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        public override string ToString()
        {
            return string.Format("ID: {0}; Interest: {1}", PersonId, InterestName);
        }
    }
}
