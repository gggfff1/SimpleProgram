using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;


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
                        "\nARRAY построение массива из случайных чисел" +
                        "\nRARRAY вывод массива в обратном порядке" +
                        "\nMAXMINARRAY максимальное и минимальное число" +
                        "\nTRANS дешифровка текста перепутанной раскладки" +
                        "\nRANDOM генерация случайного числа");
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

        static void rarray()
        {
            Console.Write("Введите на сколько элементов рассчитан массив ");
            int elementsCount = int.Parse(Console.ReadLine());
            int[] myArray = new int[elementsCount];
            Console.WriteLine("Заполните массив");
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine($"Введите элемент массива под индексом {i}:");
                myArray[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Вывод массива в обратном порядке");

            for (int i = myArray.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(myArray[i]);
            }
        }

        static void maxminarray()
        {
            Console.WriteLine("Введите числа, каждое число расценивается отдельным");
            char[] nums = Console.ReadLine().ToArray();
            int minimal = 0;
            int maximal = 0;
            minimal = int.Parse(nums[0].ToString());
            for (int i = 0; i < nums.Length; i++)
            {

                int num = int.Parse(nums[i].ToString());
                if (num < minimal)
                {
                    minimal = num;
                }
                if (num > maximal)
                {
                    maximal = num;
                }
            }
            Console.WriteLine("Минимальное " + minimal);
            Console.WriteLine("Максимальное " + maximal);
        }

        static void trans()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Введите текст");
                char[] array = Console.ReadLine().ToLower().ToCharArray();

                for (int i = 0; i < array.Length; i++)
                {
                    switch (array[i])
                    {
                        case 'q':
                            array[i] = 'й';
                            break;
                        case 'w':
                            array[i] = 'ц';
                            break;
                        case 'e':
                            array[i] = 'у';
                            break;
                        case 'r':
                            array[i] = 'к';
                            break;
                        case 't':
                            array[i] = 'е';
                            break;
                        case 'y':
                            array[i] = 'н';
                            break;
                        case 'u':
                            array[i] = 'г';
                            break;
                        case 'i':
                            array[i] = 'ш';
                            break;
                        case 'o':
                            array[i] = 'щ';
                            break;
                        case 'p':
                            array[i] = 'з';
                            break;
                        case '[':
                            array[i] = 'х';
                            break;
                        case ']':
                            array[i] = 'ъ';
                            break;
                        case 'a':
                            array[i] = 'ф';
                            break;
                        case 's':
                            array[i] = 'ы';
                            break;
                        case 'd':
                            array[i] = 'в';
                            break;
                        case 'f':
                            array[i] = 'а';
                            break;
                        case 'g':
                            array[i] = 'п';
                            break;
                        case 'h':
                            array[i] = 'р';
                            break;
                        case 'j':
                            array[i] = 'о';
                            break;
                        case 'k':
                            array[i] = 'л';
                            break;
                        case 'l':
                            array[i] = 'д';
                            break;
                        case ';':
                            array[i] = 'ж';
                            break;
                        case '\'':
                            array[i] = 'э';
                            break;
                        case 'z':
                            array[i] = 'я';
                            break;
                        case 'x':
                            array[i] = 'ч';
                            break;
                        case 'c':
                            array[i] = 'с';
                            break;
                        case 'v':
                            array[i] = 'м';
                            break;
                        case 'b':
                            array[i] = 'и';
                            break;
                        case 'n':
                            array[i] = 'т';
                            break;
                        case 'm':
                            array[i] = 'ь';
                            break;
                        case ',':
                            array[i] = 'б';
                            break;
                        case '.':
                            array[i] = 'ю';
                            break;
                        case '/':
                            array[i] = '.';
                            break;
                        case ' ':
                            array[i] = ' ';
                            break;
                        case '`':
                            array[i] = 'ё';
                            break;
                    }
                }
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i]);
                }
                Console.WriteLine("\n нажмите Q, чтобы вернуться в меню");
            } while (Console.ReadKey().Key != ConsoleKey.Q);
        }

        static void random()
        {
            do
            {
                Console.WriteLine("Введите сторое число диапазона");
                int[] Array = new int[10000];
                Random randomNumber = new Random();
                Console.WriteLine("Заполнение массива");
                for (short i = 0; i < Array.Length; i++)
                {
                    //Console.WriteLine($"Генерация элемента массива под индексом {i}:");
                    Array[i] = randomNumber.Next(100);
                }
                Console.WriteLine("Случайное число: " + Array[randomNumber.Next(10000)]);
                Console.WriteLine("\n нажмите Q, чтобы вернуться в меню");
            } while (Console.ReadKey().Key != ConsoleKey.Q);
        }
    }
}