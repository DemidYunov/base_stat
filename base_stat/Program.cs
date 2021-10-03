using static System.Console;

namespace base_stat
{
    class Program
    {
        static void Main()
        {
            Write("Сколько чисел будем анализировать? (введите количество): ");
            int n = GetIntegerNum();
            int[] nums = new int[n];

            for (int i = 0; i < n; i++)
            {
                Write($"Введите {i + 1}  целое число: ");
                nums[i] = GetIntegerNum();
            }

            int min = nums[0], max = nums[0], sum = 0;
            int positiveCount = 0, negativeCount = 0, zeroCount = 0;

            foreach (int num in nums)
            {
                sum += num;
                if (min > num) min = num;
                if (max < num) max = num;

                if (num < 0)
                    negativeCount++;
                else if (num > 0)
                    positiveCount++;
                else
                    zeroCount++;
            }

            double avg = sum / n;

            WriteLine($"\nМинимальное значение:             {min}" +
                      $"\nМаксимальное значение:            {max}" +
                      $"\nСреднее значение:                 {avg}" +
                      $"\nКоличество положительных чисел:   {positiveCount}" +
                      $"\nКоличество отрицательных чисел:   {negativeCount}" +
                      $"\nКоличество нулей:                 {zeroCount}" +
                      $"\n\nPress F to pay respects");

            System.ConsoleKey key = ReadKey().Key;
            while (key != System.ConsoleKey.F)
            {
                key = ReadKey().Key;
            }
        }

        static int GetIntegerNum()
        {
            string amount = ReadLine();
            int n;
            while (!int.TryParse(amount, out n) || n == 0)
            {
                Write("Введено ошибочное значение! Повторите ввод: ");
                amount = ReadLine();
            }
            return n;
        }
    }
}
