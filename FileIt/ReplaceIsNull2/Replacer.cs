using System;
using System.Text;

namespace FileIt.ReplaceIsNull2
{
    public class Replacer
    {
        public int Replace(string text, out string replacedText)
        {
            string keyIsNull = "IsNull(";
            string keyIsNotNull = "IsNotNull(";
            string replaceIsNull = " == null";
            string replaceIsNotNull = " != null";

            var replaceMents = ReplaceKey(text, keyIsNull, replaceIsNull, out replacedText);
            replaceMents += ReplaceKey(replacedText, keyIsNotNull, replaceIsNotNull, 
                out replacedText);

            return replaceMents;
        }

        private int ReplaceKey(string text, string key, string keyReplacement, out string replacedText)
        {
            StringBuilder sb = new StringBuilder();
            // Find occurence of key word
            int searchStart = 0;
            int matchStart;
            int replaceMents = 0;
            while (HasMatch(text, searchStart, key, out matchStart))
            {
                var argStart = matchStart + key.Length;
                var arg = MatchArgument(text, argStart);
                sb.Append(text.Substring(searchStart, matchStart - searchStart));
                sb.Append(arg.Trim());
                sb.Append(keyReplacement);
                searchStart = argStart + arg.Length + 1;
                replaceMents++;
            }
            sb.Append(text.Substring(searchStart));
            replacedText = sb.ToString();
            return replaceMents;
        }

        private bool HasMatch(string text, int startIndex, string key, out int index)
        {
            index = text.IndexOf(key, startIndex, StringComparison.Ordinal);
            return index >= 0;
        }

        private string MatchArgument(string text, int start)
        {
            // Loop characters, match brackets. 
            int parCount = 0;
            int j = 0;
            while (true)
            {
                if (text[start + j] == '(')
                {
                    parCount++;
                }
                else if (text[start + j] == ')' && parCount > 0)
                {
                    parCount--;
                }
                else if (text[start + j] == ')' && parCount == 0)
                {
                    return text.Substring(start, j);
                }
                j++;
            }
        }
    }
}
