using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Windows;

namespace Farming_Simulator_15_Savegame_Editor
{
    class Economy
    {
        public static void Load(string path, FieldManageWindow control, List<Field> fields)
        {

            try
            {
                XmlDocument Xeconomy = new XmlDocument(); //Przechowuje zawartosc XML
                Xeconomy.Load(path); //Wczytanie zawartosci
                //Analogicznie do klasy Savegame:
                XmlNodeList fieldList = Xeconomy.GetElementsByTagName("field"); 
                foreach (XmlNode elem in fieldList)
                {
                    fields.Add(new Field() { Numer = elem.Attributes["number"].Value, Stan = Convert.ToBoolean(elem.Attributes["ownedByPlayer"].Value) });
                }
                control.fieldDataGrid.ItemsSource = fields; //przypisujemy liste pol do daraGridu w trybie TwoWay
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static void Save(string path, FieldManageWindow control, List<Field> fields)
        {
            try
            {
                //Analogicznie do klasy Savegame:
                XmlDocument Xeconomy = new XmlDocument();
                Xeconomy.Load(path);
                XmlNodeList fieldList = Xeconomy.GetElementsByTagName("field");
                foreach (XmlNode elem in fieldList)
                {
                    elem.Attributes["ownedByPlayer"].Value = fields.Single(x => x.Numer == elem.Attributes["number"].Value).Stan.ToString(); //przypisanie wartosci stanu pola gdzie zmienna Numer jest rowna numerowi w atrybucie nummber w wezle field
                }
                Xeconomy.Save(path);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
