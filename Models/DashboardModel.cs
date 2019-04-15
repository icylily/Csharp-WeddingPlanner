using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WeddingPlaner.Models
{
    public class DashboardModel
    {
        public int Currentuser;
        public List<Wedding> attendWedd;
        public List<Wedding> allWedd;



    }

}