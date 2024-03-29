﻿using BuisnessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessLayer.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

        void SaveCategory(Category category);

        Category DelteCategory(int categoryID);

        Category FindCategory(int categoryID);

        Category FindCategoryByName(string name);
    }
}
