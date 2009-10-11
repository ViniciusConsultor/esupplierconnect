//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Vinss, Rajendran Vinoth Prabu
// Created Date : 11 Oct 2009
// NUS ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class contains field mapping to database table [mtlstock].
//	  
// Revision History:
//    1.0:
//      Author  : Vinss
//      Date    : 11 Oct 2009
//      Comments: Created class 
//    
// Copyright 2008-2010 ISS/Fujitec
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    ///<summary>Entity Object (MaterialStock) - Database table [mtlstock]</summary>
    [Serializable]
    public class MaterialStock
    {
        ///<summary>Database mapping to column mtlstock.MATNR</summary>
        string materialNumber;
        public string MaterialNumber
        {
            get { return materialNumber; }
            set { materialNumber = value; }
        }

        ///<summary>Database mapping to column mtlstock.MAKTX</summary>
        string materialDescription;
        public string MaterialDescription
        {
            get { return materialDescription; }
            set { materialDescription = value; }
        }

        ///<summary>Database mapping to column mtlstock.WERKS</summary>
        string plant;
        public string Plant
        {
            get { return plant; }
            set { plant = value; }
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
