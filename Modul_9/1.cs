using System;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Action displayTime = () => Console.WriteLine("Current time: " + DateTime.Now.ToString("HH:mm:ss"));
            displayTime();

            Action displayDate = () => Console.WriteLine("Current date: " + DateTime.Now.ToString("yyyy-MM-dd"));
            displayDate();

            Action displayDayOfWeek = () => Console.WriteLine("Current day of week: " + DateTime.Now.DayOfWeek);
            displayDayOfWeek();

            Func<double, double, double> calculateTriangleArea = (baseLength, height) => 0.5 * baseLength * height;
            double triangleArea = calculateTriangleArea(10, 5);
            Console.WriteLine("Triangle area: " + triangleArea);

            Func<double, double, double> calculateRectangleArea = (width, height) => width * height;
            double rectangleArea = calculateRectangleArea(8, 6);
            Console.WriteLine("Rectangle area: " + rectangleArea);
        }
    }
}
