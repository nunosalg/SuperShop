using System;
using System.ComponentModel.DataAnnotations;

namespace SuperShop.Data.Entities
{
    public class Product : IEntity
    {
        //[Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(50, ErrorMessage ="The field {0} can't contain more than {1} characters length.")]
        public string Name { get; set; }


        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }


        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        //public Guid ImageId { get; set; }


        [Display(Name = "Last Purchase")]
        public DateTime? LastPurchase {  get; set; }


        [Display(Name = "Last Sale")]
        public DateTime? LastSale { get; set; }


        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock {  get; set; }


        public User User { get; set; }


        //public string ImageFullPath => ImageId == Guid.Empty 
        //    ? $"https://supershopns.azurewebsites.net/images/noimage.png" 
        //    : $"https://supershopns.blob.core.windows.net/products/{ImageId}";

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImageUrl))
                {
                    return "~/images/noimage.png";
                }

                return $"https://localhost:44315{ImageUrl.Substring(1)}";
            }
        }
    }
}
