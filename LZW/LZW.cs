/// <summary>
/// The implementation of  LZW algorithm methods: Compress and Decompress.
/// </summary>
public class LZW
{
    /// <summary>
    /// Compresses files using LZW algorithm.
    /// </summary>
    /// <param name="inputPath">The path to the file to be compressed.</param>
    /// <param name="outputPath">The path to the compressed file.</param>
    public static void Compress(string inputPath, string outputPath)
    {
        if (new FileInfo(inputPath).Length == 0)
        {
            throw new ArgumentNullException("InputFile is empty");
        }

        Trie trie = new Trie();
        FileStream fileToCompress = new FileStream(inputPath, FileMode.Open);
        FileStream compressedFile = new FileStream(outputPath, FileMode.CreateNew);
        var input = new byte[fileToCompress.Length];
        fileToCompress.Read(input, 0, input.Length);

        for (var i = 0; i < 256; i++)
        {
            trie.Add(((char)i).ToString(), (ushort)i);
        }

        ushort nextCode = 256;
        byte[] symbolCode;
        string current = string.Empty;

        foreach (byte nextByte in input)
        {
            string currentSymbol = current + (char)nextByte;
            if (trie.Contains(currentSymbol))
            {
                current = currentSymbol;
            }
            else
            {
                symbolCode = GetCodeForCompressedFile(trie.GetCode(current));
                compressedFile.Write(symbolCode, 0, symbolCode.Length);
                trie.Add(currentSymbol, nextCode);
                nextCode++;
                current = ((char)nextByte).ToString();
            }
        }

        symbolCode = GetCodeForCompressedFile(trie.GetCode(current));
        compressedFile.Write(symbolCode, 0, symbolCode.Length);
        fileToCompress.Close();
        compressedFile.Close();
    }

    /// <summary>
    /// Decompresses files compressed using LZW algorithm.
    /// </summary>
    /// <param name="inputPath">The path to the compressed file.</param>
    /// <param name="outputPath">The path to the decompressed file.</param>
    public static void Decompress(string inputPath, string outputPath)
    {
        if (new FileInfo(inputPath).Length == 0)
        {
            throw new ArgumentNullException("InputFile is empty");
        }

        Dictionary<ushort, string> dictionary = new Dictionary<ushort, string>();
        for (var i = 0; i < 256; i++)
        {
            dictionary.Add((ushort)i, ((char)i).ToString());
        }

        List<ushort> codes = new List<ushort>();
        using (BinaryReader reader = new BinaryReader(File.OpenRead(inputPath)))
        {
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                codes.Add(reader.ReadUInt16());
            }
        }

        string current = dictionary[codes[0]];
        string output = current;
        for (var i = 1; i < codes.Count; i++)
        {
            string entry = string.Empty;
            if (dictionary.ContainsKey(codes[i]))
            {
                entry = dictionary[codes[i]];
            }
            else if (codes[i] == dictionary.Count)
            {
                entry = current + current[0];
            }

            output += entry;
            dictionary.Add((ushort)dictionary.Count, current + entry[0].ToString());
            current = entry;
        }

        File.WriteAllText(outputPath, output);
    }

    private static byte[] GetCodeForCompressedFile(ushort? number)
    {
        bool[] boolArray = new bool[16];
        for (int i = 0; i < 16; i++)
        {
            boolArray[i] = (number & (1 << i)) != 0;
        }

        byte[] byteArray = new byte[2];
        for (int i = 0; i < 8; i++)
        {
            byteArray[0] |= (byte)(boolArray[i] ? (1 << i) : 0);
            byteArray[1] |= (byte)(boolArray[i + 8] ? (1 << i) : 0);
        }

        return byteArray;
    }
}