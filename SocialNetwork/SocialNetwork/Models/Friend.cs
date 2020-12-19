using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Friend
    {
        public int Id {get; set;}
        
        public string IdUser {get; set;}
        
        public string FriendId {get; set;}
        
        
        public string FriendName {get; set;}
        
    }
}