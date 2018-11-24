using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMed.Model
{
    public class CaseNoteDto
    {
        public DateTime? CreatedAt { get; set; }
        public string Attachment { get; set; }
        public string CategoryName { get; set; }
        public string CreatedBy { get; set; }
        public string EntryText { get; set; }
    }
}
