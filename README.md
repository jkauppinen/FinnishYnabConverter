FinnishYnabConverter
==========================

Converts Finnish banks transaction files to YNAB 4 compatible format. 

* Verified to work with following banks formats
  * OP csv format
  * Handelsbanken csv format

Target framework: .NET Core 2.2


Building
==========================

`git clone git@github.com:jkauppinen/FinnishYnabConverter.git`

`cd FinnishYnabConverter`

`dotnet build FinnishYnabConverter.sln`

Creating executable on linux 

`dotnet publish -c Release -r ubuntu.16.04-x64`


CLI arguments
==========================


| Argument| Description| Required |
|-------------|-------------|-------------|
| -i| Full path to input file| true |
| -b| Name of the bank. This is case insensitive| true|
| -o| Full path to output directory|true|

Examples
==========================
On windows

`FinnishYnabConverter.exe -i C:\input\mytransactions.csv -b Handelsbanken -o C:\output\`

On linux

`./FinnishYnabConverter -i /input/mytransactions.csv -b Handelsbanken -o /output/`
