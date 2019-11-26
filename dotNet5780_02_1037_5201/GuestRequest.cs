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
            return base.ToString();
        }
       
    }

}