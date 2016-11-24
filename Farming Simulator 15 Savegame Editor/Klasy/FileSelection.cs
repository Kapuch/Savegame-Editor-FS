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
        public static void dirAutoSearch(MainWindow control)
        {
            for (int i = 2011; i <= 2017; i += 2)
                if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\farmingsimulator" + i))
                {
                    control.DIRcomboBox.Items.Add("FarmingSimulator" + i);
                }
            
        }
       
    }
}
