using Microsoft.AspNetCore.SignalR;

namespace Kursova.Structure
{
    public class UserNotify : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Identity.Name;
        }
    }
}
