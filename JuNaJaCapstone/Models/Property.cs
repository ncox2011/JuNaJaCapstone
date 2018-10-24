using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace JuNaJaCapstone.Models
{
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Number of Bedrooms")]
        public int Bedrooms { get; set; }

        [Required]
        [Display(Name = "Number of Bathrooms")]
        public int Bathrooms { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        //[/*NonLuxuryProduct*/]
        public double Rent { get; set; }


        [DisplayFormat(DataFormatString = "{0:C}")]
        //[/*NonLuxuryProduct*/]
        public double Mortgage { get; set; }

        public bool Rented { get; set; }

        [Required]
        public virtual IdentityUser User { get; set; }

        public string UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateSold { get; set; }

        public virtual ICollection<PropertyNote> Notes {get; set;}

        public virtual ICollection<PropertyImage> Image { get; set; }

    }
}
