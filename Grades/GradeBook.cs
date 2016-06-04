using System;
using System.Collections;
using System.Collections.Generic; // allows to store multiple things
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    //
    public class GradeBook : GradeTracker //"internal" by default
    {

        public GradeBook()//a constructor
        {
            _name = "Empty";
            grades = new List<float>();
        }

        public bool ThrowAwayLowest { get; set; }



        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeStatistics::GradeBook");
            GradeStatistics stats = new GradeStatistics();
            stats.HighestGrade = 0;//we initialize the field to 0.



            float sum = 0;
            foreach (float grade in grades)
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

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i - 1]);
            }
        }

        public override void AddGrade(float grade) // we should use floating point precision for grades.
        {
            grades.Add(grade);
        }

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }

        protected List<float> grades; //creates a FIELD for the class; it has a listr called "grades". If I make a member Public, then it should have first caps on it. default is private
                                      //if I'm gonna set the field as public I would normally do it making it a property

        //public string Name; //it's in capitals because it's public

    }
}
