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
        public static List<TextBox> listBox(MainWindow control)
        {
            List<TextBox> listBox = new List<TextBox>();
            listBox.Add(control.potatoBox);
            listBox.Add(control.rapeBox);
            listBox.Add(control.wheatBox);
            listBox.Add(control.barleyBox);
            listBox.Add(control.maizeBox);
            listBox.Add(control.sugarBeetBox);
            listBox.Add(control.woodChipsBox);
            listBox.Add(control.grassBox);
            listBox.Add(control.manureBox);
            listBox.Add(control.liquidManureBox);
            listBox.Add(control.chaffBox);
            listBox.Add(control.moneyBox);
            return listBox;
        }
    }
}
