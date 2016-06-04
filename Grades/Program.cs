using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades  // noun are going to be classes
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook(); //parenthesis for the instance constructor, new object

            

            // what happens here is as follows.
            // first the property Name is accesed through the method set, which is defined so it checks on any incoming name that doesn't match with the current one.
            //in this case the name is new, so the if condition in the get method invokes a NameChanged public field. This field was set above to reference the method 
            //OnNameChanged, and so, for this case, if an instance of book changes its name property, the delegate will invoke OnNameChanged (a printout type action)
            //by means of .NameChanged 

            //GetBookName(book);
            AddingGrades(book);
            SaveGrades(book);
            WriteResults(book);

            //g1
            // GradeBook g1 = new GradeBook(); //new instance of g1 GradeBook();
            // GradeBook g2 = g1; //copies the po  ter to the g1. Notes it copies the object at the current
            // //state of g1.

            // //g1 = new GradeBook(); //if this is commented out then the next line will print nothing out,
            // //cause it replaces the existing g1. and this new one has no name.
            //g1.Name = "Scott's grade book";
            // Console.WriteLine(g2.Name); //I'll print g1.Name out. 
            //                               //If a new instance of g1 is created (i.e the line 39 is commented out), then the second one
            //                             //will have the name and not the first one, that is the one g2 is copied from.
        }

       
        
        private static IGradeTracker CreateGradeBook()
        {
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello! this is the GradeBook Program!");
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics(); //a class for encapsulating concepts: in this case statistics 

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }


            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade); //this is a cast method: specifying the type of the passed in parameter I can force the overloaded method I want to use, according to its signature. 
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Grade", stats.LetterGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt")) //returns an object of stringwriter type, compatible witha text writer{
                                                                            //streams buffer information, you have to dispose of it properly.
            {                                                               // the StreamWriter class has its own method of disposing garbage, so you can use the using method
                book.WriteGrades(outputFile);
                outputFile.Close();
            }      //closes the file
                   //GradeBook book2 = new GradeBook();
                   //book2.AddGrade(75); //erase the firs instance of book, replace with a new one.

            //GradeBook book3 = book; //what happens here? it will copy book into book3
            //book3.AddGrade(10);
            //// classes are reference types
            //// variables hold a pointer value, points to an instance or memory state 
        }

        private static void AddingGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try //handling a null argument exception 
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void WriteResult(string description, float result) //has to be static cause I want to call this m,ethod from another static member (Main is static)
        {//three ways of displaying
            //Console.WriteLine("1st: " + description + ": " + result); //direct concatenation 
            //Console.WriteLine("2nd: {0}: {1:F2}", description, result); //:F2 formats the number into a floating point with two digits: ":C" formats into a currency. There is a lot of format options.
            Console.WriteLine($"{description}: {result:F2}"); //string interpolation
        }

        static void WriteResult(string description, string result) //overloaded method to receive a string as a result.
        {
            Console.WriteLine($"{description}: {result}"); //string interpolation
        }

        //static void OnNameChanged(object sender, NameChangedEventArgs args)
        //{
        //    Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        //}


        //static void WriteResult(string description, int result) //Method overloading. C# compiler uses the most matching option for an overloaded methods.
        //{
        //    Console.WriteLine(description + ": " + result);
        //}
    }
}

// on assemblies: unit testing!
//properties go with capitals!!