using YatzyGameEngine;
using YatzyScoringEngine;

namespace YatzyTests
{
    public class RollTests
    {
        [Test]
        public void ScoreSuccessfulYatzy() 
        {
            //Call a method that will
            //present dice roll
            //take in category from user
            //return a message about the score
            var phase = new Phase();
            phase.Roll = new List<int> { 1, 1, 1, 1, 1 };
            var category = ScoreCategory.Yatzy.ToString();
            phase.ReadInCategory = () => category;
            Assert.That(phase.RollAndPlayAndScore(), Is.EqualTo($"Category: {category} Score: 50"));
        }


        [Test]
        public void ScoreFailYatzy()
        {
            var phase = new Phase();
            phase.Roll = new List<int> { 1, 1, 1, 1, 2 };
            var category = ScoreCategory.Yatzy.ToString();
            phase.ReadInCategory = () => category;
            Assert.That(phase.RollAndPlayAndScore(), Is.EqualTo($"Category: {category} Score: 0"));
        }


        [Test]
        public void ScoreTwoOnesInOnesCategory()
        {
            var phase = new Phase();
            phase.Roll = new List<int> { 1, 1, 2, 3, 2 };
            var category = ScoreCategory.Ones.ToString();
            phase.ReadInCategory = () => category;
            Assert.That(phase.RollAndPlayAndScore(), Is.EqualTo($"Category: {category} Score: 2"));
        }


        [Test]
        public void ScoreManuallyTypedCategory()
        {
            var phase = new Phase();
            phase.Roll = new List<int> { 1, 1, 2, 3, 2 };
            var category = "ones";
            phase.ReadInCategory = () => category;
            Assert.That(phase.RollAndPlayAndScore(), Is.EqualTo($"Category: {ScoreCategory.Ones} Score: 2"));
        }


        [Test]
        public void HandleMissingCategory()
        {
            var phase = new Phase();
            phase.Roll = new List<int> { 1, 1, 2, 3, 2 };
            var category = "";
            phase.ReadInCategory = () => category;
            Assert.That(phase.RollAndPlayAndScore(), Is.EqualTo($"error msg"));
        }

    }
}
