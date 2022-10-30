using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise05
{
    internal class Order
    {
        public int index = 1;
        private int[] indexes = new int[2];
        private string[,] menu = new string[20, 20];
        private int top;
        private string label = "Заказ тортов-конструкторов";
        private int vGap = 2;
        private int gap = 0;
        private int curientmenu = 0;
        cake cake01 = new cake();

        private void DrawUI()
        {

            Console.CursorVisible = false;

            List<string> list = new List<string>();
            int j = 0;

            while (j < 20)
            {
                list.Add(menu[j, curientmenu]);
                j++;
            }

            for (int i = 0; i < list.Count; i++)
            {
                string curientString = menu[i, curientmenu];
                if (string.IsNullOrEmpty(curientString))
                {
                    continue;
                }
                if (index == i)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.SetCursorPosition(5 + gap, vGap + i);
                Console.Write(curientString);

            }
            Console.ResetColor();

        }

        private int[] UI()
        {

            ConsoleKey consoleKey;
            do
            {
                Console.SetCursorPosition(Console.BufferWidth / 2 - label.Length / 2, top);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(label);

                new Thread(DrawUI).Start();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;

                switch (consoleKey)
                {

                    case ConsoleKey.DownArrow:
                        index++;
                        if (menu[index, curientmenu] is null)
                        {
                            index--;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        index--;
                        if (index < 0)
                        {
                            index++;
                        }
                        else if (menu[index, curientmenu] is null)
                        {
                            index++;
                        }
                        break;

                    case ConsoleKey.Escape:
                        if (curientmenu == 0)
                        {
                            Process.GetCurrentProcess().Kill();
                        }
                        curientmenu = 0;
                        index = 1;
                        break;

                }

                Console.Clear();

            } while (consoleKey != ConsoleKey.Enter);

            indexes[0] = index;
            indexes[1] = curientmenu;

            return indexes;
        }

        public cake order()
        {

            int[] indexLocal = new int[2];

            while (true)
            {
                Menu();
                indexLocal = UI();

                switch (indexLocal[1])
                {
                    case 0:
                        switch (indexLocal[0])
                        {
                            case 1:
                                curientmenu = 1;
                                index = 1;
                                break;

                            case 2:
                                curientmenu = 2;
                                index = 1;
                                break;



                        }
                }

                private void Menu()
                {
                    cake01.totalCost = cake01.formCost + cake01.sizeCost + cake01.tasteCost + cake01.levelsCost + cake01.decorCost + cake01.glazeCost;
                    cake01.list = string.Concat(cake01.form, cake01.size, cake01.taste, cake01.decor, cake01.glaze, cake01.levels);
                    menu[10, 0] = $"Цена заказа: {cake01.totalCost}";
                    menu[11, 0] = "Состав заказа: " + cake01.list;

                    menu[1, 0] = "Форма";
                    menu[2, 0] = "Размер";
                    menu[3, 0] = "Вкус";
                    menu[4, 0] = "Глазурь";
                    menu[5, 0] = "Декор";
                    menu[6, 0] = "Кол-во коржей";
                    menu[7, 0] = "закончить заказ";

                    menu[1, 1] = "Круг - 500";
                    menu[2, 1] = "Квадрат - 500";
                    menu[3, 1] = "Прямоугольник - 500";
                    menu[4, 1] = "Сердечко - 700";

                    menu[1, 2] = "Малый(Диаметр 16см, 8 порций) - 1000";
                    menu[2, 2] = "Обычный(Диаметр 18см, 10 порций) - 1200";
                    menu[3, 2] = "Большой(Диаметр 28см, 24 порций) - 2000";

                    menu[1, 3] = "Ваниль - 100";
                    menu[2, 3] = "Шоколад - 100";
                    menu[3, 3] = "Карамель - 150";
                    menu[4, 3] = "Ягоды - 200";
                    menu[5, 3] = "Кокос - 250";

                    menu[1, 6] = "1 корж - 200";
                    menu[2, 6] = "2 коржа - 400";
                    menu[3, 6] = "3 коржа - 600";
                    menu[4, 6] = "4 коржа - 800";

                    menu[1, 5] = "Шоколад - 100";
                    menu[2, 5] = "Крем - 100";
                    menu[3, 5] = "Бизе - 150";
                    menu[4, 5] = "Драже - 150";
                    menu[5, 5] = "Ягоды - 200";

                    menu[1, 4] = "Шоколадная - 150";
                    menu[2, 4] = "Ягодная - 150";
                    menu[3, 4] = "Кремовая - 150";
                }
            }
        }

