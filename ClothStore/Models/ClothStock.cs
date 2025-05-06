using System;
using System.Collections.Generic;

namespace ClothStore.Models
{
    public partial class ClothStock
    {
        public int ClothId { get; set; }
        public int? RateOfCloth { get; set; }
        public int? ClothsInStock { get; set; }
        public int BrandName { get; set; }
        public int ClothSize { get; set; }
        public int TypeOfCloth { get; set; }
        public int ColorOfCloth { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Brand BrandNameNavigation { get; set; } = null!;
        public virtual Size ClothSizeNavigation { get; set; } = null!;
        public virtual ClothColor ColorOfClothNavigation { get; set; } = null!;
        public virtual ClothType TypeOfClothNavigation { get; set; } = null!;
    }
}
