
//------------------------------------------------------------------------------
// 
//     This code was generated by a SAP. NET Connector Proxy Generator Version 2.0
//     Created at 31/12/2009
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
  /// Purchase Order Component Details - Work Area
  /// </summary>
  [RfcStructure(AbapName ="ZORDER_COMP" , Length = 87, Length2 = 168)]
  [Serializable]
  public class ZORDER_COMP : SAPStructure
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
    /// Delivery Schedule Line Counter
    /// </summary>
 
    [RfcField(AbapName = "COMPL", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 4, Length2 = 8, Offset = 15, Offset2 = 30)]
    [XmlElement("COMPL", Form=XmlSchemaForm.Unqualified)]
    public string Compl
    { 
       get
       {
          return _Compl;
       }
       set
       {
          _Compl = value;
       }
    }
    private string _Compl;


    /// <summary>
    /// Material Number
    /// </summary>
 
    [RfcField(AbapName = "MATNR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 18, Length2 = 36, Offset = 19, Offset2 = 38)]
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
    /// Material Description
    /// </summary>
 
    [RfcField(AbapName = "MAKTX", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Length2 = 80, Offset = 37, Offset2 = 74)]
    [XmlElement("MAKTX", Form=XmlSchemaForm.Unqualified)]
    public string Maktx
    { 
       get
       {
          return _Maktx;
       }
       set
       {
          _Maktx = value;
       }
    }
    private string _Maktx;


    /// <summary>
    /// Requirement Quantity
    /// </summary>
 
    [RfcField(AbapName = "BDMNG", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 3, Offset = 77, Offset2 = 154)]
    [XmlElement("BDMNG", Form=XmlSchemaForm.Unqualified)]
    public Decimal Bdmng
    { 
       get
       {
          return _Bdmng;
       }
       set
       {
          _Bdmng = value;
       }
    }
    private Decimal _Bdmng;


    /// <summary>
    /// Base Unit of Measure
    /// </summary>
 
    [RfcField(AbapName = "MEINS", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 3, Length2 = 6, Offset = 84, Offset2 = 162)]
    [XmlElement("MEINS", Form=XmlSchemaForm.Unqualified)]
    public string Meins
    { 
       get
       {
          return _Meins;
       }
       set
       {
          _Meins = value;
       }
    }
    private string _Meins;

  }

}
