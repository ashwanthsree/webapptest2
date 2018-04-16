namespace PhoneBookTestApp
{
    public class Person : IPerson
    {
        private string name;
        private string phoneNumber;
        private string address;

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetPhoneNum()
        {
            return phoneNumber;
        }

        public void SetPhoneNum(string phonenum)
        {
            this.phoneNumber = phonenum;
        }


        public string GetAddress()
        {
            return address;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }


    }
}