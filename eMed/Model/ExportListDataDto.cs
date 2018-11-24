using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMed.Model
{
    public class ExportListDataDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string EmployeeID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
    }
}
