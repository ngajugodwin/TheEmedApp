using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMed.Model
{
    public class PatientCartDto
    {
        /*select s.code, s.description ,sc.name, u.firstname, t.price, t.quantity*/
        public int Id { get; set; }
        public string Code { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceType { get; set; }
        public string CreatorName { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }

    }
}
