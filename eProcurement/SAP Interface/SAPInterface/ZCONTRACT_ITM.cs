
//------------------------------------------------------------------------------
// 
//     This code was generated by a SAP. NET Connector Proxy Generator Version 2.0
//     Created at 11/08/2009
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
  /// Contract Item Details - Work Area
  /// </summary>
  [RfcStructure(AbapName ="ZCONTRACT_ITM" , Length = 144, Length2 = 266)]
  [Serializable]
  public class ZCONTRACT_ITM : SAPStructure
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
    /// Short text
    /// </summary>
 
    [RfcField(AbapName = "TXZ01", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Length2 = 80, Offset = 15, Offset2 = 30)]
    [XmlElement("TXZ01", Form=XmlSchemaForm.Unqualified)]
    public string Txz01
    { 
       get
       {
          return _Txz01;
       }
       set
       {
          _Txz01 = value;
       }
    }
    private string _Txz01;


    /// <summary>
    /// Material Number
    /// </summary>
 
    [RfcField(AbapName = "MATNR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 18, Length2 = 36, Offset = 55, Offset2 = 110)]
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
    /// Plant
    /// </summary>
 
    [RfcField(AbapName = "WERKS", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Length2 = 8, Offset = 73, Offset2 = 146)]
    [XmlElement("WERKS", Form=XmlSchemaForm.Unqualified)]
    public string Werks
    { 
       get
       {
          return _Werks;
       }
       set
       {
          _Werks = value;
       }
    }
    private string _Werks;


    /// <summary>
    /// Material Group
    /// </summary>
 
    [RfcField(AbapName = "MATKL", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 9, Length2 = 18, Offset = 77, Offset2 = 154)]
    [XmlElement("MATKL", Form=XmlSchemaForm.Unqualified)]
    public string Matkl
    { 
       get
       {
          return _Matkl;
       }
       set
       {
          _Matkl = value;
       }
    }
    private string _Matkl;


    /// <summary>
    /// Target quantity
    /// </summary>
 
    [RfcField(AbapName = "KTMNG", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 3, Offset = 86, Offset2 = 172)]
    [XmlElement("KTMNG", Form=XmlSchemaForm.Unqualified)]
    public Decimal Ktmng
    { 
       get
       {
          return _Ktmng;
       }
       set
       {
          _Ktmng = value;
       }
    }
    private Decimal _Ktmng;


    /// <summary>
    /// Base Unit of Measure
    /// </summary>
 
    [RfcField(AbapName = "MEINS", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 3, Length2 = 6, Offset = 93, Offset2 = 180)]
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


    /// <summary>
    /// Net price
    /// </summary>
 
    [RfcField(AbapName = "NETPR", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 6, Length2 = 6, Decimals = 2, Offset = 96, Offset2 = 186)]
    [XmlElement("NETPR", Form=XmlSchemaForm.Unqualified)]
    public Decimal Netpr
    { 
       get
       {
          return _Netpr;
       }
       set
       {
          _Netpr = value;
       }
    }
    private Decimal _Netpr;


    /// <summary>
    /// Price Unit
    /// </summary>
 
    [RfcField(AbapName = "PEINH", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 3, Length2 = 3, Offset = 102, Offset2 = 192)]
    [XmlElement("PEINH", Form=XmlSchemaForm.Unqualified)]
    public Decimal Peinh
    { 
       get
       {
          return _Peinh;
       }
       set
       {
          _Peinh = value;
       }
    }
    private Decimal _Peinh;


    /// <summary>
    /// Gross order value in PO currency
    /// </summary>
 
    [RfcField(AbapName = "BRTWR", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 2, Offset = 105, Offset2 = 195)]
    [XmlElement("BRTWR", Form=XmlSchemaForm.Unqualified)]
    public Decimal Brtwr
    { 
       get
       {
          return _Brtwr;
       }
       set
       {
          _Brtwr = value;
       }
    }
    private Decimal _Brtwr;


    /// <summary>
    /// RFQ number
    /// </summary>
 
    [RfcField(AbapName = "ANFNR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Length2 = 20, Offset = 112, Offset2 = 202)]
    [XmlElement("ANFNR", Form=XmlSchemaForm.Unqualified)]
    public string Anfnr
    { 
       get
       {
          return _Anfnr;
       }
       set
       {
          _Anfnr = value;
       }
    }
    private string _Anfnr;


    /// <summary>
    /// Purchase requisition number
    /// </summary>
 
    [RfcField(AbapName = "BANFN", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Length2 = 20, Offset = 122, Offset2 = 222)]
    [XmlElement("BANFN", Form=XmlSchemaForm.Unqualified)]
    public string Banfn
    { 
       get
       {
          return _Banfn;
       }
       set
       {
          _Banfn = value;
       }
    }
    private string _Banfn;


    /// <summary>
    /// Name of requisitioner/requester
    /// </summary>
 
    [RfcField(AbapName = "AFNAM", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 12, Length2 = 24, Offset = 132, Offset2 = 242)]
    [XmlElement("AFNAM", Form=XmlSchemaForm.Unqualified)]
    public string Afnam
    { 
       get
       {
          return _Afnam;
       }
       set
       {
          _Afnam = value;
       }
    }
    private string _Afnam;

  }

}
