using System;
using System.Collections.Generic;

namespace pruebas_fibo
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("----------Menú Principal----------");
                Console.WriteLine("\n(1) = Naturals Counter \n(2) = Fibonacci\n(3) = Primes Counter\n(4) = Salir");
                int menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        Console.WriteLine("----------Contador de números naturales----------");
                        Console.Write("\nIntroduzca el número máximo: ");
                        int maxNum = int.Parse(Console.ReadLine());
                        var NaturalsNum = NaturalNum(maxNum);
                        foreach (var natural in NaturalsNum)
                        {
                            Console.WriteLine(natural);
                        }
                        break;
                    case 2:
                        Console.WriteLine("----------Secuencia Fibonacci----------");
                        var fibonacci = Fibonacci();
                        Console.Write("Introduzca la cantidad de números que desea ver: ");
                        int maxNum1 = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        for (int i = 0; i < maxNum1; i++)
                        {
                            Console.WriteLine(fibonacci());
                        }
                        break;
                    case 3:
                        Console.WriteLine("----------Contador de números primos----------");
                        Console.Write("\nIntroduce el número máximo: ");
                        int maxNum2 = int.Parse(Console.ReadLine());
                        var PrimesNum = PrimeNum(maxNum2);
                        foreach (var num in PrimesNum) Console.WriteLine(num);
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Entrada no válida.");
                        break;
                }
            }
        }

        static Func<int> Fibonacci()
        {
            int a = 0, b = 1;

            return delegate ()
            {
                int c = a, d = b;
                b += a;
                a = d;
                return c;
            };
        }
        static IEnumerable<int> PrimeNum(int num)
        {
            List<int> primeList = new List<int>();
            for (int i = 2; i <= num; i++)
            {
                primeList.Add(i);
            }

            for (int i = 0; i < primeList.Count; i++)
            {
                for (int j = 0; j < primeList.Count; j++)
                {
                    if (primeList[i] != primeList[j] && primeList[j] % primeList[i] == 0) primeList.RemoveAt(j);

                }
            }

            foreach (var j in primeList) yield return j;
        }

        static IEnumerable<int> NaturalNum(int cant)
        {
            for (int i = 0; i <= cant; i++)
            {
                yield return i;
            }
        }
    }
}