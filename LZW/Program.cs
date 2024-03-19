
static void Main(string[] args)
{
    if (args.Length == 0)
    {
        Console.WriteLine("No command line arguments provided.");
    }
    else
    {
        if (args[1] == "--c")
        {
            string outputPath = args[0] + ".zipped";
            LZW.Compress(args[0], outputPath);
            FileInfo originalFile = new FileInfo(args[0]);
            FileInfo compressedFile = new FileInfo(outputPath);
            double compressionRatio = (double)originalFile.Length / compressedFile.Length * 100;
            Console.WriteLine("Compression Ratio: " + compressionRatio + "%");
        }

        if (args[1] == "-u")
        {
            string outputPath = args[0].Substring(0, args[0].Length - 7);
            LZW.Decompress(args[0], outputPath);
        }
    }
}