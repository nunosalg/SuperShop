using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Prism.Models
{
    public class ProductResponse
    {
        private string _imageFullPath;


        private string Url = @"https://kqqj54d2-44315.uks1.devtunnels.ms";

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public object LastPurchase { get; set; }

        public object LastSale { get; set; }

        public bool IsAvailable { get; set; }

        public float Stock { get; set; }

        public UserResponse User { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImageUrl))
                {
                    return $"{Url}/images/noimage.png";
                }
                else
                {
                    return $"{Url}{ImageUrl.Substring(1)}";
                }
            }
            set
            {
                _imageFullPath = value;
            }
        }
        
    }
}
