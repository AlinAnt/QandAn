using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace QandAn
{
    public class AnswerHub : Hub
    {
        public async Task Send(string groupname, string answer, string username)
        {
            await Clients.Group(groupname).SendAsync ("Receive", answer, username, DateTime.Now.ToString());
        }
        
        public void JoinGroup(string groupName)
        {
            this.Groups.AddToGroupAsync(this.Context.ConnectionId, groupName);
        }
    } 
}