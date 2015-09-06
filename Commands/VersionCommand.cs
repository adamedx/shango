using System;

namespace Shango
{
    using System.Reflection;
    using ConsoleProcessRedirection;

	/// <summary>
	/// Summary description for VersionCommand.
	/// </summary>
    public class VersionCommand : MultiInstanceCommand
    {
        public
            VersionCommand(
            MainWindow Application,
            ITerminal  Terminal ) : base ( Application, Terminal )
        {
        }

        public
            override
            int
            PerformCommand( string [] Arguments )
        {
            Assembly ThisAssembly = Assembly.GetCallingAssembly();

            string   AppTitle = "Shango";
            string   AppCompany = "Afrosoft";
            Version  AppVersion = new Version("0.1.0.10");
           
            object[] Attributes = ThisAssembly.GetCustomAttributes( false );

            foreach ( object Attr in Attributes )
            {
                if ( Attr is AssemblyTitleAttribute )
                {
                    AppTitle = ( ( AssemblyTitleAttribute ) Attr ).Title;
                }

                if ( Attr is AssemblyCompanyAttribute )
                {
                    AppCompany = ( ( AssemblyCompanyAttribute ) Attr ).Company;
                }

                if ( Attr is AssemblyName )
                {
                    AppVersion = ( ( AssemblyName ) Attr ).Version;
                }
            }

            string AppDescription = AppCompany + " " + AppTitle;

            AppDescription += " [Version " + AppVersion.Major + "." + AppVersion.Minor + "." + AppVersion.Revision + "." + AppVersion.Build + "]";

            TermUtil.WriteText( _Terminal, AppDescription + Environment.NewLine );



            return 0;
        }            	
    }
}
