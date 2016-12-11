using System.Collections.Generic;
using System.Windows;

namespace Farming_Simulator_15_Savegame_Editor
{
    /// <summary>
    /// Interaction logic for FieldManageWindow.xaml
    /// </summary>
    public partial class FieldManageWindow : Window
    {
        public FieldManageWindow(string path)
        {
            InitializeComponent();
            Economy.Load(path, this, pola); //tak jak w MainWindow Savegame.Load
            this.path = path;

        }
        private string path;
        private List<Field> pola = new List<Field>(); // lista pol ktora jest aktualizowana wraz ze zmiana w kontrolce dataGrid dzieki trybowi TwoWay

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Economy.Save(path, this, pola); //tak jak w MainWindow Savegame.Save
            Close();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
