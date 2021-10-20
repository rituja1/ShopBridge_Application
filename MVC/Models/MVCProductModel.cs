using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class MVCProductModel
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Description"), MaxLength(50)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter Price")]
        public Nullable<int> Price { get; set; }
    }
}