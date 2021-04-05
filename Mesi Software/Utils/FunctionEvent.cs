using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;

namespace Mesi_Software.Utils
{
    internal static class FunctionEvent
    {
        static MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

        internal static void mainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double hauteur = mainWindow.Height;
            double largeur = mainWindow.Width;

            if (mainWindow.WindowState == WindowState.Maximized)
            {
                Debug.WriteLine("maximiser");
                hauteur = SystemParameters.PrimaryScreenHeight;
                largeur = SystemParameters.PrimaryScreenWidth;
            }

            double PlusGrand = hauteur > largeur ? hauteur : largeur;

            double vMaxNormal = PlusGrand / 35;
            double vMaxTitre = PlusGrand / 25;
            double vMaxInfo = PlusGrand / 50;
            double vMaxInput = PlusGrand / 40;

            Application.Current.Resources["FontSizeTitre"] = vMaxTitre;
            Application.Current.Resources["FontSizeNormal"] = vMaxNormal;
            Application.Current.Resources["FontSizeInfo"] = vMaxInfo;
            Application.Current.Resources["FontSizeInput"] = vMaxInput;
            Application.Current.Resources["FontSizeReponse"] = vMaxInput;
        }
    }

}
