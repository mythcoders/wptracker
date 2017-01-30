using System;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WP7_Tracker.ViewModel.OS;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Primitives;
using Microsoft.Phone.Marketplace;

namespace WP7_Tracker
{

    public partial class App : Application
    {              
        private static LicenseInformation _licenseInfo = new LicenseInformation();

        private static MainViewModel viewModel = null;

        /// <summary>
        /// A static ViewModel used by the views to bind against.
        /// </summary>
        /// <returns>The MainViewModel object.</returns>
        public static MainViewModel ViewModel
        {
            get
            {
                // Delay creation of the view model until necessary
                if (viewModel == null)
                    viewModel = new MainViewModel();

                return viewModel;
            }
        }

        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public PhoneApplicationFrame RootFrame { get; private set; }
        

        private void RadDiagnostics_ExceptionOccurred(object sender, ExceptionOccurredEventArgs e)
        {
            //e.Cancel = true; setting Cancel to true will prevent the message box from displaying.
             // add any custom code here, like reporting to a custom web service
            //SendDiagnosticsToWebService((sender as RadDiagnostics).DiagnosticInfo);
        }

        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        { 
            // Global handler for uncaught exceptions. 
            UnhandledException += Application_UnhandledException;

            // Standard Silverlight initialization
            InitializeComponent();

            // Phone-specific initialization
            InitializePhoneApplication();

            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {

#if DEBUG
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

#endif
                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode, 
                // which shows areas of a page that are handed off to GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Disable the application idle detection by setting the UserIdleDetectionMode property of the
                // application's PhoneApplicationService object to Disabled.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

        }

        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
            ApplicationUsageHelper.Init("2.0");
            RadDiagnostics diagnostics = new RadDiagnostics();
            diagnostics.EmailTo = "support@adkinssd.com";
            diagnostics.ApplicationName = "[WP Tracker] Crash Report";
            diagnostics.ApplicationVersion = "2.0";

            diagnostics.Init();

            CheckTrialMode();
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
            CheckTrialMode();
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

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }            
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;
            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RadTransition transition = new RadTransition();
            transition.BackwardInAnimation = this.Resources["fadeInAnimation"] as RadFadeAnimation;
            transition.BackwardOutAnimation = this.Resources["fadeOutAnimation"] as RadFadeAnimation;
            transition.ForwardInAnimation = this.Resources["fadeInAnimation"] as RadFadeAnimation;
            transition.ForwardOutAnimation = this.Resources["fadeOutAnimation"] as RadFadeAnimation;
            transition.PlayMode = TransitionPlayMode.Consecutively;
            RadPhoneApplicationFrame frame = new RadPhoneApplicationFrame();
            frame.Transition = new RadFadeTransition();
            RootFrame = frame;
            RootFrame.Navigated += CompleteInitializePhoneApplication;
            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;
            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        #endregion

        LicenseInformation licenseInformation = new LicenseInformation();

        private void CheckTrialMode()
        {

#if DEBUG
            _isTrial = licenseInformation.IsTrial();
            _isDebug = true;            
            
            //MessageBoxResult result = MessageBox.Show("Press 'OK' to run with a trial license. Press 'Cancel' to use a full license.", "ASD License", MessageBoxButton.OKCancel);
            
            //if (result == MessageBoxResult.OK)
            //{
            //    licenseInformation.IsTrial();
            //    _isDebug = true;
            //}
            //else
            //{
            //    _isTrial = false;
            //    _isDebug = true;
            //}
#else
            isTrial = false;
#endif
        }

        bool _isDebug = false;
        public bool IsDebug
        {
            get
            {
                return _isDebug;
            }
        }

        bool _isTrial = true;
        public bool IsTrial
        {
            get
            {
                return _isTrial;
            }
        }
    }
}