namespace YatzyKata
{
    public class Tests
    {
        [Test]
        public void ChanceWillSumAllDice()
        {
            var roll = new List<int> { 1,2,3,4,5 };
            Assert.That(Yatzy.Score(roll, "CHANCE"), Is.EqualTo(1+2+3+4+5));
        }

        [Test]
        public void YatzyGivesFiftyPoints()
        {
            var roll = new List<int> { 1, 1, 1, 1, 1 };
            Assert.That(Yatzy.Score(roll, "YATZY"), Is.EqualTo(50));
        }

        [Test]
        public void NotAYatzyInYatzyGivesZeroPoints()
        {
            var roll = new List<int> { 1, 1, 1, 2, 1 };
            Assert.That(Yatzy.Score(roll, "YATZY"), Is.EqualTo(0));
        }

        [Test]
        public void OnesAddsUpTheOnes()
        {
            var roll = new List<int> { 1, 1, 3, 2, 1 };
            Assert.That(Yatzy.Score(roll, "ONES"), Is.EqualTo(3));
        }

        [Test]
        public void OnesAddsUpTheOnesV2()
        {
            var roll = new List<int> { 1, 1, 3, 1, 1 };
            Assert.That(Yatzy.Score(roll, "ONES"), Is.EqualTo(4));
        }
    }
}