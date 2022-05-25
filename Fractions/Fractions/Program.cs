using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction a = new Fraction(4, -8);
            Fraction b = new Fraction(2, 5);
            Fraction z = new Fraction(81, 17, 21);
            Fraction c;
            Console.WriteLine("Представление в виде обыкновенной дроби:" + a.ToString() + " " + b.ToString());
            Console.Write("Введите знак операции: ");
            string sign = Console.ReadLine();
            string reznak = "+";
            Fraction d = new Fraction(4, 7);
            Console.WriteLine($"Индекс 0: {d[0]}");
            Console.WriteLine($"Индекс 1: {d[1]}");
            a.Change += ChangeNum;
            a.Change += ChangeDenum;
            a.Numinator_2 = 2;
            a.Denominator_2 = 5;
            switch (sign)
            {
                case "+":
                    c = a + b;
                    Console.WriteLine("Проверка на сложение: " + a.ToString() + "+" + b.ToString() + "=" + c.ToString());
                    if ((c.Numinator_2 < 0))
                    {
                        reznak = "-";
                    }
                    Console.WriteLine("Знак дроби: " + reznak);
                    Console.WriteLine("Десятичная дробь: " + c.ToDouble());
                    break;
                case "-":
                    c = a - b;
                    Console.WriteLine("Проверка на вычитание: " + a.ToString() + "-" + b.ToString() + "=" + c.ToString());
                    if ((c.Numinator_2 < 0))
                    {
                        reznak = "-";
                    }
                    Console.WriteLine("Знак дроби: " + reznak);
                    Console.WriteLine("Десятичная дробь: " + c.ToDouble());
                    break;
                case "*":
                    c = a * b;
                    Console.WriteLine("Проверка на умножение: " + a.ToString() + "*" + b.ToString() + "=" + c.ToString());
                    if ((c.Numinator_2 < 0))
                    {
                        reznak = "-";
                    }
                    Console.WriteLine("Знак дроби: " + reznak);
                    Console.WriteLine("Десятичная дробь: " + c.ToDouble());
                    break;
                case "/":
                    c = a / b;
                    Console.WriteLine("Проверка на деление: " + a.ToString() + "/" + b.ToString() + "=" + c.ToString());
                    if ((c.Numinator_2 < 0))
                    {
                        reznak = "-";
                    }
                    Console.WriteLine("Знак дроби: " + reznak);
                    Console.WriteLine("Десятичная дробь: " + c.ToDouble());
                    break;
                default:
                    Console.WriteLine("Неизвестная операция");
                    break;
            }
            Console.ReadKey();
        }
        public static void ChangeNum(Fraction fraction, int num)
        {
            Console.WriteLine("Числитель изменился");
        }
        
        public static void ChangeDenum(Fraction fraction, int num)
        {
            Console.WriteLine("Знаменатель изменился");
        }
    }
}
