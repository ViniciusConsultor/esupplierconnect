
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
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using SAP.Connector;

namespace SAPInterface
{
  /// <summary>
  /// A typed collection of ZORDER_COMP elements.
  /// </summary>
  [Serializable]
  public class ZORDER_COMPTable : SAPTable 
  {
  
    /// <summary>
    /// Returns the element type ZORDER_COMP.
    /// </summary>
    /// <returns>The type ZORDER_COMP.</returns>
    public override Type GetElementType() 
    {
        return (typeof(ZORDER_COMP));
    }

    /// <summary>
    /// Creates an empty new row of type ZORDER_COMP.
    /// </summary>
    /// <returns>The newZORDER_COMP.</returns>
    public override object CreateNewRow()
    { 
        return new ZORDER_COMP();
    }
     
    /// <summary>
    /// The indexer of the collection.
    /// </summary>
    public ZORDER_COMP this[int index] 
    {
        get 
        {
            return ((ZORDER_COMP)(List[index]));
        }
        set 
        {
            List[index] = value;
        }
    }
        
    /// <summary>
    /// Adds a ZORDER_COMP to the end of the collection.
    /// </summary>
    /// <param name="value">The ZORDER_COMP to be added to the end of the collection.</param>
    /// <returns>The index of the newZORDER_COMP.</returns>
    public int Add(ZORDER_COMP value) 
    {
        return List.Add(value);
    }
        
    /// <summary>
    /// Inserts a ZORDER_COMP into the collection at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which value should be inserted.</param>
    /// <param name="value">The ZORDER_COMP to insert.</param>
    public void Insert(int index, ZORDER_COMP value) 
    {
        List.Insert(index, value);
    }
        
    /// <summary>
    /// Searches for the specified ZORDER_COMP and returnes the zero-based index of the first occurrence in the collection.
    /// </summary>
    /// <param name="value">The ZORDER_COMP to locate in the collection.</param>
    /// <returns>The index of the object found or -1.</returns>
    public int IndexOf(ZORDER_COMP value) 
    {
        return List.IndexOf(value);
    }
        
    /// <summary>
    /// Determines wheter an element is in the collection.
    /// </summary>
    /// <param name="value">The ZORDER_COMP to locate in the collection.</param>
    /// <returns>True if found; else false.</returns>
    public bool Contains(ZORDER_COMP value) 
    {
        return List.Contains(value);
    }
        
    /// <summary>
    /// Removes the first occurrence of the specified ZORDER_COMP from the collection.
    /// </summary>
    /// <param name="value">The ZORDER_COMP to remove from the collection.</param>
    public void Remove(ZORDER_COMP value) 
    {
        List.Remove(value);
    }

    /// <summary>
    /// Copies the contents of the ZORDER_COMPTable to the specified one-dimensional array starting at the specified index in the target array.
    /// </summary>
    /// <param name="array">The one-dimensional destination array.</param>           
    /// <param name="index">The zero-based index in array at which copying begins.</param>           
    public void CopyTo(ZORDER_COMP[] array, int index) 
    {
        List.CopyTo(array, index);
	}
  }
}
