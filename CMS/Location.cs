using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities
{
    internal class Location
    {
        long locationID;
        string locationname;
        string address;
        public long LocationID { get { return locationID; } set { locationID = value; } }
        public string LocationName { get { return locationname; } set { locationname = value; } }
        public string Address { get { return address; } set { address = value; } }

        public Location(long locationID, string locationname, string address)
        {
            LocationID = locationID;
            LocationName = locationname;
            Address = address;


        }
    }
}

