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
        [Required]
        public bool IsNormal { get; set; }
        [Required]
        public int NoOfPaper { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int duration { get; set; }
        public int ServiceId { get; set; }
        public DateTime startDate { get; set; }


    }
}