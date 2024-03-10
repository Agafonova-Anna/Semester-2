public class Tests
{
    [Test]
    public void Calculate_WithTooManyNumbers_ShouldThrowArgumentException()
    {
        StackCalculator calculatorStackArray = new StackCalculator(new StackArray());

        Assert.Throws<ArgumentException>(() => calculatorStackArray.Calculate("5 5 5 5 +"));
    }

    [Test]
    public void Calculate_WithTooManyOperations_ShouldThrowArgumentException()
    {
        StackCalculator calculatorStackList = new StackCalculator(new StackList());

        Assert.Throws<ArgumentException>(() => calculatorStackList.Calculate("5 + + +"));
    }

    [Test]
    public void Calculate_WithDivisionByZeroExpression_ShouldThrowDivideByZeroException()
    {
        StackCalculator calculatorStackArray = new StackCalculator(new StackArray());

        Assert.Throws<DivideByZeroException>(() => calculatorStackArray.Calculate("0 2 /"));
    }

    [Test]
    public void Calculate_WithUsingOfInvalidOperation_ShouldThrowArgumentException()
    {
        StackCalculator calculatorStackArray = new StackCalculator(new StackArray());

        Assert.Throws<ArgumentException>(() => calculatorStackArray.Calculate(" 5 5 %"));
    }

    [Test]
    public void Calculate_WithUsingOfInvalidSymbols_ShouldThrowArgumentException()
    {
        StackCalculator calculatorStackList = new StackCalculator(new StackList());

        Assert.Throws<ArgumentException>(() => calculatorStackList.Calculate(" 5 f 5 + +"));
    }

    [Test]
    public void Calculate_WithEmptyString_ShouldThrowArgumentExeption()
    {
        StackCalculator calculatorStackList = new StackCalculator(new StackList());

        Assert.Throws<ArgumentException>(() => calculatorStackList.Calculate(""));
    }

    [TestCase("1 2 +", 3)]
    [TestCase("0 12345 +", 12345)]
    [TestCase("-3 -4 +", -7)]
    public void Calculate_WithAdditionExpression_ShouldReturnExpectedResult_StackArray(string expression, double expectedResult)
    {
        StackCalculator calculatorStackArray = new StackCalculator(new StackArray());
        float result;

        result = calculatorStackArray.Calculate(expression);

        Assert.That(expectedResult, Is.EqualTo(result));
    }

    [TestCase("-456 12 +", -444)]
    [TestCase("0 0 +", 0)]
    public void Calculate_WithAdditionExpression_ShouldReturnExpectedResult_StackList(string expression, double expectedResult)
    {
        StackCalculator calculatorStackArray = new StackCalculator(new StackList());
        float result;

        result = calculatorStackArray.Calculate(expression);

        Assert.That(expectedResult, Is.EqualTo(result));
    }

    [TestCase("1 2 -", 1)]
    [TestCase("-199 -1 -", 198)]
    public void Calculate_WithSubstractionExpression_ShouldReturnExpectedResult_StackArray(string expression, double expectedResult)
    {
        StackCalculator calculatorStackArray = new StackCalculator(new StackArray());
        float result;

        result = calculatorStackArray.Calculate(expression);

        Assert.That(expectedResult, Is.EqualTo(result));
    }

    [TestCase("-123 5 -", 128)]
    [TestCase("1439 0 -", -1439)]
    public void Calculate_WithSubstractionExpression_ShouldReturnExpectedResult_StackList(string expression, double expectedResult)
    {
        StackCalculator calculatorStackArray = new StackCalculator(new StackList());
        float result;

        result = calculatorStackArray.Calculate(expression);

        Assert.That(expectedResult, Is.EqualTo(result));
    }

    [TestCase("0 2 *", 0)]
    [TestCase("3 2 *", 6)]
    public void Calculate_WithMultiplicationExpression_ShouldReturnExpectedResult_StackArray(string expression, double expectedResult)
    {
        StackCalculator calculatorStackArray = new StackCalculator(new StackArray());
        float result;

        result = calculatorStackArray.Calculate(expression);

        Assert.That(expectedResult, Is.EqualTo(result));
    }

    [TestCase("-25 3 *", -75)]
    [TestCase("-123 -2 *", 246)]
    public void Calculate_WithMultiplicationExpression_ShouldReturnExpectedResult_StackList(string expression, double expectedResult)
    {
        StackCalculator calculatorStackArray = new StackCalculator(new StackList());
        float result;

        result = calculatorStackArray.Calculate(expression);

        Assert.That(expectedResult, Is.EqualTo(result));
    }

    [TestCase("2 6 /", 3)]
    [TestCase("-3 -6 /", 2)]
    [TestCase("4 6 /", 1.5)]
    public void Calculate_WithDivisionExpression_ShouldReturnExpectedResult_StackArray(string expression, double expectedResult)
    {
        StackCalculator calculatorStackArray = new StackCalculator(new StackArray());
        float result;

        result = calculatorStackArray.Calculate(expression);

        Assert.That(expectedResult, Is.EqualTo(result));
    }

    [TestCase("11 121 /", 11)]
    [TestCase("15 -255 /", -17)]
    [TestCase("2 0 /", 0)]
    public void Calculate_WithDivisionExpression_ShouldReturnExpectedResult_StackList(string expression, double expectedResult)
    {
        StackCalculator calculatorStackArray = new StackCalculator(new StackList());
        float result;

        result = calculatorStackArray.Calculate(expression);

        Assert.That(expectedResult, Is.EqualTo(result));
    }

    [TestCase("1 2 3 4 5 + + * -", 23)]
    [TestCase("2 128 -57 1024 - * /", 69184)]
    public void Calculate_WithDifferentOperations_ShouldReturnExpectedResult_StackArray(string expression, double expectedResult)
    {
        StackCalculator calculatorStackArray = new StackCalculator(new StackArray());
        float result;

        result = calculatorStackArray.Calculate(expression);

        Assert.That(expectedResult, Is.EqualTo(result));
    }

    [TestCase("11 243 -3 54 5 + + * -", 13597)]
    [TestCase("1 2 2 2 5 - / * /", 3)]
    public void Calculate_WithDifferentOperations_ShouldReturnExpectedResult_StackList(string expression, double expectedResult)
    {
        StackCalculator calculatorStackArray = new StackCalculator(new StackList());
        float result;

        result = calculatorStackArray.Calculate(expression);

        Assert.That(expectedResult, Is.EqualTo(result));
    }
}