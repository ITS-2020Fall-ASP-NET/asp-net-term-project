using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NeighTrade.Models
{
    public enum Category
    {
        Baby,
        Beauty,
        [Display(Name="Camera & Photo")]
        CameraPhoto,
        [Display(Name = "Clothing & Accessories")]
        ClothingAccessories,
        [Display(Name = "Consumer Electronics")]
        ConsumerElectronics
    }

    public class Item
    {
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public decimal ListingPrice { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public int LikeCount { get; set; }
        public string ImgPath { get; set; }
        
        [NotMapped]
        public HttpPostedFileBase ImgFile { get; set; }

        public virtual User User { get; set; }
    }
}