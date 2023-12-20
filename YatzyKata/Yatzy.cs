namespace YatzyKata
{
    public static class Yatzy
    {
        static readonly Dictionary<string, int> _oldNumberCategories = new()
        {
            {"ONES", 1 },
            {"TWOS", 2 },
            {"THREES", 3 },
            {"FOURS", 4 },
            {"FIVES", 5 },
            {"SIXES", 6 },
        };

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
            if (play.Category == ScoreCategory.Chance)
                return play.Roll.Sum();
            if (play.Category == ScoreCategory.Yatzy)
            {
                if (play.Roll.Distinct().Count() == 1)
                {
                    return 50;
                }
                return 0;
            }
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

            int? numberToScore = _numberCategories.ContainsKey(play.Category) ? _numberCategories[play.Category] : null;
            if (numberToScore != null)
                return ScoreNumberCategory(play.Roll, numberToScore.Value);

            return -1;
        }

        public static int Score(List<int> roll, string category)
        {
            if (category == "CHANCE")
            {
                Play play = new(roll, ScoreCategory.Chance);               
                return Score(play);
            }
            if (category == "YATZY")
            {
                Play play = new(roll, ScoreCategory.Yatzy);
                return Score(play);
            }
            
            if (category == "FULLHOUSE")
            {
                var counts = roll.GroupBy(x => x);
                var pair = counts.Where(x => x.Count() == 2).FirstOrDefault();
                var set = counts.Where(x => x.Count() == 3).FirstOrDefault();
                if (pair != null && set != null)
                {
                    return 25;
                }
                return 0;
            }

            if (category == "ONES")
            {
                Play play = new(roll, ScoreCategory.Ones);
                return Score(play);
            }
            if (category == "TWOS")
            {
                Play play = new(roll, ScoreCategory.Twos);
                return Score(play);
            }
            if (category == "THREES")
            {
                Play play = new(roll, ScoreCategory.Threes);
                return Score(play);
            }
            if (category == "FOURS")
            {
                Play play = new(roll, ScoreCategory.Fours);
                return Score(play);
            }
            if (category == "FIVES")
            {
                Play play = new(roll, ScoreCategory.Fives);
                return Score(play);
            }
            if (category == "SIXES")
            {
                Play play = new(roll, ScoreCategory.Sixes);
                return Score(play);
            }


            return -1;
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