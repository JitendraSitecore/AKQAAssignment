using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AKQAAssignment;

namespace AKQAAssignmentUnitTest
{
    [TestClass]
    public class CurrencyHandler_Test
    {
        [TestMethod]
        public void ConvertToWorld_NegativeInput()
        {
            decimal amount = -1;
            string words = CurrencyHandler.ConvertToWord(amount);

            Assert.AreEqual("Negative currency not acceptable.", words, true);
        }

        [TestMethod]
        public void ConvertToWorld_Zero()
        {
            decimal amount = 0;
            string words = CurrencyHandler.ConvertToWord(amount);

            Assert.AreEqual("Amount must be greater than zero.", words, true);
        }

        [TestMethod]
        public void ConvertToWorld_Input_1()
        {
            decimal amount = 1;
            string words = CurrencyHandler.ConvertToWord(amount);

            Assert.AreEqual("One Dollor", words, true);
        }

        [TestMethod]
        public void ConvertToWorld_Input_10()
        {
            decimal amount = 10;
            string words = CurrencyHandler.ConvertToWord(amount);

            Assert.AreEqual("Ten Dollors", words, true);
        }

        [TestMethod]
        public void ConvertToWorld_Input_DollorAndCents()
        {
            decimal amount = (decimal)19876.67;
            string words = CurrencyHandler.ConvertToWord(amount);

            Assert.AreEqual("NINETEEN THOUSAND AND EIGHT HUNDRED AND SEVENTY SIX DOLLORS AND SIXTY SEVEN CENTS", words, true);
        }


    }

}
