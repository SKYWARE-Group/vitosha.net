using System;
using System.Collections.Generic;
using System.Text;

namespace Vitosha.Model.Universal
{
    public enum MessageStatuses : int
    {
        NOT_SENT = -1,
        SENT_FAIL = 100,
        SENT_SUCCESS = 200
    }
}
