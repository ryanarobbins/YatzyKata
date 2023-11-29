namespace YatzyKata
{
    public static class Yatzy
    {
        static Dictionary<string, int> numberCategories = new()
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
            
            int? numberToScore = numberCategories.ContainsKey(category) ? numberCategories[category] : null;
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