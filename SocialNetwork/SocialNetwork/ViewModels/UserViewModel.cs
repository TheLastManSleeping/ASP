using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using SocialNetwork.Models;

namespace SocialNetwork.ViewModels
{
    public class UserInfoViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDay { get; set; }
        public string Gender { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }
        
        public string Photo { get; set; }

        public UserInfoViewModel()
        {
        }
        public UserInfoViewModel(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Name = user.Name;
            Surname = user.Surname;
            BirthDay = user.BirthDay;
            Email = user.Email;
            Country = user.Country;
            Gender = user.Gender;
            Photo = user.Photo;
        }

    }
}