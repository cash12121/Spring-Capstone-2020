echo off

rem batch file to run a script to create the Master db on your home machine
rem 2/3/2020

sqlcmd -S localhost\sqlexpress -E -i ../DB_Script/PetUniverseDB.sql
rem sqlcmd -S LAPTOP-T3PUJGNB\SQLEXPRESS -E -i ../DB_Script/PetUniverseDB.sql

ECHO .
ECHO if no error messages appear DB was created
PAUSE