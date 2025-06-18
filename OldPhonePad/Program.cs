using System;
using System.Text;
using System.Collections.Generic;

namespace OldPhonePad
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = "222*2#";
            string result = OldPhonePad(input);
            Console.WriteLine(result);
        }

        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            char[] digits = input.ToCharArray();

            var characters = new Dictionary<char, string>
        {
            {'2', "ABC" },
            {'3', "DEF" },
            {'4', "GHI" },
            {'5', "JKL" },
            {'6', "MNO" },
            {'7', "PQRS" },
            {'8', "TUV" },
            {'9', "WXYZ" }
        };

            StringBuilder result = new StringBuilder();
            List<char> series = new List<char>();

            if (digits != null && digits[digits.Length - 1] != '#')
            {
                return result.ToString(); // return early if # is not typed
            }


            for (int i = 0; i < digits.Length; i++)
            {
                char digit = digits[i];
                bool hasNext = (i + 1) < digits.Length;
                char nextDigit = hasNext ? digits[i + 1] : '\0'; // for not to have index out of bound error

                if (digit == '#')
                {
                    return result.ToString();
                }

                else if (digit == ' ')
                {
                    continue;
                }

                else if (nextDigit == digit && series.Count <= characters[digit].Length - 1)
                {
                    if (i + 2 < digits.Length && digits[i + 2] != '*') // not deleting then add
                        series.Add(digit);
                }

                else
                {
                    int letterIndex = series.Count;
                    if (characters.ContainsKey(digit))
                    {
                        result.Append(characters[digit][letterIndex]);
                    }
                    series.Clear();
                }

            }


            return result.ToString();
        }
    }

}
