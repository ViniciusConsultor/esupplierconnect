using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using eProcurement_DAL;

namespace eProcurement_BLL
{
    [Serializable]
    public class ShortageMaterialVO:ShortageMaterial 
    {
        ///<summary>Database mapping to column mtlstock.MAKTX</summary>
        string materialDescription;
        public string MaterialDescription
        {
            get { return materialDescription; }
            set { materialDescription = value; }
        }

        ///<summary>Database mapping to column mtlstock.LABST</summary>
        Nullable<decimal> unrestrictedStock;
        public Nullable<decimal> UnrestrictedStock
        {
            get { return unrestrictedStock; }
            set { unrestrictedStock = value; }
        }

        ///<summary>Database mapping to column mtlstock.QINSP</summary>
        Nullable<decimal> inspectionStock;
        public Nullable<decimal> InspectionStock
        {
            get { return inspectionStock; }
            set { inspectionStock = value; }
        }

        ///<summary>Database mapping to column mtlstock.MEINS</summary>
        string unitOfMeasure;
        public string UnitOfMeasure
        {
            get { return unitOfMeasure; }
            set { unitOfMeasure = value; }
        }
    }
}
