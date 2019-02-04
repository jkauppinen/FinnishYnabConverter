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


Using
==========================
To view available commands
`FinnishYnabConverter --help`
