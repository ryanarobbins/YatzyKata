namespace YatzyKata
{
    public static class Yatzy
    {
        static readonly Dictionary<string, int> _numberCategories = new()
        {
            {"ONES", 1 },
            {"TWOS", 2 },
            {"THREES", 3 },
            {"FOURS", 4 },
            {"FIVES", 5 },
            {"SIXES", 6 },
        };

        internal static int Score(List<int> roll, string category)
        {
            if (category == "CHANCE")
            {
                return roll.Sum();
            }
            if (category == "YATZY")
            {
                if (roll.Distinct().Count() == 1)
                {
                    return 50;
                }
                return 0;
            }
            if(category == "PAIR")
            {
                var counts = roll.GroupBy(x => x);
                var pairs = counts.Where(x => x.Count() >= 2);
                var sumPair = pairs.FirstOrDefault(s => s.Key == pairs.Max(x => x.Key));
                var score = sumPair?.Sum();

                return score ?? 0;
            }
            
            int? numberToScore = _numberCategories.ContainsKey(category) ? _numberCategories[category] : null;
            if (numberToScore != null)
                return ScoreNumberCategory(roll, numberToScore.Value);
            
            return -1;
        }

        private static int ScoreNumberCategory(List<int> roll, int numberToScore)
        {
            return roll.Where(x => x == numberToScore).Sum();
        }
    }
}