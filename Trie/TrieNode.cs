/// <summary>
/// This class is used to describe nodes of a Trie.
/// </summary>
public class TrieNode
{
    public TrieNode[] children = new TrieNode[26];
    public bool terminate;

    /// <summary>
    /// Initializes a new instance of the <see cref="TrieNode"/> class.
    /// This is a constuctor for TrieNode class.
    /// </summary>
    public TrieNode()
    {
        terminate = false;
        for (int i = 0; i < 26; i++)
        {
            children[i] = null;
        }
    }
}