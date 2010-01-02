//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Ei Ei Thu
// Created Date : 19/09/2009
// ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class contains field mapping to database table [rejection].
//	  
// Revision History:
//    1.0:
//      Author  : Ei Ei Thu
//      Date    : 19/09/2009   
//      Comments: Created class 
//    
// Copyright 2008-2010 ISS/Fujitec
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    ///<summary>Entity Object (Purchase Item Text) - Database table [rejection]</summary>
    [Serializable]
    public class RejectedGood
    {
        ///<summary>Database mapping to column rejection.EBELN</summary>
        string orderNumber;
        public string OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }
        ///<summary>Database mapping to column rejection.EBELP</summary>
        string itemSequence;
        public string ItemSequence
        {
            get { return itemSequence; }
            set { itemSequence = value; }
        }
        ///<summary>Database mapping to column rejection.DOCNO</summary>
        string documentNumber;
        public string DocumentNumber
        {
            get { return documentNumber; }
            set { documentNumber = value; }
        }
        ///<summary>Database mapping to column rejection.ITEMNO</summary>
        string documentSerial;
        public string DocumentSerial
        {
            get { return documentSerial; }
            set { documentSerial = value; }
        }
        ///<summary>Database mapping to column rejection.MATNR</summary>
        string materialNumber;
        public string MaterialNumber
        {
            get { return materialNumber; }
            set { materialNumber = value; }
        }
        //<summary>Database mapping to column rejection.TRNQTY</summary>
        Nullable<decimal> rejectQuantity;
        public Nullable<decimal> RejectQuantity
        {
            get { return rejectQuantity; }
            set { rejectQuantity = value; }
        }
        ///<summary>Database mapping to column rejection.MEINS</summary>
        string unitofMeasure;
        public string UnitofMeasure
        {
            get { return unitofMeasure; }
            set { unitofMeasure = value; }
        }
        ///<summary>Database mapping to column rejection.REFNO</summary>
        string referenceNumber;
        public string ReferenceNumber
        {
            get { return referenceNumber; }
            set { referenceNumber = value; }
        }
        ///<summary>Database mapping to column rejection.AEDAT</summary>
        Nullable<long> rejectDate;
        public Nullable<long> RejectDate
        {
            get { return rejectDate; }
            set { rejectDate = value; }
        }
        ///<summary>Database mapping to column rejection.ACKSTS</summary>
        string acknowledgeStatus;
        public string AcknowledgeStatus
        {
            get { return acknowledgeStatus; }
            set { acknowledgeStatus = value; }
        }


        
    }
}
