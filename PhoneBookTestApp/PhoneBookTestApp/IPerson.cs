using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    public interface IPerson
    {
        string GetName();

        void SetName(string name);

        string GetPhoneNum();

        void SetPhoneNum(string phonenum);

        string GetAddress();

        void SetAddress(string address);
    }
}
