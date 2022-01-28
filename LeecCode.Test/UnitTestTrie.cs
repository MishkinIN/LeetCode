using NUnit.Framework;
using LeetCode;

namespace LeecCode.Test
{
    public class UnitTestTrie
    {
        [Test]
        public void Trie()
        {
            var trie = new Trie();
          
        }
        [Test]
        
        public void Insert() {
            var trie = new Trie();
            trie.Insert("apple");
            trie.Insert("apple");
            trie.Insert("book");
            trie.Insert("zerro");
            trie.Insert("a");
            Assert.AreEqual(4, trie.Count);
        }
        [Test]
        public void Search() {
            var trie = new Trie();
            trie.Insert("apple");
            trie.Insert("apple");
            trie.Insert("book");
            trie.Insert("zerro");
            trie.Insert("a");

            Assert.IsTrue( trie.Search("apple"));
            Assert.IsFalse(trie.Search("app"));
            Assert.IsTrue(trie.Search("a"));
            Assert.IsTrue(trie.Search("book"));

        }
        [Test]
        public void StartsWith() {
            var trie = new Trie();
            trie.Insert("apple");
            trie.Insert("book");
            trie.Insert("zerro");
            trie.Insert("a");
            Assert.IsTrue(trie.StartsWith("app"));
            Assert.IsTrue(trie.StartsWith("ze"));
            Assert.IsTrue(trie.StartsWith("book"));
            Assert.IsTrue(trie.StartsWith("a"));
            Assert.IsFalse(trie.StartsWith("no"));

        }

    }
}