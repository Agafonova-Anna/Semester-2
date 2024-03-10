/// <summary>
/// A stack-based calculator that receives a string in reverse Polish notation.
/// </summary>
public class StackCalculator
{
    private IStack stack;

    /// <summary>
    /// Initializes a new instance of the <see cref="StackCalculator"/> class.
    /// </summary>
    /// <param name="stack">Preferred stack implementation.</param>
    public StackCalculator(IStack stack)
    {
        this.stack = stack;
    }

    /// <summary>
    /// a calculator that calculates the value of an expression written as a reverse Polish notation.
    /// </summary>
    /// <param name="enteredString">a string of numbers and signs (first numbers, then signs) in reverse Polish notation.</param>
    /// <returns>the resualt of calculations.</returns>
    /// <exception cref="ArgumentException">is thrown after the user has entered an empty string.</exception>
    /// <exception cref="ArgumentException">is thrown after the user has invalid string.</exception>
    public float Calculate(string enteredString)
    {
        ArgumentException.ThrowIfNullOrEmpty(enteredString);

        var enteredStringArray = enteredString.Split();

        var numberOfNumbers = PerformOperations(enteredStringArray);

        if (numberOfNumbers != 1)
        {
            throw new ArgumentException("Invalid input");
        }

        return stack.Pop();
    }

    private int PerformOperations(string[] enteredStringArray)
    {
        var numberOfNumbers = 0;
        foreach (var element in enteredStringArray)
        {
            if (float.TryParse(element, out var number))
            {
                stack.Push(number);
                ++numberOfNumbers;
            }
            else
            {
                if (numberOfNumbers < 2 )
                {
                    return -1;
                }

                switch (element)
                {
                    case "+":
                        {
                            Add();
                            --numberOfNumbers;
                            break;
                        }

                    case "-":
                        {
                            Substract();
                            --numberOfNumbers;
                            break;
                        }

                    case "*":
                        {
                            Multiply();
                            --numberOfNumbers;
                            break;
                        }

                    case "/":
                        {
                            Divide();
                            --numberOfNumbers;
                            break;
                        }

                    default:
                        {
                            throw new ArgumentException("Invalid input");
                        }
                }
            }
        }

        return numberOfNumbers;
    }

    private void Add() => stack.Push(stack.Pop() + stack.Pop());

    private void Substract() => stack.Push(stack.Pop() - stack.Pop());

    private void Multiply() => stack.Push(stack.Pop() * stack.Pop());

    private void Divide()
    {
        float firstNumber = stack.Pop();
        float secondNumber = stack.Pop();
        if (Math.Abs(secondNumber) < 1e-9)
        {
            throw new DivideByZeroException("Attempt to divide by zero");
        }

        var operationResult = firstNumber / secondNumber;
        stack.Push(operationResult);
    }
}