//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Vinss, Rajendran Vinoth Prabu
// Created Date : 11 Oct 2009
// NUS ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class contains field mapping to database table [MTLSHORTAGE].
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
     ///<summary>Entity Object (MaterialStock) - Database table [MTLSTOCK]</summary>
    [Serializable]
    public class ShortageMaterial
    {
        ///<summary>Database mapping to column MTLSHORTAGE.MATNR</summary>
        string materialNumber;
        public string MaterialNumber
        {
            get { return materialNumber; }
            set { materialNumber = value; }
        }

        ///<summary>Database mapping to column MTLSHORTAGE.WERKS</summary>
        string plant;
        public string Plant
        {
            get { return plant; }
            set { plant = value; }
        }

        ///<summary>Database mapping to column MTLSHORTAGE.MENGE</summary>
        Nullable<decimal> shortageQuantity;
        public Nullable<decimal> ShortageQuantity
        {
            get { return shortageQuantity; }
            set { shortageQuantity = value; }
        }
    }
}
