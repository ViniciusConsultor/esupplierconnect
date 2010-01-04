
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
  /// Purchase Order Schedule Details - Work Area
  /// </summary>
  [RfcStructure(AbapName ="ZORDER_SCH" , Length = 67, Length2 = 122)]
  [Serializable]
  public class ZORDER_SCH : SAPStructure
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
    /// Item Number of Purchasing Document
    /// </summary>
 
    [RfcField(AbapName = "EBELP", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 5, Length2 = 10, Offset = 10, Offset2 = 20)]
    [XmlElement("EBELP", Form=XmlSchemaForm.Unqualified)]
    public string Ebelp
    { 
       get
       {
          return _Ebelp;
       }
       set
       {
          _Ebelp = value;
       }
    }
    private string _Ebelp;


    /// <summary>
    /// Material Number
    /// </summary>
 
    [RfcField(AbapName = "MATNR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 18, Length2 = 36, Offset = 15, Offset2 = 30)]
    [XmlElement("MATNR", Form=XmlSchemaForm.Unqualified)]
    public string Matnr
    { 
       get
       {
          return _Matnr;
       }
       set
       {
          _Matnr = value;
       }
    }
    private string _Matnr;


    /// <summary>
    /// Schedule line
    /// </summary>
 
    [RfcField(AbapName = "ETENR", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 4, Length2 = 8, Offset = 33, Offset2 = 66)]
    [XmlElement("ETENR", Form=XmlSchemaForm.Unqualified)]
    public string Etenr
    { 
       get
       {
          return _Etenr;
       }
       set
       {
          _Etenr = value;
       }
    }
    private string _Etenr;


    /// <summary>
    /// Statistics-relevant delivery date
    /// </summary>
 
    [RfcField(AbapName = "SLFDT", RfcType = RFCTYPE.RFCTYPE_DATE, Length = 8, Length2 = 16, Offset = 37, Offset2 = 74)]
    [XmlElement("SLFDT", Form=XmlSchemaForm.Unqualified)]
    public string Slfdt
    { 
       get
       {
          return _Slfdt;
       }
       set
       {
          _Slfdt = value;
       }
    }
    private string _Slfdt;


    /// <summary>
    /// Purchase order quantity
    /// </summary>
 
    [RfcField(AbapName = "MENGE", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 3, Offset = 45, Offset2 = 90)]
    [XmlElement("MENGE", Form=XmlSchemaForm.Unqualified)]
    public Decimal Menge
    { 
       get
       {
          return _Menge;
       }
       set
       {
          _Menge = value;
       }
    }
    private Decimal _Menge;


    /// <summary>
    /// Item delivery date
    /// </summary>
 
    [RfcField(AbapName = "EINDT", RfcType = RFCTYPE.RFCTYPE_DATE, Length = 8, Length2 = 16, Offset = 52, Offset2 = 98)]
    [XmlElement("EINDT", Form=XmlSchemaForm.Unqualified)]
    public string Eindt
    { 
       get
       {
          return _Eindt;
       }
       set
       {
          _Eindt = value;
       }
    }
    private string _Eindt;


    /// <summary>
    /// Quantity of goods received
    /// </summary>
 
    [RfcField(AbapName = "WEMNG", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 3, Offset = 60, Offset2 = 114)]
    [XmlElement("WEMNG", Form=XmlSchemaForm.Unqualified)]
    public Decimal Wemng
    { 
       get
       {
          return _Wemng;
       }
       set
       {
          _Wemng = value;
       }
    }
    private Decimal _Wemng;

  }

}
