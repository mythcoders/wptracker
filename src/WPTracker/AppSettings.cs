using System;
using System.IO.IsolatedStorage;
using System.Diagnostics;

namespace WPTracker
{
    public class AppSettings
    {
        readonly IsolatedStorageSettings settings;

        const string ToastNotificationSettingKeyName = "ToastNotificationSetting";
        const string OfflineDataSettingKeyName = "OfflineDataSetting";
        const string DatabaseLastUpdateSettingKeyName = "DatabaseLastUpdateSetting";

        const bool ToastNotificationSettingDefault = true;
        const bool OfflineDataSettingDefault = false;
        const string DatabaseLastUpdateSettingDefault = "Never";

        public AppSettings()
        {
            try
            {
                settings = IsolatedStorageSettings.ApplicationSettings;

            }
            catch (Exception e)
            {
                Debug.WriteLine("Error when trying to load Settings: " + e.ToString());
            }
        }

        public bool AddOrUpdateValue(string Key, Object value)
        {
            var valueChanged = false;

            if (settings.Contains(Key))
            {
                if (settings[Key] == value) return valueChanged;

                settings[Key] = value;
                valueChanged = true;
            }
            else
            {
                settings.Add(Key, value);
                valueChanged = true;
            }

            return valueChanged;
        }

        public T GetValueOrDefault<T>(string Key, T defaultValue)
        {
            T value;

            if (settings.Contains(Key))
            {
                value = (T)settings[Key];
            }
            else
            {
                value = defaultValue;
            }

            return value;
        }

        public void Save()
        {
            settings.Save();
        }

        //Settings

        public bool ToastNotificationSetting
        {
            get
            {
                return GetValueOrDefault<bool>(ToastNotificationSettingKeyName, ToastNotificationSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(ToastNotificationSettingKeyName, value))
                {
                    settings.Save();
                }

                settings.Save();
            }
        }

        public bool OfflineDataSetting
        {
            get
            {
                return GetValueOrDefault<bool>(OfflineDataSettingKeyName, OfflineDataSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(OfflineDataSettingKeyName, value))
                {
                    settings.Save();
                }

                settings.Save();
            }
        }

        public string DatabaseLastUpdateSetting
        {
            get
            {
                return GetValueOrDefault<string>(DatabaseLastUpdateSettingKeyName, DatabaseLastUpdateSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(DatabaseLastUpdateSettingKeyName, value))
                {
                    settings.Save();
                }

                settings.Save();
            }
        }
    }
}
