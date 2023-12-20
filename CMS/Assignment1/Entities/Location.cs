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
        string locationName;
        string address;
        // Default constructor
        public Location()
        {
            // dc
        }

        // Parameterized constructor
        public Location(long locationID, string locationName, string address)
        {
            this.locationID = locationID;
            this.locationName = locationName;
            this.address = address;
        }
        // Getter and Setters
        public long LocationID
        {
            get { return locationID; }
            set { locationID = value; }
        }

        public string LocationName
        {
            get { return locationName; }
            set { locationName = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        // ToString method to represent object as a string
        public override string ToString()
        {
            return $"LocationID: {locationID}, LocationName: {locationName}, Address: {address}";
        }
    }
}

