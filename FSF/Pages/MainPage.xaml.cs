using Classes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Net.NetworkInformation;
using Microsoft.Phone.Shell;
using MyToolkit.Multimedia;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FSF.Pages
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            rec_cover.Visibility = prog_video.Visibility = System.Windows.Visibility.Collapsed;

            (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled =
            (ApplicationBar.Buttons[1] as ApplicationBarIconButton).IsEnabled =
            (ApplicationBar.MenuItems[0] as ApplicationBarMenuItem).IsEnabled =
            (ApplicationBar.MenuItems[1] as ApplicationBarMenuItem).IsEnabled = true;
        }

        private void LoadData()
        {
            Video v = VideoManager.Films.Videos[0];
            btn_latest.Tag = v.ID;
            img_latest.Source = ImageManager.BitmapFromString(v.ScreenshotUrl);
            txt_LatestName.Text = v.VideoName;
            txt_LatestDes.Text = v.Description;

            lst_films.ItemsSource = VideoManager.Films.Latest(8);
            lst_sketches.ItemsSource = VideoManager.Sketches.Latest(8);
        }

        #region MORE VIDEO CLICKS

        private void AllFilmsClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Nav("Videos", "?source=fil");
        }
        private void AllSketchesClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Nav("Videos", "?source=ske");
        }
        private void Cotw_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Nav("Videos", "?source=cot");
        }
        private void Bts_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Nav("Videos", "?source=bts");
        }
        private void Wir_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Nav("Videos", "?source=wir");
        }
        private void Mtcac_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Nav("CastCrew");
        }

        #endregion
        #region APPBAR BUTTON HANDLES

        private void Random_Click(object sender, EventArgs e)
        {

        }
        private void Search_Click(object sender, EventArgs e)
        {
            Nav("Search");
        }
        private void About_Click(object sender, EventArgs e)
        {
            Nav("About");
        }
        private void Settings_Click(object sender, EventArgs e)
        {
            Nav("Settings");
        }

        #endregion

        private void Nav(string page, string query = "")
        {
            NavigationService.Navigate(new Uri("/Pages/" + page + ".xaml" + query, UriKind.Relative));
        }
        private void PlayVideo(object sender, System.Windows.RoutedEventArgs e)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                rec_cover.Visibility = prog_video.Visibility = System.Windows.Visibility.Visible;

                (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled =
                (ApplicationBar.Buttons[1] as ApplicationBarIconButton).IsEnabled =
                (ApplicationBar.MenuItems[0] as ApplicationBarMenuItem).IsEnabled =
                (ApplicationBar.MenuItems[1] as ApplicationBarMenuItem).IsEnabled = false;

                YouTube.Play((sender as Button).Tag.ToString(), YouTubeQuality.Quality720P, (x) =>
                {
                    if (x != null)
                    {
                        Dispatcher.BeginInvoke(() =>
                        {
                            MessageBox.Show("Sorry about this, something went wrong while trying to get the video. Here is the error message returned:\n\n" + x.Message, "Can't play video.", MessageBoxButton.OK);
                        });
                    }
                });
            }
            else
            {
                MessageBox.Show("No internet connection available.", "Can't play video.", MessageBoxButton.OK);
            }
        }
    }
}