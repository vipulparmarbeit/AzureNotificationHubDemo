using mobilepush.client.Services;
using Plugin.Firebase.CloudMessaging;

namespace mobilepush.client
{
    public partial class MainPage : ContentPage
    {
        private const string AzureNotificationHubConnectionString = "YOUR_AZURE_NOTIFICATION_HUB_CONNECTION_STRING";
        private const string HubName = "YOUR_HUB_NAME";
        private readonly INotificationService _notificationService;
        public MainPage(INotificationService notificationService)
        {
            InitializeComponent();
            _notificationService = notificationService;
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            try
            {
                var token = await _notificationService.GetDeviceToken();
                StatusLabel.Text = $"Device token: {token}";

                await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
                var token1 = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
                StatusLabel.Text = $"Device token: {token1}";

               // await _notificationService.RegisterForNotifications(AzureNotificationHubConnectionString, HubName);
                StatusLabel.Text = "Registered for notifications!";

              
            }
            catch (Exception ex)
            {
                StatusLabel.Text = $"Registration failed: {ex.Message}";
            }
        }

        private async void OnUnregisterClicked(object sender, EventArgs e)
        {
            try
            {
                await _notificationService.UnregisterFromNotifications();
                StatusLabel.Text = "Unregistered from notifications";
            }
            catch (Exception ex)
            {
                StatusLabel.Text = $"Unregistration failed: {ex.Message}";
            }
        }
    }
}
