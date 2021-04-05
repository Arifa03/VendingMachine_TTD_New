using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    interface ISelectProduct
    {
        bool SelectProduct(string product);

        void GetProducts();
    }
    //product list
}
