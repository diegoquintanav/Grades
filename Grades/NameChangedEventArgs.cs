using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class NameChangedEventArgs : EventArgs //this a POO property. This means that NameChangedEventArgs derives from EventArgs, a system class. This is called Inheritance.
    {
        public string ExistingName { get; set; }
        public string NewName { get; set; }
    }
}
