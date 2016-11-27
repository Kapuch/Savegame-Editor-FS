using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Farming_Simulator_15_Savegame_Editor
{
    class ControlListGenerate
    {
        /// <summary>Zwraca listę kontrolek textBox</summary>
        public static List<TextBox> siloBox(MainWindow control)
        {
            List<TextBox> siloBox = new List<TextBox>();
            siloBox.Add(control.potatoBox);
            siloBox.Add(control.rapeBox);
            siloBox.Add(control.wheatBox);
            siloBox.Add(control.barleyBox);
            siloBox.Add(control.maizeBox);
            siloBox.Add(control.sugarBeetBox);
            siloBox.Add(control.woodChipsBox);
            siloBox.Add(control.grassBox);
            siloBox.Add(control.manureBox);
            siloBox.Add(control.liquidManureBox);
            siloBox.Add(control.chaffBox);
            return siloBox;
        }
    }
}
