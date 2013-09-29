using System.IO.IsolatedStorage;

namespace Classes
{
    public static class StorageManager
    {
        public static IsolatedStorageSettings StorageSettings = IsolatedStorageSettings.ApplicationSettings;

        public static object Get(string ID, object DefaultValue)
        {
            if (StorageSettings.Contains(ID))
            {
                try
                {
                    return StorageSettings[ID];
                }
                catch
                {
                    StorageSettings[ID] = DefaultValue;
                    StorageSettings.Save();
                    return StorageSettings[ID];
                }
            }
            else
            {
                StorageSettings.Add(ID, DefaultValue);
                StorageSettings.Save();
                return StorageSettings[ID];
            }
        }
        public static void Set(string ID, object NewValue)
        {
            if (StorageSettings.Contains(ID))
            {
                StorageSettings[ID] = NewValue;
            }
            else
            {
                StorageSettings.Add(ID, NewValue);
                StorageSettings.Save();
            }
        }
    }
}