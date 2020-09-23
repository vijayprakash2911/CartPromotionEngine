using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CartPromotionEngine
{
    //Class to calculate Promotions for SKU
    public static class Program
    {
        //Value of Unit A
        public static int A = 50;
        //Value of Unit B
        public static int B = 30;
        //Value of Unit C
        public static int C = 20;
        //Value of Unit D
        public static int D = 15;
        //Value for Promotions Calculation
        public static int PromotionsCalculation;

        //Method to define and calculate Promotions
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

        //Method to return the amount of one Promotion
        public static int Calculate(string UnitName, int UnitsRequired)
        {
            int TotalAmount = Promotions(UnitName.ToLower(), UnitsRequired);
            return TotalAmount;
        }

        //Main method to get user input and returns the total amount in command window
        public static void Main(string[] args)
        {
            //Value of Output, intially it was 0
            int Output = 0;
            //Dictionary to story user inputs
            Dictionary<string, int> dict = new Dictionary<string, int>();
            Console.WriteLine("Press Enter key to Continue:");
            string Entry = Console.ReadLine();
            //To quit getting User input, press "q" and enter
            while (Entry != "q")
            {
                Console.WriteLine("Enter Unit:");
                string Unit = Console.ReadLine();
                if (Unit == "")
                {
                    Console.WriteLine("Enter Unit:");
                    Unit = Console.ReadLine();
                }
                int UnitReq = 0;
                if ((Unit != "") || (Unit.GetType().Equals(typeof(string))))
                {
                    //Regex to get the match the units available
                    Match m = Regex.Match(Unit, @"[a-dA-D]");
                    if (m.Success)
                    {
                        Console.WriteLine("Enter Unit Required:");
                        UnitReq = Convert.ToInt32(Console.ReadLine());
                        dict.Add(Unit.ToLower(), UnitReq);
                    }
                    //Writes to user, that no units is available
                    else
                    {
                        Console.WriteLine("The Unit is not available");
                    }
                }
                //Writes to user, that no units is available
                else
                {
                    Console.WriteLine("The Unit is not available");
                }
                Console.WriteLine("Press Enter key to Continue or Type 'q' to exit : ");
                Entry = Console.ReadLine();
            }
            //Condition to consolidate all the input Units if it contains units both C & D to give SKUs
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
            //Processed Output
            Console.WriteLine("Total amount of Units purchased: {0} ", Output);
            Console.ReadLine();
        }
    }
}
