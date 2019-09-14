using System;

namespace  Scrape
{
    public class SKUPackagingPrice
    {
        [DontInsert][DontUpdate]
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string SKU { get; set; }
        public double? Price { get; set; }
        public string Packaging { get; set; }
        public double? PricePerKG { get; set; }
        public double? AmountInKG { get; set; }
        public double? Volume_Ltr { get; set; }
    }
}