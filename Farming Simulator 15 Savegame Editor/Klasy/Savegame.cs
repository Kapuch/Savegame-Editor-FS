using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Farming_Simulator_15_Savegame_Editor
{
    class Savegame
    {
        public static void Load(string patch, MainWindow control, List<TextBox> allBox)
        {
            if (File.Exists(patch))
            {
                foreach (var box in allBox)
                {
                    box.IsEnabled = false;
                    box.Clear();
                }
                XmlDocument Xcareer = new XmlDocument();
                try
                {
                    Xcareer.Load(patch);
                    XmlNodeList XNodeSilo = Xcareer.GetElementsByTagName("farmSiloAmount");
                    foreach (XmlNode silo in XNodeSilo)
                    {
                        #region wprowadzanie wartosci w odpowiednie textBoxy
                        switch (silo.Attributes["fillType"].Value)
                        {
                            case "potato":
                                control.potatoBox.Text = silo.Attributes["amount"].Value;
                                control.potatoBox.IsEnabled = true;
                                break;
                            case "rape":
                                control.rapeBox.Text = silo.Attributes["amount"].Value;
                                control.rapeBox.IsEnabled = true;
                                break;
                            case "wheat":
                                control.wheatBox.Text = silo.Attributes["amount"].Value;
                                control.wheatBox.IsEnabled = true;
                                break;
                            case "barley":
                                control.barleyBox.Text = silo.Attributes["amount"].Value;
                                control.barleyBox.IsEnabled = true;
                                break;
                            case "maize":
                                control.maizeBox.Text = silo.Attributes["amount"].Value;
                                control.maizeBox.IsEnabled = true;
                                break;
                            case "sugarBeet":
                                control.sugarBeetBox.Text = silo.Attributes["amount"].Value;
                                control.sugarBeetBox.IsEnabled = true;
                                break;
                            case "woodChips":
                                control.woodChipsBox.Text = silo.Attributes["amount"].Value;
                                control.woodChipsBox.IsEnabled = true;
                                break;
                            case "grass":
                                control.grassBox.Text = silo.Attributes["amount"].Value;
                                control.grassBox.IsEnabled = true;
                                break;
                            case "manure":
                                control.manureBox.Text = silo.Attributes["amount"].Value;
                                control.manureBox.IsEnabled = true;
                                break;
                            case "liquidManure":
                                control.liquidManureBox.Text = silo.Attributes["amount"].Value;
                                control.liquidManureBox.IsEnabled = true;
                                break;
                            case "chaff":
                                control.chaffBox.Text = silo.Attributes["amount"].Value;
                                control.chaffBox.IsEnabled = true;
                                break;
                        }
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }   
        }
        public static void Save(string patch, MainWindow control)
        {
            if (File.Exists(patch))
            {
                XmlDocument Xcareer = new XmlDocument();
                try
                {
                    Xcareer.Load(patch);
                    XmlNodeList XNodeSilo = Xcareer.GetElementsByTagName("farmSiloAmount");
                    foreach (XmlNode silo in XNodeSilo)
                    {
                        #region wyprowadzenie wartosci z odpowiednich textBoxów
                        switch (silo.Attributes["fillType"].Value)
                        {
                            case "potato":
                                silo.Attributes["amount"].Value = control.potatoBox.Text;
                                break;
                            case "rape":
                                silo.Attributes["amount"].Value = control.rapeBox.Text;
                                break;
                            case "wheat":
                                silo.Attributes["amount"].Value = control.wheatBox.Text;
                                break;
                            case "barley":
                                silo.Attributes["amount"].Value = control.barleyBox.Text;
                                break;
                            case "maize":
                                silo.Attributes["amount"].Value = control.maizeBox.Text;
                                break;
                            case "sugarBeet":
                                silo.Attributes["amount"].Value = control.sugarBeetBox.Text;
                                break;
                            case "woodChips":
                                silo.Attributes["amount"].Value = control.woodChipsBox.Text;
                                break;
                            case "grass":
                                silo.Attributes["amount"].Value = control.grassBox.Text;
                                break;
                            case "manure":
                                silo.Attributes["amount"].Value = control.manureBox.Text;
                                break;
                            case "liquidManure":
                                silo.Attributes["amount"].Value = control.liquidManureBox.Text;
                                break;
                            case "chaff":
                                silo.Attributes["amount"].Value = control.chaffBox.Text;
                                break;
                        }
                        #endregion
                    }
                    Xcareer.Save(patch);
                    MessageBox.Show("Zapisano.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
