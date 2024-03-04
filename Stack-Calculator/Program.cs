Console.WriteLine("Enter an expression:");
var enteredString = Console.ReadLine();
var stackCalculator = new StackCalculatorImplementation();
Console.WriteLine(stackCalculator.StackCalculator(enteredString));