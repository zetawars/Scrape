using System;

namespace Scrape
{
    [Table("Category")]
    public class Category
    {
        [DontInsert][DontUpdate]
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryURL { get; set; }
        public bool Processed { get; set; }
    }
}