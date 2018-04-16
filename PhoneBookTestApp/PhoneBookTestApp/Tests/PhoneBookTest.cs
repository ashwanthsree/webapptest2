using PhoneBookTestApp;
using PhoneBookTestApp.Services;
using PhoneBookTestApp.DataAccessRepo;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using System.Linq;
using System.Linq.Expressions;
using System;


namespace PhoneBookTestAppTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class PhoneBookTest
    {
        PhoneBookMgr pbMgr;

        Mock<IUnitOfWorkFactory> factoryMock;

        Mock<IUnitOfWork> uowMock;
        Mock<IPhoneBookRepository> repoMock;


        public PhoneBookTest()
        {
            pbMgr = new PhoneBookMgr();
            factoryMock = new Mock<IUnitOfWorkFactory>();
            uowMock = new Mock<IUnitOfWork>();
            repoMock = new Mock<IPhoneBookRepository>();

            factoryMock.Setup(f => f.GetUnitOfWork()).Returns(uowMock.Object);
            uowMock.Setup(f => f.PhoneBookRepo).Returns(repoMock.Object);
        }


        [Test]
        public void AddPersonToList()
        {
            Person newPer = new Person();
            newPer.SetName("John Smith");
            newPer.SetPhoneNum("(248) 123-4567");
            newPer.SetAddress("1234 Sand Hill Dr, Royal Oak, MI");
            Assert.That(true, Is.EqualTo(pbMgr.AddPersonToList(newPer)));
        }

        [Test]
        public void FindPersonInList()
        {
            Assert.That("John Smith", Is.EqualTo(pbMgr.FindPerson("John Smith").GetName()));
        }

        [Test]
        public void GetAllPeopleInList()
        {
            List<IPerson> lstPerson = pbMgr.GetAllPeople();
            Assert.IsNotNull(lstPerson); // Test if null
            Assert.AreEqual(1, lstPerson.Count); // Verify the correct Number
        }

        [Test]
        public void AddPersonToDB()
        {
            bool savewascalled = false;

            repoMock.Setup(x => x.Add(It.Is<PHONEBOOK>(c => c.NAME == "John Smith"))).Returns(true);
            uowMock.Setup(f => f.SaveChanges()).Callback(() => savewascalled = true);

            PhoneBookMgr phbk = new PhoneBookMgr(factoryMock.Object);

            Person per = new Person();
            per.SetAddress("");
            per.SetName("John Smith");
            per.SetPhoneNum("");

            bool retval = phbk.AddPersonToDB(per);

            Assert.AreEqual(true, retval, "Add is successful");
            Assert.IsTrue(savewascalled, "Save was called");

        }

        [Test]
        public void FindPersonInDB()
        {

            string name = "John Smith";
            repoMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<PHONEBOOK, bool>>>())).Returns(new List<PHONEBOOK> { new PHONEBOOK { NAME = "John Smith" } });

            PhoneBookMgr phbk = new PhoneBookMgr(factoryMock.Object);

            List<IPerson> lstPerson = phbk.GetAllPeopleFromDB(name);

            Assert.IsNotNull(lstPerson); // Test if null
            Assert.AreEqual(1, lstPerson.Count); // Verify the correct Number
        }
    }

    // ReSharper restore InconsistentNaming 
}