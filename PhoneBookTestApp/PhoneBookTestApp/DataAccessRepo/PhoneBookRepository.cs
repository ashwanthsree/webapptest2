using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp.DataAccessRepo
{
    public class PhoneBookRepository : Repository<PHONEBOOK>, IPhoneBookRepository
    {
        public PhoneBookRepository(MyDatabaseEntities dbcontext) : base(dbcontext)
        {

        }
    }
}
