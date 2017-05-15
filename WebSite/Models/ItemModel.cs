using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class ItemModel
    {
        public string Month { get; set; }
        public string ItemName { get; set; }
        public int Quantity{get;set;}
        public decimal TotalAmount { get; set; }
    }
}
