using System;
using System.Security.Permissions;
using BaseConverterLibrary;

namespace CalculatorProgram
{
    class Program
    {
        static void Main()
        {
            bool endApp = false;
            Console.WriteLine("Console base converter on C#\r");
            Console.WriteLine("-----------\n");
            BaseConverter bc = new BaseConverter();
            while (!endApp)
            {
                string numInput1 = "";
                string numInput2 = "";
                string result = "";

                Console.WriteLine("Type integer number, press Enter");
                numInput1 = Console.ReadLine();
                int cleanNum1 = 0;
                while (!int.TryParse(numInput1, out cleanNum1))
                {
                    Console.WriteLine("Input integer number:");
                    numInput1 = Console.ReadLine();
                }

                Console.WriteLine("Type new base of number (0 < base < 36), press Enter");
                numInput2 = Console.ReadLine();
                int cleanNum2 = 0;
                while (!int.TryParse(numInput2, out cleanNum2) ||
                    cleanNum2 > 36 || 
                    cleanNum2 < 2)
                {
                    Console.WriteLine("Type new base of number (2 <= base <= 36):");
                    numInput2 = Console.ReadLine();
                }
                try
                {
                    result = bc.ConvertBase(cleanNum1, cleanNum2);
                    Console.WriteLine(numInput1 + " in base " + numInput2 + " is: " + result + "\n");
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
    }
}

