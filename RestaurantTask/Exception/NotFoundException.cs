using System;
using System.Collections.Generic;
using System.Text;

namespace Exception
{
    public class NotFoundException:RankException
    {
        public NotFoundException(string msg):base(msg)
        {

        }

    }
}
