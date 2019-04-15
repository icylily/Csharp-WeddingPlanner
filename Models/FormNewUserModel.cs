using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace WeddingPlaner.Models
{
    public class NewUser
    {
        [Required]
        [MinLength(2)]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password Must be 8 characters or longer!")]
        [Display(Name = "Password:")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [CompareAttribute("Password", ErrorMessage = "Passwords Must Match!")]
        [Display(Name = "Confirm your password:")]
        public string PasswordConfirm { get; set; }


        //Coveret this form data to the obj that need to add to dababase

        public User GetNewuser()
        {
            User newUSer = new User();
            newUSer.FirstName =  FirstName;
            newUSer.LastName = LastName;
            newUSer.Email = Email;
            newUSer.Password = Password;
            return newUSer;
        }
    }
}