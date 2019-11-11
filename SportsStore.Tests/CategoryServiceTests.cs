using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using BuisnessLayer.Services;
using SportsStore.Tests.MockRepositories;
using BuisnessLayer.Entityes;

namespace SportsStore.Tests
{
    public class CategoryServiceTests
    {
        private CategoryService service;

        private MockCategoryRepository repository;

        public CategoryServiceTests()
        {
            repository = new MockCategoryRepository();
            service = new CategoryService(repository);
        }

        private LinkedList<Category> CreateCategories(int count)
        {
            LinkedList<Category> categories = new LinkedList<Category>();

            for (int i = 0; i < count; i++)
            {
                categories.AddLast(new Category()
                {
                    IsEnable = true,
                    CategoryID = 0,
                    Name = $"Category {i}"
                });
            }

            return categories;
        }

        private void SaveCategories(IEnumerable<Category> categories)
        {
            foreach (Category category in categories)
            {
                service.SaveCategory(category);
            }
        }

        [Fact]
        public void SaveCategory_MethodShould_Save_Category()
        {
            int count = 10;
            LinkedList<Category> categories = CreateCategories(count);

            SaveCategories(categories);

            Assert.Equal(categories, repository.categories);
            repository.Clear();
        }

        [Fact]
        public void Category_Property_Should_Returns_Category()
        {
            int count = 10;
            IEnumerable<Category> categories = CreateCategories(count);
            SaveCategories(categories);

            IEnumerable<Category> categoriesFromService = service.Categories;

            Assert.Equal(categories, categoriesFromService);
            repository.Clear();
        }

        [Fact]
        public void GetCategories_Method_Should_Returns_Category()
        {
            int count = 10;
            IEnumerable<Category> categories = CreateCategories(count);
            SaveCategories(categories);

            IEnumerable<Category> categoriesFromService = service.GetCategories();

            Assert.Equal(categories, categoriesFromService);
            repository.Clear();
        }

        [Fact]
        public void FindCategory_Should_Return_Category_By_Id()
        {
            int count = 10;
            int id = new Random().Next() % count + 1;
            LinkedList<Category> categories = CreateCategories(count);
            SaveCategories(categories);

            Category category = service.FindCategory(id);

            Assert.Equal(category.CategoryID, id);
            repository.Clear();
        }

        [Fact]
        public void FindCategory_Should_Return_Null_By_Id()
        {
            int count = 10;
            int id = count + 1;
            LinkedList<Category> categories = CreateCategories(count);
            SaveCategories(categories);

            Category category = service.FindCategory(id);

            Assert.Null(category);
            repository.Clear();
        }

        [Fact]
        public void FindCategoryByName_Method_Should_Return_Category_By_Name()
        {
            int count = 10;
            int id = new Random().Next() % count + 1;
            LinkedList<Category> categories = CreateCategories(count);
            SaveCategories(categories);
            string categoryName = repository.categories.FirstOrDefault(c => c.CategoryID == id).Name;

            Category category = service.FindCategoryByName(categoryName);

            Assert.Equal(category.Name, categoryName);
            repository.Clear();
        }

        [Fact]
        public void FindCategoryByName_Method_Should_Return_Null_By_Name()
        {
            int count = 10;
            LinkedList<Category> categories = CreateCategories(count);
            string categoryName = "";
            SaveCategories(categories);

            Category category = service.FindCategoryByName(categoryName);

            Assert.Null(category);
            repository.Clear();
        }

        [Fact]
        public void DeleteCategory_Method_Should_Delete_Category_And_Return_It()
        {
            int count = 10;
            int id = new Random().Next() % count + 1;
            LinkedList<Category> categories = CreateCategories(count);
            SaveCategories(categories);

            Category categoryBeforeDelete = repository.categories.FirstOrDefault(p => p.CategoryID == id && p.IsEnable);
            Category category = service.DeleteCategory(id);
            Category categoryAfterDelete = repository.categories.FirstOrDefault(p => p.CategoryID == id && p.IsEnable);

            Assert.NotNull(category);
            Assert.Equal(category.CategoryID, categoryBeforeDelete.CategoryID);
            Assert.Null(categoryAfterDelete);
            repository.Clear();
        }

        [Fact]
        public void DeleteCategory_Method_Should_Not_Delete_Category_And_Return_Null_On_Not_Used_Id()
        {
            int count = 10;
            int id = count + 1;
            LinkedList<Category> categories = CreateCategories(count);
            SaveCategories(categories);

            Category category = service.DeleteCategory(id);

            Assert.Null(category);
            repository.Clear();
        }
    }
}
