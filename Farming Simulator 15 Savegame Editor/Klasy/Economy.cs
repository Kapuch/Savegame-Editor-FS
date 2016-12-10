using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows;

namespace Farming_Simulator_15_Savegame_Editor
{
    class Economy
    {
        public static void Load(string path, FieldManageWindow control, List<Field> fields)
        {

            try
            {
                XmlDocument Xeconomy = new XmlDocument();
                Xeconomy.Load(path);
                XmlNodeList fieldList = Xeconomy.GetElementsByTagName("field");
                foreach (XmlNode elem in fieldList)
                {
                    fields.Add(new Field() { Numer = elem.Attributes["number"].Value, Stan = Convert.ToBoolean(elem.Attributes["ownedByPlayer"].Value) });
                }
                control.fieldDataGrid.ItemsSource = fields;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
