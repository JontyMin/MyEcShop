using System;

namespace Model
{
	public class Order
	{
		public string OID { get; set; }
		public int MID { get; set; }
		public DateTime ODate { get; set; }
		public string OConsignee { get; set; }
		public string OAddress { get; set; }
		public string OTelephone { get; set; }
		public double OSumPrice { get; set; }
		public int OState { get; set; }
		public string state { get; set; }
	}
}
