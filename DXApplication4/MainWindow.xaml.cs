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
    public partial class MainWindow 
    {
        DoorControlViewModel doorViewModel;
        SearchViewModel searchViewModel;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new DoorControlViewModel();
            this.DataContext = new SearchViewModel();
        }

        private void DoorControl_Click(object sender, RoutedEventArgs e)
        {
           View.Source = new Uri("Views/DoorControlView.xaml",UriKind.Relative);
        }

        private void SearchControl_Click(object sender, RoutedEventArgs e)
        {
            View.Source = new Uri("Views/SearchView.xaml", UriKind.Relative);
        }
    }
}
