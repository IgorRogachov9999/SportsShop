using BuisnessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BuisnessLayer.Repositories;

namespace SportsStore.Tests.MockRepositories
{
    class MockCategoryRepository : ICategoryRepository
    {
        public LinkedList<Category> categories;

        public MockCategoryRepository()
        {
            categories = new LinkedList<Category>();
        }

        public void Clear()
        {
            categories = new LinkedList<Category>();
        }

        public IEnumerable<Category> Categories => categories.Where(p => p.IsEnable).AsQueryable();

        public Category DelteCategory(int categoryID)
        {
            Category dbEntry = categories
                .FirstOrDefault(c => c.CategoryID == categoryID && c.IsEnable);
            if (dbEntry != null)
            {
                dbEntry.IsEnable = false;
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
            if (category.CategoryID == 0 && !Categories.Any(c => c.Name == category.Name && c.IsEnable))
            {
                category.CategoryID = categories.Last != null ? categories.Last.Value.CategoryID + 1 : 1;
                categories.AddLast(category);
            }
            else
            {
                Category dbEntry = Categories
                    .FirstOrDefault(c => (c.CategoryID == category.CategoryID ||
                        c.Name == category.Name) && c.IsEnable);

                if (dbEntry != null)
                {
                    dbEntry.Name = category.Name;
                }
            }
        }
    }
}
