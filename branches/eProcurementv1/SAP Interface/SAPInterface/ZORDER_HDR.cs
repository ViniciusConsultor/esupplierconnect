
//------------------------------------------------------------------------------
// 
//     This code was generated by a SAP. NET Connector Proxy Generator Version 2.0
//     Created at 04/01/2010
//     Created from Windows
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// 
//------------------------------------------------------------------------------
using System;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using SAP.Connector;

namespace SAPInterface
{

  /// <summary>
  /// Purchase Order Header Details - Work Area
  /// </summary>
  [RfcStructure(AbapName ="ZORDER_HDR" , Length = 340, Length2 = 662)]
  [Serializable]
  public class ZORDER_HDR : SAPStructure
  {
   

    /// <summary>
    /// Purchasing Document Number
    /// </summary>
 
    [RfcField(AbapName = "EBELN", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Length2 = 20, Offset = 0, Offset2 = 0)]
    [XmlElement("EBELN", Form=XmlSchemaForm.Unqualified)]
    public string Ebeln
    { 
       get
       {
          return _Ebeln;
       }
       set
       {
          _Ebeln = value;
       }
    }
    private string _Ebeln;


    /// <summary>
    /// Purchase Order Date
    /// </summary>
 
    [RfcField(AbapName = "BEDAT", RfcType = RFCTYPE.RFCTYPE_DATE, Length = 8, Length2 = 16, Offset = 10, Offset2 = 20)]
    [XmlElement("BEDAT", Form=XmlSchemaForm.Unqualified)]
    public string Bedat
    { 
       get
       {
          return _Bedat;
       }
       set
       {
          _Bedat = value;
       }
    }
    private string _Bedat;


    /// <summary>
    /// Purchasing document category
    /// </summary>
 
    [RfcField(AbapName = "BSTYP", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Length2 = 2, Offset = 18, Offset2 = 36)]
    [XmlElement("BSTYP", Form=XmlSchemaForm.Unqualified)]
    public string Bstyp
    { 
       get
       {
          return _Bstyp;
       }
       set
       {
          _Bstyp = value;
       }
    }
    private string _Bstyp;


    /// <summary>
    /// Order type (Purchasing)
    /// </summary>
 
    [RfcField(AbapName = "BSART", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Length2 = 8, Offset = 19, Offset2 = 38)]
    [XmlElement("BSART", Form=XmlSchemaForm.Unqualified)]
    public string Bsart
    { 
       get
       {
          return _Bsart;
       }
       set
       {
          _Bsart = value;
       }
    }
    private string _Bsart;


    /// <summary>
    /// Name of Person who Created the Object
    /// </summary>
 
    [RfcField(AbapName = "ERNAM", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 12, Length2 = 24, Offset = 23, Offset2 = 46)]
    [XmlElement("ERNAM", Form=XmlSchemaForm.Unqualified)]
    public string Ernam
    { 
       get
       {
          return _Ernam;
       }
       set
       {
          _Ernam = value;
       }
    }
    private string _Ernam;


    /// <summary>
    /// Fax Number
    /// </summary>
 
    [RfcField(AbapName = "BUYER", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 31, Length2 = 62, Offset = 35, Offset2 = 70)]
    [XmlElement("BUYER", Form=XmlSchemaForm.Unqualified)]
    public string Buyer
    { 
       get
       {
          return _Buyer;
       }
       set
       {
          _Buyer = value;
       }
    }
    private string _Buyer;


    /// <summary>
    /// Telephone number of purchasing group (buyer group)
    /// </summary>
 
    [RfcField(AbapName = "PHONE", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 12, Length2 = 24, Offset = 66, Offset2 = 132)]
    [XmlElement("PHONE", Form=XmlSchemaForm.Unqualified)]
    public string Phone
    { 
       get
       {
          return _Phone;
       }
       set
       {
          _Phone = value;
       }
    }
    private string _Phone;


    /// <summary>
    /// Account Number of Vendor or Creditor
    /// </summary>
 
