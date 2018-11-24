using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMed.Model
{
    class UserAttendanceDTo
    {
        public int Id { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public long? Duration { get; set; }
    }
}
