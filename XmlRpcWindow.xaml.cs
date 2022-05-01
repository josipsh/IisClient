using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Xml;

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
            String res = DoRequest(cityName.Text);

            result.Text = res;
        }

        private string DoRequest(string city)
        {
            byte[] body = PrepareBody(city);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8080");
            request.Method = "POST";
            request.Accept = "application/xml";
            request.ContentType = "application/xml";

            Stream requestBody = request.GetRequestStream();
            requestBody.Write(body, 0, body.Length);
            requestBody.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseBody = response.GetResponseStream();

            XmlDocument responseDoc = new XmlDocument();
            responseDoc.Load(responseBody);

            return "";
        }

        private byte[] PrepareBody(string city)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("");
            doc.DocumentElement.ChildNodes[0].InnerText = "DHMZ.fetchNewestDataFotCity";
            doc.DocumentElement.ChildNodes[1].ChildNodes[1].ChildNodes[0].ChildNodes[0].InnerText = city;

            MemoryStream stream = new MemoryStream();
            doc.Save(stream);

            return Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(stream.ToArray()));
        }
    }
}
