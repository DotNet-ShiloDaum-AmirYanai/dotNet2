using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_1037_5201
{
    internal class GuestRequest
    {
        public int[] EntryDate
        {
            set;
            get;
        }
        public int[] ReleaseDate
        {
            set;
            get;
        }
        public bool IsApproved
        {
            set;
            get;
        }

        public GuestRequest()
        {
            EntryDate = new int[2];
            ReleaseDate = new int[2];
            IsApproved = false;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string output;
            output = "Entry date:" + (EntryDate[0]+1).ToString()+"."+ (EntryDate[1] + 1).ToString() +"\n"+
                ", release date:" + (ReleaseDate[0] + 1).ToString() + "." + (ReleaseDate[1] + 1).ToString() + "\n";
            output += (IsApproved) ? "approved" : "not approved";

            return output;
        }
       
    }

}