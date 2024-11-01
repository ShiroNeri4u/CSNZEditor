using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using CSODataCore;
using Windows.Media;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CSNZEditor
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            ItemManager.ImportItem("C:\\Users\\KazamataNeri\\source\\repos\\CSNZEditor\\CSNZEditor\\bin\\x86\\Debug\\net8.0-windows10.0.19041.0\\win-x86\\item.csv");
            ItemManager.ImportLanguage("C:\\Users\\KazamataNeri\\source\\repos\\CSNZEditor\\CSNZEditor\\bin\\x86\\Debug\\net8.0-windows10.0.19041.0\\win-x86\\cso_chn.txt");
            ItemManager.ImportReinforce("C:\\Users\\KazamataNeri\\source\\repos\\CSNZEditor\\CSNZEditor\\bin\\x86\\Debug\\net8.0-windows10.0.19041.0\\win-x86\\ReinforceMaxLv.csv");
            ItemManager.LoadLanguage();
            Item[] items = ItemManager.Search("°ÍÀ×ÌØ");
            myButton.Content = items[1].TransName;

        }
    }
}
