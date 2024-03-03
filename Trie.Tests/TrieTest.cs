public class Tests
{
    public Trie trie;

    [SetUp]
    public void Setup()
    {
        trie = new Trie();
    }

    [Test]
    public void ContainsWordPresentReturnsTrue()
    {
        trie.Add("word");

        Assert.IsTrue(trie.Contains("word"));
    }

    [Test]
    public void ContainsWordNotPresentedReturnFalse()
    {
        Assert.IsFalse(trie.Contains("cat"));
    }

    [Test]
    public void RemoveExistingWord()
    {
        trie.Add("dog");
        trie.Remove("dog");

        Assert.IsFalse(trie.Contains("dog"));
    }

    [Test]
    public void RemoveNonExistingWord()
    {
        trie.Add("cat");

        Assert.IsFalse(trie.Remove("dog"));
    }

    [Test]
    public void HowManyStartsWithPrefixNoWordsWithSuchPrefix()
    {
        trie.Add("dog");
        trie.Add("apple");

        Assert.That(trie.HowManyStartsWithPrefix("and"), Is.EqualTo(0));

    }

    [Test]
    public void HowManyStartsWithPrefixWordsExist()
    {
        trie.Add("and");
        trie.Add("ant");
        trie.Add("cat");

        Assert.That(trie.HowManyStartsWithPrefix("an"), Is.EqualTo(2));
    }

    [Test]
    public void HowManyStartsWithPrefixPrefixIsTheWholeWord()
    {
        trie.Add("cookie");
        trie.Add("coffee");
        Assert.That(trie.HowManyStartsWithPrefix("coffee"), Is.EqualTo(1));
    }

    [Test]
    public void SizeIfOnlyAdd()
    {
        trie.Add("dog");
        trie.Add("cat");

        Assert.That(trie.size, Is.EqualTo(2));
    }

    [Test]
    public void SizeIfAddAndRemove()
    {
        trie.Add("apple");
        trie.Add("car");
        trie.Add("dog");
        trie.Remove("apple");

        Assert.That(trie.size, Is.EqualTo(2));
    }

    [Test]
    public void AddEmptyStringThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => trie.Add(""));
    }

    [Test]
    public void ContainsEmptyStringThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => trie.Add(""));
    }

    public void RemoveEmptyStringThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => trie.Add(""));
    }
}