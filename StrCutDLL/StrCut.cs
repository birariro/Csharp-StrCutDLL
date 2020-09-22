using System;
using System.Collections.Generic;
using System.Text;

namespace StrCutDLL
{
    public class StrCut
    {
        /// <summary>
        /// Find only the desired location in the string
        /// If you choose the wrong location return "ERR"
        /// </summary>
        /// <param name="Original">Original String</param>
        /// <param name="strStart">Start of source string to find or Enter NULL to 0 index</param>
        /// <param name="strEnd">End of source string to find, or Enter NULL to End index</param>
        /// <param name="flag">True : integer find  , False : All </param>
        public static string StrChange(string Original, string strStart, string strEnd, bool flag)
        {
            int indexStart = 0;
            StringBuilder resultStr = new StringBuilder();
            if (strStart != null)
            {
                indexStart = Original.IndexOf(strStart);
                if (indexStart == -1) throw new Exception("parameter(strStart) Check it out"); //no strStart
                indexStart += strStart.Length;
            }
            else indexStart = 0;


            if (strEnd != null)
            {
                int indexEnd = Original.IndexOf(strEnd, indexStart) - indexStart;
                if (indexEnd < 0) throw new Exception("parameter(strEnd) Check it out"); //no strEnd
                Original = Original.Substring(indexStart, indexEnd);
            }
            else Original = Original.Substring(indexStart);

            if (flag == false) return Original;

            for (int i = 0; i < Original.Length; i++)
            {
                int htmlChar = Convert.ToInt32(Original[i]);
                if (htmlChar >= 48 && htmlChar <= 57) resultStr.Append(Original[i]);
                else if (resultStr.Length != 0 && (htmlChar < 48 || htmlChar > 57) && htmlChar != 44) break;
            }
            if (resultStr.Length == 0) throw new Exception("All Check it out"); //no Value
            return resultStr.ToString();
        }
        public static string[] ArrSplit(string Original, string SplitStr)
        {
            string[] result = Original.Split(new string[] { SplitStr }, StringSplitOptions.None);
            return result;
        }

        /// <summary>
        /// Find only numbers in a string
        /// Number of Multiple
        /// </summary>
        /// <param name="Original">Original String</param>
        /// <param name="strStart">Start of source string to find or Enter NULL to 0 index</param>
        /// <param name="strEnd">End of source string to find, or Enter NULL to End index</param>
        public static string[] StrChangeArray(string Original, string strStart, string strEnd)
        {
            try
            {
                Original = StrChange(Original, strStart, strEnd, false);
                List<string> resultList = new List<string>();
                string strTmp = "";
                for (int i = 0; i < Original.Length; i++)
                {
                    int htmlChar = Convert.ToInt32(Original[i]);
                    if (htmlChar >= 48 && htmlChar <= 57) strTmp += Original[i];
                    else if (strTmp.Length != 0 && (htmlChar < 48 || htmlChar > 57) && htmlChar != 44)
                    {
                        resultList.Add(strTmp);
                        strTmp = "";
                    }
                }
                string[] result = new string[resultList.Count];
                for (int i = 0; i < resultList.Count; i++)
                {
                    result[i] = resultList[i];
                }

                return result;
            }
            catch (Exception e)
            {
                DebugLog.e(e);
                return new string[] { "ERR" };
            }

        }
    }
}
