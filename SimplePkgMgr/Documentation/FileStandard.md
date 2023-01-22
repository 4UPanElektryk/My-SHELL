# Example Repo File
```json
{
	
}
Name=PackageName
[Downloadable_0]
Package=http://example.com/File.zip
Manual=http://example.com/manual.txt
#This line below meens it's an alternative download server 
[Downloadable_1]
Package=http://example.com/File.zip
Manual=http://example.com/manual.txt
[ExecutableFiles]
File=program.exe
```

### Eplanation
Name is the package that will be install during the initial install and another modifiers

Every command you want to include accesible from My Shell must be included in ExecutableFiles section
File is the command name and past the "=" is the file name