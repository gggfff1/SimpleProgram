using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System;


namespace SimpleProgram
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nЧтобы ознакомиться с командами, введите help");
                var name = Console.ReadLine()?.Trim().ToLower();
                if (name == "help")
                {
                    Console.WriteLine("В наличии программ есть:\n" +
                        "\nEXIT выйти из программы" +
                        "\nTIMER это простой таймер" +
                        "\nSQRTMATH это решение квадратных уравнений" +
                        "\nCALC это простой калькулятор" +
                        "\nODDEVEN это нахождение в четных и нечетных чисел в диапазоне" +
                        "\nCONVERTER это конвертер валют. из рублей в йены" +
                        "\nBENCH это простая программа для напряга" +
                        "\nHERALD какой ты рекрут по ммр" +
                        "\nRECTANGLE потроение прямоугольников произвольного размера" +
                        "\nTRAINGLE построение треугольников" +
                        "\nARRAY построение массива из случайных чисел");
                }
                else
                {
                    Console.Clear();
                    var task = typeof(Program).GetMethod(name ?? "", BindingFlags.Static | BindingFlags.NonPublic);
                    if (name == "exit")
                    {
                        return;
                    }
                    else if (task is null)
                    {
                        Console.WriteLine("Такой задачи пока нет."); continue;
                    }
                    task.Invoke(null, null);
                }
            }
        }

        static void timer()
        {
            int timeLimit = 0;
            while (true)
            {
                Console.WriteLine("Simple timer. enter time in sec");
                try
                {
                    timeLimit = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    System.Console.WriteLine("Введено неправильное число!");
                    continue;
                }
                for (int i = timeLimit; i > 0; i--)
                {
                    Console.WriteLine(i);
                    System.Threading.Thread.Sleep(1000);
                }
                Console.WriteLine("Times up!");
                break;
            }
        }

        static void sqrtmath()
        {
            Console.Clear();
            Console.WriteLine("x^2 +- bx +- c");
            Console.WriteLine("Введите a");
            string a = Console.ReadLine();
            Console.WriteLine("Введите b");
            string b = Console.ReadLine();
            Console.WriteLine("Введите c");
            string c = Console.ReadLine();

            int powb = (int)Math.Pow(Convert.ToInt32(b), 2);

            Console.WriteLine("\nКорни:");
            int discriminant = powb - 4 * Convert.ToInt32(a) * Convert.ToInt32(c);
            int x1 = (-Convert.ToInt32(b) + discriminant) / (2 * Convert.ToInt32(a));
            Console.WriteLine(x1);
            int x2 = (-Convert.ToInt32(b) - discriminant) / (2 * Convert.ToInt32(a));
            Console.WriteLine(x2);
        }

        static void calc()
        {
            while (true)
            {
                Console.Clear();
                double valueFirst = 0, valueSecond = 0;
                try
                {
                    Console.WriteLine("Введите первое число");
                    valueFirst = double.Parse(Console.ReadLine());

                    Console.WriteLine("Введите второе число");
                    valueSecond = double.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка: введено неверное число");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("Выберите оператор + - * /");
                string Operator = Console.ReadLine();
                double result = 0;
                switch (Operator)
                {
                    case "+":
                        result = valueFirst + valueSecond;
                        break;
                    case "-":
                        result = valueFirst - valueSecond;
                        break;
                    case "*":
                        result = valueFirst * valueSecond;
                        break;
                    case "/":
                        result = valueFirst / valueSecond;
                        break;
                    default:
                        Console.WriteLine("Неизвестная операция");
                        break;
                }
                Console.WriteLine("Результат: " + result);

                Console.WriteLine("Нажмите Q, чтобы выйти");
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Q:
                        return;
                }
            }
        }

        static void oddeven()
        {
            Console.WriteLine("Введите начало диапазона:");
            int inRange = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите конец диапазона:");
            int limit = int.Parse(Console.ReadLine());
            uint evenCount = 0;
            uint oddCount = 0;
            int evenSum = 0, oddSum = 0;
            while (inRange < limit)
            {
                inRange++;
                if (inRange % 2 == 0)
                {
                    evenSum += inRange;
                    evenCount++;
                }
                else
                {
                    oddSum += inRange;
                    oddCount++;
                }
            }
            Console.WriteLine("Четные " + evenCount);
            Console.WriteLine("Нечетные " + oddCount);
            Console.WriteLine("Их сумма " + (evenCount + oddCount));
            Console.WriteLine("Сумма всех четных чисел " + evenSum + "\nСумма всех нечетных " + oddSum);
        }

        static void converter()
        {
            double rubActual = 0.52;
            double yenActual = 1.92;
            Console.WriteLine("Калькулятор валют\nИз Рублей в Йены\nВыберите 1 если из Рублей в Йены\nВыберите 2 если из Йен в Рубли");
            if (Console.ReadLine() == "1")
            {
                Console.WriteLine("Введите количество Рублей");
                double rub = double.Parse(Console.ReadLine());
                yenActual = 1.91;
                double convert = rub * yenActual;
                Console.WriteLine("Получится " + convert + " Йен");
            }
            else
            {
                Console.WriteLine("Введите количество Йен");
                double yen = double.Parse(Console.ReadLine());
                rubActual = 0.52;
                double convert = rubActual * yen;
                Console.WriteLine("Получится " + convert + " Руб");
            }
        }
        static void bench()
        {
            Console.WriteLine("Choose efficiency of your proccessor.\nLow, Medium, High");
            string power = Console.ReadLine().ToLower();
            long value = 0;
            switch (power)
            {
                case "low":
                    {
                        value = 500000;
                    }
                    break;
                case "medium":
                    {
                        value = 5000000;
                    }
                    break;
                case "high":
                    {
                        value = 500000000;
                    }
                    break;
            }
            long timer = 0;
            while (timer < value)
            {
                timer++;
                Console.WriteLine(timer);
            }

            Console.WriteLine(timer);
        }

        static void herald()
        {
            Console.WriteLine("Введите свой ммр");
            int mmr = int.Parse(Console.ReadLine());
            int rating = 1;
            for (int i = 153; i < mmr;)
            {
                rating++;
                i += 153;
            }
            Console.WriteLine("Вы рекрут " + rating + "!");
        }

        static void rectangle()
        {
            Console.WriteLine("Введите высоту прямоугольника");
            int height = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите ширину прямоугольника");
            int width = int.Parse(Console.ReadLine());
            width += width;

            for (int i = 0; i < height; i++)
            {
                for (int w = 0; w < width; w++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
        }

        static void traingle()
        {
            Console.WriteLine("Введите количество треугольников, 1 это 2 обычных, 2 отзеркаленных");
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите рамер");
            int width = int.Parse(Console.ReadLine());
            int traingle = 0;
            for (int i = 1; i <= height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write('#');
                    for (int g = 0; g < traingle; g++)
                    {
                        Console.Write("#");
                    }
                    traingle++;
                    Console.WriteLine();
                }
                int traingle2 = traingle;
                Console.WriteLine();
                Console.WriteLine();
                for (int c = 0; c < width; c++)
                {
                    Console.Write('#');
                    traingle--;
                    for (int g = 0; g < traingle; g++)
                    {
                        Console.Write("#");
                    }
                    Console.WriteLine();
                }

                traingle = 0;

                Console.WriteLine();

                for (int j = 0; j < width; j++)
                {
                    Console.Write("");
                    for (int q = 1; q < traingle2; q++)
                    {
                        Console.Write(" ");
                    }
                    traingle2--;
                    traingle++;
                    for (int d = 0; d < traingle; d++)
                    {
                        Console.Write('#');
                    }

                    Console.WriteLine();
                }


                Console.WriteLine();
                Console.WriteLine();


                for (int j = 0; j < width; j++)
                {


                    Console.Write("");
                    for (int q = 0; q < traingle2; q++)
                    {
                        Console.Write(" ");
                    }
                    traingle2++;
                    traingle--;
                    for (int d = 0; d <= traingle; d++)
                    {
                        Console.Write('#');
                    }
                    Console.WriteLine();
                }
            }
        }

        static void array()
        {
            while (true)
            {
                long elementsCount;
                long[] Array;
                try
                {
                    Console.WriteLine("Введите количество элементов в массиве, лимит элементов в массиве UInt64");
                    elementsCount = long.Parse(Console.ReadLine());
                    Array = new long[elementsCount];
                }
                catch (Exception) { continue; }
                
                Random randomNumber = new Random();
                Console.WriteLine("Заполнение массива");
                var timeStart= DateTime.Now;
                for (long i = 0; i < Array.Length; i++)
                {
                    Console.WriteLine($"Генерация элемента массива под индексом {i}:");
                    Array[i] = randomNumber.Next(9);
                }

                ulong evenCount = 0, oddCount = 0;
                double evenSum = 0, oddSum = 0;

                for (int i = 0; i < Array.Length; i++)
                {
                    long temp = int.Parse(Array[i].ToString());

                    if (temp % 2 == 0)
                    {
                        evenCount++;
                        evenSum += temp;
                    }
                    else
                    {
                        oddCount++;
                        oddSum += temp;
                    }

                }
                Console.WriteLine("Количество четных " + evenCount);
                Console.WriteLine("Сумма четных " + evenSum);
                Console.WriteLine("Количество нечетных " + oddCount);
                Console.WriteLine("Сумма нечетных " + oddSum);

                double theory = evenSum / evenCount;
                double theory2 = oddSum / oddCount;
                Console.Write("Нижняя граница: ");
                Console.WriteLine(theory);
                Console.Write("Верхняя граница: ");
                Console.WriteLine(theory2);
                Console.WriteLine("Время начала перебора " + timeStart);
                Console.WriteLine("Время остановки перебора " + DateTime.Now);
                Console.WriteLine("Нажмите Q, чтобы выйти");
                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    break;
                }
            }
        }


    }
}