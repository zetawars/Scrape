using System;
using System.Collections.Generic;

namespace Scrape
{
    [Table("Product")]
    public class Product
    {
        [DontInsert]
        [DontUpdate]
        public int ID { get; set; }

        public int SubCategoryID { get; set; }
        public string ID_Link { get; set; } 
        public string name { get; set; }
        [DontInsert]
        [DontUpdate]
        [DontLoad]
        public List<SKU_PackSize> SKU_PackSize { get; set; }
        [DontInsert]
        [DontUpdate]
        [DontLoad]
        public List<string> Packaging { get; set; }
        public string Volume { get; set; }
        public string Density { get; set; }
        public string AmountInKG { get; set; }
        public string PricePerKG { get; set; }
        public string Assay { get; set; }
        public string CASnumber { get; set; }
        public string InChlkey { get; set; }
        public string Description { get; set; }
        public string Biologicalsource { get; set; }
        public string Synonyms { get; set; }
        public string Linearformula { get; set; }
        public string Molecularweight { get; set; }
        public string ECnumber { get; set; }
        public string Beilsteinnumber { get; set; }
        public string PubChemID { get; set; }
        public bool Processed { get; set; }
        public string ProductUrl { get; set; }


    }
}