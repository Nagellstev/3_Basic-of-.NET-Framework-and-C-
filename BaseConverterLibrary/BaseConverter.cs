/// <summary>
/// The library 
/// </summary>

using System;

namespace BaseConverterLibrary
{
    public class BaseConverter
    {
        public string ConvertBase(int dec, int bas)
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