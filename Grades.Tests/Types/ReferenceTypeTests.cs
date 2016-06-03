using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//structs are value types. When should I write a struct instead of a class?
//by default it shoiuld be a class. structs are used in abstraction for complex numbers like date, 3point position
//other value type is "enum"

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {

        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);


            Assert.AreEqual(89.1f, grades[1]);
        }
       
        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;             

        }

        [TestMethod]
        public void UppercaseString()
        {
            string name = "scott";
            name.ToUpper(); //ToUpper and related methods operate on String class, that is passed as a reference value.

            //Assert.AreEqual("SCOTT", name); // this test alone will fail because even ToUpper doesn¿t modify the string that i'm pointing to, instead 
                                            // create a new string and  return that string from the method, so i need to capture it

            name = name.ToUpper(); // this way I store name 

            Assert.AreEqual("SCOTT", name); // this test should pass now.
        }
        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            date = date.AddDays(1); // kind of a date =+ 1          
            Assert.AreEqual(2, date.Day);
            //AddDays creates a new instance of DateTime object, I can solve this by assigning it to the same reference.
        }

        [TestMethod]
        public void ValueTypesPassedByValue()
        {
            int x = 46;
            IncrementNumber(x);

            Assert.AreEqual(46, x);
        }

        private void IncrementNumber(int number)
        {
            number += 1;
        }

        [TestMethod]
        public void ReferenceTypesPassedByValue()
        {
            GradeBook book1 = new GradeBook(); // asigno nuevo espacio
            
            GradeBook book2 = book1; // copying the reference to book1 into book2

            GiveBookAName(book2); // method GiveBookAName will operate over the reference to book1, because the value of book2 is a pointer.

            book1 = new GradeBook(); // creo otro espacio en la memoria con el nbombre book1, borrando el pointer a la memoria asignada previamente a book1

            Assert.AreEqual("A GradeBook", book2.Name); // comparo el string 
            
        }

        private void GiveBookAName(GradeBook book)
        {           
            book.Name = "A GradeBook";
        }

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;
            Assert.AreEqual(x1, x2);
        }


        [TestMethod]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook(); 
            GradeBook g2 = g1; 


            g1.Name = "Scott's grade book";
            Assert.AreEqual(g1.Name, g2.Name);
        }
    }
}
