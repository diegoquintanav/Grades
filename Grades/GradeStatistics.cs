using System;
using System.Collections.Generic; // allows to store multiple things
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Grades
{
    public class GradeStatistics //internal means only accesible from within the filespace or namespace of the project. It can only be used within the "Grades" solution.
    { 
        
        // public:    Visibility everywhere
        //private: only in the same class
        //internal: ONly in the same assembly


        //create three FIELDS

        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue; //largest possible float number
        }
       public float AverageGrade;
       public float HighestGrade;
       public float LowestGrade;

        public string Description
        {
            get
            {
                string result;
                switch (LetterGrade)
                {
                    case "A":
                        result = "Excellent";
                        break;
                    case "B":
                        result = "Good";
                        break;
                    case "C":
                        result = "Average";
                        break;
                    case "D":
                        result = "Below Average";
                        break;                        
                    default:
                        result = "Failing";
                        break;
                }
                return result;
            }
                }
        public string LetterGrade
        {
            get
            {
                string result;
                if (AverageGrade>=90)
                {
                    result = "A"; 
                }
                else if(AverageGrade>=80)
                {
                    result = "B"; 
                }
                else if (AverageGrade>=70)
                {
                    result = "C";
                }
                else if (AverageGrade>=60)
                {
                    result = "D"; 
                }
                else
                {
                    result = "F";
                }
                return result;
            }
        }
    }
}