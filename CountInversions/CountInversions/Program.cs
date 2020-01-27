using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CountInversions
{
    public class Program
    {
        /* This method sorts the input array and returns the 
       number of inversions in the array */
    static long mergeSort(int []arr, int array_size) 
    { 
        int []temp = new int[array_size]; 
        return _mergeSort(arr, temp, 0, array_size - 1); 
    } 
   
    /* An auxiliary recursive method that sorts the input array and 
      returns the number of inversions in the array. */
    static long _mergeSort(int []arr, int []temp, int left, int right) 
    {
        int mid;
        long inv_count = 0; 
        if (right > left) { 
            /* Divide the array into two parts and call _mergeSortAndCountInv() 
           for each of the parts */
            mid = (right + left) / 2; 
   
            /* Inversion count will be the sum of inversions in left-part, right-part 
          and number of inversions in merging */
            inv_count = _mergeSort(arr, temp, left, mid); 
            inv_count += _mergeSort(arr, temp, mid + 1, right); 
   
            /*Merge the two parts*/
            inv_count += merge(arr, temp, left, mid + 1, right); 
        } 
        return inv_count; 
    } 
   
    /* This method merges two sorted arrays and returns inversion count in 
       the arrays.*/
    static long merge(int []arr, int []temp, int left, int mid, int right) 
    { 
        int i, j, k; 
        long inv_count = 0; 
   
        i = left; /* i is index for left subarray*/
        j = mid; /* j is index for right subarray*/
        k = left; /* k is index for resultant merged subarray*/
        while ((i <= mid - 1) && (j <= right)) { 
            if (arr[i] <= arr[j]) { 
                temp[k++] = arr[i++]; 
            } 
            else { 
                temp[k++] = arr[j++]; 
   
                /*this is tricky -- see above explanation/diagram for merge()*/
                inv_count = inv_count + (mid - i); 
            } 
        } 
   
        /* Copy the remaining elements of left subarray 
       (if there are any) to temp*/
        while (i <= mid - 1) 
            temp[k++] = arr[i++]; 
   
        /* Copy the remaining elements of right subarray 
       (if there are any) to temp*/
        while (j <= right) 
            temp[k++] = arr[j++]; 
   
        /*Copy back the merged elements to original array*/
        for (i = left; i <= right; i++) 
            arr[i] = temp[i]; 
   
        return inv_count; 
    } 
        static void Main(string[] args)
        {
           


            var list = new List<int>();
            var fileStream = new FileStream(@"C:\Users\Administrador\Desktop\Cursos\Algorithms\2.CounInversionsWithMergeSort\IntegerArray.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(Convert.ToInt32(line));
                }
            }

            int[] arr= new int[list.Count];

            arr = list.ToArray();
            Console.Write("Number of inversions are " + mergeSort(arr, arr.Length));

            //foreach(int line in arr)
            //{
            //    Console.WriteLine(line);
            //}
        }
    }
}
