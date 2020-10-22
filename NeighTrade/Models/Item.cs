using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Web;

namespace NeighTrade.Models
{
    public enum Category
    {
        [Display(Name = "Baby")]
        Baby,
        [Display(Name = "Beauty")]
        Beauty,
        [Display(Name = "Books")]
        Books,
        [Display(Name="Camera & Photo")]
        CameraPhoto,
        [Display(Name = "Clothing & Accessories")]
        ClothingAccessories,
        [Display(Name = "Consumer Electronics")]
        ConsumerElectronics,
        [Display(Name = "Grocery & Gourmet Foods")]
        GroceryGourmetFoods,
        [Display(Name = "Health & Personal Care")]
        HealthPersonalCare,
        [Display(Name = "Home & Garden")]
        HomeGarden,
        [Display(Name = "Industrial & Scientific")]
        IndustrialScientific,
        [Display(Name = "Luggage & Travel Accessories")]
        LuggageTravelAccessories,
        [Display(Name = "Musical Instruments")]
        MusicalInstruments,
        [Display(Name = "Office Products")]
        OfficeProducts,
        [Display(Name = "Outdoors")]
        Outdoors,
        [Display(Name = "Personal Computers")]
        PersonalComputers,
        [Display(Name = "Pet Supplies")]
        PetSupplies,
        [Display(Name = "Shoes, Handbags, & Sunglasses")]
        ShoesHandbagsSunglasses,
        [Display(Name = "Software")]
        Software,
        [Display(Name = "Sports")]
        Sports,
        [Display(Name = "Tools & Home Improvement")]
        ToolsHomeImprovement,
        [Display(Name = "Toys")]
        Toys,
        [Display(Name = "Video Games")]
        VideoGames
    }

    public class Item
    {
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public decimal ListingPrice { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public Category Category { get; set; }
        public int LikeCount { get; set; }
        public string ImgPath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImgFile { get; set; }

        [NotMapped]
        public string CategoryName {
            get {
                System.Console.WriteLine(Category.ToString());
                return Category.GetType().GetMember(Category.ToString())
                   .First()
                   .GetCustomAttribute<DisplayAttribute>()
                   .Name;
            }
            set {
                CategoryName = value;
            }
        }

        public virtual User User { get; set; }
    }
}