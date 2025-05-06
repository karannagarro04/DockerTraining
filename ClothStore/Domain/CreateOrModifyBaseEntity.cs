using System;

namespace ClothStore.Domain;

public abstract class CreateOrModifyBaseEntity
{
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
}
