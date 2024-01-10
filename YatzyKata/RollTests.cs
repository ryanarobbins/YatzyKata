using YatzyGameEngine;

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
            Assert.That(phase.RollAndPlayAndScore(), Is.EqualTo("Category: Yatzy Score: 50"));
        }


        [Test]
        public void ScoreFailYatzy()
        {

            //Call a method that will
            //present dice roll
            //take in category from user
            //return a message about the score
            var phase = new Phase();
            phase.Roll = new List<int> { 1, 1, 1, 1, 2 };
            Assert.That(phase.RollAndPlayAndScore(), Is.EqualTo("Category: Yatzy Score: 0"));
        }

    }
}
