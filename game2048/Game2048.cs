using System;
using System.Collections.Generic;
using System.Text;

namespace game2048
{
    class Game2048
    {
        Random rand = new Random();
        private int[,] field = new int[4, 4];
        private bool winFlag = false;
        public void initField()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    field[i, j] = 0;
                }
            }
            setNewItem();
            setNewItem();

            drawTable();

            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.LeftArrow:
                        leftChange();
                        break;
                    case ConsoleKey.UpArrow:
                        upChange();
                        break;
                    case ConsoleKey.RightArrow:
                        rightChange();
                        break;
                    case ConsoleKey.DownArrow:
                        downChange();
                        break;
                    default:
                        break;
                }
            }
        }

        public void winAlert()
        {
            Console.WriteLine("WIN");
        }

        public void setNewItem()
        {
            while(true)
            {
                int x = rand.Next(0, 4);
                int y = rand.Next(0, 4);

                if (field[x, y] == 0) {
                    field[x, y] = 2;
                    break;
                }
            }
        }

        public void drawTable()
        {
            Console.Clear();
            Console.WriteLine("/===============\\");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int itemValue = field[i, j];
                    Console.Write("|");
                    switch (itemValue)
                    {
                        case 0:
                            Console.Write("   ");
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{itemValue, -3}");
                            Console.ResetColor();
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write($"{itemValue,-3}");
                            Console.ResetColor();
                            break;
                        case 8:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.Write($"{itemValue,-3}");
                            Console.ResetColor();
                            break;
                        case 16:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.Write($"{itemValue,-3}");
                            Console.ResetColor();
                            break;
                        case 32:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.Write($"{itemValue,-3}");
                            Console.ResetColor();
                            break;
                        case 64:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write($"{itemValue,-3}");
                            Console.ResetColor();
                            break;
                        case 128:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write($"{itemValue,-3}");
                            Console.ResetColor();
                            break;
                        case 256:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write($"{itemValue,-3}");
                            Console.ResetColor();
                            break;
                        case 512:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write($"{itemValue,-3}");
                            Console.ResetColor();
                            break;
                        case 1024:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.Write($"{itemValue,-3}");
                            Console.ResetColor();
                            break;
                        case 2048:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{itemValue,-3}");
                            Console.ResetColor();
                            winFlag = true;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write($"{itemValue,-3}");
                            break;
                    }
                }
                Console.WriteLine("|");
                Console.WriteLine("-----------------");
            }
            Console.WriteLine("\\===============/");

            if (winFlag) winAlert(); 
        }


        public void leftChange()
        {
            Console.WriteLine("left");

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int itemValue = field[i, j];

                    if (itemValue == 0 || j == 0) continue;

                    for (int k = j; k > 0; k--)
                    {
                        if (k == 0) break;

                        if (field[i, k-1] == 0)
                        {
                            field[i, k-1] = itemValue;
                            field[i, k] = 0;
                            continue;

                        }else if (field[i, k - 1] != 0)
                        {
                            if (field[i, k - 1] == itemValue)
                            {
                                field[i, k - 1] *= 2;
                                field[i, k] = 0;

                            } else if (field[i, k - 1] != itemValue) break;
                        }
                    }
                }
            }

            setNewItem();
            drawTable();
        }

        public void rightChange()
        {
            Console.WriteLine("right");

            for (int i = 0; i < 4; i++)
            {
                for (int j = 3; j >= 0; j--)
                {
                    int itemValue = field[i, j];

                    if (itemValue == 0 || j == 3) continue;

                    for (int k = j; k < 4; k++)
                    {
                        if (k == 3) break;

                        if (field[i, k + 1] == 0)
                        {
                            field[i, k + 1] = itemValue;
                            field[i, k] = 0;
                            continue;

                        }
                        else if (field[i, k + 1] != 0)
                        {
                            if (field[i, k + 1] == itemValue)
                            {
                                field[i, k + 1] *= 2;
                                field[i, k] = 0;

                            }
                            else if (field[i, k + 1] != itemValue) break;
                        }
                    }
                }
            }

            setNewItem();
            drawTable();
        }

        public void upChange()
        {
            Console.WriteLine("up");

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int itemValue = field[j, i];

                    if (itemValue == 0 || j == 0) continue;

                    for (int k = j; k > 0; k--)
                    {
                        if (k == 0) break;

                        if (field[k - 1, i] == 0)
                        {
                            field[k - 1, i] = itemValue;
                            field[k, i] = 0;
                            continue;

                        }
                        else if (field[k - 1, i] != 0)
                        {
                            if (field[k - 1, i] == itemValue)
                            {
                                field[k - 1, i] *= 2;
                                field[k, i] = 0;

                            }
                            else if (field[k - 1, i] != itemValue) break;
                        }
                    }
                }
            }

            setNewItem();
            drawTable();
        }

        public void downChange()
        {
            Console.WriteLine("down");

            for (int i = 0; i < 4; i++)
            {
                for (int j = 3; j >= 0; j--)
                {
                    int itemValue = field[j, i];

                    if (itemValue == 0 || j == 3) continue;

                    for (int k = j; k < 4; k++)
                    {
                        if (k == 3) break;

                        if (field[k + 1, i] == 0)
                        {
                            field[k + 1, i] = itemValue;
                            field[k, i] = 0;
                            continue;

                        }
                        else if (field[k + 1, i] != 0)
                        {
                            if (field[k + 1, i] == itemValue)
                            {
                                field[k + 1, i] *= 2;
                                field[k, i] = 0;

                            }
                            else if (field[k + 1, i] != itemValue) break;
                        }
                    }
                }
            }

            setNewItem();
            drawTable();
        }

    }
}
