using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePad
{
    public class Program
    {
        static void Main(string[] args)
        {
            // string input = "4433555 555666#";
            string input = "8 88777444666*664#";
            string result = OldPhonePad(input);
            Console.WriteLine(result);
        }

        // public static string OldPhonePad(string input)
        // {
        //     if (string.IsNullOrEmpty(input))
        //         return string.Empty;

        //     char[] digits = input.ToCharArray();

        //     var keypad = new Dictionary<char, string>
        //     {
        //         {'2', "ABC" },
        //         {'3', "DEF" },
        //         {'4', "GHI" },
        //         {'5', "JKL" },
        //         {'6', "MNO" },
        //         {'7', "PQRS" },
        //         {'8', "TUV" },
        //         {'9', "WXYZ" }
        //     };

        //     StringBuilder result = new StringBuilder();
        //     List<char> series = new List<char>();

        //     if (digits != null && digits[digits.Length - 1] != '#')
        //     {
        //         return result.ToString(); // return early if # is not typed
        //     }

        //     for (int i = 0; i < digits.Length; i++)
        //     {
        //         char digit = digits[i];
        //         bool hasNext = (i + 1) < digits.Length;
        //         char nextDigit = hasNext ? digits[i + 1] : '\0'; // for not to have index out of bound error

        //         if (digit == '#')
        //         {
        //             return result.ToString();
        //         }

        //         else if (digit == ' ')
        //         {
        //             continue;
        //         }

        //         else if (nextDigit == digit && series.Count <= keypad[digit].Length - 1)
        //         {
        //             if (i + 2 < digits.Length && digits[i + 2] != '*') // not deleting then add
        //                 series.Add(digit);
        //         }

        //         else
        //         {
        //             int letterIndex = series.Count;
        //             if (keypad.ContainsKey(digit))
        //             {
        //                 result.Append(keypad[digit][letterIndex]);
        //             }
        //             series.Clear();
        //         }

        //     }
        //     return result.ToString();
        // }

        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            var keypad = new Dictionary<char, string>
            {
                { '2', "ABC" },
                { '3', "DEF" },
                { '4', "GHI" },
                { '5', "JKL" },
                { '6', "MNO" },
                { '7', "PQRS" },
                { '8', "TUV" },
                { '9', "WXYZ" },
            };

            var result = new StringBuilder();
            char lastDigit = '\0';
            int pressCount = 0;

            foreach (char c in input)
            {
                switch (c)
                {
                    case '#':
                        // End of input
                        goto End;

                    case '*':
                        // Backspace
                        if (result.Length > 0)
                            result.Remove(result.Length - 1, 1);
                        lastDigit = '\0';
                        pressCount = 0;
                        break;

                    case ' ':
                        // Pause (finalize previous letter)
                        if (keypad.ContainsKey(lastDigit))
                        {
                            string letters = keypad[lastDigit];
                            int index = (pressCount - 1) % letters.Length;
                            result.Append(letters[index]);
                        }
                        lastDigit = '\0';
                        pressCount = 0;
                        break;

                    default:
                        if (keypad.ContainsKey(c))
                        {
                            if (c == lastDigit)
                            {
                                pressCount++;
                            }
                            else
                            {
                                if (keypad.ContainsKey(lastDigit))
                                {
                                    string letters = keypad[lastDigit];
                                    int index = (pressCount - 1) % letters.Length;
                                    result.Append(letters[index]);
                                }
                                lastDigit = c;
                                pressCount = 1;
                            }
                        }
                        break;
                }
            }

            End:
            if (keypad.ContainsKey(lastDigit))
            {
                string letters = keypad[lastDigit];
                int index = (pressCount - 1) % letters.Length;
                result.Append(letters[index]);
            }

            return result.ToString();
        }
    }
}
