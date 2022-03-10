using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CliectProject.Models.ViewModels
{
    public class AddOrder
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, Choose if your order is urgent or not")]

        public bool IsNormal { get; set; }
        [Required(ErrorMessage = "Please, Specify the number of papers")]

        public int NoOfPaper { get; set; }
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please, Enter your order details")]

        public string Description { get; set; }
        public int duration { get; set; }
        public int ServiceId { get; set; }
        public string ClientId { get; set; }
        public DateTime startDate { get; set; }


    }
}