using System;
using System.Collections.Generic;

namespace ClothStore.Models
{
    public partial class Size
    {
        public Size()
        {
            ClothStocks = new HashSet<ClothStock>();
        }

        public int Id { get; set; }
        public string? ClothSize { get; set; }

        public virtual ICollection<ClothStock> ClothStocks { get; set; }
    }
}
