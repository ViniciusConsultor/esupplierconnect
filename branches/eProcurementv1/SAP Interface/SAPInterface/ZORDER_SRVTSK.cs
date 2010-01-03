
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
  /// Purchase Order Service Item Task Details - Work Area
  /// </summary>
  [RfcStructure(AbapName ="ZORDER_SRVTSK" , Length = 94, Length2 = 176)]
  [Serializable]
  public class ZORDER_SRVTSK : SAPStructure
  {
   

    /// <summary>
    /// Entry sheet number
    /// </summary>
 
    [RfcField(AbapName = "LBLNI", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Length2 = 20, Offset = 0, Offset2 = 0)]
    [XmlElement("LBLNI", Form=XmlSchemaForm.Unqualified)]
    public string Lblni
    { 
       get
       {
          return _Lblni;
       }
       set
       {
          _Lblni = value;
       }
    }
    private string _Lblni;


    /// <summary>
    /// Line number
    /// </summary>
 
    [RfcField(AbapName = "EXTROW", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 10, Length2 = 20, Offset = 10, Offset2 = 20)]
    [XmlElement("EXTROW", Form=XmlSchemaForm.Unqualified)]
    public string Extrow
    { 
       get
       {
          return _Extrow;
       }
       set
       {
          _Extrow = value;
       }
    }
    private string _Extrow;


    /// <summary>
    /// Service number
    /// </summary>
 
    [RfcField(AbapName = "SRVPOS", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 18, Length2 = 36, Offset = 20, Offset2 = 40)]
    [XmlElement("SRVPOS", Form=XmlSchemaForm.Unqualified)]
    public string Srvpos
    { 
       get
       {
          return _Srvpos;
       }
       set
       {
          _Srvpos = value;
       }
    }
    private string _Srvpos;


    /// <summary>
    /// Purchase order quantity
    /// </summary>
 
    [RfcField(AbapName = "MENGEV", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Length2 = 7, Decimals = 3, Offset = 38, Offset2 = 76)]
    [XmlElement("MENGEV", Form=XmlSchemaForm.Unqualified)]
    public Decimal Mengev
    { 
       get
       {
          return _Mengev;
       }
       set
       {
          _Mengev = value;
       }
    }
    private Decimal _Mengev;


    /// <summary>
    /// Base Unit of Measure
    /// </summary>
 
    [RfcField(AbapName = "MEINS", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 3, Length2 = 6, Offset = 45, Offset2 = 84)]
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
    /// Net Value of the Item
    /// </summary>
 
    [RfcField(AbapName = "SBRTWR", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 6, Length2 = 6, Decimals = 2, Offset = 48, Offset2 = 90)]
    [XmlElement("SBRTWR", Form=XmlSchemaForm.Unqualified)]
    public Decimal Sbrtwr
    { 
       get
       {
          return _Sbrtwr;
       }
       set
       {
          _Sbrtwr = value;
       }
    }
    private Decimal _Sbrtwr;


    /// <summary>
    /// Short text 1
    /// </summary>
 
    [RfcField(AbapName = "KTEXT1", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Length2 = 80, Offset = 54, Offset2 = 96)]
    [XmlElement("KTEXT1", Form=XmlSchemaForm.Unqualified)]
    public string Ktext1
    { 
       get
       {
          return _Ktext1;
       }
       set
       {
          _Ktext1 = value;
       }
    }
    private string _Ktext1;

  }

}