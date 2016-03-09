using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class ExternalContact
    {
        public virtual string Title { get; set; }
        public virtual string FullName { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Phone { get; set; }
    }
}
