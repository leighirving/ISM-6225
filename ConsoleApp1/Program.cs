using System;
using System.Diagnostics;
using System.Linq;

namespace Project01_Introduction
{
    // All organizing structures use { and } to define their boundaries
    class L1_Program
    {
        // All .NET programs begin with the main method
        // It looks like this
        static void Main(string[] args)
        {

            // example 0 - first program
            Console.WriteLine("Hello World!");
            // Console.ReadKey();
            // Debug.WriteLine("Hello World!");

            // obtaining user input
            Console.WriteLine("Please provide your input");
            string userInput = Console.ReadLine();

            // parsing to specific data types
            int inputNumber = Convert.ToInt32(userInput);

            // parsing with error handling
            Console.WriteLine("Please provide your input");
            string userInputToCheck = Console.ReadLine();

            try
            {
                int inputNumberChecked = Convert.ToInt32(userInputToCheck);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // example 1 - simple computation
            // M disambiguates between double and decimal
            decimal income = 10000000.45M;
            decimal taxRate = 0.1M;
            decimal taxLiability = income * taxRate;
            Debug.WriteLine("Tax liability is " + taxLiability);

            // example 2 - API usage
            double rate = 0.06;
            double doublingTime = Math.Log(2) / Math.Log(1 + rate);

            Debug.WriteLine("Doubling time is " + doublingTime + " years");


            // Exercise 1
            // Calculate the area of a triangle using Heron's formula
            // Area = SquareRoot(s * (s-a) * (s-b) * (s-c)) where s=(a+b+c)/2 and a,b,c are the sides of the triangle
            // Eg. a=3, b=4, c=5. Area = 6

            //Write your code here

            /*
            int a = 3;
            int b = 4;
            int c = 5;

            int s = (a + b + c) / 2;

            double Area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            Console.WriteLine("Area is " + Area);
            */


            Console.WriteLine("Length of side 1:");
            string s1 = Console.ReadLine();
            int a = Convert.ToInt32(s1);

            Console.WriteLine("Length of side 2:");
            string s2 = Console.ReadLine();
            int b = Convert.ToInt32(s2);


            Console.WriteLine("Length of side 3:");
            string s3 = Console.ReadLine();
            int c = Convert.ToInt32(s3);



            double Area(int a, int b, int c)
            {
                int s = (a + b + c) / 2;
                double Area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
                return Area;
            }

            Console.WriteLine("Area is " + Area(a,b,c));



            // example 3 - selection
            if (income < 400000)
                taxLiability = 0;
            else
            {
                taxRate = 0.5M;
                taxLiability = taxRate * income;
            }

            Debug.WriteLine("Tax liability is " + taxLiability);

            // example 4 - numeric input
            string incomeInput = Console.ReadLine();

            Debug.WriteLine("Thanks, you entered " + incomeInput);

            income = Convert.ToDecimal(incomeInput);
            if (income > 400000)
            {
                taxRate = 0.5M;
                taxLiability = taxRate * income;
            }
            else
            {
                taxLiability = 0;
            }

            Debug.WriteLine("Tax liability is " + taxLiability);


            // Exercise 2
            // Input a number (n) from the user and check if it is even or odd.

            // Write your code here

            Console.WriteLine("Please provide input to check if it is even or odd");
            string n = Console.ReadLine();

            decimal numN = Convert.ToDecimal(n);

            if (numN % 2 == 0)
            {
                Console.WriteLine("Number is even");
            }
            else
            {
                Console.WriteLine("Number is odd");
            }


            // Exercise 3
            // Input 3 numbers from the user (x,y,z) and find the greatest of them.

            // Write your code here
            Console.WriteLine("Please provide input 1:");
            string num1 = Console.ReadLine();

            Console.WriteLine("Please provide input 2:");
            string num2 = Console.ReadLine();

            Console.WriteLine("Please provide input 3:");
            string num3 = Console.ReadLine();

            decimal x = Convert.ToDecimal(num1);
            decimal y = Convert.ToDecimal(num2);
            decimal z = Convert.ToDecimal(num3);


            if ((x > y) && (x > z))
            {
                Console.WriteLine("The largest input was " + x);
            }
            else if ((y > x) && (y > z))
            {
                Console.WriteLine("The largest input was " + y);
            }
            else
            {
                Console.WriteLine("The largest input was " + z);
            }


            // example 5 - loop
            bool stopProgram = false;

            while (stopProgram == false)
            {
                Console.Write("Please enter income: $");
                income = Convert.ToDecimal(Console.ReadLine());

                if (income > 400000)
                {
                    taxRate = 0.5M;
                    taxLiability = taxRate * income;
                }
                else if (income >= 0)
                {
                    taxLiability = 0;
                }
                else
                {
                    stopProgram = true;
                }

                Console.WriteLine("Tax liability is " + taxLiability);
            } // end while loop


            // Exercise 4
            // Input a value (n) from the user and calculate the sum of first n natural numbers.
            // Eg. n=5. sum = 1+2+3+4+5 = 15

            // Write your code here
            Console.WriteLine("Please provide input n to calculate the sum of first n natural numbers:");

            decimal v = Convert.ToDecimal(Console.ReadLine());

            decimal sum = 0;

            while (v > 0)
            {
                sum = v + sum;
                v = v - 1;

            }

            Console.WriteLine("The sum of first n natural numbers is " + sum);


            // Exercise 5
            // Input a value (n) from the user and display the following * pattern:
            // Input n=5
            // Output
            // *
            // **
            // ***
            // ****
            // *****

            // Write your code here
            Console.WriteLine("Please provide input n to display pattern:");

            int w = Convert.ToInt32(Console.ReadLine());

            int itr = 1;
            while (itr <= w)
            {
                string tabs = new String('*', itr);

                Console.WriteLine(tabs);
                itr += 1;
            }



            // Exercise 6
            // Input a value (n) from the user and display the following * pattern:
            // Input n=5
            // Output
            //     *
            //    **
            //   ***
            //  ****
            // *****

            // Write your code here
            Console.WriteLine("Please provide input n to display pattern:");

            int t = Convert.ToInt32(Console.ReadLine());

            int itr2 = 1;
            while (t > 0)
            {
                string tabs2 = new String(' ', t-1) + new String('*', itr2);

                Console.WriteLine(tabs2);
                itr2 += 1;
                t -= 1;
            }



            // example 6 - method
            income = Convert.ToDecimal(Console.ReadLine());
            taxLiability = ComputeTaxes(income);
            Debug.WriteLine("Tax liability is " + taxLiability);


            // Exercise 7
            // Write a method that accepts a parameter (n) and returns the sum of first n natural numbers.

            // Write your code here

            Console.WriteLine("Please provide input n to return the sum of first n natural numbers:");
            int u = Convert.ToInt32(Console.ReadLine());


            int natNum(int u)
            {
                int sum = 0;

                while (u > 0)
                {
                    sum = u + sum;
                    u = u - 1;

                }

                return sum;
            }

            Console.WriteLine(natNum(u));




            // example 7 - arrays
            decimal[] incomes = new decimal[] { 100.0M, 234532, 2443245.1M, 123443 };

            for (int i = 0; i < 4; i++)
            {
                Debug.WriteLine(incomes[i]);
            }


            // Exercise 8
            // Enter n numbers in an array and print all the even numbers.

            // Write your code here
            decimal[] numbers = new decimal[] { 100.0M, 234532, 2443245.1M, 123443 };

            foreach (decimal j in numbers)
            {
                if (j % 2 == 0)
                {
                    Console.WriteLine(j);
                }          
            }



            // Exercise 9
            // Enter n numbers in an array and find the highest and the smallest number.

            // Write your code here
            Console.WriteLine("How many numbers would you like to compare?");
            int ans = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter numbers:");

            decimal[] answer = new decimal[ans];
            for (int i = 0; i < answer.Length; i++)
            {
                answer[i] = Convert.ToDecimal(Console.ReadLine());
            }

            Console.WriteLine("The highest number is: " + answer.Max());
            Console.WriteLine("The smallest number is: " + answer.Min());


        }

        static decimal ComputeTaxes(decimal income)
        {
            decimal taxLiability;
            decimal taxRate;

            if (income < 400000)
                taxLiability = 0;
            else
            {
                taxRate = 0.5M;
                taxLiability = taxRate * income;
            }

            return taxLiability;
        }
    }
}