using static System.Console;
using static System.Convert;

namespace base_stat
{
    class Program
    {
        static void Main()
        {
            Write("Сколько чисел будем анализировать? (введите количество): ");
            int n = GetIntegerNum();
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                Write($"Введите {i + 1}  целое число: ");
                numbers[i] = GetIntegerNum();
            }

            int minimal = numbers[0], maximal = numbers[0], summa = 0, positiveCount = 0, negativeCount = 0, zeroCount = 0;

            foreach (int localNumbers in numbers)
            {
                summa += localNumbers;
                if (minimal > localNumbers) minimal = localNumbers;
                if (maximal < localNumbers) maximal = localNumbers;

                if (localNumbers < 0)
                    negativeCount++;
                else if (localNumbers > 0)
                    positiveCount++;
                else
                    zeroCount++;
            }

            double average = ToDouble(summa / n);

            OutputResults(minimal, maximal, average, positiveCount, negativeCount, zeroCount);

            ExitProgram();
        }

        static int GetIntegerNum()
        {
            string amount = ReadLine();
            int n;
            while (!int.TryParse(amount, out n) || n <= 0)
            {
                Write("Введено ошибочное значение! Повторите ввод: ");
                amount = ReadLine();
            }
            return n;
        }

        static string OutputResults(int min, int max, double avg, int countPositiveNumber, int countNegativeNumber, int countZero) =>
                        $"\nМинимальное значение:             {min}" +
                            $"\nМаксимальное значение:            {max}" +
                            $"\nСреднее значение:                 {avg}" +
                            $"\nКоличество положительных чисел:   {countPositiveNumber}" +
                            $"\nКоличество отрицательных чисел:   {countNegativeNumber}" +
                            $"\nКоличество нулей:                 {countZero}" +
                                $"\n\nPress F to pay respects";

        static void ExitProgram()
        {
            System.ConsoleKey key = ReadKey().Key;
            while (key != System.ConsoleKey.F)
            {
                key = ReadKey().Key;
            }
        }
    }
}
