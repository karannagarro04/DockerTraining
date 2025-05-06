using System;
using System.Collections.Generic;

namespace ClothStore.Models
{
    public partial class ClothColor
    {
        public ClothColor()
        {
            ClothStocks = new HashSet<ClothStock>();
        }

        public int Id { get; set; }
        public string? ColorCode { get; set; }

        public virtual ICollection<ClothStock> ClothStocks { get; set; }
    }
}
