/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions; 

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        public static List<string> final = new List<string>();

        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 2, 3, 3 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        // Learned binary search through this question and should try to be more proficient in using it
        public static int SearchInsert(int[] nums, int target)
        {

            return search(nums, 0, nums.Length - 1, target); 
        }
        private static int search(int[] nums, int l, int r, int target)
        {
            try
            {
                if (l > r)
                {
                    return r + 1;
                }
                int mid = (l + r) / 2; // finding mid of an array

                if (nums[mid] < target)
                {
                    return search(nums, mid + 1, r, target); //calls recursive search function
                }
                if (nums[mid] > target)
                {
                    return search(nums, l, mid - 1, target); 
                }
                return mid;
            }
            catch (Exception) { throw; 
            }
        }
        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.
        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.
        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        // Learned using dictionaries and some of its inbuilt functions
        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                var bulls_string2 = Regex.Replace(paragraph, @"[^a-zA-Z ]", "").ToLower(); //removes white spaces and special characters if any and converts the string to lowercase
                Console.WriteLine(bulls_string2);
                List<string> arr_bulls = new List<string>(); //creates a new list
                /* Hashtable use_words = new Hashtable(); */
                Dictionary<String, int> use_words = new Dictionary<String, int>(); // declaring and initialising dictionary
                var output = "somestring";
                use_words[output] = -1;
                arr_bulls = bulls_string2.Split(" ").ToList(); //splits the string at space and converts it to list
                foreach (var norm in arr_bulls)
                {
                    var word = banned.Contains(norm) || string.IsNullOrWhiteSpace(norm); // returns bool value
                    if (!word)
                    {
                        if (use_words.ContainsKey(norm)) //if norm is in keys of use_words, its value in dictionary is increased
                        {

                            use_words[norm]++;
                        }

                        else
                        {

                            use_words[norm] = 1;
                        }
                    }
                }
                foreach (var uw in use_words) 
                {
                    if (use_words[uw.Key] > use_words[output]) //if the key is greater than value of output in dictionary , key is assigned to output
                    {
                        output = uw.Key; 

                    }

                }
                return output;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        // Learnt a different way ti manipulate an array which has no elements in it
        public static int FindLucky(int[] arr)
        {
            try
            {
                int[] lucky = new int[501]; // creates array of size 500 to meet constraints

                foreach (int i in arr)
                {
                    lucky[i]++;  //increases the value in lucky i if that integer is in arr
                }

                for (int i = lucky.Length - 1; i > 0; i--) // iterates from back to find largest lucky number
                {
                    if (i == lucky[i]) // if the value is equal to integer, returns the value
                    {

                        return i;
                    }
                }
                return -1; //else return -1
            }
            catch (Exception) {
                throw;
            }
        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"
        */

        // learnt the method remove. Shouldve done better with using loops
        public static string GetHint(string secret, string guess)
        {
            try
            {
                String final = "";
                int bulls = 0;
                int cows = 0;
                int i = 0;
                while (i < secret.Length)
                {
                    if (secret[i] == guess[i])
                    {
                        bulls = bulls + 1;
                        secret = secret.Remove(i, 1); //remove function deletes the elements in the string till the specified number
                        guess = guess.Remove(i, 1);
                        
                    }
                    else
                    {
                        i = i + 1; 
                    }

                }
                int sl = secret.Length;
                int gl = guess.Length;
                for (int j = 0; j < sl; j++) //two loops to iterate on two strings
                {
                    int k = 0;
                    while (k < guess.Length)
                    {
                        if (secret[j] == guess[k])
                        {

                            guess = guess.Remove(k, 1); //removes the element from the index k and increases cows
                            cows = cows + 1;
                            
                            break;
                        }
                        else
                        {
                            k = k + 1; // index increases if element doesn't match

                        }
                    }

                }
                final = bulls.ToString() + "A" + cows.ToString() + "B";
                return final;

            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.
        Example 1:
        Input: s = "ababcbacadefegdehijhklij"  
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
        */

        // Most complicated problem in the assignment. Took around 3 hrs to complete it. Got a grip on using Ascii values
        public static List<int> PartitionLabels(string s)
        {
            try
            {
                int[] lastpos = new int[26];
                char[] convs = s.ToCharArray(); //converts s to character array
                int lb = 0;
                int rb = 0;
                List<int> myList = new List<int>(); //declares and initialises a List
                int i = 0;
                foreach (char c in convs)
                {
                    lastpos[c - 'a'] = i; // gets the difference in ASCII values and the value in the index of that difference is assigned in i
                    i++;
                }
                for (int j = 0; j <= s.Length; j++)
                {
                    if (j > rb)
                    {
                        myList.Add((rb - lb) + 1); // adds the difference to MyList
                        lb = j;

                        if (j == s.Length)
                        {
                            break;
                        }
                    }
                    int rightpos = lastpos[s[j] - 'a']; // the value at the index of the difference between s[j] and 'a' Ascii values is assigned to rightpos
                    if (rightpos > rb)
                    {
                        rb = rightpos;
                    }

                }
                return myList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6
        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.
         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.
         */

        // Experience from previous problem helped me in completing this. 

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                /*String alpha = "abcdefghijklmnopqrstuvwxyz";
                Dictionary<char, int> az = new Dictionary<char, int>();
                /* for(int i=0;i<alpha.Length;i++)
                {
                    az.Add(alpha[i], widths[i]);      
                }
                int count = 0;
                int sum=0;
                int[] dup = new int[1];
                int sum2 = 0;
                for (int j = 0; j < s.Length-1; j++) {
                    count = count + 1;
                    sum = sum + alpha[s[j]];
                    sum2 = sum + alpha[s[j + 1]];
                    if (sum2>100) {
                        dup.add(v);         
                    }
                }*/

                int number = 1;
                int characters = 0;
                for (int i=0; i<s.Length;i++)
                {
                    int w = widths[s[i] - 'a']; //gets difference ascii values b/w character and 'a' and the value width in that index and add to width
                   
                   characters += w;
                    if (characters > 100) //if width is greater than 100, increase the numbers by 1
                    {
                        number++;
                        characters= w;
                    }

                }
                return new List<int>() {
                    number,characters
                };
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
        
        Question 7:
        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true
        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true
        Example 3:
        Input: bulls_string  = "(]"
        Output: false
        */

        //Learnt manipulating stacks and its functions along with dictionaries
        public static bool IsValid(string bulls_string10)
        {
            try
            {
                if (bulls_string10.Length % 2 != 0) // if length is odd , return false
                {

                    return false;
                }

                Dictionary<char, char> special = new Dictionary<char, char>();
                special.Add('(', ')'); // add values to dictionary
                special.Add('[', ']');
                special.Add('{', '}');
                Stack st = new Stack(); // declare and intialize a stack
                var keys = special.Keys;
                foreach (char b in bulls_string10)
                {
                    if (keys.Contains(b)) // if the character is in keys, push it into stack
                    {

                        st.Push(b);
                    }
                    else
                    {
                        if (st.Count == 0) 
                        {
                            return false;
                        }
                        var p = st.Pop(); // pops the value from stack
                        char popped = Convert.ToChar(p); // converts the popped value to char
                        if (b != special[popped]) // if the element is not equal to the value of the element popped, return false
                        {
                            return false;
                        }

                    }

                }
                return (st.Count == 0); //returns true if count is zero, else returns false

            }
            catch (Exception) { throw; }
        }





        /* Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.
        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".
        */

        // Took a while to complete this. Shouldve done better with using loops.
        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                String alpha = "abcdefghijklmnopqrstuvwxyz";
                Dictionary<string, string> dict = new Dictionary<string, string>();
                List<string> morsecode = new List<string>();
                List<string> mor = new List<string>();
                string[] morse = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                for (int i = 0; i < alpha.Length; i++)
                {
                    dict.Add(alpha[i].ToString(), morse[i]); // adds alphabet and its morse code to dictionary
                }
                foreach (string i in words)
                {
                    int k = 0;
                    String mc = "";
                    while (k < i.Split().Length) // splits word into letters
                    {
                        int h = 0; 
                        while (h < i.Split()[k].Length)
                        {
                            mc = mc + dict[i.Split()[k][h].ToString()];//gets the value of the letter from dictionary and concatenates it with string
                            h = h + 1;
                        }
                        mor.Add(mc); // appends the string to the list
                        k = k + 1;
                    }
                }
                return mor.Select(x => x).Distinct().Count(); // returns the count of unique value in the list
            }
            catch (Exception)
            {
                throw;
            }

        }

        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        */

                public static int SwimInWater(int[,] grid)
        {
            try
            {
                //write your code here.
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:
        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                //write your code here.
                return 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}