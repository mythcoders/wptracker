using System;
using System.IO.IsolatedStorage;
using System.Diagnostics;

namespace WP7_Tracker
{
    public class AppSettings
    {
        IsolatedStorageSettings isolatedStore;

        const string DefaultViewKeyName = "DefaultView";
        const string VersionFeedbackKeyName = "VersionFeedback";
        const string StatusBarKeyName = "StatusBar";

        const int DefaultViewDefault = 0;
        const bool VersionFeedbackDefault = true;
        const bool StatusBarDefault = true;

        public AppSettings()
        {
            try
            {
                isolatedStore = IsolatedStorageSettings.ApplicationSettings;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception while using IsolatedStorageSettings: " + e.ToString());
            }
        }

        public bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;

            if (isolatedStore.Contains(Key))
            {
                if (isolatedStore[Key] != value)
                {
                    isolatedStore[Key] = value;
                    valueChanged = true;
                }
            }
            else
            {
                isolatedStore.Add(Key, value);
                valueChanged = true;
            }

            return valueChanged;
        }

        public valueType GetValueOrDefault<valueType>(string Key, valueType defaultValue)
        {
            valueType value;

            if (isolatedStore.Contains(Key))
            {
                value = (valueType)isolatedStore[Key];
            }
            else
            {
                value = defaultValue;
            }

            return value;
        }

        public void Save()
        {
            isolatedStore.Save();
        }

        public bool StatusBar
        {
            get
            {
                return GetValueOrDefault<bool>(StatusBarKeyName, StatusBarDefault);
            }
            set
            {
                AddOrUpdateValue(StatusBarKeyName, value);
                Save();
            }
        }

        public int DefaultView
        {
            get
            {
                return GetValueOrDefault<int>(DefaultViewKeyName, DefaultViewDefault);
            }
            set
            {
                AddOrUpdateValue(DefaultViewKeyName, value);
                Save();
            }
        }

        public bool VesionFeedback
        {
            get
            {
                return GetValueOrDefault<bool>(VersionFeedbackKeyName, VersionFeedbackDefault);
            }
            set
            {
                AddOrUpdateValue(VersionFeedbackKeyName, value);
                Save();
            }
        }


    }
}