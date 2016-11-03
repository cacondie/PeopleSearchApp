using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Repository
{
    [Table("Person")]
    public class Person : IEntity
    {
        public Person()
        {
            Interests = new List<Interest>();
            Addresses = new List<Address>();
            Pictures = new List<Picture>();
        }
        [Key, Column("PersonId")]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(50)]
        public string FirstName { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(50)]
        public string LastName { get; set; }

        [Column(TypeName = "DATE"), Required]
        public DateTime BirthDate { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(11), Required]
        public string SSN { get; set; }

        public int Age
        {
            get
            {
                int age = (int)Math.Floor(((DateTime.Now - BirthDate).TotalDays / 365.25));

                if (age > 0)
                {
                    return age;
                }
                else
                {
                    return 0;
                }

            }
        }
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        
        
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Interest> Interests { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }

        public override string ToString()
        {
            return string.Format("ID:{0}, Name: {1} {2}, SSN: {3}", Id, FirstName, LastName, SSN);
        }
    }
}
