namespace YatzyKata
{
    // using mob tool
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

        [Test]
        public void TwosAddsUpTheTwos()
        {
            var roll = new List<int> { 2, 1, 3, 2, 2 };
            Assert.That(Yatzy.Score(roll, "TWOS"), Is.EqualTo(6));
        }

        [Test]
        public void ThreesAddsUpTheThrees()
        {
            var roll = new List<int> { 2, 1, 3, 3, 2 };
            Assert.That(Yatzy.Score(roll, "THREES"), Is.EqualTo(6));
        }

        [Test]
        public void OtherNumberCategories()
        {
            var roll = new List<int> { 4, 4, 5, 6, 6 };
            Assert.That(Yatzy.Score(roll, "FOURS"), Is.EqualTo(8));
            Assert.That(Yatzy.Score(roll, "FIVES"), Is.EqualTo(5));
            Assert.That(Yatzy.Score(roll, "SIXES"), Is.EqualTo(12));
            Assert.That(Yatzy.Score(roll, "THREES"), Is.EqualTo(0));
        }

        [Test]
        public void OnePairGetScoredCorrectly()
        {
            var roll = new List<int> { 2, 1, 4, 3, 2 };
            Assert.That(Yatzy.Score(roll, "PAIR"), Is.EqualTo(4));
        }

        [Test]
        public void OnePairGetScoredCorrectlyWhenThereAreTwoPairs()
        {
            var roll = new List<int> { 2, 1, 6, 6, 2 };
            Assert.That(Yatzy.Score(roll, "PAIR"), Is.EqualTo(12));
        }

        [Test]
        public void OnePairGetScoredCorrectlyWhenThereAreNoPairs()
        {
            var roll = new List<int> { 1, 2, 3, 4, 5 };
            Assert.That(Yatzy.Score(roll, "PAIR"), Is.EqualTo(0));
        }
    }
}