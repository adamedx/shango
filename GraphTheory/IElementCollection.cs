using System;
using System.Collections;

namespace GraphTheory
{
	/// <summary>
	/// Summary description for IElementCollection.
	/// </summary>
	public interface IElementCollection : ICollection, IEnumerable
	{
        Element
            FindMatch(
            Element sourceElement );               
	}
}
