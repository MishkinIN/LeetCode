using NUnit.Framework;
using LeetCode;

namespace LeecCode.Test
{
    public class UnitTestWordDictionary {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WordDictionary() {
            var dic = new WordDictionary();
        }

        [Test]
        public void AddWords() {
            var dic = new WordDictionary();
            dic.AddWord("bad");
            dic.AddWord("bad");
            dic.AddWord("mad");
            dic.AddWord("dad");
            dic.AddWord("pad");
            dic.AddWord("bad");
        }

        [Test]
        public void Search() {
            var dic = new WordDictionary();
            dic.AddWord("bad");
            dic.AddWord("bad");
            dic.AddWord("mad");
            dic.AddWord("dad");
            dic.AddWord("pad");
            dic.AddWord("banana");
            Assert.IsFalse(dic.Search(""));
            Assert.IsTrue(dic.Search(".ad"));
            Assert.IsTrue(dic.Search("dad"));
            Assert.IsTrue(dic.Search("....n."));
            Assert.IsTrue(dic.Search("..."));
            Assert.IsTrue(dic.Search("ma."));
            Assert.IsTrue(dic.Search("b.d"));
            Assert.IsFalse(dic.Search("gold"));
            Assert.IsFalse(dic.Search("gold"));
            Assert.IsFalse(dic.Search("...a."));

        }

    }
}