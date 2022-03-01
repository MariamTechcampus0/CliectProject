using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CliectProject.Models
{
    public enum OrderStatus
    {
        WaitPayment = 1,
        PindingAdmin =2,
        InProgress = 3,
        Finished =4,
        Reviewing= 5
    }
}