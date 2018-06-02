using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Utility;

namespace EhrWeb.Models
{
    public class UserModel
    {
        [ScaffoldColumn(false)]
        public int UserID { get; set; }

        [Display(Name = "Username")]
        [StringLength(20)]
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public CommonUnit.UserType UserType { get; set; }

        [Display(Name = "Type")]
        [StringLength(20)]
        public string UserTypeDsc { get; set; }
    }
}