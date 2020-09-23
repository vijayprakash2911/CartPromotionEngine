using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CartPromotionEngine
{
    public static class Program
    {
        public static int A = 50;
        public static int B = 30;
        public static int C = 20;
        public static int D = 15;
        public static int PromotionsCalculation;

        public static int Promotions(string UnitName, int UnitsRequired)
        {
            int remainder;
            int quotient;

            if (UnitName == "a")
            {
                quotient = Math.DivRem(UnitsRequired, 3, out remainder);
                PromotionsCalculation = (quotient * 130) + (remainder * A);
            }
            if (UnitName == "b")
            {
                quotient = Math.DivRem(UnitsRequired, 2, out remainder);
                PromotionsCalculation = (quotient * 45) + (remainder * B);
            }
            if (UnitName == "c")
            {
                PromotionsCalculation = UnitsRequired * C;
            }
            if (UnitName == "d")
            {
                PromotionsCalculation = UnitsRequired * D;
            }
            return PromotionsCalculation;
        }

        public static int Calculate(string UnitName, int UnitsRequired)
        {
            int TotalAmount = Promotions(UnitName.ToLower(), UnitsRequired);
            return TotalAmount;
        }

        public static void Main(string[] args)
        {
            int Output = 0;
            Dictionary<string, int> dict = new Dictionary<string, int>();
            Console.WriteLine("Press Enter key to Continue:");
            string Entry = Console.ReadLine();
            while (Entry != "q")
            {
                Console.WriteLine("Enter Unit:");
                string Unit = Console.ReadLine();
                if (Unit == "")
                {
                    Console.WriteLine("Enter Unit:");
                    Unit = Console.ReadLine();
                }
                Console.WriteLine("Press Enter key to Continue or Type 'q' to exit : ");
                Entry = Console.ReadLine();
            }
            if ((dict.ContainsKey("c") && dict.ContainsKey("d")))
            {
                foreach (var dic in dict)
                {
                    if ((dic.Key == "c"))
                    {
                        Output += 0;
                    }
                    else if (dic.Key == "d")
                    {
                        Output += 30;
                    }
                    else
                    {
                        int res = Calculate(dic.Key, dic.Value);
                        Output += res;
                    }
                }
            }
            else
            {
                foreach (var dic in dict)
                {
                    int res = Calculate(dic.Key, dic.Value);
                    Output += res;
                }
            }
            Console.WriteLine("Total amount of Units purchased: {0} ", Output);
            Console.ReadLine();
        }
    }
}
