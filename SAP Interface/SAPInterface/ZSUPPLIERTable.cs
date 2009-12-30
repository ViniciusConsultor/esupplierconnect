
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
  /// A typed collection of ZSUPPLIER elements.
  /// </summary>
  [Serializable]
  public class ZSUPPLIERTable : SAPTable 
  {
  
    /// <summary>
    /// Returns the element type ZSUPPLIER.
    /// </summary>
    /// <returns>The type ZSUPPLIER.</returns>
    public override Type GetElementType() 
    {
        return (typeof(ZSUPPLIER));
    }

    /// <summary>
    /// Creates an empty new row of type ZSUPPLIER.
    /// </summary>
    /// <returns>The newZSUPPLIER.</returns>
    public override object CreateNewRow()
    { 
        return new ZSUPPLIER();
    }
     
    /// <summary>
    /// The indexer of the collection.
    /// </summary>
    public ZSUPPLIER this[int index] 
    {
        get 
        {
            return ((ZSUPPLIER)(List[index]));
        }
        set 
        {
            List[index] = value;
        }
    }
        
    /// <summary>
    /// Adds a ZSUPPLIER to the end of the collection.
    /// </summary>
    /// <param name="value">The ZSUPPLIER to be added to the end of the collection.</param>
    /// <returns>The index of the newZSUPPLIER.</returns>
    public int Add(ZSUPPLIER value) 
    {
        return List.Add(value);
    }
        
    /// <summary>
    /// Inserts a ZSUPPLIER into the collection at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which value should be inserted.</param>
    /// <param name="value">The ZSUPPLIER to insert.</param>
    public void Insert(int index, ZSUPPLIER value) 
    {
        List.Insert(index, value);
    }
        
    /// <summary>
    /// Searches for the specified ZSUPPLIER and returnes the zero-based index of the first occurrence in the collection.
    /// </summary>
    /// <param name="value">The ZSUPPLIER to locate in the collection.</param>
    /// <returns>The index of the object found or -1.</returns>
    public int IndexOf(ZSUPPLIER value) 
    {
        return List.IndexOf(value);
    }
        
    /// <summary>
    /// Determines wheter an element is in the collection.
    /// </summary>
    /// <param name="value">The ZSUPPLIER to locate in the collection.</param>
    /// <returns>True if found; else false.</returns>
    public bool Contains(ZSUPPLIER value) 
    {
        return List.Contains(value);
    }
        
    /// <summary>
    /// Removes the first occurrence of the specified ZSUPPLIER from the collection.
    /// </summary>
    /// <param name="value">The ZSUPPLIER to remove from the collection.</param>
    public void Remove(ZSUPPLIER value) 
    {
        List.Remove(value);
    }

    /// <summary>
    /// Copies the contents of the ZSUPPLIERTable to the specified one-dimensional array starting at the specified index in the target array.
    /// </summary>
    /// <param name="array">The one-dimensional destination array.</param>           
    /// <param name="index">The zero-based index in array at which copying begins.</param>           
    public void CopyTo(ZSUPPLIER[] array, int index) 
    {
        List.CopyTo(array, index);
	}
  }
}
