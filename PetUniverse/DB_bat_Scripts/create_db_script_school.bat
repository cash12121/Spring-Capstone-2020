echo off

rem batch file to run a script to create the Master db on a school computer.
rem 2/15/2020

sqlcmd -S localhost -E -i ../DB_Script/PetUniverseDB.sql

ECHO .
ECHO if no error messages appear DB was created
PAUSE