using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookTestApp;

namespace PhoneBookTestApp.Mapper
{
    public static class PhoneBookMapper
    {
        public static PHONEBOOK MapPerBEToDE(IPerson per)
        {
            PHONEBOOK phBK = new PHONEBOOK();
            phBK.NAME = per.GetName();
            phBK.ADDRESS = per.GetAddress();
            phBK.PHONENUMBER = per.GetPhoneNum();
            return phBK;
        }

        public static List<IPerson> MapPerDEToBE(List<PHONEBOOK> phbk)
        {
            List<IPerson> lstPerson = new List<IPerson>();
            foreach (PHONEBOOK phbook in phbk)
            {
                Person per = new Person();
                per.SetAddress(phbook.ADDRESS);
                per.SetName(phbook.NAME);
                per.SetPhoneNum(phbook.PHONENUMBER);
                lstPerson.Add(per);
            }

            return lstPerson;

        }
    }
}
