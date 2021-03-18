"use strict";

/**IEEF? 
 * Trying to do an IEEF
 * Starts up the entire sweetnsalty
 * Defines all the variables needed for the application
 * Does the looping through the numbers
 * Tried using a number of concepts taught throughout the week
*/
(function StartSweetnSalty ()
{
    /**Variable Definitions
     * Not used
     * Here as a placeholder(?) incase user does want to change a value
     * Function call uses default values in parameter instead
     */
     let sweetNum = 3;
     let saltyNum = 5;
     let sweetText = "sweet";
     let saltyText = "salty";
     let sweetnSaltyText = "sweetnSalty";


     /**Variables that we do use
      * Start and end count
      * A complete string that we're going to print out
      * An object to keep count of how many times a specific thing was printed
      */
    let startNum = 1;
    let endNum = 1000;
    let incrementValue = 10;
    let completeString = "";
    let counter = {
        sweetCount: 0,
        saltyCount: 0,
        sweetSaltyCount: 0,
    };

    /**Start of counting
     * Declare i outisde of for-loop for the 2nd for-loop
     * 2nd for-loop handles if the # of numbers per line(increments per line) doesn't fit perfectly
     * Gets the string for the current line each loop using other function. A lot of parameters using default values
     */
    let i = 0;
    for(i = startNum; i < endNum; i += incrementValue)
    {
        completeString += PrintCheck(i, counter); 
    }
    
    for(; i < endNum; i++)
    {
        completeString += PrintCheck(i, counter);
    }

    /**Print the entire sweetnSalty string */
    console.log(completeString);
    /**Print the counts using a loop through each value in the object */
    for(let key in counter)
    {
        console.log(key + ": " + counter[key]);
    }
})();

/**Function PrintChecck
 * Returns the string for the current line
 * Contains (incrementValue) amount of numbers
 * Does divisible checks using (sweetNum) and (saltyNum)
 * 
 */
function PrintCheck(curNum, counter, incrementvalue = 10, sweetNum = 3, saltyNum = 5, sweetText = "sweet", saltyText = "salty", sweetnSaltyText = "sweetnSalty")
{
    let curString = "";

    //Loop through each number in the current line and see what needs to be added to string/printed
    for(let i = curNum; i < curNum + incrementvalue; i++)
    {
        if(i % (sweetNum*saltyNum) == 0)
        {
            curString += sweetnSaltyText;
            counter.sweetSaltyCount++;
        }
        else if(i % sweetNum == 0)
        {
            curString += sweetText;
            counter.sweetCount++;
        }
        else if(i % saltyNum == 0)
        {
            curString += saltyText;
            counter.saltyCount++;
        }
        else
        {
            curString += i;
        }
        curString += " ";
    }

    //Return this line's string with a newline at the end
    return curString += "\n";
}
