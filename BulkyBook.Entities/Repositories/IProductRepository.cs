﻿using BulkyBook.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Entities.Repositories
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        void Update(Product product);
    }
}
