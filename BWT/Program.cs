
if (!Tests.TestResult())
{
    Console.WriteLine("Eror!");
}

Console.WriteLine("Enter a string:");
var enteredString = Console.ReadLine();

var transformedString = BurrowsWheelerTransformMethods.BurrowsWheelerTransform(enteredString);
var position = BurrowsWheelerTransformMethods.Position(BurrowsWheelerTransformMethods.GetInitialSuffixArray(enteredString), enteredString);
var originalString = BurrowsWheelerTransformMethods.InverseBWT(transformedString, position);

Console.WriteLine($"Output: {transformedString}");
Console.WriteLine($"Position: {position}");
Console.WriteLine($"Original string: {originalString}");

