using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserInput
{
    public class GetInputFromUser
    {
        public static string ChoseOneOfTheseWithTab(List<string> list , string question)
        {
            list.ForEach(x => x.ToLower());
            List<ConsoleKey> pressedKeys = new List<ConsoleKey>();
            List<string> shortList = new List<string>();
            Console.Write(question);
            string writtenText = "";
            Regex isCharacter = new Regex("\\w");
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Backspace)
                {
                    if (writtenText.Length > 0) 
                        writtenText = writtenText.Substring(0, writtenText.Length - 1);
                    Console.Write(Environment.NewLine);
                    Console.Write(question);
                    Console.Write(writtenText);
                }
                else if (key == ConsoleKey.Tab)
                {
                    shortList = FindMatches("^"+writtenText , list , false);
                    Console.Write(Environment.NewLine);
                    shortList.ForEach(x => Console.WriteLine(x));
                    Console.Write(question);
                    if (shortList.Count == 1)
                    {
                        Console.Write(shortList[0]);
                        writtenText = shortList[0];
                    }
                    else
                        Console.Write(writtenText);
                }
                else if (key == ConsoleKey.Enter)
                {
                    shortList = FindMatches($"^{writtenText}$", list, false);
                    if (shortList.Count == 1)
                        return shortList[0];
                }
                else
                {
                    string inKey = key.ToString();
                    if (isCharacter.IsMatch(inKey))
                        writtenText += inKey.ToLower();
                    pressedKeys.Add(key);
                }
                
                
            }
        }

        private static List<string> FindMatches(string writtenText, List<string> list , bool caseSensitive)
        {
            if (!caseSensitive)
            {
                for (int i = 0; i < list.Count; i++)
                    list[i] = list[i].ToLower();
            }
                
            Regex r = new Regex(writtenText);
            List<string> output = new List<string>();
            foreach (string listitem in list)
            {
                if (r.IsMatch(listitem))
                    output.Add(listitem);
            }
            return output;
        }

        public static int GetInt(string question)
        {
            while (true)
            {
                Console.Write(question);
                string input = Console.ReadLine();
                if (input.Length != 0)
                {
                    if (int.TryParse(input, out int output))
                    {
                        return output;
                    }
                }
            }

        }

        public static string GetString(string question, int minChars, int maxChars)
        {
            return GetStringMethod(question, minChars, maxChars);
        }

        public static string GetString(string question)
        {
            return GetStringMethod(question, 0, 1000000000); //Behövs så långa strängar? Det är en övre gräns! c.f. överlagring
        }

        public static string GetStringMethod(string question, int minChars, int maxChars)
        {
            while (true)
            {
                Console.Write(question);
                string input = Console.ReadLine();
                if ((input.Length >= minChars) && (input.Length <= maxChars))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine($"Your text has to have at least {minChars} characters and at most {maxChars} characters. Current length is {input.Length} characters");
                }
            }
        }

        public static char GetChar(string question)
        {
            Console.Write(question);
            char c = char.Parse(Console.ReadLine());
            return c;

        }

        public static int[] GetTwoInts(string question, char separator, int max , int[] defaultOutput)
        {
            while (true)
            {
                string input = GetString(question);
                if (input == "")
                {
                    return defaultOutput;
                }
                int[] output = ReturnIntMethod(input, question, separator);
                if (((output[0] > 0) && (output[1] > 0)) && ((output[0] <= max) && (output[1] <= max) ))
                    
                    return output;
                else if ((output[0] > max) || (output[1] > max))
                {
                    Console.WriteLine($"The grid is too large! Maximum size is {max}x{max}");
                }
            }
        }


        public static int[] GetTwoInts(string question, char separator) //Onödigt att bryta ut denna från ReturnIntMethod
        {
            string input = GetString(question);

            return ReturnIntMethod(input, question, separator);
        }

        private static int[] ReturnIntMethod(string input, string question, char separator)
        {

            string[] splitInput = input.Split(separator);
            if (splitInput.Length == 2)
            {
                int[] output = new int[2];
                if (!(int.TryParse(splitInput[0], out output[0]) && int.TryParse(splitInput[1], out output[1])))
                {
                    Console.WriteLine("Bad input!");
                    return new int[] { 0, 0 };
                }
                else
                {
                    return output;
                }
            }
            else
            {
                return new int[] { 0, 0 };
            }

        }

    }
}
