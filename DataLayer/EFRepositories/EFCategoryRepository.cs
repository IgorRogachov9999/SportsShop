using BuisnessLayer;
using BuisnessLayer.Entityes;
using BuisnessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayer.EFRepositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private AppDbContext context;

        public EFCategoryRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Category> Categories => context.Categories.Where(p => p.IsEnable);

        public Category DelteCategory(int categoryID)
        {
            Category dbEntry = context.Categories
                .FirstOrDefault(c => c.CategoryID == categoryID);
            if (dbEntry != null)
            {
                dbEntry.IsEnable = false;
                context.SaveChanges();
            }
            return dbEntry;
        }

        public Category FindCategory(int categoryID)
        {
            return Categories.FirstOrDefault(c => c.CategoryID == categoryID && c.IsEnable);
        }

        public Category FindCategoryByName(string name)
        {
            return Categories.FirstOrDefault(c => c.Name == name && c.IsEnable);
        }

        public void SaveCategory(Category category)
        {
            if (category.CategoryID == 0 && !context.Categories.Any(c => c.Name == category.Name && c.IsEnable))
            {
                context.Categories.Add(category);
            }
            else
            {
                Category dbEntry = context.Categories
                    .FirstOrDefault(c => (c.CategoryID == category.CategoryID || 
                        c.Name == category.Name) && c.IsEnable);

                if (dbEntry != null)
                {
                    dbEntry.Name = category.Name;
                }
            }
            context.SaveChanges();
        }
    }
}
