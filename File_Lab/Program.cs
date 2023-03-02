using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Lab
{
    class Program
    {
        public static void PrimeNumbers(int n, string filePath)
        {
            bool isPrime = IsPrime(n);
            if (isPrime)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write($"{n}, ");
                }
            }
        }
        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;

            if (n % 2 == 0 || n % 3 == 0) return false;

            for (int i = 5; i * i <= n; i = i + 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void Fibonacci(int n, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                if (IsFibonacciNumber(n))
                {
                    writer.Write($"{n}, ");
                }
            }
        }
        public static bool IsFibonacciNumber(int n)
        {
            return IsPerfectSquare(5 * n * n + 4) || IsPerfectSquare(5 * n * n - 4);
        }
        public static bool IsPerfectSquare(int n)
        {
            int sqrt = (int)Math.Sqrt(n);
            return sqrt * sqrt == n;
        }


        static void Main(string[] args)
        {
            //1
            string primeFilePath = "primes.txt";
            string fibonacciFilePath = "fibonacci.txt";

            Random random = new Random();
            int[] array = new int[100];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 1000);
                PrimeNumbers(i, primeFilePath);
                Fibonacci(i, fibonacciFilePath);
            }

            //2
            string filePath = @"C:\Programming\File_Lab\File_Lab\bin\Debug\Word_substitution.txt"; // путь к файлу
            string searchWord = "are";
            string replaceWord = "ARE";
            string fileContent = File.ReadAllText(filePath);

            string newContent = fileContent.Replace(searchWord, replaceWord);
            File.WriteAllText(filePath, newContent);

            //3
            string sourceFilePath = @"C:\Programming\File_Lab\File_Lab\bin\Debug\Words_for_moderation.txt"; // путь к файлу со словами для замены            

            string[] words = File.ReadAllLines(sourceFilePath);

            string text = File.ReadAllText(filePath);
            foreach (string word in words)
            {
                text = text.Replace(word, new string('*', word.Length));
            }

            File.WriteAllText(filePath, text);

            //4
            Console.Write("Введите путь к файлу: ");
            string newfilePath = Console.ReadLine();

            string newfileContent = File.ReadAllText(newfilePath);

            char[] charArray = newfileContent.ToCharArray();
            Array.Reverse(charArray);
            string reversedContent = new string(charArray);

            string reversedFilePath = Path.GetDirectoryName(newfilePath) + "\\" +
                Path.GetFileNameWithoutExtension(newfilePath) + "_reversed" +
                Path.GetExtension(newfilePath);
            File.WriteAllText(reversedFilePath, reversedContent);

            Console.WriteLine("Файл успешно перевернут и сохранен как {0}", reversedFilePath);

            //5
            Random rand = new Random();
            int[] numbers = new int[100000];
            for (int i = 0; i < 100000; i++)
            {
                numbers[i] = rand.Next(-100000, 100000);
            }

            using (StreamWriter writer = new StreamWriter("numbers.txt"))
            {
                foreach (int num in numbers)
                {
                    writer.WriteLine(num);
                }
            }
            using (StreamReader reader = new StreamReader("numbers.txt"))
            {
                int posCount = 0;
                int negCount = 0;
                int twoDigitCount = 0;
                int fiveDigitCount = 0;

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int num = int.Parse(line.Trim());

                    if (num > 0)
                    {
                        posCount++;
                    }
                    else if (num < 0)
                    {
                        negCount++;
                    }

                    if (num >= 10 && num <= 99)
                    {
                        twoDigitCount++;
                    }

                    if (num >= 10000 && num <= 99999)
                    {
                        fiveDigitCount++;
                    }
                }

                Console.WriteLine("Количество положительных чисел: {0}", posCount);
                Console.WriteLine("Количество отрицательных чисел: {0}", negCount);
                Console.WriteLine("Количество двузначных чисел: {0}", twoDigitCount);
                Console.WriteLine("Количество пятизначных чисел: {0}", fiveDigitCount);
            }
        }
    }
}

