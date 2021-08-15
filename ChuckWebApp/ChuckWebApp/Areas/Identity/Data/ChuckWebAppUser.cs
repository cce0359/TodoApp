using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChuckWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace ChuckWebApp.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ChuckWebAppUser class
    public class ChuckWebAppUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }

        public ICollection<Todo> Todos { get; set; }
    }
}
