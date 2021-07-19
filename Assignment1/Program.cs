using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int n = 5;
            PrintPattern(n);

            int n2 = 6;
            PrintSeries(n2);

            string s = "09:15:35PM";
            string t = UsfTime(s);
            Console.WriteLine(t);

            int n3 = 110;
            int k = 11;
            UsfNumbers(n3, k);
            
            string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            PalindromePairs(words);

            Stones(5);
            

        }


        private static void PrintPattern(int n)
        /* Prints number pattern of n integers using recursion */
        {
            try
            {   
                
                if (n > 0)
                {
                    string line = ""; //the decrementing values per row

                    for (int count = n;  count > 0; count--)
                    {
                        line += count; //add each value decrement from n 
                    }
                    Console.WriteLine(line);
                    n--;
                    PrintPattern(n);
                }

            }

            catch
            {
                Console.WriteLine("Exception Occured while computing printPattern");
            }
        }


        private static void PrintSeries(int n2)
        /* Prints the following series til n2 terms: 1, 3, 6, 10, 15, 21…… */
        {
            try
            {
                int i = 0;
                string sep = "";

                for (int counter = 0; counter < n2; counter++) //counter keeps track of the number of terms to print
                {
                    int total = i + counter + 1; //calculate next value in series
                    Console.Write(sep + "{0}", total);
                    sep = ", ";

                    i = total; //set i to the next value in the series
                }

                Console.WriteLine();

            }

            catch
            {
                Console.WriteLine("Exception Occured while computing printSeries");
            }
        }


        public static string UsfTime(string s)
        /* On planet “USF” which is similar to that of Earth follows different clock where instead of hours they have U , instead of minutes they have S 
        , instead of seconds they have F. Similar to earth where each day has 24 hours, each hour has 60 minutes and each minute has 60 seconds , 
        USF planet’s day has 36 U , each U has 60 S and each S has 45 F. 
        This method takes 12HR format s and prints a string representing input time in USF time format. */

        {
            try
            {
                DateTime s_time =  DateTime.ParseExact(s, "hh:mm:sstt", CultureInfo.InvariantCulture); //converts 's' to datetime format 


                int earthSeconds = s_time.Second;
                int earthMinuteSecs = s_time.Minute * 60; 
                int earthHourSecs = s_time.Hour * 60 * 60; 

                int totalEarthSecs = earthSeconds + earthMinuteSecs + earthHourSecs;
                
                int usfHourSecs = totalEarthSecs / (60 * 45); //convert Earth seconds to USF hours

                double earthSecsLeft = totalEarthSecs - (usfHourSecs * 60 * 45); //Get remaining seconds after subtracting number of hours

                int usfMinuteSecs = (int) earthSecsLeft / 45; //convert Earth minutes to USF hours

                int usfSeconds = (int) earthSecsLeft - (usfMinuteSecs * 45); //Get remaining seconds after subtracting number of minutes


                Console.WriteLine(usfHourSecs + ":" + usfMinuteSecs + ":" + usfSeconds);
                


            }
            catch
            {
                Console.WriteLine("Exception Occured while computing UsfTime");
            }
            return null;
        }


        public static void UsfNumbers(int n3, int k)
        /* Prints the numbers 1 to n3, k numbers per line. 
         * It prints 'U' in place of numbers which are multiple of 3, "S" for multiples of 5,"F" for multiples of 7, 
         * 'US' in place of numbers which are multiple of 3 and 5,
         * 'SF' in place of numbers which are multiple of 5 and 7 and so on. */

        {
            try
            {
                for (int i = 1; i <= n3; i++) //loops through numbers 1 to n3 
                {
                    if ((i % 3 == 0) & (i % 5 == 0))
                    {
                        Console.Write(" US");
                    }

                    else if ((i % 5 == 0) & (i % 7 == 0))
                    {
                        Console.Write(" SF");

                    }
                    else if ((i % 3 == 0) & (i % 7 == 0))
                    {
                        Console.Write(" UF");
                    }
                    else if (i % 3 == 0)
                    {
                        Console.Write(" U");
                    }
                    else if (i % 5 == 0)
                    {
                        Console.Write(" S");

                    }
                    else if (i % 7 == 0)
                    {
                        Console.Write(" F");

                    }

                    else
                    {
                        Console.Write(" " + i);

                    }


                    if (i % k == 0) //creates new line after printing k numbers
                    {

                        Console.WriteLine(" ");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing UsfNumbers()");
            }
        }

        public static void PalindromePairs(string[] words)
        /*Takes a list of unique words and finds all the pairs of distinct indices (i,j) in the given list such that the concatenation of 
         * two words i.e. words[i]+words[j] is a palindrome. */
        {

            static string ReverseString(string s) //create method to reverse a string
            {
                char[] arr = s.ToCharArray();
                Array.Reverse(arr);
                return new string(arr);
            }

            try
            {
                string result = "[";
                string combination;

                for(int i = 0; i<words.Length; i++)
                {
                    for(int j = 0; j<words.Length; j++)
                    {
                        combination = words[i] + words[j];
                        if (combination == ReverseString(combination) && i !=j) //compare the current combination of words with its reverse
                        {                                                        //if they match and this isnt a combination of a word with itself then
                            result += "[" + i + "," + j + "],";                  //add it to the result list
                        }
                    }
                }

                result  = result.Remove(result.Length - 1, 1);
                result += "]";
                Console.WriteLine(result);

            }catch
            { 

                Console.WriteLine("Exception occured while computing PalindromePairs()");
            }

        }
        public static void Stones(int n4)
        /*Two friends are playing a stone game. There are n4 number of stones in a bag, each time the players take turns and take out 1 to 3 stones. 
         The player who takes out the last stone will be the winner. Player 1 will be the first player to remove the stone(s).

         This method determines whether Player 1 can win the game given the number of stones in the bag. It prints false if Player 1 cannot win the game, 
         otherwise prints any one set of moves where Player 1 wins the game. */

        {
            try
             {
                 if (n4 <= 3)
                 //Player 1 wins since they can just choose 1, 2 or 3 to take all the stones.
                 {
                     int[] win = { n4 };
                     Console.WriteLine("[{0}]", string.Join(", ", win));

                 }
                 else if (n4 % 4 == 0)
                //If n4 is divisible by 4 then whichever value Player 1 chooses, Player 2 will win as they have the option of choosing 
                //1, 2 or 3 for the final stones.
                {
                    Console.WriteLine(false);
                 }
                 else
                 {

                    int startingNum = n4 % 4;
                    int quotient = n4 / 4; //set of [Player 1, Player 2] moves before Player 1 wins

                    List<int> moves = new List<int>();

                    moves.Add(startingNum);

                    printAnswer(quotient, moves);

                    void printAnswer(int quotient, List<int> plays)
                    {
                        if (quotient == 0)
                        {

                            int[] solutions = plays.ToArray();
                            Console.WriteLine("[{0}]", string.Join(", ", solutions)); 

                        }
                        else
                        {    //since Player 1 wins whenever the given value is not a multiple of 4 all possible combinations 
                            //that add up to 4 after removing the remainder are valid plays

                            List<int> sol1 = new List<int>() { 1, 3 };
                            printAnswer(quotient - 1, plays.Concat(sol1).ToList()); 

                            List<int> sol2 = new List<int>() { 2, 2 };
                            printAnswer(quotient - 1, plays.Concat(sol2).ToList());

                            IList<int> sol3 = new List<int>() { 3, 1 };
                            printAnswer(quotient - 1, plays.Concat(sol3).ToList());

                        }

                    }

                }
             }
             catch
             {
                 Console.WriteLine("Exception occured while computing Stones()");
             }
        }


    }
}
