﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderEntity
{
    public enum OrderPaymentStatus
    {
        Pending =0,
        PaymentReceived=1,
        PaymentFailed=2

    }
}
