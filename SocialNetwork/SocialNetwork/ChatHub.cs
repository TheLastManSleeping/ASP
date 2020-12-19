using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SocialNetwork.Models;
using SocialNetwork.Repositories;

namespace SocialNetwork
{
    public class ChatHub : Hub
    {
        IRepository<Message> _messageRepository;

        public ChatHub(IRepository<Message> messageRepository)
        {
            _messageRepository = messageRepository;
        }
        
        public async Task Send(string text, string userName)
        {
            await Clients.All.SendAsync("Send", text, userName);
        }
        
        public void Save(string text, string userName, int id)
        {
            var message = new Message();
            message.Text = ' ' + text;
            message.DialogId = id;
            message.UserName = userName + ':';
            _messageRepository.SaveEntity(message);
        }
        
    }
}