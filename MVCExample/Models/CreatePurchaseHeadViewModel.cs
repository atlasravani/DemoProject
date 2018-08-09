using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExample.Models
{
    public class CreatePurchaseHeadViewModel
    {
        public List<Staff> staff { get; set; }
        public List<Customer> customers { get; set; }
        public List<Store> stores { get; set; }
    }
}