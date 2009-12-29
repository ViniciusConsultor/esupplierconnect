using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using eProcurement_DAL;

namespace eProcurement_BLL
{
    [Serializable]
    public class PurchaseExpeditingVO : PurchaseExpediting
    {
        Nullable<long> orderItemScheduleDate;
        public Nullable<long> OrderItemScheduleDate
        {
            get { return orderItemScheduleDate; }
            set { orderItemScheduleDate = value; }
        }

        Nullable<decimal> deliveryScheduleQuantity;
        public Nullable<decimal> DeliveryScheduleQuantity
        {
            get { return deliveryScheduleQuantity; }
            set { deliveryScheduleQuantity = value; }
        }
    }
}
