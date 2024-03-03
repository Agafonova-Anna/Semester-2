TrieNode root;
Trie trie = new Trie();
Console.WriteLine("Choose an option:");
Console.WriteLine("If you want to add the element, enter 1");
Console.WriteLine("If you want to find the element, enter 2");
Console.WriteLine("If you want to remove the element, enter 3");
Console.WriteLine("If you want to know how many elements start with the prefix you entered, enter 4");
Console.WriteLine("If you want to know how many elements are in a Trie, enter 5.");

int option;
string enteredWord;
bool exit;
do
{
    Console.WriteLine("Enter the digit:");
    enteredWord = Console.ReadLine();
    if (!int.TryParse(enteredWord, out option))
    {
        throw new ArgumentException("Invalid value");
    }

    switch (option)
    {
        case 1:
            {
                Console.WriteLine("Enter the word");
                enteredWord = Console.ReadLine();
                if (trie.Add(enteredWord))
                {
                    Console.WriteLine("Added successfully");
                }
                else
                {
                    Console.WriteLine("This word already exists in the Trie");
                }

                break;
            }

        case 2:
            {
                Console.WriteLine("Enter the word");
                enteredWord = Console.ReadLine();
                if (trie.Contains(enteredWord))
                {
                    Console.WriteLine($"The word {enteredWord} has been foud");
                }
                else
                {
                    Console.WriteLine("There's no such word in the Trie");
                }

                break;
            }

        case 3:
            {
                Console.WriteLine("Enter the word");
                enteredWord = Console.ReadLine();
                if (trie.Remove(enteredWord))
                {
                    Console.WriteLine($"The word {enteredWord} has been removed from the Trie");
                }
                else
                {
                    Console.WriteLine("There's no such word in the Trie");
                }

                break;
            }

        case 4:
            {
                Console.WriteLine("Enter the prefix");
                enteredWord = Console.ReadLine();
                Console.WriteLine($"There're {trie.HowManyStartsWithPrefix(enteredWord)} having that prefix");

                break;
            }

        case 5:
            {
                Console.WriteLine($"There're {trie.size} word(s) in the Trie");
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
    enteredWord = Console.ReadLine();
    switch (enteredWord)
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

} while (!exit);