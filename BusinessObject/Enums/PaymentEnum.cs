using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Enums
{
    public enum PaymentStatus
    {
        Unpaid = 0,
        Paid = 1,
    }
    public enum PaymentMethod
    {
        COD, MOMO, PAYPAL
    }
}
