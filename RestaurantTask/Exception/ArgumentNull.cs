using System;
using System.Collections.Generic;
using System.Text;

namespace Exception
{
    public class ArgumentNull:RankException
    {
        public ArgumentNull(string msg):base(msg)
        {

        }
    }
}
