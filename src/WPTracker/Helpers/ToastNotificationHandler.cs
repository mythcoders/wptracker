using System;
using Microsoft.Phone.Notification;
using Microsoft.WindowsAzure.Messaging;

namespace WPTracker.Helpers
{
    class ToastNotificationHandler
    {
        public void Toaster(bool value)
        {
            var channel = HttpNotificationChannel.Find("MyPushChannel");
                        
            if (value == true)
            {
                if (channel == null)
                {
                    channel = new HttpNotificationChannel("MyPushChannel");
                    channel.Open();
                    channel.BindToShellToast();
                }

                channel.ChannelUriUpdated += new EventHandler<NotificationChannelUriEventArgs>(async (o, args) =>
                {
                    var hub = new NotificationHub("wptracker", "Endpoint=sb://wptracker-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=CdXM6iIWh9epI9g/LPHSh4AjfICvMOxiLZ08Rxrh/os=");
                    await hub.RegisterNativeAsync(args.ChannelUri.ToString());
                });
            }
            else
            {
                channel.Close();
            }
        }
    }
}
