using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace Farming_Simulator_15_Savegame_Editor
{
   public class FileSelection
    {
        /// <summary>wyszukukuje katalogi gier w Dokumentach</summary>
        ///<param name="control">Parametr przyjmuje klasę w której znajdują się kontrolki (domyślnie: this)</param>
        public static void dirAutoSearch(MainWindow control)
        {
            control.DIRcomboBox.Items.Add("Wybierz ręcznie");
            for (int i = 2011; i <= 2017; i += 2)
                if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\farmingsimulator" + i))
                {
                    control.DIRcomboBox.Items.Add("FarmingSimulator" + i);
                }
        }
        ///<summary>Odświerza listę katalogów gier w Dokumentach</summary>
        public static void dirAutoSearchReload(MainWindow control)
        {
            control.DIRcomboBox.Items.Clear();
            dirAutoSearch(control);
            control.DIRcomboBox.SelectedIndex = 0;
        }
       
    }
}
