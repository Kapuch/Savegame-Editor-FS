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
using System.Xml;

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
            siloBox = ControlListGenerate.siloBox(this);
            FileSelection.dirAutoSearch(this);     
        }
        ///<summary>Lista kontrolek textBox</summary>
        List<TextBox> siloBox = new List<TextBox>();
        




        private void button_Click(object sender, RoutedEventArgs e)
        {
            Savegame.Load(FileSelection.manualChoice(this),this,siloBox);
        }
        private void ReloadDirButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var k in siloBox)
                k.IsEnabled=true;
        }
        private void DIRcomboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (DIRcomboBox.SelectedIndex > 0)
            {
                SAVEcomboBox.IsEnabled = true;
                FileSelection.saveAutoSearch(this);
            }
            else
            {
                SAVEcomboBox.Items.Clear();
                SAVEcomboBox.IsEnabled = false;
            }
        }

        private void SAVEcomboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (SAVEcomboBox.SelectedIndex>=0)
                Savegame.Load(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\" + DIRcomboBox.Text + @"\" + SAVEcomboBox.Text + @"\careerSavegame.xml", this, siloBox);
        }
    }
}
