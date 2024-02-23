

using System;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace BurrowsWheeler
{
    class Program
    {
        struct SuffArray
        {
            public int suffIndex;
            public string suffix;
        }
        private static int Compare(SuffArray suff1, SuffArray suff2)
        {
            return string.Compare(suff1.suffix, suff2.suffix);
        }
        private static SuffArray[] FormAndSortSuff(string enteredString)
        {
            SuffArray[] suff = new SuffArray[enteredString.Length];
            for (var i = 0; i < enteredString.Length; i++)
            {
                suff[i].suffIndex = i;
                suff[i].suffix = enteredString.Substring(i);
            }
            Array.Sort(suff, Compare);
            return suff;
        }
        private static int Position(SuffArray[] suff, string enteredString)
        {
            var position = 0;
            for (var i = 0; i < suff.Length; i++)
            {
                if (String.Compare(suff[i].suffix, enteredString) == 0)
                {
                    position = i;
                    break;
                }
            }
            return position;
        }
        private static int[] SortedArrInt(SuffArray[] suff)
        {
            int[] sortedSuffArr = new int[suff.Length];
            for (var i = 0; i < suff.Length; i++)
            {
                sortedSuffArr[i] = suff[i].suffIndex;
            }
            return sortedSuffArr;
        }
        private static string BurrowsWheelerTransform(string enteredString)
        {
            int[] sortedSuffArr = SortedArrInt(FormAndSortSuff(enteredString));
            char[] bwtArr = new char[enteredString.Length];
            for (var i = 0; i < enteredString.Length; i++)
            {
                var j = sortedSuffArr[i] - 1;
                if (j < 0)
                {
                    j += enteredString.Length;
                }
                bwtArr[i] = enteredString[j];
            }
            string bwtStr = String.Concat<char>(bwtArr);
            return bwtStr;
        }
        private static string InvertBWT(string convertedStr, int position)
        {
            char[] originalStr = new char[convertedStr.Length];
            int[] numOfEqual = new int[convertedStr.Length];
            for (var i = 0; i < convertedStr.Length; i++)
            {
                var count = 0;
                for (var j = 0; j < i; j++)
                {
                    if (convertedStr[i] == convertedStr[j])
                    {
                        count++;
                    }
                }
                numOfEqual[i] = count;
            }
            Dictionary<char, int> numOfSmaller = new Dictionary<char, int>();
            foreach (var symbol in convertedStr)
            {
                if (!numOfSmaller.ContainsKey(symbol))
                {
                    var count = 0;
                    foreach (var letter in convertedStr)
                    {
                        if (letter < symbol)
                        {
                            count++;
                        }
                    }
                    numOfSmaller.Add(symbol, count);
                }
            }
            originalStr[convertedStr.Length - 1] = convertedStr[position];
            var numOfSm = 0;
            for (var i = convertedStr.Length - 2; i >= 0; i--)
            {
                foreach (var symbol in numOfSmaller)
                {
                    if (originalStr[i + 1] == symbol.Key)
                    {
                        numOfSm = symbol.Value;
                        break;
                    }
                }
                originalStr[i] = convertedStr[numOfSm + numOfEqual[position]];
                position = numOfSm + numOfEqual[position];
            }
            string originalString = String.Concat<char>(originalStr);
            return originalString;
        }
        static void Main(string[] args)
        {
            var enteredString = "gfkjjgdfgfdljkwrklrokrhh";
            var position = Position(FormAndSortSuff(enteredString), enteredString);
            string transformedStr = BurrowsWheelerTransform(enteredString);
            string originalString = InvertBWT(transformedStr, position);
            Console.WriteLine($"Entered string: {enteredString}");
            Console.WriteLine($"Output: {transformedStr}");
            Console.WriteLine($"Position: {position}");
            Console.WriteLine($"Original string: {originalString}");
        }
    }
}
