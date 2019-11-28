using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_1037_5201
{
    /// <summary>
    /// Hosting unit represents a hotel or room
    /// </summary>

    internal class HostingUnit : IComparable
    {
        //random number generator
        static Random rand = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// serial key is the total number of hosting units
        /// hosting key is the key of the current hosting unit
        /// diary is the calndar that represents the occupation
        /// </summary>
        private static int stSerialKey = 0;
        private int hostingKey;
        //true for occupied
        private bool[,] diary = new bool[12, 31];

        //default ctor
        public HostingUnit()
        {
            HostingKey = StSerialKey + 1;
            StSerialKey++;
        }
        public HostingUnit(int _key)
        {
            HostingKey = _key;
        }
        /// <summary>
        /// properties to fields
        /// </summary>
        public int HostingKey { get => hostingKey; set => hostingKey = value; }
        public int StSerialKey { get => stSerialKey; set => stSerialKey = value; }
        public bool[,] Diary { get => diary; set => diary = value; }

        //indexer
        public bool this[DateTime i] => Diary[i.Month - 1, i.Day - 1];

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// converts HostingUnit to string 
        /// </summary>
        /// <returns>string of hosting unit</returns>
        public override string ToString()
        {
            string output;
            output ="unit ID:"+ HostingKey.ToString()+"\n\n";
            output += hostingdata();
            return output;

        }

        /// <summary>
        /// get the dates of all vactions
        /// </summary>
        /// <returns>string of all occupied dates</returns>
        private string hostingdata()
        {
            DateTime curr = new DateTime(Host.Year, 1, 1);
            //vacations' start
            List<DateTime> v_s = new List<DateTime>();
            //vacations' end
            List<DateTime> v_e = new List<DateTime>();
            //search for start-true
            bool start = true;
            string output = "vacation occupation: \n";
            for (; curr.Year < 2001; curr = curr.AddDays(1))
            {
                if (start && this[curr])
                {
                    start = false;
                    v_s.Add(curr);
                }
                else if ((!start) && (!this[curr]))
                {
                    start = true;
                    v_e.Add(curr);
                }
            }
            if (!start)
            {
                v_e.Add(curr.AddDays(-1));
            }
            for (int i = 0; i < v_s.Count; i++)
            {
                output += "starts: " + v_s[i].Day.ToString() + "." + v_s[i].Month.ToString() + "." + Host.Year.ToString() + " \n";
                output += "ends: " + v_e[i].Day.ToString() + "." + v_e[i].Month.ToString() + "." + Host.Year.ToString() + " \n\n";
            }
            return output;
        }

        /// <summary>
        /// approve request to this hosting unit
        /// </summary>
        /// <param name="guestReq">the wanted request</param>
        /// <returns>true if it was accepted</returns>
        public bool ApproveRequest(GuestRequest guestReq)
        {
            if (Available(guestReq))
            {
                MarkFull(guestReq);
                guestReq.IsApproved = true;
                return true;
            }
            else
            {
                guestReq.IsApproved = false;
                return false;
            }
        }

        /// <summary>
        /// mark full for dates of order
        /// </summary>
        /// <param name="guestReq">guest request</param>
        private void MarkFull(GuestRequest guestReq)
        {
            //toDo adjust to DateTime
            DateTime currDay = guestReq.EntryDate;
            for (; currDay < guestReq.ReleaseDate; currDay = currDay.AddDays(1))
            {
                SetDayTrue(currDay);
            }
        }

        /// <summary>
        /// set a single day as taken
        /// </summary>
        /// <param name="currDay">current day</param>
        private void SetDayTrue(DateTime currDay)
        {
            Diary[currDay.Month - 1, currDay.Day - 1] = true;
        }

        /// <summary>
        /// get the value of a day
        /// </summary>
        /// <param name="currDay"></param>
        /// <returns>value of day</returns>
        private bool GetDay(DateTime currDay)
        {
            return Diary[currDay.Month - 1, currDay.Day - 1];
        }

        /// <summary>
        /// check for availability
        /// </summary>
        /// <param name="guestReq">guest request</param>
        /// <returns>true if available in this range</returns>
        private bool Available(GuestRequest guestReq)
        {
            //help variable to check if room is empty
            bool empty = true;
            //ToDo
            //entry month and day, release month and day
            if (guestReq == null) return false;

            //check for dates availabily
            DateTime currDay = guestReq.EntryDate;
            for (; (currDay < guestReq.ReleaseDate); currDay = currDay.AddDays(1))
            {
                if (GetDay(currDay))
                    empty = false;
            }
            return empty;
        }

        /// <summary>
        /// get how many days in a year are taken
        /// </summary>
        /// <returns>number of taken days</returns>
        public int GetAnnualBusyDays()
        {
            DateTime d = new DateTime(Host.Year, 1, 1);
            int busyDays = 0;
            for (; d.Year < Host.Year+1; d = d.AddDays(1))
            {
                if (this[d])
                    busyDays++;
            }
            if (busyDays < 100)
            {
                ;
            }
            return busyDays;
        }

        /// <summary>
        /// annual percentage of used days
        /// </summary>
        /// <returns>percentage of used days</returns>
        public float GetAnnualBusyPercentage()
        {
            float per = GetAnnualBusyDays() / (256);//assuming 256 days in year
            return per;
        }


        //compare to other hosting unit
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            HostingUnit otherUnit = obj as HostingUnit;
            if (otherUnit != null)
            {
                int ourBusyDays = this.GetAnnualBusyDays();
                int otherBusyDays = otherUnit.GetAnnualBusyDays();
                return ourBusyDays.CompareTo(otherBusyDays);
            }

            else
                throw new ArgumentException("Object is not a HostingUnit");
        }
    }
}