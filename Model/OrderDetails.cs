using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class OrderDetails
    { 
		public string OID { get; set; }
		public int BID { get; set; }
		public double BPrice { get; set; }
		public int BCount { get; set; }
        public double CountPrice { get; set; }
    }
}