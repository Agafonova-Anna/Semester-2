Console.WriteLine("Enter an expression:");
var enteredString = Console.ReadLine();
var stackCalculator = new StackCalculator(new StackArray());
Console.WriteLine(stackCalculator.Calculate(enteredString));