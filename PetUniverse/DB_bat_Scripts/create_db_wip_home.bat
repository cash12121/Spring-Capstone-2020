echo off

rem batch file to run a script to create a Work In Process version on your home computer
rem 2/15/2020

sqlcmd -S localhost\sqlexpress -E -i ../DB_WIP/PetUniverseDB.sql

ECHO .
ECHO if no error messages appear DB was created
PAUSE