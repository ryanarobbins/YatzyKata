using YatzyScoringEngine;

namespace YatzyGameEngine
{
    public class Phase
    {
        public List<int> Roll { get; set; } = default!;

        public Func<string?> ReadInCategory = () => Console.ReadLine();

        public string RollAndPlayAndScore()
        {
            var category = ReadInCategory();
            
            if (!Enum.TryParse<ScoreCategory>(category, true, out var parsedCategory))
            {
                return "error msg";
            }
            var score = Yatzy.Score(new Play(Roll, parsedCategory));
            return $"Category: {parsedCategory} Score: {score}";
        }
    }
}
