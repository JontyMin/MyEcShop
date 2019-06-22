using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Trade
    { 
		public int TID { get; set; }
		public int BID { get; set; }
		public int MID { get; set; }
		public int BCount { get; set; }
        public string BName { get; set; }
        public string BPic { get; set; }
        public double BPrice { get; set; }
        public double Xj { get; set; }
    }
}