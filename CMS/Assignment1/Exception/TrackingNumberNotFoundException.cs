using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Exception
{
    internal class TrackingNumberNotFoundException : IOException
    {
        public int TrackingNumber { get; }
        public TrackingNumberNotFoundException(int trackingNumber)
            : base($"Courier with number {trackingNumber} not found.")
        {
            TrackingNumber = trackingNumber;
        }
    }
}
