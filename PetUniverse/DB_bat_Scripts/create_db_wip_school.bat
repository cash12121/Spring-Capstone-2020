echo off

rem batch file to run a script to create a Work In Process version on the school computers
rem 2/15/2020

sqlcmd -S localhost -E -i ../DB_WIP/PetUniverseDB.sql

ECHO .
ECHO if no error messages appear DB was created
PAUSE