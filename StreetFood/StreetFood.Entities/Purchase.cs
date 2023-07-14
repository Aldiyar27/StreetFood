using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int Id_Ingredient { get; set; }
        public int count  { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public string Parther { get; set; }
        public string Comment { get; set; }
    }
}
