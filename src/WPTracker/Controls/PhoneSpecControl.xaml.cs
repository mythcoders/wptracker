using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPTracker.Controls
{
    public partial class PhoneSpecControl : UserControl
    {
        public PhoneSpecControl()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
                                          "Icon",
                                          typeof(ImageSource),
                                          typeof(PhoneSpecControl),
                                          new PropertyMetadata(null));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
                                          "Value",
                                          typeof(string),
                                          typeof(PhoneSpecControl),
                                          new PropertyMetadata(""));

        public static readonly DependencyProperty FieldProperty = DependencyProperty.Register(
                                          "Field",
                                          typeof(string),
                                          typeof(PhoneSpecControl),
                                          new PropertyMetadata(""));

        public ImageSource Icon
        {
            get
            {
                return (ImageSource)GetValue(IconProperty);
            }
            set
            {
                SetValue(IconProperty, value);
            }
        }

        public string Value
        {
            get
            {
                return (String)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        public string Field
        {
            get
            {
                return (String)GetValue(FieldProperty);
            }
            set
            {
                SetValue(FieldProperty, value);
            }
        }
    }
}
