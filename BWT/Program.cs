Console.WriteLine("Choose an option:");
Console.WriteLine("If you want to perform a Burroughs Wheeler transformation, enter 1");
Console.WriteLine("If you want to perform an Inverse Burrows Wheeler Transform, enter 2");

string enteredSymbol;
int option;
bool exit;
do
{
    Console.WriteLine("Enter the digit:");
    enteredSymbol = Console.ReadLine();
    if (!int.TryParse(enteredSymbol, out option))
    {
        throw new ArgumentException("Invalid value");
    }

    switch (option)
    {
        case 1:
            {
                Console.WriteLine("Enter the word:");
                var enteredString = Console.ReadLine();
                var transformedString = BurrowsWheelerTransformMethods.BurrowsWheelerTransform(enteredString);
                var position = BurrowsWheelerTransformMethods.Position(enteredString);
                Console.WriteLine($"Output: {transformedString}");
                Console.WriteLine($"Position: {position}");
                break;
            }

        case 2:
            {
                Console.WriteLine("Enter the word:");
                var transformedString = Console.ReadLine();

                Console.WriteLine("Enter the position:");
                var positionString = Console.ReadLine();
                var position = int.Parse(positionString);
                var originalString = BurrowsWheelerTransformMethods.InverseBWT(transformedString, position);
                Console.WriteLine($"Original string: {originalString}");
                break;
            }

        default:
            {
                Console.WriteLine("Invalid value");
                break;
            }
    }

    Console.WriteLine("Do you want to exit?");
    Console.WriteLine("(Enter 'yes' or 'no')");
    enteredSymbol = Console.ReadLine();
    switch (enteredSymbol)
    {
        case "yes":
            {
                exit = true;
                break;
            }

        case "no":
            {
                exit = false;
                break;
            }

        default:
            {
                Console.WriteLine("Invalid value");
                exit = true;
                break;
            }
    }
}
while (!exit);