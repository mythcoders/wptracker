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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Primitives;

namespace WP7_Tracker
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            RadPhoneApplicationFrame frame = App.Current.RootVisual as RadPhoneApplicationFrame;

            if ((Application.Current as App).IsTrial)
            {
                ApplicationBar = new ApplicationBar();
                ApplicationBar.IsMenuEnabled = true;
                ApplicationBar.IsVisible = true;
                ApplicationBar.Opacity = 1.0;
                ApplicationBar.Mode = ApplicationBarMode.Minimized;

                ApplicationBarMenuItem fullVersion = new ApplicationBarMenuItem();
                fullVersion.IsEnabled = true;
                fullVersion.Text = "full version";
                fullVersion.Click += new EventHandler(ApplicationBarMenuItem_Click_1);

                ApplicationBarMenuItem about = new ApplicationBarMenuItem();
                about.IsEnabled = true;
                about.Text = "about";
                about.Click += new EventHandler(ApplicationBarMenuItem_Click_2);

                ApplicationBarMenuItem bugtracker = new ApplicationBarMenuItem();
                bugtracker.IsEnabled = true;
                bugtracker.Text = "bugzilla";
                bugtracker.Click += new EventHandler(ApplicationBarMenuItem_Click_4);

                ApplicationBar.MenuItems.Add(fullVersion);
                ApplicationBar.MenuItems.Add(bugtracker);
                ApplicationBar.MenuItems.Add(about);

                RadRateApplicationReminder rateReminder = new RadRateApplicationReminder();
                rateReminder.RecurrencePerUsageCount = 3;
                rateReminder.AllowUsersToSkipFurtherReminders = false;
                rateReminder.MessageBoxInfo.Title = "Do you want to review WP7 Tracker in the marketplace?";
                rateReminder.MessageBoxInfo.Content = "We value customer feedback to help us develop the application. \n\nWe would appreciate it if you took a few minutes to let other people know what's good and bad about the application.";
                rateReminder.Notify();
            }
            else
            {
                ApplicationBar = new ApplicationBar();
                ApplicationBar.IsMenuEnabled = true;
                ApplicationBar.IsVisible = true;
                ApplicationBar.Opacity = 1.0;
                ApplicationBar.Mode = ApplicationBarMode.Minimized;

                ApplicationBarMenuItem settings = new ApplicationBarMenuItem();
                settings.IsEnabled = true;
                settings.Text = "settings";
                settings.Click += new EventHandler(ApplicationBarMenuItem_Click_3);

                ApplicationBarMenuItem about = new ApplicationBarMenuItem();
                about.IsEnabled = true;
                about.Text = "about";
                about.Click += new EventHandler(ApplicationBarMenuItem_Click_2);

                ApplicationBarMenuItem bugtracker = new ApplicationBarMenuItem();
                bugtracker.IsEnabled = true;
                bugtracker.Text = "bugzilla";
                bugtracker.Click += new EventHandler(ApplicationBarMenuItem_Click_4);

                //ApplicationBar.MenuItems.Add(settings);
                ApplicationBar.MenuItems.Add(bugtracker);
                ApplicationBar.MenuItems.Add(about);

                RadRateApplicationReminder rateReminder = new RadRateApplicationReminder();
                rateReminder.RecurrencePerTimePeriod = TimeSpan.FromDays(10);
                //rateReminder.RecurrencePerUsageCount = 1;
                rateReminder.AllowUsersToSkipFurtherReminders = true;
                rateReminder.MessageBoxInfo.Title = "Do you want to review WP7 Tracker in the marketplace?";
                rateReminder.MessageBoxInfo.Content =  "We value customer feedback to help us develop the application. \n\nWe would appreciate it if you took a few minutes to let other people know what's good and bad about the application.";
                rateReminder.MessageBoxInfo.SkipFurtherRemindersMessage = "Don't remind me again";
                rateReminder.Notify();
            }
        }

        //AppBarMenuItem :: Full Version
        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/FullVersion.xaml", UriKind.Relative));
        }

        //AppBarMenuItem :: About
        private void ApplicationBarMenuItem_Click_2(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        //AppBarMenuItem :: Settings
        private void ApplicationBarMenuItem_Click_3(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }

        //AppBarMenuItem :: Bugtracker
        private void ApplicationBarMenuItem_Click_4(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/BugTracker.xaml", UriKind.Relative));
        }
        
        private void hubTile1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if ((Application.Current as App).IsTrial)
            {
                NavigationService.Navigate(new Uri("/ViewModel/AllTrial.xaml", UriKind.Relative)); 
            }
            else
            {
                NavigationService.Navigate(new Uri("/ViewModel/All.xaml", UriKind.Relative)); 
            }
        }

        private void hubTile2_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Manufacturer.xaml", UriKind.Relative));
        }

        private void hubTile3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if ((Application.Current as App).IsTrial)
            {
                RadMessageBox.Show(new AboutMessage[] 
            { 
                new AboutMessage() { Title = "The Obvious", Message = "Convert to the full version for the rock bottom price of $0.99!" },
                new AboutMessage() { Title = "Nothing", Message = "Continuing using the trial version until you come to your senses ;)" }
            },
                "Hold the phone!",
                "This operation can only be done in the full version, which you don't have. What shall be do about this?",
                closedHandler: (args) =>
                {
                    if (args.ClickedButton == null)
                    {
                        return;
                    }
                    AboutMessage option = (AboutMessage)args.ClickedButton.Content;
                    if (option.Title == "The Obvious")
                    {
                        MarketplaceDetailTask _marketPlaceDetailTask = new MarketplaceDetailTask();
                        _marketPlaceDetailTask.Show();
                    }
                    if (option.Title == "Nothing")
                    {
                        // Just like the title says!
                    }
                });
            }
            else
            {
                NavigationService.Navigate(new Uri("/ViewModel/Carriers.xaml", UriKind.Relative));
            }         
        }

        private void hubTile5_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {                
            NavigationService.Navigate(new Uri("/ViewModel/OS/MainPage.xaml", UriKind.Relative));
        }

        //All Devices HubTile
        private void RadContextMenuItem_Tapped(object sender, ContextMenuItemSelectedEventArgs e)
        {            ShellTile TileToFind = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("/ViewModel/All.xaml"));

            if ((Application.Current as App).IsTrial)
            {
                RadMessageBox.Show(new AboutMessage[] 
            { 
                new AboutMessage() { Title = "The Obvious", Message = "Convert to the full version for the rock bottom price of $0.99!" },
                new AboutMessage() { Title = "Nothing", Message = "Continuing using the trial version until you come to your senses ;)" }
            },
                "Hold the phone!",
                "This operation can only be done in the full version, which you don't have. What shall be do about this?",
                closedHandler: (args) =>
            {
                if (args.ClickedButton == null)
                    {
                        return;
                    }
                 AboutMessage option = (AboutMessage)args.ClickedButton.Content;
                 if (option.Title == "The Obvious")
                    {
                        MarketplaceDetailTask _marketPlaceDetailTask = new MarketplaceDetailTask();
                        _marketPlaceDetailTask.Show();
                    }
                    if (option.Title == "Nothing")
                    {
                       // Just like the title says!
                    }
                });
            }
            else
            {
                if (TileToFind == null)
                {
                    StandardTileData NewTileData = new StandardTileData
                    {
                        BackgroundImage = new Uri("Images/pinable/tile-all.png", UriKind.Relative),
                        Title = " ",
                        Count = 0,
                        BackTitle = "WP7 Tracker",
                        BackContent = "view all wp7 devices",
                    };

                    ShellTile.Create(new Uri("/ViewModel/All.xaml", UriKind.Relative), NewTileData);
                }
            }
        }

        //Manufacturer HubTile
        private void RadContextMenuItem_Tapped_1(object sender, ContextMenuItemSelectedEventArgs e)
        {
            ShellTile TileToFind = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("/ViewModel/Manufacturer.xaml"));
            if ((Application.Current as App).IsTrial)
            {
                RadMessageBox.Show(new AboutMessage[] 
            { 
                new AboutMessage() { Title = "The Obvious", Message = "Convert to the full version for the rock bottom price of $0.99!" },
                new AboutMessage() { Title = "Nothing", Message = "Continuing using the trial version until you come to your senses ;)" }
            },
                "Hold the phone!",
                "This operation can only be done in the full version, which you don't have. What shall be do about this?",
                closedHandler: (args) =>
            {
                if (args.ClickedButton == null)
                {
                    return;
                }
                AboutMessage option = (AboutMessage)args.ClickedButton.Content;
                if (option.Title == "The Obvious")
                {
                    MarketplaceDetailTask _marketPlaceDetailTask = new MarketplaceDetailTask();
                    _marketPlaceDetailTask.Show();
                }

                if (option.Title == "Nothing")
                {
                    // Just like the title says!
                }
            });
            }
            else
            {
                if (TileToFind == null)
                {
                    StandardTileData NewTileData = new StandardTileData
                    {
                        BackgroundImage = new Uri("Images/pinable/tile-manufacturer.png", UriKind.Relative),
                        Title = " ",
                        Count = 0,
                        BackTitle = "WP7 Tracker",
                        BackContent = "view by manufacturer",
                    };

                    ShellTile.Create(new Uri("/ViewModel/Manufacturer.xaml", UriKind.Relative), NewTileData);
                }
            }
        }

        //Versions HubTile
        private void RadContextMenuItem_Tapped_2(object sender, ContextMenuItemSelectedEventArgs e)
        {
            ShellTile TileToFind = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("/ViewModel/OS/MainPage.xaml"));

            if ((Application.Current as App).IsTrial)
            {
                RadMessageBox.Show(new AboutMessage[] 
            { 
                new AboutMessage() { Title = "The Obvious", Message = "Convert to the full version for the rock bottom price of $0.99!" },
                new AboutMessage() { Title = "Nothing", Message = "Continuing using the trial version until you come to your senses ;)" }
            },
                "Hold the phone!",
                "This operation can only be done in the full version, which you don't have. What shall be do about this?",
                closedHandler: (args) =>
            {
                if (args.ClickedButton == null)
                {
                    return;
                }
                AboutMessage option = (AboutMessage)args.ClickedButton.Content;
                if (option.Title == "The Obvious")
                {
                    MarketplaceDetailTask _marketPlaceDetailTask = new MarketplaceDetailTask();

                    _marketPlaceDetailTask.Show();
                }

                if (option.Title == "Nothing")
                {
                    // Just like the title says!
                }
            });
            }
            else
            {
                if (TileToFind == null)
                {
                    StandardTileData NewTileData = new StandardTileData
                    {
                        BackgroundImage = new Uri("Images/pinable/tile-versions.png", UriKind.Relative),
                        Title = " ",
                        Count = 0,
                        BackTitle = "WP7 Tracker",
                        BackContent = "view released os verions",
                    };

                    ShellTile.Create(new Uri("/ViewModel/OS/MainPage.xaml", UriKind.Relative), NewTileData);
                }
            }
        }

        //Carrier HubTile
        private void RadContextMenuItem_Tapped_3(object sender, ContextMenuItemSelectedEventArgs e)
        {
            ShellTile TileToFind = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("/ViewModel/Carriers.xaml"));

            if ((Application.Current as App).IsTrial)
            {
                RadMessageBox.Show(new AboutMessage[] 
            { 
                new AboutMessage() { Title = "The Obvious", Message = "Convert to the full version for the rock bottom price of $0.99!" },
                new AboutMessage() { Title = "Nothing", Message = "Continuing using the trial version until you come to your senses ;)" }
            },
                "Hold the phone!",
                "This operation can only be done in the full version, which you don't have. What shall be do about this?",
                closedHandler: (args) =>
            {
                if (args.ClickedButton == null)
                {
                    return;
                }
                AboutMessage option = (AboutMessage)args.ClickedButton.Content;
                if (option.Title == "The Obvious")
                {
                    MarketplaceDetailTask _marketPlaceDetailTask = new MarketplaceDetailTask();

                    _marketPlaceDetailTask.Show();
                }

                if (option.Title == "Nothing")
                {
                    // Just like the title says!
                }
            });
            }
            else
            {
                if (TileToFind == null)
                {
                    StandardTileData NewTileData = new StandardTileData
                    {
                        BackgroundImage = new Uri("Images/pinable/tile-carrier.png", UriKind.Relative),
                        Title = " ",
                        Count = 0,
                        BackTitle = "WP7 Tracker",
                        BackContent = "view devices by carrier",
                    };

                    ShellTile.Create(new Uri("/ViewModel/Carriers.xaml", UriKind.Relative), NewTileData);
                }
            }
        }
    }
}
