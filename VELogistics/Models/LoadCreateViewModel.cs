using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VELogistics.Models.ViewModel
{
    public class LoadCreateViewModel
    {
        public Load Load { get; set; }
        public List<UserType> AvailableUserTypes { get; set; }
        // NOTE: Here we use an expression bodied, read-only property
        //       AND the ?. operator
        //       ...good times....
        public List<SelectListItem> UserTypeOptions
        {
            get
            {
                if (AvailableUserTypes == null)
                {
                    return null;
                }

                var apt = AvailableUserTypes?.Select(a => new SelectListItem(a.Name, a.Id.ToString())).ToList();
                apt.Insert(0, new SelectListItem("Select UserType", "Add UserType"));

                return apt;
            }
        }
        public List<Driver> AvailableDrivers { get; set; }
        public List<SelectListItem> DriverOptions
        {
            get
            {
                if (AvailableDrivers == null)
                {
                    return null;
                }
                var apt = AvailableDrivers?.Select(a => new SelectListItem(a.FullName, a.Id.ToString())).ToList();
                apt.Insert(0, new SelectListItem("Select Driver", "Add Driver"));

                return apt;
            }


        }
    }
}
