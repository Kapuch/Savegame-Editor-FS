using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO; //Directory

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
            listBox = ControlListGenerate.listBox(this); //przypisanie kontrolek do listy gdy okno zostanie otwarte
            FileSelection.dirAutoSearch(this); //automatyczne wyszukiwanie katalogów w folderze Dokumenty
        }
        ///<summary>Lista kontrolek textBox</summary>
        List<TextBox> listBox = new List<TextBox>();
        string savePath = null; //przechowuje sciezke dla careerSavegame.xml
        string economyPath = null; //przechowuje sciezke dla economy.xml

        private void button_Click(object sender, RoutedEventArgs e)
        {
            savePath = FileSelection.manualChoice(this); //przypisanie scieżki z ręcznego wyboru pliku
            Savegame.Load(savePath, this, listBox); //wczytanie zawartosci pliku do kontrolek
            FieldManageButton.IsEnabled = false; // <--- zazadzanie polami w wyborze recznym niedostepne, gdyż można wybrać plik który nie jest w sąsiedztwie z economy.xml
            statusLabel.Content = "Wybrano ręcznie";
        }

        private void DIRcomboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (DIRcomboBox.SelectedIndex > 0)
            {
                SAVEcomboBox.IsEnabled = true;
                FileSelection.saveAutoSearch(this);  //przeszukanie wybranego katalogu wzgledem warunku istnienia savegame, istnienie wielu katalogów nie oznacza że istnieje także save w tym katalogu
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
                FieldManageButton.IsEnabled = File.Exists(economyPath) ? true : false; //jeżeli economy.xml istnieje, możliwe będzie zarządanie polami
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Savegame.Save(savePath, this); //zapisanie zawartosci kontrolek do pliku
        }

        private void Box_PreviewTextInput(object sender, TextCompositionEventArgs e) //ograniczenie kontrolek do wprowadzania wylacznie cyfr
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) 
                e.Handled = true;
        }

        private void FieldManageButton_Click(object sender, RoutedEventArgs e)
        {
            FieldManageWindow economyWindow = new FieldManageWindow(economyPath); //tworzymy okno zarzadzania polami
            economyWindow.Show(); //wyswietlamy utworzone okno
        }
    }
}
