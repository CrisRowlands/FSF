using System;
using System.Collections.Generic;

namespace Classes
{
    public static class FavouritesManager
    {
        public static Dictionary<String, Video> Favourites
        {
            get
            {
                return (Dictionary<String, Video>)StorageManager.Get("FavouriteList", new Dictionary<String, Video>());
            }
            set
            {
                StorageManager.Set("FavouriteList", value);
            }
        }
        public static bool IsFavourite(String ID)
        {
            return Favourites.ContainsKey(ID);
        }
        public static void RemoveFavourite(String ID)
        {
            Favourites.Remove(ID);
        }
        public static void ClearFavourites()
        {
            Favourites = new Dictionary<String, Video>();
        }
    }
}