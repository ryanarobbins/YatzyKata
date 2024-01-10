using YatzyScoringEngine;

namespace YatzyGameEngine
{
    public class Phase
    {
        public List<int> Roll { get; set; } = default!;

        public string RollAndPlayAndScore()
        {
            var score = Yatzy.Score(new Play(Roll, ScoreCategory.Yatzy));
            return $"Category: {ScoreCategory.Yatzy} Score: {score}";
        }
    }
}
