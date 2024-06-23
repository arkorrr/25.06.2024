using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace _25._06._2024
{
    internal class Program
    {
        static int col = 5;
        static int line = 4;
        static void Main(string[] args)
        {
            //Task1
            //Создать двумерный массив целых чисел размером 5х4. 
            //Заполнить его случайными числами. Найти максимальный и минимальный элемент в массиве. Найти максимальный и минимальный элемент для каждой строки массива.
            var array = new int[col, line];
            Random rand = new Random();

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < line; j++)
                {
                    array[i, j] = rand.Next(30, 60);
                    Console.Write("{0,3}", array[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Минимум: " + GetMin(array));
            Console.WriteLine("Максимум: " + GetMax(array));

            //Task2
            //Напишите программу, которая принимает строку от пользователя и меняет регистр всех букв в этой строке на противоположный 
            //(то есть большие буквы становятся маленькими, а маленькие буквы - большими).
            Console.Write("Enter a string: ");
            string str = Console.ReadLine();
            char[] arr = str.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (char.IsLower(arr[i]))
                {
                    arr[i] = char.ToUpper(arr[i]);
                }
                else if (char.IsUpper(arr[i]))
                {
                    arr[i] = char.ToLower(arr[i]);
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
            }
            //Task3 Напишите программу, которая принимает строку, содержащую несколько слов, и разделяет ее на отдельные слова.
            Console.Write("Enter a string: ");
            string strr = Console.ReadLine();
            string[] words = strr.Split(' ');

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            //Task4 Дан текст. Верно ли, что в нем есть пять идущих подряд одинаковых символов? Вывести соответствующее сообщение.
            string inputText = "How are you.....";
            bool contains4Repeat = IsContains4Repeat(inputText);

            if (contains4Repeat)
            {
                Console.WriteLine("В тексте есть пять идущих подряд одинаковых символов.");
            }
            else
            {
                Console.WriteLine("В тексте нет пяти идущих подряд одинаковых символов.");
            }
            //Task5 Описать структуру Client, содержащую поля: код клиента; ФИО; адрес; телефон; количество заказов, осуществленных клиентом; 
            // общая сумма заказов клиента. Включите в структуру конструктор с параметрами и метод Print(). Создать экземпляр структуры.
            Client client = new Client(111, "1111", "1111", 1111, 22222, 3333);
            client.Print();
            //Task6
            //Описать структуру Request, содержащую поля: код заказа; клиент; дата заказа; 
            //перечень заказанных товаров; сумма заказа. Включите в структуру конструктор с параметрами и метод Print(). Создать экземпляр структуры.
            Request request = new Request(111,111,111,111);
            request.Print();
        }
        struct Request
        {
            public int IdOfOrder;
            public int dateOfOrder;
            public int order;
            public int sumOfOrder;
            public Request(int id,int date,int ord, int sumOrd)
            {
                IdOfOrder = id;
                dateOfOrder = date;
                order = ord;
                sumOfOrder = sumOrd;
            }
            public void Print()
            {
                Console.WriteLine($"Id of Order = {IdOfOrder}, Date of Order = {dateOfOrder}, Order = {order}, Sum of Order = {sumOfOrder}");
            }

        }
        struct Client
        {
            public int Id;
            public string FullName;
            public string Address;
            public int number;
            public int orders;
            public int SumOfOrders;
            public Client(int id, string fullname, string address, int num, int ord, int sumOrd)
            {
                Id = id;
                FullName = fullname;
                Address = address;
                number = num;
                orders = ord;
                SumOfOrders = sumOrd;
            }
            public void Print()
            {
                Console.WriteLine($"ID = {Id}, Name = {FullName}, Address = {Address}, Number = {number}, Orders = {orders},Sum of orders = {SumOfOrders}");
            }
        }
        public static bool IsContains4Repeat(string str)
        {
            Regex r = new Regex(@"(.)\1\1\1\1");
            return r.IsMatch(str);
        }
        private static int GetMax(int[,] mas)
        {
            int result = mas[0, 0];
            for (int i = 0; i < col; i++)
                for (int j = 0; j < line; j++)
                    if (result < mas[i, j])
                        result = mas[i, j];
            return result;
        }

        private static int GetMin(int[,] mas)
        {
            int result = mas[0, 0];
            for (int i = 0; i < col; i++)
                for (int j = 0; j < line; j++)
                    if (result > mas[i, j])
                        result = mas[i, j];
            return result;
        }
    }
}
