using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities
{
    internal class CourierServices
    {
        int serviceID;
        string servicename;
        double cost;
        public int ServiceID { get { return serviceID; } set { serviceID = value; } }
        public string ServiceName { get { return servicename; } set { servicename = value; } }
        public double Cost { get { return cost; } set { cost = value; } }
       
        public CourierServices(int serviceID, string servicename, double cost)
        {
            ServiceID = serviceID;
            ServiceName = servicename;
            Cost = cost;


        }
    }
}

