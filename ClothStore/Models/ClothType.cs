using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothStore.Models
{
    public partial class ClothType
    {
        public ClothType()
        {
            ClothStocks = new HashSet<ClothStock>();
        }

        public int Id { get; set; }
        [Column("ClothType")]
        public string? ClothTypes { get; set; }

        public virtual ICollection<ClothStock> ClothStocks { get; set; }
    }
}
