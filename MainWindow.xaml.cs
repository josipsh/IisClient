using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IisClient
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BoughtAsset_Click(object sender, RoutedEventArgs e)
        {
            AddBoughtAssetRecordWindow window= new AddBoughtAssetRecordWindow();
            window.Show();
        }

        private void SoldAsset_Click(object sender, RoutedEventArgs e)
        {
            new AddSoldAssetRecordWindow().Show();
        }

        private void GetAnalyst_Click(object sender, RoutedEventArgs e)
        {

        }

        private void XmlRpc_Click(object sender, RoutedEventArgs e)
        {
            new XmlRpcWindow().Show();
        }
    }
}
