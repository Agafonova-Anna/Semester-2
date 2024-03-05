public class Tests
{
    [Test]
    public void TestBurrowsWheelerTransformEmptyStringExeption()
    {
        Assert.Throws<ArgumentException>(() => BurrowsWheelerTransformMethods.BurrowsWheelerTransform(""));
    }

    [Test]
    public void TestInverseBWTEmptyStringExeption()
    {
        Assert.Throws<ArgumentException>(() => BurrowsWheelerTransformMethods.InverseBWT("", 2));
    }

    [Test]
    public void TestPositionEmptyStringExeption()
    {
        Assert.Throws<ArgumentException>(() => BurrowsWheelerTransformMethods.Position(""));
    }

    [Test]
    public void TestInverseBWTNegativePositionValueExeption()
    {
        Assert.Throws<ArgumentException>(() => BurrowsWheelerTransformMethods.InverseBWT("g", -1));
    }

    [Test]
    public void TestBurrowsWheelerTransformLongStringReturnsExpectedResult()
    {
        string result = BurrowsWheelerTransformMethods.BurrowsWheelerTransform("gfjkgzsngklnsnmksfnmfgngfgff$");
        Assert.That(result, Is.EqualTo("ffggmgsfn$nfkfjgmknngsfslkzng"));
    }

    [Test]
    public void TestPositionExpectedResult()
    {
        Assert.That(2, Is.EqualTo(BurrowsWheelerTransformMethods.Position("колокол$")));
    }

    [Test]
    public void TestBurrowsWheelerTransformOneSymbol() 
    {
        Assert.That("g", Is.EqualTo(BurrowsWheelerTransformMethods.BurrowsWheelerTransform("g")));
    }

    [Test]
    public void TestInverseBWTExpectedResult()
    {
        Assert.That("колокол$", Is.EqualTo(BurrowsWheelerTransformMethods.InverseBWT("ло$оолкк", 2)));
    }

    [Test]
    public void TestInverseBWTOneSymbol()
    {
        Assert.That("g", Is.EqualTo(BurrowsWheelerTransformMethods.InverseBWT("g", 0)));
    }

    [Test]
    public void TestPositionOneSymbol()
    {
        Assert.That(0, Is.EqualTo(BurrowsWheelerTransformMethods.Position("g")));
    }

    [Test]
    public void TestBurrowsWheelerTransformRepeatedCharacters()
    {
        Assert.That("aaaaaaaaaa$", Is.EqualTo(BurrowsWheelerTransformMethods.BurrowsWheelerTransform("aaaaaaaaaa$")));
    }

    [Test]
    public void TestInverseBWTRepeatedCharacters()
    {
        Assert.That("aaaaaaaaaa$", Is.EqualTo(BurrowsWheelerTransformMethods.InverseBWT("aaaaaaaaaa$", 10)));
    }

    [Test]
    public void TestPositionRepeatedCharacters()
    {
        Assert.That(10, Is.EqualTo(BurrowsWheelerTransformMethods.Position("aaaaaaaaaa$")));
    }

    [Test]
    public void TestPalindromeStringBWT()
    {
        Assert.That("mmdaa$", Is.EqualTo(BurrowsWheelerTransformMethods.BurrowsWheelerTransform("madam$")));
    }

    [Test]
    public void TestPalindromeStringInverseBWT()
    {
        Assert.That("madam$", Is.EqualTo(BurrowsWheelerTransformMethods.InverseBWT("mmdaa$", 5)));
    }

    [Test]
    public void TestPalindromeStringPosition()
    {
        Assert.That(5, Is.EqualTo(BurrowsWheelerTransformMethods.Position("madam$")));
    }

    [Test]
    public void TestBWTSpacesAsArgument()
    {
        Assert.That("$  ", Is.EqualTo(BurrowsWheelerTransformMethods.BurrowsWheelerTransform("  $")));
    }

    [Test]
    public void TestPositionSpacesAsArgument()
    {
        Assert.That(0, Is.EqualTo(BurrowsWheelerTransformMethods.Position("  $")));
    }

    [Test]
    public void TestInverseBWTSpacesAsArgument()
    {
        Assert.That("  $", Is.EqualTo(BurrowsWheelerTransformMethods.InverseBWT("$  ", 0)));
    }
}

