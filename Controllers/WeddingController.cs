using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlaner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace WeddingPlaner.Controllers
{
    public class WeddingController : Controller
    {
        private WeddingContext dbContext;
        public WeddingController(WeddingContext context)
        {
            dbContext = context;
        }

        [HttpGet("/NewWedding")]
        public IActionResult Index()
        {
            return View("NewWedding");
        }

        [HttpPost("NewWeeding")]
        public IActionResult NewWeeding(NewWedding newweeding)
        {
            // Console.WriteLine("into newWedding controller");
            if (!ModelState.IsValid)
            {
                return View("NewWedding");
            }
            else
            {
                DateTime now = DateTime.Today;
                if (DateTime.Compare( newweeding.DateofWeeding,now) < 0)
                {
                    ModelState.AddModelError("DateofWeeding", "The Wedding Date must be in the future!");
                    return View("NewWedding");
                }
                else
                {
                    newweeding.UserId = Loginuser.GetUserID(HttpContext);
                    Wedding addWeeding = newweeding.GetNewWedding();
                    dbContext.Weddings.Add(addWeeding);
                    dbContext.SaveChanges();
                    return Redirect("ViewWedding/"+addWeeding.WeddingId);
                }
            }
        }

        [HttpGet("ViewWedding/{weddingId}")]
        public IActionResult ViewWedding(int weddingId)
        {
            var viewWedding = dbContext.Weddings
            .Include(wedd => wedd.Creator)
            .Include(wedd => wedd.Attendences)
            .ThenInclude(attendence =>attendence.User)
            .FirstOrDefault(wedd => wedd.WeddingId == weddingId);
            return View(viewWedding);
        }

        [HttpGet("wedding/delete/{weddingId}")]
        public IActionResult DeleteWeeding(int weddingId)
        {
            int currentUser = Loginuser.GetUserID(HttpContext);
            Wedding thisWedding = dbContext.Weddings.FirstOrDefault(Wedding=> Wedding.WeddingId == weddingId);
            Console.WriteLine("current user is :",currentUser);
            Console.WriteLine("wedding.user is :",thisWedding.UserId);
            if (thisWedding.UserId != currentUser)
            {
                ViewBag.message = "Can not delete a weeding  that not created by yourself!";
                return View("Warning");
            }
            dbContext.Weddings.Remove(thisWedding);
            dbContext.SaveChanges();
            return Redirect("/dashboard");
        }

        [HttpGet("wedding/rsvp/{weddingId}/{userId}")]
        public IActionResult RSVP(int weddingId, int userId)
        {
            int currentUser = Loginuser.GetUserID(HttpContext);
            if (userId != currentUser)
            {
                ViewBag.message = "Can not  RSVP for other user!";
                return View("Warning");
            }
            Attendence newAtten = new Attendence();
            newAtten.UserId = userId;
            newAtten.WeedingId = weddingId;
            dbContext.Attendences.Add(newAtten);
            dbContext.SaveChanges();
            
            return Redirect("/dashboard");
        }


        [HttpGet("wedding/unrsvp/{weddingId}/{userId}")]
        public IActionResult UnRSVP(int weddingId, int userId)
        {
            int currentUser = Loginuser.GetUserID(HttpContext);
            if (userId != currentUser)
            {
                ViewBag.message = "Can not  Un-RSVP for other user!";
                return View("Warning");
            }
            Attendence delAtten = dbContext.Attendences
            .Where(att =>((att.WeedingId == weddingId )&&(att.UserId == userId)))
            .FirstOrDefault();
            dbContext.Attendences.Remove(delAtten);
            dbContext.SaveChanges();

            return Redirect("/dashboard");
        }

        [HttpGet("/Wedding/edit/{weddingId}")]
        public IActionResult ShowEditWedding(int weddingId)
        {
            int currentUser = Loginuser.GetUserID(HttpContext);
            Wedding thisWedding = dbContext.Weddings.FirstOrDefault(wed => wed.WeddingId == weddingId);
            if(thisWedding.UserId != currentUser)
            {
                ViewBag.message = "You can not edit this Wedding!!";
                return View("Warning");
            }
            else
            {
                NewWedding newWedding = new NewWedding(thisWedding);
                return View(newWedding);
            }
        }

        [HttpPost("EditWedding")]
        public IActionResult EditWedding(NewWedding newWedding)
        {
            if(newWedding.UserId != Loginuser.GetUserID(HttpContext))
            {
                ViewBag.message = "You can not edit thie Wedding!";
                return View("Warning");
            }
            
            if (!ModelState.IsValid)
            {
                return View("ShowEditWedding",newWedding);
            }
            else
            {
                DateTime now = DateTime.Today;
                if (DateTime.Compare(newWedding.DateofWeeding, now) < 0)
                {
                    ModelState.AddModelError("DateofWeeding", "The Wedding Date must be in the future!");
                    return View("ShowEditWedding", newWedding);
                }
                else
                {
                    // newWedding.UserId = Loginuser.GetUserID(HttpContext);
                    Wedding editWedding = dbContext.Weddings.FirstOrDefault(wed => wed.WeddingId == newWedding.WeddingId);
                    editWedding.WedderOne = newWedding.WedderOne;
                    editWedding.WedderTwo = newWedding.WedderTwo;
                    editWedding.DateofWeeding = newWedding.DateofWeeding;
                    editWedding.Address = newWedding.Address;
                    dbContext.SaveChanges();
                    return Redirect("ViewWedding/" + editWedding.WeddingId);
                }
            }
        }

    }
}

