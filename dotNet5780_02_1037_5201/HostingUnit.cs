using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_1037_5201
{
    internal class HostingUnit : IComparable
    {
        static Random rand = new Random(DateTime.Now.Millisecond);

        private static int stSerialKey=0;
        private int hostingKey;
        //true for occupied
        private bool[,] Diary = new bool[12, 31];
        public HostingUnit() => HostingKey = rand.Next(1, 99999999);
        public HostingUnit(int _key) => HostingKey = _key;

        public int HostingKey { get => hostingKey; set => hostingKey = value; }
        public int StSerialKey { get => stSerialKey; set => stSerialKey = value; }

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
            output = HostingKey.ToString();
            return output;

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
            int ed = guestReq.EntryDate[0];
            int em = guestReq.EntryDate[1];
            int rd = guestReq.ReleaseDate[0];
            int rm = guestReq.ReleaseDate[1];

            int months = rm - em;

            int duration = months * 31 + rd - ed - 1;

            for (int i = 0; i < duration; Diary[(em + (ed + i) / 31) % 12, (ed + i) % 31] = true, i++) ;
        }

        private bool Available(GuestRequest guestReq)
        {
            //help variable to check if room is empty
            bool empty = true;
            //ToDo
            //entry month and day, release month and day
            if (guestReq == null) return false;

            int ed = guestReq.EntryDate[0];
            int em = guestReq.EntryDate[1];
            int rd = guestReq.EntryDate[0];
            int rm = guestReq.EntryDate[1];

            int months = rm - em;

            int curm, curd;
            int duration = months * 31 + rd - ed - 1;
            //check for dates availabily
            for (int i = 0; i < months * 31 + rd - ed - 1; i++)
            {
                //ToCheck
                //check that no days are already occupied
                curm = (em + (ed + i) / 31) % 12;
                curd = (ed + i) % 31;
                if (Diary[curm, curd]) empty = false;
            }
            return empty;
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
            float per = GetAnnualBusyDays() / (31 * 12.0f);
            return per;
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