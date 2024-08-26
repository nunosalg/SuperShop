using System.ComponentModel.DataAnnotations;

namespace SuperShop.Models
{
    public class CityViewModel
    {
        public int CountryId { get; set; }


        public int CityId { get; set; }


        [Required]
        [Display(Name = "City")]
        [MaxLength(50, ErrorMessage = "The field {0} can only contain {1} characters lenght.")]
        public string Name { get; set; }
    }
}
