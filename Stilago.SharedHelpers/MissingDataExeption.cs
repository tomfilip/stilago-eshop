using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago
{
    public class MissingDataExeption : Exception
    {
        public MissingDataExeption()
            :base()
        {

        }
        public MissingDataExeption(string message)
            :base(message)
        {

        }
    }
}
