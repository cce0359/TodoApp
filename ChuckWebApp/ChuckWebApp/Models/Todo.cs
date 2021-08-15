using ChuckWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChuckWebApp.Models
{
    public class Todo
    {
        public int TodoID { get; set; }

        [Required]
        [Display(Name = "To do")]
        public string Activity { get; set; }

        [Display(Name = "Completed")]
        public bool IsDone { get; set; } = false;

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Finsh By")]
        public DateTime DueDate { get; set; }

        public string ChuckWebAppUserId { get; set; }

        //public ChuckWebAppUser User { get; set; }

    }
}
