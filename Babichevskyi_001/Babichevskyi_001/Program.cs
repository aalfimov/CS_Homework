using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babichevskyi_001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {              
                Console.WriteLine("Введите номер задания");
                int y = Convert.ToInt32(Console.ReadLine());

                switch (y)
                {
                    case 1:
                        {
                            Console.WriteLine("Введите число от 1 до 100");                           
                            int x = Convert.ToInt32(Console.ReadLine());

                            while (x < 1 || x > 100)
                            {
                                Console.Beep();
                                Console.WriteLine("Неверное число, введите еще раз");                              
                                x = Convert.ToInt32(Console.ReadLine());
                            }
                            
                            if (x % 3 == 0) Console.WriteLine("Fizz");
                            if (x % 5 == 0) Console.WriteLine("Buzz");
                            if (x % 5 == 0 && x % 3 == 0) Console.WriteLine("Fizz Buzz");
                            if (x % 5 != 0 && x % 3 != 0) Console.WriteLine(x);                         
                            break;
                        }
                    case 2: {
                            Console.WriteLine("Введите значение: ");
                            int value = Convert.ToInt32(Console.ReadLine());
                            int percent = 0;

                            while (percent <= 0) {
                                Console.WriteLine("Введите процент: ");
                                percent = Convert.ToInt32(Console.ReadLine());
                                if (percent <= 0) Console.WriteLine("Число меньше 0");
                            }
                            int result = (value * percent) / 100;
                            Console.WriteLine("Результат: " + result);
                            break;
                        }
                    case 3: {
                            int k = 0, t = 0, q = 0, r = 0;
                            while (k <= 0 || t <= 0 || q <= 0 || r <= 0)
                            {
                                Console.WriteLine("Введите 1 число: ");
                                k = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите 2 число: ");
                                t = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите 3 число: ");
                                q = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите 4 число: ");
                                r = Convert.ToInt32(Console.ReadLine());
                                if(k<=0) Console.WriteLine("1 число меньше/равно 0");
                                if(t<=0) Console.WriteLine("2 число меньше/равно 0");
                                if(q<=0) Console.WriteLine("3 число меньше/равно 0");
                                if(r<=0) Console.WriteLine("4 число меньше/равно 0");
                            }                            
                            int res = (k * 1000) + (t * 100) + (q * 10) + r;
                            Console.WriteLine("Результат: " + res );
                            break;
                        }
                    case 4: {
                            int x, r;
                            string value = "Error";

                            void Print(int[] k)
                            {
                                for (int i = 0; i < 6; i++)
                                {
                                    Console.WriteLine(k[i]);
                                }
                            }
                            void swap(int[]v, int k,int u) {
                                int buf = v[k];
                                k--;
                                u--;
                                v[k] = v[u];
                                v[u] = buf - 1;
                                Print(v);
                            }
                                                        
                            while (value.Length <= 5)
                            {
                                Console.WriteLine("Введите 6-ти значное число");
                                value = Console.ReadLine();
                                if(value.Length != 6) Console.WriteLine("Вы ввели не 6 чисел");
                            }
                            
                            for (int i = 0; i < value.Length; i++)
                            {
                                Console.WriteLine(value[i]);                              
                            }
                            Console.WriteLine("Введите номера символов которые хотите поменять: ");
                            Console.WriteLine("Первый: ");
                            x = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Второй: ");
                            r = Convert.ToInt32(Console.ReadLine());
                            
                            int[] val = new int[7];
                            for (int i = 0; i < 6; i++)
                            {
                                val[i] = ((int)value[i]) - 48 ;                              
                            }                         
                            
                            swap(val, x, r);

                            break;
                        }
                    case 5: {
                            int x, r, z,season;
                            
                            Console.WriteLine("Введите год: ");
                            x = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите месяц: ");
                            r = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите день: ");
                            z = Convert.ToInt32(Console.ReadLine());
                            DateTime date1 = new DateTime(x, r, z);
                            
                            season = Convert.ToInt32(date1.DayOfYear);
                            if (season < 61 || season > 343)  Console.WriteLine("Winter " + date1.DayOfWeek); 
                            if (season > 61 && season < 155)  Console.WriteLine("Spring " + date1.DayOfWeek); 
                            if (season > 155 && season < 250)  Console.WriteLine("Summer " + date1.DayOfWeek); 
                            if (season > 250 && season < 343)  Console.WriteLine("Autumn " + date1.DayOfWeek); 

                            break;
                        }
                    case 6: 
                        {
                            int c, f, x;

                            void celsius(int cel)
                            {
                                int far = (cel * 9 / 5) + 32;
                                Console.WriteLine("В Фарингейтах: " + far);
                            }
                                void farengate(int far) 
                            {
                                int res = (far - 32) * 5 / 9;
                                Console.WriteLine("В Цельсиях: " + res);
                            }
                            Console.WriteLine("Выберите функцию");
                            Console.WriteLine("Цельсий - Фарингейт = = = Введите 1");
                            Console.WriteLine("Фарингейт - Цельсий = = = Введите 2");
                            x = Convert.ToInt32(Console.ReadLine());
                            switch (x)
                            {
                                case 1:
                                    Console.WriteLine("Введите градус по Цельсию");
                                    c = Convert.ToInt32(Console.ReadLine());
                                    celsius(c);
                                    break;
                                case 2:
                                    Console.WriteLine("Введите градус по Фарингейту");
                                    f = Convert.ToInt32(Console.ReadLine());
                                    farengate(f);
                                    break;
                                default:
                                    Console.WriteLine("Неверное значение");
                                    break;
                            }
                            break;
                        }
                    case 7: 
                      {
                            int f, s, buf;

                            void swap(ref int f1,ref int s1) {
                                buf = f1;
                                f1 = s1;
                                s1 = buf;
                            
                            }
                            
                            Console.WriteLine("Введите первое число:");
                            f = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите второе число:");
                            s = Convert.ToInt32(Console.ReadLine());
                            if (f > s) {
                                Console.WriteLine(f + "\t" + s);
                                swap(ref f, ref s);
                                Console.WriteLine(f + "\t" + s);
                            }
                            for (int i = f; i <= s; i++)
                            {
                                if ((i % 2) == 0) {
                                    Console.WriteLine(i);
                                }
                            }
                            break;
                      }
                }
            }            
        }
    }
}
