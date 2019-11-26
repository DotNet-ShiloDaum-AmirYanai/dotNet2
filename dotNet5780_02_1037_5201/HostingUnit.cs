using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_1037_5201
{
    internal class HostingUnit:IComparable
    {
        private static int stSerialKey;
        private int hostingKey;
        //true for occupied
        private static bool[,] Diary;
        public HostingUnit()
        {
        }

        public int HostingKey { get => hostingKey; set => hostingKey = value; }

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

        private void MarkFull(GuestRequest guestReq)
        {
            //ToDo
            throw new NotImplementedException();
        }

        private bool Available(GuestRequest guestReq)
        {
            //ToDo
            throw new NotImplementedException();
        }

        public int GetAnnualBusyDays()
        {
            int busyDays = 0;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (Diary[i, j] == true)
                    {
                        ++busyDays;
                    }
                }
            }
            return busyDays;
        }
        public float GetAnnualBusyPercentage()
        {
            return GetAnnualBusyDays()/(31*12.0f);
        }

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