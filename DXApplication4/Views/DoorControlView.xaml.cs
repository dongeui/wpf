using DXApplication4.ViewModels;
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

namespace DXApplication4.Views
{
    /// <summary>
    /// Interaction logic for DoorControlView.xaml
    /// </summary>
    public partial class DoorControlView : UserControl
    {
        DoorControlViewModel doorViewModel;
        public DoorControlView()
        {
            InitializeComponent();
            doorViewModel = new DoorControlViewModel();
            this.DataContext = doorViewModel;
        }

        private void GridControl_CurrentItemChanged(object sender, DevExpress.Xpf.Grid.CurrentItemChangedEventArgs e)
        {
            doorViewModel.ChangeGroupEvent(sender, e);
        }
    }
}
