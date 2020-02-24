using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kkfmisservice.Constant
{
    public class StaticValue
    {
       
        private static StaticValue instant { get; set; }
        private StaticValue()
        {
        }

        public static StaticValue GetInstant()
        {
            if (instant == null) instant = new StaticValue();
            return instant;
        }

        public void LoadInstantAll()
        {
            this.AccessKey();
            this.TokenKey();
            this.UserData();
        }

        internal dynamic GetUserDetail(object updateBy)
        {
            throw new NotImplementedException();
        }

        public void AccessKey()
        {
            
        }

        public void TokenKey()
        {
           
        }

        public void UserData()
        {
            
        }

        

    }
}
