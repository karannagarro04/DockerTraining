using System;
using System.Collections.Generic;

namespace ClothStore.Models
{
    public partial class Brand
    {
        public Brand()
        {
            ClothStocks = new HashSet<ClothStock>();
        }

        public int Id { get; set; }
        public string? BrandName { get; set; }

        public virtual ICollection<ClothStock> ClothStocks { get; set; }
    }
}
