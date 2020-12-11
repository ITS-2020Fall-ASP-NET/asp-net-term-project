using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NeighTrade.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public Nullable<int> BuyerId { get; set; }
        public Nullable<int> SellerId { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Status { get; set; }
        public String toString()
        {
            return Date.ToString();
        }
    }
}