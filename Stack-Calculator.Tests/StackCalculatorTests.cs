public class Tests
{
    private StackCalculatorImplementation stackCalculator;
    [SetUp]
    public void Setup()
    {
        stackCalculator = new StackCalculatorImplementation();
    }

    [Test]
    public void TestDivisionByZeroExeption()
    {
        Assert.Throws<DivideByZeroException>(() => stackCalculator.StackCalculator("0 2 /"));
    }

    [Test]
    public void TestEmptyStringStackExeptionCalculator()
    {
        Assert.Throws<ArgumentException>(() => stackCalculator.StackCalculator(""));
    }

    [Test]
    public void TestInvalidValueExeptionStackCalculator()
    {
        Assert.Throws<ArgumentException>(() => stackCalculator.StackCalculator("dfg ! 3 &"));
    }

    [Test]
    public void TestAddition()
    {
        Assert.That(3, Is.EqualTo(stackCalculator.StackCalculator("1 2 +")));
        Assert.That(12345, Is.EqualTo(stackCalculator.StackCalculator("0 12345 +")));
        Assert.That(-7, Is.EqualTo(stackCalculator.StackCalculator("-3 -4 +")));
        Assert.That(-444, Is.EqualTo(stackCalculator.StackCalculator("-456 12 +")));
        Assert.That(0, Is.EqualTo(stackCalculator.StackCalculator("0 0 +")));
    }

    [Test]
    public void TestSubtraction()
    {
        Assert.That(1, Is.EqualTo(stackCalculator.StackCalculator("1 2 -")));
        Assert.That(198, Is.EqualTo(stackCalculator.StackCalculator("-199 -1 -")));
        Assert.That(128, Is.EqualTo(stackCalculator.StackCalculator("-123 5 -")));
        Assert.That(-1439, Is.EqualTo(stackCalculator.StackCalculator("1439 0 -")));
    }

    [Test]
    public void TestMultiplication()
    {
        Assert.That(0, Is.EqualTo(stackCalculator.StackCalculator("0 2 *")));
        Assert.That(6, Is.EqualTo(stackCalculator.StackCalculator("2 3 *")));
        Assert.That(-75, Is.EqualTo(stackCalculator.StackCalculator("-25 3 *")));
        Assert.That(246, Is.EqualTo(stackCalculator.StackCalculator("-123 -2 *")));
    }

    [Test]
    public void TestDivision()
    {
        Assert.That(3, Is.EqualTo(stackCalculator.StackCalculator("2 6 /")));
        Assert.That(2, Is.EqualTo(stackCalculator.StackCalculator("-3 -6 /")));
        Assert.That(-6, Is.EqualTo(stackCalculator.StackCalculator("111 -666 /")));
        Assert.That(1.5, Is.EqualTo(stackCalculator.StackCalculator("4 6 /")));
    }

    [Test]
    public void TestCombiningSigns()
    {
        Assert.That(23, Is.EqualTo(stackCalculator.StackCalculator("1 2 3 4 5 + + * -")));
        Assert.That(69184, Is.EqualTo(stackCalculator.StackCalculator("2 128 -57 1024 - * /")));
    }
}