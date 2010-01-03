
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
  /// Requisition Header - Work Area
  /// </summary>
  [RfcStructure(AbapName ="ZREQN_HDR" , Length = 52, Length2 = 104)]
  [Serializable]
  public class ZREQN_HDR : SAPStructure
  {
   

    /// <summary>
    /// Purchase requisition number
    /// </summary>
 
    [RfcField(AbapName = "BANFN", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Length2 = 20, Offset = 0, Offset2 = 0)]
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
    /// Order type (Purchasing)
    /// </summary>
 
    [RfcField(AbapName = "BSART", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Length2 = 8, Offset = 10, Offset2 = 20)]
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
    /// Purchasing document category
    /// </summary>
 
    [RfcField(AbapName = "BSTYP", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Length2 = 2, Offset = 14, Offset2 = 28)]
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
    /// Requisition (request) date
    /// </summary>
 
    [RfcField(AbapName = "BADAT", RfcType = RFCTYPE.RFCTYPE_DATE, Length = 8, Length2 = 16, Offset = 15, Offset2 = 30)]
    [XmlElement("BADAT", Form=XmlSchemaForm.Unqualified)]
    public string Badat
    { 
       get
       {
          return _Badat;
       }
       set
       {
          _Badat = value;
       }
    }
    private string _Badat;


    /// <summary>
    /// Processing status of purchase requisition
    /// </summary>
 
    [RfcField(AbapName = "STATU", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Length2 = 2, Offset = 23, Offset2 = 46)]
    [XmlElement("STATU", Form=XmlSchemaForm.Unqualified)]
    public string Statu
    { 
       get
       {
          return _Statu;
       }
       set
       {
          _Statu = value;
       }
    }
    private string _Statu;


    /// <summary>
    /// Release status
    /// </summary>
 
    [RfcField(AbapName = "FRGZU", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 8, Length2 = 16, Offset = 24, Offset2 = 48)]
    [XmlElement("FRGZU", Form=XmlSchemaForm.Unqualified)]
    public string Frgzu
    { 
       get
       {
          return _Frgzu;
       }
       set
       {
          _Frgzu = value;
       }
    }
    private string _Frgzu;


    /// <summary>
    /// Purchase requisition release date
    /// </summary>
 
    [RfcField(AbapName = "FRGDT", RfcType = RFCTYPE.RFCTYPE_DATE, Length = 8, Length2 = 16, Offset = 32, Offset2 = 64)]
    [XmlElement("FRGDT", Form=XmlSchemaForm.Unqualified)]
    public string Frgdt
    { 
       get
       {
          return _Frgdt;
       }
       set
       {
          _Frgdt = value;
       }
    }
    private string _Frgdt;


    /// <summary>
    /// Name of Person who Created the Object
    /// </summary>
 
    [RfcField(AbapName = "ERNAM", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 12, Length2 = 24, Offset = 40, Offset2 = 80)]
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

  }

}