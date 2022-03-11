using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //Added for access for Data Annotations (Verify valid email etc)

namespace PersonalSiteMVC.UI.MVC.Models
{
    public class ContactViewModel
    {

        //PROPERTIES
        [Required(ErrorMessage = "*Name is required")] 
        public string Name { get; set; }

        [Required(ErrorMessage = "*Valid Email is required")] 
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public string Subject { get; set; }

        [Required(ErrorMessage = "*Message is required")]
        [UIHint("MultilineText")]
        public string Message { get; set; }

    }
}