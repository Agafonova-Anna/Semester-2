/// <summary>
/// This class is used to describe a trie.
/// </summary>
public class Trie
{
    private TrieNode root = new TrieNode();
    public int size = 0;

    /// <summary>
    /// This method adds words into Trie.
    /// </summary>
    /// <param name="element">Entered word.</param>
    /// <returns>true if entered word is new and false if it's not.</returns>
    /// <exception cref="ArgumentException">Thrown when the argument "element" is null or empty.</exception>
    public bool Add(string element)
    {
        ArgumentException.ThrowIfNullOrEmpty(element);

        int level;
        int length = element.Length;
        int index;

        TrieNode currentNode = this.root;

        for (level = 0; level < length; level++)
        {
            index = element[level] - 'a';
            if (currentNode.children[index] == null)
            {
                currentNode.children[index] = new TrieNode();
            }

            currentNode = currentNode.children[index];
        }

        if (!currentNode.terminate)
        {
            currentNode.terminate = true;
            this.size++;
            return true;
        }

        return false;
    }

    /// <summary>
    /// This method is used to search for the entered word in the Trie.
    /// </summary>
    /// <param name="element">The word you want to find.</param>
    /// <returns>true if the Trie contains the word,false if it doesn't.</returns>
    /// <exception cref="ArgumentException">Thrown when the argument "element" is null or empty.</exception>
    public bool Contains(string element)
    {
        ArgumentException.ThrowIfNullOrEmpty(element);

        int level = 0;
        int length = element.Length;
        int index;

        TrieNode? currentNode = this.root;

        for (level = 0; level < length; level++)
        {
            index = element[level] - 'a';

            if (currentNode.children[index] == null)
            {
                return false;
            }

            currentNode = currentNode.children[index];
        }

        return currentNode.terminate;
    }

    /// <summary>
    /// This method removes entered word
    /// </summary>
    /// <param name="element">word that a user wants to remove</param>
    /// <returns>true if entered word presented in the Trie, false if it didn't </returns>
    /// <exception cref="ArgumentException">Thrown when the argument "element" is null or empty.</exception>
    public bool Remove(string element)
    {
        ArgumentException.ThrowIfNullOrEmpty(element);

        if (!this.Contains(element))
        {
            return false;
        }

        if (this.root == null)
        {
            Console.WriteLine("The trie is empty");
            return false;
        }

        this.AuxiliaryMethodForDeletingWord(root, 0, element);
        this.size--;
        return true;
    }

    /// <summary>
    /// This method counts the number of words in the Trie that starts with an entered prefix.
    /// </summary>
    /// <param name="prefix">The prefix for which the user wants to count the number of words starting with it.</param>
    /// <returns>The number of words in the Trie that starts with an entered prefix.</returns>
    /// <exception cref="ArgumentException">Thrown when the argument "prefix" is null or empty.</exception>
    public int HowManyStartsWithPrefix(string prefix)
    {
        ArgumentException.ThrowIfNullOrEmpty(prefix);

        int count = 0;
        int level = 0;
        int length = prefix.Length;
        int index;

        TrieNode? currentNode = this.root;

        for (level = 0; level < length; level++)
        {
            index = prefix[level] - 'a';

            if (currentNode.children[index] == null)
            {
                return 0;
            }

            currentNode = currentNode.children[index];
        }

        if (currentNode.terminate)
        {
            count++;
        }

        count += this.NumberOfChildren(currentNode);

        return count;
    }

    /// <summary>
    /// This method is used to determine whether a node has child elements.
    /// </summary>
    /// <param name="node">The node that should be checked.</param>
    /// <returns>true if the node has children, false if it doesn't. </returns>
    private bool IsEmpty(TrieNode node)
    {
        for (int i = 0; i < node.children.Length; i++)
        {
            if (node.children[i] != null)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// This method is used to find the last node of an element.
    /// </summary>
    /// <param name="element">the word which last node should be found.</param>
    /// <returns>node if this word presents in Trie, null if it doesn't.</returns>
    private TrieNode? LastNode(string element)
    {
        TrieNode? node = this.root;

        int index;
        int length = element.Length;
        int level;

        for (level = 0; level < length; level++)
        {
            index = element[level] - 'a';

            if (node.children[index] == null)
            {
                return null;
            }

            node = node.children[index];
        }

        if (node.terminate)
        {
            return node;
        }

        return null;
    }

    /// <summary>
    /// This method should be called in the Remove method; it deletes the entered word.
    /// </summary>
    /// <param name="root">A root of a trie.</param>
    /// <param name="level">The number of the letter in the word that is being deleted.</param>
    /// <param name="element">The word that a user wants to remove. </param>
    /// <returns>Root if the remaining trie value is not empty, null if it is empty.</returns>
    private TrieNode? AuxiliaryMethodForDeletingWord(TrieNode? root, int level, string element)
    {
        if (root == null)
        {
            return null;
        }

        if (level == element.Length)
        {
            if (root.terminate)
            {
                root.terminate = false;
            }

            if (this.IsEmpty(root))
            {
                root = null;
            }

            return root;
        }

        int index = element[level] - 'a';

        root.children[index] = this.AuxiliaryMethodForDeletingWord(root.children[index], level + 1, element);

        if (this.IsEmpty(root) && !root.terminate)
        {
            root = null;
        }

        return root;
    }

    private int NumberOfChildren(TrieNode node)
    {
        int count = 0;

        foreach (var child in node.children)
        {
            if (child != null)
            {
                count++;
            }
        }

        return count;
    }
}