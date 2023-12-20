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
        DateTime paymentDate;

        // Default constructor
        public Payment()
        {
            // dc
        }

        // Parameterized constructor
        public Payment(long paymentID, long courierID, double amount, DateTime paymentDate)
        {
            this.paymentID = paymentID;
            this.courierID = courierID;
            this.amount = amount;
            this.paymentDate = paymentDate;
        }
        // Getters and Setters
        public long PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; }
        }

        public long CourierID
        {
            get { return courierID; }
            set { courierID = value; }
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }

        // ToString method to represent object as a string
        public override string ToString()
        {
            return $"PaymentID: {paymentID}, CourierID: {courierID}, Amount: {amount}, PaymentDate: {paymentDate}";
        }
    }
}


