using Microsoft.Phone.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;

namespace Classes
{
    public static class VideoManager
    {
        public static Feed Films = new Feed("Films", "http://5secondfilms.com/films/recent");
        public static Feed Sketches = new Feed("Sketches", "http://5secondfilms.com/sketches/recent");
        public static Feed CommentsOfTheWeek = new Feed("CommentsOfTheWeek", "http://5secondfilms.com/extras/cotw");
        public static Feed BehindTheScenes = new Feed("BehindTheScenes", "http://5secondfilms.com/extras/bts");
        public static Feed WeekInReview = new Feed("WeekInReview", "http://5secondfilms.com/extras/week");

        public static void Update()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("No internet connection available.", "Error.", MessageBoxButton.OK);
                return;
            }

            Films.Update();
            Sketches.Update();
            CommentsOfTheWeek.Update();
            BehindTheScenes.Update();
            WeekInReview.Update();
        }
        public static void Clear()
        {
            Films.Clear();
            Sketches.Clear();
            CommentsOfTheWeek.Clear();
            BehindTheScenes.Clear();
            WeekInReview.Clear();
        }
        public static bool IsDownloading
        {
            get
            {
                if (Films.IsDownloading) return true;
                if (Sketches.IsDownloading) return true;
                if (CommentsOfTheWeek.IsDownloading) return true;
                if (BehindTheScenes.IsDownloading) return true;
                if (WeekInReview.IsDownloading) return true;
                return false;
            }
        }
    }

    public class Feed
    {
        public Feed(string name, string url)
        {
            this.Name = name;
            this.Url = url;
            IsDownloading = false;
        }

        public string Name { get; set; }
        private string Url { get; set; }
        public bool IsDownloading { get; set; }

        public List<Video> Latest(int count)
        {
            if (Videos.Count < count)
            {
                return Videos;
            }
            else
            {
                List<Video> ReturnList = new List<Video>();

                for (int i = 0; i < count; i++)
                {
                    ReturnList.Add(Videos[i]);
                }

                return ReturnList;
            }
        }
        public List<Video> Videos
        {
            get
            {
                return (List<Video>)StorageManager.Get(Name, new List<Video>());
            }
            set
            {
                StorageManager.Set(Name, value);
            }
        }

        public void Update()
        {
            if (IsDownloading) return;
            IsDownloading = true;

            HttpWebRequest NewsRequest = (HttpWebRequest)WebRequest.Create(Url);
            NewsRequest.BeginGetResponse(r =>
            {
                IsDownloading = false;

                try
                {
                    var httpRequest = (HttpWebRequest)r.AsyncState;
                    var httpResponse = (HttpWebResponse)httpRequest.EndGetResponse(r);

                    if (httpResponse.StatusCode != HttpStatusCode.OK) return;

                    using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string response = reader.ReadToEnd();

                        Deployment.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            // ADD NEW VIDEOS TO THE FEED.
                            UpdateDisplay();
                        }));
                    }
                }
                catch { }
            }, NewsRequest);
        }
        public void Clear()
        {
            Videos = new List<Video>();
        }
        private void UpdateDisplay()
        {
            //    if (Helper.PageString == "/Pages/Home.xaml")
            //    {
            //        //PPC.Pages.Home.LoadTileImages();

            //        if (Name == "NewsFeed")
            //        {
            //            PPC.Pages.Home.Lst_News.ItemsSource = LatestThree;
            //        }

            //        if (Name == "WallpaperFeed")
            //        {
            //            PPC.Pages.Home.Lst_Wallpaper.ItemsSource = LatestSix;
            //        }

            //        if (!FeedManager.IsDownloading)
            //        {
            //            // STOP LOADING MESSAGE #LoadingBay
            //        }
            //    }

            //    if (Helper.PageString.StartsWith("/Pages/Articles.xaml") && PPC.Pages.Articles.FeedString == Name)
            //    {
            //        PPC.Pages.Articles.Lst_Feed.ItemsSource = Articles;

            //        if (!FeedManager.IsDownloading)
            //        {
            //            // STOP LOADING MESSAGE #LoadingBay
            //        }
            //    }
        }
    }

    public class Video
    {
        public string ID { get; set; }
        public string VideoName { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string ScreenshotUrl { get { return "http://img.youtube.com/vi/" + this.ID + "/0.jpg"; } }
    }
}