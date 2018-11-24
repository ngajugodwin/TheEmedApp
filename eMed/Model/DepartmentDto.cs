using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMed.Model
{
    public class DepartmentDto
    {
        public int department_id { get; set; }
        public string department_name { get; set; }
        public int user_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
    }
}
