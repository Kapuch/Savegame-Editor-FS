using System.Linq;

namespace Farming_Simulator_15_Savegame_Editor
{
    class Format
    {
        /// <summary>
        /// Przeksztalcenie ciagu znakow w postaci liczby zmienno przecinkowej do ciagu znakow w postaci liczby calkowitej (ucinamy czesc ulamkowa w stringu)
        /// </summary>
        public static string GiveMeDigits(string value)
        {
            return new string(value.Split('.')[0].Where(char.IsDigit).ToArray());
        }
    }
}
