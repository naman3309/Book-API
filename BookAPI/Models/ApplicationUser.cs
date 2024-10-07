﻿using Microsoft.AspNetCore.Identity;

namespace BookAPI.Models
{
    public class ApplicationUser:IdentityUser
    {
        public String FirstName {  get; set; }
        public string LastName { get; set; }
    }
}
