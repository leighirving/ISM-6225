using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Assignment2_CT_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question 1");
            int[] l1 = new int[] { 5, 6, 6, 9, 9, 12 };
            int target = 9;
            int[] r = TargetRange(l1, target);

            Console.WriteLine();

            Console.WriteLine("Question 2");
            string s = "University of South Florida";
            string rs = StringReverse(s);
            Console.WriteLine(rs);

            Console.WriteLine("Question 3");
            int[] l2 = new int[] { 2, 2, 3, 5, 6 };
            int sum = MinimumSum(l2);
            Console.WriteLine(sum);

            Console.WriteLine("Question 4");
            string s2 = "Dell";
            string sortedString = FreqSort(s2);
            Console.WriteLine(sortedString);

            Console.WriteLine("Question 5-Part 1");
            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect1 = Intersect1(nums1, nums2);
            Console.WriteLine("Part 1- Intersection of two arrays is: ");
            DisplayArray(intersect1);
            Console.WriteLine("\n");
            Console.WriteLine("Question 5-Part 2");
            int[] intersect2 = Intersect2(nums1, nums2);
            Console.WriteLine("\n");

            Console.WriteLine("Question 6"); 
            char[] arr = new char[] { 'a', 'g','h', 'a'}; 
            int k = 3; 
            Console.WriteLine(ContainsDuplicate(arr, k));

            Console.WriteLine("Question 7");
            int rodLength = 6;
            int priceProduct = GoldRod(rodLength);
            Console.WriteLine(priceProduct);


            Console.WriteLine("Question 8");
            string[] userDict = new string[] { "rocky", "usf", "hello", "apple" };
            string keyword = "";
            Console.WriteLine(DictSearch(userDict, keyword));

            Console.WriteLine("Question 9");
            SolvePuzzle();

        }

        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }

        //Question 1


        public static int[] TargetRange(int[] l1, int t)
        {
            //below prints if the target elements is same as first array element
            if (l1[0] == t)
                Console.Write(0 + " ");


            //initializing below value which helps to do return output based on its value(code followed..)
            int a = 0;
            //initialing the array list with 100 elemnents
            //not using arraylist as the datatype declared is only int
            int[] r = new int[100];
            try
            {
                int j = 0;

                //below for loop checks the condition untill last array element

                for (int i = 0; i < l1.Length; i++)
                {
                    //the result array will be initiated only there the target varaible is equal to the respective array elment
                    //the below condition keeps checking for all array elements
                    if (l1[i] == t)
                    {
                        //the below a value helps in printing the output
                        a = 1;
                        //the below result array keeps adding the number of array elemnt it each matches with the target
                        r[j] = Convert.ToInt32(i);

                    }
                    //the below is incremented for the result array positioning
                    j++;

                }
                //if the above if loop is not executed,then default output shown below will be excuted
                if (a == 0)
                {
                    Console.WriteLine("[-1,-1]");
                }


            }
            catch (Exception)
            {

                Console.WriteLine("Kindly recheck your inputs before proceeding");
            }

            //return new int[] { };--given in asgn-recheck

            //below for loop checks the condition untill last array element
            for (int m = 0; m < r.Length; m++)
            {
                //if the array elemts is overwritten with any other value,then only the below condition is true
                if ((r[m]) != 0)

                    Console.Write(r[m] + " ");
            }

            return r;


        }


        //Question 2
        public static string StringReverse(string s)
         {
             try
             {
                string a = "";
                string final = "";
                //initializing i value to the number of array elements and loop stops once i becomes negative
                for (int i = s.Length - 1; i > -1; i--)
                {
                    //if checks for the empty space between words,if true to it appends the temporary value 'a' to the existing final value
                    if (s[i] == ' ')
                    {
                        //the below final will keep appending each word in reverse order
                        final = a + " " + final;
                        a = "";

                    }
                    else
                    //if there are no empty spaces then the temporary value 'a' will store the array elemnts of a word in rever order as i is stated with array last element
                    {
                        a += s[i];

                    }
                }
                //the below final is required to add the last reversed word,else if we try to print from the earlier final value it prints all words except last word(as it skips the result executed in last else loop)
                final = a + " " + final;
                return (final);
            }
             catch (Exception)
             {
                 throw;
             }
             return null;
         }

        //Question 3
        public static int MinimumSum(int[] l2)
         {
             try
             {
                //for loop below intializes and checks the condition
                for (int i = 0; i < (l2.Length - 1); i++)
                {
                    //assumption:input in ascending order and code works for all integers(-ve numbers,0,+ve numbers)
                    //corner case:the below code is one of the corner case when if the input has more than 2 similar elements(ex:{ 1, 2, 2, 2, 3 }).
                    //in the above example although we increase the 2nd element,there will be a problem with 3rd element and doesnt follow ascening order.In those the blow check is done,which initially swaps before incrementing
                    if (l2[i] > l2[i + 1])
                    {
                        l2[i + 1] = l2[i];
                    }
                    //whenever the current and succeeding array elemnts are same,if loop executes.Otherwise,the array eleents remains constant
                    if (l2[i] == l2[i + 1])
                    {
                        //if they are same,then the suceeding array element will increase the value making every elemnt unique-choosen to increase suceeding element as the array should be in ascending order
                        l2[i + 1] = l2[i] + 1;
                    }
                    

                }
                //once the modified array is available,the sum of it is made by passing to predefoned sum function
                int sum = l2.Sum();
                return sum;
            }
             catch (Exception)
             {
                 throw;
             }
             //return sum;
         }

        //Question 4
        public static string FreqSort(string s2)

        {
            try
            {
                //Corner case:the below condition is check for the corner case when the string is not having any input(ex:s2="")
                //only if there is input the logic executes else it exits
                if ((s2.Length) != 0)
                {
                    //creating a new dictionary which pulls each character from a given string
                    Dictionary<char, int> a = new Dictionary<char, int>();
                    //loop the splited characters
                    for (int i = 0; i < s2.Length; i++)
                    {
                        // Checking if character already exist in dictionary ,if satisfied it doesnt make a duplicate entry into the dictionary but keeps increasing the value

                        if (a.ContainsKey(s2[i]))
                        {
                            int value = a[s2[i]];
                            a[s2[i]] = value + 1;

                        }
                        else
                        {
                            //if the char is not present in dictionary then the char is added into the dictionary and its value is set to 1
                            a.Add(s2[i], 1);

                        }
                    }
                    //the below foreach loop orders the value in the dictionary in the descending order to print the desired output
                    foreach (KeyValuePair<char, int> kvp in a.OrderByDescending(key => key.Value))

                    {
                        //below for loop prints the repeated key elements based on the number declared for key elements
                        //ex:if value is 2,then its elements is printed twice
                        for (int i = 0; i < kvp.Value; i++)
                            Console.Write(kvp.Key);
                    }

                }

                else
                {
                    Console.WriteLine("Kindly input string value and rerun the program.Exiting the Program.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

        //Question 5 - Part 1
        public static int[] Intersect1(int[] nums1, int[] nums2)
         {
             try
             {
                // Step 1 - Sort the arrays
                Array.Sort(nums1);
                Array.Sort(nums2);
                int a = nums1.Length;
                int b = nums2.Length;
                int i = 0, j = 0;
                List<int> list = new List<int>();

                while (i < a && j < b)
                {
                    // Step 2 - Compare the elements in both arrays to see if they're greater than or equal to each other
                    if (nums1[i] < nums2[j])
                    {
                        i++;
                    }
                    else if (nums2[j] < nums1[i])
                    {
                        j++;
                    }
                    else
                    {
                        // Step 3 - If any elements are equal, print it out
                        list.Add(nums1[i]);
                        i++;
                        j++;
                    }
                }
                return list.ToArray();
            }
             catch
             {
                 throw;
             }
             return new int[] { };
         }

        //Question 5 - Part 2
        public static int[] Intersect2(int[] nums1, int[] nums2)
        {
            try
            {
                int a = nums1.Length;
                int b = nums2.Length;

                //Corner case:checks if the array length is zero
                if ((a == 0) || (b == 0))
                {
                    Console.WriteLine("Kindly enter input to proceed further.Exiting the application");
                }
                //declaring new dictionaries for each array and one resultant dictionary
                var dic1 = new Dictionary<int, int>();
                var dic2 = new Dictionary<int, int>();
                var res = new Dictionary<int, int>();
                //loop based on length of input length
                for (int i = 0; i < nums1.Length; i++)
                {
                    //if the dictionary already contains the key,then the value will be increased
                    if (dic1.ContainsKey(nums1[i]))
                    {
                        int value = dic1[nums1[i]];
                        dic1[nums1[i]] = value + 1;

                    }
                    //else,a new entry will be made into the dictionary 
                    else
                    {
                        dic1.Add(nums1[i], 1);

                    }

                }
                for (int i = 0; i < nums2.Length; i++)
                {
                    if (dic2.ContainsKey(nums2[i]))
                    {
                        int value = dic2[nums2[i]];
                        dic2[nums2[i]] = value + 1;

                    }
                    else
                    {
                        dic2.Add(nums2[i], 1);

                    }
                }
                //resultant dictionary stores the values of all intersection between two input dictionaries
                res = dic1.Keys.Intersect(dic2.Keys)
                                  .ToDictionary(t => t, t => dic1[t]);
                Console.WriteLine("Part 2- Intersection of two arrays is: ");
                foreach (KeyValuePair<int, int> kvp in res)

                {

                    for (int i = 0; i < kvp.Value; i++)
                        Console.Write((kvp.Key) + " ");

                }


            }
            catch
            {
                Console.WriteLine("Exception occured during intersect execution");
            }
            return new int[] { };
        }


        //Question 6

        public static bool ContainsDuplicate(char[] arr, int k)
        {
            try
            {
                arr.Take(k + 1).ToDictionary(key => key, value => value); 
            }
            catch (Exception) 
            {
                return true; //returns true if key already exists in dictionary, i.e. there is a duplicate
            }
            if(arr.Length > k + 1)
            {
                return ContainsDuplicate(arr.Skip(k + 1).ToArray(), k); 
            }

            return false;
        }
        
       



        //Question 7
        private static int denom = -1;
        private static List<Tuple<int, string>> result = new List<Tuple<int, string>>();

        public static int GoldRod(int n)
        {
            try
            {
                if (n<0)
                {
                    Console.WriteLine("Invalid number entered.");
                    return 0;
                }
                
                if (denom == 0)
                {
                    var output = result.OrderByDescending(x => x.Item1).FirstOrDefault();
                    if (output != null)
                    {
                        Console.WriteLine(output.Item2);
                        return 0;
                    }
                }

                if (denom == -1)
                    denom = (int)Math.Floor(n / 2.0);

                if (n % denom == 0)
                {
                    var pow = n / denom;
                    var output = Output(denom, pow);
                    result.Add(output);
                }

                denom--;
                GoldRod(n);
            }
            catch (Exception)
            {
                throw;
            }
            return 0;
        }

        public static Tuple<int, string> Output(int denom, int pow)
        {
            var total = 1;
            var sb = new StringBuilder();
            for (int i = 1; i <= pow; i++)
            {
                sb.Append(denom);

                if (i != pow)
                    sb.Append("*");

                total *= denom;
            }

            sb.Append($"= {total}");

            return new Tuple<int, string>(total, sb.ToString());
        }


        // Question 8
        public static bool DictSearch(string[] userDict, string keyword)
        {
            try
            {
                int numberOfDeviations = 0;
                for (int x = 0; x < userDict.Length; x++)
                {
                    for (int i = 0; i < userDict[x].Length; i++)
                    {
                        if (keyword.Length != userDict[x].Length) //no solution if words are not the same length
                        {
                            break;
                        }

                        if (userDict[x][i] != keyword[i]) //counts the number of times each position (i) of a letter of a word in dictionary 
                                                          //is not equal to same position (i) in keyword 
                        {
                            numberOfDeviations++;
                        }
                    }
                    if (numberOfDeviations == 1)
                    {
                        return true;
                    }
                    numberOfDeviations = 0;
                }

                return false;

            }
            catch (Exception)
            {

                throw;
            }
            return default;
        }

        //Question 9
        public static void SolvePuzzle()
        {
            try
            {
                string equationString = getInputs();

                Cryptarithmetic c = new Cryptarithmetic(equationString); //Declare equationString as an object (c) of type Cryptarithmetic.
                c.Calc();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string getInputs() //collect inputs from user
        {
            Console.WriteLine("Enter input string 1:");
            string input1 = Console.ReadLine();
            Console.WriteLine("Enter input string 2:");
            string input2 = Console.ReadLine();
            Console.WriteLine("Enter output string:");
            string output = Console.ReadLine();

            return input1 + "+" + input2 + "=" + output;
        }

        public class Cryptarithmetic
        {
            string input1, input2, sum;
            bool invalidString;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            List<char> lettercount = new List<char>();
            Func<int, int, int, bool> calc;

            public Cryptarithmetic(string str)
            {
                SetString(str);
                if (!invalidString)
                {
                    SetDict(input1);
                    SetDict(input2);
                    SetDict(sum);
                }
            }

            void SetString(string str)
            {
                str = str.ToUpper().Replace(' ', '\0'); //make all characters in string uppercase because different cases will represent the same value
                                                        //i.e. cool = COOL
                string[] words = new string[3];
                try
                {
                    for (int i = 0, j = 0; i < str.Length; i++)
                    {
                        if (char.IsLetter(str[i])) //check if each character in the string is a letter
                        {
                            words[j] += str[i];
                        }
                        else
                        {
                            j++;
                            
                            calc = (n1, n2, s) => n1 + n2 == s && dict[sum[0]] != 0;  
                            
                            //validate that the values of  string 1 and 2 are valid for the given input and that the left most digit for sum is not equal to 0

                        }
                    }
                    input1 = words[0];
                    input2 = words[1];
                    sum = words[2];
                }
                catch
                {
                    invalidString = true;
                }
            }

            public void Calc() //checks if inputs are valid and can be calculated
            {
                if (invalidString || calc == null)

                {
                    Console.WriteLine("Invalid String");
                    return;
                }

                HashSet<int> set = new HashSet<int>(); //declare HashSet set which stores an unordered collection of the unique elements
                if (Solve(0, set))
                {
                    PrintInputs();
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
            }

            bool Solve(int idx, HashSet<int> set) //check if solutions exist for given inputs
            {
                bool found = false;
                if (idx == dict.Count)
                {
                    return Verify();
                }
                char ch = lettercount[idx];
                for (int n = 0; n < 10; n++)
                {
                    if (!set.Contains(n) && dict[ch] == -1)
                    {
                        dict[ch] = n;
                        set.Add(n);
                        found = Solve(idx + 1, set);
                        if (!found)
                        {
                            set.Remove(n);
                            dict[ch] = -1;
                        }
                        else return found;
                    }
                }
                return false;
            }

            void SetDict(string str)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (!dict.ContainsKey(str[i]))
                    {
                        dict.Add(str[i], -1);
                        lettercount.Add(str[i]);
                    }
                }
            }

            bool Verify() //check if solution is correct
            {
                int input1 = GetNum(this.input1);
                int input2 = GetNum(this.input2);
                int sum = GetNum(this.sum);
                return calc(input1, input2, sum);
            }

            int GetNum(string str) 
            {
                int pow = 1;
                int res = 0;
                for (int i = str.Length - 1; i >= 0; i--)
                {
                    res += dict[str[i]] * pow; 
                    pow *= 10;                      
                }
                return res;
            }

            void PrintInputs()
            {
                Console.WriteLine();
                PrintString(input1);
                Console.WriteLine("+");
                PrintString(input2);
                Console.WriteLine("=");
                PrintString(sum);
            }

            void PrintString(string str)
            {
                string res = string.Empty;
                for (int i = 0; i < str.Length; i++)
                {
                    res += dict[str[i]];
                }
                Console.WriteLine(str);
                Console.WriteLine(res);
            }
        }

    }
}