using System;
using System.Text.RegularExpressions;

namespace GraduateAssessment
{
    class Program
    {
        //Defining a new method
        static void PeopleInput()
        {

            //Asking for input of first persons name
            Console.WriteLine("Person One: ");
            //Taking string input, first persons name
            string PersonOne = Console.ReadLine();

            //Asking for input of first persons name
            Console.WriteLine("Person Two: ");
            //Taking string input, first persons name
            string PersonTwo = Console.ReadLine();

            //definig an if...else statement and using REGEX to check if both inputs ONLY contains letters and not other characters
            //The regex, explained:
            //'^' is the start of the string
            //'+' the character can occur one ore more times
            //'a-z' range of small letters
            //'A-Z' range of capital letters
            //'$' end of the string
            if ((Regex.IsMatch(PersonOne, @"^[a-zA-Z]+$")) && (Regex.IsMatch(PersonTwo, @"^[a-zA-Z]+$")))
            {
                //Concatanating the two string variables with 'matches', between
                string Sentence = PersonOne + " matches " + PersonTwo;


                String firstpart = MatchingLetters(Sentence); //Passing 'Sentence' as an argument and storing in variable, 'firstpart'

                String part2 = gettingpercentage(firstpart);

                do
                {
                    part2 = gettingpercentage(part2);

                } while (part2.Length > 2);


                if (Int32.Parse(part2) >= 80)
                {

                    Console.WriteLine(Sentence + " " + part2 + "%, good match");

                }
                else
                {

                    Console.WriteLine(Sentence + " " + part2 + "%");

                }


            }
            else
            {
                Console.WriteLine("Invalid. Try Again.");
                //Clears the console
                Console.Clear();
                //RECURSION of the method - It will be called until/unless the input is correct
                PeopleInput();
            }

        }

        //Defining a public static string variable
        public static String toMatch1;

        //Defining a new method called, 'MatchingLetters', recieving a string parameter
        static String MatchingLetters(string toMatch)
        {
            //Replacing/removing white-spaces
            toMatch1 = toMatch = toMatch.Replace(" ", String.Empty);

            int counter; // Index of next character
            int matching; //storing increment of matches


            String finalnumber = ""; //string returned at the end

            //nested for-loop
            //run for the length of the string
            for (int s = 0; s < toMatch1.Length; s++)
            {
                matching = 1; // reset counter to 1
                counter = s + 1; //used to compare next letter in string by using '+1'

                //If end of string, the last letter can not be matched, therefore, it's adding one to the final string
                if (s == toMatch1.Length - 1)
                {
                    finalnumber = finalnumber + matching.ToString();
                }

                //Looping through to compare characters
                //i is the letter being compared to the rest of the string
                for (int i = s; counter < toMatch1.Length; counter++)
                {

                    if (counter == toMatch1.Length - 1)
                    {
                        //if counter reaches the end of the string, add number of matches to the string of numbers
                        if (toMatch1[i] == toMatch1[counter])
                        {

                            matching++;// Increment

                            toMatch1 = toMatch1.Remove((counter), 1);//Removing character

                            finalnumber = finalnumber + matching.ToString();//Adding the count to the string of numbers
                        }
                        else
                        {

                            finalnumber = finalnumber + matching.ToString();

                        }

                    }
                    else if (toMatch1[i] == toMatch1[counter]) //If letter 1 is matched to the next letter, in the loop
                    {

                        matching++;//Increment matched number

                        toMatch1 = toMatch1.Remove((counter), 1);// remove character from the string

                        counter--; //Counter decrement

                    }

                }
            }

            return finalnumber;
        }

        //Declaring method
        public static string gettingpercentage(string number)
        {
            String percentage = "";

            //Declaration of for-loop
            //Loop will run until the length of 'number' is complete
            for (int i = 0; i < number.Length; i++)
            {
                //find middle of 'number'
                double md = number.Length / 2;

                //Rounding up to the middle number
                double middle = Math.Ceiling(md);

                //checking if left to middle AND right to middle has a break point, if the amount of numbers are even
                if (i >= middle && number.Length % 2 == 0)
                {

                    break;

                }
                //If the length of the number string is odd, when the iteration reaches the middle term, add the number to the overall new percentage
                else if (i == middle && number.Length % 2 > 0)
                {

                    //Adding the odd middle number, to the overall percentage
                    percentage = percentage + number[(int)middle].ToString();

                    break;

                }
                else
                {
                    //adding most left to most right, and going in-ward
                    //Passing char to int
                    percentage = percentage + ((int)Char.GetNumericValue(number[i]) + (int)Char.GetNumericValue(number[number.Length - (i + 1)])).ToString();
                }

            }

            return percentage;

        }

        
        public static void Main(string[] args)
        {
            //Calling the 'PeopleInput' method
            PeopleInput();
        }
    }
}
