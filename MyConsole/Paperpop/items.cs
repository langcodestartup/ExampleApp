using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole.Paperpop
{
    public class Order
    {

        public string OrderNo { get; set; }
        public string Recipient { get; set; }
        public string OrderItemName { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }

        public Dictionary<string, int> SKUS { get; set; }
    }

    public class Item
    {
        public string Id { get; set; } // Key : OrderItemName, Option
        public Dictionary<string, int> SKUs { get; set; }
    }
}
