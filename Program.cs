using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] nums1 = { 4, 9, 5 };
            int[] nums2 = { 9, 4, 9, 8, 4 };
            Intersection(nums1, nums2);
            Console.WriteLine("");

            //Question 2 
            Console.WriteLine("Question 2");
            int[] nums = { 0, 1, 0, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine(""); 

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            int Lnum = LuckyNumber(ar3);
            if (Lnum == -1)
            Console.WriteLine("Given Array doesn't have any lucky Integer");
            else
            Console.WriteLine("Lucky Integer for given array {0}", Lnum);
            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            Console.WriteLine("Enter the value for n:");
            int n = Int32.Parse(Console.ReadLine());
            int Ma = GenerateNums(n);
            Console.WriteLine("Maximun Element in the Generated Array is {0}", Ma);
            Console.WriteLine();

            //Question 5

            Console.WriteLine("Question 5");
            List<List<string>> cities = new List<List<string>>();
            cities.Add(new List<string>() { "London", "New York" });
            cities.Add(new List<string>() { "New York", "Tampa" });
            cities.Add(new List<string>() { "Delhi", "London" });
            string Dcity = DestCity(cities);
            Console.WriteLine("Destination City for Given Route is : {0}", Dcity);

            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 7, 11, 15 };
            int target_sum = 9;
            targetSum(Nums, target_sum);
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int[] arr = { 1, 2, 3, 4, 5, 6, 7};
            int K = 3;
            RotateArray(arr, K);
            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] arr9 = { 7, 1, 5, 3, 6, 4 };
            int Ms = MaximumSum(arr9);
            Console.WriteLine("Maximun Sum contiguous subarray {0}", Ms);
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int[] costs = { 10, 15, 20 };
            int minCost = MinCostToClimb(costs);
            Console.WriteLine("Minium cost to climb the top stair {0}", minCost);
            Console.WriteLine();
        }

        //Question1
        public static void Intersection(int[] nums1, int[] nums2)
        {

            try
            {
                //if the first and second sets are print no intersetion
                if (((nums1 == null)
                    || (nums2 == null)))
                {
                    Console.WriteLine("No Intersection");
                }
                // create two hashsets
                HashSet<int> set = new HashSet<int>();
                HashSet<int> ret = new HashSet<int>();
                //store all the elements in the first set(nums1) in "set"
                for (int i = 0; i < nums1.Length; i++)
                {
                    set.Add(nums1[i]);
                }
                //perform iterations to find the intersected elements and store them in "ret"
                for (int i = 0; (i < nums2.Length); i++)
                {
                    if ((set.Contains(nums2[i])
                                && !ret.Contains(nums2[i])))
                    {
                        ret.Add(nums2[i]);
                    }

                }
                //create a new array to store all the unique elements of "ret"
                int a = ret.Count;
                int[] arr = new int[a];
                int counter = 0;
                foreach (int curr in ret)
                {
                    arr[counter++] = curr;

                }
                // To print the unique intersected terms
                foreach (int k in arr)
                {

                    Console.Write("{0} ", k);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Question2
        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                // Lower and upper index values in the array
                int start = 0;
                int end = nums.Length - 1;
                // Search the array "nums"
                while (start <= end)
                {
                    int mid = (start + end) / 2;
                    // If target is found
                    if (nums[mid] == target)
                        return mid;
                    // If target isn't found and middle element is smaller than target then consider "start" as "mid+1"
                    //so that we can eleminate the lower values and search in the elements which are greater than "mid"
                    else if (nums[mid] < target)
                        start= mid +1;
                    else
                        end = mid - 1;
                }

                // If all elements are smaller than target value then return the length of the array which will be the last index value of the array

                return end + 1;

            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question3
        private static int LuckyNumber(int[] nums)
        {
            try
            {
                int res = -1;
                int[] count = new int[501];
                //traverse every element in the array
                foreach (int a in nums)
                {
                    count[a]++;
                }
                //finding the repeated lucky number 
                for (int i = 500; i >=1; i--)
                {
                    if (count[i] == i)
                    {
                        return i;
                    }

                }

                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
           
                

        //Question4
        private static int GenerateNums(int n)
        {
            try
            {
                    if (n < 2) //base case
                        return n;
                    int[] nums = new int[n + 1];
                    nums[0] = 0; //first element
                    nums[1] = 1; //second element
                    for (int i = 2; i <= n; i++)
                    {
                    // according to the given rule: for all even index numbers (nums[4] = nums[4/2 = 2] = nums[2])
                        if (i % 2 == 0)
                        {
                            nums[i] = nums[i / 2];
                        }
                        else //for odd indexed numbers
                        {
                            int temp = (i - 1) / 2;
                            nums[i] = nums[temp] + nums[temp + 1];
                        }
                    }
                    return nums.ToList().Max();
                }
            catch (Exception)
            {

                throw;
            }

        }
        //Question 5
        public static string DestCity(List<List<string>> paths)
        {
            try
            {
                var dict = paths.ToDictionary(x => x[0], y => y[1]);
                var res = "";
                // Iterate through all of the paths and check to see if the end cities exist in the dictionary.
                // If not found, return this city.
                foreach (var e in paths)
                {
                    if (!dict.ContainsKey(e[1]))
                    {
                        res = e[1];
                    }
                }
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Question 6
        private static void targetSum(int[] nums, int target)
        {
            try
            {
                var i = 0;
                var j = nums.Length - 1;

                while (i < j)
                {
                    //if the target element is found print i+1 and j+1
                    if (nums[i] + nums[j] == target)
                    {
                        Console.WriteLine("[" + (i + 1) + "," + (j + 1) + "]");
                        break;
                    }
                    //if target element is greater than the sum of elements increment i and continue
                    else if (nums[i] + nums[j] < target)
                    {
                        i++;
                    }
                    else
                    {
                        j--;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Queestion 7
        private static void HighFive(int[,] items)
        {
            try
            {
                // initialize new lists to store the top five average score of the students in it 
                List<int[]> l = new List<int[]>();
                List<int[,]> res = new List<int[,]>();

                for (int i = 0; i < items.GetLength(0); i++)
                {
                    l.Add(new int[] { items[i, 0], items[i, 1] }); // adding all the scores to the new list l
                }
                //now sort the scores to find the maximum 5 scores of every student
                l.Sort((a, b) => { return (a[0] < b[0]) ? -1 : ((a[0] == b[0]) ? ((a[1] <= b[1]) ? 1 : -1) : 1); });
                int x = l[0][0];
                int count = 1;
                int sum = l[0][1];

                //now consider the top 5 scores of the student and find the average of top 5 scores
                for (int i = 1; i < l.Count; i++)
                {
                    if (l[i][0] == x && count < 5)
                    {
                        sum += l[i][1];
                        count += 1;
                    }
                    else if (l[i][0] != x)
                    {
                        res.Add(new int[,] { { x, sum / 5 } });

                        Console.WriteLine("[[" + x + "," + sum / 5 + "]" + ",");
                        x = l[i][0];
                        count = 1;
                        sum = l[i][1];
                    }
                }
                res.Add(new int[,] { { x, sum / 5 } });
                Console.WriteLine("[" + x + "," + sum / 5 + "]]"); //print the result in the desired format
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Question 8
        private static void RotateArray(int[] arr, int n)
        {
            try
            {
                //initializing result in a new array with the same length of the array
                int[] result = new int[arr.Length];
                int l = arr.Length;
                // assigning the first element of the arr as the nth element in the result --> result[n]=arr[0], result[n+1]=arr[1] and continues
                //the loop continues until all elements are rotated or reached the first element in this cycle
                for (int i = 0; i < l; i++)
                {
                    result[(i + n) % l] = arr[i];
                }
               //this loop helps to assign values to arr[]
                for (int i = 0; i < l; i++)
                {
                    arr[i] = result[i];
                    
                }
                Console.WriteLine("[" + String.Join(",", arr) + "]");
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Question 9
        private static int MaximumSum(int[] arr)
        {
            try
            {
                if (arr == null)
                    return 0;

                int result = arr[0]; // initialize result to keep track of maximum sum contiguous subarray among all positive subarrays
                // implementing Kadane's algorithm to find the maximum sum of subarray
                int interval = 0;
                // Each time we get a positive sum compare it with result and update result if it is greater 
                for (int i = 0; i < arr.Length; ++i)
                {
                    interval += arr[i];
                    result = Math.Max(interval, result);
                    interval = Math.Max(0, interval);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Question 10
        private static int MinCostToClimb(int[] costs)
        {
            try
            {
                //initializizing first element in the array as prev_prev and second element as prev
                int prev_prev = costs[0];
                int prev = costs[1];
                //for all the elements in the array compare every 2 consecutive elements and find out the minimum element by using Math.Min() method and move forward
                for (int i = 2; i < costs.Length; i++)
                {
                    int curr = Math.Min(prev_prev, prev) + costs[i]; 
                    prev_prev = prev; // for every loop prev becomes prev_prev and curr becomes prev
                    prev = curr;
                }

                return Math.Min(prev_prev, prev); //return the minimum cost 
            }
            catch (Exception)
            {

                throw;
            }
        }
    }          
}
    

