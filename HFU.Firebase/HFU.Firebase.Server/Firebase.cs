using System.Collections.Generic;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace HFU.Firebase.Server
{
    public class Firebase
    {
        public Firebase()
        {
            // TODO: Provider your own credentials file from the firebase console.
            FirebaseApp.Create(new AppOptions()
            {
                Credential =
                    GoogleCredential.FromFile("/Users/fabrizio/Desktop/HFU/todosample-450e3-16503bd8c8d0.json"),
            });
        }

        public async Task<string> SendMessage(string deviceToken, Dictionary<string, string> data)
        {
            var message = new Message
            {
                Notification = new Notification
                {
                    Title = "Title Notification",
                    Body = "Message Notification",
                },
                Data = data,
                Token = deviceToken,
            };

            return await FirebaseMessaging.DefaultInstance.SendAsync(message);
        }
        
        public async Task<BatchResponse> SendMessage(Dictionary<string, string> data, params string[] deviceTokens)
        {
            var message = new MulticastMessage
            {
                Notification = new Notification
                {
                    Title = "Title Notification",
                    Body = "Message Notification",
                },
                Data = data,
                Tokens = deviceTokens,
            };

            return await FirebaseMessaging.DefaultInstance.SendMulticastAsync(message);
        }
    }
}