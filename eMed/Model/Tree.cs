using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMed.Model
{
    class Tree
    {
        public Tree childTree { get; set; }
        public bool childFilePath { get; set; }
        public qm_tree content { get; set; }
    }
}
