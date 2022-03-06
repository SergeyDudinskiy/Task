namespace Task
{
    abstract class Figure
    {
        protected int [,] coordinates;        

        public int [,] GetCoordinates()
        {
            return coordinates;
        }

        public int Thickness { get { return 18; } }
    }
}

