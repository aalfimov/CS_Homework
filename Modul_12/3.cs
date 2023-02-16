using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к файлу:");
        string filePath = Console.ReadLine();

        // Проверяем существование файла
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл {filePath} не найден");
            return;
        }

        // Считываем содержимое файла
        string fileContent = File.ReadAllText(filePath);

        // Создаем новую строку с перевернутым содержимым
        string reversedContent = new string(fileContent.Reverse().ToArray());

        // Формируем новый путь для сохранения перевернутого файла
        string reversedFilePath = Path.Combine(Path.GetDirectoryName(filePath), "reversed_" + Path.GetFileName(filePath));

        // Записываем перевернутое содержимое в новый файл
        File.WriteAllText(reversedFilePath, reversedContent);

        // Выводим сообщение об успешном завершении работы
        Console.WriteLine($"Файл {filePath} был успешно перевернут и сохранен в {reversedFilePath}");
    }
}
