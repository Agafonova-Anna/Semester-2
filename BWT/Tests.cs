
public class Tests
{
    public static void PrintTestResult(string testName, bool result)
    {
        Console.WriteLine(testName + " " + (result ? "was completed successfully" : "ended with an eror"));
    }

    public static bool LongStringBWTTest()
    {
        if (String.Compare(BurrowsWheelerTransformMethods.BurrowsWheelerTransform("gfjkgzsngklnsnmksfnmfgngfgff$"), "ffggmgsfn$nfkfjgmknngsfslkzng") == 0)
        {
            return true;
        }

        return false;


    }

    public static bool PositionTest()
    {
        if (BurrowsWheelerTransformMethods.Position(BurrowsWheelerTransformMethods.GetInitialSuffixArray("колокол$"), "колокол$") == 2)
        {
            return true;
        }

        return false;
    }

    public static bool OneSymbolStringBWTTest()
    {
        if (String.Compare(BurrowsWheelerTransformMethods.BurrowsWheelerTransform("g"), "g") == 0)
        {
            return true;
        }

        return false;
    }

    public static bool InverseBWTTest()
    {
        if (String.Compare("колокол$", BurrowsWheelerTransformMethods.InverseBWT("ло$оолкк", 2)) == 0)
        {
            return true;
        }

        return false;

    }

    public static bool TestResult()
    {
        bool longStringBWTResult = LongStringBWTTest();
        bool positionResult = PositionTest();
        bool oneSymbolResult = OneSymbolStringBWTTest();
        bool inverseBWTResult = InverseBWTTest();

        PrintTestResult("Long String Test", longStringBWTResult);
        PrintTestResult("Position Test", positionResult);
        PrintTestResult("One symbol Test", oneSymbolResult);
        PrintTestResult("Inverse BWT Test", inverseBWTResult);

        return longStringBWTResult && positionResult && oneSymbolResult && inverseBWTResult;
    }
}