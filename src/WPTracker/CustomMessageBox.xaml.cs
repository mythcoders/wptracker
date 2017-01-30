using System.Windows.Controls;

namespace WPTracker
{
    public partial class CustomMessageBox : UserControl
    {
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        public string Title
        {
            get
            {
                return this.title.Text;
            }

            set
            {
                this.title.Text = value;
            }
        }

        public string Message
        {
            get
            {
                return this.message.Text;
            }

            set
            {
                this.message.Text = value;
            }
        }
    }
}