    [RfcField(AbapName = "LIFNR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Length2 = 20, Offset = 78, Offset2 = 156)]
    [XmlElement("LIFNR", Form=XmlSchemaForm.Unqualified)]
    public string Lifnr
    { 
       get
       {
          return _Lifnr;
       }
       set
       {
          _Lifnr = value;
       }
    }
    private string _Lifnr;


    /// <summary>
    /// Terms of payment key
    /// </summary>
 
    [RfcField(AbapName = "ZTERM", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Length2 = 8, Offset = 88, Offset2 = 176)]
    [XmlElement("ZTERM", Form=XmlSchemaForm.Unqualified)]
    public string Zterm
    { 
       get
       {
          return _Zterm;
       }
       set
       {
          _Zterm = value;
       }
    }
    private string _Zterm;


    /// <summary>
    /// Purchasing Group
    /// </summary>
 
    [RfcField(AbapName = "EKGRP", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 3, Length2 = 6, Offset = 92, Offset2 = 184)]
    [XmlElement("EKGRP", Form=XmlSchemaForm.Unqualified)]
    public string Ekgrp
    { 
       get
       {
          return _Ekgrp;
       }
       set
       {
          _Ekgrp = value;
       }
    }
    private string _Ekgrp;


    /// <summary>
    /// Purchasing Organization
    /// </summary>
 
    [RfcField(AbapName = "EKORG", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Length2 = 8, Offset = 95, Offset2 = 190)]
    [XmlElement("EKORG", Form=XmlSchemaForm.Unqualified)]
    public string Ekorg
    { 
       get
       {
          return _Ekorg;
       }
       set
       {
          _Ekorg = value;
       }
    }
    private string _Ekorg;


    /// <summary>
    /// Currency Key
    /// </summary>
 
    [RfcField(AbapName = "WAERS", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 5, Length2 = 10, Offset = 99, Offset2 = 198)]
    [XmlElement("WAERS", Form=XmlSchemaForm.Unqualified)]
    public string Waers
    { 
       get
       {
          return _Waers;
       }
       set
       {
          _Waers = value;
       }
    }
    private string _Waers;


    /// <summary>
    /// Exchange rate
    /// </summary>
 
    [RfcField(AbapName = "WKURS", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 5, Length2 = 5, Decimals = 5, Offset = 104, Offset2 = 208)]
    [XmlElement("WKURS", Form=XmlSchemaForm.Unqualified)]
    public Decimal Wkurs
    { 
       get
       {
          return _Wkurs;
       }
       set
       {
          _Wkurs = value;
       }
    }
    private Decimal _Wkurs;


    /// <summary>
    /// Salesperson responsible in the event of queries
    /// </summary>
 
    [RfcField(AbapName = "VERKF", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 30, Length2 = 60, Offset = 109, Offset2 = 214)]
    [XmlElement("VERKF", Form=XmlSchemaForm.Unqualified)]
    public string Verkf
    { 
       get
       {
          return _Verkf;
       }
       set
       {
          _Verkf = value;
       }
    }
    private string _Verkf;


    /// <summary>
    /// First telephone number
    /// </summary>
 
    [RfcField(AbapName = "TELF1", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 16, Length2 = 32, Offset = 139, Offset2 = 274)]
    [XmlElement("TELF1", Form=XmlSchemaForm.Unqualified)]
    public string Telf1
    { 
       get
       {
          return _Telf1;
       }
       set
       {
          _Telf1 = value;
       }
    }
    private string _Telf1;


    /// <summary>
    /// Gross order value in PO currency
    /// </summary>
 
    [RfcField(AbapName = "AMTPR", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 2, Offset = 155, Offset2 = 306)]
    [XmlElement("AMTPR", Form=XmlSchemaForm.Unqualified)]
    public Decimal Amtpr
    { 
       get
       {
          return _Amtpr;
       }
       set
       {
          _Amtpr = value;
       }
    }
    private Decimal _Amtpr;


    /// <summary>
    /// Net order value in PO currency
    /// </summary>
 
    [RfcField(AbapName = "GSTAM", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 2, Offset = 162, Offset2 = 313)]
    [XmlElement("GSTAM", Form=XmlSchemaForm.Unqualified)]
    public Decimal Gstam
    { 
       get
       {
          return _Gstam;
       }
       set
       {
          _Gstam = value;
       }
    }
    private Decimal _Gstam;


    /// <summary>
    /// Full details of address
    /// </summary>
 
    [RfcField(AbapName = "LADDR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 80, Length2 = 160, Offset = 169, Offset2 = 320)]
    [XmlElement("LADDR", Form=XmlSchemaForm.Unqualified)]
    public string Laddr
    { 
       get
       {
          return _Laddr;
       }
       set
       {
          _Laddr = value;
       }
    }
    private string _Laddr;


    /// <summary>
    /// Telephone no.: dialling code+number
    /// </summary>
 
    [RfcField(AbapName = "ADNBR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 30, Length2 = 60, Offset = 249, Offset2 = 480)]
    [XmlElement("ADNBR", Form=XmlSchemaForm.Unqualified)]
    public string Adnbr
    { 
       get
       {
          return _Adnbr;
       }
       set
       {
          _Adnbr = value;
       }
    }
    private string _Adnbr;


    /// <summary>
    /// Note text
    /// </summary>
 
    [RfcField(AbapName = "TXT01", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 60, Length2 = 120, Offset = 279, Offset2 = 540)]
    [XmlElement("TXT01", Form=XmlSchemaForm.Unqualified)]
    public string Txt01
    { 
       get
       {
          return _Txt01;
       }
       set
       {
          _Txt01 = value;
       }
    }
    private string _Txt01;


    /// <summary>
    /// Asset class marked for deletion
    /// </summary>
 
    [RfcField(AbapName = "LOEKZ", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Length2 = 2, Offset = 339, Offset2 = 660)]
    [XmlElement("LOEKZ", Form=XmlSchemaForm.Unqualified)]
    public string Loekz
    { 
       get
       {
          return _Loekz;
       }
       set
       {
          _Loekz = value;
       }
    }
    private string _Loekz;

  }

}
