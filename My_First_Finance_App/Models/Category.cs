using System.Collections.Generic;

namespace My_First_Finance_App.Models
{
    public class Category
    {

        public int CategoryId { get; set; }
        public required string Name { get; set; }
        
        public List<Transaction>? Transactions { get; set; }
    }
}