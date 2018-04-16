using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookTestApp.Services;

namespace PhoneBookTestApp
{
    class Program
    {
        //private static PhoneBookMgr phoneBkMgr = null;
        static void Main(string[] args)
        {
            PhoneBookMgr phoneBkMgr = new PhoneBookMgr();
            IUnitOfWorkFactory uowFact = new UnitOfWorkFactory();
            try
            {
                //DatabaseUtil.initializeDatabase();

                /* TODO: create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */

                Console.WriteLine("Input 1 to capture Person details or Input 0 to exit at any time. Press enter to proceed with processing");
                string input = Console.ReadLine();

                while (input == "1")
                {
                    Person newPerson1 = new Person();
                    Console.WriteLine("Enter name of person and press enter");
                    newPerson1.SetName(Console.ReadLine());
                    Console.WriteLine("Enter Phone num of person and press enter");
                    newPerson1.SetPhoneNum(Console.ReadLine());
                    Console.WriteLine("Enter Street of person and press enter");
                    newPerson1.SetAddress(Console.ReadLine());
                    phoneBkMgr.AddPersonToList(newPerson1);

                    Console.WriteLine("Input 1 to continue entering details of next person or input 0 to exit. Press enter to proceed with processing");
                    input = Console.ReadLine();
                }

                // TODO: print the phone book out to System.out
                Console.WriteLine("List of people entered are as follows");
                foreach (Person per in phoneBkMgr.GetAllPeople())
                {
                    Console.WriteLine("***Person Start****");
                    Console.WriteLine(per.GetName());
                    Console.WriteLine(per.GetPhoneNum());
                    Console.WriteLine(per.GetAddress());
                    Console.WriteLine("***Person End****");

                }

                // TODO: find Cynthia Smith and print out just her entry
                Console.WriteLine("Do you want to search by name in the list of people just added (Y / N) ? ");
                string searchflag = Console.ReadLine();
                if (searchflag.ToUpper() == "Y")
                {
                    if (phoneBkMgr.GetAllPeople().Count > 0)
                    {
                        Console.WriteLine("Input name of the person to search and press enter");
                        Person findPerson = (Person)phoneBkMgr.FindPerson(Console.ReadLine());
                        Console.WriteLine(findPerson.GetName());
                        Console.WriteLine(findPerson.GetPhoneNum());
                        Console.WriteLine(findPerson.GetAddress());
                    }
                    else
                    {
                        Console.WriteLine("There are no people to search in the PhoneBook directory");
                    }
                }


                PhoneBookMgr phbkMgrDB = new PhoneBookMgr(uowFact);

                // TODO: insert the new person objects into the database
                foreach (Person per in phoneBkMgr.GetAllPeople())
                {
                    phbkMgrDB.AddPersonToDB(per);
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                phoneBkMgr = null;
                uowFact = null;
            }
        }
    }
}
