public class LZWTests
{
    private const string inputFilePath = "FileForTests.txt";
    private const string compressedFilePath = "FileForTests.txt.zipped";
    private const string decompressedFilePath = "DecompressedFile.txt";

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(inputFilePath))
        {
            File.Delete(inputFilePath);
        }
        if (File.Exists(compressedFilePath))
        {
            File.Delete(compressedFilePath);
        }
        if (File.Exists(decompressedFilePath))
        {
            File.Delete(decompressedFilePath);
        }
    }

    [Test]
    public void Compress_InputFileIsCompressed_Successfully()
    {
        File.WriteAllText(inputFilePath, "Test content for compression and decompression.");

        LZW.Compress(inputFilePath, compressedFilePath);

        Assert.IsTrue(File.Exists(compressedFilePath));
    }

    [Test]
    public void Decompress_DecompressedFileIsCreated_Successfully()
    {
        File.WriteAllText(inputFilePath, "Test content for compression and decompression.");

        LZW.Compress(inputFilePath, compressedFilePath);
        LZW.Decompress(compressedFilePath, decompressedFilePath);

        Assert.IsTrue(File.Exists(decompressedFilePath));
    }


    [TestCase("Data compression has an undeserved reputation for being difficult to master, hard to implement, and tough to maintain. In fact, the techniques used in the previously mentioned programs are relatively simple, and can be implemented with standard utilities taking only a few lines of code. This article discusses a good all-purpose data compression technique: Lempel-Ziv-Welch, or LZW compression.")]
    [TestCase("a")]
    [TestCase("12345%^&$(@$%)")]
    public void Decompress_CompressedFileIsDecompressed_Successfully(string contentsOfSourceFile)
    {
        File.WriteAllText(inputFilePath, contentsOfSourceFile);
        LZW.Compress(inputFilePath, compressedFilePath);

        LZW.Decompress(compressedFilePath, decompressedFilePath);
        string originalContent = File.ReadAllText(inputFilePath);
        string decompressedContent = File.ReadAllText(decompressedFilePath);

        Assert.AreEqual(originalContent, decompressedContent);
    }

    [Test]
    public void Compress_EmptyInputFile_ShouldThrowArgumentNullExeption()
    {
        File.WriteAllText(inputFilePath, "");

        Assert.Throws<ArgumentNullException>(() => LZW.Compress(inputFilePath,compressedFilePath));
    }

    [Test]
    public void Decompress_EmptyInputFile_ShouldThrowArgumentNullExeption()
    {
        File.WriteAllText(inputFilePath, "");

        Assert.Throws<ArgumentNullException>(() => LZW.Decompress(inputFilePath, decompressedFilePath));
    }

}
