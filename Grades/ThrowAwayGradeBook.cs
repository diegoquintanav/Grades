using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook //it inherits all of the capabilites of GradeBook
    {
        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeStatistics::ThrowAwayGradeBook");
            float lowest = float.MaxValue;
            foreach (float grade in grades)
            {
                lowest = Math.Min(grade, lowest);
            }

            grades.Remove(lowest);
            Console.WriteLine($"Note that the lowest grade ({lowest}) was removed from the list!");
            return base.ComputeStatistics();
        }
        
    }
}
