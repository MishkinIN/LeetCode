using NUnit.Framework;
using LeetCode;

namespace LeecCode.Test {
    public class UnitTestWinnerGame {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void WinnerSquareGame() {
            // 2,5,7,10,12,15,17,20,22,34,39,44,52,57,62,65,67,72,85,89,95,
            // 2,5,7,10,12,15,17,20,22,29,34,39,44,52,57,62,67,72,
            // 2,5,7,10,12,15,17,20,22,34,39,44,52,57,62,65,67,72,85,95,109,119,124,127,130,132,137,142,147,150,170,177,180,182,187,192,197,204,210,215,238,243,249,255,257,260,262,267,272,275,312,317,322,327,332,335,340,345,350,369,377,390,392,397,
            // 2,5,7,10,12,15,17,20,22,34,39,44,52,57,62,65,67,72,85,95,109,119,124,127,130,132,137,142,147,150,170,177,180,182,187,192,197,204,210,215,238,243,249,255,257,260,262,267,272,275,312,317,322,327,332,335,340,345,350,369,377,390,392,397,425,430,437,442,447,449,464,502,507,510,512,515,517,520,522,
       
            Assert.IsTrue(Solution.WinnerSquareGame(29));
            Assert.IsTrue(Solution.WinnerSquareGame(410));
            Assert.IsFalse(Solution.WinnerSquareGame(554));
            Assert.IsTrue(Solution.WinnerSquareGame(49));
            Assert.IsFalse(Solution.WinnerSquareGame(85));
            Assert.IsFalse(Solution.WinnerSquareGame(72));
            Assert.IsFalse(Solution.WinnerSquareGame(67));
            Assert.IsFalse(Solution.WinnerSquareGame(65));
            Assert.IsFalse(Solution.WinnerSquareGame(62));
            Assert.IsFalse(Solution.WinnerSquareGame(57));
            Assert.IsFalse(Solution.WinnerSquareGame(52));
            Assert.IsFalse(Solution.WinnerSquareGame(44));
            Assert.IsFalse(Solution.WinnerSquareGame(39));
            Assert.IsFalse(Solution.WinnerSquareGame(34));
            Assert.IsFalse(Solution.WinnerSquareGame(22));
            Assert.IsTrue(Solution.WinnerSquareGame(33));

            Assert.IsTrue(Solution.WinnerSquareGame(99));
            Assert.IsTrue(Solution.WinnerSquareGame(18));
            Assert.IsTrue(Solution.WinnerSquareGame(19));
            Assert.IsFalse(Solution.WinnerSquareGame(20));
            Assert.IsTrue(Solution.WinnerSquareGame(21));
            Assert.IsFalse(Solution.WinnerSquareGame(22));
            Assert.IsTrue(Solution.WinnerSquareGame(23));
            Assert.IsTrue(Solution.WinnerSquareGame(24));
            Assert.IsTrue(Solution.WinnerSquareGame(25));
            Assert.IsTrue(Solution.WinnerSquareGame(26));
             Assert.IsTrue(Solution.WinnerSquareGame(27));
            Assert.IsTrue(Solution.WinnerSquareGame(28));
             Assert.IsFalse(Solution.WinnerSquareGame(44));
      }

    }
}