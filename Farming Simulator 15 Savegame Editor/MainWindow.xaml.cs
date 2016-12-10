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
            listBox = ControlListGenerate.listBox(this);
            FileSelection.dirAutoSearch(this);     
        }
        ///<summary>Lista kontrolek textBox</summary>
        List<TextBox> listBox = new List<TextBox>();
        string savePath = null;
        string economyPath = null;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            savePath = FileSelection.manualChoice(this);
            Savegame.Load(savePath, this, listBox);
            FieldManageButton.IsEnabled = false;
            statusLabel.Content = "Wybrano ręcznie";
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
            {
                savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\" + DIRcomboBox.Text + @"\" + SAVEcomboBox.Text + @"\careerSavegame.xml";
                Savegame.Load(savePath, this, listBox);
                statusLabel.Content = SAVEcomboBox.Text + " (" + DIRcomboBox.Text + ")";
                economyPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\" + DIRcomboBox.Text + @"\" + SAVEcomboBox.Text + @"\economy.xml";
                FieldManageButton.IsEnabled = File.Exists(economyPath) ? true : false;
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Savegame.Save(savePath, this);
        }

        private void Box_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void FieldManageButton_Click(object sender, RoutedEventArgs e)
        {
            FieldManageWindow economyWindow = new FieldManageWindow(economyPath);
            economyWindow.Show();
        }
    }
}
