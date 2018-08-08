using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace signalAPP_Backend 
{
    public class ChatHub: Hub
    {
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("SendMessage", Context.User.Identity.Name, message);
        }
    }
}