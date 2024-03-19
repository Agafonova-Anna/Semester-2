
/// <summary>
/// This class is used to describe a trie.
/// </summary>
public class Trie
{
    private TrieNode root = new TrieNode();

    /// <summary>
    /// Gets or sets the size of the trie.
    /// </summary>
    public ushort Size { get; set; }

    /// <summary>
    /// Inserts elements into the tree.
    /// </summary>
    /// <param name="element">A string that should be added into the trie.</param>
    /// <param name="code">The code of that particular string. </param>
    /// <returns>True if the element was successfully added, false if it is already present.</returns>
    public bool Add(string element, ushort code)
    {
        ArgumentException.ThrowIfNullOrEmpty(element);

        int level;
        int length = element.Length;
        int index;

        TrieNode currentNode = this.root;

        for (level = 0; level < length; level++)
        {
            index = (int)element[level];
            if (currentNode.children[index] == null)
            {
                currentNode.children[index] = new TrieNode();
            }

            currentNode = currentNode.children[index];
        }

        if (!currentNode.terminate)
        {
            currentNode.terminate = true;
            currentNode.code = code;
            Size++;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Checks whether the string is present in the trie.
    /// </summary>
    /// <param name="element">The string to be found.</param>
    /// <returns>True if it is present, false if it is not.</returns>
    public bool Contains(string element)
    {
        ArgumentException.ThrowIfNullOrEmpty(element);

        int level = 0;
        int length = element.Length;
        int index;

        TrieNode? currentNode = this.root;

        for (level = 0; level < length; level++)
        {
            index = (int)element[level];

            if (currentNode.children[index] == null)
            {
                return false;
            }

            currentNode = currentNode.children[index];
        }

        return currentNode.terminate;
    }

    /// <summary>
    /// Finds the code of an element in the trie.
    /// </summary>
    /// <param name="word">The string whose code should be found.</param>
    /// <returns>The code of the word.</returns>
    public ushort? GetCode(string word)
    {
        int level = 0;
        int length = word.Length;
        int index;

        TrieNode? currentNode = root;

        for (level = 0; level < length; level++)
        {
            index = word[level];

            if (currentNode.children[index] == null)
            {
                return null;
            }

            currentNode = currentNode.children[index];
        }

        return currentNode.code;
    }
}