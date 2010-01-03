
//------------------------------------------------------------------------------
// 
//     This code was generated by a SAP. NET Connector Proxy Generator Version 2.0
//     Created at 01/01/2010
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
  /// A typed collection of ZMATL_STOCK elements.
  /// </summary>
  [Serializable]
  public class ZMATL_STOCKTable : SAPTable 
  {
  
    /// <summary>
    /// Returns the element type ZMATL_STOCK.
    /// </summary>
    /// <returns>The type ZMATL_STOCK.</returns>
    public override Type GetElementType() 
    {
        return (typeof(ZMATL_STOCK));
    }

    /// <summary>
    /// Creates an empty new row of type ZMATL_STOCK.
    /// </summary>
    /// <returns>The newZMATL_STOCK.</returns>
    public override object CreateNewRow()
    { 
        return new ZMATL_STOCK();
    }
     
    /// <summary>
    /// The indexer of the collection.
    /// </summary>
    public ZMATL_STOCK this[int index] 
    {
        get 
        {
            return ((ZMATL_STOCK)(List[index]));
        }
        set 
        {
            List[index] = value;
        }
    }
        
    /// <summary>
    /// Adds a ZMATL_STOCK to the end of the collection.
    /// </summary>
    /// <param name="value">The ZMATL_STOCK to be added to the end of the collection.</param>
    /// <returns>The index of the newZMATL_STOCK.</returns>
    public int Add(ZMATL_STOCK value) 
    {
        return List.Add(value);
    }
        
    /// <summary>
    /// Inserts a ZMATL_STOCK into the collection at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which value should be inserted.</param>
    /// <param name="value">The ZMATL_STOCK to insert.</param>
    public void Insert(int index, ZMATL_STOCK value) 
    {
        List.Insert(index, value);
    }
        
    /// <summary>
    /// Searches for the specified ZMATL_STOCK and returnes the zero-based index of the first occurrence in the collection.
    /// </summary>
    /// <param name="value">The ZMATL_STOCK to locate in the collection.</param>
    /// <returns>The index of the object found or -1.</returns>
    public int IndexOf(ZMATL_STOCK value) 
    {
        return List.IndexOf(value);
    }
        
    /// <summary>
    /// Determines wheter an element is in the collection.
    /// </summary>
    /// <param name="value">The ZMATL_STOCK to locate in the collection.</param>
    /// <returns>True if found; else false.</returns>
    public bool Contains(ZMATL_STOCK value) 
    {
        return List.Contains(value);
    }
        
    /// <summary>
    /// Removes the first occurrence of the specified ZMATL_STOCK from the collection.
    /// </summary>
    /// <param name="value">The ZMATL_STOCK to remove from the collection.</param>
    public void Remove(ZMATL_STOCK value) 
    {
        List.Remove(value);
    }

    /// <summary>
    /// Copies the contents of the ZMATL_STOCKTable to the specified one-dimensional array starting at the specified index in the target array.
    /// </summary>
    /// <param name="array">The one-dimensional destination array.</param>           
    /// <param name="index">The zero-based index in array at which copying begins.</param>           
    public void CopyTo(ZMATL_STOCK[] array, int index) 
    {
        List.CopyTo(array, index);
	}
  }
}