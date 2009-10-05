using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class MaterialRequirement
    {
        string materialNumber;
        public string MaterialNumber
        {
            get { return materialNumber; }
            set { materialNumber = value; }
        }

        string plant;
        public string Plant
        {
            get { return plant; }
            set { plant = value; }
        }

        Nullable<long> requiredDate;
        public Nullable<long> RequiredDate
        {
            get { return requiredDate; }
            set { requiredDate = value; }
        }

        Nullable<decimal> requiredQuantity;
        public Nullable<decimal> RequiredQuantity
        {
            get { return requiredQuantity; }
            set { requiredQuantity = value; }
        }

        string unitOfMeasure;
        public string UnitOfMeasure
        {
            get { return unitOfMeasure; }
            set { unitOfMeasure = value; }
        }

    }
}
