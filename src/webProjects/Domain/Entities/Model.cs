﻿using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Model : BaseEntity<int>
{
    public int BrandId { get; set; }
    public string Name { get; set; }

    public Brand? Brand { get; set; }

    public virtual ICollection<Car> Cars { get; set; }

    public Model()
    {
        Cars = new HashSet<Car>();
    }

    public Model(int id, int brandId, string name)
    {
        Id = id;
        BrandId = brandId;
        Name = name;
    }
}