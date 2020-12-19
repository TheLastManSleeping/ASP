using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SocialNetwork.ViewModels
{
    public class RegisterViewModel
    {
        
        [Required]
        [Display(Name = "Псевдоним")]
        public string UserName { get; set; }
        
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDay { get; set; }
        
        [Required]
        [Display(Name = "Пол")]
        public string Gender { get; set; }
        
        [Required]
        [Display(Name = "Страна")]
        public string Country { get; set; }
        
        [Required]
        [Display(Name = "Фото")]
        [AllowedExtensions.AllowedExtensionsAttribute(new [] { ".jpg", ".jpeg", ".png" })]
        public IFormFile Photo { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
 
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}