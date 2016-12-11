using System;
using System.Collections.Generic;
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
                    box.IsEnabled = false; //wylacza wszystkie kontrolki textbox
                    box.Clear(); //przed zaladowaniem wartosci czysci wczesniej załadowane
                }
                XmlDocument Xcareer = new XmlDocument(); //przechowuje zawartosc XML
                try
                {
                    Xcareer.Load(patch);
                    XmlNodeList XNodeSilo = Xcareer.GetElementsByTagName("farmSiloAmount"); //tworzymy liste wezlow zawartych w wezle farmSiloAmount
                    foreach (XmlNode silo in XNodeSilo)
                    {
                        #region wprowadzanie wartosci w odpowiednie textBoxy
                        switch (silo.Attributes["fillType"].Value)
                        {
                            case "potato":
                                control.potatoBox.Text = Format.GiveMeDigits(silo.Attributes["amount"].Value); //dla wezla o atrybucie filltype przypisz dla kontroli textbox wartosc atrybutu amount znajdujacego sie na tym samym poziomie
                                control.potatoBox.IsEnabled = true; //wlaczenie kontrolki
                                break;
                            case "rape":
                                control.rapeBox.Text = Format.GiveMeDigits(silo.Attributes["amount"].Value);
                                control.rapeBox.IsEnabled = true;
                                break;
                            case "wheat":
                                control.wheatBox.Text = Format.GiveMeDigits(silo.Attributes["amount"].Value);
                                control.wheatBox.IsEnabled = true;
                                break;
                            case "barley":
                                control.barleyBox.Text = Format.GiveMeDigits(silo.Attributes["amount"].Value);
                                control.barleyBox.IsEnabled = true;
                                break;
                            case "maize":
                                control.maizeBox.Text = Format.GiveMeDigits(silo.Attributes["amount"].Value);
                                control.maizeBox.IsEnabled = true;
                                break;
                            case "sugarBeet":
                                control.sugarBeetBox.Text = Format.GiveMeDigits(silo.Attributes["amount"].Value);
                                control.sugarBeetBox.IsEnabled = true;
                                break;
                            case "woodChips":
                                control.woodChipsBox.Text = Format.GiveMeDigits(silo.Attributes["amount"].Value);
                                control.woodChipsBox.IsEnabled = true;
                                break;
                            case "grass":
                                control.grassBox.Text = Format.GiveMeDigits(silo.Attributes["amount"].Value);
                                control.grassBox.IsEnabled = true;
                                break;
                            case "manure":
                                control.manureBox.Text = Format.GiveMeDigits(silo.Attributes["amount"].Value);
                                control.manureBox.IsEnabled = true;
                                break;
                            case "liquidManure":
                                control.liquidManureBox.Text = Format.GiveMeDigits(silo.Attributes["amount"].Value);
                                control.liquidManureBox.IsEnabled = true;
                                break;
                            case "chaff":
                                control.chaffBox.Text = Format.GiveMeDigits(silo.Attributes["amount"].Value);
                                control.chaffBox.IsEnabled = true;
                                break;
                        }
                        #endregion
                    }
                    XmlNode myNode = Xcareer.SelectSingleNode("/careerSavegame");
                    control.moneyBox.IsEnabled = true;
                    control.moneyBox.Text = myNode.Attributes["money"].Value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }   
        }
        public static void Save(string path, MainWindow control)
        {
            if (File.Exists(path))
            {
                XmlDocument Xcareer = new XmlDocument(); //przechowuje zawartosc dokumentu XML
                try
                {
                    Xcareer.Load(path);
                    XmlNodeList XNodeSilo = Xcareer.GetElementsByTagName("farmSiloAmount"); //tworzymy liste wezlow zawartych w wezle farmSiloAmount
                    foreach (XmlNode silo in XNodeSilo)
                    {
                        #region wyprowadzenie wartosci z odpowiednich textBoxów
                        switch (silo.Attributes["fillType"].Value)
                        {
                            case "potato":
                                silo.Attributes["amount"].Value = control.potatoBox.Text; //dla wezla o atrybucie filltype przypisz dla atrybutu amount znajdujacego sie na tym samym poziomie wartosc kontrolki textbox
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
                    XmlNode myNode = Xcareer.SelectSingleNode("/careerSavegame"); //wybor pojedynczego wezla
                    myNode.Attributes["money"].Value = control.moneyBox.Text; //zmiana wartosci atrybutu money
                    Xcareer.Save(path);
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
