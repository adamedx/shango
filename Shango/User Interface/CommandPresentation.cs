using System;

namespace Shango
{
	/// <summary>
	/// Summary description for CommandPresentation.
	/// </summary>
	public interface ICommandPresentation
	{
        string[]
        GetLines();   
     
        void
        SetText(
            string newText );
	}
}
