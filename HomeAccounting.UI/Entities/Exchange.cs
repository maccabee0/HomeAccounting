using System;

namespace HomeAccounting.UI.Entities
{
    public class Exchange
    {
        public int ExchangeID { get; set; }
        public DateTime Date { get; set; }
        public decimal DollarAmount { get; set; }
        public decimal Course { get; set; }
        public decimal GrivnyaAmount { get { return Course * DollarAmount; } }
    }
}
