﻿using BuisnessLayer.Repositories;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewLayer.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository repository;

        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Category> Categories => repository.Categories;

        public IEnumerable<Category> GetCategories()
        {
            return repository.Categories;
        }

        public Category FindCategory(int categoryID)
        {
            return repository.FindCategory(categoryID);
        }

        public Category FindCategoryByName(string categoryName)
        {
            return repository.FindCategoryByName(categoryName);
        }

        public void SaveCategory(Category category)
        {
            repository.SaveCategory(category);
        }

        public Category DeleteCategory(int categoryID)
        {
            return repository.DelteCategory(categoryID);
        }
    }
}