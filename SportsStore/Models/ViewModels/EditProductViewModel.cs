using SportsStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.ViewModels
{
    public class EditProductViewModel
    {
        public Product Product { get; set; }

        public IEnumerable<Category> AllCategories { get; set; }

    }
}
