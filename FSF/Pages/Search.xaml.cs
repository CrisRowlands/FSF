using Microsoft.Phone.Controls;
using System;
using System.IO;
using System.Net;
using System.Windows;

namespace FSF.Pages
{
    public partial class Search : PhoneApplicationPage
    {
        public Search()
        {
            InitializeComponent();
            Loaded += Search_Loaded;
        }
        private void Search_Loaded(object sender, RoutedEventArgs e)
        {
            Txt_Search.Focus();
        }
        private void Txt_Search_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;

            this.Focus();
            prog_searching.Visibility = System.Windows.Visibility.Visible;

            HttpWebRequest SearchRequest = (HttpWebRequest)WebRequest.Create("http://www.5secondfilms.com/");//http://www.1800pocketpc.com/?s={0}&feed=rss2&timestamp={1}", _SearchTextBox.Text.Trim(), DateTime.Now.Ticks
            SearchRequest.BeginGetResponse(r =>
            {
                var httpRequest = (HttpWebRequest)r.AsyncState;
                var httpResponse = (HttpWebResponse)httpRequest.EndGetResponse(r);

                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    prog_searching.Visibility = System.Windows.Visibility.Visible;
                    return;
                }

                using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string response = reader.ReadToEnd();

                    Deployment.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        prog_searching.Visibility = System.Windows.Visibility.Visible;
                        //if (lst_results != null)
                        //{
                        //    lst_results.ItemsSource = ParseXMLFeed(response);
                        //}
                    }));
                }
            }, SearchRequest);

        }

    }
}