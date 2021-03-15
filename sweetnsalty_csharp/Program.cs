using System;

namespace sweetnsalty
{
    class Program
    {
        static void Main(string[] args)
        {
            //Defined values from the problem
            var start = 1;
            var end = 1000;
            var increments = 10;
            var sweetDiv = 3;
            var saltyDiv = 5;
            var sweetText = "sweet";
            var saltyText = "salty";
            var bothText = "sweet’nSalty";

            SweetnSalty(start, end, increments, sweetDiv, saltyDiv, sweetText, saltyText, bothText);
        }
        /// <summary>
        /// Performs sweetnsalty as defined in the problem
        /// </summary>
        /// <param name="start">Start of the count</param>
        /// <param name="end">End of the count</param>
        /// <param name="increments">Total numbers per line</param>
        /// <param name="sweetDiv">Divisible Check to print first text</param>
        /// <param name="saltyDiv">Divsible check to print second text</param>
        /// <param name="sweetText">First text</param>
        /// <param name="saltyText">Second text</param>
        /// <param name="bothText">Text for both</param>
        static void SweetnSalty(int start, int end, int increments, int sweetDiv, int saltyDiv, string sweetText, string saltyText, string bothText)
        {
            var curNum = start;
            var sweetnsaltyString = ""; //Complete sweetnsalty string we're going to print out.
            int[] count = new int[3]; //array to hold count. also for pointer purposes to pass by reference(?). 0 = sweet, 1 = salty, 2 = both

            //while-loop handles most of the numbers. gets the current console line string returned back witha \n at end.
            while(curNum < end)
            {
                //Gets the current sweetnsalty line to be printed later()
                sweetnsaltyString += sweetSaltLine(curNum, increments, sweetDiv, saltyDiv, sweetText, saltyText, bothText, count);
                curNum += increments; //Increments to start again at next line
            }

            //for-loop to handle "left overs" if the increment per line wasn't perfectly divisible
            for(int i = curNum; i < end; i++)
            {
                sweetnsaltyString += sweetSaltLine(curNum, increments, sweetDiv, saltyDiv, sweetText, saltyText, bothText, count);
            }

            Console.WriteLine(sweetnsaltyString); //Prints out the entire sweetnsalty message
            printCount(count); //Prints the counts for each
        }

        /// <summary>
        /// Returns a string for the current sweetnsalty line based off parameterse
        /// </summary>
        /// <param name="curNum">Current start of line number</param>
        /// <param name="increments">Total numbers per line</param>
        /// <param name="sweetDiv">Divisible Check to print first text</param>
        /// <param name="saltyDiv">Divsible check to print second text</param>
        /// <param name="sweetText">First text</param>
        /// <param name="saltyText">Second text</param>
        /// <param name="count">Count for number of prints(reference)</param>
        /// <returns></returns>
        static string sweetSaltLine(int curNum, int increments, int sweetDiv, int saltyDiv, string sweetText, string saltyText, string bothText, int[] count)
        {
            var curLineString = "";

            /*
            Loops through all the numbers on this line
            If divisble by both values, add bothtext to string and increment both.
            If divisble by first value, add firsttext to stringand increment first.
            If divisble by second value, add secondtext to string and increment second.
            If not divisible, add current number to return string
            */
            for(int i = curNum; i < curNum + increments; i++) 
            {
                if(bothCheck(i, saltyDiv, sweetDiv))
                {
                    curLineString += bothText + " ";
                    count[2]++;
                }
                else if(saltyCheck(i, saltyDiv))
                {
                    curLineString += saltyText + " ";
                    count[1]++;
                }
                else if(sweetCheck(i, sweetDiv))
                {
                    curLineString += sweetText + " ";
                    count[0]++;
                }
                else
                {
                    curLineString += i + " ";
                }
            }

            //Add a newline to the end of currentline and return the string of the current line
            curLineString += "\n";
            return curLineString;
        }

        /// <summary>
        /// Prints the total counts for each text
        /// </summary>
        /// <param name="count">Total count of each text</param>
        static void printCount(int[] count)
        {
            Console.WriteLine("Total Sweet: " + count[0]);
            Console.WriteLine("Total Salty: " + count[1]);
            Console.WriteLine("Total SweetnSalty: " + count[2]);
        }

        /*
        Below can division checks for each possible text
        */
        static bool sweetCheck(int i, int sweetDiv)
        {
            return (i % sweetDiv == 0);
        }

        static bool saltyCheck(int i, int saltyDiv)
        {
            return (i % saltyDiv == 0);
        }

        static bool bothCheck(int i, int saltyDiv, int sweetDiv)
        {
            return (i % saltyDiv == 0) && (i % sweetDiv == 0);
        }
    }
}
