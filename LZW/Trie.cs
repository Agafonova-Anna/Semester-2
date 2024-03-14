
/// <summary>
/// This class is used to describe a trie.
/// </summary>
public class Trie
{
    private TrieNode root = new TrieNode();
    public int size = 0;
    public bool Add(string element, int code)
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
            this.size++;
            return true;
        }

        return false;
    }

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

    public int GetCode(string word)
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
                return -1;
            }

            currentNode = currentNode.children[index];
        }

        return currentNode.code;
    }
}