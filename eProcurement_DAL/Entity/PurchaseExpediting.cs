//------------------------------------------------------------------------------
// 
// Team         : Team 03
// Author       : Ma hongyu
// Created Date : 18/09/2009
// ISS M.TECH SE16 Batch
//
// Note: 
//    1. This class contains field mapping to database table [purexpedite].
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
    ///<summary>Entity Object (Purchase Expediting) - Database table [purexpedite]</summary>
    [Serializable]
    public class PurchaseExpediting
    {
        ///<summary>Database mapping to column purexpedite.EBELN</summary>
        string orderNumber;
        public string OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        string itemSequence;
        ///<summary>Database mapping to column purexpedite.EBELP</summary>
        public string ItemSequence
        {
            get { return itemSequence; }
            set { itemSequence = value; }
        }

        string scheduleSequence;
        ///<summary>Database mapping to column purexpedite.ETENR</summary>
        public string ScheduleSequence
        {
            get { return scheduleSequence; }
            set { scheduleSequence = value; }
        }

        string materialNumber;
        ///<summary>Database mapping to column purexpedite.MATNR</summary>
        public string MaterialNumber
        {
            get { return materialNumber; }
            set { materialNumber = value; }
        }

        ///<summary>Database mapping to column purexpedite.EXPDT</summary>
        Nullable<long> expeditDate;
        public Nullable<long> ExpeditDate
        {
            get { return expeditDate; }
            set { expeditDate = value; }
        }

        ///<summary>Database mapping to column purexpedite.WEMNG</summary>
        Nullable<decimal> expediteQuantity;
        public Nullable<decimal> ExpediteQuantity
        {
            get { return expediteQuantity; }
            set { expediteQuantity = value; }
        }

        ///<summary>Database mapping to column purexpedite.VBELN</summary>
        string unitMeasure;
        public string UnitMeasure
        {
            get { return unitMeasure; }
            set { unitMeasure = value; }
        }

        ///<summary>Database mapping to column purexpedite.PRMDT1</summary>
        Nullable<long> promiseDate1;
        public Nullable<long> PromiseDate1
        {
            get { return promiseDate1; }
            set { promiseDate1 = value; }
        }

        ///<summary>Database mapping to column purexpedite.PRMDT1</summary>
        Nullable<long> promiseDate2;
        public Nullable<long> PromiseDate2
        {
            get { return promiseDate2; }
            set { promiseDate2 = value; }
        }

        ///<summary>Database mapping to column purexpedite.RECSTS</summary>
        string recordStatus;
        public string RecordStatus
        {
            get { return recordStatus; }
            set { recordStatus = value; }
        }
    }
}
