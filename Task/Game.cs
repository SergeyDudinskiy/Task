namespace Task
{
    class Game
    {
        static int level;
        public static int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;                
                Speed = 0.9 + (double)level / 10;
            }
        }

        static int score;
        public static int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                Level = score / 100;             
            }
        }

        public static double Speed { get; set; } = 1;
    }
}
