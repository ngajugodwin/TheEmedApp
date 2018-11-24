using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMed.Model
{
    class CheckListBoxItem
    {
        public int Tag;
        public string Text;
        public override string ToString() { return Text; }
    }
}
