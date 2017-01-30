using System;
using System.ComponentModel;

using System.Collections.ObjectModel;


namespace WP7_Tracker.ViewModel.OS
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData()
        {
            //LineOne = OS Version
            //LineTwo = Codename
            //LineThree = Notes
            //LineFour = Change Log     \n• is what is used for a new line

            this.Items.Add(new ItemViewModel()
            {
                LineOne = "about",
                LineTwo = "information regarding OS builds",
                LineThree = "The OS builds screen lists updates that have been released to any Windows Phone device. Some updates include only partial change logs as they are too long to list. We have also included the updates codename or the name which it most commonly referred to as.",
                LineFour = "• N/A"
            });

            #region Windows Phone 7
            #region WP7 RTM
            this.Items.Add(new ItemViewModel() { 
                LineOne = "7.0.7004", 
                LineTwo = "rtm", 
                LineThree = "RTM of the Windows Phone 7 OS. This build shipped on all first generation devices at their launches.",
                LineFour = "• No changes to list" 
            });
            this.Items.Add(new ItemViewModel()
            {
                LineOne = "7.0.7008",
                LineTwo = "update fix",
                LineThree = "This build was released to fix future updating experiences. Oddly, this update caused major headaches for Microsoft. It was pushed to devices beginning in February 2011.",
                LineFour = "• Tweaked the updating process."
            });
            #endregion

            #region NoDo
            this.Items.Add(new ItemViewModel() { 
                LineOne = "7.0.7389", 
                LineTwo = "nodo - Sprint", 
                LineThree = "This build is exactly the same as 7390. Shipped with the HTC Arrive (Sprint).",
                LineFour = "• CDMA support \n• Copy and Paste \n• Faster startup and resume times for apps \n• Improved category search in Marketplace \n• Deeper Facebook integration \n• Performance tune ups" 
            });            
            this.Items.Add(new ItemViewModel() { 
                LineOne = "7.0.7390", 
                LineTwo = "nodo", 
                LineThree = "The first feature update to Windows Phone was codenamed 'NoDo'. ROMS for several devices on the internet several days before NoDo was officially pushed to devices on March 22, 2011. It's major new features were Copy and Paste and CMDA support, which allowed Sprint and later Verizon to launch their Windows Phone devices.",
                LineFour = "• CDMA support \n• Copy and Paste \n• Faster startup and resume times for apps \n• Improved category search in Marketplace \n• Deeper Facebook integration \n• Performance tune ups" 
            });
            this.Items.Add(new ItemViewModel() { 
                LineOne = "7.0.7392", 
                LineTwo = "fraudulent certificate", 
                LineThree = "Revoking of fraudulent certificates.",
                LineFour = "• Removed 5 fraudulent certificates." 
            });
            this.Items.Add(new ItemViewModel() { 
                LineOne = "7.0.7403", 
                LineTwo = "post no-do, pre mango", 
                LineThree = "intermediate update required for updating to Mango. There are no known changes with this build.",
                LineFour = "• No official change log"
            });
            #endregion

            #region Mango
            this.Items.Add(new ItemViewModel() { 
                LineOne = "7.10.7661", 
                LineTwo = "'mango' developer beta", 
                LineThree = "First preview of Mango for developers.",
                LineFour = "• No official change log"
            });
            this.Items.Add(new ItemViewModel() { 
                LineOne = "7.10.7712", 
                LineTwo = "'mango' release candidate", 
                LineThree = "Released about two or three weeks before Mango RTM'd. This update, included completed API's for developers along with numerous bug fixes. Some people questioned how much was different between this and the RTM of 7720. One feature that was not yet present was hidden wi-fi network support. Some users experienced trouble with Twitter contacts, but Microsoft confirmed this bug was not present in 7720.",
                LineFour = "• Twitter & LinkedIn integration \n• Numerous Bug Fixes \n• No official change log"
            });
            this.Items.Add(new ItemViewModel() { 
                LineOne = "7.10.7720", 
                LineTwo = "windows phone 7.5 'mango'", 
                LineThree = "Windows Phone 7.5 (codenamed 'Mango') is a major software update for Windows Phone, the mobile operating system by Microsoft. Although the OS internally identifies itself as version 7.1, it is marketed as version 7.5 in all published materials intended for end-users. The update was formally announced in New York on May 24, 2011, when Microsoft gave an in-depth preview of the update, shortly before which Steve Ballmer had disclosed that there would be over 500 features. Microsoft started rolling out Windows Phone 7.5 to both the United States and International markets on September 27, 2011. The first phones that came pre-loaded with Windows Phone 7.5 were released in the last quarter of 2011.",
                LineFour = "Messaging and social \n• Twitter and LinkedIn integration \n• Groups: organize contacts by groups \n• Facebook check-in support. \n• Windows Live Messenger and Facebook Chat integration. \n• Threads: all messaging communication organized in a single thread (Messenger, SMS, MMS). \n• Threaded email conversations support. \n• Linked email accounts: multiple email accounts can be combined and linked into one inbox. \n• Built-in voice-to-text/text-to-voice \n• Visual Voicemail \nBing \n• Bing Vision\n• Bing Audio \n• Bing Local Scout \n• Bing Quick Cards \n• Bing Maps: turn-by-turn navigation, voice guidance. \nOffice\n• Skydrive and Office 365 documents sync \n• Excel Mobile now supports adding additional macro functions. \n• Added 'To-Do' option when editing OneNote pages.\n• People tagging in the photos with Skydrive and Facebook sync \n• Photo auto-fix \n• Pictures tile is now animated. \n• Video sharing via MMS, Facebook, Skydrive, and email. \n• Pin any album to Start, including Facebook albums. \nMultimedia\n• Zune SmartDJ mix support. \n• Artist picture now displays on lock screen when music is played. \n• UI change of the media controls on the lock screen. \n• Ability to control video aspect ratio during playback. \n• Single music track repeat\n• Podcast downloads and subscriptions over the air (US only). \n• Ability to create and save playlists. \n• Settings are now saved when the Camera application is closed. \n• Disable/enable shutter sound. \n• Support for front facing camera. \n• Touch focus and capture \nGames\n• Redesigned Games hub with integrated 3D avatar and avatar customization. \n• Friends and achievements now integrated in the hub. \nInternet Explorer 9 Mobile\n• Hardware-accelerated rendering. \n• Support for HTML5 \n• New UI with URL bar at the bottom of the screen. \n• URL bar is now available in landscape mode. \nSecurity\n• Voice commands are now disabled when the device is locked. \n• Complex (alpha-numeric) PIN support. \nOther changes\n• Internet sharing \n• Battery saver: phone automatically disables power consuming services and applications running in the background if the battery is low. Also predicts time remaining on battery. \n• Ringtones \n• Search icon and quick jump list added to the application list."
            });
            this.Items.Add(new ItemViewModel() { 
                LineOne = "7.10.7740", 
                LineTwo = "exchange server fix", 
                LineThree = "7740 is available to all carriers that request it only. However, most carriers have chosen not to release this update including US Carriers.",
                LineFour = "• Fixed email issue in Microsoft Exchange Server 2003 \n• Voicemail notification issue"
            });
            #endregion

            #region 7.5 Refresh
            this.Items.Add(new ItemViewModel() { 
                LineOne = "7.10.8107", 
                LineTwo = "'mango' commercial release 2 (cr2)", 
                LineThree = "This update is known as 'Mango Commercial Release 2'. It's roll out has started in international markets and on Verizon Wireless in the US",
                LineFour = "• Fixed keyboard disappearing bug \n• Location access issue\n• LTE Support \n• Bug fixes"
            });
            this.Items.Add(new ItemViewModel()
            {
                LineOne = "7.10.8112",
                LineTwo = "'mango' commercial release 2 (cr2) - AT&T",
                LineThree = "This update is known as 'Mango Commercial Release 2' and ships on the Lumia 900 and HTC TITAN II. This version has not been seen on any other devices except for the Lumia 900 and TITAN II. It's possible that this is a AT&T specific build.",
                LineFour = "• Fixed keyboard disappearing bug \n• Location access issue\n• LTE Support \n• Bug fixes \n• AT&T Visual Voicemail & Internet Sharing (Tethering)"
            });
            #endregion

            #region Tango
            this.Items.Add(new ItemViewModel()
            {
                LineOne = "7.10.8773.98",
                LineTwo = "Tango",
                LineThree = "Released: June 28, 2013",
                LineFour = "• Better media messaging \n• Ability to send ringtones via MMS\n• Export and manage contacts to SIM card \n• Support for low-cost devices with 256 MB RAM and low clock CPU \n• New wallpapers \n• Letter indexing \n• More reliable notifications \n• Attachment download with Microsoft Exchange 2003 Server \n• Faster numeric PIN response \n• Location awareness icon \n• Minor improvements and changes"
            });
            this.Items.Add(new ItemViewModel()
            {
                LineOne = "7.10.8779.8",
                LineTwo = "Tango",
                LineThree = "Released: ?",
                LineFour = "• Fixes an issue with app purchases in some regions. \n• Changes default sync times for email"
            });
            this.Items.Add(new ItemViewModel()
            {
                LineOne = "7.10.8783.12",
                LineTwo = "Tango",
                LineThree = "Released: ?",
                LineFour = "• Provides support for phones without physical camera buttons. \n• Provides other Windows Phone Improvements"
            });
            #endregion

            #region 7.8
            this.Items.Add(new ItemViewModel()
            {
                LineOne = "7.10.8858.136",
                LineTwo = "Windows Phone 7.8",
                LineThree = "Released: February 1, 2013",
                LineFour = "• Better media messaging \n• Ability to send ringtones via MMS\n• Export and manage contacts to SIM card \n• Support for low-cost devices with 256 MB RAM and low clock CPU \n• New wallpapers \n• Letter indexing \n• More reliable notifications \n• Attachment download with Microsoft Exchange 2003 Server \n• Faster numeric PIN response \n• Location awareness icon \n• Minor improvements and changes"
            });
            this.Items.Add(new ItemViewModel()
            {
                LineOne = "7.10.8860.142",
                LineTwo = "Windows Phone 7.8",
                LineThree = "Released: March 14, 2013",
                LineFour = "• Intermediate update \n• Features 'several quality improvements' \n• Enabled Tethering Wi-Fi on the Samsung Omnia GT-I8350"
            });
            this.Items.Add(new ItemViewModel()
            {
                LineOne = "7.10.8862.144",
                LineTwo = "Windows Phone 7.8",
                LineThree = "Released: March 14, 2013",
                LineFour = "• Fix for functionality issues with Live Tiles, such as Live Tiles not updating \n• Provides resizable small, medium and large Live Tiles \n• Expands the number of accent colors to 20 \n• Improved accidental wipe protection on lock screen and Bing image of the day wallpaper \n• Expanded Windows Phone Marketplace and Xbox support to new countires and regions \n• Enhances the Chinese font and improves the appearance of Arabic and other languages \n• Included many other improved to Windows Phone"
            });
            #endregion
            #endregion

            #region Windows Phone 8
            #region Apollo
            this.Items.Add(new ItemViewModel()
            {
                LineOne = "8.0.9903.10",
                LineTwo = "Apollo",
                LineThree = "Released: October 29, 2012",
                LineFour = "• Lots of shit"
            });
            this.Items.Add(new ItemViewModel()
            {
                LineOne = "8.0.10211.204",
                LineTwo = "Portico",
                LineThree = "Released: December 11, 2012",
                LineFour = "Messageing improvements \n• multiple recipents when sending messages \n• Automatically saving unsent drafts \n• Possibility to edit forwarded messages \n• Text replies to incoming calls \nInternet Explorer Improvements \n• Prevent pictures from downloading autoamically \n• Possibilit to delete selected sites from browsing history \nWi-Fi Connectivity \n• Option to keep Wi-Fi alive when screen is off, Wi-Fi- network prioritization"
            });
            #endregion
            #endregion

            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}