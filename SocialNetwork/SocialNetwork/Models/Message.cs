using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    public class Message
    {
        public int Id { get; set; }
        
        public string Text { get; set; }

        public int? DialogId { get; set; }
        
        public  string UserName { get; set; }

    }
}