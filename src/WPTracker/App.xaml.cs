using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Telerik.Windows.Controls;
using Microsoft.Phone.Notification;
using Microsoft.Phone.Marketplace;
using Microsoft.WindowsAzure.MobileServices;
using WPTracker.ViewModels.Phones;
using WPTracker.Helpers;
using Microsoft.WindowsAzure.Messaging;

namespace WPTracker
{
    public partial class App : Application
    {
        #region Telerik & Other Utilities
        
        public RadDiagnostics diagnostics;
        public RadRateApplicationReminder rateReminder;
        
        public PhoneApplicationFrame RootFrame { get; private set; }

        #endregion
        
        #region Azure

        //Azure Settings - Database/Mobile Service - DO NOT MODIFY!
        public static MobileServiceClient MobileService = new MobileServiceClient(

            //URL for Application - DO NOT MODIFY!
            "https://wptracker.azure-mobile.net/",          
            
            //Application Access Key - DO NOT MODIFY!
            "tlpGStAlItGenLWxmNuuOMDyGuFPyE18");
        
        #endregion

        #region Application Variables

        public static WPTracker.Data.Phones SelectedPhone { get; set; }
        public static WPTracker.Data.OSVersions SelectedVersion { get; set; }
        public static WPTracker.Data.Phones MyPhone { get; set; }
        public static string MyDevice { get; set; }
        public static string XMLLastUpdated { get; set; }
        public static string XMLVersion { get; set; }
        public static string XMLLatestVersion { get; set; }
        public static bool XMLUpdating { get; set; }
        public bool _toastNotifications;
        public bool offlineData;
        
        #endregion
            
        public App()
        {
            UnhandledException += Application_UnhandledException;
            
            InitializeComponent();
            
            InitializePhoneApplication();
                
            if (System.Diagnostics.Debugger.IsAttached)
            {
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }
            
            #region [TELERIK] Settings
            
            diagnostics = new RadDiagnostics();
            diagnostics.EmailTo = "support@adkinssd.com";
            diagnostics.ApplicationName = "WPTracker";
            diagnostics.ApplicationVersion = "Version 3.0.alpha";
            diagnostics.HandleUnhandledException = true;
            diagnostics.Init();
            
            rateReminder = new RadRateApplicationReminder();
            rateReminder.RecurrencePerUsageCount = 2;
            rateReminder.AllowUsersToSkipFurtherReminders = true;

            //Set up theme.
            ThemeManager.SetAccentColor(AccentColor.NokiaBlue);
            ThemeManager.ToLightTheme();
        }
        
        #endregion

        private void PushNotifications()
        {
            AppSettings settings = (AppSettings)this.Resources["AppSettings"];
                
            if (settings.ToastNotificationSetting == true)
            {
                var channel = HttpNotificationChannel.Find("MyPushChannel");
                if (channel == null)
                {
                    channel = new HttpNotificationChannel("MyPushChannel");
                    channel.Open();
                    channel.BindToShellToast();
                }
                    
                channel.ChannelUriUpdated += new EventHandler<NotificationChannelUriEventArgs>(async (o, args) =>
                {
                    var hub = new NotificationHub("wptracker", "Endpoint=sb://wptracker-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=CdXM6iIWh9epI9g/LPHSh4AjfICvMOxiLZ08Rxrh/os=");
                    await hub.RegisterNativeAsync(args.ChannelUri.ToString());
                });
            }
            else
            {
                var channel = HttpNotificationChannel.Find("MyPushChannel");
                if (channel == null)
                {
                    channel = new HttpNotificationChannel("MyPushChannel");
                    channel.Close();                    
                }
            }
        }
        
        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
            PushNotifications();
            
            ApplicationUsageHelper.Init("3.0.alpha");
            ApplicationUsageHelper.OnApplicationActivated();

            var myDevice = PhoneNameResolver.Resolve(
                Microsoft.Phone.Info.DeviceStatus.DeviceManufacturer,
                Microsoft.Phone.Info.DeviceStatus.DeviceName);

            MyDevice = myDevice.CanonicalModel;
        }
        
        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
           PushNotifications();
            
            if (!e.IsApplicationInstancePreserved)
            {
                ApplicationUsageHelper.OnApplicationActivated();
            }
        }
        
        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {

        }
        
        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {

        }
            
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                System.Diagnostics.Debugger.Break();
            }
        }
            
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                System.Diagnostics.Debugger.Break();
            }
        }
                   
        #region [TELERIK] Phone application initialization
        
        private bool phoneApplicationInitialized = false;
            
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;
            RootFrame = new RadPhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;
            
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            phoneApplicationInitialized = true;
        }
            
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;
        
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        #endregion
    }
}
