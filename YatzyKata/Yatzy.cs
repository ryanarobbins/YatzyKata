namespace YatzyKata
{
    public static class Yatzy
    {
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
            if(category == "ONES")
            {
                return roll.Where(x => x == 1).Sum();
            }
            return -1;
        }
    }
}