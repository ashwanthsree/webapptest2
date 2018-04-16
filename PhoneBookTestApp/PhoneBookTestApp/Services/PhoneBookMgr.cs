using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookTestApp.Mapper;
using PhoneBookTestApp.Services;
using PhoneBookTestApp.DataAccessRepo;

namespace PhoneBookTestApp
{
    public class PhoneBookMgr : IPhoneBookMgr
    {
        private List<IPerson> lstPerson = new List<IPerson>();
        private readonly IUnitOfWorkFactory _factory;

        public PhoneBookMgr()
        {
        }

        public PhoneBookMgr(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public bool AddPersonToList(IPerson person)
        {
            try
            {
                lstPerson.Add(person);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool AddPersonToDB(IPerson person)
        {
            try
            {
                IUnitOfWork unitOfWork = _factory.GetUnitOfWork();
                unitOfWork.PhoneBookRepo.Add(PhoneBookMapper.MapPerBEToDE(person));
                unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IPerson FindPerson(string name)
        {
            IPerson per = null;
            try
            {
                foreach (IPerson pers in lstPerson)
                {
                    if (pers.GetName().ToLower() == name.ToLower())
                    {
                        per = pers;
                    }
                }
                return per;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<IPerson> GetAllPeople()
        {
            return lstPerson;
        }

        public List<IPerson> GetAllPeopleFromDB(string name)
        {
            try
            {
                IUnitOfWork unitOfWork = _factory.GetUnitOfWork();
                return PhoneBookMapper.MapPerDEToBE(unitOfWork.PhoneBookRepo.GetAll(x => x.NAME.ToUpper() == name.ToUpper()).ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
