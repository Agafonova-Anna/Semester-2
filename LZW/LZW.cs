
public class LZW
{
    public static void Compress(string inputPath, string outputPath)
    {
        Trie trie = new Trie();
        FileStream fileToCompress = new FileStream(inputPath, FileMode.Open);
        FileStream compressedFile = new FileStream(outputPath, FileMode.CreateNew);
        byte[] input = new byte[fileToCompress.Length];
        fileToCompress.Read(input, 0, input.Length);

        for (int i = 0; i < 256; i++)
        {
            trie.Add(((char)i).ToString(), i);
        }

        int nextCode = 256;
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

    public static void Decompress(string inputPath, string outputPath)
    {
        Dictionary<int, string> dictionary = new Dictionary<int, string>();
        for (int i = 0; i < 256; i++)
        {
            dictionary.Add(i, ((char)i).ToString());
        }


        List<int> codes = new List<int>();
        using (BinaryReader reader = new BinaryReader(File.OpenRead(inputPath)))
        {
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                codes.Add(reader.ReadInt32());
            }
        }

        string current = dictionary[codes[0]];
        string output = current;
        for (int i = 1; i < codes.Count; i++)
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
            dictionary.Add(dictionary.Count, current + entry[0].ToString());
            current = entry;
        }

        File.WriteAllText(outputPath, output);
    }

    private static bool[] GetBinaryRepresentation(int number)
    {
        bool[] binaryArray = new bool[32];

        for (int i = 0; i < 32; i++)
        {
            binaryArray[i] = (number & (1 << i)) != 0;
        }

        return binaryArray;
    }

    private static byte[] GetByteArrayFromBinary(bool[] binaryArray)
    {
        byte[] byteArray = new byte[4];

        for (int i = 0; i < 4; i++)
        {
            int value = 0;

            for (int j = 0; j < 8; j++)
            {
                value |= (binaryArray[(i * 8) + j] ? 1 : 0) << j;
            }

            byteArray[i] = (byte)value;
        }

        return byteArray;
    }

    private static byte[] GetCodeForCompressedFile(int code)
    {
        bool[] binaryArray = GetBinaryRepresentation(code);
        byte[] byteArray = GetByteArrayFromBinary(binaryArray);

        return byteArray;
    }
}