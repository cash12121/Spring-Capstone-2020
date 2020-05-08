# Sql Code Standards


## Global Conventions

### Structure
* There is a section for Table, Stored Procedures, and Inserts. 
* Please put new SQL code and the end of each section.

### Keywords
* All Keywords must be in all CAPS.

### Data Types
* Must be all lowercase

### Use the Square brackets [ ] for table and column names
* Examples:
    * `[dbo].[TableName]`
    * `[Customer].[Email]`
    * `[Email]`

### Miscellaneous
* Commas go at the end of a line 
* No Semicolons are used in T-SQL

# Comments
## Comment Are Properly Formatted

Example:

```SQL
    /*
    Created By: Steven Cardona
    Date: 3/01/2020
    Comment: Creating procedure to insert User
    */
```

# Table Statements

## Create Table Statement Structure ( In Order )

1. Comment
2. Drop Table Statement
3. GO
4. Print Statements
5. GO
6. SQL Statement/Code Block
7. GO

## Drop the table  before you create it.

Example:

```SQL
    DROP TABLE IF EXISTS [dbo].[TableName]
    GO
```

**Note**: Insert statements do not need a drop statement.

## Fields in a Create table statement

### Must have these:

* Required
    * Column name
    * Data type
    * NULL or NOT NULL
* Optional
    * Default value


## EXAMPLE OF PROPERLY FORMATTED TABLE STATEMENT

```SQL
    /*
    Created by: Zach Behrensmeyer
    Date: 2/3/2020
    Comment: This is used to pair a user with their roles
    */
    DROP TABLE IF EXISTS [dbo].[UserRole]
    GO
    PRINT '' PRINT '*** Create User Role Table ***'
    GO
    CREATE TABLE [dbo].[UserRole](
        [UserID] 		    [int]					 	NOT NULL,
        [RoleID] 			[nvarchar] (50) 			NOT NULL,

        CONSTRAINT [pk_UserID_RoleID] PRIMARY KEY ([UserID] ASC, [RoleID] ASC),
        CONSTRAINT [fk_UserRole_UserID] FOREIGN KEY ([UserID])
        REFERENCES [dbo].[User] (UserID),
        CONSTRAINT [fk_Role_RoleID] FOREIGN KEY(RoleID)
        REFERENCES Role (RoleID) ON UPDATE CASCADE
    )
    GO
```


# Stored Procedures

## Conventions

* Stored Procedure Name
    * Starts with sp
    * Is all lowercase
    * Has one of the below to idenify the action type
        * select
        * insert
        * update
        * reactivate
        * deactivate
        * delete

* Parameters ( optional )
    * using [ ] for data type
    * must have old and new parameters for all field being updated (**Update Procedures Only**)

* Code Block inbetween Begin and End
    * Uses [ ] for any table/field references

## Create Procedure Statement Structure ( In Order )

1. Comment
2. Drop Procedure Statement
3. GO
4. Print Statements
5. GO
6. SQL Statement/Code Block
7. GO

## Drop the procedure before you create it.

Example:

```SQL
    DROP PROCEDURE IF EXISTS [sp_insert_user]
    GO
```

**Note**: Insert statements do not need a drop statement.

## EXAMPLE OF PROPERLY FORMATTED STORED PROCEDURE STATEMENT

### Create Procedure

```SQL
    /*
    Created by: Steven Cardona
    Date: 02/06/2020
    Comment: This is used to INSERT a new user into the database
    with all default values used.
    */
    DROP PROCEDURE IF EXISTS [sp_insert_user]
    GO
    PRINT '' PRINT '*** Create sp_insert_user ***'
    GO
    CREATE PROCEDURE [sp_insert_user]
    (
        @FirstName [nvarchar](50),
        @LastName [nvarchar](50),
        @PhoneNumber [nvarchar](11),
        @Email [nvarchar](250),
        @Address1 [nvarchar](250),
        @Address2 [nvarchar](250),
        @City [nvarchar](20),
        @State [nvarchar](2),
        @Zipcode [nvarchar](15)
    )
    AS
    Begin
        INSERT INTO [dbo].[User]
            ([FirstName], [LastName],[PhoneNumber],[Email],[addressLineOne],[addressLineTwo],[City],[State],[Zipcode])
        VALUES
            (@FirstName, @LastName, @PhoneNumber, @Email, @Address1, @Address2, @City, @State, @Zipcode)
    END
    GO
```

### Update Procedure

```SQL
    /*
    Created by: Carl Davis
    Date: 2/14/2020
    Comment: Sproc to update facility maintenance
    */
    DROP PROCEDURE IF EXISTS [sp_update_facility_maintenance]
    GO
    PRINT '' PRINT '*** Creating sp_update_facility_maintenance '
    GO
    CREATE PROCEDURE [sp_update_facility_maintenance]
    (
        @FacilityMaintenanceID          	[int],
        @OldUserID                        	[int],
        @OldMaintenanceName            		[nvarchar](50),
        @OldMaintenanceInterval         	[nvarchar](20),
        @OldMaintenanceDescription     		[nvarchar](250),
        @NewUserID                        	[int],
        @NewMaintenanceName            		[nvarchar](50),
        @NewMaintenanceInterval         	[nvarchar](20),
        @NewMaintenanceDescription     		[nvarchar](250)

    )
    AS
    BEGIN
        UPDATE 	[dbo].[FacilityMaintenance]
        SET 	[UserID] = @NewUserID,
                [MaintenanceName] = @NewMaintenanceName,
                [MaintenanceInterval] = @NewMaintenanceInterval,
                [MaintenanceDescription] = @NewMaintenanceDescription

        WHERE   [FacilityMaintenanceID] = @FacilityMaintenanceID
            AND	[UserID] = @OldUserID
            AND	[MaintenanceName] = @OldMaintenanceName
            AND	[MaintenanceInterval] = @OldMaintenanceInterval
            AND	[MaintenanceDescription] = @OldMaintenanceDescription
        RETURN @@ROWCOUNT

    END
    GO
```