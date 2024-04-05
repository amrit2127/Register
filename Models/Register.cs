using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contry_State_City.Models
{
    public class Register
    {
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        public GenderType Gender { get; set; }
        [Required]
        public bool IsSubscribe { get; set; }
        [Display(Name ="City")]
        public int CityId { get; set; }
        public City City { get; set; }
        [NotMapped]
        [Display(Name="State")]
        public int StateId { get; set; }
        [NotMapped]
        [Display(Name ="Country")]
        public int CountryId { get; set; }
        
       
    }

}