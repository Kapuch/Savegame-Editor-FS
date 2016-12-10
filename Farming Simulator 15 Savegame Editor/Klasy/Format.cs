using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farming_Simulator_15_Savegame_Editor
{
    class Format
    {
        public static string GiveMeDigits(string value)
        {
            return new string(value.Split('.')[0].Where(char.IsDigit).ToArray());
        }
    }
}
