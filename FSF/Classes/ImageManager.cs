using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Classes
{
    public static class ImageManager
    {
        private static int ImageCounter
        {
            get
            {
                return (int)StorageManager.Get("imageCounter", 0);
            }
            set
            {
                StorageManager.Set("imageCounter", value);
            }
        }
        private static string ParseAddress(string UnparsedAddress)
        {
            if (ImageDictionary.ContainsKey(UnparsedAddress))
            {
                return ImageDictionary[UnparsedAddress];
            }
            else
            {
                ImageCounter++;
                ImageDictionary.Add(UnparsedAddress, ImageCounter.ToString());
                return ImageCounter.ToString();
            }
        }
        private static Dictionary<String, String> ImageDictionary
        {
            get
            {
                return (Dictionary<String, String>)StorageManager.Get("imageDictionary", new Dictionary<String, String>());
            }
            set
            {
                StorageManager.Set("imageDictionary", value);
            }
        }
        public static BitmapImage CachedImage(string Address)
        {
            if (Address == "/Images/Grey.png") { return new BitmapImage(new Uri("/Images/Grey.png", UriKind.Relative)); }
            string ParsedUrl = ParseAddress(Address);

            using (IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isolatedStorageFile.FileExists("imgCache/" + ParsedUrl))
                {
                    try
                    {
                        using (IsolatedStorageFileStream FileStream = IsolatedStorageFile.GetUserStoreForApplication().OpenFile("imgCache\\" + ParsedUrl, FileMode.Open, FileAccess.Read))
                        {
                            BitmapImage _Bitmap = new BitmapImage();
                            _Bitmap.SetSource(FileStream);
                            return _Bitmap;
                        }
                    }
                    catch
                    {
                        BitmapImage _Bitmap = new BitmapImage();
                        _Bitmap.ImageOpened += CachedImageOpened;
                        _Bitmap.UriSource = new Uri(Address, UriKind.RelativeOrAbsolute);
                        return _Bitmap;
                    }
                }
                else
                {
                    BitmapImage _Bitmap = new BitmapImage();
                    _Bitmap.ImageOpened += CachedImageOpened;
                    _Bitmap.UriSource = new Uri(Address, UriKind.RelativeOrAbsolute);
                    return _Bitmap;
                }
            }
        }
        private static void CachedImageOpened(object sender, RoutedEventArgs e)
        {
            BitmapImage SenderBitmap = sender as BitmapImage;
            string ParsedAddress = ParseAddress(SenderBitmap.UriSource.OriginalString);

            using (IsolatedStorageFile _IsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!_IsolatedStorage.DirectoryExists("imgCache"))
                {
                    _IsolatedStorage.CreateDirectory("imgCache");
                }
                if (_IsolatedStorage.FileExists("imgcache/" + ParsedAddress))
                {
                    _IsolatedStorage.DeleteFile("imgcache/" + ParsedAddress);
                }

                IsolatedStorageFileStream Stream = new IsolatedStorageFileStream("imgcache\\" + ParsedAddress, FileMode.OpenOrCreate, FileAccess.ReadWrite, _IsolatedStorage);
                WriteableBitmap _WriteableBitmap = new WriteableBitmap(SenderBitmap);
                _WriteableBitmap.SaveJpeg(Stream, _WriteableBitmap.PixelWidth, _WriteableBitmap.PixelHeight, 0, 100);
                Stream.Close();
            }
        }
        public static void ClearCache()
        {
            StorageManager.Set("imageDictionary", new Dictionary<String, String>());

            using (IsolatedStorageFile _IsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!_IsolatedStorage.DirectoryExists("imgCache"))
                {
                    return;
                }

                string[] Files = _IsolatedStorage.GetFileNames("imgCache\\*");
                if (Files.Length > 0)
                {
                    for (int i = 0; i < Files.Length; ++i)
                    {
                        _IsolatedStorage.DeleteFile("imgCache\\" + Files[i]);
                    }
                }
            }
            ImageCounter = 0;
        }
        public static BitmapImage BitmapFromString(string Address)
        {
            return new BitmapImage(new Uri(Address, UriKind.RelativeOrAbsolute))
            {
                CreateOptions = BitmapCreateOptions.None
            };
        }
    }
}