using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к файлу с целыми числами:");
        string filePath = Console.ReadLine();

        // Проверяем существование файла
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл {filePath} не найден");
            return;
        }

        // Читаем все строки из файла
        string[] lines = File.ReadAllLines(filePath);

        // Переменные для хранения статистики
        int positiveCount = 0;
        int negativeCount = 0;
        int twoDigitCount = 0;
        int fiveDigitCount = 0;

        // Списки для хранения чисел
        var positiveNumbers = new List<int>();
        var negativeNumbers = new List<int>();
        var twoDigitNumbers = new List<int>();
        var fiveDigitNumbers = new List<int>();

        // Проходим по всем строкам файла
        foreach (string line in lines)
        {
            // Парсим строку в число
            if (int.TryParse(line, out int number))
            {
                // Добавляем число в соответствующий список
                if (number > 0)
                {
                    positiveNumbers.Add(number);
                    positiveCount++;
                }
                else if (number < 0)
                {
                    negativeNumbers.Add(number);
                    negativeCount++;
                }

                // Проверяем, сколько цифр в числе
                int digitCount = Math.Abs(number).ToString().Length;

                if (digitCount == 2)
                {
                    twoDigitNumbers.Add(number);
                    twoDigitCount++;
                }
                else if (digitCount == 5)
                {
                    fiveDigitNumbers.Add(number);
                    fiveDigitCount++;
                }
            }
        }

        // Выводим статистику
        Console.WriteLine($"Количество положительных чисел: {positiveCount}");
        Console.WriteLine($"Количество отрицательных чисел: {negativeCount}");
        Console.WriteLine($"Количество двузначных чисел: {twoDigitCount}");
        Console.WriteLine($"Количество пятизначных чисел: {fiveDigitCount}");

        // Сохраняем числа в соответствующие файлы
        string positiveFilePath = Path.Combine(Path.GetDirectoryName(filePath), "positive_numbers.txt");
        string negativeFilePath = Path.Combine(Path.GetDirectoryName(filePath), "negative_numbers.txt");
        string twoDigitFilePath = Path.Combine(Path.GetDirectoryName(filePath), "two_digit_numbers.txt");
        string fiveDigitFilePath = Path.Combine(Path.GetDirectoryName(filePath), "five_digit_numbers.txt");

        File.WriteAllLines(positiveFilePath, positiveNumbers.Select(n => n.ToString()));
        File.WriteAllLines(negativeFilePath, negativeNumbers.Select(n => n.ToString()));
        File.WriteAllLines(twoDigitFilePath, twoDigitNumbers.Select(n => n.ToString()));
        File.WriteAllLines(fiveDigitFilePath, fiveDigitNumbers.Select(n => n.ToString()));

        // Выводим сообщение об успешном завершении работы
        Console.WriteLine($"Статистика по файлу {filePath} была успешно собрана и сохранена в соответствующие файлы");
    }
}
