using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpodIgly.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzic Imię")]
        [StringLength(150)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "musisz wprowadzib nazwisko")]
        [StringLength(150)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Nie wprowaszomp adresu")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Wprowadz kod pocztowy i miasto")]
        [StringLength(50)]
        public string CodeAndCity { get; set; }

        [Required(ErrorMessage = "mosisz wprowadzoc numer telefonu")]
        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Blędny format nuneru ")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Wprowadz adres email")]
        [EmailAddress(ErrorMessage = "błędny format")]
        public string Email { get; set; }

        public string Comment { get; set; }

        public DateTime DateCreated { get; set; }

        public OrderState OrderState { get; set; }

        public decimal TotalPrice { get; set; }


        public List<OrderItem>OrderItems { get; set; }


    }

    public enum OrderState
    {
        [Display(Name = "nowe")]
        New,
        [Display(Name = "Wysłane")]
        Shipped
    }
}