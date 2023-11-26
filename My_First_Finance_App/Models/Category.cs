using System.Collections.Generic;

namespace My_First_Finance_App.Models
{
    public class Category
    {

        public int CategoryId { get; set; }
        public required string Name { get; set; }
        // Other category-related properties
        public List<Transaction>? Transactions { get; set; }
    }
}