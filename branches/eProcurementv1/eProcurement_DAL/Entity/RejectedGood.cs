//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Vinss, Rajendran Vinoth Prabu
// Created Date : 11 Oct 2009
// NUS ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class contains field mapping to database table [notification].
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
    ///<summary>Entity Object (RejectedGood) - Database table [REJECTION]</summary>
    [Serializable]
    class RejectedGood
    {

        ///<summary>Database mapping to column REJECTION.EBELN</summary>
        string orderNo;
        public string OrderNo
        {
            get { return orderNo; }
            set { orderNo = value; }
        }

        ///<summary>Database mapping to column REJECTION.EBELP</summary>
        string itemSequence;
        public string ItemSequence
        {
            get { return itemSequence; }
            set { itemSequence = value; }
        }

        ///<summary>Database mapping to column REJECTION.DOCNO</summary>
        string documentNumber;
        public string DocumentNumber
        {
            get { return documentNumber; }
            set { documentNumber = value; }
        }

        ///<summary>Database mapping to column REJECTION.ITEMNO</summary>
        string documentSerial;
        public string DocumentSerial
        {
            get { return documentSerial; }
            set { documentSerial = value; }
        }

        ///<summary>Database mapping to column REJECTION.MATNR</summary>
        string materialNumber;
        public string MaterialNumber
        {
            get { return materialNumber; }
            set { materialNumber = value; }
        }

        ///<summary>Database mapping to column REJECTION.TRNQTY</summary>
        decimal rejectQuantity;
        public decimal RejectQuantity
        {
            get { return rejectQuantity; }
            set { rejectQuantity = value; }
        }


        ///<summary>Database mapping to column REJECTION.MEINS</summary>
        string unitOfMeasure;
        public string UnitOfMeasure
        {
            get { return unitOfMeasure; }
            set { unitOfMeasure = value; }
        }

        ///<summary>Database mapping to column REJECTION.REFNO</summary>
        string referenceNumber;
        public string ReferenceNumber
        {
            get { return referenceNumber; }
            set { referenceNumber = value; }
        }

        ///<summary>Database mapping to column REJECTION.AEDAT</summary>
        long rejectDate;
        public long RejectDate
        {
            get { return rejectDate; }
            set { rejectDate = value; }
        }

        ///<summary>Database mapping to column REJECTION.ACKSTS</summary>
        string acknowledgeStatus;
        public string AcknowledgeStatus
        {
            get { return acknowledgeStatus; }
            set { acknowledgeStatus = value; }
        }

        


    }
}
