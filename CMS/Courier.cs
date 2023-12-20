using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities
{
    internal class Courier
    {
        long courierID;
        string sendername;
        string senderaddress;
        string receivername;
        string receiveraddress;
        double weight;
        string status;
        long trackingnumber;
        date deliverydate;

        public long CourierID { get { return courierID; } set { courierID = value; } }
        public string SenderName { get { return sendername; } set { sendername = value; } }
        public string SenderAddress { get { return senderaddress; } set { senderaddress = value; } }
        public string ReceiverName { get { return receivername; } set { receivername = value; } }
        public string ReceiverAddress { get { return receiveraddress; } set { receiveraddress = value; } }
        public double Weight { get { return weight; } set { weight = value; } }
        public string Status { get { return status; } set { status = value; } }
        public long TrackingNumber { get { return trackingnumber; } set { trackingnumber = value; } }
        public date DeliveryDate { get { return deliverydate; } set { deliverydate = value; } }
        public Courier(int courierID, string sendername, string senderaddress, string receivername, string receiveraddress, 
            double weight,string status,long trackingnumber,date deliverydate)
        {
            CourierID = courierID;
            SenderName = sendername;
            SenderAddress = senderaddress;
            ReceiverName = receivername;
            ReceiverAddress = receiveraddress;
            Weight = weight;
            Status = status;
            TrackingNumber = trackingnumber;
            DeliveryDate = deliverydate;
        }
    }
}

