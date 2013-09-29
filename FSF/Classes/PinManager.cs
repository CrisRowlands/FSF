using Microsoft.Phone.Shell;
using System;
using System.Linq;
using System.Windows;

namespace Classes
{
    public static class PinManager
    {
        public static void PinPage(string ID, string Name)
        {
            if (!PinManager.TileExists(ID))
            {
                ShellTile.Create(new Uri("/_Pages/_Editor.xaml?VideoID=" + ID, UriKind.Relative), new FlipTileData
                {
                    Title = Name
                }, false);
            }
            else
            {
                MessageBox.Show("I can't pin the same video more than once, that would just be silly.",
                    "Video already pinned.",
                    MessageBoxButton.OK);
            }
        }
        private static bool TileExists(string ID)
        {
            ShellTile TileToCheck = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("VideoID=" + ID));
            return (TileToCheck != null);
        }
    }
}