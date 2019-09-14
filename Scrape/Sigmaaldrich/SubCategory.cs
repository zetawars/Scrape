using System;

namespace Scrape
{
    [Table("SubCategory")]
    public class SubCategory
    {
        [DontInsert]
        [DontUpdate]
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryURL { get; set; }
        public bool Processed { get; set; }
        public int? SubCategoryID { get; set; }
    }
}