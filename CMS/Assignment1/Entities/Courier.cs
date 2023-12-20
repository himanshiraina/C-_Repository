using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Entities
{
    public class Courier
    {
        // Static variables for autogenerating IDs
        private static long nextCourierID = 20;
        private static long nextTrackingNumber = 4008;

        public long CourierID { get; private set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public double Weight { get; set; }
        public string Status { get; set; }
        public long TrackingNumber { get; private set; }
        public DateTime DeliveryDate { get; set; }
        public int UserId { get; set; }

        public Courier()
        {
            CourierID = ++nextCourierID;
            TrackingNumber = nextTrackingNumber++;
        }

        public Courier(string senderName, string senderAddress, string receiverName, string receiverAddress, double weight, string status, DateTime deliveryDate, int userId)
            : this()
        {
            SenderName = senderName;
            SenderAddress = senderAddress;
            ReceiverName = receiverName;
            ReceiverAddress = receiverAddress;
            Weight = weight;
            Status = status;
            DeliveryDate = deliveryDate;
            UserId = userId;
        }

        public override string ToString()
        {
            return $"CourierID: {CourierID}\nSender: {SenderName} - {SenderAddress}\nReceiver: {ReceiverName} - {ReceiverAddress}\nWeight: {Weight}kg\nStatus: {Status}\nTracking Number: {TrackingNumber}\nDelivery Date: {DeliveryDate}\nUser ID: {UserId}";
        }

        // Getters and setters for each property
        public long courierID
        {
            get;
            private set;
        }

        public string senderName
        {
            get;
            set;
        }

        public string senderAddress
        {
            get;
            set;
        }

        public string receiverName
        {
            get;
            set;
        }

        public string receiverAddress
        {
            get;
            set;
        }

        public double weight
        {
            get;
            set;
        }

        public string status
        {
            get;
            set;
        }

        public long trackingNumber
        {
            get;
            private set;
        }

        public DateTime deliveryDate
        {
            get;
            set;
        }

        public int userId
        {
            get;
            set;
        }

       
    }

}
