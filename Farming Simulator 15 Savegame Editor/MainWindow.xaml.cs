using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO; //Directory
using Microsoft.Win32; //OpenFileDialog

namespace Farming_Simulator_15_Savegame_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            siloBox = ControlListGenerate();
            dirAutoSearch();
            
        }
        ///<summary>Lista kontrolek textBox</summary>
        List<TextBox> siloBox = new List<TextBox>();
        OpenFileDialog FileDialog = new OpenFileDialog();
        string filePath;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            string dirFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\"+DIRcomboBox.Text;
            if (Directory.Exists(dirFile)) //sprawdzamy lokalizację podobnie jak w dirAutoSearch() wrazie gdyby przed zainicjowaniem lokalizacji zmodyfikowano folder (mimo że już lokalizacja była znana wcześniej)
                FileDialog.InitialDirectory = dirFile; //wybór pliku zaczyna w folderze o ścieżce z dirFile
            else
                if (DIRcomboBox.SelectedIndex>0)
                    MessageBox.Show("Nie znaleziono lokalizacji\n"+dirFile+"\nWybór należy przeprowadzić ręcznie");
            FileDialog.Filter = @"FarmingSimulator20xx careerSavegame (*.xml)|careerSavegame.xml"; // @ - ignorowanie formatowania dla nazwy pliku
            if (FileDialog.ShowDialog() == true)//sprawdzenie czy plik został wybrany
            {
                filePath = FileDialog.FileName;
            }
        }
        /// <summary>Zwraca listę kontrolek textBox</summary>
        public List<TextBox> ControlListGenerate()
        {
            List<TextBox> siloBox = new List<TextBox>();
            siloBox.Add(potatoBox);
            siloBox.Add(rapeBox);
            siloBox.Add(wheatBox);
            siloBox.Add(barleyBox);
            siloBox.Add(maizeBox);
            siloBox.Add(sugarBeetBox);
            siloBox.Add(woodChipsBox);
            siloBox.Add(grassBox);
            siloBox.Add(manureBox);
            siloBox.Add(liquidManureBox);
            siloBox.Add(chaffBox);
            return siloBox;
        }
        /// <summary>wyszukukuje katalogi gier w Dokumentach</summary>
        public void dirAutoSearch()
        {
            for(int i = 2011 ; i<=2017 ; i+=2)
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+@"\My Games\farmingsimulator"+i))
            {
                DIRcomboBox.Items.Add("FarmingSimulator"+i);
                    
            }
        }
       
    }
}
