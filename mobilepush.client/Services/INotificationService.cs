using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobilepush.client.Services
{
    public interface INotificationService
    {
        Task<string> GetDeviceToken();
        Task RegisterForNotifications(string azureNotificationHubConnectionString, string hubName);
        Task UnregisterFromNotifications();
    }
}


