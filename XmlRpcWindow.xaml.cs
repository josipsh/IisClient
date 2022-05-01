using IisClient.Dto;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Xml;

namespace IisClient
{
    public partial class XmlRpcWindow : Window
    {
        public XmlRpcWindow()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            result.Text = "";

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

            string encodedBody = responseDoc.GetElementsByTagName("value").Item(0).InnerText;

            string json = Encoding.UTF8.GetString(Convert.FromBase64String(encodedBody));

            WeatherDataDto? weatherData = JsonConvert.DeserializeObject<WeatherDataDto>(json);

            if (weatherData == null)
            {
                return "Unexpeced error occured!";
            }

            if (weatherData.errorMessage.Length > 0)
            {
                return weatherData.errorMessage;
            }

            return weatherData.ToString();
        }

        private byte[] PrepareBody(string city)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Helpers/XmlPrxRequestBodyTemplate.xml");
            doc.DocumentElement.ChildNodes[0].InnerText = "DHMZ.fetchNewestDataFotCity";
            doc.DocumentElement.ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes[0].InnerText = city;

            MemoryStream stream = new MemoryStream();
            doc.Save(stream);

            return Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(stream.ToArray()));
        }
    }
}
