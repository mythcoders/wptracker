using System;
using System.Windows;
using System.Windows.Controls;

namespace WPTracker.Controls
{
    public partial class SettingControl : UserControl
    {
        public SettingControl()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
                                          "Title",
                                          typeof(string),
                                          typeof(SettingControl),
                                          new PropertyMetadata(""));

        public static readonly DependencyProperty SubtitleProperty = DependencyProperty.Register(
                                          "Subtitle",
                                          typeof(string),
                                          typeof(SettingControl),
                                          new PropertyMetadata(""));
        
        public string Title
        {
            get
            {
                return (String)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }

        public string Subtitle
        {
            get
            {
                return (String)GetValue(SubtitleProperty);
            }
            set
            {
                SetValue(SubtitleProperty, value);
            }
        }
    }
}
