using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Features
{
    class DbManager
    {
        private static DbManager _this;

        private DbManager()
        {

        }

        public static DbManager Instance
        {
            get
            {
                return _this ?? (_this = new DbManager());
            }
        }

        public void X()
        {

        }
    }
}
