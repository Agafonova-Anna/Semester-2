
/// <summary>
/// Class <c>BurrowsWheelerTransformMethods</c> describes methods,that are used in Burrows-Wheeler Transform.
/// </summary>
public class BurrowsWheelerTransformMethods
{
    /// <summary>
    /// Stores elements of the suffix array.
    /// </summary>
    private struct SuffixArray
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuffixArray"/> struct.
        /// </summary>
        /// <param name="index">The index of the element that will be stored in the suffix array.</param>
        /// <param name="suffix">The suffix that will be stored in the suffix array.</param>
        public SuffixArray(int index, string suffix)
        {
            SuffixIndex = index;
            Suffix = suffix;
        }

        /// <summary>
        /// Gets the index of the element that will be stored in the suffix array.
        /// </summary>
        public int SuffixIndex { get; }

        /// <summary>
        /// Gets the suffix that will be stored in the suffix array.
        /// </summary>
        public string Suffix { get; }
    }

    /// <summary>
    /// This method calculates the index of the element in a sorted suffix array,that contains the entered string in it's Suffix field.
    /// </summary>
    /// <param name="suffixArray"> a sorted suffix array that is a result of <c>GetInitialSuffixArray</c> method.</param>
    /// <param name="enteredString">the string entered by a user.</param>
    /// <returns> int number representing the index described above.</returns>
    /// <exception cref="ArgumentException">Thrown when the argument enteredString is null or empty.</exception> 
    public static int Position(string enteredString)
    {
        ArgumentException.ThrowIfNullOrEmpty(enteredString);
        var suffixArray = GetInitialSuffixArray(enteredString);
        var position = 0;

        for (var i = 0; i < suffixArray.Length; i++)
        {
            if (suffixArray[i].Suffix == enteredString)
            {
                position = i;
                break;
            }
        }

        return position;
    }

    /// <summary>
    /// This method is an implementation of the Burrows-Wheeler transform.
    /// </summary>
    /// <param name="enteredString">The string entered by a user.</param>
    /// <returns>A string transformed by means of Burrows-Wheeler algorithm.</returns>
    /// <exception cref="ArgumentException">Thrown when the argument enteredString is null or empty.</exception>
    public static string BurrowsWheelerTransform(string enteredString)
    {
        ArgumentException.ThrowIfNullOrEmpty(enteredString);

        var suffixArray = GetInitialSuffixArray(enteredString);
        var sortedSuffixArray = suffixArray.Select(s => s.SuffixIndex).ToArray();
        var bwtArrayChar = new char[enteredString.Length];

        for (var i = 0; i < enteredString.Length; i++)
        {
            var j = sortedSuffixArray[i] - 1;

            if (j < 0)
            {
                j += enteredString.Length;
            }

            bwtArrayChar[i] = enteredString[j];
        }

        var bwtString = string.Concat(bwtArrayChar);

        return bwtString;
    }

    /// <summary>
    /// This method is an implementation of the Inverse Burrows-Wheeler transform.
    /// </summary>
    /// <param name="convertedString">a string transformed by means of BWT algorithm.</param>
    /// <param name="position">the index of the element in a sorted suffix array from a direct BWT that contains the entered string in it's Suffix field.</param>
    /// <returns>the original string (the string entered by a user before a direct BWT).</returns>
    /// <exception cref=" ArgumentException">Thrown when the argument position is less then zero.</exception>
    /// <exception cref=" ArgumentException">Thrown when the argument convertedString is null or empty. </exception>
    public static string InverseBWT(string convertedString, int position)
    {
        ArgumentException.ThrowIfNullOrEmpty(convertedString);
        if (position < 0)
        {
            throw new ArgumentException("Invalid position value");
        }

        var originalStringChar = new char[convertedString.Length];
        var numberOfEqualSymbols = NumberOfEqualSymbolsInSubstring(convertedString);
        Dictionary<char, int> numberOfSmallerSymbols = NumberOfSmallerSymbolsInString(convertedString);

        originalStringChar[convertedString.Length - 1] = convertedString[position];

        var numberOfSmallerCharacters = 0;

        for (var i = convertedString.Length - 2; i >= 0; i--)
        {
            foreach (var symbol in numberOfSmallerSymbols)
            {
                if (originalStringChar[i + 1] == symbol.Key)
                {
                    numberOfSmallerCharacters = symbol.Value;
                    break;
                }
            }

            originalStringChar[i] = convertedString[numberOfSmallerCharacters + numberOfEqualSymbols[position]];
            position = numberOfSmallerCharacters + numberOfEqualSymbols[position];
        }

        var originalString = string.Concat(originalStringChar);

        return originalString;
    }

    /// <summary>
    /// This method creates and sorts an array of suffixes of the entered string.
    /// </summary>
    /// <param name="enteredString">the string entered by a user.</param>
    /// <returns> a sorted suffix array described above. </returns>
    private static SuffixArray[] GetInitialSuffixArray(string enteredString)
    {
        var suffixArray = new SuffixArray[enteredString.Length];

        for (var i = 0; i < enteredString.Length; i++)
        {
            suffixArray[i] = new SuffixArray(i, enteredString.Substring(i));
        }

        Array.Sort(suffixArray, (SuffixArray a, SuffixArray b) => string.Compare(a.Suffix, b.Suffix));

        return suffixArray;
    }

    /// <summary>
    /// This method counts the number of elements equal to each element of the entered string in the substring,starting from the first character and ending with the given character.
    /// </summary>
    /// <param name="convertedString">a string transformed by means of BWT algorithm.</param>
    /// <returns>an array of int numbers representing the information described above.</returns>
    private static int[] NumberOfEqualSymbolsInSubstring(string convertedString)
    {
        var numberOfEqualSymbols = new int[convertedString.Length];

        for (var i = 0; i < convertedString.Length; i++)
        {
            var count = 0;

            for (var j = 0; j < i; j++)
            {
                if (convertedString[i] == convertedString[j])
                {
                    count++;
                }
            }

            numberOfEqualSymbols[i] = count;
        }

        return numberOfEqualSymbols;
    }

    /// <summary>
    /// This method makes up a dictionary
    /// which contains the information about each unique symbol in a converted string:
    /// key is a unique character, value is a number of letters in a converted string
    /// smaller than this character.
    /// </summary>
    /// <param name="convertedString">a string transformed by means of BWT algorithm.</param>
    /// <returns> a dictionary described above.</returns>
    private static Dictionary<char, int> NumberOfSmallerSymbolsInString(string convertedString)
    {
        Dictionary<char, int> numberOfSmallerSymbols = new Dictionary<char, int>();

        foreach (var symbol in convertedString)
        {
            if (!numberOfSmallerSymbols.ContainsKey(symbol))
            {
                var count = 0;

                foreach (var letter in convertedString)
                {
                    if (letter < symbol)
                    {
                        count++;
                    }
                }

                numberOfSmallerSymbols.Add(symbol, count);
            }
        }

        return numberOfSmallerSymbols;
    }
}