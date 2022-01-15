using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vitosha.Model.Universal;
using VitoshaWebModel.Model.Request;

namespace VitoshaClient.Helpers.LinkMobility
{

    public static class StatusHelper
    {

        public static MessageStatuses GetStatus(Message skmeg) => 
            skmeg.Statuses.Any(x => x.Status == 202) ? 
                MessageStatuses.SENT_SUCCESS : 
                    skmeg.Statuses.Length <= 0 ? 
                        MessageStatuses.NOT_SENT : MessageStatuses.SENT_FAIL;

    }

}
