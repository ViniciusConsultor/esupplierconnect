
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
  /// Material Requirement Details - Work Area
  /// </summary>
  [RfcStructure(AbapName ="ZMATL_REQUIRE" , Length = 40, Length2 = 74)]
  [Serializable]
  public class ZMATL_REQUIRE : SAPStructure
  {
   

    /// <summary>
    /// Material Number
    /// </summary>
 
    [RfcField(AbapName = "MATNR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 18, Length2 = 36, Offset = 0, Offset2 = 0)]
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
 
    [RfcField(AbapName = "WERKS", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Length2 = 8, Offset = 18, Offset2 = 36)]
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
    /// Requirement Quantity
    /// </summary>
 
    [RfcField(AbapName = "BDMNG", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 3, Offset = 22, Offset2 = 44)]
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
    /// Requirements Date for the Component
    /// </summary>
 
    [RfcField(AbapName = "BDTER", RfcType = RFCTYPE.RFCTYPE_DATE, Length = 8, Length2 = 16, Offset = 29, Offset2 = 52)]
    [XmlElement("BDTER", Form=XmlSchemaForm.Unqualified)]
    public string Bdter
    { 
       get
       {
          return _Bdter;
       }
       set
       {
          _Bdter = value;
       }
    }
    private string _Bdter;


    /// <summary>
    /// Base Unit of Measure
    /// </summary>
 
    [RfcField(AbapName = "MEINS", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 3, Length2 = 6, Offset = 37, Offset2 = 68)]
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
