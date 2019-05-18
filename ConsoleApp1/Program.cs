using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = 0;

            bool start = false;
            //здесь будет храниться количество значений каждого множества 
            int nA, nB, nC;
            //множетва
            List<int> A = new List<int>(); //множество А
            List<int> B = new List<int>(); //множество B
            List<int> C = new List<int>(); //множество C

            do
            {
                Console.WriteLine("Реализация Абстрактных типов данных и операций над ними. Множества \r\n");
                Console.WriteLine("Выберите режим работы программы:");
                Console.WriteLine("1: Интерактивный: данные вводятся в консоль с клавиатуры, результаты так же выводятся на консоль;");
                Console.WriteLine("2: Полуинтерактивный: включается, если при запуске программы обнаруживается файл input.txt, в котором находятся исходные (входные) данные, результаты выводятся так же на консоль;");
                Console.WriteLine("3: Неинтерактивный: включается, если при запуске программы обнаруживается файл data.txt, в котором находятся исходные (входные) данные, результаты выводятся в файл output.txt. Окно программы не показывается;");
                Console.WriteLine("4: Exit");
                number = Convert.ToInt32(Console.ReadLine());

                switch (number)
                {
                    case 1:
                        Console.WriteLine("Вы выбрали Интерактивный вариант реализации\r\n");

                        int currint;

                        do
                        {

                            Console.Clear();
                            Console.Write("Введите размерность множества A: ");

                        } while (!int.TryParse(Console.ReadLine(), out currint));

                        nA = currint;

                        for (int i = 0; i < nA; i++)
                        {

                            Console.Write("Введите элемент {0}: ", i + 1);

                            if (int.TryParse(Console.ReadLine(), out currint))
                            {
                                A.Add(currint);
                            }
                            else --i;


                        }

                        do
                        {

                            Console.Clear();
                            Console.Write("Введите размерность миножества B: ");

                        } while (!int.TryParse(Console.ReadLine(), out currint));

                        nB = currint;

                        for (int j = 0; j < nA; j++)
                        {

                            Console.Write("Введите элемент {0}: ", j + 1);

                            if (int.TryParse(Console.ReadLine(), out currint))
                            {
                                B.Add(currint);
                            }
                            else --j;
                        }

                        do
                        {

                            Console.Clear();
                            Console.Write("Введите размерность миножества C: ");

                        } while (!int.TryParse(Console.ReadLine(), out currint));

                        nC = currint;
                        for (int k = 0; k < nC; k++)
                        {

                            Console.Write("Введите элемент {0}: ", k + 1);

                            if (int.TryParse(Console.ReadLine(), out currint))
                            {
                                C.Add(currint);
                            }
                            else --k;
                        }

                        SetsResult(A, B, C);


                        break;
                    case 2:
                        Console.WriteLine("Вы выбрали Полуинтерактивный вариант реализации");

                        string path = @"input.txt";


                        try
                        {
                            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                            {
                                var number_line = 0;
                                string line;
                                while ((line = sr.ReadLine()) != null)
                                {

                                    number_line++;
                                    int[] ArrLine = new int[line.Length];
                                 
                                    for (var i = 0; i < line.Length; i++)
                                    {
             
                                        ArrLine[i] = Convert.ToInt32(line.Substring(i,1));
                                      
                                    }

                                    switch (number_line)
                                    {
                                        case 1:
                                            A = ArrLine.ToList();
                                            break;
                                        case 2:
                                            B = ArrLine.ToList();
                                            break;
                                        case 3:
                                            C = ArrLine.ToList();
                                            break;
                                        default:
                                            Console.Write("Привышенно количество множеств строк в файле");
                                            break;
                                    }
                                }

                            }


                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        SetsResult(A,B,C);

                        break;
                    case 3:
                        Console.WriteLine("Вы выбрали Неинтерактивный вариант реализации");
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Вы ввели неверное значение повторите попытку или закройте  приложение\r\n");
                        start = true;
                        break;
                }

            }while (start);


                Console.ReadKey();
           
        }


        static void SetsResult(List<int> A, List<int> B, List<int> C)
        {
            var easyset1 = new LotsOf<int>(A.ToArray());
            var easyset2 = new LotsOf<int>(B.ToArray());
            var easyset3 = new LotsOf<int>(C.ToArray());

            //var easyset1 = new LotsOf<int>(new int[] {1,2,3,4,5});
            //var easyset2 = new LotsOf<int>(new int[] {4,5,6,7,8 });
            //var easyset3 = new LotsOf<int>(new int[] {3,4,5});

            Console.Write("Union - операция объединения: ");
            foreach (var item in easyset1.Union(easyset2))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\r\n");

            Console.Write("Intersection - операция пересечения: ");
            foreach (var item in easyset1.Intersection(easyset2))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\r\n");

            Console.Write("Difference - операция разности A \\ B: ");
            foreach (var item in easyset1.Difference(easyset2))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\r\n");

            Console.Write("Difference - операция разности B \\ A: ");
            foreach (var item in easyset2.Difference(easyset1))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\r\n");

            Console.Write("Subset - операция определения подмножества A Subset C: ");
            Console.Write(easyset1.Subset(easyset3));
            Console.WriteLine("\r\n");

            Console.Write("Subset - операция определения подмножества C Subset A: ");
            Console.Write(easyset3.Subset(easyset1));
            Console.WriteLine("\r\n");

            Console.Write("Subset - операция определения подмножества C Subset B: ");
            Console.Write(easyset3.Subset(easyset2));
            Console.WriteLine("\r\n");

            Console.Write("SummetricDifference - операция семметричной разности: ");
            foreach (var item in easyset1.SummetricDifference(easyset2))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\r\n");

        }



    }
 }
