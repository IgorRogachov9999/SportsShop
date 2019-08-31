using SportsStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.Repositories
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }

        void SaveCategory(Category category);

        Category DelteCategory(int categoryID);
    }
}
