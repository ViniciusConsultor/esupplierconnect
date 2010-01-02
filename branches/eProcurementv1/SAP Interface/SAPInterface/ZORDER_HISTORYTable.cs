
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
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using SAP.Connector;

namespace SAPInterface
{
  /// <summary>
  /// A typed collection of ZORDER_HISTORY elements.
  /// </summary>
  [Serializable]
  public class ZORDER_HISTORYTable : SAPTable 
  {
  
    /// <summary>
    /// Returns the element type ZORDER_HISTORY.
    /// </summary>
    /// <returns>The type ZORDER_HISTORY.</returns>
    public override Type GetElementType() 
    {
        return (typeof(ZORDER_HISTORY));
    }

    /// <summary>
    /// Creates an empty new row of type ZORDER_HISTORY.
    /// </summary>
    /// <returns>The newZORDER_HISTORY.</returns>
    public override object CreateNewRow()
    { 
        return new ZORDER_HISTORY();
    }
     
    /// <summary>
    /// The indexer of the collection.
    /// </summary>
    public ZORDER_HISTORY this[int index] 
    {
        get 
        {
            return ((ZORDER_HISTORY)(List[index]));
        }
        set 
        {
            List[index] = value;
        }
    }
        
    /// <summary>
    /// Adds a ZORDER_HISTORY to the end of the collection.
    /// </summary>
    /// <param name="value">The ZORDER_HISTORY to be added to the end of the collection.</param>
    /// <returns>The index of the newZORDER_HISTORY.</returns>
    public int Add(ZORDER_HISTORY value) 
    {
        return List.Add(value);
    }
        
    /// <summary>
    /// Inserts a ZORDER_HISTORY into the collection at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which value should be inserted.</param>
    /// <param name="value">The ZORDER_HISTORY to insert.</param>
    public void Insert(int index, ZORDER_HISTORY value) 
    {
        List.Insert(index, value);
    }
        
    /// <summary>
    /// Searches for the specified ZORDER_HISTORY and returnes the zero-based index of the first occurrence in the collection.
    /// </summary>
    /// <param name="value">The ZORDER_HISTORY to locate in the collection.</param>
    /// <returns>The index of the object found or -1.</returns>
    public int IndexOf(ZORDER_HISTORY value) 
    {
        return List.IndexOf(value);
    }
        
    /// <summary>
    /// Determines wheter an element is in the collection.
    /// </summary>
    /// <param name="value">The ZORDER_HISTORY to locate in the collection.</param>
    /// <returns>True if found; else false.</returns>
    public bool Contains(ZORDER_HISTORY value) 
    {
        return List.Contains(value);
    }
        
    /// <summary>
    /// Removes the first occurrence of the specified ZORDER_HISTORY from the collection.
    /// </summary>
    /// <param name="value">The ZORDER_HISTORY to remove from the collection.</param>
    public void Remove(ZORDER_HISTORY value) 
    {
        List.Remove(value);
    }

    /// <summary>
    /// Copies the contents of the ZORDER_HISTORYTable to the specified one-dimensional array starting at the specified index in the target array.
    /// </summary>
    /// <param name="array">The one-dimensional destination array.</param>           
    /// <param name="index">The zero-based index in array at which copying begins.</param>           
    public void CopyTo(ZORDER_HISTORY[] array, int index) 
    {
        List.CopyTo(array, index);
	}
  }
}