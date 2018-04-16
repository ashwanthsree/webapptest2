using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp.DataAccessRepo
{
    public interface IUnitOfWork
    {
        IPhoneBookRepository PhoneBookRepo { get; }
        void SaveChanges();
    }
}
