/// <summary>
/// A stack-based calculator that receives a string in reverse Polish notation.
/// </summary>
public class StackCalculatorImplementation
{
    private IStack stack = new StackArray();

    /// <summary>
    /// a calculator that calculates the value of an expression written as a reverse Polish notation.
    /// </summary>
    /// <param name="enteredString">a string of numbers and signs (first numbers, then signs) in reverse Polish notation.</param>
    /// <returns>the resualt of calculations.</returns>
    /// <exception cref="DivideByZeroException">is thrown when an attempt is made to divide by zero.</exception>
    /// <exception cref="ArgumentException">is thrown after the user has entered an invalid string.</exception>
    /// <exception cref="ArgumentException">is thrown after the user has entered an empty string.</exception>
    public float StackCalculator(string enteredString)
    {
        ArgumentException.ThrowIfNullOrEmpty(enteredString);

        float operationResult = 0;
        var enteredStringArray = enteredString.Split(' ');
        foreach (var element in enteredStringArray)
        {
            if (float.TryParse(element, out var number))
            {
                this.stack.Push(number);
            }
            else
            {
                switch (element)
                {
                    case "+":
                        {
                            operationResult = this.stack.Pop() + this.stack.Pop();
                            this.stack.Push(operationResult);
                            break;
                        }

                    case "-":
                        {
                            operationResult = this.stack.Pop() - this.stack.Pop();
                            this.stack.Push(operationResult);
                            break;
                        }

                    case "*":
                        {
                            operationResult = this.stack.Pop() * this.stack.Pop();
                            this.stack.Push(operationResult);
                            break;
                        }

                    case "/":
                        {
                            float firstNumber = this.stack.Pop();
                            float secondNumber = this.stack.Pop();
                            if (Math.Abs(secondNumber) < 1e-9)
                            {
                                throw new DivideByZeroException("Attempt to divide by zero");
                            }

                            operationResult = firstNumber / secondNumber;
                            this.stack.Push(operationResult);
                            break;
                        }

                    default:
                        {
                            throw new ArgumentException("Invalid argument value");
                        }
                }
            }
        }

        return operationResult;
    }
}