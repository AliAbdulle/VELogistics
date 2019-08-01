using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VELogistics.Models.ViewModel
{
    public class LoadCustomerCreateViewModel
    {
        public Load Load { get; set; }
        public List<UserType> AvailableUserType { get; set; }

        // NOTE: Here we use an expression bodied, read-only property
        //       AND the ?. operator
        //       ...good times....
        public List<SelectListItem> AvailableOption
        {
            get
            {
                if (AvailableUserType == null)
                {
                    return null;
                }

                var apt = AvailableUserType?.Select(l => new SelectListItem(l.Name, l.Id.ToString())).ToList();
                apt.Insert(0, new SelectListItem("Select Customer", "Add Customer"));

                return apt;
            }
        }
    }
}