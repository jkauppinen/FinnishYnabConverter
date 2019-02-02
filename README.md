FinnishYnabConverter
==========================

Converts Finnish banks transaction files to YNAB compatible format. 

* Verified to work with following banks formats
  * Handelsbanken csv format

Target framework: .NET Core 2.2


Building
==========================

`git clone git@github.com:jkauppinen/FinnishYnabConverter.git`

`cd FinnishYnabConverter`

`dotnet build FinnishYnabConverter.sln`

Arguments
==========================


| Argument| Description| 
|-------------|-------------|
| -i| Full path to input file| 
| -b| Name of the bank. This is case insensitive|  
| -o| Full path to output directory|   
