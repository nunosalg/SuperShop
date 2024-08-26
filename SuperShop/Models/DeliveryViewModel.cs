using System;
using System.ComponentModel.DataAnnotations;

namespace SuperShop.Models
{
    public class DeliveryViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Delivery date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime DeliveryDate { get; set; }
    }
}
