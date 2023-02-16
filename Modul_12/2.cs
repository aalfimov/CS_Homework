using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к файлу с текстом:");
        string textFilePath = Console.ReadLine();

        Console.WriteLine("Введите путь к файлу со словами для модерирования:");
        string wordsFilePath = Console.ReadLine();

        // Проверяем существование файлов
        if (!File.Exists(textFilePath))
        {
            Console.WriteLine($"Файл {textFilePath} не найден");
            return;
        }

        if (!File.Exists(wordsFilePath))
        {
            Console.WriteLine($"Файл {wordsFilePath} не найден");
            return;
        }

        // Считываем содержимое файлов
        string textContent = File.ReadAllText(textFilePath);
        string wordsContent = File.ReadAllText(wordsFilePath);

        // Разбиваем слова для модерирования на массив строк
        string[] words = wordsContent.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        // Заменяем каждое слово для модерирования на *
        foreach (string word in words)
        {
            textContent = textContent.Replace(word, new string('*', word.Length));
        }

        // Записываем новое содержимое в файл
        File.WriteAllText(textFilePath, textContent);

        // Выводим сообщение об успешном завершении работы
        Console.WriteLine("Слова для модерирования были успешно заменены на *");
    }
}
