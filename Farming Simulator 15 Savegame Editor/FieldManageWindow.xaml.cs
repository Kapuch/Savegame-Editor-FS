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
using System.Windows.Shapes;

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
            Economy.Load(path, this, pola);
            this.path = path;

        }
        private string path;
        private List<Field> pola = new List<Field>();

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Economy.Save(path, this, pola);
            Close();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
