using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpodIgly.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "musisz wprowadzić email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "musisz wprowadzić hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }

    }
}