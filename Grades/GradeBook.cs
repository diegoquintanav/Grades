using System;
using System.Collections.Generic; // allows to store multiple things
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    //
    public class GradeBook //"internal" by default
    {

        public GradeBook()//a constructor
        {
            _name = "Empty";
            grades = new List<float>();
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            stats.HighestGrade = 0;//we initialize the field to 0.
            
            float sum = 0;
            foreach(float grade in grades)
            {
                //if (grade > stats.HighestGrade)
                //{
                //    stats.HighestGrade = grade;
                //} //that's one way to do it

                stats.HighestGrade = Math.Max(grade, stats.HighestGrade); //choose the highest grade
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade); //choose the highest grade
                sum = sum + grade; //sum += grade is an equivalent expression
            }
            stats.AverageGrade = sum / grades.Count; //it won't handle a dividebyzero exception

            return stats;
        }

        public void WriteGrades(TextWriter destination)
        {
            for (int i =  grades.Count; i>0 ; i--)
            {
                destination.WriteLine(grades[i-1]);
            }
        }

        public void AddGrade(float grade) // we should use floating point precision for grades.
        {
            grades.Add(grade);         
        }


        //Fields
    public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if (_name != value) //Name in fact changing. I want to set this as a trigger, setting a delegate
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.ExistingName = _name;
                        args.NewName = value;
                        NameChanged(this,args); //I should pass myself, with an implicit reference to the gradebook object that we are currently operating. Check using point and see the context menu displayed.
                        // invoking the method NameChanged invokes a delegate (see the public field of type NameChangedDelegate below) that points
                        //to any method taking two strings as parameter and a void return type. 
                    }
                    _name = value; //i require the newset name not to be empty or null
                }
            } //Now name is a property
        }
        public event NameChangedDelegate NameChanged; //a public field using a delegate. Adding the keyword event to it forces the delegate to be updated only and it cannot be assigned to some other things.
        //updated means more delegates added or removed from it. We call this subscribing to the delegate-
        private string _name; //_ uised for hidden or private fields
        private List<float> grades; //creates a FIELD for the class; it has a listr called "grades". If I make a member Public, then it should have first caps on it. default is private
        //if I'm gonna set the field as public I would normally do it making it a property

        //public string Name; //it's in capitals because it's public

        //I can change the field into a property writing get and set methods:
    

        //about keyword "static" field or method: you can access to it without creating an instance, just referencing it outside. Example is WriteLine, you don't need to create an instance of Console 
        //so you can use Console.WriteLine();

    }
}
