/// <summary>
/// The program takes an integer in decimal, and a new base number system (from 2 to 20) 
/// from the command line. Print the original number converted to this system to the console.
/// </summary>

using System;
using System.Security.Permissions;

namespace BaseConverterProgram
{
    public class Program
    {

        public static void Main()
        {
            bool endApp = false;

            Console.WriteLine("Console base converter on C#\r");
            Console.WriteLine("-----------\n");

            while (!endApp)
            {
                string numberInput = "";
                string baseInput = "";
                string result = "";
                int cleanNumber = 0;
                int cleanBase = 0;

                Console.WriteLine("Type integer number, press Enter");
                numberInput = Console.ReadLine();

                while (!int.TryParse(numberInput, out cleanNumber))
                {
                    Console.WriteLine("Input integer number:");
                    numberInput = Console.ReadLine();
                }

                Console.WriteLine("Type new base of number (0 < base < 36), press Enter");
                baseInput = Console.ReadLine();

                while (!int.TryParse(baseInput, out cleanBase) ||
                    cleanBase > 36 || 
                    cleanBase < 2)
                {
                    Console.WriteLine("Type new base of number (2 <= base <= 36):");
                    baseInput = Console.ReadLine();
                }

                try
                {
                    result = ConvertBase(cleanNumber, cleanBase);
                    Console.WriteLine($"{numberInput} in base {baseInput} is: {result}\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something Wrong!\n" + e.Message);
                }

                Console.WriteLine("----------------------\n");
                Console.WriteLine("Press 'n' and 'Enter' to exit or other key to continue.\n");

                if (Console.ReadLine() == "n")
                {
                    endApp = true;
                }

                Console.WriteLine("\n");
            }
            return;
        }

        public static string ConvertBase(int numberInDecimalBase, int newBase)
        {
            string output = "";
            int quotient;
            int reminder;
            char reminderChar;
            bool endLoop = true;

            if (newBase > 36 ||
                newBase < 2)
            {
                output = "inappropriate base";
                return output;
            }

            while (endLoop)
            {
                quotient = numberInDecimalBase / newBase;
                reminder = numberInDecimalBase % newBase;

                if (reminder >= 0 &&
                    reminder <= 9)
                {
                    reminderChar = Convert.ToChar(reminder + 48);
                }
                else if (reminder > 9 &&
                    reminder <= newBase)
                {
                    reminderChar = Convert.ToChar(reminder + 65 - 10);
                }
                else
                {
                    output = "conver error";
                    return output;
                }

                output = reminderChar.ToString() + output;
                numberInDecimalBase = quotient;

                if (quotient <= 0)
                {
                    endLoop = false;
                }
            }

            return output;
        }
    }
}

