using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities
{
    internal class Payment
    {
        long paymentID;
        long courierID;
        double amount;
        date paymentdate;

        public long PaymentID { get { return paymentID; } set { paymentID = value; } }
        public long CourierID { get { return courierID; } set { courierID = value; } }
        public double Amount { get { return amount; } set { amount = value; } }
        public date PaymentDate { get { return paymentdate; } set { paymentdate = value; } }
        public Payment(long paymentID, long courierID, double amount, date paymentdate)
        {
            PaymentID = paymentID;
            CourierID = courierID;
            Amount = amount;
            PaymentDate = paymentdate;
         
        }
    }
}


