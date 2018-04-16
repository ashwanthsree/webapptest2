using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp.DataAccessRepo
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private MyDatabaseEntities _dbContext = new MyDatabaseEntities();
        private IPhoneBookRepository phoneBookRepo;

        public IPhoneBookRepository PhoneBookRepo
        {
            get
            {
                if (this.phoneBookRepo == null)
                {
                    this.phoneBookRepo = new PhoneBookRepository(_dbContext);
                }
                return phoneBookRepo;
            }

        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
