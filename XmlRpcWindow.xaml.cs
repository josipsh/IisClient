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
using System.Windows.Shapes;

namespace IisClient
{
    /// <summary>
    /// Interaction logic for XmlRpcWindow.xaml
    /// </summary>
    public partial class XmlRpcWindow : Window
    {
        public XmlRpcWindow()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Data result for city {cityName.Text}: \n");
            sb.Append($"\t Temp: 10.5 \n");
            sb.Append($"\t Temp: 10.5 \n");
            sb.Append($"\t Temp: 10.5 \n");

            result.Text = sb.ToString();
        }
    }
}
