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
    class Savegame
    {
        public static void Load(MainWindow control,string patch)
        {
            if (patch!=null)
            {
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
                                break;
                            case "rape":
                                control.rapeBox.Text = silo.Attributes["amount"].Value;
                                break;
                            case "wheat":
                                control.wheatBox.Text = silo.Attributes["amount"].Value;
                                break;
                            case "barley":
                                control.barleyBox.Text = silo.Attributes["amount"].Value;
                                break;
                            case "maize":
                                control.maizeBox.Text = silo.Attributes["amount"].Value;
                                break;
                            case "sugarBeet":
                                control.sugarBeetBox.Text = silo.Attributes["amount"].Value;
                                break;
                            case "woodChips":
                                control.woodChipsBox.Text = silo.Attributes["amount"].Value;
                                break;
                            case "grass":
                                control.grassBox.Text = silo.Attributes["amount"].Value;
                                break;
                            case "manure":
                                control.manureBox.Text = silo.Attributes["amount"].Value;
                                break;
                            case "liquidManure":
                                control.liquidManureBox.Text = silo.Attributes["amount"].Value;
                                break;
                            case "chaff":
                                control.chaffBox.Text = silo.Attributes["amount"].Value;
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
    }
}
