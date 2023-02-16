using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babichevskyi_002
{
    public class Program
{
    static void Main(string[] args)
    {
        int a = 1;
        int b = 2;
        Console.WriteLine($"Before swap: a = {a}, b = {b}");
        Swap(ref a, ref b);
        Console.WriteLine($"After swap: a = {a}, b = {b}");

        string str1 = "hello";
        string str2 = "world";
        Console.WriteLine($"Before swap: str1 = {str1}, str2 = {str2}");
        Swap(ref str1, ref str2);
        Console.WriteLine($"After swap: str1 = {str1}, str2 = {str2}");
    }

    static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
}





}
