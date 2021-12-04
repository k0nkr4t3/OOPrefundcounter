using System;


namespace OOPrefundcounter
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Refund Counter V1.";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Program.Drivers();
        }
        static void Drivers() 
        {
            Program.Intro();
            Program.Calc_refund();
            Console.Read();
        }

        static void Intro()
        {
            Console.Clear();
            Console.WriteLine("\n- A tizedeseknél pont helyett vesszőt használj.");
            Console.WriteLine("- A kalkulátor a hónapokat 30 nappal számolja.");
        }

        static int DateCalculator()
        {
            Console.Write("\nA vásárlás dátuma: ");
            DateTime dateofpurchase = Convert.ToDateTime(Console.ReadLine());
            Console.Write("A refund kérés dátuma: ");
            DateTime dateofrefund = Convert.ToDateTime(Console.ReadLine());

            DayCounter days = new();
            days.purchase = dateofpurchase;
            days.refund = dateofrefund;

            int numberofdays = days.Calculator();
            return numberofdays;
        }

        private static double Calc_refund() 
        {
            int tmp_value = DateCalculator();

            Console.Write("\nA fizetett membership ára: ");
            double membPrice = Convert.ToDouble(Console.ReadLine());
            Console.Write($"A fizetés napjától eltelt napok száma: {tmp_value} ");
            Console.Write("\nA megvásárolt csomag hossza napokban: ");
            int membLong = Convert.ToInt32(Console.ReadLine());

            RefundCalc reca = new();
            reca.mp = membPrice;
            reca.dc = tmp_value;
            reca.ml = membLong;

            double value = reca.Refcalc();
            Console.Write($"\n\nA refund összege: {value}");
            Console.ReadLine();
            Program.Drivers();
            return value;
        }
    }
    class DayCounter
    {
        public DateTime purchase;
        public DateTime refund;
        public int Calculator()
        {
            int dates = Convert.ToInt32((refund - purchase).TotalDays) + 1;
            return dates;
        }
    }
    class RefundCalc
    {
        public double mp;
        public int dc;
        public int ml;

        public double Refcalc()
        {
            double valueRefund = mp - ((mp / ml) * dc);
            return valueRefund;
        }
    }
}
