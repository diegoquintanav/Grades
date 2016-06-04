using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : object, IGradeTracker //more implementations with comma
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }


                if (_name != value && NameChanged != null) //Name in fact changing. I want to set this as a trigger, setting a delegate
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;
                    NameChanged(this, args); //I should pass myself, with an implicit reference to the gradebook object that we are currently operating. Check using point and see the context menu displayed.
                                             // invoking the method NameChanged invokes a delegate (see the public field of type NameChangedDelegate below) that points
                                             //to any method taking two strings as parameter and a void return type. 
                }
                _name = value; //i require the newset name not to be empty or null

            } //Now name is a property
        }
        public event NameChangedDelegate NameChanged; //a public field using a delegate. Adding the keyword event to it forces the delegate to be updated only and it cannot be assigned to some other things.
        //updated means more delegates added or removed from it. We call this subscribing to the delegate-
        protected string _name; //_ uised for hidden or private fields

        //implementation

        public abstract IEnumerator GetEnumerator();

    }
}
