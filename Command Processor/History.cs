using System;

namespace Shango
{
    using System.Collections;

	/// <summary>
	/// Summary description for History.
	/// </summary>
	public class History
	{
		public History( int Maximum )
		{
            _SequentialList = new ArrayList( Maximum );

            _SearchableList = new SortedList( null, Maximum );

            ResetIterator();
		}

        public
            bool
            Find(
                bool   bGetFirst,
                string PartialCommand,
            out string FullCommand )
        {
			FullCommand = "";

            if ( bGetFirst )
            {
                _iCurrentSearch = 0;
            }

            for ( int iCurrentSearch = _iCurrentSearch; iCurrentSearch < _SearchableList.Count; iCurrentSearch ++ )
            {
                string Command = (string) _SearchableList.GetKey( iCurrentSearch );

                int Result = string.Compare( PartialCommand, 0, Command, 0, PartialCommand.Length );

                if ( 0 == Result )
                {
                    FullCommand = Command;

                    _iCurrentSearch = iCurrentSearch + 1;

                    return true;
                }
                else if ( -1 == Result )
                {
                    break;
                }
            }

            return false;
        }

        public
            void
            Add( string NewCommand )
        {
            if ( _SequentialList.Count >= _SequentialList.Capacity  )
            {
                string OldCommand = (string) _SequentialList[0];            

                _SequentialList.RemoveAt(0);
            
                _SearchableList.Remove( OldCommand );
            }

            _iCurrent = ( _iCurrent + 1 ) % _SequentialList.Capacity;

            _SequentialList.Add( NewCommand );

            if ( ! _SearchableList.ContainsKey( NewCommand ) )
            {
                _SearchableList.Add( NewCommand, NewCommand );
            }
        }

        public
            bool
            GetCurrentCommand(
                 bool  bPrevious, 
            out string Command )
        {
			Command = "";

            int Offset = _iCurrent + ( bPrevious ? -1 : 1 );

            if ( Offset < 0 || Offset >= _SequentialList.Count )
            {
                return false;
            }

            _iCurrent = Offset;

            Command = (string) _SequentialList[ Offset ];

            return true;
        }

        public
            void
            ResetIterator()
        {
            _iCurrent = _SequentialList.Count;
        }

        int        _iCurrent;
        int        _iCurrentSearch = 0;

        ArrayList  _SequentialList;
        SortedList _SearchableList;
	}
}
