using System.Collections.Generic;

namespace SocialNetwork.Models
{
    public class Dialog
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public string FriendId { get; set; }

        
        public ICollection<Message> Messages { get; set; }
    }
}