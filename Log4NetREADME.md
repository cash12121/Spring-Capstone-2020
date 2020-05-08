Hello! If you are here you may be having issues with Log4net.

1.) If your program is running slowly to log you in go to the app.config and find the connection string and change it depending on what type of sql connection you need. Find this: <connectionStringName value="ConnectionString2" />
if you need one with localhost\sqlexpress do connectionstring1. 
If you only need one with localhost then do connectionstring2

2.) If you have done this and it is still not working left click on app.config and look at the "Advanced" section of properties. Make sure copy to output directory is copy always.

3.) Reach out to Zach Behrensmeyer and Josh Jackson

b77a5c561934e089
669e0ddf0bb1aa2a