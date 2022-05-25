using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    class Fraction
    {
        private int numerator = 0;
        private int denominator = 0;
        public Fraction(int c)
        {
            this.numerator = c;
            this.denominator = 1;
        }

        public Fraction(int c, int z)
        {
            this.numerator = c;
            this.denominator = z;

        }
        public Fraction(int celoe, int c, int z)
        {
            this.numerator = celoe * z + c;
            this.denominator = z;
        }
        public char Sign { get; set; }
        public delegate void FractionChangeDelegate(Fraction fraction, int num);

        public event FractionChangeDelegate Change;
        public int Numinator_2
        {
            get
            {
                return numerator;
            }

            set
            {
                if (Change != null)
                {
                    Change(this, value);
                }
                numerator = value;
            }
        }
        public int Denominator_2
        {
            get
            {
                return denominator;
            }

            set
            {
                if (Change != null)
                    Change(this, value);

                denominator = value;
            }
        }
        public double ToDouble()
        {
            return (double)(numerator) / denominator;
        }

        public override string ToString()
        {
            return "(" + numerator.ToString() + "/" + denominator.ToString() + ")";
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction l = new Fraction(1, 1);
            l.numerator = (a.numerator * b.denominator + a.denominator * b.numerator);
            l.denominator = a.denominator * b.denominator;
            Fraction.Reduction(l);//сокращаем дробь
            return l;

        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction l = new Fraction(1, 1);
            l.numerator = (a.numerator * b.denominator - a.denominator * b.numerator);
            l.denominator = a.denominator * b.denominator;
            Fraction.Reduction(l);
            return
            l;

        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            Fraction l = new Fraction(1, 1);
            l.numerator = (a.numerator * b.numerator);
            l.denominator = a.denominator * b.denominator;
            Fraction.Reduction(l);
            return l;

        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            Fraction l = new Fraction(1, 1);
            l.numerator = (a.numerator / b.numerator);
            l.denominator = a.denominator / b.denominator;
            Fraction.Reduction(l);
            return l;
        }
        //процедура по сокращению дроби
        public static Fraction Reduction(Fraction a)
        {
            double max = 0;
            
            if (a.numerator > a.denominator)
                max = Math.Abs(a.denominator);// берем по модулю, что работало и с отрицательными
            else
                max = Math.Abs(a.denominator);
                                              
            for (double i = max; i >= 2; i--)
            {
                //такого числа, поделив на которое бы делилось без
                //остатка и на числитель и на знаменатель
                if ((a.numerator % i == 0) & (a.denominator % i == 0))
                {
                    a.numerator = Convert.ToInt32(a.numerator / i);
                    a.denominator = Convert.ToInt32(a.denominator / i);
                }

            }
            // Определяемся со знаком. Если в знаменателе минус, поднимаем его наверх
            if ((a.denominator < 0))
            {
                a.numerator = -1 * (a.numerator);
                a.denominator = Math.Abs(a.denominator);
            }
            return (a);
        }
        public int this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return numerator;
                }

                if (index == 1)
                {
                    return denominator;
                }

                return -1;
            }
        }
    }
}
