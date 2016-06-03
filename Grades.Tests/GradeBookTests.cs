using Microsoft.VisualStudio.TestTools.UnitTesting; //needs to be added
using Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Scott"; //string is a reference type, don't let anyone ever tell you otherwise
            string name2 = "scott";
            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ComputesHighestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(90, result.HighestGrade);
        }

        [TestMethod]
        public void ComputesLowestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(10, result.LowestGrade);
        }

        [TestMethod]
        public void ComputesAverageGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics result = book.ComputeStatistics();
            //Assert.AreEqual(85.16666666667f, result.AverageGrade); //in the case I wouldn't have used a float (singlepoint precision number), and used a double (doublepoint precision
            // number), I would have received an error because both numbers differ in the least significant decimals. Float somehow truncates the number so they compare better and actually match.
            Assert.AreEqual(85.17, result.AverageGrade, 1); //I can specify a delta value to handle "almost equal" situations.
        }
    }
}
