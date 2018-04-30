using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using DXApplication4.ViewModels;
using DXApplication4.Views;

namespace DXApplication4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DoorControl_Click(object sender, RoutedEventArgs e)
        {
            //SearchView.IsEnabled = false;
            //DoorView.IsEnabled = true;
           View.Source = new Uri("Views/DoorControlView.xaml",UriKind.Relative);
            //DoorView.IsVisible();
        }

        private void SearchControl_Click(object sender, RoutedEventArgs e)
        {
            //DoorView.IsEnabled = false;
            //SearchView.IsEnabled =true;
            //SearchView.IsVisible();
            View.Source = new Uri("Views/SearchView.xaml", UriKind.Relative);

        }
    }
}
