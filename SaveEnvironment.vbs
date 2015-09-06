Set WshShell = WScript.CreateObject("WScript.Shell")
Set CurrentEnvironment = WshShell.Environment("Process")

for each EnvironmentVariable in CurrentEnvironment
	if left( EnvironmentVariable, 1 ) <> "=" then
		wscript.echo "set " + EnvironmentVariable	
    end if		
next


