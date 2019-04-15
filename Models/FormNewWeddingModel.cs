using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;


namespace WeddingPlaner.Models
{
    public class NewWedding
    {
        [Required(ErrorMessage = "Wedder One's Name is required!")]
        [MinLength(2,ErrorMessage = "Wedder One's Name Must be 2 characters or longer!")]
        [Display(Name = "Wedder One :")]
        public string WedderOne { get; set; }
        [Required(ErrorMessage = "Wedder Two's Name is required!")]
        [MinLength(2, ErrorMessage = "Wedder Two's Name Must be 2 characters or longer!")]
        [Display(Name = "Wedder Two :")]
        public string WedderTwo { get; set; }

        [Required(ErrorMessage = "Wedding Date is required")]
        [Display(Name = "Wedding Date:")]
        public DateTime DateofWeeding { get; set; }
        [Required(ErrorMessage = "Wedding Address is required")]
        [MinLength(4, ErrorMessage = "Address Must be 4 characters or longer!")]
        [Display(Name = "Wedding Address :")]
        public string Address { get; set; }
        public int WeddingId{get;set;}
        public int UserId { get; set; }
        // Navigation property for related User object
        public User Creator { get; set; }
        // Covert this form data to the obj that need to add to dababase

        public Wedding GetNewWedding()
        {
            Wedding newWedding = new Wedding();
            newWedding.WedderOne = WedderOne;
            newWedding.WedderTwo = WedderTwo;
            newWedding.DateofWeeding = DateofWeeding;
            newWedding.Address = Address;
            newWedding.UserId = UserId;
            return newWedding;
        }

        public NewWedding(){}

        public NewWedding( Wedding wedding)
        {
            UserId = wedding.UserId;
            WedderOne = wedding.WedderOne;
            WedderTwo = wedding.WedderTwo;
            DateofWeeding = wedding.DateofWeeding;
            Address = wedding.Address;
            WeddingId = wedding.WeddingId;
        }
    }
}