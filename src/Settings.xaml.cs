using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Phone.Controls;

namespace WP7_Tracker
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();

            this.radListPicker.ItemsSource = views;
            this.radListPicker.SelectedItem = "when app loads";
        }
             

        List<string> views = new List<string>() { "when app loads", "all", "manufacturer", "carrier", "region", "OS Versions" }; 

    }
}