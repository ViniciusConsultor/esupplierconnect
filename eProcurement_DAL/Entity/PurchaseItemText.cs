//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Ma hongyu
// Created Date : 18/09/2009
// ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class contains field mapping to database table [puitxt].
//	  
// Revision History:
//    1.0:
//      Author  : Ma hongyu
//      Date    : 18/09/2009   
//      Comments: Created class 
//    
// Copyright 2008-2010 ISS/Fujitec
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    ///<summary>Entity Object (Purchase Item Text) - Database table [puitxt]</summary>
    [Serializable]
    public class PurchaseItemText
    {
        string orderNumber;
        ///<summary>Database mapping to column puitxt.EBELN</summary>
        public string OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        string itemSequence;
        ///<summary>Database mapping to column puitxt.EBELP</summary>
        public string ItemSequence
        {
            get { return itemSequence; }
            set { itemSequence = value; }
        }

        string textSequence;
        ///<summary>Database mapping to column puitxt.TXTITM</summary>
        public string TextSequence
        {
            get { return textSequence; }
            set { textSequence = value; }
        }

        string longText;
        ///<summary>Database mapping to column puitxt.LTXT</summary>
        public string LongText
        {
            get { return longText; }
            set { longText = value; }
        }

    }
}
