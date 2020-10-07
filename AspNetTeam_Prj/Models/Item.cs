using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetTeam_Prj.Models
{
    public class Item
    {
        public int Item_id { get; set; }
        public int User_id { get; set; }
        public string Name { get; set; }
        public decimal Listing_price { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public int Like_count { get; set; }
    }
}