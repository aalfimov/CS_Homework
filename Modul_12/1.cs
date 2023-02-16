using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите слово для поиска:");
        string searchWord = Console.ReadLine();

        Console.WriteLine("Введите слово для замены:");
        string replaceWord = Console.ReadLine();

        Console.WriteLine("Введите путь к файлу:");
        string filePath = Console.ReadLine();

        // Проверяем существует ли файл
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл {filePath} не найден");
            return;
        }

        // Считываем содержимое файла
        string fileContent = File.ReadAllText(filePath);

        // Заменяем слово в содержимом файла
        string newFileContent = fileContent.Replace(searchWord, replaceWord);

        // Записываем новое содержимое в файл
        File.WriteAllText(filePath, newFileContent);

        // Выводим статистику
        int count = newFileContent.Split(new string[] { searchWord }, StringSplitOptions.None).Length - 1;
        Console.WriteLine($"Слово {searchWord} было заменено на {replaceWord} {count} раз");
    }
}
