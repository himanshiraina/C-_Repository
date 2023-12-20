using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Entities
{
    internal class Orders
    {
        public int OrderId { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int CustomerId { get; set; }
        public Orders() { }

        public Orders(int orderId, DateTime deliveryDate, int customerId)
        {
            OrderId = orderId;
            DeliveryDate = deliveryDate;
            CustomerId = customerId;
        }

    }
}
