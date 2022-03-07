using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Task
{
    public partial class MainForm : Form
    {
        Graphics g;
        Map map;
        byte [,] field;
        int [,] coordinates;
        Thread myThread;
        Brush [] colors;
        Brush [,] colorField;
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);

        public MainForm()
        {
            InitializeComponent();            
            RefreshPictureBox();           
            map = new Map();
            field = map.GetMap();
            colorField = map.GetColorMap();
            myThread = new Thread(StartGame);
            colors = new Brush[8] { Brushes.Green, Brushes.Red, Brushes.Yellow, Brushes.Orange, Brushes.Blue, Brushes.Brown, Brushes.Purple, Brushes.Pink };
        }

        private void StartGame()
        {
            label2.BeginInvoke((MethodInvoker)(() => label2.Text = Game.Level.ToString()));
            label4.BeginInvoke((MethodInvoker)(() => label4.Text = Game.Score.ToString()));            
            bool endGame = false;
            Random random = new Random();
            int choice = random.Next(0, 4);         
            int color = random.Next(0, colors.Length);            
            int k = 1000;
            int flag = 0;

            if (choice == 0)
            {
                Figure1 figure1 = new Figure1(3, 0);
                coordinates = figure1.GetCoordinates();

                if (map.CheckStep(coordinates, 0) == false)
                {
                    endGame = true;
                }

                while (endGame == false)
                {
                    coordinates = figure1.GetCoordinates();

                    if (GetAsyncKeyState(Keys.Left) != 0)
                    {
                        Figure1 tempFigure1 = new Figure1(coordinates[0, 0] - 1, coordinates[0, 1]);
                        int [,] tempCoordinates = tempFigure1.GetCoordinates();

                        if (map.CheckStep(tempCoordinates, 2) == true)
                        {
                            figure1 = tempFigure1;
                            coordinates = tempCoordinates;
                        }
                    }
                    else if (GetAsyncKeyState(Keys.Right) != 0)
                    {
                        Figure1 tempFigure1 = new Figure1(coordinates[0, 0] + 1, coordinates[0, 1]);
                        int [,] tempCoordinates = tempFigure1.GetCoordinates();

                        if (map.CheckStep(tempCoordinates, 1) == true)
                        {
                            figure1 = tempFigure1;
                            coordinates = tempCoordinates;
                        }
                    }
                    else if (GetAsyncKeyState(Keys.Down) != 0)
                    {
                        k = 300;
                    }

                    DrawFigure(colors[color], figure1.Thickness);
                    pictureBox1.BeginInvoke((MethodInvoker)(() => pictureBox1.Refresh()));
                    Thread.Sleep((int)(k / Game.Speed));

                    if (map.CheckStep(coordinates, 0) == true)
                    {
                        DrawFigure(Brushes.White, figure1.Thickness);
                        coordinates[0, 1] += 1;
                        figure1 = new Figure1(coordinates[0, 0], coordinates[0, 1]);
                    }
                    else
                    {
                        DeleteRow(color, figure1);
                        break;
                    }
                }
            }
            else if (choice == 1)
            {                
                Figure2 figure1 = new Figure2(3, 0, flag);
                coordinates = figure1.GetCoordinates();

                if (map.CheckStep(coordinates, 0) == false)
                {
                    endGame = true;
                }

                while (endGame == false)
                {
                    coordinates = figure1.GetCoordinates();

                    if (GetAsyncKeyState(Keys.Up) != 0) //вертикальную фигуру делаем горизонтальной                        
                    {
                        int tempFlag = flag == 0 ? 1 : 0;
                        Figure2 tempFigure1 = new Figure2(coordinates[0, 0], coordinates[0, 1], tempFlag);
                        int [,] tempCoordinates = tempFigure1.GetCoordinates();

                        if (map.CheckStep(tempCoordinates, -1) == true)
                        {
                            figure1 = tempFigure1;
                            coordinates = tempCoordinates;
                            flag = tempFlag;
                        }
                    }
                    else if (GetAsyncKeyState(Keys.Left) != 0)
                    {
                        Figure2 tempFigure1 = new Figure2(coordinates[0, 0] - 1, coordinates[0, 1], flag);
                        int [,] tempCoordinates = tempFigure1.GetCoordinates();

                        if (map.CheckStep(tempCoordinates, 2) == true)
                        {
                            figure1 = tempFigure1;
                            coordinates = tempCoordinates;
                        }
                    }
                    else if (GetAsyncKeyState(Keys.Right) != 0)
                    {
                        Figure2 tempFigure1 = new Figure2(coordinates[0, 0] + 1, coordinates[0, 1], flag);
                        int [,] tempCoordinates = tempFigure1.GetCoordinates();

                        if (map.CheckStep(tempCoordinates, 1) == true)
                        {
                            figure1 = tempFigure1;
                            coordinates = tempCoordinates;
                        }
                    }
                    else if (GetAsyncKeyState(Keys.Down) != 0)
                    {
                        k = 300;
                    }

                    DrawFigure(colors[color], figure1.Thickness);
                    pictureBox1.BeginInvoke((MethodInvoker)(() => pictureBox1.Refresh()));
                    Thread.Sleep((int)(k / Game.Speed));

                    if (map.CheckStep(coordinates, 0) == true)
                    {
                        DrawFigure(Brushes.White, figure1.Thickness);
                        coordinates[0, 1] += 1;
                        figure1 = new Figure2(coordinates[0, 0], coordinates[0, 1], flag);
                    }
                    else
                    {
                        DeleteRow(color, figure1);
                        break;
                    }
                }
            }
            else if (choice == 2)
            {
                Figure3 figure1 = new Figure3(3, 0, flag);
                coordinates = figure1.GetCoordinates();

                if (map.CheckStep(coordinates, 0) == false)
                {
                    endGame = true;
                }

                while (endGame == false)
                {
                    coordinates = figure1.GetCoordinates();

                    if (GetAsyncKeyState(Keys.Up) != 0)                    
                    {
                        int tempFlag = flag == 0 ? 1 : 0;
                        Figure3 tempFigure1 = new Figure3(coordinates[0, 0], coordinates[0, 1], tempFlag);
                        int [,] tempCoordinates = tempFigure1.GetCoordinates();

                        if (map.CheckStep(tempCoordinates, -1) == true)
                        {
                            figure1 = tempFigure1;
                            coordinates = tempCoordinates;
                            flag = tempFlag;
                        }
                    }
                    else if (GetAsyncKeyState(Keys.Left) != 0)
                    {
                        Figure3 tempFigure1 = new Figure3(coordinates[0, 0] - 1, coordinates[0, 1], flag);
                        int [,] tempCoordinates = tempFigure1.GetCoordinates();

                        if (map.CheckStep(tempCoordinates, 2) == true)
                        {
                            figure1 = tempFigure1;
                            coordinates = tempCoordinates;
                        }
                    }
                    else if (GetAsyncKeyState(Keys.Right) != 0)
                    {
                        Figure3 tempFigure1 = new Figure3(coordinates[0, 0] + 1, coordinates[0, 1], flag);
                        int [,] tempCoordinates = tempFigure1.GetCoordinates();

                        if (map.CheckStep(tempCoordinates, 1) == true)
                        {
                            figure1 = tempFigure1;
                            coordinates = tempCoordinates;
                        }
                    }
                    else if (GetAsyncKeyState(Keys.Down) != 0)
                    {
                        k = 300;
                    }

                    DrawFigure(colors[color], figure1.Thickness);
                    pictureBox1.BeginInvoke((MethodInvoker)(() => pictureBox1.Refresh()));
                    Thread.Sleep((int)(k / Game.Speed));

                    if (map.CheckStep(coordinates, 0) == true)
                    {
                        DrawFigure(Brushes.White, figure1.Thickness);
                        coordinates[0, 1] += 1;
                        figure1 = new Figure3(coordinates[0, 0], coordinates[0, 1], flag);
                    }
                    else
                    {
                        DeleteRow(color, figure1);
                        break;
                    }
                }
            }
            else if (choice == 3)
            {
                Figure4 figure1 = new Figure4(3, 0, flag);
                coordinates = figure1.GetCoordinates();

                if (map.CheckStep(coordinates, 0) == false)
                {
                    endGame = true;
                }

                while (endGame == false)
                {
                    coordinates = figure1.GetCoordinates();

                    if (GetAsyncKeyState(Keys.Up) != 0)
                    {
                        int tempFlag = flag == 3 ? 0 : flag + 1;
                        Figure4 tempFigure1 = new Figure4(coordinates[0, 0], coordinates[0, 1], tempFlag);
                        int [,] tempCoordinates = tempFigure1.GetCoordinates();

                        if (map.CheckStep(tempCoordinates, -1) == true)
                        {
                            figure1 = tempFigure1;
                            coordinates = tempCoordinates;
                            flag = tempFlag;
                        }
                    }
                    else if (GetAsyncKeyState(Keys.Left) != 0)
                    {
                        Figure4 tempFigure1 = new Figure4(coordinates[0, 0] - 1, coordinates[0, 1], flag);
                        int [,] tempCoordinates = tempFigure1.GetCoordinates();

                        if (map.CheckStep(tempCoordinates, 2) == true)
                        {
                            figure1 = tempFigure1;
                            coordinates = tempCoordinates;
                        }
                    }
                    else if (GetAsyncKeyState(Keys.Right) != 0)
                    {
                        Figure4 tempFigure1 = new Figure4(coordinates[0, 0] + 1, coordinates[0, 1], flag);
                        int [,] tempCoordinates = tempFigure1.GetCoordinates();

                        if (map.CheckStep(tempCoordinates, 1) == true)
                        {
                            figure1 = tempFigure1;
                            coordinates = tempCoordinates;
                        }
                    }
                    else if (GetAsyncKeyState(Keys.Down) != 0)
                    {
                        k = 300;
                    }

                    DrawFigure(colors[color], figure1.Thickness);
                    pictureBox1.BeginInvoke((MethodInvoker)(() => pictureBox1.Refresh()));
                    Thread.Sleep((int)(k / Game.Speed));

                    if (map.CheckStep(coordinates, 0) == true)
                    {
                        DrawFigure(Brushes.White, figure1.Thickness);
                        coordinates[0, 1] += 1;
                        figure1 = new Figure4(coordinates[0, 0], coordinates[0, 1], flag);
                    }
                    else
                    {
                        DeleteRow(color, figure1);
                        break;
                    }
                }
            }

            if (endGame == false)
            {
                StartGame();
            }
            else
            {
                MessageBox.Show("Игра закончена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            myThread.Start();
        }        

        private void RefreshPictureBox()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            float thickness = pictureBox1.Height / 15;
            float newY = 0;
            float newX = 0;

            for (int i = 0; i < 15; i++)
            {
                g.DrawLine(new Pen(Brushes.Black), 0, newY, pictureBox1.Width - 6, newY);
                g.DrawLine(new Pen(Brushes.Black), newX, 0, newX, pictureBox1.Height - 32);
                newY += thickness;
                newX += thickness;
            }
        }

        private void DeleteRow(int color, Figure figure1)
        {
            PutFigureValuesOnGameField(color);
            int counter = 0;
            List<int> deletedRows = new List<int>();
            byte [,] tempField = new byte[field.GetLength(0), field.GetLength(1)];
            Brush [,] tempColorField = new Brush[colorField.GetLength(0), colorField.GetLength(1)];

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    tempField[i, j] = 0;
                    tempColorField[i, j] = Brushes.White;
                }
            }

            for (int i = field.GetLength(1) - 1; i >= 0; i--)
            {
                for (int j = 0; j < field.GetLength(0); j++)
                {
                    if (field[j, i] == 1)
                    {
                        counter++;
                    }
                }

                if (counter == field.GetLength(0))
                {
                    deletedRows.Add(i);
                }

                counter = 0;
            }

            int tempRow = field.GetLength(1) - 1;

            for (int i = field.GetLength(1) - 1; i >= 0; i--)
            {
                if (!deletedRows.Contains(i))
                {
                    for (int j = 0; j < field.GetLength(0); j++)
                    {
                        tempField[j, tempRow] = field[j, i];
                        tempColorField[j, tempRow] = colorField[j, i];
                    }

                    tempRow--;
                }
            }

            if (deletedRows.Count != 0)
            {
                Game.Score += deletedRows.Count * 50;
                field = tempField;
                colorField = tempColorField;

                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        g.FillRectangle(colorField[i, j], i * figure1.Thickness, j * figure1.Thickness, figure1.Thickness, figure1.Thickness);
                        g.DrawRectangle(new Pen(Brushes.Black), i * figure1.Thickness, j * figure1.Thickness, figure1.Thickness, figure1.Thickness);
                    }
                }

                map.SetMap(field);
                map.SetColorMap(colorField);
                pictureBox1.BeginInvoke((MethodInvoker)(() => pictureBox1.Refresh()));
            }
        }

        private void DrawFigure(Brush brush, int thickness)
        {
            for (int i = 0; i < coordinates.GetLength(1); i += 2)
            {
                g.FillRectangle(brush, coordinates[1, i], coordinates[1, i + 1], thickness, thickness);
                g.DrawRectangle(new Pen(Brushes.Black), coordinates[1, i], coordinates[1, i + 1], thickness, thickness);                
            }
        }

        private void PutFigureValuesOnGameField(int color)
        {
            for (int i = 0; i < coordinates.GetLength(1); i += 2)
            {
                colorField[coordinates[0, i], coordinates[0, i + 1]] = colors[color];
                field[coordinates[0, i], coordinates[0, i + 1]] = 1;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            myThread.Abort();            
        }
    }
}
