using System;

namespace ClothStore.Domain.ClothStock;

public class ClothStock : CreateOrModifyBaseEntity
{
        public int ClothId { get; set; }
        public int? RateOfCloth { get; set; }
        public int? ClothsInStock { get; set; }
        public int BrandName { get; set; }
        public int ClothSize { get; set; }
        public int TypeOfCloth { get; set; }
        public int ColorOfCloth { get; set; }
}
