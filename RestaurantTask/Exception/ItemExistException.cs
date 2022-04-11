using System;
using System.Collections.Generic;
using System.Text;

namespace Exception
{
    public class ItemExistException:RankException
    {
        public ItemExistException(string msg):base(msg)
        {

        }
    }
}
