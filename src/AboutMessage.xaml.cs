using System.Windows.Controls;

namespace WP7_Tracker
{
    public partial class AboutMessage : UserControl
    {
        public AboutMessage()
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