using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VELogistics.Models.ViewModel
{
    public class LoadEditViewModel
    {
        public Load Load { get; set; }
        public List<Driver> AvailableDrivers { get; set; }

        // NOTE: Here we use an expression bodied, read-only property
        //       AND the ?. operator
        //       ...good times....
        public List<SelectListItem> DriverOptions =>
            AvailableDrivers?.Select(a => new SelectListItem(a.FullName, a.Id.ToString())).ToList();
    }
}
