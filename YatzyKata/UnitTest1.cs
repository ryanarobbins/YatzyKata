namespace YatzyKata
{
    // using mob tool
    public class Tests
    {
        [Test]
        public void ChanceWillSumAllDice()
        {
            var roll = new List<int> { 1, 2, 3, 4, 5 };
            var play = new Play(roll, ScoreCategory.Chance);
            Assert.That(Yatzy.Score(play), Is.EqualTo(1 + 2 + 3 + 4 + 5));
        }

        [Test]
        public void YatzyGivesFiftyPoints()
        {
            var roll = new List<int> { 1, 1, 1, 1, 1 };
            var play = new Play(roll, ScoreCategory.Yatzy);
            Assert.That(Yatzy.Score(play), Is.EqualTo(50));
        }

        [Test]
        public void NotAYatzyInYatzyGivesZeroPoints()
        {
            var roll = new List<int> { 1, 1, 1, 2, 1 };
            var play = new Play(roll, ScoreCategory.Yatzy);
            Assert.That(Yatzy.Score(play), Is.EqualTo(0));
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
            var play = new Play(roll, ScoreCategory.Ones);
            Assert.That(Yatzy.Score(play), Is.EqualTo(4));
        }

        [Test]
        public void TwosAddsUpTheTwos()
        {
            var roll = new List<int> { 2, 1, 3, 2, 2 };
            var play = new Play(roll, ScoreCategory.Twos);
            Assert.That(Yatzy.Score(play), Is.EqualTo(6));
        }

        [Test]
        public void ThreesAddsUpTheThrees()
        {
            var roll = new List<int> { 2, 1, 3, 3, 2 };
            var play = new Play(roll, ScoreCategory.Threes);
            Assert.That(Yatzy.Score(play), Is.EqualTo(6));
        }

        [Test]
        public void OtherNumberCategories()
        {
            var roll = new List<int> { 4, 4, 5, 6, 6 };
            Assert.That(Yatzy.Score(new Play(roll, ScoreCategory.Fours)), Is.EqualTo(8));
            Assert.That(Yatzy.Score(new Play(roll, ScoreCategory.Fives)), Is.EqualTo(5));
            Assert.That(Yatzy.Score(new Play(roll, ScoreCategory.Sixes)), Is.EqualTo(12));
            Assert.That(Yatzy.Score(new Play(roll, ScoreCategory.Threes)), Is.EqualTo(0));
        }

        [Test]
        public void OnePairGetScoredCorrectly()
        {
            var roll = new List<int> { 2, 1, 4, 3, 2 };
            var play = new Play(roll, ScoreCategory.Pair);
            Assert.That(Yatzy.Score(play), Is.EqualTo(4));
        }

        [Test]
        public void OnePairGetScoredCorrectlyWhenThereAreTwoPairs()
        {
            var roll = new List<int> { 2, 1, 6, 6, 2 };
            var play = new Play(roll, ScoreCategory.Pair);
            Assert.That(Yatzy.Score(play), Is.EqualTo(12));
        }

        [Test]
        public void OnePairGetScoredCorrectlyWhenThereAreNoPairs()
        {
            var roll = new List<int> { 1, 2, 3, 4, 5 };
            var play = new Play(roll, ScoreCategory.Pair);
            Assert.That(Yatzy.Score(play), Is.EqualTo(0));
        }

        [Test]
        public void ThreeOfAKindGetsScoredCorrectlyWhenThereIsNotThreeOfAKind()
        {
            var roll = new List<int> { 1, 1, 3, 4, 5 };
            var play = new Play(roll, ScoreCategory.ThreeOfAKind);
            Assert.That(Yatzy.Score(play), Is.EqualTo(0));
        }

        [Test]
        public void ThreeOfAKindGetsScoredCorrectlyWhenOneSetExists()
        {
            var roll = new List<int> { 1, 1, 1, 4, 5 };
            var play = new Play(roll, ScoreCategory.ThreeOfAKind);
            Assert.That(Yatzy.Score(play), Is.EqualTo(12));
        }

        [Test]
        public void FourOfAKindGetsScoredCorrectlyWhenThereIsNotFourOfAKind()
        {
            var roll = new List<int> { 1, 1, 1, 4, 5 };
            var play = new Play(roll, ScoreCategory.FourOfAKind);
            Assert.That(Yatzy.Score(play), Is.EqualTo(0));
        }

        [Test]
        public void FourOfAKindGetsScoredCorrectlyWhenOneSetExists()
        {
            var roll = new List<int> { 1, 1, 1, 1, 5 };
            var play = new Play(roll, ScoreCategory.FourOfAKind);
            Assert.That(Yatzy.Score(play), Is.EqualTo(9));
        }

        [Test]
        public void FullHouseWhenThereIsAFullHouse()
        {
            var roll = new List<int> { 1, 1, 1, 2, 2 };
            Assert.That(Yatzy.Score(roll, "FULLHOUSE"), Is.EqualTo(25));
        }

        [Test]
        public void FullHouseWhenThereIsNotAFullHouse()
        {
            var roll = new List<int> { 1, 1, 3, 2, 2 };
            Assert.That(Yatzy.Score(roll, "FULLHOUSE"), Is.EqualTo(0));
        }
    }
}