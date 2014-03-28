using System;

namespace _06_NewTypes
{
    internal class Person
    {
        public Day navbatKuni;
        private int age;
        private string name;

        public string addr;
        public string phone;
        private const int Date2 = 9;
        private readonly DateTime Date;

        #region Ctors

        public Person(int a, string s)
        {
            //Date2 = a + 9;
            Date = DateTime.Now;
            age = a;
            name = s;
        }

        public Person()
            :this(18, "Noname")
        {
            navbatKuni = Day.Mon;
            addr = "N/A";
            phone = "N/A";
        }

        #endregion

        public string FullName
        {
            get
            {
                return name + "-" + age;
            }
        }

        public int Age
        {
            get
            {
                return age - 5;
            }
            set
            {
                if (value >= 18)
                    age = value;
            }
        }

        public DateTime BirthDay { get; set; }

        public void Save()
        {
            Console.WriteLine(FullName);
        }
    }
}
