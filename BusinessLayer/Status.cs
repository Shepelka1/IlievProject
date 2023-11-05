using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    [Flags]
    public enum Status
    {
        Offline,
        Online,
        Busy,
        Sad
    }
}
