using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NeighTrade.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<int> Parent { get; set; }
    }
}