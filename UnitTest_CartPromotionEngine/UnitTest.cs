using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CartPromotionEngine;
using System.Collections.Generic;

namespace UnitTest_CartPromotionEngine
{
    [TestClass]
    public class UnitTest
    {
        //Unit Test Methods to test Scenario A
        [TestMethod]
        public void ScenarioA()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("A", 1);
            dict.Add("B", 1);
            dict.Add("C", 1);
            int expectedOutput = 100;
            int actualOutput = 0;
            foreach (var dic in dict)
            {
                var Output = Program.Calculate(dic.Key, dic.Value);
                actualOutput += Output;
            }
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        //Unit Test Methods to test Scenario B
        [TestMethod]
        public void ScenarioB()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("A", 5);
            dict.Add("B", 5);
            dict.Add("C", 1);
            int expectedOutput = 370;
            int actualOutput = 0;
            foreach (var dic in dict)
            {
                var Output = Program.Calculate(dic.Key, dic.Value);
                actualOutput += Output;
            }
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        //Unit Test Methods to test Scenario C
        [TestMethod]
        public void ScenarioC()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("A", 3);
            dict.Add("B", 5);
            dict.Add("C", 1);
            dict.Add("D", 1);

            int expectedOutput = 280;
            int actualOutput = 0;
            if (dict.ContainsKey("C") && dict.ContainsKey("D"))
            {
                foreach (var dic in dict)
                {
                    if ((dic.Key == "C"))
                    {
                        actualOutput += 0;
                    }
                    else if (dic.Key == "D")
                    {
                        actualOutput += 30;
                    }
                    else
                    {
                        int Output = Program.Calculate(dic.Key, dic.Value);
                        actualOutput += Output;
                    }
                }
            }
            else
            {
                foreach (var dic in dict)
                {
                    int Output = Program.Calculate(dic.Key, dic.Value);
                    actualOutput += Output;
                }
            }
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
