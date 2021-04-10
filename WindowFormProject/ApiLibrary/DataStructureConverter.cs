using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProjectLibrary
{
    public class DataStructureConverter
    {
        /// <summary>
        /// example: convert "[name,car,house]" to [name,car,house]
        /// </summary>
        /// <returns></returns>
        public static string[] ConvertStringToArrayOfString(string arrayInString)
        {
            //remove brackets in the string (array leftover)
            arrayInString=arrayInString.Replace("[", "");
            arrayInString=arrayInString.Replace("]", "");
            return arrayInString.Split(',');


        }
        /// <summary>
        /// example: convert "[3,4,5]" to [3,4,5]
        /// </summary>
        /// <returns></returns>
        public static int[] ConvertArrayInStringToArrayOfInt(string arrayInString)
        {
            
            //remove brackets in the string (array leftover)
            arrayInString = arrayInString.Replace("[", "");
            arrayInString = arrayInString.Replace("]", "");
            string[] array=arrayInString.Split(',');
            //convert to int
            int[] convertedArray = new int[array.Length];
            for (int i = 0; i < convertedArray.Length; i++)
            {
                convertedArray[i] = Int32.Parse(array[i]);
            }
            return convertedArray;
        }
        public static byte[] ConvertArrayInStringToArrayOfByte(string arrayInString)
        {

            //remove brackets in the string (array leftover)
            arrayInString = arrayInString.Replace("[", "");
            arrayInString = arrayInString.Replace("]", "");
            string[] array = arrayInString.Split(',');
            //convert to int
            byte [] convertedArray = new byte[array.Length];
            for (int i = 0; i < convertedArray.Length; i++)
            {
                convertedArray[i] = Convert.ToByte(array[i]);
               
            }
           


            return convertedArray;
        }
        public static T[,,] Convert1dArrayTo3d<T>(T[] array,int d1,int d2,int d3)
        {
            //bad args
            if (d1 * d2 * d3 != array.Length)
            {
                Debug.WriteLine("array size doesnt match");
                Debug.WriteLine("3d array size is " + (d1 * d2 * d3).ToString());
                Debug.WriteLine("1d array size is " + array.Length.ToString());
                throw new ArgumentException("array size doesnt match");
            }
            int i, j, k, p;
            T[,,] arr = new T[d1, d2, d3];
            p = 0;
            //fill array
            for (i = 0; i < d1; i++)
            {
                for (j = 0; j < d2; j++)
                {
                    for (k = 0; k < d3; k++)
                    {

                        arr[i, j, k] = array[p];
                        p++;
                    }
                }
            
            }
                
                        

            return arr;

        }
    }
}
