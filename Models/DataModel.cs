using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WeddingPlaner.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public List<Wedding> CreatedWeddings { get; set; }
        public List<Attendence> Attendences{get;set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }
        [Required]
        public string WedderOne { get; set; }
        [Required]
        public string WedderTwo { get; set; }
        [Required]
        public DateTime DateofWeeding { get; set; }
        [Required]
        public string Address{get;set;}
        public int UserId { get; set; }
        // Navigation property for related User object
        public User Creator { get; set; }
        public List<Attendence> Attendences { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }

    public class Attendence
    {
        [Key]
        public int AttendenceId { get; set; }
        [Required]
        public int UserId{get;set;}
        [Required]
        public int WeedingId{get;set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public User User{get;set;}
        public Wedding Weeding{get;set;}
    }

}