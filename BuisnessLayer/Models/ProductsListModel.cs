using BuisnessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessLayer.Models
{
    public class PageViewModel<T>
    {
        public IEnumerable<T> PageData { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
