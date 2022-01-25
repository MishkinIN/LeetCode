using NUnit.Framework;
using LeetCode;

namespace LeecCode.Test
{
    public class UnitTestNode
    {
        [Test]
        public void TestConnect()
        {
            Node node;
            node = Node.Create(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            Node node1 = Node.Connect(node);
            Assert.AreSame(null, node1.right.next);
            Assert.AreSame(node1.left.next, node1.right);
            Assert.AreSame(node1.right.left.next, node1.right.right);
            Assert.AreSame(node1.left.right.next, node1.right.left);
        }

    }
}
