using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace signalAPP_Backend 
{
    public class ChatHub: Hub
    {

        public async Task GetId()
        {
            await Clients.Caller.SendAsync("getId", Context.ConnectionId);
        }

        public async Task SendMessage(UserModel user, string message)
        {
            await Clients.All.SendAsync("getMessage", user.id, user.name, message);
        }

        public async Task Typing(UserModel user){
            await Clients.Others.SendAsync("typing", user.id, user.name);
        }

        public async Task StoppedType(UserModel user){
            await Clients.Others.SendAsync("stoppedTyping", user.id, user.name);
        }
    }
}