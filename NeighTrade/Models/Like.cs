using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NeighTrade.Models
{
    public class Like
    {
        public int LikeId { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
    }
}