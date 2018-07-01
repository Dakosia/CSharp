using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace FirstWeekPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose the number of problem (1-10)");
            int choose = Int32.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    ProblemNumberOne();
                    break;
                case 2:
                    ProblemNumberTwo();
                    break;
                case 3:
                    ProblemNumberThree();
                    break;
                case 4:
                    ProblemNumberFour();
                    break;
                case 5:
                    ProblemNumberFive();
                    break;
                case 6:
                    ProblemNumberSix();
                    break;
                case 7:
                    ProblemNumberSeven();
                    break;
                case 8:
                    ProblemNumberEight();
                    break;
                case 9:
                    ProblemNumberNine();
                    break;
                case 10:
                    ProblemNumberTen();
                    break;
                default:
                    Console.WriteLine("No such problem");
                    break;
            }
            Console.ReadLine();
        }

        //Problem #1
        static void ProblemNumberOne()
        {
            Console.WriteLine("Enter string to count upper characters in it");
            string str = Console.ReadLine();
            int UpperCharsCnt = 0;
            foreach (char item in str)
            {
                if (char.IsUpper(item))
                {
                    UpperCharsCnt++;
                }
            }
            Console.WriteLine(UpperCharsCnt);
            Console.ReadLine();
        }

        //Problem #2
        static void ProblemNumberTwo()
        {
            Console.WriteLine("Enter string to count digits in it");
            string str = Console.ReadLine();
            int DigitsCnt = 0;
            foreach (char item in str)
            {
                if (char.IsDigit(item))
                {
                    DigitsCnt++;
                }
            }
            Console.WriteLine(DigitsCnt);
            Console.ReadLine();
        }
        
        //Problem #3
        static void Calculator(int a, int b, int ScaleOfNotation)
        {
            string addition = Convert.ToString(a + b, ScaleOfNotation);
            string subtraction;
            bool AnswerIsNegative = false;
            if (a > b)
                subtraction = Convert.ToString(a - b, ScaleOfNotation);
            else
            {
                subtraction = Convert.ToString(b - a, ScaleOfNotation);
                AnswerIsNegative = true;
            }
            string multiplication = Convert.ToString(a * b, ScaleOfNotation);
            string division = Convert.ToString(a / b, ScaleOfNotation);
            string mod = Convert.ToString(a % b, ScaleOfNotation);
            int p = Convert.ToInt32(Math.Pow(a, b));
            string power = Convert.ToString(p, ScaleOfNotation);

            string a1 = Convert.ToString(a, ScaleOfNotation);
            string b1 = Convert.ToString(b, ScaleOfNotation);

            #region
            Console.WriteLine("Base = " + ScaleOfNotation);
            Console.WriteLine(a1 + " + " + b1 + " = " + addition);
            if (AnswerIsNegative == false)
                Console.WriteLine(a1 + " - " + b1 + " = " + subtraction);
            else
                Console.WriteLine(a1 + " - " + b1 + " = " + "-" + subtraction);
            Console.WriteLine(a1 + " * " + b1 + " = " + multiplication);
            Console.WriteLine(a1 + " / " + b1 + " = " + division);
            Console.WriteLine(a1 + " % " + b1 + " = " + mod);
            Console.WriteLine(a1 + " ^ " + b1 + " = " + power);
            Console.WriteLine();
            #endregion

            #region String.Format and pattern {n}
            Console.WriteLine(String.Format("Base = {0}", ScaleOfNotation));
            Console.WriteLine(String.Format("{0} + {1} = {2}", a1, b1, addition));
            if (AnswerIsNegative == false)
                Console.WriteLine(String.Format("{0} - {1} = {2}", a1, b1, subtraction));
            else
                Console.WriteLine(String.Format("{0} - {1} = -{2}", a1, b1, subtraction));
            Console.WriteLine(String.Format("{0} * {1} = {2}", a1, b1, multiplication));
            Console.WriteLine(String.Format("{0} / {1} = {2}", a1, b1, division));
            Console.WriteLine(String.Format("{0} % {1} = {2}", a1, b1, mod));
            Console.WriteLine(String.Format("{0} ^ {1} = {2}", a1, b1, power));
            Console.WriteLine();
            #endregion

            #region String Interpolation
            Console.WriteLine($"Base = {ScaleOfNotation}");
            Console.WriteLine($"{a1} + {b1} = {addition}");
            if (AnswerIsNegative == false)
                Console.WriteLine($"{a1} - {b1} = {subtraction}");
            else
                Console.WriteLine($"{a1} - {b1} = -{subtraction}");
            Console.WriteLine($"{a1} * {b1} = {multiplication}");
            Console.WriteLine($"{a1} / {b1} = {division}");
            Console.WriteLine($"{a1} % {b1} = {mod}");
            Console.WriteLine($"{a1} ^ {b1} = {power}");
            Console.WriteLine();
            #endregion
        }
        static void ProblemNumberThree()
        {
            Console.WriteLine("Enter a:");
            int a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter b:");
            int b = Int32.Parse(Console.ReadLine());
            //Console.WriteLine("Enter scale of notation");
            //int ScaleOfNotation = Int32.Parse(Console.ReadLine());

            Calculator(a, b, 2);
            Calculator(a, b, 8);
            Calculator(a, b, 10);
            Calculator(a, b, 16);
            Console.ReadLine();
        }

        //Problem #4
        static void ProblemNumberFour()
        {

        }

        //Problem #5
        static void ProblemNumberFive()
        {
            Console.OutputEncoding = ASCIIEncoding.UTF8;
            Console.WriteLine("Enter total amount of loan with overpayment");
            double LoanTotalAmountWithOverpayment = Double.Parse(Console.ReadLine());

            Console.WriteLine("Enter monthly income");
            double MonthlyIncome = Double.Parse(Console.ReadLine());

            Console.WriteLine("Enter percentage of salary for loan");
            double PercentageOfSalaryForLoan = Double.Parse(Console.ReadLine());

            double MonthlyLoanPayment = MonthlyIncome * PercentageOfSalaryForLoan / 100;
            double MonthsToPayForLoan = Math.Ceiling(LoanTotalAmountWithOverpayment / MonthlyLoanPayment);
            Console.WriteLine("Loan term: " + MonthsToPayForLoan + " months");

            double DollarsExchangeRatio = 343.64;
            var USD = new CultureInfo("EN-us");
            string PaymentInDollars = String.Format(USD, "{0:C}", MonthlyLoanPayment / DollarsExchangeRatio);

            var KZT = new CultureInfo("KZ-kz");
            string PaymentInTenge = String.Format(KZT, "{0:C}", MonthlyLoanPayment);

            double RublesExchangeRatio = 5.43;
            var RUB = new CultureInfo("RU-ru");
            string PaymentInRubles = String.Format(RUB, "{0:C}", MonthlyLoanPayment / RublesExchangeRatio);

            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Month\t\t" + "Debt, USD\t" + "Debt, KZT\t" + "Debt, RUB\t" + "Payment, USD\t" + "Payment, KZT\t" + "Payment, RUB\t");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            double debt = LoanTotalAmountWithOverpayment;
            for (int i = 0; i < MonthsToPayForLoan; i++)
            {
                string currentMonth = DateTime.Now.AddMonths(i).ToString("MMMM yyyy");
                Console.Write(currentMonth + "\t");

                debt -= MonthlyLoanPayment;
                Console.Write(String.Format(USD, "{0:C}", debt / DollarsExchangeRatio) + "\t");
                Console.Write(String.Format(KZT, "{0:C}", debt) + "\t");
                Console.Write(String.Format(RUB, "{0:C}", debt / RublesExchangeRatio) + "\t");

                Console.Write(PaymentInDollars + "\t\t");
                Console.Write(PaymentInTenge + "\t");
                Console.Write(PaymentInRubles + "\t");
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        //Problem #6
        static void ProblemNumberSix()
        {
            Random rand = new Random();
            int x = rand.Next(1, 31);
            Console.WriteLine("Enter number from 1 to 30");
            int y = 0;
            while (y != x)
            {
                y = Int32.Parse(Console.ReadLine());
                if (y == x)
                    Console.WriteLine("You won");
                else if (y > x)
                    Console.WriteLine("Try smaller number");
                else
                    Console.WriteLine("Try bigger number");
            }
            Console.ReadLine();
        }

        //Problem #7
        static void ProblemNumberSeven()
        {
            Random rand = new Random();
            int x = rand.Next(1, 31);
            int MaximumNumberOfAttemtps = rand.Next(3, 7);
            Console.WriteLine("Enter your bet from $100 to $1000");
            int bet = Int32.Parse(Console.ReadLine());
            int MinimumAccountBalance = bet * 2 / 100;
            Console.WriteLine("Enter number from 1 to 30");
            int y = 0;
            int AttemtpsCnt = 0;
            while (y != x)
            {
                y = Int32.Parse(Console.ReadLine());
                MaximumNumberOfAttemtps--;
                AttemtpsCnt++;
                if (MaximumNumberOfAttemtps == 0 || bet < MinimumAccountBalance)
                {
                    Console.WriteLine("GAME OVER");
                    break;
                }
                if (y == x)
                {
                    if (AttemtpsCnt == 1)
                        Console.WriteLine("You won ${0}", bet + bet);
                    else if (AttemtpsCnt == 2)
                        Console.WriteLine("You won ${0}", bet + bet * 75 / 100);
                    else if (AttemtpsCnt == 3)
                        Console.WriteLine("You won ${0}", bet + bet * 50 / 100);
                    else if (AttemtpsCnt == 4)
                        Console.WriteLine("You won ${0}", bet + bet * 25 / 100);
                    else
                        Console.WriteLine("You won ${0}", bet);
                }
                else if (y > x)
                    Console.WriteLine("Try smaller number");
                else
                    Console.WriteLine("Try bigger number");
                bet /= 2;
            }
            Console.ReadLine();
        }

        //Problem #8
        static void ProblemNumberEight()
        {

        }

        //Problem #9
        static void ProblemNumberNine()
        {

        }

        //Problem #10
        static private Random gen = new Random();
        static DateTime RandomDay()
        {
            DateTime start = new DateTime(1918, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
        static void ProblemNumberTen()
        {
            Tuple<string, DateTime>[] customers =
            {
                Tuple.Create("Aina", RandomDay()),
                Tuple.Create("Ami", RandomDay()),
                Tuple.Create("Asuka", RandomDay()),
                Tuple.Create("Chihiro", RandomDay()),
                Tuple.Create("Daiki", RandomDay()),
                Tuple.Create("Fumi", RandomDay()),
                Tuple.Create("Hana", RandomDay()),
                Tuple.Create("Haruhi", RandomDay()),
                Tuple.Create("Hinata", RandomDay()),
                Tuple.Create("Ichigo", RandomDay()),
                Tuple.Create("Jin", RandomDay()),
                Tuple.Create("Kaito", RandomDay()),
                Tuple.Create("Mamoru", RandomDay()),
                Tuple.Create("Mao", RandomDay()),
                Tuple.Create("Mie", RandomDay()),
                Tuple.Create("Mitsuki", RandomDay()),
                Tuple.Create("Nagisa", RandomDay()),
                Tuple.Create("Rei", RandomDay()),
                Tuple.Create("Ryu", RandomDay()),
                Tuple.Create("Satsuki", RandomDay()),
                Tuple.Create("Shiro", RandomDay()),
                Tuple.Create("Sora", RandomDay()),
                Tuple.Create("Tamaki", RandomDay()),
                Tuple.Create("Yui", RandomDay()),
                Tuple.Create("Yuki", RandomDay())
            };

            for (int i = 0; i < customers.Length; i++)
            {
                if (customers[i].Item2.Month == DateTime.Now.Month)
                {
                    int discount = (DateTime.Now.Year - customers[i].Item2.Year) / 10 * 5;
                    if (customers[i].Item2.Day == DateTime.Now.Day)
                        discount += 5;
                    Console.WriteLine("This month {0} has {1}% discount", customers[i].Item1, discount);
                }
            }
            Console.ReadLine();
        }
    }
}
