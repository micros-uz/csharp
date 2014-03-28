using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary1
{
    public class Person
    {
        public string Name { get; set; }

        public void Save()
        {
            Db.Store(this);
        }
    }

    public class Db
    {
        internal static void Store(Person p)
        {
            File.WriteAllText("persons.db", p.Name);
        }
    }
}
