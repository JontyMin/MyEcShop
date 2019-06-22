using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Book
    { 
		public int BID { get; set; }
		public int BSID { get; set; }
		public string BName { get; set; }
		public string BAuthor { get; set; }
		public string BISBN { get; set; }
		public string BTOC { get; set; }
		public string BComment { get; set; }
		public string BPic { get; set; }
		public double BPrice { get; set; }
		public int BCount { get; set; }
		public DateTime BDate { get; set; }
		public int BSaleCount { get; set; }

    }
}