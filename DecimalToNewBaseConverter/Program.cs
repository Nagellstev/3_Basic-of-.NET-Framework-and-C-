/// <summary>
/// The program takes an integer in decimal, and a new base number system (from 2 to 20) 
/// from the command line. Print the original number converted to this system to the console.
/// </summary>

using System;
using System.Security.Permissions;

namespace BaseConverterProgram
{
    class Program
    {
        public static void Main()
        {
            bool endApp = false;
            Console.WriteLine("Console base converter on C#\r");
            Console.WriteLine("-----------\n");
            while (!endApp)
            {
                string numInput = "";
                string baseInput = "";
                string result = "";

                Console.WriteLine("Type integer number, press Enter");
                numInput = Console.ReadLine();
                int cleanNum = 0;
                while (!int.TryParse(numInput, out cleanNum))
                {
                    Console.WriteLine("Input integer number:");
                    numInput = Console.ReadLine();
                }

                Console.WriteLine("Type new base of number (0 < base < 36), press Enter");
                baseInput = Console.ReadLine();
                int cleanBase = 0;
                while (!int.TryParse(baseInput, out cleanBase) ||
                    cleanBase > 36 || 
                    cleanBase < 2)
                {
                    Console.WriteLine("Type new base of number (2 <= base <= 36):");
                    baseInput = Console.ReadLine();
                }
                try
                {
                    result = ConvertBase(cleanNum, cleanBase);
                    Console.WriteLine($"{numInput} in base {baseInput} is: {result}\n");
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

        public static string ConvertBase(int dec, int bas)
        {
            string output = "";
            int div;
            int rem;
            char rem_ch;
            if (bas > 36 ||
                bas < 2)
            {
                output = "inappropriate base";
                return output;
            }
            do
            {
                div = dec / bas;
                rem = dec % bas;
                if (rem >= 0 &&
                    rem <= 9)
                {
                    rem_ch = Convert.ToChar(rem + 48);
                }
                else if (rem > 9 &&
                    rem <= bas)
                {
                    rem_ch = Convert.ToChar(rem + 65 - 10);
                }
                else
                {
                    output = "conver error";
                    return output;
                }
                output = rem_ch.ToString() + output;
                dec = div;
            } while (div > 0);
            return output;
        }
    }
}

