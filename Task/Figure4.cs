namespace Task
{
    class Figure4 : Figure
    {
        public Figure4(int x1, int y1, int flag)
        {
            if (flag == 0)
            {
                // *                                                       
                // ***   
                coordinates = new int[2, 8]; //{ x1, y1, x2, y2, x3, y3, x4, y4 }
                coordinates[0, 0] = x1;      //{ x1 * Thickness, y1 * Thickness, x2 * Thickness, y2 * Thickness, x3 * Thickness, y3 * Thickness, x4 * Thickness, y4 * Thickness}
                coordinates[0, 1] = y1;
                coordinates[0, 2] = x1;
                coordinates[0, 3] = y1 + 1;
                coordinates[0, 4] = x1 + 1;
                coordinates[0, 5] = y1 + 1;
                coordinates[0, 6] = x1 + 2;
                coordinates[0, 7] = y1 + 1;
            }
            else if (flag == 1) 
            {
                // **                                                       
                // *
                // *
                coordinates = new int[2, 8]; //{ x1, y1, x2, y2, x3, y3, x4, y4 }
                coordinates[0, 0] = x1;      //{ x1 * Thickness, y1 * Thickness, x2 * Thickness, y2 * Thickness, x3 * Thickness, y3 * Thickness, x4 * Thickness, y4 * Thickness}
                coordinates[0, 1] = y1;
                coordinates[0, 2] = x1 + 1;
                coordinates[0, 3] = y1;
                coordinates[0, 4] = x1;
                coordinates[0, 5] = y1 + 1;
                coordinates[0, 6] = x1;
                coordinates[0, 7] = y1 + 2;
            }
            else if (flag == 2) 
            {
                // ***                                                       
                //   *                
                coordinates = new int[2, 8]; //{ x1, y1, x2, y2, x3, y3, x4, y4 }
                coordinates[0, 0] = x1;      //{ x1 * Thickness, y1 * Thickness, x2 * Thickness, y2 * Thickness, x3 * Thickness, y3 * Thickness, x4 * Thickness, y4 * Thickness}
                coordinates[0, 1] = y1;
                coordinates[0, 2] = x1 + 1;
                coordinates[0, 3] = y1;
                coordinates[0, 4] = x1 + 2;
                coordinates[0, 5] = y1;
                coordinates[0, 6] = x1 + 2;
                coordinates[0, 7] = y1 + 1;
            }
            else if (flag == 3) 
            {
                //  *                                                       
                //  *
                // **
                coordinates = new int[2, 8]; //{ x1, y1, x2, y2, x3, y3, x4, y4 }
                coordinates[0, 0] = x1;      //{ x1 * Thickness, y1 * Thickness, x2 * Thickness, y2 * Thickness, x3 * Thickness, y3 * Thickness, x4 * Thickness, y4 * Thickness}
                coordinates[0, 1] = y1;
                coordinates[0, 2] = x1;
                coordinates[0, 3] = y1 + 1;
                coordinates[0, 4] = x1;
                coordinates[0, 5] = y1 + 2;
                coordinates[0, 6] = x1 - 1;
                coordinates[0, 7] = y1 + 2;
            }

            for (int i = 0; i < coordinates.GetLength(1); i++)
            {
                coordinates[1, i] = coordinates[0, i] * Thickness;
            }
        }
    }
}
