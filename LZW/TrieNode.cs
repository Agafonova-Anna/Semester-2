
/// <summary>
/// This class is used to describe nodes of a Trie.
/// </summary>
public class TrieNode
{
    public int code;
    public TrieNode[] children;
    public bool terminate;

    public TrieNode()
    {
        code = 0;
        children = new TrieNode[256];
        terminate = false;
    }
}