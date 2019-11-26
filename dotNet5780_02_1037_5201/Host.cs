using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace dotNet5780_02_1037_5201
{

    internal class Host : IEnumerable
    {
        private List<HostingUnit> hostingUnits;
        public int HostKey
        {
            set; get;
        }
        public List<HostingUnit> HostingUnits { get => hostingUnits; set => hostingUnits = value; }
        public HostingUnit this[int i] => HostingUnits[i];

        public Host()
        {
        }
        
        /// <summary>
        /// intialize Host with id and number of units rquired
        /// </summary>
        /// <param name="id">id of host</param>
        /// <param name="numOfUnits">number of hosting units he has</param>
        public Host(int id,int numOfUnits)
        {
            HostKey = id;
            HostingUnits = new List<HostingUnit>(numOfUnits);
            for (int i = 0; i < numOfUnits; i++)
            {
                HostingUnits.Add(new HostingUnit());
                HostingUnits[i].StSerialKey = HostingUnits[i].StSerialKey + 1;
            }

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
            string output= "";
            output += "host id: " + HostKey.ToString()+" \n";
            for (int i = 0; i < HostingUnits.Count; i++)
            {
                output +="unit number "+(i+1).ToString()+": "+ HostingUnits[i].ToString()+" \n";
            }
            return output;
        }

        private long SubmitRequest(GuestRequest guestReq)
        {
            long res = -1;
            foreach(HostingUnit h in HostingUnits)
            {
                if (h!=null && h.ApproveRequest(guestReq))
                {
                    res = h.HostingKey;
                    break;
                }
            }
            return res;
        }

        public int GetHostAnnualBusyDays()
        {
            int sum = 0;
            foreach(HostingUnit h in HostingUnits)
            {
                if(h!=null)
                    sum += h.GetAnnualBusyDays();
            }
            return sum;
        }

        public void SortUnits()
        {
            HostingUnits.Sort();
        }

        public bool AssignRequests(params GuestRequest[] guestRequests)
        {
            bool flag = true;
            foreach(GuestRequest g in guestRequests)
            {
                long res=SubmitRequest(g);
                if (-1 == res)
                    flag = false;
            }

            
            return flag;
        }

        public IEnumerator GetEnumerator()
        {
            return HostingUnits.GetEnumerator();
        }
    }
}