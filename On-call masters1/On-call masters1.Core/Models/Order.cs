using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace On_call_masters1.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal PriceOfOrder { get; set; }
        public int UserID { get; set; }
        public int WorkRegionID { get; set; }
    }
}
