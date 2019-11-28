using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_1037_5201
{
    /// <summary>
    /// Guest request
    /// </summary>
    internal class GuestRequest
    {
        /// <summary>
        /// icludes the entry daate, the release dae and a boolean that represents whether the request was approved
        /// </summary>
        public DateTime EntryDate
        {
            set;
            get;
        }
        public DateTime ReleaseDate
        {
            set;
            get;
        }
        public bool IsApproved
        {
            set;
            get;
        }

        /// default ctor
        public GuestRequest()
        {
            EntryDate = new DateTime(Host.Year,1,1);
            ReleaseDate = new DateTime(Host.Year);
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

        /// <summary>
        /// convert a request to string
        /// </summary>
        /// <returns>string that represets a guest request</returns>
        public override string ToString()
        {
            string output;
            output = "Entry date:" + (EntryDate.Day).ToString() + "." + (EntryDate.Month).ToString() + " \n" +
                ", release date:" + (ReleaseDate.Day).ToString() + "." + (ReleaseDate.Month).ToString() + " \n";
            output += (IsApproved) ? "approved" : "not approved";
            return output;
        }

    }

}