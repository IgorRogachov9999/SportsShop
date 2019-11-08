using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewLayer.Components
{
    public class AdminNavigationMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();

    }
}
