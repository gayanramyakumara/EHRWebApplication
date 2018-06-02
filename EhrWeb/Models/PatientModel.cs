using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntity;
using System.ComponentModel.DataAnnotations;

namespace EhrWeb.Models
{
    public class PatientModel
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Display(Name = "Patient ID")]
        [ScaffoldColumn(false)]
        public int PatientId { get; set; }

        [Display(Name = "PIN")]
        [StringLength(10)]
        public string PIN { get; set; }

        [Display(Name = "Full Name")]
        [StringLength(100)]
        [Required(ErrorMessage = "Patient Name is required")]
        public string PatientName { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        [Display(Name = "NIC/Passport")]
        [StringLength(10)]
        public string NIC { get; set; }

        [Display(Name = "Gender")]
        [StringLength(10)]
        public string Gender { get; set; }

        public AddressModel Address { get; set; }

        [Display(Name = "Joined Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime JoinedDate { get; set; }

        [Display(Name = "Updated Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime UpdatedDate { get; set; }

        [ScaffoldColumn(false)]
        public int IsActive { get; set; }                
    }
}