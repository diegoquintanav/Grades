using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public delegate void NameChangedDelegate(object sender, NameChangedEventArgs args); //I can point this delegate to any method taking two strings as parameter and a void return type
                                                                                        // the sender/args is a C# convention.
                                                                                        //object specifies that the passed parameter can be anything.
    
}
