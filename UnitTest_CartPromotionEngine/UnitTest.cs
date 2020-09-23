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
    }
}
