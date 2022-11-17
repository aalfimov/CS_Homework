using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babichevskyi_002
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Random rand = new Random();
                Console.WriteLine("Введите номер задания: ");
                int y = Convert.ToInt32(Console.ReadLine());

                switch (y)
                {
                    case 1:
                        {
                            int opA = 1, chetA = 0;
                            double maxB = 0, minB = 102, sumB = 0, opB = 1, NechetB = 0;
                            int[] A = new int[5];
                            double[,] B = new double[3, 4];                          

                            for (int i = 0; i < 5; i++)
                            {
                                Console.WriteLine("Введите "+ (i + 1) + " число массива: ");
                                A[i] = Convert.ToInt32(Console.ReadLine());
                            }

                            for (int i = 0; i < 3; i++)
                            {
                                for (int k = 0; k < 4; k++)
                                {
                                    B[i, k] = Convert.ToDouble(rand.Next(1000) / 10.0);
                                    sumB += B[i, k];
                                    opB *= B[i, k];
                                    if (k % 2 != 0) NechetB += B[i, k];
                                    if (B[i, k] > maxB) maxB = B[i, k];
                                    if (B[i, k] < minB) minB = B[i, k];
                                }
                            } 

                            Console.Write("Ваш массив: ");
                            
                            foreach (int i in A) Console.Write(i + " ");

                            Console.WriteLine("\n\nСгенерированый массив: \n");

                            for (int i = 0; i < 3; i++)
                            {                               
                                for (int k = 0; k < 4; k++)
                                {
                                    Console.Write(" " + B[i,k] + "\t");
                                }
                                Console.WriteLine("\n");
                            }

                            Console.WriteLine(
                                  " Максимальный элемент 1 массива: " + A.Max()
                                + "\n Минимальный элемент 1 массива: " + A.Min()
                                + "\n"
                                );                            

                            Console.WriteLine(
                                    " Максимальный элемент 2 массива: " + maxB
                                + "\n Минимальный элемент 2 массива: " + minB
                                + "\n"
                                );

                            for (int i = 0; i < 5; i++)
                            {
                                opA *= A[i];
                                if (A[i] % 2 == 0) chetA += A[i];
                            }

                            Console.WriteLine("Сумма элементов 1 массива: " + A.Sum());
                            Console.WriteLine("Сумма чётный элементов 1 массива: " + chetA);
                            Console.WriteLine("Произведение элементов 1 массива: " + opA);

                            Console.WriteLine("\nСумма элементов 2 массива: " + sumB);
                            Console.WriteLine("Сумма нечётных столбцов 2 массива: " + NechetB);
                            Console.WriteLine("Произведение элементов 2 массива: " + opB);

                            break;
                        }
                     
                    case 2: {

                            int[,] Arr = new int[5,5];
                            
                            int minID = 0, maxID = 0, sum = 0;

                            for (int i = 0; i < 5; i++)
                            {
                                int max = 0, min = 0;
                                
                                for (int k = 0; k < 5; k++)
                               {
                                    Arr[i, k] = rand.Next(-100, 100);
 
                                    if (min > Arr[i, k]) { min = Arr[i, k]; minID = k;}
                                    if (max < Arr[i, k]) { max = Arr[i, k]; maxID = k;}
                                }
                                for (int j = minID; j < maxID; j++) sum += Arr[i, j];
                            }
                            Console.WriteLine("\nСумма: " + sum);
                            break;
                        }
                       
                    case 3:  {

                            const string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

                            Console.Write("Введите текст: ");
                            string message = Console.ReadLine();
                            Console.Write("Введите ключ: ");
                            int secretKey = Convert.ToInt32(Console.ReadLine());

                            string CodeEncode(string text, int k){

                                var fullAlfabet = alfabet + alfabet.ToLower();
                                var LetQ = fullAlfabet.Length; var retVal = "";
                                for (int i = 0; i < text.Length; i++){
                                    var c = text[i];
                                    var ID = fullAlfabet.IndexOf(c);
                                    if (ID < 0) retVal += c.ToString();
                                    else{
                                        var codeID = (LetQ + ID + k) % LetQ;
                                        retVal += fullAlfabet[codeID];
                                    }
                                }
                                return retVal;
                            }
                            
                           string Encrypt(string plainMessage, int key)
                                => CodeEncode(plainMessage, key);
  
                             string Decrypt(string encryptedMessage, int key)
                                => CodeEncode(encryptedMessage, -key);

                            var encryptedText = Encrypt(message, secretKey);
                            Console.WriteLine("Зашифрованное сообщение: " +  encryptedText);
                            Console.WriteLine("Расшифрованное сообщение: " + Decrypt(encryptedText, secretKey));

                            break; 
                        }
                     
                    case 4: {
                            int[,] A = new int[3,3];
                            int[,] B = new int[3,3];
                            int key, addition, multipication;

                            Console.WriteLine("Первая матрица: ");

                            for (int i = 0; i < 3; i++)
                            {
                                for (int k = 0; k < 3; k++)
                                {
                                    A[i, k] = rand.Next(10);
                                    B[i, k] = rand.Next(10);
                                    Console.Write(" " + A[i, k] + "\t");
                                }
                                Console.WriteLine("\n");
                            }

                            Console.WriteLine("Вторая матрица: ");

                            for (int i = 0; i < 3; i++)
                            {
                                for (int k = 0; k < 3; k++)
                                {
                                    Console.Write(" " + B[i, k] + "\t");
                                }
                                Console.WriteLine("\n");
                            }

                            Console.Write("Введите число: ");
                            key = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Результат умножения 1 матрицы на число: ");

                            for (int i = 0; i < 3; i++)
                            {
                                for (int k = 0; k < 3; k++)
                                {
                                    A[i, k] *= key;
                                    Console.Write(" " + A[i, k] + "\t");
                                }
                                Console.WriteLine("\n");
                            }

                            Console.WriteLine("Результат сложения 1 и 2 матрицы: ");

                            for (int i = 0; i < 3; i++)
                            {
                                for (int k = 0; k < 3; k++)
                                {
                                    A[i, k] += B[i, k];
                                    Console.Write(" " + A[i, k] + "\t");
                                }
                                Console.WriteLine("\n");
                            }

                            Console.WriteLine("Результат произведения 1 и 2 матрицы: ");

                            for (int i = 0; i < 3; i++)
                            {
                                for (int k = 0; k < 3; k++)
                                {
                                    A[i, k] *= B[i, k];
                                    Console.Write(" " + A[i, k] + "\t");
                                }
                                Console.WriteLine("\n");
                            }
                            break;
                        }
                       
                    case 5: {
                            string operation;
                            int operation_final, r = 0, a = 0, b = 0, result = 0, id = 0; ;

                            Console.WriteLine(@"Введите выражение используя только ""+"" или ""-"": ");
                            operation = Console.ReadLine();
                            for (int i = 0; i < operation.Length; i++){
                                if (operation[i] == '*' || operation[i] == '/' || operation[i] == '%')
                                    Console.WriteLine("Введена недопустимая операция!");     
                            }
      
                            while (operation[r] != '+' && operation[r] != '-'){
                                if (operation[r] == 48) a *= 10;
                                if (r == 0) a += operation[r] - 48;
                                else a += (operation[r] - 48) * 10;
                                r++;
                            }
                            if (operation[r] == '+') id = 1;

                            for (int i = r + 1; i < operation.Length; i++){
                                if (operation[i] == 48) b *= 10;
                                if (i == r + 1) b += operation[i] - 48;
                                else b += (operation[i] - 48) * 10;
                            }

                            if (id == 0) result = a - b;
                            if (id == 1) result = a + b;

                            Console.WriteLine("Результат: " + result);
                            break;
                        }
                      
                    case 6:{
                            string text;
                            int k = 1;                            
                            Console.WriteLine("Введите текст: ");
                            text = Console.ReadLine();

                            if (text.Length == 0) Console.WriteLine("Вы не ввели текст!");
                            else {   
                                text = text[0].ToString().ToUpper() + text.Substring(1);
                                for (int i = 0; i < text.Length; i++)
                                {
                                    //if (i != 0 && text[i - k] == '.') Console.WriteLine(text);
                                    //if (i != 0 && text[i - k] == '.') text = text[i++].ToString().ToUpper() + text.Substring(i);
                                }
                            }
                            Console.WriteLine(text);
                            break;
                        }

                   case 7: {
                            string text = "To be, or not to be, that is the question,\r\nWhether 'tis nobler in the mind to suffer\r\nThe slings and arrows of outrageous fortune,\r\nOr to take arms against a sea of troubles,\r\nAnd by opposing end them? To die: to sleep;\r\nNo more; and by a sleep to say we end\r\nThe heart-ache and the thousand natural shocks\r\nThat flesh is heir to, 'tis a consummation\r\nDevoutly to be wish'd. To die, to sleep";
                            int blockCounter = 0;
                            string[] block = { "die", "be" };
                      
                            Console.WriteLine(text);
                            string str = "Top topfase";
                            string[] words = text.Split(new Char[] { ' ' });  

                            for (int i = 0; i <= words.Length - 1; i++) {
                                if (words[i] == "die") { words[i] = "***"; blockCounter++; }
                            }
                            
                            string res = "";
                            foreach (string s in words)
                                res += s + " "; 

                            break;
                        }
                }                
            }
        }
    }
}
