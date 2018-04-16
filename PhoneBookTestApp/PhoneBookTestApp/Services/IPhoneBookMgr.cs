using System.Collections.Generic;

namespace PhoneBookTestApp
{
    public interface IPhoneBookMgr
    {
        IPerson FindPerson(string name);
        bool AddPersonToDB(IPerson newPerson);

        bool AddPersonToList(IPerson person);
        List<IPerson> GetAllPeople();
    }
}