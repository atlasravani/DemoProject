using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExample.Models
{
    public class CreatePurchaseLineViewModel
    {
        public PurchaseHead header { get; set; }
        public List<Product> products { get; set; }
    }
}