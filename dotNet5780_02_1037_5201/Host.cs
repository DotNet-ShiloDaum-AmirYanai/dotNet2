using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace dotNet5780_02_1037_5201
{
    /// <summary>
    /// represents a host
    /// </summary>
    internal class Host : IEnumerable
    {
        /// <summary>
        /// hosting units is a list of hosting units
        /// </summary>
        private List<HostingUnit> hostingUnits;

        // host key is id number of host
        public int HostKey
        {
            set; get;
        }

        //property for hostingUnits
        public List<HostingUnit> HostingUnits { get => hostingUnits; set => hostingUnits = value; }

        //indexer
        public HostingUnit this[int i] => HostingUnits[i];

        //default ctor
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
            //ad new unit
            for (int i = 0; i < numOfUnits; i++)
            {
                HostingUnits.Add(new HostingUnit());
            }

        }

        //auto function
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //convert Host to str
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

        /// <summary>
        /// add new request
        /// </summary>
        /// <param name="guestReq">the request to add</param>
        /// <returns>hosting unit id if there is an available one</returns>
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

        /// <summary>
        /// get how the sum of the days each unit was occupied
        /// </summary>
        /// <returns>sum of occupied days in all units</returns>
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

        /// <summary>
        /// sort the list of hosting units
        /// </summary>
        public void SortUnits()
        {
            HostingUnits.Sort();
        }

        /// <summary>
        /// gets a list of requests and submits them all
        /// </summary>
        /// <param name="guestRequests">list of requests</param>
        /// <returns>true if all requests were submitted successfully</returns>
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

        /// <summary>
        /// get enumarator
        /// </summary>
        /// <returns>enumarator of hostings units' list</returns>
        public IEnumerator GetEnumerator()
        {
            return HostingUnits.GetEnumerator();
        }
    }
}