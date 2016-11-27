using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32; //OpenFileDialog


namespace Farming_Simulator_15_Savegame_Editor
{
   public class FileSelection
    {
        private static string mainPatch = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\";
        /// <summary>wyszukukuje katalogi gier w Dokumentach</summary>
        ///<param name="control">Parametr przyjmuje klasę w której znajdują się kontrolki (this)</param>
        public static void dirAutoSearch(MainWindow control)
        {
            control.DIRcomboBox.Items.Clear();
            control.DIRcomboBox.Items.Add("Wybierz ręcznie");
            for (int i = 2011; i <= 2015; i += 2) // tylko wersja 2015 i wcześniejsze ze względu na zmiany wprowadzone w wersji 2017
                if (Directory.Exists(mainPatch + @"farmingsimulator" + i))
                {
                    control.DIRcomboBox.Items.Add("FarmingSimulator" + i);
                }
            control.DIRcomboBox.SelectedIndex = 0;
        }
        public static void saveAutoSearch(MainWindow control)
        {
            control.SAVEcomboBox.Items.Clear();
            /// <summary>wyszukukuje istniejące zapisy</summary>
            if (control.DIRcomboBox.SelectedIndex != 0)
            {
                for (int i = 1; i <= 30; i++)
                    if (Directory.Exists(mainPatch + control.DIRcomboBox.Text + @"\savegame" + i))
                    {
                        if(File.Exists(mainPatch + control.DIRcomboBox.Text + @"\savegame" + i + @"\economy.xml"))
                        control.SAVEcomboBox.Items.Add("savegame" + i);
                    }
            }
        }
        public static string manualChoice(MainWindow control)
        {
            OpenFileDialog FileDialog = new OpenFileDialog();
            string dirFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\" + control.DIRcomboBox.Text;
            if (Directory.Exists(dirFile)) //sprawdzamy lokalizację podobnie jak w dirAutoSearch() wrazie gdyby przed zainicjowaniem lokalizacji zmodyfikowano folder (mimo że już lokalizacja była znana wcześniej)
                FileDialog.InitialDirectory = dirFile; //wybór pliku zaczyna w folderze o ścieżce z dirFile
            else
                if (control.DIRcomboBox.SelectedIndex > 0)
                    MessageBox.Show("Nie znaleziono lokalizacji\n" + dirFile + "\nWybór należy przeprowadzić ręcznie");
            FileDialog.Filter = @"FarmingSimulator20xx careerSavegame (*.xml)|careerSavegame.xml"; // @ - ignorowanie formatowania dla nazwy pliku
            if (FileDialog.ShowDialog() == true)//sprawdzenie czy plik został wybrany
            {
                return FileDialog.FileName;
            }
            return null;
        }
    }
}
