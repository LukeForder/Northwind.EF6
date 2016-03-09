using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class Supplier
    {
        public Supplier()
        {
            Contact = new ExternalContact();
            Address = new Address();
        }

        public virtual int Id { get; set; }
        public virtual ExternalContact Contact { get; set; }
        public virtual Address Address { get; set; }
        public virtual string HomePage { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
