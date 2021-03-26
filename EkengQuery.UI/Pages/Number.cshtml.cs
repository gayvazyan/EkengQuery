using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EkengQuery.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EkengQuery.UI.Pages
{
    public class NumberModel : PageModel
    {

        [BindProperty]
        public int NumberInt { get; set; }

        [BindProperty]
        public string NumberText { get; set; }
        public void OnGet()
        {
            NumberText = "";
        }

        public void OnPost()
        {
            var test = NumberInt;

            NumberText = ConvertToString.ConvertNumberToString(NumberInt);


        }

        //public static string ConvertNumberToString(int n)
        //{
        //    if (n < 0)
        //        throw new NotSupportedException("negative numbers not supported");
        //    if (n == 0)
        //        return "զրո";
        //    if (n < 10)
        //        return ConvertDigitToString(n);
        //    if (n < 20)
        //        return ConvertTeensToString(n);
        //    if (n < 100)
        //        return ConvertHighTensToString(n);
        //    if (n < 1000)
        //        return ConvertBigNumberToString(n, (int)1e2, "հարյուր");
        //    if (n < 1e6)
        //        return ConvertBigNumberToString(n, (int)1e3, "հազար");
        //    if (n < 1e9)
        //        return ConvertBigNumberToString(n, (int)1e6, "միլիոն");
        //    //if (n < 1e12)
        //    return ConvertBigNumberToString(n, (int)1e9, "բիլիոն");
        //}

        //private static string ConvertDigitToString(int i)
        //{
        //    switch (i)
        //    {
        //        case 0: return "";
        //        case 1: return "մեկ";
        //        case 2: return "երկու";
        //        case 3: return "երեք";
        //        case 4: return "չորս";
        //        case 5: return "հինգ";
        //        case 6: return "վեց";
        //        case 7: return "յոթ";
        //        case 8: return "ութ";
        //        case 9: return "ինը";
        //        default:
        //            throw new IndexOutOfRangeException(String.Format("{0} not a digit", i));
        //    }
        //}

        ////assumes a number between 10 & 19
        //private static string ConvertTeensToString(int n)
        //{
        //    switch (n)
        //    {
        //        case 10: return "տասը";
        //        case 11: return "տասնմեկ";
        //        case 12: return "տաներկու";
        //        case 13: return "տասներեք";
        //        case 14: return "տասնչորս";
        //        case 15: return "տասնհինգ";
        //        case 16: return "տասնվեց";
        //        case 17: return "տասնյոթ";
        //        case 18: return "տասնութ";
        //        case 19: return "տասնինը";
        //        default:
        //            throw new IndexOutOfRangeException(String.Format("{0} not a teen", n));
        //    }
        //}

        ////assumes a number between 20 and 99
        //private static string ConvertHighTensToString(int n)
        //{
        //    int tensDigit = (int)(Math.Floor((double)n / 10.0));

        //    string tensStr;
        //    switch (tensDigit)
        //    {
        //        case 2: tensStr = "քսան"; break;
        //        case 3: tensStr = "երեսուն"; break;
        //        case 4: tensStr = "քառասուն"; break;
        //        case 5: tensStr = "հիսուն"; break;
        //        case 6: tensStr = "վաթսուն"; break;
        //        case 7: tensStr = "յոթանասուն"; break;
        //        case 8: tensStr = "ութանասուն"; break;
        //        case 9: tensStr = "իննսուն"; break;
        //        default:
        //            throw new IndexOutOfRangeException(String.Format("{0} not in range 20-99", n));
        //    }
        //    if (n % 10 == 0) return tensStr;
        //    string onesStr = ConvertDigitToString(n - tensDigit * 10);
        //    return tensStr  + onesStr;
        //}

        //private static string ConvertBigNumberToString(int n, int baseNum, string baseNumStr)
        //{
        //    // special case: use commas to separate portions of the number, unless we are in the hundreds
        //    string separator = (baseNumStr != "հարյուր") ? ", " : " ";

        //    // Strategy: translate the first portion of the number, then recursively translate the remaining sections.
        //    // Step 1: strip off first portion, and convert it to string:
        //    int bigPart = (int)(Math.Floor((double)n / baseNum));
        //    string bigPartStr = ConvertNumberToString(bigPart) + " " + baseNumStr;
        //    // Step 2: check to see whether we're done:
        //    if (n % baseNum == 0) return bigPartStr;
        //    // Step 3: concatenate 1st part of string with recursively generated remainder:
        //    int restOfNumber = n - bigPart * baseNum;
        //    return bigPartStr + separator + ConvertNumberToString(restOfNumber);
        //}


    }
}
