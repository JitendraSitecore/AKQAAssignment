using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKQAAssignment
{
    public class CurrencyHandler
    {
        private static string[] arrNumber = { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
        private static string[] arrNumberTens = { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

        private static string strThousand = "THOUSAND";
        private static string strHundred = "HUNDRED";
        private static string strMillion = "MILLION";

        public static string ConvertToWord(decimal amount)
        {
            string strAmount = string.Empty;
            string sAmount = amount.ToString();
            int cents = 0;
            int fullAmount = 0;

            if (amount < 0)
                strAmount = "Negative currency not acceptable.";
            else if(amount == 0)
            {
                strAmount = "Amount must be greater than zero.";
            }
            else
            {
                //find cents
                if (sAmount.Contains("."))
                {
                    string amountAfterDecimal = sAmount.Split('.')[1];
                    if (amountAfterDecimal.Length > 2)
                        cents = int.Parse(amountAfterDecimal.Substring(0, 2));
                    else
                        cents = int.Parse(amountAfterDecimal);
                }

                fullAmount = int.Parse(sAmount.Split('.')[0]);

                if (fullAmount > 0)
                    strAmount = CurrencyToWords(fullAmount) + ((fullAmount == 1) ? " DOLLOR" : " DOLLORS");

                if (cents > 0)
                {
                    if (!string.IsNullOrWhiteSpace(strAmount.Trim()))
                        strAmount += " AND ";
                    strAmount += CurrencyToWords(cents) + ((cents == 1) ? " CENT" : " CENTS");
                }
            }

            return strAmount;
        }

        private static string CurrencyToWords(int amount)
        {
            string strAmount = string.Empty;
            string sAmount = amount.ToString();
            int fullAmount = 0;
            int remainingAmount = 0;
            int number = 0;



            //find full amount without cents
            fullAmount = int.Parse(sAmount.Split('.')[0]);
            remainingAmount = fullAmount;

            //For Million
            if (fullAmount >= 1000000)
            {
                number = (fullAmount / 1000000);
                strAmount += CurrencyToWords(number) + " " + strMillion;
                remainingAmount = fullAmount - (number * 1000000);
            }

            //For Thousand
            if (remainingAmount >= 1000)
            {
                number = (fullAmount / 1000);
                strAmount += CurrencyToWords(number) + " " + strThousand;
                remainingAmount = fullAmount - (number * 1000);
            }

            //For hundred
            if (remainingAmount >= 100)
            {
                number = (int)(remainingAmount / 100);

                if (!string.IsNullOrEmpty(strAmount))
                    strAmount += " AND ";

                strAmount += CurrencyToWords(number) + " " + strHundred;

                remainingAmount = remainingAmount - (number * 100);
            }

            //For tens or single unit
            if (remainingAmount > 0)
            {
                if (!string.IsNullOrEmpty(strAmount))
                    strAmount += " AND ";

                if (remainingAmount < 20)
                {
                    strAmount += arrNumber[remainingAmount];
                }
                else
                {
                    strAmount += arrNumberTens[(int)remainingAmount / 10];
                    if (((int)remainingAmount / 10) > 0 && ((int)remainingAmount % 10) != 0)
                        strAmount += " " + arrNumber[(int)remainingAmount % 10];
                }
            }
            return strAmount;
        }

    }
}