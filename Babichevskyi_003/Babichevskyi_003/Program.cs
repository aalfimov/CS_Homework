using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babichevskyi_003
{
    internal class Program
    {
        class WebSite {
            string name, link, description, ip;
            
            public string Name {
                get { return name; }
                set { name = value; }
            }
            public string Link
            {
                get { return link; }
                set { link = value; }
            }
            public string Description
            {
                get { return description; }
                set { description = value; }
            }
            public string IP
            {
                get { return ip; }
                set { ip = value; }
            }

            public void Print() {
                Console.WriteLine("Название сайта: " + Name);
                Console.WriteLine("Ссылка сайта: " + Link);
                Console.WriteLine("Описание сайта: " + Description);
                Console.WriteLine("IP сайта: " + IP);
            }
        }


        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Введите номер задания: ");
                int y = Convert.ToInt32(Console.ReadLine());

                switch (y)
                {
                    case 1:
                        {
                            void Square(int _length, char _symbol) {
                                for (int i = 0; i < _length; i++) {
                                    for (int k = 0; k < _length; k++)
                                    {
                                        Console.Write(_symbol);
                                    }
                                    Console.WriteLine();
                                }
                            }

                            Console.WriteLine("Введите длину квадрата: ");
                            int length = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите символ квадрата: ");
                            char symbol = Convert.ToChar(Console.ReadLine());

                            Square(length, symbol);
                            break;
                        }

                    case 2:
                        {
                            bool PalindromChecker(int _number) {
                                string number_str = Convert.ToString(_number);
                                if (number_str[0] == number_str[3] &&
                                    number_str[1] == number_str[2]
                                    ) { return true; }
                                else return false;
                            }
                            Console.WriteLine("Введите число: ");
                            int number = Convert.ToInt32(Console.ReadLine());
                            if (PalindromChecker(number) == true) Console.WriteLine("Число является палиндромом");
                            else Console.WriteLine("Число не является палиндромом");
                            break;
                        }

                    case 3:
                        {
                            void Filter(int[] tmp_arr,int[] tmp_arr_filter) {

                                string _arr = Convert.ToString(tmp_arr);
                                string _arr_filter = Convert.ToString(tmp_arr_filter);


                                for (int  i = 0;  i < _arr_filter.Length;  i++)
                                {
                                    for (int k = 0; k < _arr.Length; k++)
                                    {
                                        if (_arr[k] == _arr_filter[i]) _arr[k] = ' ';
                                    }
                                }

                                
                            }

                            int[] arr = new int[5];
                            int[] arr_filter = new int[5];
                            Console.Write("Введите массив: ");
                            for (int i = 0; i < 5; i++)
                            {
                                arr[i] = Convert.ToInt32(Console.ReadLine());
                            }

                            Console.Write("Введите фильтр - массив: ");
                            for (int i = 0; i < 5; i++)
                            {
                                arr_filter[i] = Convert.ToInt32(Console.ReadLine());
                            }

                            Filter( arr,arr_filter);

                            break;
                        }

                    case 4:
                        {
                            WebSite MySite = new WebSite();
                            Console.Write("Введите имя сайта: ");
                            MySite.Name = Console.ReadLine();
                            Console.Write("Введите ссылку сайта: ");
                            MySite.Link = Console.ReadLine();
                            Console.Write("Введите описание сайта: ");
                            MySite.Description = Console.ReadLine();
                            Console.Write("Введите IP сайта: ");
                            MySite.IP = Console.ReadLine();

                            MySite.Print();

                            break;
                        }

                   
                }
            }
        }
    }
}
