using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessLayer.Entityes
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string Name { get; set; }

        public bool IsEnable { get; set; }
    }
}
