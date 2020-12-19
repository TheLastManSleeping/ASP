using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SocialNetwork.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string BirthDay {get; set;}
        
        public string Photo {get; set;}
        
    }
}