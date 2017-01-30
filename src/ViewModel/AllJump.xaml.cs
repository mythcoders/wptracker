using System;
using System.Collections.ObjectModel;
using Microsoft.Phone.Controls;
using WP7_Tracker.ViewModel.Data;

namespace WP7_Tracker.ViewModel
{
    public partial class AllJump : PhoneApplicationPage
    {
        private ObservableCollection<DevicesViewModel> source = new ObservableCollection<DevicesViewModel>();
        public AllJump()
        {
            InitializeComponent();

        }
    }
}