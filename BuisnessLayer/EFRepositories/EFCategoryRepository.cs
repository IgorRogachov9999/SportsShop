using DataLayer;
using DataLayer.Entityes;
using BuisnessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessLayer.EFRepositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private AppDbContext context;

        public EFCategoryRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Category> Categories => context.Categories;

        public Category DelteCategory(int categoryID)
        {
            Category dbEntry = context.Categories
                .FirstOrDefault(c => c.CategoryID == categoryID);
            if (dbEntry != null)
            {
                context.Categories.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveCategory(Category category)
        {
            if (category.CategoryID == 0 && !context.Categories.Any(c => c.Name == category.Name))
            {
                context.Categories.Add(category);
            }
            else
            {
                Category dbEntry = context.Categories
                    .FirstOrDefault(c => c.CategoryID == category.CategoryID || 
                        c.Name == category.Name);

                if (dbEntry != null)
                {
                    dbEntry.Name = category.Name;
                }
            }
            context.SaveChanges();
        }
    }
}
