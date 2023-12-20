using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Entities
{
    internal class Admin
    {

        public int Courier_StaffID { get; set; }
        public string NAME { get; set; }
        public string CONTACT_NO { get; set; }

        public Admin() { }

        public Admin(int courier_StaffID, string nAME, string cONTACT_NO)
        {
            Courier_StaffID = courier_StaffID;
            NAME = nAME;
            CONTACT_NO = cONTACT_NO;
        }
    }
}
