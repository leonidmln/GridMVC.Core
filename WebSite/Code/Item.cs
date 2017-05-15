using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;

namespace WebSite.Code
{
    public class SaleItem
    {
        public static IEnumerable<ItemModel> ListAll()
        {
            return new ItemModel[] {
                new ItemModel{ Month = "June", ItemName = "Pencil", Quantity = 10, TotalAmount = 101},
                new ItemModel{ Month = "June", ItemName = "Box", Quantity = 5, TotalAmount = 15},
                new ItemModel{ Month = "September", ItemName = "Tools", Quantity = 2, TotalAmount = 10},
                new ItemModel{ Month = "October", ItemName = "Box", Quantity = 5, TotalAmount = 151},
                new ItemModel{ Month = "October", ItemName = "Pencil", Quantity = 7, TotalAmount = 114},
                new ItemModel{ Month = "October", ItemName = "X-Box", Quantity = 1, TotalAmount = 675}
            };
        }
    }
}
