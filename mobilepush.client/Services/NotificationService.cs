using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Firebase.CloudMessaging;
namespace mobilepush.client.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IFirebaseCloudMessaging _firebaseMessaging;
        private string _deviceToken;
        private string _registrationId;

        public NotificationService(IFirebaseCloudMessaging firebaseMessaging)
        {
            _firebaseMessaging = firebaseMessaging;
        }

        public async Task<string> GetDeviceToken()
        {
            if (string.IsNullOrEmpty(_deviceToken))
            {
                _deviceToken = await _firebaseMessaging.GetTokenAsync();
            }
            await Task.Delay(1000);
            return _deviceToken;
        }


        public async Task UnregisterFromNotifications()
        {
            //await _firebaseMessaging.UnsubscribeFromTopicAsync("all");
            await Task.Delay(1000);
        }

        public async Task RegisterForNotifications(string azureNotificationHubConnectionString, string hubName)
        {
            await Task.Delay(1000);
        }
    }
}



