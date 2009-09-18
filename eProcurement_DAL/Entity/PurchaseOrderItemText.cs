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
    ///<summary>Entity Object - Database table [puitxt]</summary>
    [Serializable]
    public class PurchaseOrderItemText
    {
        string orderNumber;
        ///<summary>Database mapping to column puitxt.EBELN</summary>
        public string OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        string itemSequenceNumber;
        ///<summary>Database mapping to column puitxt.EBELP</summary>
        public string ItemSequenceNumber
        {
            get { return itemSequenceNumber; }
            set { itemSequenceNumber = value; }
        }

        string textSerialNumber;
        ///<summary>Database mapping to column puitxt.TXTITM</summary>
        public string TextSerialNumber
        {
            get { return textSerialNumber; }
            set { textSerialNumber = value; }
        }

        string longText;
        ///<summary>Database mapping to column puitxt.LTXT</summary>
        public string LongText
        {
            get { return longText; }
            set { longText = value; }
        }

        string recordStatus;
        ///<summary>Database mapping to column puitxt.RECSTS</summary>
        public string RecordStatus
        {
            get { return recordStatus; }
            set { recordStatus = value; }
        }
    }
}
