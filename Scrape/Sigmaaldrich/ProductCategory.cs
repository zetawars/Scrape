using System.Collections.Generic;

namespace  Scrape
{
    public class ProductCategory
    {
        public string CategoryName { get; set; }
        public List<ProductSubCategory> SubCategories { get; set; }

    }
}