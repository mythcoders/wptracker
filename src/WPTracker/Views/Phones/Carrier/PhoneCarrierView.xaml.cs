using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WPTracker.ViewModels.Phones
{
    public partial class PhoneCarrierView : PhoneApplicationPage
    {
        public PhoneCarrierView()
        {
            InitializeComponent();
        }

        List<string> carrierNames = new List<string>() {
            "All",
            "AT&T",
            "Verizon",
            "T-Mobile",
            "Sprint",
            "Others",
            "Yep",
        };
    }
}