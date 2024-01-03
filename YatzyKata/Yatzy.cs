namespace YatzyKata
{
    public static class Yatzy
    {
        static readonly Dictionary<ScoreCategory, int> _numberCategories = new()
        {
            {ScoreCategory.Ones, 1 },
            {ScoreCategory.Twos, 2 },
            {ScoreCategory.Threes, 3 },
            {ScoreCategory.Fours, 4 },
            {ScoreCategory.Fives, 5 },
            {ScoreCategory.Sixes, 6 },
        };

        public static int Score(Play play)
        {
            var finalScore = 0;
            switch (play.Category)
            {
                case ScoreCategory.Yatzy:
                    {
                        if (play.Roll.Distinct().Count() == 1)
                        {
                            finalScore = 50;
                        }
                    }
                    break;
                default:
                    break;

            }
            if (finalScore != 0) { return finalScore; }
            if (play.Category == ScoreCategory.Chance)
                return play.Roll.Sum();

            if (play.Category == ScoreCategory.Pair)
            {
                var counts = play.Roll.GroupBy(x => x);
                var pairs = counts.Where(x => x.Count() >= 2);
                var sumPair = pairs.FirstOrDefault(s => s.Key == pairs.Max(x => x.Key));
                var score = sumPair?.Sum();

                return score ?? 0;
            }
            if (play.Category == ScoreCategory.ThreeOfAKind)
            {
                return ScoreSetCategory(play.Roll, 3);
            }
            if (play.Category == ScoreCategory.FourOfAKind)
            {
                return ScoreSetCategory(play.Roll, 4);
            }
            if (play.Category == ScoreCategory.FullHouse)
            {
                var counts = play.Roll.GroupBy(x => x);
                var pair = counts.Where(x => x.Count() == 2).FirstOrDefault();
                var set = counts.Where(x => x.Count() == 3).FirstOrDefault();
                if (pair != null && set != null)
                {
                    return 25;
                }
            }
            if (play.Category == ScoreCategory.SmallStraight)
            {
                var expected = new List<int> { 1, 2, 3, 4, 5 };
                if (expected.All(play.Roll.Contains))
                {
                    return 15;
                }
            }
            if (play.Category == ScoreCategory.LargeStraight)
            {
                var expected = new List<int> { 2, 3, 4, 5, 6 };
                if (expected.All(play.Roll.Contains))
                {
                    return 20;
                }
            }

            int? numberToScore = _numberCategories.ContainsKey(play.Category) ? _numberCategories[play.Category] : null;
            if (numberToScore != null)
                return ScoreNumberCategory(play.Roll, numberToScore.Value);

            return 0;
        }

        private static int ScoreSetCategory(List<int> roll, int setLength)
        {
            var counts = roll.GroupBy(x => x);
            var sets = counts.Where(x => x.Count() >= setLength);
            var score = sets.Any() ? roll.Sum() : 0;

            return score;
        }

        private static int ScoreNumberCategory(List<int> roll, int numberToScore)
        {
            return roll.Where(x => x == numberToScore).Sum();
        }
    }
}