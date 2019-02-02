FinnishYnabConverter
==========================

Converts Finnish banks csv transaction files to YNAB compatible format. 

* Verified to work with following banks csv format
  * Handelsbanken
 

How to use
==========================

On windows
```
finnish-ynab-csv-converter.exe -i C:\input\mytransactions.csv -b Handelsbanken -o C:\output\ 
```


| Argument| Description| 
|-------------|-------------|
| -i| Full path to input file| 
| -b| Name of the bank. This is case insensitive|  
| -o| Full path to output directory|   
