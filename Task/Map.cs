using System.Drawing;

namespace Task
{
    class Map
    {
        byte [,] map;
        Brush [,] colorMap;

        public Map()
        {
            map = new byte[8, 14]; //8 - width, 14 - height
            colorMap = new Brush[8, 14];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = 0;
                    colorMap[i, j] = Brushes.White;
                }
            }
        }

        public float Width { get { return 144; } }
        public float Height { get { return 252; } }

        public byte [,] GetMap()
        {
            return map;
        }

        public void SetMap(byte [,] _map)
        {
            map = _map;
        }

        public Brush [,] GetColorMap()
        {
            return colorMap;
        }

        public void SetColorMap(Brush [,] _colorMap)
        {
            colorMap = _colorMap;
        }

        public bool CheckStep(int [,] coordinates, int flagMovement) //-1 - поворот фигуры, 0 - вниз, 1 - направо, 2 - налево
        {
            try
            {
                for (int i = 0; i < coordinates.GetLength(1); i += 2)
                {
                    if (flagMovement == -1 && map[coordinates[0, i], coordinates[0, i + 1]] == 1)
                    {
                        return false;
                    }
                    else if (flagMovement == 0 && map[coordinates[0, i], coordinates[0, i + 1] + 1] == 1)
                    {
                        return false;
                    }
                    else if (flagMovement == 1 && map[coordinates[0, i], coordinates[0, i + 1]] == 1)
                    {
                        return false;
                    }
                    else if (flagMovement == 2 && map[coordinates[0, i], coordinates[0, i + 1]] == 1)
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}

