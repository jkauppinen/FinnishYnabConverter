FinnishYnabCvsConverter
==========================

Converts Finnish banks csv transaction files to YNAB compatible format. 

* Verified to work with following banks csv format
  * Handelsbanken
 

How to use
==========================
1. Go to directory of finnish-ynab-csv-converter.exe
2. Run with commend line arguments. Example:

```
finnish-ynab-csv-converter.exe -i C:\input\mytransactions.csv -b Handelsbanken -o C:\output\ 
```


| Argument| Description| 
|-------------|-------------|
| -i| Full path to input file| 
| -b| Name of the bank. This is case insensitive|  
| -o| Full path to output directory|   
