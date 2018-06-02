using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EhrWeb.Models
{
    public class AddressModel
    {
        [Display(Name = "AddressId")]
        [ScaffoldColumn(false)]
        public int AddressId { get; set; }

        [Display(Name = "Address L1")]
        [Required(ErrorMessage = "Address Line one is required")]
        [StringLength(100)]
        public string AddressL1 { get; set; }

        [Display(Name = "Address L2")]
        [Required(ErrorMessage = "Address Line one is required")]
        [StringLength(100)]
        public string AddressL2 { get; set; }

        [Display(Name = "Address L3")]
        [StringLength(100)]
        public string AddressL3 { get; set; }

        [Display(Name = "Post/Zip Code")]
        [StringLength(10)]
        public string PostCode { get; set; }

        [Display(Name = "City/Town")]
        [Required(ErrorMessage = "City/Town is required")]
        [StringLength(100)]
        public string City { get; set; }

        [Display(Name = "Country")]
        [StringLength(100)]
        public string Country { get; set; }
    }
}