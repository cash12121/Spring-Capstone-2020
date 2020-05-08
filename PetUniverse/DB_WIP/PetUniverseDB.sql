/* Check whether the database already exists */
IF EXISTS (SELECT 1 FROM master.dbo.sysdatabases WHERE name= 'PetUniverseDB')
BEGIN
	DROP DATABASE [PetUniverseDB]
	PRINT '' PRINT '*** Dropping PetUniverseDB'
END
GO
PRINT '' PRINT '*** Creating Database'
GO

CREATE DATABASE [PetUniverseDB]
GO

PRINT '' PRINT '*** Using Database'
GO

USE PetUniverseDB
GO

/*
 ******************************* CREATE TABLEs *****************************
*/
PRINT '' PRINT '******************* CREATE TABLEs *********************'

/*
 * Created by: Jordan Lindo
 * Date: 2/5/2020
 * Comment: This is the table for department information.
 */
DROP TABLE IF EXISTS [dbo].[Department]
GO
PRINT '' PRINT '*** Creating Table Department'
GO

CREATE TABLE [dbo].[department]
(
	 [DepartmentID]			[nvarchar](50)		NOT NULL PRIMARY KEY
	,[Description]			[nvarchar](200)		NULL DEFAULT NULL
	,[Active]				[bit] 				NOT NULL DEFAULT 1	
)
GO

/*
Created by: Zach Behrensmeyer
Date: 2/3/2020
Comment: General user table, this is used for logging in and finding information about that user.
*/
DROP TABLE IF EXISTS [dbo].[User]
GO
print '' print '*** Create User Table ***'
GO
CREATE TABLE [dbo].[User](
[UserID] [int] NOT NULL Identity(100000, 1) PRIMARY KEY,
[FirstName] [nvarchar](50) NOT NULL,
[LastName] [nvarchar](50) NOT NULL,
[PhoneNumber] [nvarchar](11) NOT NULL,
[Email] [nvarchar](250) NOT NULL,
[PasswordHash] [nvarchar](100) NOT NULL DEFAULT 
'9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E',
[Active] [bit] NOT NULL Default 1,
[addressLineOne] [nvarchar](250) NOT NULL,
[addressLineTwo] [nvarchar](250) NULL,
[City] [nvarchar] (20) NOT NULL,
[State] [nvarchar] (2) NOT NULL,
[Zipcode] [nvarchar] (15) NOT NULL,
[Locked] [bit] NOT NULL Default 0,
[LockDate] [DateTime] NULL,
[UnlockDate] [DateTime] NULL,
[DepartmentID] [nvarchar](50) NULL,
[HasViewedPoliciesAndStandards] [bit] NOT NULL Default 0,
CONSTRAINT [fk_User_DepartmentID] FOREIGN KEY([DepartmentID])
		REFERENCES [Department]([DepartmentID])
)
GO

/*
Created by: Steven Cardona
Date: 2/3/2020
Comment: General user table, this is used for logging in and finding information about that user.
*/
DROP TABLE IF EXISTS [dbo].[Customer]
GO
PRINT '' PRINT '*** Create Customer Table ***'
GO
CREATE TABLE [dbo].[Customer](
    [Email] [nvarchar](250) NOT NULL PRIMARY KEY,
    [FirstName] [nvarchar](50) NOT NULL,
    [LastName] [nvarchar](50) NOT NULL,
    [PhoneNumber] [nvarchar](11) NOT NULL,
    [PasswordHash] [nvarchar](100) NOT NULL DEFAULT
    '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E',
    [addressLineOne] [nvarchar](250) NOT NULL,
    [addressLineTwo] [nvarchar](250) NULL,
    [City] [nvarchar] (20) NOT NULL,
    [State] [nvarchar] (2) NOT NULL,
    [Zipcode] [nvarchar] (15) NOT NULL,
    [Active] [bit] NOT NULL Default 1
)
GO

/*
Created by: Zach Behrensmeyer
Date: 2/8/2020
Comment: This is used to store logs from the program
*/
DROP TABLE IF EXISTS [dbo].[Logging]
GO
PRINT '' PRINT '*** Creating logging table'
CREATE TABLE [dbo].[Logging](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Date] [datetime] NOT NULL,
    [Thread] [varchar](255) NOT NULL,
    [Level] [varchar](50) NOT NULL,
    [Logger] [varchar](255) NOT NULL,
    [Message] [varchar](4000) NOT NULL,
    [Exception] [varchar](2000) NULL,
)
GO

/*
Created by: Chuck Baxter
Date: 2/8/2020
Comment: Place Holder for animal species

Updated by: Austin Gee
Date: 2/21/2020
Comment: Added Description Field.
*/
DROP TABLE IF EXISTS [dbo].[AnimalSpecies]
GO
PRINT '' PRINT '*** Creating table AnimalSpecies'
GO
CREATE TABLE [dbo].[AnimalSpecies](
	[AnimalSpeciesID]	[nvarchar](100)				NOT NULL,
	[Description]		[nvarchar](1000)					,
	CONSTRAINT [pk_AnimalSpeciesID] PRIMARY KEY([AnimalSpeciesID] ASC)
)
GO

/*
Created by: Chuck Baxter
Date: 2/8/2020
Comment: PlaceHolder Status table
*/
DROP TABLE IF EXISTS [dbo].[Status]
GO
PRINT '' PRINT '*** Creating Placeholder Status Table'
GO
CREATE TABLE [dbo].[Status](
	[StatusID]			[nvarchar](100)				NOT NULL,
	CONSTRAINT [pk_StatusID] PRIMARY KEY([StatusID] ASC)
)
GO

/*
Created by: Chuck Baxter
Date: 2/8/2020
Comment: Actual Animal Table
*/
DROP TABLE IF EXISTS [dbo].[Animal]
GO
PRINT '' PRINT '*** Creating table Animal'
GO
CREATE TABLE [dbo].[Animal](
	[AnimalID]			[int]IDENTITY(1000000,1)	NOT NULL,
	[AnimalName]		[nvarchar](100)				NOT NULL,
	[Dob]				[date]						NULL,
	[AnimalBreed]		[nvarchar](100)				NOT NULL,
	[ArrivalDate]		[date]						NOT NULL,
	[CurrentlyHoused]	[bit]						NOT NULL 	DEFAULT 0,
	[Adoptable]			[bit]						NOT NULL	DEFAULT 0,
	[Active]			[bit]						NOT NULL	DEFAULT 1,
	[AnimalSpeciesID]	[nvarchar](100)				NOT NULL,
	/*Create By: Michael Thompson
	Date 2/7/2020
	Comment: Adding ProfilePhoto and Description
	*/
	[ProfilePhoto]			[nvarchar](50)  DEFAULT 'No image found',
	[ProfileDescription]	[nvarchar](500) DEFAULT 'NO description found',
	CONSTRAINT [pk_AnimalID] PRIMARY KEY([AnimalID] ASC),
	CONSTRAINT [fk_Animal_AnimalSpeciesID] FOREIGN KEY([AnimalSpeciesID])
		REFERENCES [AnimalSpecies]([AnimalSpeciesID]) ON UPDATE CASCADE
)
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses location number and access dates
*/
DROP TABLE IF EXISTS [dbo].[AnimalKennel]
GO
print '' print '*** Creating AnimalKennel Table'
GO
CREATE TABLE [dbo].[AnimalKennel] (

	[AnimalKennelID]		[int] IDENTITY(1000000,1) NOT NULL,
	[AnimalID]				[int]					  NOT NULL,
	[UserID]				[int]                     NOT NULL,
	[AnimalKennelInfo]		[nvarchar](4000)                  ,
	[AnimalKennelDateIn]	[date]                    NOT NULL,
	[AnimalKennelDateOut]	[date]

	CONSTRAINT [pk_AnimalKennelID] PRIMARY KEY([AnimalKennelID] ASC),

	CONSTRAINT [fk_Animal_AnimalID] FOREIGN KEY([AnimalID])
		REFERENCES [Animal]([AnimalID]) ON UPDATE CASCADE,

	CONSTRAINT [fk_AnimalKennel_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [ak_AnimalKennelID] UNIQUE([AnimalKennelID] ASC)
)
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Handling notes for animals
*/
DROP TABLE IF EXISTS [dbo].[AnimalHandlingNotes]
GO
PRINT '' PRINT '*** Creating AnimalHandlingNotes Table'
GO
CREATE TABLE [dbo].[AnimalHandlingNotes] (

	[AnimalHandlingNotesID]	[int] IDENTITY(1000000,1) NOT NULL,
	[AnimalID]				[int]					  NOT NULL,
	[UserID]				[int]					  NOT NULL,
	[AnimalHandlingNotes]	[nvarchar](4000)		  NOT NULL,
	[TemperamentWarning]	[nvarchar](1000)		  NOT NULL,
	[UpdateDate]			[date]					  NOT NULL

	CONSTRAINT [pk_AnimalHandlingNotesID] PRIMARY KEY([AnimalHandlingNotesID] ASC),

	CONSTRAINT [fk_Animal_AnimalID_] FOREIGN KEY([AnimalID])
		REFERENCES [Animal]([AnimalID]) ON UPDATE CASCADE,

	CONSTRAINT [fk_AnimalHandlingNotes_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [ak_AnimalHandlingNotesID] UNIQUE([AnimalHandlingNotesID] ASC)
)
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Vet appointments
*/
DROP TABLE IF EXISTS [dbo].[AnimalVetAppointment]
GO
PRINT '' PRINT '*** Creating AnimalVetAppointment Table'
GO
CREATE TABLE [dbo].[AnimalVetAppointment] (

	[AnimalVetAppointmentID]	[int] IDENTITY(1000000,1)			NOT NULL,
	[AnimalID]					[int]								NOT NULL,
	[UserID]					[int]								NOT NULL,
	[AppointmentDate]			[datetime]							NOT NULL,
	[AppointmentDescription]	[nvarchar](4000),
	[ClinicAddress]				[nvarchar](200),
	[VetName]					[nvarchar](200),
	[FollowUpDate]				[datetime],

	CONSTRAINT [pk_AnimalVetAppointmentID] PRIMARY KEY([AnimalVetAppointmentID] ASC),

	CONSTRAINT [fk_Animal_AnimalID__] FOREIGN KEY([AnimalID])
		REFERENCES [Animal]([AnimalID]) ON UPDATE CASCADE,

	CONSTRAINT [fk_AnimalVetAppointment_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [ak_AnimalVetAppointmentID] UNIQUE([AnimalVetAppointmentID] ASC)
)
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Animal Medical Information
*/
DROP TABLE IF EXISTS [dbo].[AnimalMedicalInfo]
GO
PRINT '' PRINT '*** Creating AnimalMedicalInfo Table'
GO
CREATE TABLE [dbo].[AnimalMedicalInfo] (

	[AnimalMedicalInfoID]		[int] IDENTITY(1000000,1)  NOT NULL,
	[AnimalID]					[int]					   NOT NULL,
	[UserID]					[int]					   NOT NULL,
	[SpayedNeutered]			[bit]					   NOT NULL,
	[Vaccinations]				[nvarchar](250)			   NOT NULL,
	[MostRecentVaccinationDate]	[Date]					   NOT NULL,
	[AdditionalNotes]			[nvarchar](500)

	CONSTRAINT [pk_AnimalMedicalInfoID] PRIMARY KEY([AnimalMedicalInfoID] ASC),

	CONSTRAINT [fk_Animal_AnimalID#] FOREIGN KEY([AnimalID])
		REFERENCES [Animal]([AnimalID]) ON UPDATE CASCADE,

	CONSTRAINT [fk_AnimalMedicalInfo_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [ak_AnimalMedicalInfoID] UNIQUE([AnimalMedicalInfoID] ASC)
)
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Animal Prescription Information
*/
DROP TABLE IF EXISTS [dbo].[AnimalPrescriptions]
GO
PRINT '' PRINT '*** Creating AnimalPrescriptions Table'
GO
CREATE TABLE [dbo].[AnimalPrescriptions] (

	[AnimalPrescriptionsID]   	[int] IDENTITY(1000000,1)	NOT NULL,
	[AnimalID]					[int]						NOT NULL,
	[AnimalVetAppointmentID] 	[int]						NOT NULL,
	[PrescriptionName]			[nvarchar](50)				NOT NULL,
	[Dosage]					[decimal]					NOT NULL,
	[Interval]					[nvarchar](250)				NOT NULL,
	[AdministrationMethod]		[nvarchar](100)				NOT NULL,
	[StartDate]					[Date]						NOT NULL,
	[EndDate]					[Date]						NOT NULL,
	[Description]				[nvarchar](500)

	CONSTRAINT [pk_AnimalPrescriptionsID] PRIMARY KEY([AnimalPrescriptionsID] ASC),

	CONSTRAINT [fk_AnimalVetAppointment_AnimalVetAppointmentID] FOREIGN KEY([AnimalVetAppointmentID])
		REFERENCES [AnimalVetAppointment]([AnimalVetAppointmentID]) ON UPDATE CASCADE,

	CONSTRAINT [fk_Animal_AnimalID___] FOREIGN KEY ([AnimalID])
		REFERENCES [Animal]([AnimalID]),

	CONSTRAINT [ak_AnimalPrescriptionsID] UNIQUE([AnimalPrescriptionsID] ASC)

)
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Facility Maintenance Information
*/
DROP TABLE IF EXISTS [dbo].[FacilityMaintenance]
GO
PRINT '' PRINT '*** Creating FacilityMaintenance Table'
GO
CREATE TABLE [dbo].[FacilityMaintenance] (

	[FacilityMaintenanceID]		[int] IDENTITY(1000000,1)	NOT NULL,
	[UserID]					[int]						NOT NULL,
	[MaintenanceName]			[nvarchar](50)				NOT NULL,
	[MaintenanceInterval]		[nvarchar](20)				NOT NULL,
	[MaintenanceDescription]	[nvarchar](250)				NOT NULL,
	[Active]					[bit]	   					NOT NULL DEFAULT 1

	CONSTRAINT [pk_FacilityMaintenanceID] PRIMARY KEY([FacilityMaintenanceID] ASC),

	CONSTRAINT [fk_User_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [ak_FacilityMaintenanceID] UNIQUE([FacilityMaintenanceID] ASC)
)
GO

/*
Created by: Carl Davis
Date: 2/28/2020
Comment: Table that has the Facility Inspection Information
*/
DROP TABLE IF EXISTS [dbo].[FacilityInspection]
GO
PRINT '' PRINT '*** Creating FacilityInspection Table'
GO
CREATE TABLE [dbo].[FacilityInspection] (

	[FacilityInspectionID]		[int] IDENTITY(1000000,1)	NOT NULL,
	[UserID]					[int]						NOT NULL,
	[InspectorName]				[nvarchar](50)				NOT NULL,
	[InspectionDate]			[date]						NOT NULL,
	[InspectionDescription]		[nvarchar](500)				NOT NULL,
	[InspectionCompleted]		[bit]						NOT NULL DEFAULT 0

	CONSTRAINT [pk_FacilityInspectionID] PRIMARY KEY([FacilityInspectionID] ASC),

	CONSTRAINT [fk_FacilityInspection_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [ak_FacilityInspectionID] UNIQUE([FacilityInspectionID] ASC)
)
GO

/*
Created by: Carl Davis
Date: 3/30/2020
Comment: Table that has the Facility Inspection Item Information
*/
DROP TABLE IF EXISTS [dbo].[FacilityInspectionItems]
GO
PRINT '' PRINT '*** Creating FacilityInspectionItem Table'
GO
CREATE TABLE [dbo].[FacilityInspectionItem] (

	[FacilityInspectionItemID]		[int] IDENTITY(1000000,1)		NOT NULL,
	[ItemName]						[nvarchar](100)					NOT NULL,
	[UserID]						[int]							NOT NULL,
	[FacilityInspectionID]			[int]							NOT NULL,
	[ItemDescription]				[nvarchar](500)					

	CONSTRAINT [pk_FacilityInspectionItemID] PRIMARY KEY([FacilityInspectionItemID] ASC),

	CONSTRAINT [fk_FacilityInspectionItem_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,
		
	CONSTRAINT [fk_FacilityInspectionItem_FacilityInspectionID] FOREIGN KEY([FacilityInspectionID])
		REFERENCES [FacilityInspection]([FacilityInspectionID]),

	CONSTRAINT [ak_FacilityInspectionItemID] UNIQUE([FacilityInspectionItemID] ASC)
)
GO

/*
Created by: Carl Davis
Date: 4/9/2020
Comment: Table that houses Facility Task Information
*/
DROP TABLE IF EXISTS [dbo].[FacilityTask]
GO
PRINT '' PRINT '*** Creating FacilityTask Table'
GO
CREATE TABLE [dbo].[FacilityTask] (

	[FacilityTaskID]		[int] IDENTITY(1000000,1) NOT NULL,
	[FacilityTaskName]		[nvarchar](100)			  NOT NULL,
	[UserID]				[int]					  NOT NULL,
	[StartDate]				[date]					  NOT NULL,
	[CompletionDate]		[date]					  NULL,
	[FacilityTaskNotes]		[nvarchar](500)			  NOT NULL,
	[TaskCompleted]			[bit]					  NOT NULL DEFAULT 0

	CONSTRAINT [pk_FacilityTaskID] PRIMARY KEY([FacilityTaskID] ASC),

	CONSTRAINT [fk_FacilityTask_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [ak_FacilityTaskID] UNIQUE([FacilityTaskID] ASC)
)
GO


/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Facility Work Information
*/
DROP TABLE IF EXISTS [dbo].[FacilityWork]
GO
PRINT '' PRINT '*** Creating FacilityWork Table'
GO
CREATE TABLE [dbo].[FacilityWork] (

	[FacilityWorkID]		[int] IDENTITY(1000000,1) NOT NULL,
	[UserID]				[int]					  NOT NULL,
	[WorkerUserID]	    	[int]				      NOT NULL,
	[FacilityMaintenanceID]	[int]					  NOT NULL,
	[AssignmentDate]		[date]					  NOT NULL,
	[CompletionDate]		[date]					  NOT NULL,
	[CompletionTime]		[date]					  NOT NULL,
	[CompletionNotes]		[nvarchar](250)			  NOT NULL

	CONSTRAINT [pk_FacilityWorkID] PRIMARY KEY([FacilityWorkID] ASC),

	CONSTRAINT [fk_FacilityWork_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [fk_FacilityWork_FacilityMaintenanceID] FOREIGN KEY([FacilityMaintenanceID])
		REFERENCES [FacilityMaintenance]([FacilityMaintenanceID]),

	CONSTRAINT [ak_FacilityWorkID] UNIQUE([FacilityWorkID] ASC)
)
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Kennel Cleaning Information
*/
DROP TABLE IF EXISTS [dbo].[FacilityKennelCleaning]
GO
PRINT '' PRINT '*** Creating FacilityKennelCleaning Table'
GO
CREATE TABLE [dbo].[FacilityKennelCleaning] (

	[FacilityKennelCleaningID]	[int] IDENTITY(1000000,1)	NOT NULL,
	[UserID]					[int]						NOT NULL,
	[AnimalKennelID]			[int]						NOT NULL,
	[Date]						[date]						NOT NULL,
	[Notes]						[nvarchar](250)

	CONSTRAINT [pk_FacilityKennelCleaningID] PRIMARY KEY([FacilityKennelCleaningID] ASC),

	CONSTRAINT [fk_FacilityKennelCleaning_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [fk_FacilityKennelCleaning_AnimalKennelID] FOREIGN KEY([AnimalKennelID])
		REFERENCES [AnimalKennel]([AnimalKennelID])

)
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Animal Activity
*/
DROP TABLE IF EXISTS [dbo].[AnimalActivityType]
GO
PRINT '' PRINT '*** Creating AnimalActivityType Table'
GO
CREATE TABLE [dbo].[AnimalActivityType] (
	[AnimalActivityTypeID]	[nvarchar](100)				 	NOT NULL,
	[ActivityNotes]			[nvarchar](MAX)

	CONSTRAINT [pk_AnimalActivityTypeID] PRIMARY KEY([AnimalActivityTypeID] ASC)
)
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Animal Activity
*/
DROP TABLE IF EXISTS [dbo].[AnimalActivity]
GO
PRINT '' PRINT '*** Creating AnimalActivity Table'
GO
CREATE TABLE [dbo].[AnimalActivity] (

[AnimalActivityID] 	    [int] IDENTITY(1000000,1)	NOT NULL,
[AnimalID]		        [int]						NOT NULL,
[UserID]			    [int]						NOT NULL,
[AnimalActivityTypeID]  [nvarchar](100)				NOT NULL,
[ActivityDateTime]      [DateTime]   				NOT NULL,
[Description]			[nvarchar](4000)			NOT NULL,


	CONSTRAINT [pk_AnimalActivityID] PRIMARY KEY([AnimalActivityID] ASC),

	CONSTRAINT [fk_AnimalActivity_AnimalID] FOREIGN KEY([AnimalID])
		REFERENCES [Animal]([AnimalID]) ON UPDATE CASCADE,

	CONSTRAINT [fk_AnimalActivity_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [fk_AnimalActivityType_AnimalActivityTypeID] FOREIGN KEY([AnimalActivityTypeID])
		REFERENCES [AnimalActivityType]([AnimalActivityTypeID]) ON UPDATE CASCADE
)
GO

/*
ShiftTime table shows timeframe and which dept.

Author: Lane Sandburg
2/5/2020

*/
DROP TABLE IF EXISTS [dbo].[ShiftTime]
GO
PRINT '' PRINT '*** creating table ShiftTime'
GO
CREATE TABLE [dbo].[ShiftTime](
	[ShiftTimeID]	[int]IDENTITY(1000000,1)	NOT NULL,
	[DepartmentID]  [NVARCHAR](50)				NOT NULL,
	[StartTime]		[NVARCHAR](20) 					NOT NULL,
	[EndTime]		[NVARCHAR](20) 					NOT NULL,


	CONSTRAINT [pk_ShiftTime_ShiftTimeID]
		PRIMARY KEY([ShiftTimeID] ASC),
	CONSTRAINT [fk_ShiftTime_DepartmentID] FOREIGN KEY([DepartmentID])
		REFERENCES [Department]([DepartmentID]) ON UPDATE CASCADE
)
GO

/*
Created by: Mohamed Elamin
Date: 2/3/2020
Comment: AdoptionApplication table.
*/
DROP TABLE IF EXISTS [dbo].[AdoptionApplication]
GO
PRINT '' PRINT '*** Creating AdoptionApplication Table'
GO
CREATE TABLE [dbo].[AdoptionApplication](
	[AdoptionApplicationID]		[int]	IDENTITY(100000,1)		NOT NULL,
	[CustomerEmail]				[nvarchar](250)					NOT NULL,
	[AnimalID]					[int]									,
	[Status]					[nvarchar]	(1000)						,
	[RecievedDate]				[datetime]						NOT NULL,
	[Active]					[bit]	DEFAULT 1        		NOT NULL,
	CONSTRAINT [pk_AdoptionApplicationID] PRIMARY KEY ([AdoptionApplicationID]),
	CONSTRAINT [fk_AdoptionApplication_Customer_CustomerEmail] FOREIGN KEY ([CustomerEmail])
		REFERENCES [Customer]([Email]),
	CONSTRAINT [fk_AdoptionApplication_Animal_AnimalID] FOREIGN KEY ([AnimalID])
		REFERENCES [Animal]([AnimalID])
)
GO

/*
Created by: Austin Gee
Date: 2/21/2020
Comment: Table that holds the various appointment types for adoption appointments
*/
DROP TABLE IF EXISTS [dbo].[AppointmentType]
GO
PRINT '' PRINT '*** Creating AppointmentType Table'
GO
CREATE TABLE [dbo].[AppointmentType](
	[AppointmentTypeID]		[nvarchar]	(100)	NOT NULL,
	[Description]			[nvarchar]	(1000)			,
	CONSTRAINT [pk_AppointmentTypeID] PRIMARY KEY ([AppointmentTypeID])
)
GO

/*
Created by: Austin Gee
Date: 2/21/2020
Comment: This Table holds locations in general. It is used by Adoptions to
	track locations of various appointments.
*/
DROP TABLE IF EXISTS [dbo].[Location]
GO
PRINT '' PRINT '*** Creating Location Table'
GO
CREATE TABLE [dbo].[Location](
	[LocationID]	[int]	IDENTITY(1000000,1)		NOT NULL,
	[Name]			[nvarchar]	(100)						,
	[Address1]		[nvarchar]	(100)				NOT NULL,
	[Address2]		[nvarchar]	(100)						,
	[City]			[nvarchar]	(100)				NOT NULL,
	[State]			[nvarchar]	(2)					NOT NULL,
	[Zip]			[nvarchar]	(20)				NOT NULL,
	CONSTRAINT [pk_LocationID] PRIMARY KEY	([LocationID])
)
GO

/*
Created by: Austin Gee
Date: 2/21/2020
Comment: This table holds data regarding various adoption related appointments.
*/
DROP TABLE IF EXISTS [dbo].[Appointment]
GO
PRINT '' PRINT '*** Creating Appointment Table'
GO
CREATE TABLE [dbo].[Appointment](
	[AppointmentID]			[int]	IDENTITY(1000000,1)		NOT NULL,
	[AdoptionApplicationID]	[int]							NOT NULL,
	[AppointmentTypeID]		[nvarchar]	(100)				NOT NULL,
	[DateTime]				[datetime]						NOT NULL,
	[Notes]					[nvarchar]	(1000)						,
	[Decision]				[nvarchar]	(50)						,
	[LocationID]			[int]							NOT NULL,
	[Active]				[bit]	DEFAULT 1				NOT NULL,
	CONSTRAINT [pk_AppointmentID] PRIMARY KEY ([AppointmentID]),
	CONSTRAINT [fk_Appointment_AdoptionApplication_AdoptionApplicationID] FOREIGN KEY ([AdoptionApplicationID])
		REFERENCES [AdoptionApplication] ([AdoptionApplicationID]),
	CONSTRAINT [fk_Appointment_AppointmentType_AppointmentTypeID] FOREIGN KEY ([AppointmentTypeID])
		REFERENCES [AppointmentType] ([AppointmentTypeID]),
	CONSTRAINT [fk_Appointment_Location_LocationID] FOREIGN KEY ([LocationID])
		REFERENCES [Location] ([LocationID])
)
GO


/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Create ItemCategory Table
*/
DROP TABLE IF EXISTS [dbo].[ItemCategory]
GO
PRINT '' PRINT '*** Creating ItemCategory Table'
GO
CREATE TABLE [dbo].[ItemCategory](
	[ItemCategoryID] [nvarchar](50) NOT NULL PRIMARY KEY,
	[Description] [nvarchar](250) NOT NULL
)
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Create Item Table
Updated By: Matt Deaton
Date: 2020-03-07
Comment: Added the ShelterItem and Shelter Theshold field to allow for Shelter Item
*/
DROP TABLE IF EXISTS [dbo].[Item]
GO
PRINT '' PRINT '*** Creating Item Table'
GO
CREATE TABLE [dbo].[Item](
	[ItemID] [int] NOT NULL IDENTITY(100000, 1) PRIMARY KEY,
	[ItemName] [nvarchar](50) NOT NULL,
	[ItemCategoryID] [nvarchar](50) NOT NULL,
	[ItemDescription] [nvarchar](250) ,
	[ItemQuantity] [int] NOT NULL,
	[Active]       [bit] DEFAULT 1 NOT NULL,
	[ShelterItem] [bit] DEFAULT 0,
	[ShelterThershold]	[int]
	
)
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Create ProductCategory Table
*/
DROP TABLE IF EXISTS [dbo].[ProductCategory]
GO
PRINT '' PRINT '*** Creating ProductCategory Table'
GO
CREATE TABLE [dbo].[ProductCategory](
	[ProductCategoryID] [nvarchar](20) NOT NULL PRIMARY KEY,
	[Description] [nvarchar](500) NOT NULL
)
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Create ProductType Table
*/
DROP TABLE IF EXISTS [dbo].[ProductType]
GO
PRINT '' PRINT '*** Creating ProductType Table'
GO
CREATE TABLE [dbo].[ProductType](
	[ProductTypeID] [nvarchar](20) NOT NULL PRIMARY KEY,
	[Description] [nvarchar](500) NOT NULL
)
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Create Product Table, Updated to new structure 2020/03/17 by Robert Holmes
*/
DROP TABLE IF EXISTS [dbo].[Product]
GO
print '' print '*** Creating Product table'
GO
CREATE TABLE [dbo].[Product](
	[ProductID]		[nvarchar](13)	NOT NULL	PRIMARY KEY,
	[ItemID]		[INT]			NOT NULL,
	[ProductTypeID]	[nvarchar](20)	NOT NULL,
	[Taxable]		[BIT]			NOT NULL,
	[Price]			[decimal](10,2)	NOT NULL,
	[Description]	[nvarchar](500)	NOT NULL,
	[Brand]			[nvarchar](20)	NOT	NULL,
	[Active]		[BIT]			NOT NULL	DEFAULT 1,
	CONSTRAINT [fk_Product_ItemID]	FOREIGN KEY ([ItemID])
		REFERENCES [dbo].[Item]([ItemID]),
	CONSTRAINT [fk_Product_ProductTypeID]	FOREIGN KEY ([ProductTypeID])
		REFERENCES [dbo].[ProductType]([ProductTypeID])
)
GO

/*
Created by: Derek Taylor
Date 2/4/2020
Comment: Stores data about applicants
*/
DROP TABLE IF EXISTS [dbo].[Applicant]
GO
PRINT '' PRINT '*** Creating Applicant Table'
GO
CREATE TABLE [dbo].[Applicant](
	[ApplicantID]			[int]IDENTITY(100000, 1)	NOT NULL,
	[FirstName]				[nvarchar](50)				NOT NULL,
	[LastName]				[nvarchar](50)				NOT NULL,
	[MiddleName]			[nvarchar](50)				NULL,
	[Email]					[nvarchar](250)				NOT NULL,
	[PhoneNumber]			[nvarchar](11)				NOT NULL,
	[AddressLine1]			[nvarchar](100)				NOT NULL,
	[AddressLine2]			[nvarchar](100)				NULL,
	[City]					[nvarchar](100)				NOT NULL,
	[State]					[char](2)					NOT NULL,
	[ZipCode]				[nvarchar](12)				NOT NULL,
	[Foster]				[bit]						NOT NULL DEFAULT 0,
	CONSTRAINT [pk_ApplicantID] PRIMARY KEY([ApplicantID] ASC),
	CONSTRAINT [ak_Applicant_Email] UNIQUE([Email] ASC)
)
GO

/*
Created by: Chase Schulte
Date: 02/05/2020
Comment: Inserts table for the ERole Table
*/
DROP TABLE IF EXISTS [dbo].[ERole]
GO
PRINT ''  PRINT '*** Creating Table ERole Table'
GO
CREATE TABLE [dbo].[ERole](
	[ERoleID]	[nvarchar](50) 							not Null,
	[DepartmentID] nvarchar(50)							Not Null,
	[Description] [nvarchar](200)						Null,
	[Active]		[bit]			Not Null Default 1,
	Constraint	[pk_ERoleID] 	PRIMARY KEY([ERoleID] ASC),
	Constraint	[fk_ERole_DepartmentID] Foreign Key([DepartmentID])
		REFERENCES [department]([DepartmentID] ) On UPDATE CASCADE
)
GO

/*
Created by: Chase Schulte
Date: 02/28/2020
Comment: Create UserERole Table
*/
DROP TABLE IF EXISTS [dbo].[UserERole]
GO
PRINT '' PRINT '*** Creating table UserERole'
GO
CREATE TABLE [dbo].[UserERole](
	[UserID]	[int] 									NOT NULL,
	[ERoleID]	[nvarchar](50) 							Not Null,

	Constraint	[pk_UserERole_UserID_RoleID] 	PRIMARY KEY([UserID] ASC, [ERoleID] Asc),
	Constraint	[fk_UserERole_UserID] Foreign Key([UserID])
		REFERENCES [User]([UserID]),
	Constraint	[fk_UserERole_RoleID] 	Foreign KEY([ERoleID])
		REFERENCES [ERole]([ERoleID]) On UPDATE CASCADE

)
Go

/*
Created by: Ethan Holmes
Date: 02/16/2020
Comment: Create volunteer task table
*/
DROP TABLE IF EXISTS [dbo].[VolunteerTask]
GO
PRINT '' PRINT '*** Creating VolunteerTask Table'
GO
CREATE TABLE [dbo].[VolunteerTask](
	[VolunteerTaskID] 		[int] IDENTITY(1000000,1) 	NOT NULL,
	[TaskName]				[NVARCHAR](100)				NOT NULL,
	[TaskType]				[NVARCHAR](100)				NOT NULL,
	[AssignmentGroup]		[NVARCHAR](100)				NOT NULL,
	[TaskDescription] 		[NVARCHAR](1080) 			    NULL,
	[DueDate] 				[DATE]						NOT NULL,

	CONSTRAINT [pk_VolunteerTaskID] PRIMARY KEY([VolunteerTaskID] ASC),
)
GO

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Table that holds different types of requests
*/
DROP TABLE IF EXISTS [dbo].[requestType]
GO
PRINT '' PRINT '*** Creating requestType table'
GO
CREATE TABLE [dbo].[requestType] (
	[RequestTypeID]		[nvarchar](50)		NOT NULL,
	[Description]		[nvarchar](250)			NULL,
	CONSTRAINT [pk_RequestTypeID] PRIMARY KEY ([RequestTypeID] ASC)
)
GO

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Table that holds each submitted request
*/
DROP TABLE IF EXISTS [dbo].[request]
GO
PRINT '' PRINT '*** Creating request table'
GO
CREATE TABLE [dbo].[request] (
	[RequestID]				[int]IDENTITY(1000000,1)	NOT NULL,
	[RequestTypeID]			[nvarchar](50)				NOT NULL,
	[DateCreated]			[datetime]					NOT NULL,
	[RequestingUserID]		[int]						NOT NULL,
	[Open]					[bit]			  NOT NULL DEFAULT 1,
	CONSTRAINT [pk_RequestID] PRIMARY KEY ([RequestID] ASC),
	CONSTRAINT [fk_request_requestTypeID] FOREIGN KEY([RequestTypeID])
		REFERENCES [requestType]([RequestTypeID]) ON UPDATE CASCADE,
	CONSTRAINT [fk_request_requestingUserD] FOREIGN KEY ([RequestingUserID])
		REFERENCES [user]([UserID])
)
GO

/*
Created by: Kaleb Bachert
Date: 3/6/2020
Comment: Table that holds each submitted time off request
*/
DROP TABLE IF EXISTS [dbo].[timeOffRequest]
GO
PRINT '' PRINT '*** Creating timeOffRequest table'
GO
CREATE TABLE [dbo].[timeOffRequest] (
	[TimeOffRequestID]		[int]IDENTITY(1000000,1)	NOT NULL,
	[EffectiveStart]		[datetime]					NOT NULL,
	[EffectiveEnd]			[datetime]						NULL,
	[ApprovalDate]			[datetime]						NULL,
	[ApprovingUserID]		[int]							NULL,
	[RequestID]				[int]						NOT NULL,
	CONSTRAINT [pk_TimeOffRequestID] PRIMARY KEY ([TimeOffRequestID] ASC),
	CONSTRAINT [fk_timeOffRequest_RequestID] FOREIGN KEY ([RequestID])
		REFERENCES [request]([RequestID]),
	CONSTRAINT [fk_timeOffRequest_ApprovingUserID] FOREIGN KEY ([ApprovingUserID])
		REFERENCES [user]([UserID])
)

GO


/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that holds outgoing orders
*/
DROP TABLE IF EXISTS [dbo].[OutgoingOrders]
GO
PRINT '' PRINT '*** Creating OutgoingOrders Table'
GO
CREATE TABLE [dbo].[OutgoingOrders] (

	[OutgoingOrderID]	[int] IDENTITY(1000000,1)			NOT NULL,
	[OrderDate]			[DateTime] 							NOT NULL,
	[ItemID]			[int] 								NOT NULL,
	[ItemCategoryID]	[nvarchar](1000) 					NOT NULL,
	[UserID] 			[int] 								NOT NULL,
	[ItemQuantity]		[int] 								NOT NULL,
	
	CONSTRAINT [pk_OutgoingOrderID] PRIMARY KEY([OutgoingOrderID] ASC)
	)

GO


/*
Created by: Kaleb Bachert
Date: 3/17/2020
Comment: Table that holds each submitted availability change request
*/
print '' print '*** Creating availabilityRequest table'
GO
CREATE TABLE [dbo].[availabilityRequest] (
	[AvailabilityRequestID]		[int]IDENTITY(1000000,1)	NOT NULL,
	[SundayStartTime]			[nvarchar](30)					NULL,
	[SundayEndTime]				[nvarchar](30)					NULL,
	[MondayStartTime]			[nvarchar](30)					NULL,
	[MondayEndTime]				[nvarchar](30)					NULL,
	[TuesdayStartTime]			[nvarchar](30)					NULL,
	[TuesdayEndTime]			[nvarchar](30)					NULL,
	[WednesdayStartTime]		[nvarchar](30)					NULL,
	[WednesdayEndTime]			[nvarchar](30)					NULL,
	[ThursdayStartTime]			[nvarchar](30)					NULL,
	[ThursdayEndTime]			[nvarchar](30)					NULL,
	[FridayStartTime]			[nvarchar](30)					NULL,
	[FridayEndTime]				[nvarchar](30)					NULL,
	[SaturdayStartTime]			[nvarchar](30)					NULL,
	[SaturdayEndTime]			[nvarchar](30)					NULL,
	[ApprovalDate]				[datetime]						NULL,
	[ApprovingEmployeeID]		[int]							NULL,
	[RequestID]					[int]						NOT NULL,
	CONSTRAINT [pk_AvailabilityRequestID] PRIMARY KEY ([AvailabilityRequestID] ASC),
	CONSTRAINT [fk_availabilityRequest_RequestID] FOREIGN KEY ([RequestID])
		REFERENCES [request]([RequestID]),
	CONSTRAINT [fk_availabilityRequest_ApprovingEmployeeID] FOREIGN KEY ([ApprovingEmployeeID])
		REFERENCES [user]([UserID])
)
GO
/*
Created by: Awaab Elamin
Date: 2/18/2020
Comment: Create a general questiones table that contain the questions of the questionnair.
*/
GO
print '' print '*** Creating the GeneralQusetions table'
GO
DROP TABLE IF EXISTS [dbo].[GeneralQusetions]
GO
CREATE TABLE [dbo].[GeneralQusetions](
	[QuestionID] [int] IDENTITY (1000000, 1) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,

	CONSTRAINT [pk_QuestionID] PRIMARY KEY ([QuestionID] ASC)
)
GO
/*
Created by: Awaab Elamin
Date: 2/10/2020
Comment: Create Customer Answers table that contains the customer answers of the questionnair
*/
print '' print '*** Creating the CustomerAnswer table'
GO
CREATE TABLE [dbo].[CustomerAnswers](
	[QuestionDescription] [nvarchar](100)  NOT NULL,
	[CustomerEmail] [NVARCHAR](250)  NOT NULL,
	[AdoptionApplicationID] [int]  NOT NULL,
	[Answer] [nvarchar](500) NOT NULL,

	CONSTRAINT [pk_QuestionID_CustomerID_AdoptionApplicationID] PRIMARY KEY ([QuestionDescription] ASC,[CustomerEmail] ASC,[AdoptionApplicationID] ASC),	
	CONSTRAINT [CustomerEmail]	FOREIGN KEY ([CustomerEmail])
		REFERENCES [dbo].[Customer]([Email]),
	CONSTRAINT [AdoptionApplicationID]	FOREIGN KEY ([AdoptionApplicationID])
		REFERENCES [dbo].[AdoptionApplication]([AdoptionApplicationID])
)
GO

/*
Created by: Jaeho Kim
Date: 2/26/2020
Comment: Create TransactionStatus Table
*/
DROP TABLE IF EXISTS [dbo].[TransactionStatus]
GO
PRINT '' PRINT '*** Creating TransactionStatus Table'
GO
CREATE TABLE [dbo].[TransactionStatus](
	[TransactionStatusID] 	[nvarchar](20)  NOT NULL,
	[Description] 			[nvarchar](500) NOT NULL,
	[DefaultInStore]		[bit]			NOT NULL	DEFAULT 0,

	CONSTRAINT [pk_TransactionStatus_TransactionStatusID] PRIMARY KEY ([TransactionStatusID] ASC)
)
GO

/*
Created by: Jaeho Kim
Date: 2/26/2020
Comment: Create TransactionType Table
*/
DROP TABLE IF EXISTS [dbo].[TransactionType]
GO
PRINT '' PRINT '*** Creating TransactionType Table'
GO
CREATE TABLE [dbo].[TransactionType](
	[TransactionTypeID] 	[nvarchar](20) 		NOT NULL,
	[Description] 			[nvarchar](500) 	NOT NULL,
	[DefaultInStore]		[bit]				NOT Null	DEFAULT 0,

	CONSTRAINT [pk_TransactionType_TransactionTypeID] PRIMARY KEY ([TransactionTypeID] ASC)
)
GO

/*
Created by: Jaeho Kim
Date: 2/26/2020
Comment: Create Transaction Table
*/
DROP TABLE IF EXISTS [dbo].[Transaction]
GO
PRINT '' PRINT '*** Creating Transaction Table'
GO
CREATE TABLE [dbo].[Transaction](
	[TransactionID] 		[int]				IDENTITY(1000,1)	NOT NULL,
	[TransactionDateTime] 	[datetime]			NOT NULL,
	[TaxRate] 				[decimal](10,4) 	NOT NULL,
	[SubTotalTaxable] 		[decimal](10,2) 	NOT NULL,
	[SubTotal] 				[decimal](10,2) 	NOT NULL,
	[Total] 				[decimal](10,2) 	NOT NULL,
	[TransactionTypeID] 	[nvarchar](20) 		NOT NULL,
	[EmployeeID] 			[int] 				NOT NULL,
	[TransactionStatusID] 	[nvarchar](20) 		NOT NULL,
	[CustomerEmail]			[nvarchar](250),
	[StripeChargeID]		[nvarchar](30)

	CONSTRAINT [pk_Transaction_TransactionID] PRIMARY KEY ([TransactionID] ASC),
	CONSTRAINT [fk_Transaction_EmployeeID] FOREIGN KEY ([EmployeeID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,
	CONSTRAINT [fk_Transaction_TransactionStatusID] FOREIGN KEY ([TransactionStatusID])
		REFERENCES [TransactionStatus]([TransactionStatusID]) ON UPDATE CASCADE,
	CONSTRAINT [fk_Transaction_TransactionTypeID] FOREIGN KEY ([TransactionTypeID])
		REFERENCES [TransactionType]([TransactionTypeID])  ON UPDATE CASCADE
)
GO

/*
Created by: Jaeho Kim
Date: 2/27/2020
Comment: Create TransactionLineProducts Table
*/
DROP TABLE IF EXISTS [dbo].[TransactionLineProducts]
GO
PRINT '' PRINT '*** Creating TransactionLineProducts Table'
GO

CREATE TABLE [dbo].[TransactionLineProducts](
	[TransactionID] 		[int] 				NOT NULL,
	[ProductID] 			[nvarchar](13) 		NOT NULL,
	[Quantity]				[int]				NOT NULL,
	[PriceSold]				[decimal](10,2)		NOT NULL

	CONSTRAINT [fk_TransactionLineProducts_TransactionID] FOREIGN KEY ([TransactionID])
		REFERENCES [Transaction]([TransactionID]) ON UPDATE CASCADE,
	CONSTRAINT [fk_TransactionLineProducts_ProductID] FOREIGN KEY ([ProductID])
		REFERENCES [Product]([ProductID]) ON UPDATE CASCADE
)
GO

/*
Created by: Alex Diers
Date: 2/28/2020
Comment: Creates the table for Training Videos
*/
DROP TABLE IF EXISTS [dbo].[TrainingVideo]
GO
PRINT '' PRINT '*** Creating TrainingVideo Table'
GO
CREATE TABLE [dbo].[TrainingVideo](
	[TrainingVideoID] 		[nvarchar](150)				NOT NULL,
	[RunTimeMinutes] 		[int] 						NOT NULL,
	[RunTimeSeconds] 		[int] 						NOT NULL,
	[Description] 			[nvarchar] (1000) 			NOT NULL,
	[Active] 				[bit] 						NOT NULL Default 1,
	CONSTRAINT [pk_TrainingVideoID] 			PRIMARY KEY ([TrainingVideoID] ASC)
)
GO

/*
Created by: Tener Karar
Date: 02/27/2020
Comment: INSERTing Item Location table data
*/
DROP TABLE IF EXISTS [dbo].[ItemLocation]
GO
PRINT '' PRINT '*** creating ItemLocation table'
GO
CREATE TABLE [dbo].[ItemLocation] (
	[LocationID]	    [int] IDENTITY(1000,1) 	    NOT NULL,
	[Description]      [nvarchar]     (50) 			  	NOT NULL,

	CONSTRAINT [pk_invLocationID] PRIMARY KEY([LocationID] ASC),

)
GO

/*
Created by: Tener Karar
Date: 02/27/2020
Comment: creating Item Location Line table'
*/
DROP TABLE IF EXISTS [dbo].[ItemLocationLine]
GO
PRINT '' PRINT '*** creating ItemLocationLine table'
GO
CREATE TABLE [dbo].[ItemLocationLine] (
    [ItemID]		     [int]                 	    NOT NULL,
	[LocationID]	    [int]             	    NOT NULL,

	CONSTRAINT [fk_ItemID] FOREIGN KEY([ItemID])
	REFERENCES [Item]([ItemID]),
	CONSTRAINT [fk_LocationID] FOREIGN KEY([LocationID])
	REFERENCES [ItemLocation]([LocationID])
)
GO

/*
Created By: Timothy Lickteig
Date: 2/07/2020
Comment: Table for volunteer shifts
*/
DROP TABLE IF EXISTS [dbo].[VolunteerShift]
GO
PRINT '' PRINT '*** Creating VolunteerShift Table'
GO
CREATE TABLE [dbo].[VolunteerShift](
	[VolunteerShiftID] 	[int] identity(1000000, 1) 	not null,
	[ShiftDescription] 	[nvarchar](1080) 			not null,
	[ShiftTitle] 		[nvarchar](500) 			not null,
	[ShiftDate]			[date]						not null,
	[ShiftStartTime] 	[time] 						not null,
	[ShiftEndTime] 		[time] 						not null,
	[Recurrance] 		[nvarchar](100) 			not null,
	[IsSpecialEvent] 	[bit] 						not null,
	[ShiftNotes] 		[nvarchar](1080) 			null,
	[ScheduleID] 		[int] 						not null,
	constraint [pk_VolunteerShift_VolunteerShiftID] primary key([VolunteerShiftID] asc)
)
GO

/*
Created By: Steve Coonrod
Date: 		2/9/2020
Comment:	Table for storing Event Types
*/
DROP TABLE IF EXISTS [dbo].[EventType]
GO
PRINT '' PRINT '*** Creating EventType Table'
GO
CREATE TABLE[dbo].[EventType](
	[EventTypeID]		[nvarchar](50)							NOT NULL,
	[Description]		[nvarchar](100)							NOT NULL,--Changed from nvarchar 50 to 100

	CONSTRAINT [pk_eventTypeID]			PRIMARY KEY([EventTypeID])
)
GO

/*
Created by: Steve Coonrod
Date: 		2/9/2020
Comment: 	This is the Event Table. It holds all the needed data for an Event.
*/
DROP TABLE IF EXISTS [dbo].[Event]
GO
PRINT '' PRINT '*** Creating Event Table'
GO
CREATE TABLE [dbo].[Event](
	[EventID]			[int]			IDENTITY(1000000,1)		NOT NULL,
	[CreatedByID]		[int]									NOT NULL,
	[DateCreated]		[datetime]								NOT NULL,
	[EventName]			[nvarchar](150)							NOT NULL,
	[EventTypeID]		[nvarchar](50)							NOT NULL,
	[EventDateTime]		[datetime]								NOT NULL,
	[EventAddress]		[nvarchar](200)							NOT NULL,
	[EventCity]			[nvarchar](50)							NOT NULL,
	[EventState]		[nvarchar](50)							NOT NULL,
	[EventZipcode]		[nvarchar](15)							NOT NULL,
	[EventPictureFileName]	[nvarchar](250)						NOT NULL,
	[Status]			[nvarchar](50)							NOT NULL,
	[Description]		[nvarchar](500)							NOT NULL,

	CONSTRAINT [pk_eventID]				PRIMARY KEY([EventID]ASC),
	--CONSTRAINT [fk_event_user]			FOREIGN KEY([CreatedByID])
		--REFERENCES [User]([UserID]),
	CONSTRAINT [fk_event_eventType]		FOREIGN KEY([EventTypeID])
		REFERENCES [EventType]([EventTypeID]) ON UPDATE CASCADE
)
GO

--Index to search by the events datetime
PRINT '' PRINT '  > Adding indexes to Event table'
GO
CREATE NONCLUSTERED INDEX [ix_eventDateTime]
	ON [Event]([EventDateTime]ASC)
GO
--Index to search by the events status
CREATE NONCLUSTERED INDEX [ix_eventStatus]
	ON [Event]([Status]ASC)
GO

/*
	Created by: Steve Coonrod
	Date: 		2/9/2020
	Comment: 	This is the Event Request table.
				It is a table for joining an Event to a Request
				This will be used mostly by the DC to view requests
				for events made by other members
*/
DROP TABLE IF EXISTS [dbo].[EventRequest]
GO
PRINT '' PRINT '*** Creating EventRequest Table'
GO
CREATE TABLE[dbo].[EventRequest](
	[EventID]			[int]									NOT NULL,
	[RequestID]			[int]									NOT NULL,
	[ReviewerID]		[int]									NULL,
	[DisapprovalReason]	[nvarchar](500)							NULL,
	[DesiredVolunteers]	[int]									NOT NULL,
	[Active]			[bit]									NOT NULL 	DEFAULT 1,

	CONSTRAINT [pk_eventRequest_Event_Request] PRIMARY KEY([EventID],[RequestID]),
	CONSTRAINT [fk_eventRequest_eventID] FOREIGN KEY([EventID])
		REFERENCES [Event]([EventID]) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT [fk_eventRequest_requestID] FOREIGN KEY([RequestID])
		REFERENCES [request]([RequestID]) ON UPDATE CASCADE ON DELETE CASCADE
	--CONSTRAINT [fk_eventRequest_reviewerID] FOREIGN KEY([ReviewerID])
		--REFERENCES [Employee]([EmployeeID]) ON UPDATE CASCADE
)
GO

/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: General request response table, used to track request comments and respones ********DOUBLE CHECK WITH DEREK
made by various users
*/
print '' print '*** creating request response table'
GO
CREATE TABLE [dbo].[RequestResponse] (
	[RequestResponseID]		[int]IDENTITY(100000, 1)	NOT NULL,
	[RequestID]				[int]						NOT NULL,
	[UserID]				[int]						NOT NULL,
	[Response]				[nvarchar](4000)			NOT NULL,
	[ResponseTimeStamp]		[datetime]					NOT NULL DEFAULT GETDATE(),
	CONSTRAINT [pk_response_RequestResponseID] PRIMARY KEY([RequestResponseID] ASC),
	CONSTRAINT [fk_response_RequestID] FOREIGN KEY([RequestID]) REFERENCES[Request]([RequestID]),
	CONSTRAINT [fk_requestResponse_UserID] FOREIGN KEY([UserID]) REFERENCES[User]([UserID])
)
GO

/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: Department request table, used to track inter-department requests
*/
DROP TABLE IF EXISTS [dbo].[DepartmentRequest]
GO
PRINT '' PRINT '*** creating department request table'
GO
CREATE TABLE [dbo].[DepartmentRequest] (
	[DeptRequestID]			[int]						NOT NULL,
	[RequestingUserID]		[int]						NOT NULL,
	[RequestGroupID]		[nvarchar](50)				NOT NULL,
	[RequestedGroupID]		[nvarchar](50)				NOT NULL,
	[DateAcknowledged]		[datetime]					NULL,
	[AcknowledgingUserID]	[int]						NULL,
	[DateCompleted]			[datetime]					NULL,
	[CompletedUserID]		[int]						NULL,
	[RequestSubject]		[nvarchar](100)				NOT NULL,
	[RequestTopic]			[nvarchar](250)				NOT NULL,
	[RequestBody]			[nvarchar](4000)			NOT NULL,
	CONSTRAINT [pk_DeptRequest_RequestID] PRIMARY KEY([DeptRequestID] ASC),
	CONSTRAINT [fk_DeptartmentRequest_DeptRequestID] FOREIGN KEY([DeptRequestID])
		REFERENCES [request]([RequestID]),
	CONSTRAINT [fk_RequestingUserID] FOREIGN KEY ([RequestingUserID]) REFERENCES[User]([UserID]) ON UPDATE CASCADE,
	CONSTRAINT [fk_Department_RequestGroupID] FOREIGN KEY([RequestGroupID])
		REFERENCES [Department]([DepartmentID]),
	CONSTRAINT [fk_Department_RequestedGroupID] FOREIGN KEY([RequestedGroupID])
		REFERENCES [Department]([DepartmentID]),
	CONSTRAINT [fk_UserID_AcknowledgingUserID] FOREIGN KEY([AcknowledgingUserID])
		REFERENCES [User]([UserID]),
	CONSTRAINT [fk_UserID_CompletedUserID] FOREIGN KEY([CompletedUserID])
		REFERENCES [User]([UserID])
)
GO

/*
Created by: Ryan Morganti
Date: 2020/02/21
Comment: EmployeeRole table for linking Employees and Departments
*/
DROP TABLE IF EXISTS [dbo].[EmployeeDepartment]
GO
PRINT '' PRINT '*** creating EmployeeDepartment table'
GO
CREATE TABLE [dbo].[EmployeeDepartment] (
	[EmployeeID]			[int]						NOT NULL,
	[DepartmentID]			[nvarchar](50)				NOT NULL,
	CONSTRAINT [pk_EmployeeDepartment_EmployeeID_DepartmentID] PRIMARY KEY([EmployeeID], [DepartmentID] ASC),
	CONSTRAINT [fk_EmployeeDepartment_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES[User]([UserID]) ON UPDATE CASCADE,
	CONSTRAINT [fk_EmployeeDepartment_DepartmentID] FOREIGN KEY ([DepartmentID]) REFERENCES[Department]([DepartmentID]) ON UPDATE CASCADE
)
GO

/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Table that houses Volunteer Information
*/
DROP TABLE IF EXISTS [dbo].[Volunteer]
GO
PRINT '' PRINT '*** Creating Volunteer Table'
GO
CREATE TABLE [dbo].[Volunteer](
	[VolunteerID] 	[int] identity(1000000,1) 	not null,
	[FirstName]  	[nvarchar](500)           	not null,
	[LastName]    	[nvarchar](500)         	not null,
	[Email]    	  	[nvarchar](100)				not null,
	[PhoneNumber] 	[nvarchar](12) 				not null,
	[OtherNotes]  	[nvarchar](2000)			null,
	[PasswordHash]	[nvarchar](100)				not null
		default '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E',
	[Active]      	[bit]         				not null default 1,
	constraint [pk_VolunteerID] primary key([VolunteerID] asc),
	constraint [ak_Volunteer_Email] unique([Email] asc)
)
GO


/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Table that houses different skills a volunteer could have
*/
DROP TABLE IF EXISTS [dbo].[VolunteerSkills]
GO
PRINT '' PRINT '*** Creating VolunteerSkills Table'
GO
CREATE TABLE [dbo].[VolunteerSkills](
	[SkillID]     			[nvarchar](50)  	not null,
	[SkillDescription] 		[nvarchar](500) 	not null,
	constraint [pk_SkillID] primary key([SkillID] asc)
)
GO


/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Table that ties Volunteers to their skills
*/
DROP TABLE IF EXISTS [dbo].[VolunteerSkill]
GO
PRINT '' PRINT '*** Creating VolunteerSkill Table'
GO
CREATE TABLE [dbo].[VolunteerSkill](
	[VolunteerID] 	[int]          	not null,
	[SkillID] 	  	[nvarchar](50) 	not null,
	constraint [pk_VolunteerID_SkillID] primary key([VolunteerID] asc, [SkillID] asc),
	constraint [fk_Volunteer_VolunteerID] foreign key([VolunteerID])
		references [Volunteer]([VolunteerID])on delete cascade,
    constraint [fk_VolunteerSkills_SkillID] foreign key([SkillID])
		references [VolunteerSkills]([SkillID]) on update cascade
)
GO

/*
Created by: Zoey McDonald
Date: 2/20/2020
Comment: Creates VolunteerEvents Table.
*/
DROP TABLE IF EXISTS [dbo].[VolunteerEvents]
GO
PRINT '' PRINT '*** Creating VolunteerEvents Table'
GO
CREATE TABLE [dbo].[VolunteerEvents](
	[VolunteerEventID] 		[int] IDENTITY(1000000,1)	NOT NULL,
	[EventName]   			[nvarchar](500)           	NOT NULL,
	[EventDescription]   	[nvarchar](4000)           	NOT NULL,
	[Active]      			[bit]         				NOT NULL 	DEFAULT 1,
	CONSTRAINT [pk_VolunteerEventID] PRIMARY KEY([VolunteerEventID] ASC)
)
GO

/*
Created by: Austin Gee
Date: 3/5/2020
Comment: lookup table to match a certain animal with any number of statuses
*/
DROP TABLE IF EXISTS [dbo].[AnimalStatus]
GO
PRINT '' PRINT '*** Creating AnimalStatus Table'
GO
CREATE TABLE [dbo].[AnimalStatus](
	[AnimalID]	[int]				NOT NULL,
	[StatusID] 	[nvarchar](100)		NOT NULL,
	CONSTRAINT [pk_AnimalID_StatusID] PRIMARY KEY ([AnimalID] ASC, [StatusID] ASC),
	CONSTRAINT [fk_animal_status_animal_animalID] FOREIGN KEY ([AnimalID])
		REFERENCES [Animal]([AnimalID]),
	CONSTRAINT [fk_animal_status_status_statusID] FOREIGN KEY ([StatusID])
		REFERENCES [Status]([StatusID])
)
GO

/*
Created by: Robert Holmes
Date: 2020/03/06
Comment: A table for holding a promotion types
*/
DROP TABLE IF EXISTS [dbo].[PromotionType]
GO
PRINT '' PRINT '*** Creating PromotionType table'
GO
CREATE TABLE [dbo].[PromotionType](
		[PromotionTypeID]	[nvarchar](20)	NOT NULL	PRIMARY KEY
	,	[Description]		[nvarchar](500)	NOT NULL
)
GO

/*
Created by: Robert Holmes
Date: 2020/03/06
Comment: A table for holding info about a promotion
*/
DROP TABLE IF EXISTS [dbo].[Promotion]
GO
PRINT '' PRINT '*** Creating Promotion table'
GO
CREATE TABLE [dbo].[Promotion](
	[PromotionID]		[nvarchar](20)		NOT NULL	PRIMARY KEY,
	[PromotionTypeID]	[nvarchar](20)		NOT NULL,
	[StartDate]			[datetime]			NOT NULL,
	[EndDate]			[datetime]			NOT NULL,
	[Discount]			[decimal](10, 2)	NOT NULL,
	[Description]		[nvarchar](500)		NOT NULL,
	[Active]			[bit]				NOT NULL 	DEFAULT 1,
	CONSTRAINT [fk_Promotion_PromotionType]	FOREIGN KEY([PromotionTypeID])
		REFERENCES [dbo].[PromotionType]([PromotionTypeID])
)
GO

/*
Created by: Robert Holmes
Date: 2020/03/06
Comment: A table to relate promotions to products
*/
DROP TABLE IF EXISTS [dbo].[PromoProductLine]
GO
PRINT '' PRINT '*** Creating PromoProductLine table'
GO
CREATE TABLE [dbo].[PromoProductLine](
		[PromotionID]	[nvarchar](20)	NOT NULL
	,	[ProductID]		[nvarchar](13)	NOT NULL
	,	CONSTRAINT 	[pk_PromoProductLine_PromotionID_ProductID]	PRIMARY KEY([PromotionID], [ProductID])
	,	CONSTRAINT	[fk_PromoProductLine_Promotion] 			FOREIGN KEY([PromotionID])
			REFERENCES	[dbo].[Promotion]([PromotionID])
	,	CONSTRAINT	[fk_PromoProductLine_Product]				FOREIGN KEY([ProductID])
			REFERENCES	[dbo].[Product]([ProductID])
)
GO

/*
Created By: Timothy Lickteig
Date: 3/01/2020
Comment: Table for storing instances of people signed up for shifts
*/
print '' print '*** Creating ShiftRecord Table'
go
create table [dbo].[ShiftRecord](
	
	VolunteerID [int] not null,
	VolunteerShiftID [int] not null,
	constraint [pk_ShiftRecord_VolunteerID_VolunteerShiftID] 
		primary key([VolunteerID], [VolunteerShiftID]),
	constraint [fk_VolunteerShift_VolunteerShiftID] foreign key([VolunteerShiftID])
		references [VolunteerShift]([VolunteerShiftID]),
	constraint [fk_ShiftRecord_VolunteerID] foreign key([VolunteerID])
		references [Volunteer]([VolunteerID])
)
go

/*
Author: Timothy Lickteig
Date: 2020/03/09
Comment: Creating table for Medicine
*/
print '' print '*** Creating Medicine table'
GO
CREATE TABLE [dbo].[Medicine] (

	[MedicineID] [int] identity(1000000, 1) not null,
	[MedicineName] [nvarchar](300) not null,
	[MedicineDosage] [nvarchar](300) not null,
	[MedicineDescription] [nvarchar](500),
	constraint [pk_Medicine_MedicineID] primary key([MedicineID] asc)
)
GO

/*
Created by: Zach Behrensmeyer
Date: 03/15/2020
Comment: Table for Messages
*/
DROP TABLE IF EXISTS [dbo].[Message]
GO
PRINT '' PRINT '*** Creating Message table'
GO
CREATE TABLE [dbo].[Message](
		[MessageID]				[INT]Identity(100000, 1)	PRIMARY KEY
		,[MessageContent] 		[NVARCHAR](4000) 			NULL
		,[MessageTitle] 		[NVARCHAR](100) 			NULL
		,[MessageSenderID] 		[INT] 						NOT NULL
		,[MessageReceiverID]	[INT]						NOT NULL
		,[MessageSeen] 			[BIT] DEFAULT 0 			NOT NULL
		,	CONSTRAINT	[fk_Message_MessageSenderID] 			FOREIGN KEY([MessageSenderID])
			REFERENCES	[dbo].[User]([UserID])
		,	CONSTRAINT	[fk_Message_MessageReceiverID]				FOREIGN KEY([MessageReceiverID])
			REFERENCES	[dbo].[User]([UserID])
)
GO


/*
Created by: Jordan Lindo
Date: 3/14/2020
Comment: Table BaseSchedule
*/
DROP TABLE IF EXISTS [dbo].[BaseSchedule]
GO

print '' print '*** Creating Table BaseSchedule'
GO

CREATE TABLE [dbo].[BaseSchedule]
(
	 [BaseScheduleID]				[int]		IDENTITY(1000000,1)				NOT NULL
	,[CreatingUserID]				[int]										NOT NULL
	,[CreationDate]					[date]									NOT NULL
	,[Active]						[bit]		DEFAULT  0
	,CONSTRAINT [pk_BaseScheduleID] PRIMARY KEY([BaseScheduleID] ASC)
	,CONSTRAINT [fk_CreatingUserID_BaseSchedule] FOREIGN KEY ([CreatingUserID])
		REFERENCES [User]([UserID])
)
GO

/*
Created by: Jordan Lindo
Date: 3/14/2020
Comment: Table BaseScheduleLine
*/

DROP TABLE IF EXISTS [dbo].[BaseScheduleLine]
GO

print '' print '***Creating BaseScheduleLine Table'
GO

CREATE TABLE [dbo].[BaseScheduleLine]
(
	 [ERoleID]						[nvarchar](50)			NOT NULL
	,[BaseScheduleID]				[int]					NOT	NULL
	,[ShiftTimeID]					[int]					NOT NULL
	,[Count]						[int]		DEFAULT 0
	,CONSTRAINT [pk_ERoleID_BaseScheduleID]	PRIMARY KEY([ERoleID] ASC,[BaseScheduleID] ASC)
	,CONSTRAINT [fk_ERole_BaseScheduleLine_RoleID] FOREIGN KEY ([ERoleID])
		REFERENCES [ERole]([ERoleID])
	,CONSTRAINT [fk_BaseSchedule_BaseScheduleLine_BaseScheduleID] FOREIGN KEY([BaseScheduleID])
		REFERENCES [BaseSchedule]([BaseScheduleID])
	,CONSTRAINT [fk_ShiftTime_BaseScheduleLine_ShiftTimeID]	FOREIGN KEY([ShiftTimeID])
		REFERENCES [ShiftTime]([ShiftTimeID])
)
GO

/*
Created by: Matt Deaton
Date: 2020-02-28
Comment: Table for Donor Information 
*/
PRINT '' PRINT '*** Creating Donor Table'
GO

CREATE TABLE [dbo].[Donor](
	[DonorID]				[int]IDENTITY(1000,1)			NOT NULL,
	[FirstName]				[nvarchar](25)					NOT NULL DEFAULT 'Anonymous',
	[LastName]				[nvarchar](25),
	[Active]				[bit]							NOT NULL DEFAULT 1,
	CONSTRAINT [pk_DonorID] PRIMARY KEY([DonorID] ASC)
)
GO

/*
Created by: Matt Deaton
Date: 2020-02-28
Comment: Table for Donations
*/
PRINT '' PRINT '*** Creating Donations Table'
GO

CREATE TABLE [dbo].[Donations](
	[DonationID]			[int]IDENTITY(1000,1)			NOT NULL,
	[DonorID]				[int]							NOT NULL,
	[TypeOfDonation]		[nvarchar](100)					NOT NULL,
	[DateOfDonation]		[datetime]						NOT NULL,
	[DonationAmount]		[decimal](9,2)					NULL,
	CONSTRAINT [pk_DonationID] PRIMARY KEY([DonationID] ASC),
	CONSTRAINT [fk_donations_DonorID] FOREIGN KEY([DonorID])
		REFERENCES[Donor]([DonorID])
)
GO

/*
Created by: Matt Deaton
Date: 2020-02-28
Comment: Table for DonationItem
*/
PRINT '' PRINT '*** Creating Donation Item Table'
GO

CREATE TABLE [dbo].[DonationItem](
	[DonationID]			[int]								NOT NULL,
	[ItemID]				[int]								NOT NULL,
	CONSTRAINT [pk_DonationID_ItemID] PRIMARY KEY([DonationID] ASC, [ItemID] ASC),
	CONSTRAINT [fk_Donations_DonationID] FOREIGN KEY([DonationID]) 
		REFERENCES [Donations]([DonationID]),
	CONSTRAINT [fk_Item_ItemID] FOREIGN KEY([ItemID]) 
		REFERENCES [Item]([ItemID]) ON UPDATE CASCADE
)
GO

/*
Created by: Jesse Tomash
Date: 3/10/2020
Comment: Order table
*/
DROP TABLE IF EXISTS [dbo].[orders]
GO
print '' print '*** Creating Order Table'
GO
CREATE TABLE [dbo].[orders] (
	[OrderID]					[int] IDENTITY(100000, 1) 	NOT NULL,
	[UserID]				    [int]						NOT NULL,
	[Active]					[BIT] 						NOT NULL DEFAULT 1,
	
	CONSTRAINT [pk_OrderID] PRIMARY KEY([OrderID] ASC),
	CONSTRAINT [fk_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID])
)
GO

/*
Created by: Jesse Tomash
Date: 3/30/2020
Comment: Special Order table
*/
DROP TABLE IF EXISTS [dbo].[specialorders]
GO
print '' print '*** Creating Special Order Table'
GO
CREATE TABLE [dbo].[specialorders] (
	[SpecialOrderID]			[int] IDENTITY(100000, 1) 	NOT NULL,
	[UserID]					[int]						NOT NULL,
	[Active]					[bit] 						NOT NULL DEFAULT 1,
	
	CONSTRAINT [pk_SpecialOrderID] PRIMARY KEY([SpecialOrderID] ASC),
	CONSTRAINT [fk_SpecialOrderUserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID])
)
GO

/*
Created by: Jaeho Kim
Date: 03/08/2020
Comment: Creating Sales Tax History Table.
*/
PRINT ''  PRINT '*** Creating Table SalesTaxHistory'
GO
CREATE TABLE [dbo].[SalesTaxHistory](
	[ZipCode]			[nvarchar](50) 		Not Null,
	[SalesTaxDate] 		[DateTime]			Not Null,
	[TaxRate] 			[decimal](10,5)		NOT Null,
	CONSTRAINT [pk_SalesTaxHistory_ZipCode] PRIMARY KEY ([ZipCode] ASC, [SalesTaxDate] ASC)
)
GO

/*
Created by: Rasha Mohammed
Date: 3/27/2020
Comment: Create Picture table
*/
DROP TABLE IF EXISTS [dbo].[Picture]
GO
print '' print '*** Creating Picture table'
GO
/*
CREATE TABLE [dbo].[Picture]
(
   [PictureID] 	 	[INT] 		 		NOT NULL  PRIMARY KEY,
   [ProductID] 		[NVARCHAR](13)		NOT NULL,
   [ImagePath] 		[NVARCHAR](MAX)		NOT NULL,
	CONSTRAINT [fk_Picture_ProductID] FOREIGN KEY ([ProductID])
		REFERENCES [dbo].[Product]([ProductID]) 
)
*/
CREATE TABLE [dbo].[Picture]
(
	[PictureID]			[int]	IDENTITY	NOT NULL	PRIMARY KEY,
	[ProductID]			[nvarchar](13)		NOT NULL,
	[PictureData]		[varbinary](MAX)	NOT NULL,
	[PictureMimeType]	[nvarchar](50)		NOT NULL,
	CONSTRAINT [fk_Picture_ProductID] FOREIGN KEY ([ProductID])
		REFERENCES [dbo].[Product]([ProductID])
)
GO

/*
Created by: Brandyn T. Coverdill
Date: 2020-04-07
Comment: Table for Reporting Damaged or Missing Items from the Shelf.
*/
DROP TABLE IF EXISTS [dbo].[ItemReport]
GO
print '' print '*** Creating ItemReport Table'
GO
CREATE TABLE [dbo].[ItemReport](
	[ItemID]		[int]				NOT NULL,
	[ItemQuantity]	[int]				NOT NULL,
	[Report]		[nvarchar](250)		NOT NULL,
	CONSTRAINT [fk_ItemReport_ItemID] FOREIGN KEY([ItemID])
		REFERENCES [Item]([ItemID])
)
GO

/*
Created by: Ryan Morganti
Date: 2020/03/19
Comment: JobListing Table to store open positions at Pet Universe
*/
DROP TABLE IF EXISTS [dbo].[JobListing]
GO
print '' print '*** creating JobListing table'
GO
CREATE TABLE [dbo].[JobListing] (
	[JobListingID]			[int] IDENTITY(100000, 1)	NOT NULL,
	[Position]				[nvarchar](50)				NOT NULL,
	[Benefits]				[nvarchar](250)				NOT NULL,
	[Requirements]			[nvarchar](250)				NOT NULL,
	[StartingWage]			[decimal](10,2)						NOT NULL,
	[Responsibilities]		[nvarchar](750)				NOT NULL,
	[Active]				[bit]						NOT NULL DEFAULT 1,
	CONSTRAINT [pk_JobListing_JobListingID] PRIMARY KEY([JobListingID] ASC)
)
GO

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Table holding the schedule Start and End dates
*/
DROP TABLE IF EXISTS [dbo].[schedule]
GO
PRINT '' PRINT '*** Creating schedule table'
GO
CREATE TABLE [dbo].[schedule] (
	[ScheduleID]	[int]IDENTITY(1000000,1)	NOT NULL,
	[StartDate]		[date]						NOT NULL,
	[EndDate]		[date]						NOT NULL,
	CONSTRAINT [pk_ScheduleID] PRIMARY KEY ([ScheduleID] ASC)
)
GO

/*
Created by: Lane Sandburg
Date: 3/20/2020
Comment: Availability table
*/
DROP TABLE IF EXISTS [dbo].[Availability]
GO
print '' print '** Creating Availability table'
GO
CREATE TABLE [dbo].[Availability] (
    [AvailabilityID]            [int] IDENTITY(100000, 1)     NOT NULL,
    [UserID]                [int]                         NOT NULL,
    [DayOfWeek]                 [Nvarchar](9)                 NOT NULL,
    [StartTime]                 [Nvarchar](20)                NOT NULL,
    [EndTime]                   [Nvarchar](20)                NOT NULL,
    [Active]                    [BIT]                         NOT NULL DEFAULT 1

    CONSTRAINT [pk_AvailabilityID] PRIMARY KEY([AvailabilityID] ASC),
    CONSTRAINT [fk_Availability_UserID] FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User] (UserID)
)
GO

/*
Created by: Kaleb Bachert
Date: 3/31/2020
Comment: Table that holds each scheduled Shift
*/
DROP TABLE IF EXISTS [dbo].[shift]
GO
PRINT '' PRINT '*** Creating Shift table'
GO
CREATE TABLE [dbo].[shift] (
	[ShiftID]				[int]IDENTITY(1000000,1)	NOT NULL,
	[ShiftTimeID]			[int]						NOT NULL,
	[ScheduleID]			[int]						NOT NULL,
	[Date]					[date]						NOT NULL,
	[UserID]				[int]			  			NOT NULL,
	[ERoleID]				[nvarchar](50)				NOT NULL,
	CONSTRAINT [pk_ShiftID] PRIMARY KEY ([ShiftID] ASC),
	CONSTRAINT [fk_shift_shiftTimeID] FOREIGN KEY([ShiftTimeID])
		REFERENCES [shiftTime]([ShiftTimeID]) ON UPDATE CASCADE,
	CONSTRAINT [fk_shift_ScheduleD] FOREIGN KEY ([ScheduleID])
		REFERENCES [schedule]([ScheduleID]),
	CONSTRAINT [fk_shift_UserID] FOREIGN KEY ([UserID])
		REFERENCES [user]([UserID]) ON UPDATE CASCADE,
	CONSTRAINT [fk_shift_RoleID] FOREIGN KEY ([ERoleID])
		REFERENCES [eRole]([ERoleID])
)
GO

/*
Created by: Kaleb Bachert
Date: 3/6/2020
Comment: Table that holds each submitted schedule change request
*/
DROP TABLE IF EXISTS [dbo].[scheduleChangeRequest]
GO
PRINT '' PRINT '*** Creating scheduleChangeRequest table'
GO
CREATE TABLE [dbo].[scheduleChangeRequest] (
	[ScheduleChangeRequestID]		[int]IDENTITY(1000000,1)	NOT NULL,
	[ShiftID]						[int]						NOT NULL,
	[ApprovalDate]					[datetime]						NULL,
	[ApprovingEmployeeID]			[int]							NULL,
	[RequestID]						[int]						NOT NULL,
	CONSTRAINT [pk_ScheduleChangeRequestID] PRIMARY KEY ([ScheduleChangeRequestID] ASC),
	CONSTRAINT [fk_scheduleChangeRequest_ShiftID] FOREIGN KEY ([ShiftID])
		REFERENCES [shift]([ShiftID]),
	CONSTRAINT [fk_scheduleChangeRequest_RequestID] FOREIGN KEY ([RequestID])
		REFERENCES [request]([RequestID]),
	CONSTRAINT [fk_scheduleChangeRequest_ApprovingEmployeeID] FOREIGN KEY ([ApprovingEmployeeID])
		REFERENCES [user]([UserID])
)
GO

/*
Created by: Kaleb Bachert
Date: 4/2/2020
Comment: Table that holds Active Time Off, so people aren't 
		 scheduled when they should have Time Off
*/
DROP TABLE IF EXISTS [dbo].[activeTimeOff]
GO
PRINT '' PRINT '*** Creating ActiveTimeOff table'
GO
CREATE TABLE [dbo].[activeTimeOff] (
	[TimeOffID]			[int]IDENTITY(1000000, 1)	NOT NULL,
	[UserID]			[int]						NOT NULL,
	[StartDate]			[Date]						NOT NULL,
	[EndDate]			[Date]						NOT NULL,
	CONSTRAINT [pk_TimeOffID] PRIMARY KEY ([TimeOffID] ASC),
	CONSTRAINT [fk_activeTimeOff_UserID] FOREIGN KEY ([UserID])
		REFERENCES [user]([UserID])
)
GO

/*
Created by: Jordan Lindo
Date: 04/11/2020
Comment: Table for ScheduleHours
*/
DROP TABLE IF EXISTS [dbo].[ScheduleHours]
GO

print '' print '** Creating ScheduleHours table'
GO

CREATE TABLE [dbo].[ScheduleHours]
(
    [ScheduleID]                [int]                                    NOT NULL,
    [UserID]                    [int]                                    NOT NULL,
    [HoursFirstWeek]            [decimal]            DEFAULT 0           NOT NULL,
    [HoursSecondWeek]           [decimal]            DEFAULT 0           NOT NULL,
    CONSTRAINT [pk_ScheduleID_UserID] PRIMARY KEY([ScheduleID] ASC,[UserID] ASC),
    CONSTRAINT [fk_ScheduleID_ScheduleHours] FOREIGN KEY ([ScheduleID])
        REFERENCES [Schedule]([ScheduleID]),
    CONSTRAINT [fk_UserID_ScheduleHours] FOREIGN KEY ([UserID])
        REFERENCES [User]([UserID])
)
GO

/*
 Application Tables used for creating the application
 Created By: Derek Talor
*/ 
DROP TABLE IF EXISTS [dbo].[Application]
GO
PRINT '' PRINT '*** Creating Application Table'
GO
CREATE TABLE [dbo].[Application](
	[ApplicationID]			[int]IDENTITY(100000, 1)	NOT NULL,
	[ApplicantID]			[int]						NOT NULL,
	[JobListingID]			[int]						NOT NULL,
	[SubmissionDate]		[datetime]					NOT NULL,
	[Status]				[nvarchar](50)				NOT NULL,
	CONSTRAINT [pk_Application_ApplicationID_ApplicantID] PRIMARY KEY([ApplicationID] ASC),
	CONSTRAINT [fk_Application_ApplicantID] FOREIGN KEY([ApplicantID]) REFERENCES [Applicant]([ApplicantID]) ON UPDATE CASCADE, 
	CONSTRAINT [fk_Application_JobListingID] FOREIGN KEY([JobListingID]) REFERENCES [JobListing]([JobListingID])
)
GO

/*
 Application Tables used for creating the application
 Created By: Derek Talor
*/ 
DROP TABLE IF EXISTS [dbo].[ApplicationEducation]
GO
PRINT '' PRINT '*** Creating ApplicationEducation Table'
GO
CREATE TABLE [dbo].[ApplicationEducation](
	[ApplicationID]			[int]						NOT NULL,
	[SchoolName]			[nvarchar](75)				NOT NULL,
	[City]					[nvarchar](50)				NOT NULL,
	[State]					[char](2)					NOT NULL,
	[LevelAchieved]			[nvarchar](100)				NOT NULL,
	CONSTRAINT [pk_ApplicationID_SchoolName] PRIMARY KEY([ApplicationID] ASC, [SchoolName] ASC),
	CONSTRAINT [fk_ApplicationEducation_ApplicationID] FOREIGN KEY([ApplicationID]) REFERENCES [Application]([ApplicationID])
)
GO

/*
 Application Tables used for creating the application
 Created By: Derek Talor
*/ 
DROP TABLE IF EXISTS [dbo].[ApplicationReference]
GO
PRINT '' PRINT '*** Creating ApplicationReference Table'
GO
CREATE TABLE [dbo].[ApplicationReference](
	[ReferenceID]			[nvarchar](75)				NOT NULL,
	[ApplicationID]			[int]						NOT NULL,
	[PhoneNumber]			[nvarchar](11)				NOT NULL,
	[EmailAddress]			[nvarchar](250)				NOT NULL,
	[Relationship]			[nvarchar](75)				NOT NULL,
	CONSTRAINT [pk_ReferenceID_ApplicationID] PRIMARY KEY([ReferenceID] ASC, [ApplicationID] ASC),
	CONSTRAINT [fk_ApplicationReference_ApplicationID] FOREIGN KEY([ApplicationID]) REFERENCES [Application]([ApplicationID])
)
GO

/*
 Application Tables used for creating the application
 Created By: Derek Talor
*/ 
DROP TABLE IF EXISTS [dbo].[ApplicationResume]
GO
PRINT '' PRINT '*** Creating ApplicationResume Table'
GO
CREATE TABLE [dbo].[ApplicationResume](
	[ResumeID]				[int]IDENTITY(100000, 1)	NOT NULL,
	[ApplicationID]			[int]						NOT NULL,
	[FilePath]				[nvarchar](250)				NOT NULL,
	CONSTRAINT [pk_ResumeID_ApplicationID] PRIMARY KEY([ResumeID] ASC, [ApplicationID] ASC),
	CONSTRAINT [fk_ApplicationResume_ApplicationID] FOREIGN KEY([ApplicationID]) REFERENCES [Application]([ApplicationID])
)
GO

/*
 Application Tables used for creating the application
 Created By: Derek Talor
*/ 
DROP TABLE IF EXISTS [dbo].[ApplicationSkill]
GO
PRINT '' PRINT '*** Creating ApplicationSkill Table'
GO
CREATE TABLE [dbo].[ApplicationSkill](
	[ApplicationSkillID]		[nvarchar](75)				NOT NULL,
	[ApplicationID]				[int]						NOT NULL,
	[Description]				[nvarchar](200)				NOT NULL,
	CONSTRAINT [pk_ApplicationSkill] PRIMARY KEY([ApplicationSkillID] ASC, [ApplicationID] ASC),
	CONSTRAINT [fk_ApplicationSkill_ApplicationID] FOREIGN KEY([ApplicationID]) REFERENCES [Application]([ApplicationID])
)
GO

/*
 Application Tables used for creating the application
 Created By: Derek Talor
*/ 
DROP TABLE IF EXISTS [dbo].[PreviousExperience]
GO
PRINT '' PRINT '*** Creating PreviousExperience Table'
GO
CREATE TABLE [dbo].[PreviousExperience](
	[ApplicationID]			[int]						NOT NULL,
	[PreviousWorkName]		[nvarchar](75)				NOT NULL,
	[City]					[nvarchar](50)				NOT NULL,
	[State]					[char](2)					NOT NULL,
	[Type]					[nvarchar](50)				NOT NULL,
	CONSTRAINT [pk_PreviousWorkName_ApplicationID_PreviousWorkName] PRIMARY KEY([ApplicationID] ASC, [PreviousWorkName] ASC),
	CONSTRAINT [fk_PreviousExperience_ApplicationID] FOREIGN KEY([ApplicationID]) REFERENCES [Application]([ApplicationID])
)
GO

/*
 Application Tables used for creating the application
 Created By: Derek Talor
*/ 
DROP TABLE IF EXISTS [dbo].[ApplicationAvailability]
GO
PRINT '' PRINT '*** Creating ApplicationAvailability Table'
GO
CREATE TABLE [dbo].[ApplicationAvailability](
	[ApplicationID]			[int]						NOT NULL,
	[DayOfWeek]				[nvarchar](12)				NOT NULL,
	[StartTime]				[time]						NOT NULL,
	[EndTime]				[time]						NOT NULL,
	CONSTRAINT [pk_ApplicationAvailability_ApplicationID_DayOfWeek] PRIMARY KEY([ApplicationID] ASC, [DayOfWeek] ASC),
	CONSTRAINT [fk_ApplicationAvailability_ApplicationID] FOREIGN KEY([ApplicationID]) REFERENCES [Application]([ApplicationID])
)
GO

/*
 Application Tables used for creating the application
 Created By: Derek Talor
*/ 
DROP TABLE IF EXISTS [dbo].[BackgroundCheck]
GO
PRINT '' PRINT '*** Creating BackgroundCheck Table'
GO
CREATE TABLE [dbo].[BackgroundCheck](
	[ApplicationID]			[int]						NOT NULL,
	[EmployeeID]			[int]						NOT NULL,
	[DatePerformed]			[datetime]					NOT NULL,
	[Notes]					[nvarchar](1000)			NOT NULL,
	CONSTRAINT [pk_BackgroundCheck_ApplicationID_EmployeeID] PRIMARY KEY([ApplicationID] ASC, [EmployeeID] ASC),
	CONSTRAINT [fk_BackgroundCheck_ApplicationID] FOREIGN KEY([ApplicationID]) REFERENCES [Application]([ApplicationID]),
	CONSTRAINT [fk_BackgroundCheck_EmployeeID] FOREIGN KEY([EmployeeID]) REFERENCES [User]([UserID])
)
GO

/*
 Application Tables used for creating the application
 Created By: Derek Talor
*/ 
DROP TABLE IF EXISTS [dbo].[HomeCheck]
GO
PRINT '' PRINT '*** Creating HomeCheck Table'
GO
CREATE TABLE [dbo].[HomeCheck](
	[ApplicationID]			[int]						NOT NULL,
	[EmployeeID]			[int]						NOT NULL,
	[DatePerformed]			[datetime],
	[Notes]					[nvarchar](1000),
	CONSTRAINT [pk_HomeCheck_ApplicationID_EmployeeID] PRIMARY KEY([ApplicationID] ASC, [EmployeeID] ASC),
	CONSTRAINT [fk_HomeCheck_ApplicationID] FOREIGN KEY([ApplicationID]) REFERENCES [Application]([ApplicationID]),
	CONSTRAINT [fk_HomeCheck_EmployeeID] FOREIGN KEY([EmployeeID]) REFERENCES [User]([UserID])
)
GO

/*
 Application Tables used for creating the application
 Created By: Derek Talor
*/ 
DROP TABLE IF EXISTS [dbo].[Interview]
GO
PRINT '' PRINT '*** Creating Interview Table'
GO
CREATE TABLE [dbo].[Interview](
	[ApplicationID]			[int]						NOT NULL,
	[EmployeeID]			[int]						NOT NULL,
	[DatePerformed]			[datetime]					NOT NULL,
	[Notes]					[nvarchar](1000)			NOT NULL,
	CONSTRAINT [pk_Interview_ApplicationID_EmployeeID] PRIMARY KEY([ApplicationID] ASC, [EmployeeID] ASC),
	CONSTRAINT [fk_Interview_ApplicationID] FOREIGN KEY([ApplicationID]) REFERENCES [Application]([ApplicationID]),
	CONSTRAINT [fk_Interview_EmployeeID] FOREIGN KEY([EmployeeID]) REFERENCES [User]([UserID])
)
GO

/*
 ******************************* Create Procedures *****************************
*/
PRINT '' PRINT '******************* Create Procedures *********************'
GO

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

/*
Created by: Zach Behrensmeyer
Date: 2/6/2020
Comment: Sproc to authenticate user
*/
DROP PROCEDURE IF EXISTS [sp_authenticate_user]
GO
PRINT '' PRINT '*** Creating sp_authenticate_user'
GO
CREATE PROCEDURE [sp_authenticate_user]
(
@Email 			[nvarchar](250),
@PasswordHash	[nvarchar](100)
)
AS
BEGIN
    SELECT COUNT([UserID])
    FROM 	[dbo].[User]
    WHERE 	[Email] = @Email
    AND 	[PasswordHash] = @PasswordHash
    AND 	[Active] = 1
END
GO

/*
Created by: Zach Behrensmeyer
Date: 2/6/2020
Comment: Sproc to find user by email
*/
DROP PROCEDURE IF EXISTS [sp_select_user_by_email]
GO
PRINT '' PRINT '*** Creating sp_select_user_by_email'
GO
CREATE PROCEDURE [sp_select_user_by_email]
(
	@Email 			[nvarchar](250)
)
AS
BEGIN
	SELECT 	[UserID], [FirstName], [LastName], [PhoneNumber]
	FROM 	[dbo].[User]
	WHERE 	[Email] = @Email
END
GO

/*
Created by: Zach Behrensmeyer
Date: 2/6/2020
Comment: Sproc to select roles of employee
*/
DROP PROCEDURE IF EXISTS [sp_select_roles_by_userID]
GO
PRINT '' PRINT '*** Creating sp_select_roles_by_userID'
GO
CREATE PROCEDURE [sp_select_roles_by_userID]
(
	@UserID 			[int]
)
AS
BEGIN
	SELECT 	[ERoleID]
	FROM 	[dbo].[UserERole]
	WHERE 	[UserID] = @UserID
END
GO


/*
Created by: Zach Behrensmeyer
Date: 2/11/2020
Comment: Sproc to pull list of login logs
*/
DROP PROCEDURE IF EXISTS [sp_get_login_logout_logs]
GO
PRINT '' PRINT '*** sp_get_login_logout_logs'
GO
CREATE PROCEDURE [sp_get_login_logout_logs]
AS
BEGIN
	SELECT 	[Id], [Date], [Level], [Message]
	FROM Logging
	where message like '%Successfully logged in%' or message like '%Someone failed to login using email%' or message like '%has logged out%'
END
GO

/*
Created by: Daulton Schilling
Date: 2/11/2020
Comment: Sproc to INSERT Animal Activity
*/
DROP PROCEDURE IF EXISTS [sp_insert_AnimalActivity]
GO
PRINT '' PRINT '*** sp_insert_AnimalActivity'
GO
CREATE PROCEDURE [sp_insert_AnimalActivity]
(
	@AnimalActivityID	    [int]			   ,
	@AnimalID	        	[int]			   ,
	@UserID		    		[int]			   ,
	@AnimalActivityTypeID  	[nvarchar](100)	   ,
	@ActivityDateTime   	[DateTime]
)
AS
BEGIN
	INSERT INTO [dbo].[AnimalActivity]
		([AnimalActivityID],[AnimalID],[AnimalActivityTypeID],[ActivityDateTime])
	VALUES
		(@AnimalActivityID,@AnimalID,@AnimalActivityTypeID,@ActivityDateTime)
	RETURN SCOPE_IDENTITY()
END


/*
Created by: Daulton Schilling
Date: 2/11/2020
Comment: Sproc to INSERT Animal Activity type
*/
DROP PROCEDURE IF EXISTS [sp_insert_AnimalActivityType]
GO
PRINT '' PRINT '*** sp_insert_AnimalActivityType'
GO
CREATE PROCEDURE [sp_insert_AnimalActivityType]
(
	@AnimalActivityTypeID			[nvarchar](100),
	@ActivityNotes			        [nvarchar](MAX)
)
AS
BEGIN
	INSERT INTO [dbo].[AnimalActivityType]
		([AnimalActivityTypeID],[ActivityNotes])
	VALUES
		(@AnimalActivityTypeID ,@ActivityNotes)
	RETURN SCOPE_IDENTITY()
END
GO


/*
Created by: Chuck Baxter
Date: 2/11/2020
Comment: Sproc to INSERT Animal
*/
DROP PROCEDURE IF EXISTS [sp_insert_animal]
GO
PRINT '' PRINT'*** Creating sp_insert_animal'
GO

CREATE PROCEDURE [sp_insert_animal]
(
	@AnimalName			[nvarchar](100),
	@Dob				[nvarchar](100),
	@AnimalBreed		[nvarchar](100),
	@ArrivalDate		[nvarchar](100),
	@AnimalSpeciesID	[nvarchar](100)
)
AS
BEGIN
	INSERT INTO [dbo].[Animal]
		([AnimalName],[Dob],[AnimalBreed],[ArrivalDate],[AnimalSpeciesID])
	VALUES
		(@AnimalName, @Dob, @AnimalBreed, @ArrivalDate, @AnimalSpeciesID)
	RETURN SCOPE_IDENTITY()
END
GO

/*
Created by: Chuck Baxter
Date: 2/11/2020
Comment: Sproc to select active animals
*/
DROP PROCEDURE IF EXISTS [sp_select_active_animals]
GO
PRINT '' PRINT '*** Creating sp_select_active_animals'
GO
CREATE PROCEDURE [sp_select_active_animals]
(
	@Active		[bit]
)
AS
BEGIN
	SELECT [AnimalID],[AnimalName],[Dob],[AnimalBreed],[ArrivalDate],
	[CurrentlyHoused],[Adoptable],[Active],[AnimalSpeciesID]
	FROM [dbo].[Animal]
	WHERE [Active] = @Active
	ORDER BY [AnimalID]
END
GO

/*
Created by: Carl Davis
Date: 2/11/2020
Comment: Sproc to INSERT facility maintenance
*/
DROP PROCEDURE IF EXISTS [sp_insert_facility_maintenance]
GO
PRINT '' PRINT '*** Creating sp_insert_facility_maintenance'
GO
CREATE PROCEDURE [sp_insert_facility_maintenance]
(
    @UserID                        	[int],
    @MaintenanceName            	[nvarchar](50),
    @MaintenanceInterval         	[nvarchar](20),
    @MaintenanceDescription     	[nvarchar](250)
)
AS
BEGIN
    INSERT INTO [dbo].[FacilityMaintenance]
        ([UserID], [MaintenanceName], [MaintenanceInterval], [MaintenanceDescription])
    VALUES
        (@UserID, @MaintenanceName, @MaintenanceInterval, @MaintenanceDescription)
    RETURN SCOPE_IDENTITY()

END
GO

/*
Created by: Carl Davis
Date: 2/14/2020
Comment: Sproc to select facility maintenance by id
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_maintenance_by_id]
GO
PRINT '' PRINT '*** Creating sp_select_facility_maintenance_by_id'
GO
CREATE PROCEDURE [sp_select_facility_maintenance_by_id]
(
    @FacilityMaintenanceID                        	[int],
	@Active 										[bit]

)
AS
BEGIN
    SELECT [FacilityMaintenanceID], [UserID], [MaintenanceName],
            [MaintenanceInterval], [MaintenanceDescription], [Active]
    FROM [dbo].[FacilityMaintenance]
	WHERE [FacilityMaintenanceID] = @FacilityMaintenanceID
	AND [Active] = @Active

END
GO

/*
Created by: Carl Davis
Date: 2/14/2020
Comment: Sproc to select all facility maintenance
*/
DROP PROCEDURE IF EXISTS [sp_select_all_facility_maintenance]
GO
PRINT '' PRINT '*** Creating sp_select_all_facility_maintenance'
GO
CREATE PROCEDURE [sp_select_all_facility_maintenance]
(
	@Active			[bit]
)
AS
BEGIN
    SELECT [FacilityMaintenanceID], [UserID], [MaintenanceName],
            [MaintenanceInterval], [MaintenanceDescription], [Active]
    FROM [dbo].[FacilityMaintenance]
	WHERE [Active] = @Active
END
GO

/*
Created by: Carl Davis
Date: 2/14/2020
Comment: Sproc to select facility maintenance by user id
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_maintenance_by_user_id]
GO
PRINT '' PRINT '*** Creating sp_select_facility_maintenance_by_user_id'
GO
CREATE PROCEDURE [sp_select_facility_maintenance_by_user_id]
(
    @UserID                        	[int],
	@Active							[bit]
)
AS
BEGIN
    SELECT [FacilityMaintenanceID], [UserID], [MaintenanceName],
            [MaintenanceInterval], [MaintenanceDescription], [Active]
    FROM [dbo].[FacilityMaintenance]
	WHERE [UserID] = @UserID
		AND [Active] = @Active

END
GO

/*
Created by: Carl Davis
Date: 2/14/2020
Comment: Sproc to select facility maintenance by name
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_maintenance_by_name]
GO
PRINT '' PRINT '*** Creating sp_select_facility_maintenance_by_name'
GO
CREATE PROCEDURE [sp_select_facility_maintenance_by_name]
(
    @MaintenanceName                        	[nvarchar](50),
	@Active										[bit]
)
AS
BEGIN
    SELECT [FacilityMaintenanceID], [UserID], [MaintenanceName],
            [MaintenanceInterval], [MaintenanceDescription], [Active]
    FROM [dbo].[FacilityMaintenance]
	WHERE [MaintenanceName] = @MaintenanceName
	AND [Active] = @Active
END
GO

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

/*
Created by: Carl Davis
Date: 2/28/2020
Comment: Sproc to deactivate facility maintenance
*/
DROP PROCEDURE IF EXISTS [sp_deactivate_facility_maintenance]
GO
PRINT '' PRINT '*** Creating sp_deactivate_facility_maintenance'
GO
CREATE PROCEDURE [sp_deactivate_facility_maintenance]
(
	@FacilityMaintenanceID					[int]
)
AS
BEGIN
	UPDATE [dbo].[FacilityMaintenance]
	SET		[Active] = 0
	WHERE [FacilityMaintenanceID] = @FacilityMaintenanceID
	RETURN @@ROWCOUNT
END
GO

/*
Created by: Carl Davis
Date: 2/28/2020
Comment: Sproc to INSERT facility inspection
*/
DROP PROCEDURE IF EXISTS [sp_insert_facility_inspection]
GO
PRINT '' PRINT '*** Creating sp_insert_facility_inspection'
GO
CREATE PROCEDURE [sp_insert_facility_inspection]
(
    @UserID                        	[int],
    @InspectorName            		[nvarchar](150),
    @InspectionDate         		[date],
    @InspectionDescription     		[nvarchar](500)
)
AS
BEGIN
    INSERT INTO [dbo].[FacilityInspection]
        ([UserID], [InspectorName], [InspectionDate], [InspectionDescription])
    VALUES
        (@UserID, @InspectorName, @InspectionDate, @InspectionDescription)
    RETURN SCOPE_IDENTITY()

END
GO

/*
Created by: Carl Davis
Date: 3/11/2020
Comment: Sproc to select all facility inspections
*/
DROP PROCEDURE IF EXISTS [sp_select_all_facility_inspection]
GO
PRINT '' PRINT '*** Creating sp_select_all_facility_inspection'
GO
CREATE PROCEDURE [sp_select_all_facility_inspection]
(
	@InspectionCompleted			[bit]
)
AS
BEGIN
    SELECT [FacilityInspectionID], [UserID], [InspectorName],
            [InspectionDate], [InspectionDescription], [InspectionCompleted]
    FROM [dbo].[FacilityInspection]
	WHERE [InspectionCompleted] = @InspectionCompleted
END
GO

/*
Created by: Carl Davis
Date: 3/11/2020
Comment: Sproc to select facility inspection by id
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_inspection_by_id]
GO
PRINT '' PRINT '*** Creating sp_select_facility_inspection_by_id'
GO
CREATE PROCEDURE [sp_select_facility_inspection_by_id]
(
    @FacilityInspectionID                        	[int],
	@InspectionCompleted 							[bit]

)
AS
BEGIN
    SELECT [FacilityInspectionID], [UserID], [InspectorName],
            [InspectionDate], [InspectionDescription], [InspectionCompleted]
    FROM [dbo].[FacilityInspection]
	WHERE [FacilityInspectionID] = @FacilityInspectionID
	AND [InspectionCompleted] = @InspectionCompleted

END
GO

/*
Created by: Carl Davis
Date: 3/11/2020
Comment: Sproc to select facility inspection by user id
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_inspection_by_user_id]
GO
PRINT '' PRINT '*** Creating sp_select_facility_inspection_by_user_id'
GO
CREATE PROCEDURE [sp_select_facility_inspection_by_user_id]
(
    @UserID           								[int],
	@InspectionCompleted							[bit]
)
AS
BEGIN
    SELECT [FacilityInspectionID], [UserID], [InspectorName],
            [InspectionDate], [InspectionDescription], [InspectionCompleted]
    FROM [dbo].[FacilityInspection]
	WHERE [UserID] = @UserID
		AND [InspectionCompleted] = @InspectionCompleted

END
GO

/*
Created by: Carl Davis
Date: 3/11/2020
Comment: Sproc to select facility inspection by inspector name
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_inspection_by_inspector_name]
GO
PRINT '' PRINT '*** Creating sp_select_facility_inspection_by_inspector_name'
GO
CREATE PROCEDURE [sp_select_facility_inspection_by_inspector_name]
(
    @InspectorName                        	[nvarchar](50),
	@InspectionCompleted					[bit]
)
AS
BEGIN
    SELECT [FacilityInspectionID], [UserID], [InspectorName],
            [InspectionDate], [InspectionDescription], [InspectionCompleted]
    FROM [dbo].[FacilityInspection]
	WHERE [InspectorName] = @InspectorName
	AND [InspectionCompleted] = @InspectionCompleted
END
GO

/*
Created by: Carl Davis
Date: 3/13/2020
Comment: Sproc to update facility inspection
*/
DROP PROCEDURE IF EXISTS [sp_update_facility_inspection]
GO
print '' print '*** Creating sp_update_facility_inspection'
GO
CREATE PROCEDURE [sp_update_facility_inspection]
(
	@FacilityInspectionID          		[int],
    @OldUserID                        	[int],
    @OldInspectorName            		[nvarchar](50),
    @OldInspectionDate         			[date],
    @OldInspectionDescription    		[nvarchar](250),
	@OldInspectionComplete				[bit],
	@NewUserID                        	[int],
    @NewInspectorName           		[nvarchar](50),
    @NewInspectionDate         			[date],
    @NewInspectionDescription     		[nvarchar](250),
	@NewInspectionComplete				[bit]

)
AS
BEGIN
    UPDATE 	[dbo].[FacilityInspection]
	SET 	[UserID] = @NewUserID,
			[InspectorName] = @NewInspectorName,
			[InspectionDate] = @NewInspectionDate,
			[InspectionDescription] = @NewInspectionDescription,
			[InspectionCompleted] = @NewInspectionComplete
			
	WHERE   [FacilityInspectionID] = @FacilityInspectionID
		AND	[UserID] = @OldUserID
		AND	[InspectorName] = @OldInspectorName
		AND	[InspectionDate] = @OldInspectionDate
		AND	[InspectionDescription] = @OldInspectionDescription
		AND [InspectionCompleted] = @OldInspectionComplete
	 RETURN @@ROWCOUNT

END
GO

/*
Created by: Carl Davis
Date: 4/2/2020
Comment: Sproc to INSERT facility inspection item
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_facility_inspection_item]
GO
PRINT '' PRINT '*** Creating sp_INSERT_facility_inspection_item'
GO
CREATE PROCEDURE [sp_INSERT_facility_inspection_item]
(
	@ItemName            			[nvarchar](100),
    @UserID                        	[int],
    @FacilityInspectionID         	[int],
    @ItemDescription     			[nvarchar](500)
)
AS
BEGIN
    INSERT INTO [dbo].[FacilityInspectionItem]
        ([ItemName], [UserID], [FacilityInspectionID], [ItemDescription])
    VALUES
        (@ItemName, @UserID, @FacilityInspectionID, @ItemDescription)
    RETURN SCOPE_IDENTITY()

END
GO

/*
Created by: Carl Davis
Date: 4/2/2020
Comment: Sproc to select all facility inspection items
*/
DROP PROCEDURE IF EXISTS [sp_select_all_facility_inspection_item]
GO
PRINT '' PRINT '*** Creating sp_select_all_facility_inspection_item'
GO
CREATE PROCEDURE [sp_select_all_facility_inspection_item]
AS
BEGIN
    SELECT [FacilityInspectionItemID], [ItemName], [UserID], [FacilityInspectionID], [ItemDescription]
    FROM [dbo].[FacilityInspectionItem]
END
GO

/*
Created by: Carl Davis
Date: 4/2/2020
Comment: Sproc to select facility inspection item by id
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_inspection_item_by_id]
GO
PRINT '' PRINT '*** Creating sp_select_facility_inspection_item_by_id'
GO
CREATE PROCEDURE [sp_select_facility_inspection_item_by_id]
(
    @FacilityInspectionItemID                        	[int]
)
AS
BEGIN
    SELECT [FacilityInspectionItemID], [ItemName], [UserID],
            [FacilityInspectionID], [ItemDescription]
    FROM [dbo].[FacilityInspectionItem]
	WHERE [FacilityInspectionItemID] = @FacilityInspectionItemID

END
GO

/*
Created by: Carl Davis
Date: 4/2/2020
Comment: Sproc to select facility inspection item by facility inspection id
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_inspection_item_by_facility_inspection_id]
GO
PRINT '' PRINT '*** Creating sp_select_facility_inspection_item_by_facility_inspection_id'
GO
CREATE PROCEDURE [sp_select_facility_inspection_item_by_facility_inspection_id]
(
    @FacilityInspectionID                        	[int]
)
AS
BEGIN
    SELECT [FacilityInspectionItemID], [ItemName], [UserID],
            [FacilityInspectionID], [ItemDescription]
    FROM [dbo].[FacilityInspectionItem]
	WHERE [FacilityInspectionID] = @FacilityInspectionID

END
GO

/*
Created by: Carl Davis
Date: 4/2/2020
Comment: Sproc to select facility inspection item by user id
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_inspection_item_by_user_id]
GO
PRINT '' PRINT '*** Creating sp_select_facility_inspection_item_by_user_id'
GO
CREATE PROCEDURE [sp_select_facility_inspection_item_by_user_id]
(
    @UserID           								[int]
)
AS
BEGIN
    SELECT [FacilityInspectionItemID], [ItemName], [UserID],
            [FacilityInspectionID], [ItemDescription]
    FROM [dbo].[FacilityInspectionItem]
	WHERE [UserID] = @UserID
END
GO

/*
Created by: Carl Davis
Date: 4/2/2020
Comment: Sproc to select facility inspection item by item name
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_inspection_item_by_item_name]
GO
PRINT '' PRINT '*** Creating sp_select_facility_inspection_item_by_item_name'
GO
CREATE PROCEDURE [sp_select_facility_inspection_item_by_item_name]
(
    @ItemName					[nvarchar](100)
)
AS
BEGIN
    SELECT [FacilityInspectionItemID], [ItemName], [UserID],
            [FacilityInspectionID], [ItemDescription]
    FROM [dbo].[FacilityInspectionItem]
	WHERE [ItemName] = @ItemName
END
GO

/*
Created by: Carl Davis
Date: 4/2/2020
Comment: Sproc to update facility inspection item
*/
DROP PROCEDURE IF EXISTS [sp_update_facility_inspection_item]
GO
print '' print '*** Creating sp_update_facility_inspection_item'
GO
CREATE PROCEDURE [sp_update_facility_inspection_item]
(
	@FacilityInspectionItemID          	[int],
	@OldItemName            			[nvarchar](100),
    @OldUserID                        	[int],
    @OldFacilityInspectionID         	[int],
    @OldItemDescription    				[nvarchar](500),
	@NewItemName		           		[nvarchar](100),
	@NewUserID                        	[int],
    @NewFacilityInspectionID        	[int],
    @NewItemDescription     		[nvarchar](500)

)
AS
BEGIN
    UPDATE 	[dbo].[FacilityInspectionItem]
	SET 	[ItemName] = @NewItemName,
			[UserID] = @NewUserID,
			[FacilityInspectionID] = @NewFacilityInspectionID,
			[ItemDescription] = @NewItemDescription
			
	WHERE   [FacilityInspectionItemID] = @FacilityInspectionItemID
		AND	[ItemName] = @OldItemName
		AND	[UserID] = @OldUserID
		AND	[FacilityInspectionID] = @OldFacilityInspectionID
		AND	[ItemDescription] = @OldItemDescription
	 RETURN @@ROWCOUNT

END
GO

/*
Created by: Carl Davis
Date: 4/9/2020
Comment: Sproc to INSERT facility task
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_facility_task]
GO
PRINT '' PRINT '*** Creating sp_INSERT_facility_task'
GO
CREATE PROCEDURE [sp_INSERT_facility_task]
(
	@FacilityTaskName				[nvarchar](100),
    @UserID                        	[int],
	@StartDate						[date],
	@CompletionDate					[date],
    @FacilityTaskNotes            	[nvarchar](500)
)
AS
BEGIN
    INSERT INTO [dbo].[FacilityTask]
        ([FacilityTaskName], [UserID], [StartDate], [CompletionDate], [FacilityTaskNotes])
    VALUES
        (@FacilityTaskName, @UserID, @StartDate, @CompletionDate, @FacilityTaskNotes)
    RETURN SCOPE_IDENTITY()

END
GO

/*
Created by: Carl Davis
Date: 4/9/2020
Comment: Sproc to select all facility tasks
*/
DROP PROCEDURE IF EXISTS [sp_select_all_facility_tasks]
GO
PRINT '' PRINT '*** Creating sp_select_all_facility_tasks'
GO
CREATE PROCEDURE [sp_select_all_facility_tasks]
(
	@TaskCompleted  			[bit]
)
AS
BEGIN
    SELECT [FacilityTaskID], [FacilityTaskName], [UserID], [StartDate], [CompletionDate], [FacilityTaskNotes], [TaskCompleted]
    FROM [dbo].[FacilityTask]
	WHERE [TaskCompleted] = @TaskCompleted
END
GO

/*
Created by: Carl Davis
Date: 4/9/2020
Comment: Sproc to select facility inspection task by id
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_task_by_id]
GO
PRINT '' PRINT '*** Creating sp_select_facility_task_by_id'
GO
CREATE PROCEDURE [sp_select_facility_task_by_id]
(
    @FacilityTaskID                        	[int],
	@TaskCompleted  						[bit]
)
AS
BEGIN
    SELECT [FacilityTaskID], [FacilityTaskName], [UserID], [StartDate], [CompletionDate], [FacilityTaskNotes], [TaskCompleted]
    FROM [dbo].[FacilityTask]
	WHERE [FacilityTaskID] = @FacilityTaskID
	AND [TaskCompleted] = @TaskCompleted

END
GO

/*
Created by: Carl Davis
Date: 4/9/2020
Comment: Sproc to select facility task by name
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_task_by_name]
GO
PRINT '' PRINT '*** Creating sp_select_facility_task_by_name'
GO
CREATE PROCEDURE [sp_select_facility_task_by_name]
(
    @FacilityTaskName						[nvarchar](100),
	@TaskCompleted  						[bit]
)
AS
BEGIN
    SELECT [FacilityTaskID], [FacilityTaskName], [UserID], [StartDate], [CompletionDate], [FacilityTaskNotes], [TaskCompleted]
    FROM [dbo].[FacilityTask]
	WHERE [FacilityTaskName] = @FacilityTaskName
	AND [TaskCompleted] = @TaskCompleted

END
GO

/*
Created by: Carl Davis
Date: 4/9/2020
Comment: Sproc to select facility task by user id
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_task_by_user_id]
GO
PRINT '' PRINT '*** Creating sp_select_facility_task_by_user_id'
GO
CREATE PROCEDURE [sp_select_facility_task_by_user_id]
(
    @UserID           								[int],
	@TaskCompleted  								[bit]
)
AS
BEGIN
    SELECT [FacilityTaskID], [FacilityTaskName], [UserID], [StartDate], [CompletionDate], [FacilityTaskNotes], [TaskCompleted]
    FROM [dbo].[FacilityTask]
	WHERE [UserID] = @UserID
	AND [TaskCompleted] = @TaskCompleted
END
GO

/*
Created by: Carl Davis
Date: 4/15/2020
Comment: Sproc to update facility task
*/
DROP PROCEDURE IF EXISTS [sp_update_facility_task]
GO
print '' print '*** Creating sp_update_facility_task'
GO
CREATE PROCEDURE [sp_update_facility_task]
(
	@FacilityTaskID          		[int],
    @OldFacilityTaskName			[nvarchar](100),
	@OldUserID						[int],
	@OldStartDate					[date],
	@OldCompletionDate				[date],
	@OldFacilityTaskNotes			[nvarchar](500),
	@OldTaskCompleted				[bit],
	@NewFacilityTaskName			[nvarchar](100),
	@NewUserID						[int],
	@NewStartDate					[date],
	@NewCompletionDate				[date],
	@NewFacilityTaskNotes			[nvarchar](500),
	@NewTaskCompleted				[bit]

)
AS
BEGIN
    UPDATE 	[dbo].[FacilityTask]
	SET 	[FacilityTaskName] = @NewFacilityTaskName,
			[UserID] = @NewUserID,
			[StartDate] = @NewStartDate,
			[CompletionDate] = @NewCompletionDate,
			[FacilityTaskNotes] = @NewFacilityTaskNotes,
			[TaskCompleted] = @NewTaskCompleted
			
	WHERE   [FacilityTaskID] = @FacilityTaskID
		AND	[FacilityTaskName] = @OldFacilityTaskName
		AND	[UserID] = @OldUserID
		AND	[StartDate] = @OldStartDate
		AND	[CompletionDate] = @OldCompletionDate
		AND [FacilityTaskNotes] = @OldFacilityTaskNotes
		AND [TaskCompleted] = @OldTaskCompleted
	 RETURN @@ROWCOUNT

END
GO

/*
Created by: Carl Davis
Date: 4/15/2020
Comment: Sproc to delete facility task
*/
DROP PROCEDURE IF EXISTS [sp_delete_facility_task]
GO
print '' print '*** Creating sp_delete_facility_task'
GO
CREATE PROCEDURE [sp_delete_facility_task]
(
	@FacilityTaskID          		[int]
)
AS
BEGIN
    DELETE 
	FROM [dbo].[FacilityTask]
	WHERE [FacilityTaskID] = @FacilityTaskID
	RETURN @@ROWCOUNT

END
GO

/*
Created by: Ethan Murphy
Date: 2/11/2020
Comment: Sproc to Select all vet appointments
*/
DROP PROCEDURE IF EXISTS [sp_select_all_vet_appointments]
GO
PRINT '' PRINT '*** Creating sp_select_all_vet_appointments'
GO
CREATE PROCEDURE [sp_select_all_vet_appointments]
AS
BEGIN
    SELECT [AnimalVetAppointmentID], [Animal].[AnimalID], [AnimalName],
            [AppointmentDate], [AppointmentDescription],
            [ClinicAddress], [VetName], [FollowUpDate], [UserID]
    FROM [AnimalVetAppointment] INNER JOIN [Animal]
    ON [AnimalVetAppointment].[AnimalID] = [Animal].[AnimalID]
    ORDER BY [AppointmentDate]
END
GO

/*
Create by: Ethan Murphy
Date: 3/9/2020
Comment: Procedure to select all animal prescription records
*/
DROP PROCEDURE IF EXISTS [sp_select_all_animal_prescriptions]
GO
PRINT '' PRINT '*** creating sp_select_all_animal_prescriptions'
GO
CREATE PROCEDURE [sp_select_all_animal_prescriptions]
AS
BEGIN
	SELECT [AnimalPrescriptionsID], [Animal].[AnimalID], [AnimalVetAppointmentID],
			[PrescriptionName], [Dosage], [Interval], [AdministrationMethod],
			[StartDate], [EndDate], [Description], [AnimalName]
	FROM [AnimalPrescriptions] INNER JOIN [Animal]
    ON [AnimalPrescriptions].[AnimalID] = [Animal].[AnimalID]
	ORDER BY [AnimalName]
END
GO

/*
Created by: Ethan Murphy
Date: 2/7/2020
Comment: Stored procedure for INSERTing vet appointments
*/
DROP PROCEDURE IF EXISTS [sp_create_vet_appointment]
GO
PRINT '' PRINT '*** create sp_create_vet_appointment'
GO
CREATE PROCEDURE [sp_create_vet_appointment]
(
	@AnimalID					[int],
	@UserID						[int],
	@AppointmentDate			[datetime],
	@AppointmentDescription		[nvarchar](4000),
	@ClinicAddress				[nvarchar](200),
	@VetName					[nvarchar](200),
	@FollowUpDate				[datetime]
)
AS
BEGIN
    INSERT INTO [AnimalVetAppointment]
        ([AnimalID], [AppointmentDate], [AppointmentDescription],
        [ClinicAddress], [VetName], [FollowUpDate], [UserID])
    VALUES
        (@AnimalID, @AppointmentDate, @AppointmentDescription,
        @ClinicAddress, @VetName, @FollowUpDate, @UserID)
END
GO

/*
Created by: Ethan Murphy
Date: 3/1/2020
Comment: Stored procedure for updating
an existing vet appointment record
*/
DROP PROCEDURE IF EXISTS [sp_update_vet_appointment]
GO
PRINT '' PRINT '*** creating sp_update_vet_appointment'
GO
CREATE PROCEDURE [sp_update_vet_appointment]
(
	@AnimalVetAppointmentID		[int],
	@OldAnimalID				[int],
	@OldUserID					[int],
	@OldAppointmentDate			[datetime],
	@OldAppointmentDescription	[nvarchar](4000),
	@OldClinicAddress			[nvarchar](200),
	@OldVetName					[nvarchar](200),

	@NewAnimalID				[int],
	@NewUserID					[int],
	@NewAppointmentDate			[datetime],
	@NewAppointmentDescription	[nvarchar](4000),
	@NewClinicAddress			[nvarchar](200),
	@NewVetName					[nvarchar](200),
	@NewFollowUpDate			[datetime]
)
AS
BEGIN
	UPDATE [dbo].[AnimalVetAppointment]
	SET	[AnimalID] = @NewAnimalID,
		[UserID] = @NewUserID,
		[AppointmentDate] = @NewAppointmentDate,
		[AppointmentDescription] = @NewAppointmentDescription,
		[ClinicAddress] = @NewClinicAddress,
		[VetName] = @NewVetName,
		[FollowUpDate] = @NewFollowUpDate
	WHERE [AnimalID] = @OldAnimalID
	AND [AnimalVetAppointmentID] = @AnimalVetAppointmentID
	AND [UserID] = @OldUserID
	AND	[AppointmentDate] = @OldAppointmentDate
	AND [AppointmentDescription] = @OldAppointmentDescription
	AND	[ClinicAddress] = @OldClinicAddress
	AND	[VetName] = @OldVetName
	RETURN @@ROWCOUNT
END
GO

/*
Created by: Ethan Murphy
Date: 2/16/2020
Comment: Stored procedure for INSERTing animal prescription records
*/
DROP PROCEDURE IF EXISTS [sp_create_animal_prescription_record]
GO
PRINT '' PRINT 'create sp_create_animal_prescription_record'
GO
CREATE PROCEDURE [sp_create_animal_prescription_record]
(
	@AnimalID					[int],
	@AnimalVetAppointmentID		[int],
	@PrescriptionName			[nvarchar](50),
	@Dosage						[decimal],
	@MedicationInterval			[nvarchar](250),
	@AdministrationMethod		[nvarchar](100),
	@StartDate					[date],
	@EndDate					[date],
	@Description				[nvarchar](500)
)
AS
BEGIN
INSERT INTO [AnimalPrescriptions]
	([AnimalVetAppointmentID], [PrescriptionName], [Dosage],
	[Interval], [AdministrationMethod], [AnimalID],
	[StartDate], [EndDate], [Description])
VALUES
	(@AnimalVetAppointmentID, @PrescriptionName, @Dosage,
	@MedicationInterval, @AdministrationMethod, @AnimalID,
	@StartDate, @EndDate, @Description)
END
GO

/*
Created by: Ethan Murphy
Date: 3/13/2020
Comment: Stored procedure for updating
an existing animal prescription record
*/
DROP PROCEDURE IF EXISTS [sp_update_animal_prescription]
GO
print '' print '*** creating sp_update_animal_prescription'
GO
CREATE PROCEDURE [sp_update_animal_prescription]
(
	@OldAnimalPrescriptionID	[int],
	@OldAnimalID				[int],
	@OldAnimalVetAppointmentID	[int],
	@OldPrescriptionName		[nvarchar](50),
	@OldDosage					[decimal],
	@OldInterval				[nvarchar](250),
	@OldAdministrationMethod	[nvarchar](100),
	@OldStartDate				[date],
	@OldEndDate					[date],
	@OldDescription				[nvarchar](500),
	
	@NewAnimalID				[int],
	@NewAnimalVetAppointmentID	[int],
	@NewPrescriptionName		[nvarchar](50),
	@NewDosage					[decimal],
	@NewInterval				[nvarchar](250),
	@NewAdministrationMethod	[nvarchar](100),
	@NewStartDate				[date],
	@NewEndDate					[date],
	@NewDescription				[nvarchar](500)
)
AS
BEGIN
	UPDATE [dbo].[AnimalPrescriptions]
	SET	[AnimalID] = @NewAnimalID,
		[AnimalVetAppointmentID] = @NewAnimalVetAppointmentID,
		[PrescriptionName] = @NewPrescriptionName,
		[Dosage] = @NewDosage,
		[Interval] = @NewInterval,
		[AdministrationMethod] = @NewAdministrationMethod,
		[StartDate] = @NewStartDate,
		[EndDate] = @NewEndDate,
		[Description] = @NewDescription
	WHERE 	[AnimalPrescriptionsID] = @OldAnimalPrescriptionID
	AND	  	[AnimalID] = @OldAnimalID
	AND		[AnimalVetAppointmentID] = @OldAnimalVetAppointmentID
	AND		[PrescriptionName] = @OldPrescriptionName
	AND		[Dosage] = @OldDosage
	AND		[Interval] = @OldInterval
	AND		[AdministrationMethod] = @OldAdministrationMethod
	AND		[StartDate] = @OldStartDate
	AND		[EndDate] = @OldEndDate
	AND		[Description] = @OldDescription
	RETURN @@ROWCOUNT
END
GO

/*
Created by: Ben Hanna
Date: 2/11/2020
Comment: Sproc to reactivate an animal
*/
DROP PROCEDURE IF EXISTS [sp_reactivate_animal]
GO
PRINT '' PRINT '*** Creating sp_reactivate_animal'
GO
CREATE PROCEDURE [sp_reactivate_animal]
(
    @AnimalID			 [int]
)
AS
BEGIN
	UPDATE [dbo].[Animal]
    SET [Active] = 1
    WHERE [AnimalID] = @AnimalID
    
    RETURN @@ROWCOUNT
END 
GO

/*
Created by: Ben Hanna
Date: 2/11/2020
Comment: Sproc to reactivate an animal
*/
DROP PROCEDURE IF EXISTS [sp_deactivate_animal]
GO
PRINT '' PRINT '*** Creating sp_deactivate_animal'
GO
CREATE PROCEDURE [sp_deactivate_animal]
(
    @AnimalID			 [int]
)
AS
BEGIN
	UPDATE [dbo].[Animal]
    SET [Active] = 0
    WHERE [AnimalID] = @AnimalID
    
    RETURN @@ROWCOUNT
END 
GO

/*
Created by: Ben Hanna
Date: 2/11/2020
Comment: Sproc to deahouse animal
*/
DROP PROCEDURE IF EXISTS [sp_dehouse_animal]
GO
PRINT '' PRINT '*** Creating sp_dehouse_animal'
GO
CREATE PROCEDURE [sp_dehouse_animal]
(
    @AnimalID			 [int]
)
AS
BEGIN
	UPDATE [dbo].[Animal]
    SET [CurrentlyHoused] = 0
    WHERE [AnimalID] = @AnimalID
    RETURN @@ROWCOUNT
END 
GO

/*
Created by: Ben Hanna
Date: 2/11/2020
Comment: Sproc to house an animal
*/
DROP PROCEDURE IF EXISTS [sp_house_animal]
GO
PRINT '' PRINT '*** Creating sp_house_animal'
GO
CREATE PROCEDURE [sp_house_animal]
(
    @AnimalID			 [int]
)
AS
BEGIN
	UPDATE [dbo].[Animal]
    SET [CurrentlyHoused] = 1
    WHERE [AnimalID] = @AnimalID
    RETURN @@ROWCOUNT
END 
GO

/*
Created by: Ben Hanna
Date: 2/11/2020
Comment: Sproc to deset an active animal
*/
DROP PROCEDURE IF EXISTS [sp_deset_animal_adoptable]
GO
PRINT '' PRINT '*** Creating sp_deset_animal_adoptable'
GO
CREATE PROCEDURE [sp_deset_animal_adoptable]
(
    @AnimalID			 [int]
)
AS
BEGIN
	UPDATE [dbo].[Animal]
    SET [Adoptable] = 0
    WHERE [AnimalID] = @AnimalID
    RETURN @@ROWCOUNT
END 
GO

/*
Created by: Ben Hanna
Date: 2/11/2020
Comment: Sproc to set an deset animal
*/
DROP PROCEDURE IF EXISTS [sp_set_animal_adoptable]
GO
PRINT '' PRINT '*** Creating sp_set_animal_adoptable'
GO
CREATE PROCEDURE [sp_set_animal_adoptable]
(
    @AnimalID			 [int]
)
AS
BEGIN
	UPDATE [dbo].[Animal]
    SET [Adoptable] = 1
    WHERE [AnimalID] = @AnimalID
    
    RETURN @@ROWCOUNT
END 
GO
                
/*
Created by: Ben Hanna
Date: 2/18/2020
Comment: Sets an animal's adoptable state to false
*/ 
DROP PROCEDURE IF EXISTS [sp_select_handling_notes_by_animal_id]
GO
PRINT '' PRINT '*** Creating sp_select_handling_notes_by_animal_id'
GO
CREATE PROCEDURE [sp_select_handling_notes_by_animal_id]
(
    @AnimalID      [int]
)
AS
BEGIN
   SELECT [AnimalHandlingNotesID],[AnimalHandlingNotes], [TemperamentWarning], [UpdateDate], [UserID] 
                
   FROM [dbo].[AnimalHandlingNotes]
   WHERE [AnimalID] = @AnimalID
   ORDER BY [UpdateDate]
END
GO
                
/*
Created by: Ben Hanna
Date: 2/9/2020
Comment: Insert a kennel record
*/
DROP PROCEDURE IF EXISTS [sp_insert_kennel_record]
GO                
PRINT '' PRINT '*** Creating sp_insert_kennel_record'
GO
CREATE PROCEDURE [sp_insert_kennel_record]
(
    @AnimalID           [int],
    @AnimalKennelInfo   [nvarchar](4000), 
    @AnimalKennelDateIn	[date],
    @UserID             [int]
        
)
AS
BEGIN
   INSERT INTO [dbo].[AnimalKennel] 
        ([AnimalID], 
         [AnimalKennelInfo], 
         [AnimalKennelDateIn],
         [UserID]
        )
   VALUES 
        (@AnimalID,
         @AnimalKennelInfo,
         @AnimalKennelDateIn
         ,@UserID
        )
   SELECT SCOPE_IDENTITY()
END
GO
                
/*
Created by: Ben Hanna
Date: 03/12/2020
Comment: This is used to select all kennel records fron the animal kennel table
*/
DROP PROCEDURE IF EXISTS [sp_select_all_kennel_records]
GO
PRINT '' PRINT '*** Creating sp_select_all_kennel_records'
GO
CREATE PROCEDURE [sp_select_all_kennel_records]
AS
BEGIN
	SELECT 
    [AnimalKennelID],		
	[AnimalID],				
	[UserID],				
	[AnimalKennelInfo],		
	[AnimalKennelDateIn],	
	[AnimalKennelDateOut]
 	FROM [dbo].[AnimalKennel]
END
GO 
   
/*
Created by: Ben Hanna
Date: 3/17/2020
Comment: Update a handing notes record
*/ 
DROP PROCEDURE IF EXISTS [sp_update_kennel_record_no_date_out]
GO     
PRINT '' PRINT '*** Creating sp_update_kennel_record_no_date_out'
GO
CREATE PROCEDURE [sp_update_kennel_record_no_date_out]
(
    @AnimalKennelID			           [int],
    
    @NewAnimalID                       [int],
    @NewUserID                         [int], 
    @NewAnimalKennelInfo	           [nvarchar](4000),
    @NewAnimalKennelDateIn             [date],
    
	@OldAnimalID                       [int],
    @OldUserID                         [int], 
    @OldAnimalKennelInfo               [nvarchar](4000),
    @OldAnimalKennelDateIn             [date]
)
AS
BEGIN
	UPDATE [dbo].[AnimalKennel]
    SET [AnimalID]                  = @NewAnimalID, 
        [UserID]                    = @NewUserID,  
        [AnimalKennelInfo]          = @NewAnimalKennelInfo,
        [AnimalKennelDateIn]        = @NewAnimalKennelDateIn       
    WHERE   [AnimalKennelID]        = @AnimalKennelID
    AND     [AnimalID]              = @OldAnimalID 
    AND     [UserID]                = @OldUserID  
    AND     [AnimalKennelInfo]      = @OldAnimalKennelInfo
    AND     [AnimalKennelDateIn]    = @OldAnimalKennelDateIn        
    RETURN @@ROWCOUNT
END 
GO 
                
/*
Created by: Ben Hanna
Date: 3/17/2020
Comment: Update a handing notes record
*/ 
DROP PROCEDURE IF EXISTS [sp_update_kennel_record]
GO     
PRINT '' PRINT '*** Creating sp_update_kennel_record'
GO
CREATE PROCEDURE [sp_update_kennel_record]
(
    @AnimalKennelID			           [int],
    
    @NewAnimalID                       [int],
    @NewUserID                         [int], 
    @NewAnimalKennelInfo	           [nvarchar](4000),
    @NewAnimalKennelDateIn             [date],
    @NewAnimalKennelDateOut            [date],
    
	@OldAnimalID                       [int],
    @OldUserID                         [int], 
    @OldAnimalKennelInfo               [nvarchar](4000),
    @OldAnimalKennelDateIn             [date],
    @OldAnimalKennelDateOut            [date]
)
AS
BEGIN
	UPDATE [dbo].[AnimalKennel]
    SET [AnimalID]                  = @NewAnimalID, 
        [UserID]                    = @NewUserID,  
        [AnimalKennelInfo]          = @NewAnimalKennelInfo,
        [AnimalKennelDateIn]        = @NewAnimalKennelDateIn,
        [AnimalKennelDateOut]       = @NewAnimalKennelDateOut        
    WHERE   [AnimalKennelID]        = @AnimalKennelID
    AND     [AnimalID]              = @OldAnimalID 
    AND     [UserID]                = @OldUserID  
    AND     [AnimalKennelInfo]      = @OldAnimalKennelInfo
    AND     [AnimalKennelDateIn]    = @OldAnimalKennelDateIn
    AND     [AnimalKennelDateOut]   = @OldAnimalKennelDateOut        
    RETURN @@ROWCOUNT
END 
GO 
                
/*
Created by: Ben Hanna
Date: 3/18/2020
Comment: Sproc to add date out data to the record
*/
DROP PROCEDURE IF EXISTS [sp_add_date_out]
GO
PRINT '' PRINT '*** Creating sp_add_date_out'
GO
CREATE PROCEDURE [sp_add_date_out]
(
    @AnimalKennelID			 [int],
    @AnimalKennelDateOut     [date]
)
AS
BEGIN
	UPDATE [dbo].[AnimalKennel]
    SET [AnimalKennelDateOut] = @AnimalKennelDateOut
    WHERE [AnimalKennelID] = @AnimalKennelID
    
    RETURN @@ROWCOUNT
END 
GO

/*
Created by: Ben Hanna
Date: 2/18/2020
Comment: Sets an animal's adoptable state to false
*/          
DROP PROCEDURE IF EXISTS [sp_select_handling_notes_by_id]
GO      
PRINT '' PRINT '*** Creating sp_select_handling_notes_by_id'
GO
CREATE PROCEDURE [sp_select_handling_notes_by_id]
(
    @AnimalHandlingNotesID      [int]
)
AS
BEGIN
   SELECT [AnimalID], [AnimalHandlingNotes], [TemperamentWarning], [UpdateDate], [UserID] 
   FROM [dbo].[AnimalHandlingNotes]
   WHERE [AnimalHandlingNotesID] = @AnimalHandlingNotesID
END
GO
                
/*
Created by: Ben Hanna
Date: 2/29/2020
Comment: Insert a handing notes record
*/
DROP PROCEDURE IF EXISTS [sp_insert_handling_notes_record]
GO                  
PRINT '' PRINT '*** Creating sp_insert_handling_notes_record'
GO
CREATE PROCEDURE [sp_insert_handling_notes_record]
(
    
	@AnimalID              [int],			
	@UserID			       [int],
	@AnimalHandlingNotes   [nvarchar](4000),
	@TemperamentWarning    [nvarchar](1000),
	@UpdateDate		       [date]      
        
)
AS
BEGIN
   INSERT INTO [dbo].[AnimalHandlingNotes] 
        ([AnimalID], 
         [UserID], 
         [AnimalHandlingNotes],
         [TemperamentWarning],
         [UpdateDate]
        )
   VALUES 
        (@AnimalID,
         @UserID,
         @AnimalHandlingNotes,
         @TemperamentWarning,
         @UpdateDate
         
        )
   SELECT SCOPE_IDENTITY()
END
GO 
  
/*
Created by: Ben Hanna
Date: 3/4/2020
Comment: Update a handing notes record
*/ 
DROP PROCEDURE IF EXISTS [sp_update_handling_notes_record]
GO     
PRINT '' PRINT '*** Creating sp_update_handling_notes_record'
GO
CREATE PROCEDURE [sp_update_handling_notes_record]
(
    @AnimalHandlingNotesID			   [int],
    
    @NewAnimalID                       [int],
    @NewUserID                         [int], 
    @NewAnimalHandlingNotes	           [nvarchar](4000),
    @NewTemperamentWarning             [nvarchar](1000),
    @NewUpdateDate                     [date],
    
	@OldAnimalID                       [int],
    @OldUserID                         [int], 
    @OldAnimalHandlingNotes	           [nvarchar](4000),
    @OldTemperamentWarning             [nvarchar](1000),
    @OldUpdateDate                     [date]
)
AS
BEGIN
	UPDATE [dbo].[AnimalHandlingNotes]
    SET [AnimalID]                  = @NewAnimalID, 
        [UserID]                    = @NewUserID,  
        [AnimalHandlingNotes]       = @NewAnimalHandlingNotes,
        [TemperamentWarning]        = @NewTemperamentWarning,
        [UpdateDate]                = @NewUpdateDate        
    WHERE   [AnimalHandlingNotesID] = @AnimalHandlingNotesID
    AND     [AnimalID]              = @OldAnimalID 
    AND     [UserID]                = @OldUserID  
    AND     [AnimalHandlingNotes]   = @OldAnimalHandlingNotes
    AND     [TemperamentWarning]    = @OldTemperamentWarning
    AND     [UpdateDate]            = @OldUpdateDate
    RETURN @@ROWCOUNT
END 
GO
  
/*
Created by: Ben Hanna
Date: 3/4/2020
Comment: Update a handing notes record
*/ 
DROP PROCEDURE IF EXISTS [sp_update_handling_notes_record]
GO     
PRINT '' PRINT '*** Creating sp_update_handling_notes_record'
GO
CREATE PROCEDURE [sp_update_handling_notes_record]
(
    @AnimalHandlingNotesID			   [int],
    
    @NewAnimalID                       [int],
    @NewUserID                         [int], 
    @NewAnimalHandlingNotes	           [nvarchar](4000),
    @NewTemperamentWarning             [nvarchar](1000),
    @NewUpdateDate                     [date],
    
	@OldAnimalID                       [int],
    @OldUserID                         [int], 
    @OldAnimalHandlingNotes	           [nvarchar](4000),
    @OldTemperamentWarning             [nvarchar](1000),
    @OldUpdateDate                     [date]
)
AS
BEGIN
	UPDATE [dbo].[AnimalHandlingNotes]
    SET [AnimalID]                  = @NewAnimalID, 
        [UserID]                    = @NewUserID,  
        [AnimalHandlingNotes]       = @NewAnimalHandlingNotes,
        [TemperamentWarning]        = @NewTemperamentWarning,
        [UpdateDate]                = @NewUpdateDate        
    WHERE   [AnimalHandlingNotesID] = @AnimalHandlingNotesID
    AND     [AnimalID]              = @OldAnimalID 
    AND     [UserID]                = @OldUserID  
    AND     [AnimalHandlingNotes]   = @OldAnimalHandlingNotes
    AND     [TemperamentWarning]    = @OldTemperamentWarning
    AND     [UpdateDate]            = @OldUpdateDate
    RETURN @@ROWCOUNT
END 
GO 

/*
  Created by: Jordan Lindo
  Date: 2/5/2020
  Comment: This is a stored procedure for INSERTing new departments into the
  department table.
*/
DROP PROCEDURE IF EXISTS [sp_insert_department]
GO    
PRINT '' PRINT '*** Create procedure sp_insert_department'
GO
CREATE PROCEDURE [sp_insert_department]
(
	 @DepartmentID			[nvarchar](50)
	,@Description			[nvarchar](200)
)
AS
BEGIN
	INSERT INTO [dbo].[department]
	([DepartmentID],[Description])
	VALUES
	(@DepartmentID,@Description)
END
GO

/*
  Created by: Jordan Lindo
  Date: 2/5/2020
  Comment: This is a stored procedure for selecting all department records.
*/
DROP PROCEDURE IF EXISTS [sp_select_all_departments]
GO   
PRINT '' PRINT '*** Create procedure sp_select_all_departments'
GO
CREATE PROCEDURE [sp_select_all_active_departments]
AS
BEGIN
	SELECT [DepartmentID],[Description]
	FROM [Department]
	WHERE [Active] = 1
END
GO

/*
  Created by: Jordan Lindo
  Date: 2/5/2020
  Comment: This is a stored procedure for selecting all records with a departmentID
  matching the input.
*/
DROP PROCEDURE IF EXISTS [sp_select_all_departments]
GO   
PRINT '' PRINT '*** Create procedure sp_select_department_by_id'
GO
CREATE PROCEDURE [sp_select_department_by_id]
(
	 @DepartmentID			[nvarchar](50)
)
AS
BEGIN
	SELECT [DepartmentID],[Description]
	FROM [Department]
	WHERE [DepartmentID] = @DepartmentID
END
GO

/*
 Created by: Jordan Lindo
 Date: 2/15/2020
 Comment: This is a stored procedure for updating a department record.
*/
DROP PROCEDURE IF EXISTS [sp_update_department]
GO   
PRINT '' PRINT '*** Create procedure sp_update_department'
GO
CREATE PROCEDURE [sp_update_department]
(
	 @DepartmentID			[nvarchar](50)
	,@NewDescription		[nvarchar](200)
)
AS
BEGIN
	UPDATE [dbo].[department]
	SET [Description] = @NewDescription
	WHERE [DepartmentID] = @DepartmentID
	RETURN @@ROWCOUNT
END
GO

/*
Sproc for INSERTing a shift time

Author: Lane Sandburg
2/5/2020

*/
DROP PROCEDURE IF EXISTS [sp_insert_ShiftTime]
GO
PRINT '' PRINT '*** creating sp_insert_ShiftTime'
GO
CREATE PROCEDURE [sp_insert_ShiftTime](
	@DepartmentID [NVARCHAR](50),
	@StartTime[TIME](0),
	@EndTime[TIME](0)
)
AS
BEGIN
	INSERT INTO [dbo].[ShiftTime]
		([DepartmentID],[StartTime],[EndTime])
		VALUES
		(@DepartmentID,@StartTime,@EndTime)
		RETURN SCOPE_IDENTITY()
END
GO

/*
Sproc for Retreiveing Departments

Author: Lane Sandburg
2/5/2020

*/
DROP PROCEDURE IF EXISTS [sp_select_all_ShiftTimes]
GO
PRINT '' PRINT '*** creating sp_select_all_ShiftTimes'
GO
CREATE PROCEDURE [sp_select_all_ShiftTimes]
AS
BEGIN
	SELECT [ShiftTimeID],[DepartmentID],[StartTime],[EndTime]
	FROM [dbo].[ShiftTime]
	ORDER BY [DepartmentID]
END
GO


/*
Sproc for Retreiveing Departments

Author: Lane Sandburg
2/13/2020

*/
DROP PROCEDURE IF EXISTS [sp_update_shiftTime]
GO
PRINT '' PRINT '*** creating sp_update_shiftTime'
GO
CREATE PROCEDURE [sp_update_shiftTime](
	@ShiftTimeID [int],
	@NewDepartmentID  	[nvarchar](50),
	@NewStartTime		[TIME](0),
	@NewEndTime			[TIME](0),

	@OldDepartmentID  	[nvarchar](50),
	@OldStartTime		[TIME](0),
	@OldEndTime			[TIME](0)
)
AS
BEGIN
	UPDATE [dbo].[ShiftTime]
	SET [DepartmentID] = @NewDepartmentID,
		[StartTime] = @NewStartTime,
		[EndTime] = @NewEndTime

	WHERE [ShiftTimeID] = @ShiftTimeID
	AND	[DepartmentID] = @OldDepartmentID
	AND [StartTime] = @OldStartTime
	AND[EndTime] = @OldEndTime

	RETURN @@ROWCOUNT
END
GO

/*
Sproc for Retreiveing Departments

Author: Lane Sandburg
03/05/2020
*/
DROP PROCEDURE IF EXISTS [sp_delete_shiftTime]
GO
PRINT '' PRINT '*** creating sp_delete_shiftTime'
GO
CREATE PROCEDURE [sp_delete_shiftTime](
		@ShiftTimeID [int]
)
AS
BEGIN
	DELETE FROM [dbo].[ShiftTime]
	WHERE [ShiftTimeID] = @ShiftTimeID
	RETURN @@ROWCOUNT

END
GO




/*
	Created by: Mohamed Elamin
	Date: 03/29/2020
	Comment: Store Procedure to find Customer by Customer Email from the Customer Table.
*/
DROP PROCEDURE IF EXISTS [sp_select_Customer_by_Customer_Email]
GO
PRINT '' PRINT '*** Creating sp_select_Customer_by_Customer_Email'
GO
CREATE PROCEDURE [sp_select_Customer_by_Customer_Email]
(
	@CustomerEmail 		[nvarchar](250)
)
AS
BEGIN

	SELECT  [Email],[FirstName],[lastName],[phoneNumber],[addressLineOne],[addressLineTwo],
	[city],[state],[zipCode],[Active]

	FROM 	[dbo].[Customer]
	WHERE	[Customer].[Email] = @CustomerEmail
END
GO

/*
	Created by: Mohamed Elamin
	Date: 2/2/2020
	Comment: Store Procedure to pull list of Adoption Applications which their status
	is inHomeInspection.
*/
DROP PROCEDURE IF EXISTS [sp_select_AdoptionApplication_by_Status]
GO
PRINT '' PRINT '*** Creating sp_select_AdoptionApplication_by_Status'
GO
CREATE PROCEDURE [sp_select_AdoptionApplication_by_Status]
AS
BEGIN
	SELECT 	AdoptionApplicationID,AnimalID,CustomerEmail,Status,RecievedDate
	FROM 	[dbo].[AdoptionApplication]
	WHERE	[Status] = 'InHomeInspection'
END
GO

/*
	Created by: Mohamed Elamin
	Date: 2/2/2020
	Comment: Store Procedure to find animal name from Animal table
	by animal ID.
*/
DROP PROCEDURE IF EXISTS [sp_select_AnimalName_by_AnimalID]
GO
PRINT '' PRINT '*** Creating sp_select_AnimalName_by_AnimalID'
GO
CREATE PROCEDURE [sp_select_AnimalName_by_AnimalID]
(
	@AnimalID 		[int]
)
AS
BEGIN
	SELECT 	[AnimalName]
	FROM 	[dbo].[Animal]
	WHERE	[AnimalID] = @AnimalID
END
GO




/*
	Created by: Mohamed Elamin
	Date: 02/18/2020
	Comment: store Procedure to updates Adoption application Appointment decision and notes.
*/
DROP PROCEDURE IF EXISTS [sp_update_Adoption_Appointment]
print '' print '*** Creating sp_update_Adoption_Appointment'
GO

CREATE PROCEDURE [sp_update_Adoption_Appointment]
(

    @AppointmentID		   [int]            ,
	@NewNotes		       [nvarchar](1000) ,
	@NewDecision		   [nvarchar](50)   ,	
	@OldNotes    		   [nvarchar](1000) ,
	@OldDecision		   [nvarchar](50)	
)
AS
BEGIN
	UPDATE [dbo].[Appointment]
		SET [Notes] = 	  @NewNotes,
			[Decision] = 	@NewDecision
			
	WHERE 	[AppointmentID] =	@AppointmentID  
	  AND	[Notes] = 	@OldNotes
	  AND	[Decision] = 	@OldDecision	 
	RETURN  @@ROWCOUNT
END
GO

/*
	Created by: Mohamed Elamin
	Date: 02/18/2020
	Comment: Store Procedure to find Customer by Customer Name from the Customer Table.
*/
DROP PROCEDURE IF EXISTS [sp_select_Customer_by_Customer_Name]
GO
PRINT '' PRINT '*** Creating sp_select_Customer_by_Customer_Name'
GO
CREATE PROCEDURE [sp_select_Customer_by_Customer_Name]
(
	@CustomerName 		[nvarchar](50)
)
AS
BEGIN

	SELECT  [Email],[FirstName],[lastName],[phoneNumber],[addressLineOne],[addressLineTwo],
	[city],[state],[zipCode],[Active]

	FROM 	[dbo].[Customer]
	WHERE	[Customer].[lastName] = @CustomerName
END
GO


/*
	Created by: Mohamed Elamin
	Date: 02/18/2020
	Comment: Store Procedure to updates Adoption application's decision and notes.
*/
DROP PROCEDURE IF EXISTS [sp_update_adoption_appointment_decision_note]
GO
PRINT '' PRINT '*** Creating sp_update_adoption_appointment_decision_note'
GO
CREATE PROCEDURE [sp_update_adoption_appointment_decision_note]
(
    @AppointmentID			[int],
	@NewNotes		      [nvarchar](1000),
	@NewDecision		  [nvarchar](50),

	@OldNotes    		[nvarchar](1000),
	@OldDecision		[nvarchar](50)

)
AS
BEGIN
	UPDATE [dbo].[Appointment]
	SET [Notes] = 	  @NewNotes,
		[Decision] = 	@NewDecision
	WHERE 	[AppointmentID] =	@AppointmentID
	AND	[Notes] = 	@OldNotes
	AND	[Decision] = 	@OldDecision
	RETURN  @@ROWCOUNT
END
GO

/*
	Created by: Mohamed Elamin
	Date: 02/18/2020
	Comment: Store Procedure to gets ALL Adoption applications where their  Appointment
	status is Interviewer
*/
DROP PROCEDURE IF EXISTS [sp_select_interviewer_Appointments_by_AppointmentType]
GO
PRINT '' PRINT '*** Creating sp_select_interviewer_Appointments_by_AppointmentType'
GO
CREATE PROCEDURE [sp_select_interviewer_Appointments_by_AppointmentType]
AS
BEGIN
	SELECT 	AppointmentID,AdoptionApplicationID,AppointmentTypeID,DateTime,Notes,
			Decision,LocationID
	FROM 	[dbo].[Appointment]
	WHERE	[AppointmentTypeID] = 'Interviewer'
END
GO

/*
	Created by: Mohamed Elamin
	Date: 2/29/2020
	Comment: Store Procedure to updates Adoption appointment's notes for the
	Interviewer which he will be enters these notes during the interview with the Customer.
*/
DROP PROCEDURE IF EXISTS [sp_update_Adoption_appointment_notes]
GO
PRINT '' PRINT '*** Creating sp_update_Adoption_appointment_notes'
GO
CREATE PROCEDURE [sp_update_Adoption_appointment_notes]
(
    @AppointmentID	      [int]             ,
	@NewNotes		      [nvarchar](1000)  ,
	@OldNotes    		  [nvarchar](1000)
)
AS
BEGIN
	UPDATE [dbo].[Appointment]
	SET [Notes] = 	  @NewNotes
	WHERE 	[AppointmentID] =	@AppointmentID
	AND	[Notes] = 	@OldNotes
	RETURN  @@ROWCOUNT
END
GO


/*
	Created by: Mohamed Elamin
	Date: 02/18/2020
	Comment:  Store Procedure to gets ALL Adoption applications where thier status is inHomeInspection
*/
DROP PROCEDURE IF EXISTS [sp_select_inHomeInspectionAppointments_by_AppointmentType]
GO
PRINT '' PRINT '*** Creating sp_select_inHomeInspectionAppointments_by_AppointmentType'
GO
CREATE PROCEDURE [sp_select_inHomeInspectionAppointments_by_AppointmentType]
AS
BEGIN
	SELECT 	
        [AppointmentID],
        [AdoptionApplicationID],
        [AppointmentTypeID],
        [DateTime],
        [Notes],
		[Decision],
        [LocationID],
        [Active]
	FROM 	[dbo].[Appointment]
	WHERE	[AppointmentTypeID] = 'inHomeInspection'
END
GO

/*
	Created by: Mohamed Elamin
	Date: 2020/03/10
	Comment: Store Procedure to find Customer Email by Adoption Application ID from the Customer Table.
*/
DROP PROCEDURE IF EXISTS [sp_select_customer_email_by_adoption_ApplicationId]
print '' print '*** Creating sp_select_customer_email_by_adoption_ApplicationId'
GO
CREATE PROCEDURE [sp_select_customer_email_by_adoption_ApplicationId]
(
	@AdoptionApplicationID 		[int]	
)
AS
BEGIN
	SELECT 	[Email]
	FROM  [dbo].[Customer]	

	JOIN [AdoptionApplication] ON [AdoptionApplication].[CustomerEmail] = [Customer].[Email]
	WHERE	[AdoptionApplication].[AdoptionApplicationID] = @AdoptionApplicationID 
END
GO


/*
	Created by: Mohamed Elamin
	Date: 2/2/2020
	Comment: store Procedure to find location name from Location table
	by location ID.
*/
DROP PROCEDURE IF EXISTS [sp_location_Name_by_Location_Id]
GO
PRINT '' PRINT '*** Creating sp_location_Name_by_Location_Id'
GO
CREATE PROCEDURE [sp_location_Name_by_Location_Id]
(
	@LocationID 		[int]
)
AS
BEGIN

	SELECT 	[Name]
	FROM 	[dbo].[Location]
	WHERE	[LocationID] = @LocationID 
END
GO













/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Creating Stored Procedure sp_select_all_products_items, updated 2020/03/17 to be compatible with new product table structure.
*/
DROP PROCEDURE IF EXISTS [sp_select_all_products_items]
print '' print '*** Creating sp_select_all_products_items'
GO
CREATE PROCEDURE [sp_select_all_products_items]
AS
BEGIN
	SELECT
			[Product].[ProductID]
		,	[Item].[ItemName]
		,	[Product].[Brand]
		,	[Item].[ItemCategoryID]
		,	[Product].[ProductTypeID]
		,	[Product].[Price]
		,	[Item].[ItemQuantity]
		FROM	[Product]
		JOIN	[Item]	ON	[Item].[ItemID] = [Product].[ItemID]
	END
GO

/*
Created by: Derek Taylor
Date 2/21/2020
Comment: Stored Procedure to select all of the applicants
*/
DROP PROCEDURE IF EXISTS [sp_select_all_applicants]
GO
PRINT '' PRINT '*** Creating sp_select_all_applicants'
GO
CREATE PROCEDURE [sp_select_all_applicants]
AS
BEGIN
	SELECT [Applicant].[ApplicantID], [FirstName], [LastName], [MiddleName], [Email], [PhoneNumber], [Application].[Status]
	FROM [dbo].[Applicant] JOIN [Application] ON [Application].[ApplicantID] = [Applicant].[ApplicantID]
	ORDER BY [ApplicantID]
END
GO

/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: pull up a list of eRoles
*/
DROP PROCEDURE IF EXISTS [sp_select_all_eRoles]
GO
PRINT '' PRINT '*** Creating sp_select_all_eRoles'
GO
CREATE PROCEDURE sp_select_all_eRoles
AS
BEGIN
    SELECT 	[ERoleID],[DepartmentID],[Description],[Active]
    FROM 	[ERole]
END
GO

/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: deactivate a eRoleID by ID
*/
DROP PROCEDURE IF EXISTS [sp_deactivate_eRole]
GO
PRINT ''  PRINT '*** Creating sp_deactivate_eRole '
GO
CREATE PROCEDURE [sp_deactivate_eRole]
(

	@ERoleID	[nvarchar](50)
)
AS
BEGIN
	Update [dbo].[ERole]
	Set	[Active]=0
	Where [ERoleID] = @ERoleID
	Return @@ROWCOUNT
END
GO

/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: activate a eRoleID by ID
*/
DROP PROCEDURE IF EXISTS [sp_activate_eRole]
GO
PRINT ''  PRINT '*** Creating sp_activate_eRole '
GO
CREATE PROCEDURE [sp_activate_eRole]
(

	@ERoleID	[nvarchar](50)
)
AS
BEGIN
	Update [dbo].[ERole]
	Set [Active]=1
	Where [ERoleID] = @ERoleID
	Return @@ROWCOUNT
END
GO

/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: update an oldERole with a new eRole
*/
DROP PROCEDURE IF EXISTS [sp_update_eRole_by_id]
GO
PRINT ''  PRINT '*** Creating sp_update_eRole_by_id'
GO
CREATE PROCEDURE [sp_update_eRole]
(
	@OldERoleID	[nvarchar](50),
	@OldDepartmentID nvarchar(50),
	@OldDescription [nvarchar](200),

	--New rows
	@NewDepartmentID nvarchar(50),
	@NewDescription [nvarchar](200)
)
AS
BEGIN
	Update [dbo].[ERole]
	Set
	[DepartmentID]=@NewDepartmentID,
	[Description]=@NewDescription
	Where [ERoleID] = @OldERoleID
	And [DepartmentID] = @OldDepartmentID
	And [Description] = @OldDescription
	Return @@ROWCOUNT
END
GO

/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: INSERT a new eRole
*/
DROP PROCEDURE IF EXISTS [sp_insert_eRole]
GO
PRINT ''  PRINT '*** Creating sp_insert_eRole'
GO
CREATE PROCEDURE [sp_insert_eRole]
(
	@ERoleID[nvarchar](50),
	@DepartmentID[nvarchar](50),
	@Description[nvarchar](200)
)
AS
BEGIN
	Insert Into [dbo].[ERole]
		([ERoleID],[DepartmentID],[Description])
	VALUES
		(@ERoleID,@DepartmentID,@Description)
END
GO

/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: delete an eRole
*/
DROP PROCEDURE IF EXISTS [sp_delete_eRole]
GO
PRINT '' PRINT '*** Creating sp_delete_eRole '
GO
CREATE PROCEDURE [sp_delete_eRole]
(
    @ERoleID				[nvarchar](50)
)
AS
BEGIN
    DELETE
    FROM 	[ERole]
    WHERE 	[ERoleId] = @ERoleId
    RETURN @@ROWCOUNT
END
GO

/*
Created by: Chase Schulte
Date: 02/16/2020
Comment: Select eRoles by active state
*/
DROP PROCEDURE IF EXISTS [sp_select_all_active_eRoles]
GO
PRINT '' PRINT '*** Creating sp_select_all_active_eRoles'
GO
CREATE PROCEDURE [sp_select_all_active_eRoles]
(
    @Active				[bit]
)
AS
BEGIN
	select [ERoleID],[DepartmentID],[Description],[Active]
	FROM [dbo].[ERole]
	WHERE [Active] = @Active
END
GO

/*
Created by: Chase Schulte
Date: 02/28/2020
Comment: Select UserERole by userID
*/
DROP PROCEDURE IF EXISTS [sp_select_user_eRole_by_user_id]
GO
PRINT '' PRINT '*** Creating sp_select_user_eRole_by_user_id'
GO
CREATE PROCEDURE sp_select_user_eRole_by_user_id
(
    @UserID		[int]
)
AS
BEGIN
    SELECT [ERoleID]
    FROM 	[UserERole]
    WHERE 	[UserID] = @UserID
END
GO

/*
Created by: Chase Schulte
Date: 02/28/2020
Comment: Add a UserERole
*/
DROP PROCEDURE IF EXISTS [sp_insert_user_eRole]
GO
PRINT ''  PRINT '*** Creating sp_insert_user_eRole'
GO
CREATE PROCEDURE [sp_insert_user_eERole]
(
	@UserID			[int],
	@ERoleID		[nvarchar](50)
)
AS
BEGIN
INSERT INTO [dbo].[UserERole]
	([UserID], [ERoleID])
	VALUES
	(@UserID, @ERoleID)
END
GO

/*
Created by: Chase Schulte
Date: 02/28/2020
Comment: Delete a UserERole
*/
DROP PROCEDURE IF EXISTS [sp_delete_user_eRole]
GO
PRINT '' PRINT '*** Creating sp_delete_user_eRole'
GO
CREATE PROCEDURE sp_delete_user_eRole
(
	@UserID			[int],
	@ERoleID				[nvarchar](50)
)
AS
BEGIN
	DELETE FROM [dbo].[UserERole]
	WHERE [UserID] = @UserID
	AND [ERoleID] = @ERoleID
END
GO

/*
Created by: Ethan Holmes
Date: 02/16/2020
Comment: Create volunteer task table
*/
DROP TABLE IF EXISTS [dbo].[VolunteerTask]
GO
print '' print '*** Creating VolunteerTask Table'
GO
CREATE TABLE [dbo].[VolunteerTask](
	[VolunteerTaskID] 		[int] IDENTITY(1000000,1) 	NOT NULL,
	[TaskName]				[NVARCHAR](100)				NOT NULL,
	[TaskType]				[NVARCHAR](100)				NOT NULL,
	[AssignmentGroup]		[NVARCHAR](100)				NOT NULL,
	[TaskDescription] 		[NVARCHAR](1080) 			    NULL,
	[DueDate] 				[DATE]						NOT NULL,
	
	CONSTRAINT [pk_VolunteerTaskID] PRIMARY KEY([VolunteerTaskID] ASC),
)
GO

/*
Created by: Ethan Holmes
Date: 02/16/2020
Comment: Insert a volunteer task record
*/
DROP PROCEDURE IF EXISTS [sp_insert_volunteer_task]
GO
PRINT '' PRINT '*** Creating sp_insert_volunteer_task'
GO
CREATE PROCEDURE [sp_insert_volunteer_task]
(
	@TaskName 					[NVARCHAR](100),
	@TaskType					[NVARCHAR](100),
	@AssignmentGroup			[NVARCHAR](100),
	@TaskDescription  			[NVARCHAR](1080),
	@DueDate					[DATE]

)
AS
BEGIN
	INSERT INTO [dbo].[VolunteerTask]
		([TaskName],[TaskType],[AssignmentGroup],[TaskDescription], [DueDate])
	VALUES
		(@TaskName, @TaskType, @AssignmentGroup, @TaskDescription, @DueDate)
	SELECT SCOPE_IDENTITY()
END
GO

/*
Created by: Ethan Holmes
Date: 02/16/2020
Comment: Selects volunteer task by name
*/
DROP PROCEDURE IF EXISTS [sp_select_volunteer_task_by_name]
GO
PRINT '' PRINT '*** Creating sp_select_volunteer_task_by_name'
GO
CREATE PROCEDURE [sp_select_volunteer_task_by_name]
(
	@taskName [NVARCHAR](100)
)
AS
BEGIN
	SELECT 
        [VolunteerTaskID], 
        [TaskName], 
        [TaskType], 
        [AssignmentGroup], 
        [DueDate], 
        [TaskDescription]
	FROM [dbo].[VolunteerTask]
	WHERE [TaskName] = @taskName
END
GO

/*
Created by: Ethan Holmes
Date: 02/16/2020
Comment: Select all volunteer tasks
*/
DROP PROCEDURE IF EXISTS [sp_select_all_volunteer_tasks]
GO
PRINT '' PRINT '*** Creating sp_select_all_volunteer_tasks'
GO
CREATE PROCEDURE [sp_select_all_volunteer_tasks]
AS
BEGIN
	SELECT 
        [TaskName],
        [TaskType],
        [AssignmentGroup], 
        [DueDate], 
        [TaskDescription]
	FROM [dbo].[VolunteerTask]
END
GO

/*
Created by: Ethan Holmes
Date: 02/16/2020
Comment: Updates a volunteer task record
*/
DROP PROCEDURE IF EXISTS [sp_update_volunteer_task_by_name]
GO
PRINT '' PRINT '*** Creating sp_update_volunteer_task_by_name'
GO
CREATE PROCEDURE [sp_update_volunteer_task_by_name]
(
	@TaskName 					[NVARCHAR](100),
	@TaskType					[NVARCHAR](100),
	@AssignmentGroup			[NVARCHAR](100),
	@TaskDescription  			[NVARCHAR](1080),
	@DueDate					[DATE]

)
AS
BEGIN
	UPDATE [dbo].[VolunteerTask]
	SET [TaskType] = @TaskType,
		[AssignmentGroup] = @AssignmentGroup,
		[DueDate] = @DueDate,
		[TaskDescription] = @TaskDescription
	WHERE [TaskName] = @TaskName
	SELECT SCOPE_IDENTITY()
END
GO

/*
Created By: Ethan Holmes
Date 3/6/2020
Comment: Stored Procedure to delete a volunteer task by name
*/
DROP PROCEDURE IF EXISTS [sp_delete_volunteer_task]
GO
print '' print '*** Creating sp_delete_volunteer_task'
GO
CREATE PROCEDURE [sp_delete_volunteer_task]
(
	@TaskName [nvarchar](100)
)
AS
BEGIN
	DELETE 
	FROM [dbo].[VolunteerTask]
	WHERE [TaskName] = @TaskName
	SELECT @@ROWCOUNT
END
GO

/*
Created by: Austin Gee
Date: 2/21/2020
Comment: Stored Procedure that selects Adoption Customers by active status
*/
DROP PROCEDURE IF EXISTS [sp_select_adoption_customers_by_active]
GO
PRINT '' PRINT '*** Creating sp_select_adoption_customers_by_active'
GO
CREATE PROCEDURE [sp_select_adoption_customers_by_active]
(
	@Active			[bit]
)
AS
BEGIN
	SELECT
	[FirstName]
	,[LastName]
	,[PhoneNumber]
	,[Email]
	,[Customer].[Active]
	,[addressLineOne]
	,[addressLineTwo]
	,[City]
	,[State]
	,[Zipcode]
	FROM [Customer] 
	WHERE [Customer].[Active] = @Active
END
GO


/*
Created by: Austin Gee
Date: 2/21/2020
Comment: Stored Procedure that selects adoption appointments by active and type.
*/
DROP PROCEDURE IF EXISTS [sp_select_adoption_appointments_by_active_and_type]
GO
PRINT '' PRINT '*** Creating sp_select_adoption_appointments_by_active_and_type'
GO
CREATE PROCEDURE [sp_select_adoption_appointments_by_active_and_type]
(
	@Active				[int] 			,
	@AppointmentTypeID	[nvarchar] (100)
)
AS
BEGIN
	SELECT
	[AppointmentID]
	,[AdoptionApplication].[AdoptionApplicationID]
	,[Appointment].[AppointmentTypeID]
	,[Appointment].[DateTime]
	,[Appointment].[Notes]
	,[Appointment].[Decision]
	,[Location].[LocationID]
	,[Appointment].[Active]
	,[Customer].[Email]
	,[Animal].[AnimalID]
	,[AdoptionApplication].[Status]
	,[AdoptionApplication].[RecievedDate]
	,[Location].[Name]
	,[Location].[Address1]
	,[Location].[Address2]
	,[Location].[City]
	,[Location].[State]
	,[Location].[Zip]
	,[Customer].[FirstName]
	,[Customer].[LastName]
	,[Customer].[PhoneNumber]
	,[Customer].[Active]
	,[Customer].[City]
	,[Customer].[State]
	,[Customer].[Zipcode]
	,[Animal].[AnimalName]
	,[Animal].[Dob]
	,[Animal].[AnimalSpeciesID]
	,[Animal].[AnimalBreed]
	,[Animal].[ArrivalDate]
	,[Animal].[CurrentlyHoused]
	,[Animal].[Adoptable]
	,[Animal].[Active]
	FROM [Appointment] JOIN [AdoptionApplication] ON [AdoptionApplication].[AdoptionApplicationID] = [Appointment].[AdoptionApplicationID]
	JOIN [Location] ON [Appointment].[LocationID] = [Location].[LocationID]
	JOIN [Customer] ON [AdoptionApplication].[CustomerEmail] = [Customer].[Email]
	JOIN [Animal] ON [AdoptionApplication].[AnimalID] = [Animal].[AnimalID]
	WHERE [Appointment].[Active] = @Active
	AND	[Appointment].[AppointmentTypeID] = @AppointmentTypeID
	ORDER BY [Appointment].[DateTime] DESC
END
GO



/*
Created by: Kaleb Bachert
Date: 3/3/2020
Comment: Procedure to add a Time Off Request
*/
DROP PROCEDURE IF EXISTS [sp_insert_time_off_request]
GO
PRINT '' PRINT '*** Creating sp_insert_time_off_request'
GO
CREATE PROCEDURE [sp_insert_time_off_request]
(
	@EffectiveStart			[datetime],
	@EffectiveEnd			[datetime],
	@RequestingUserID		[int]
)
AS
BEGIN
	INSERT INTO [dbo].[request]
	([RequestTypeID], [DateCreated], [RequestingUserID])
	VALUES
	('Time Off', GETDATE(), @RequestingUserID)

	INSERT INTO [dbo].[timeOffRequest]
	([EffectiveStart], [EffectiveEnd], [RequestID])
	VALUES
	(@EffectiveStart, @EffectiveEnd, SCOPE_IDENTITY())
END
GO

/*
Created by: Chase Schulte
Date: 04/07/2020
Comment: pull up a list availbilty and request by availbilityRequest ID
*/
DROP PROCEDURE IF EXISTS [sp_select_availbility_request_by_request_id]
GO
PRINT '' PRINT '*** Creating sp_select_availbility_request_by_request_id'
GO
CREATE PROCEDURE sp_select_availbility_request_by_request_id
(
	@RequestID[int]
)
AS
BEGIN
    SELECT 	[AvailabilityRequestID],[SundayStartTime],[SundayEndTime],[MondayStartTime],[MondayEndTime],
	[TuesdayStartTime],[TuesdayEndTime],[WednesdayStartTime],[WednesdayEndTime],[ThursdayStartTime],
	[ThursdayEndTime],[FridayStartTime],[FridayEndTime],[SaturdayStartTime],[SaturdayEndTime],
	[AvailabilityRequest].[requestID],[RequestingUserID],[FirstName],[LastName]
	
	
	
    FROM 	[AvailabilityRequest]
	join [request] on [AvailabilityRequest].[requestID ]= [request].[requestID]
	join [User] on [User].[userID] = [request].[RequestingUserID]
	Where	@RequestID = [AvailabilityRequest].[RequestID]
END
GO

/*
Created by: Kaleb Bachert
Date: 3/17/2020
Comment: Procedure to add an AvailabilityRequest
*/
DROP PROCEDURE IF EXISTS [sp_insert_availability_request]
GO
PRINT '' PRINT '*** Creating sp_insert_availability_request'
GO
CREATE PROCEDURE [sp_insert_availability_request]
(
	@SundayStart			[nvarchar](30),
	@SundayEnd				[nvarchar](30),
	@MondayStart			[nvarchar](30),
	@MondayEnd				[nvarchar](30),
	@TuesdayStart			[nvarchar](30),
	@TuesdayEnd				[nvarchar](30),
	@WednesdayStart			[nvarchar](30),
	@WednesdayEnd			[nvarchar](30),
	@ThursdayStart			[nvarchar](30),
	@ThursdayEnd			[nvarchar](30),
	@FridayStart			[nvarchar](30),
	@FridayEnd				[nvarchar](30),
	@SaturdayStart			[nvarchar](30),
	@SaturdayEnd			[nvarchar](30),
	@RequestingUserID		[int]
)
AS
BEGIN
	INSERT INTO [dbo].[request]
	([RequestTypeID], [DateCreated], [RequestingUserID])
	VALUES
	('Availability Change', GETDATE(), @RequestingUserID)
	
	INSERT INTO [dbo].[availabilityRequest]
	([SundayStartTime], [SundayEndTime], [MondayStartTime], [MondayEndTime], 
		[TuesdayStartTime], [TuesdayEndTime], [WednesdayStartTime], [WednesdayEndTime], 
		[ThursdayStartTime], [ThursdayEndTime], [FridayStartTime], [FridayEndTime], 
		[SaturdayStartTime], [SaturdayEndTime], [RequestID]	
	)
	VALUES
	(@SundayStart, @SundayEnd, @MondayStart, @MondayEnd,
		@TuesdayStart, @TuesdayEnd, @WednesdayStart, @WednesdayEnd,
		@ThursdayStart, @ThursdayEnd, @FridayStart, @FridayEnd,
		@SaturdayStart, @SaturdayEnd, SCOPE_IDENTITY())
END
GO

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Method to retrieve all submitted scheduling related requests by status
*/
PRINT '' PRINT '*** Creating sp_select_requests_by_status'
GO
CREATE PROCEDURE [sp_select_requests_by_status]
(
	@OpenStatus			[bit]
)
AS
BEGIN
	SELECT [RequestID], [RequestTypeID], [RequestingUserID], [DateCreated], [User].[Email]
	FROM [dbo].[request]
	INNER JOIN [dbo].[User] ON [request].[RequestingUserID] = [User].[UserID]
	WHERE [Open] = @OpenStatus
	AND ([RequestTypeID] = 'Time Off'
			OR [RequestTypeID] = 'Availability Change'
			OR [RequestTypeID] = 'Schedule Change')
END
GO

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Method to retrieve a TimeOffRequest with a specified RequestID
*/
DROP PROCEDURE IF EXISTS [sp_select_time_off_request_by_requestid]
GO
PRINT '' PRINT '*** Creating sp_select_time_off_request_by_requestid'
GO
CREATE PROCEDURE [sp_select_time_off_request_by_requestid]
(
	@RequestID			[int]
)
AS
BEGIN
	SELECT [TimeOffRequestID], [EffectiveStart], [EffectiveEnd], [ApprovalDate], [ApprovingUserID], [RequestID]
	FROM [dbo].[timeOffRequest]
	WHERE [RequestID] = @RequestID
END
GO

/*
Created by: Kaleb Bachert
Date: 2/19/2020
Comment: Method to approve a specified request
*/
DROP PROCEDURE IF EXISTS [sp_approve_time_off_request]
GO
PRINT '' PRINT '*** Creating sp_approve_time_off_request'
GO
CREATE PROCEDURE [sp_approve_time_off_request]
(
	@RequestID		[int],
	@UserID			[int]
)
AS
BEGIN
	UPDATE [dbo].[timeOffRequest]
	SET [ApprovingUserID] = @UserID,
		[ApprovalDate] = GETDATE()
	WHERE [RequestID] = @RequestID
	AND [ApprovingUserID] IS NULL

	UPDATE [dbo].[request]
	SET [Open] = 0
	WHERE [RequestID] = @RequestID
	AND [Open] = 1
	
	SELECT @@ROWCOUNT
END
GO

/*
Created by: Awaab Elamin
Date: 2/18/2020
Comment: Sproc to update the status of adoption Application.
*/
GO
print '' print '*** Creating sp_update_adoption_application_status'
GO
CREATE PROCEDURE [dbo].[sp_update_adoption_application_status]
(@status [nvarchar](100), @AdoptionApplicationID [int])
AS
BEGIN
	UPDATE [dbo].[AdoptionApplication]
	SET [Status] = @Status
	WHERE [AdoptionApplicationID] = @AdoptionApplicationID
	RETURN @@ROWCOUNT
END
/*
Created by: Awaab Elamin
Date: 2/12/2020
Comment: Create SP retrieve Customer Answers from CustomerAnswer Table by using Customer ID
Updated By: Awaab Elamin
Date: 3/15/2020
Comment: Updated CustomerID to CustomerEmail
*/
GO
print '' print '*** sp_get_Customer_Answer_By_CustomrEmail'
GO
DROP PROCEDURE IF EXISTS [sp_get_Customer_Answer_By_CustomrEmail]
GO
Create PROCEDURE [dbo].[sp_get_Customer_Answer_By_CustomrEmail]
(
	@CustomerEmail Nvarchar(250)
)
AS
BEGIN
	SELECT 	[QuestionDescription],[Answer]
	From 	[dbo].[CustomerAnswers]
	WHERE	[CustomerEmail] = @CustomerEmail
END
GO

GO
/*
Created by: Awaab Elamin
Date: 2/12/2020
Comment: Create SP retrieve Customer ID from Customers  Table by using user ID
Updated by Awaab Elamin
Date: 3/15/2020
Comment: Canceled SP because we don't need it after Customer Table Updated

GO
print '' print '*** sp_get_CustomerID_By_User_ID'
GO
Create PROCEDURE [dbo].[sp_get_CustomerID_By_User_ID]
(
	@UserID int
)
AS
BEGIN
	SELECT 	[CustomerID]
	From 	[dbo].[Customer]
	WHERE	[UserID] = @UserID;
END
GO
*/

/*
Created by: Awaab Elamin
Date: 2/12/2020
Comment: Create SP retrieve question description by question ID
*/
GO
print '' print '*** Creating sp_get_question_description_by_questionId'
GO
DROP PROCEDURE IF EXISTS [sp_get_question_description_by_questionId]
GO
CREATE PROCEDURE [dbo].[sp_get_question_description_by_questionId]
(
	@QuestionID int
)
AS
BEGIN
	SELECT 	[Description]
	From 	[dbo].[GeneralQusetions]
	WHERE	[QuestionID] = @QuestionID
END
GO
/*
Created by: Awaab Elamin
Date: 2/5/2020
Comment: Spoc to retrieve all Adoption Applications
Updated by: Awaab Elamin
Date: 3/15/2020
Comment: Update CustomerID to CustomerEmail
*/
GO
print '' print '*** Creating sp_get_Adoption_Application'
GO
DROP PROCEDURE IF EXISTS [sp_get_Adoption_Application]
GO
Create PROCEDURE [dbo].[sp_get_Adoption_Application]
AS
BEGIN
	SELECT 	[AdoptionApplicationID],
			[dbo].[AdoptionApplication].[CustomerEmail],
			[dbo].[Animal].[AnimalName],
			[dbo].[AdoptionApplication].[Status],
			[dbo].[AdoptionApplication].[RecievedDate]
	From 	[dbo].[AdoptionApplication]
	Inner Join [dbo].[Animal] 
	on [dbo].[AdoptionApplication].[AnimalID] = [dbo].[Animal].[AnimalID]
END
GO
/*
Created by: Awaab Elamin
Date: 2/6/2020
Comment: Sproc retrieve animal record by its ID.
*/
GO
GO
print '' print '*** Creating sp_get_Animal_by_id'
GO
DROP PROCEDURE IF EXISTS [sp_get_animal_by_id]
GO
Create PROCEDURE [dbo].[sp_get_animal_by_id]
(
	@animalId int
)
AS
BEGIN
	SELECT 	[AnimalID] ,
			[AnimalName],
			[Dob] ,
			[AnimalBreed] ,
			[ArrivalDate] ,
			[CurrentlyHoused] ,
			[Adoptable],
			[Active] ,
			[AnimalSpeciesID]
	FROM 	[dbo].[Animal]
	WHERE	[AnimalID] = @animalId
END
GO
/*
Created by: Awaab Elamin
Date: 2/15/2020
Comment: Create SP retrieve Adoption Application by Customer ID
Updated By: Awaab Elamin
Date: 3/15/2020
Comment: Update Sp to retrieve the Application by Customer Email
*/
GO
print '' print '*** Creating sp_get_Adoption_Application_By_CustomerEmail'
GO
DROP PROCEDURE IF EXISTS [sp_get_Adoption_Application_By_CustomerEmail]
GO
CREATE PROCEDURE [dbo].[sp_get_Adoption_Application_By_CustomerEmail]
(@customerEmail [nvarchar](250))
AS
BEGIN
	SELECT 	[AdoptionApplicationID],
			[AnimalID],
			[Status],
			[RecievedDate]
	From 	[dbo].[AdoptionApplication]
	WHERE	[CustomerEmail] = @customerEmail
END
GO

/*
Created by: Alex Diers
Date: 2/28/2020
Comment: Stored procedure to add a training video
*/
DROP PROCEDURE IF EXISTS [sp_insert_training_video]
GO
PRINT '' PRINT '*** Creating sp_insert_training_video'
GO
CREATE PROCEDURE [sp_insert_training_video]
(
	@TrainingVideoID	[nvarchar](150),
	@RunTimeMinutes		[int],
	@RunTimeSeconds 	[int],
	@Description 		[nvarchar](1000)
)
AS
BEGIN
	INSERT INTO [dbo].[TrainingVideo]
		([TrainingVideoID], [RunTimeMinutes], [RunTimeSeconds], [Description])
	VALUES
		(@TrainingVideoID, @RunTimeMinutes, @RunTimeSeconds, @Description)
	SELECT SCOPE_IDENTITY()
END
GO

/*
Created by: Alex Diers
Date: 2/28/2020
Comment: Stored procedure to select the videos to watch
*/
DROP PROCEDURE IF EXISTS [sp_select_videos_by_employee]
GO
PRINT '' PRINT '*** Creating sp_select_videos_by_employee'
GO
CREATE PROCEDURE [sp_select_videos_by_employee]
AS
BEGIN
	SELECT	[TrainingVideoID], [RunTimeMinutes], [RunTimeSeconds], [Description]
	FROM		[TrainingVideo]
	ORDER BY [TrainingVideoID]
END
GO

/*
Created by: Chase Schulte
Date: 2/28/2020
Comment: Stored procedure to update a training video
*/
DROP PROCEDURE IF EXISTS [sp_update_trainer_video]
GO
PRINT '' PRINT '*** Creating sp_update_trainer_video'
Go
CREATE PROCEDURE [sp_update_trainer_video]
(
	@OldTrainingVideoID	[nvarchar](150),
	@OldRunTimeMinutes	[int],
	@OldRunTimeSeconds 	[int],
	@OldDescription 	[nvarchar](1000),


	--New rows
	@NewRunTimeMinutes	[int],
	@NewRunTimeSeconds 	[int],
	@NewDescription 	[nvarchar](1000)


)
AS
BEGIN
	Update [dbo].[TrainingVideo]
	Set
	[RunTimeMinutes]=@NewRunTimeMinutes,
	[RunTimeSeconds]=@NewRunTimeSeconds,
	[Description]=@NewDescription
	Where [TrainingVideoID] = @OldTrainingVideoID
	And [RunTimeMinutes] = @OldRunTimeMinutes
	And [RunTimeSeconds] = @OldRunTimeSeconds
	And [Description] = @OldDescription
	Return @@ROWCOUNT
END
GO

/*
Created by: Chase Schulte
Date: 2/28/2020
Comment: Stored procedure to deactivate a training video
*/
DROP PROCEDURE IF EXISTS [sp_deactivate_training_video]
GO
PRINT '' PRINT '*** Creating sp_deactivate_trainer_video'
GO
CREATE PROCEDURE [sp_deactivate_training_video]
(
	@TrainingVideoID	[nvarchar](150)
)
AS
BEGIN
	Update [dbo].[TrainingVideo]
	Set
	[Active]=0
	Where [TrainingVideoID] = @TrainingVideoID
	Return @@ROWCOUNT
END
GO

/*
Created by: Chase Schulte
Date: 2/28/2020
Comment: Stored procedure to activate a training video
*/
DROP PROCEDURE IF EXISTS [sp_reactivate_trainer_video]
GO
PRINT '' PRINT '*** Creating sp_reactivate_trainer_video '
GO
CREATE PROCEDURE [sp_reactivate_trainer_video ]
(
	@TrainingVideoID	[nvarchar](150)
)
AS
BEGIN
	Update [dbo].[TrainingVideo]
	Set
	[Active]=1
	Where [TrainingVideoID] = @TrainingVideoID
	Return @@ROWCOUNT
END
GO

/*
Created by: Chase Schulte
Date: 3/03/2020
Comment: Stored procedure to select the videos to watch by their active state
*/
DROP PROCEDURE IF EXISTS [sp_select_videos_by_active]
GO
PRINT '' PRINT '*** Creating sp_select_videos_by_active'
GO
CREATE PROCEDURE [sp_select_videos_by_active]
(
	@Active 	[bit]
)
AS
	BEGIN
	SELECT	[TrainingVideoID], [RunTimeMinutes], [RunTimeSeconds], [Description],[Active]
	FROM		[TrainingVideo]
	Where [Active] = @Active
	ORDER BY [TrainingVideoID]
END
GO

/*
Created by: Tener Karar
Date: 02/16/2020
Comment:retrieve ItemLocations List
*/
DROP PROCEDURE IF EXISTS [sp_retrieve_ItemLocations_List]
GO
PRINT '' PRINT '*** Creating sp_retrieve_ItemLocations_List'
GO
CREATE PROCEDURE sp_retrieve_ItemLocations_List( @ItemID int)
AS
BEGIN
	SELECT  [LocationID]
	FROM [dbo].[ItemLocationLine ]
	where [ItemID] = @ItemID
END
GO

/*
Created by: Tener Karar and Brandyn Coverdill
Date: 02/16/2020
Comment:retrieve Item List
Updated By: Matt Deaton
Date: 2020-03-07
Comment: Added the ShelterItem to the Select to allow Shelter Item to show up once ran.
*/
DROP PROCEDURE IF EXISTS [sp_retrieve_item_list]
GO
PRINT '' PRINT '*** Creating sp_retrieve_item_list'
GO
CREATE PROCEDURE sp_retrieve_item_list
AS
BEGIN
	SELECT [ItemID], [ItemName]	,[ItemQuantity] ,[ItemCategoryID], [ShelterItem]
	FROM [dbo].[Item]
END
GO

/*
Created by: Tener Karar
Date: 02/16/2020
Comment:retrieve ItemCategory List
*/
DROP PROCEDURE IF EXISTS [sp_retrieve_ItemCategory_list]
GO
PRINT '' PRINT '*** Creating sp_retrieve_ItemCategory_list'
GO
CREATE PROCEDURE sp_retrieve_ItemCategory_list
AS
BEGIN
	SELECT [ItemCategoryID] ,[Description]
	FROM [dbo].[ItemCategory ]
END
GO

/*
Created by: Tener Karar
Date: 02/16/2020
Comment:update Item Location
*/
DROP PROCEDURE IF EXISTS [sp_update_Item_Location]
GO
PRINT '' PRINT '*** Creating sp_update_Item_Location'
GO
CREATE PROCEDURE [sp_update_Item_Location]
(
	@ItemID	         	[int ],
	@NewLocationID		[int],

	@OldLocationID		[int]
)
AS
BEGIN
	UPDATE [dbo].[ItemLocationLine]
	SET [LocationID] = 	@NewLocationID
	WHERE 	[ItemID] =	   @ItemID
    AND	[LocationID] = 	@OldLocationID
	RETURN @@ROWCOUNT
END
GO

/*
Created By: Timothy Lickteig
Date: 2/07/2020
Comment: Procedure for INSERTing volunteer shifts
*/
DROP PROCEDURE IF EXISTS [sp_insert_volunteer_shift]
GO
PRINT '' PRINT '*** Creating procedure sp_insert_volunteer_shift'
GO
CREATE PROCEDURE [sp_insert_volunteer_shift]
(
	@ShiftDescription 	[nvarchar](1080),
	@ShiftTitle 		[nvarchar](500),
	@ShiftDate 			[date],
	@ShiftStartTime 	[time],
	@ShiftEndTime 		[time],
	@Recurrance 		[nvarchar](100),
	@IsSpecialEvent 	[bit],
	@ShiftNotes 		[nvarchar](1080),
	@ScheduleID 		[int]
)
AS
BEGIN
	INSERT INTO [dbo].[VolunteerShift]
		([ShiftDescription], [ShiftTitle], [ShiftDate],
		[ShiftStartTime], [ShiftEndTime], [Recurrance],
		[IsSpecialEvent], [ShiftNotes], [ScheduleID])
	VALUES
		(@ShiftDescription, @ShiftTitle, @ShiftDate,
		@ShiftStartTime, @ShiftEndTime, @Recurrance,
		@IsSpecialEvent, @ShiftNotes, @ScheduleID)
END
GO

/*
Created By: Timothy Lickteig
Date: 2/05/2020
Comment: Procedure for deleting a volunteer shift
*/
DROP PROCEDURE IF EXISTS [sp_delete_volunteer_shift]
GO
PRINT '' PRINT '*** Creating procedure sp_delete_volunteer_shift'
GO
CREATE PROCEDURE [sp_delete_volunteer_shift]
(
	@ShiftID [int]
)
AS
BEGIN
	DELETE FROM [dbo].[VolunteerShift]
	WHERE [VolunteerShiftID] = @ShiftID
END
GO

/*
Created By: Timothy Lickteig
Date: 2/10/2020
Comment: Procedure for updating a volunteer shift
*/
DROP PROCEDURE IF EXISTS [sp_update_volunteer_shift]
GO
PRINT '' PRINT '*** Creating procedure sp_update_volunteer_shift'
GO
CREATE PROCEDURE [sp_update_volunteer_shift]
(
	@VolunteerShiftID [int],
	@ShiftDescription [nvarchar](1080),
	@ShiftDate [date],
	@ShiftTitle [nvarchar](500),
	@ShiftStartTime [time],
	@ShiftEndTime [time],
	@Recurrance [nvarchar](100),
	@IsSpecialEvent [bit],
	@ShiftNotes [nvarchar](1080),
	@ScheduleID [int]
)
AS
BEGIN
	UPDATE [VolunteerShift]
	SET [ShiftDescription] = @ShiftDescription,
	    [ShiftDate] = @ShiftDate,
	    [ShiftTitle] = @ShiftTitle,
	    [ShiftStartTime] = @ShiftStartTime,
	    [ShiftEndTime] = @ShiftEndTime,
	    [Recurrance] = @Recurrance,
	    [IsSpecialEvent] = @IsSpecialEvent,
	    [ShiftNotes] = @ShiftNotes,
	    [ScheduleID] = @ScheduleID
	WHERE [VolunteerShiftID] = @VolunteerShiftID
	SELECT @@ROWCOUNT
END
GO

/*
Created By: Timothy Lickteig
Date: 2/17/2020
Comment: Procedure for selecting all volunteer shifts
*/
DROP PROCEDURE IF EXISTS [sp_select_all_volunteer_shifts]
GO
PRINT '' PRINT '*** Creating procedure sp_select_all_volunteer_shifts'
GO

CREATE PROCEDURE [sp_select_all_volunteer_shifts]
AS
BEGIN
	SELECT
		[VolunteerShiftID], [ShiftDescription],
		[ShiftTitle], [ShiftStartTime], [ShiftEndTime],
		[Recurrance], [IsSpecialEvent], [ShiftNotes],
		[ShiftDate], [ScheduleID]
	FROM [dbo].[VolunteerShift]
END
GO

/*
Created By: Chuck Baxter
Date: 2/28/2020
Comment: select animal species
*/
DROP PROCEDURE IF EXISTS [sp_select_animal_species]
GO
PRINT '' PRINT '*** Creating procedure sp_select_animal_species'
GO
CREATE PROCEDURE [sp_select_animal_species]
AS
BEGIN
    SELECT 	[AnimalSpeciesID]
    FROM	[dbo].[AnimalSpecies]
END
GO

--Stored Procedures for Event Processes
/*
	Created by: Steve Coonrod
	Date: 		2/9/2020
	Comment: 	Stored Procedure for adding a new event to the DB
*/
DROP PROCEDURE IF EXISTS [sp_insert_event]
GO
PRINT '' PRINT '*** Creating sp_insert_event'
GO
CREATE PROCEDURE [sp_insert_event]
(
	@CreatedByID				[int],
	@DateCreated				[datetime],
	@EventName					[nvarchar](150),
	@EventTypeID				[nvarchar](50),
	@EventDateTime				[datetime],
	@EventAddress				[nvarchar](200),
	@EventCity					[nvarchar](50),
	@EventState					[nvarchar](50),
	@EventZipcode				[nvarchar](15),
	@EventPictureFileName		[nvarchar](250),
	@Status						[nvarchar](50),
	@Description				[nvarchar](500)
)
AS
BEGIN
	INSERT INTO [dbo].[Event]
		([CreatedByID],[DateCreated],[EventName],[EventTypeID],[EventDateTime],[EventAddress],
		[EventCity],[EventState],[EventZipcode],[EventPictureFileName],[Status],[Description])
	VALUES
		(@CreatedByID,@DateCreated,@EventName,@EventTypeID,@EventDateTime,@EventAddress,
		@EventCity,@EventState,@EventZipcode,@EventPictureFileName,@Status,@Description)
	SELECT SCOPE_IDENTITY()
END
GO

/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for editing an event in the DB
*/
DROP PROCEDURE IF EXISTS [sp_update_event]
GO
PRINT '' PRINT '*** Creating sp_update_event'
GO
CREATE PROCEDURE [sp_update_event]
(
	@EventID					[int],
	@OldCreatedByID				[int],
	@OldDateCreated				[datetime],
	@OldEventName				[nvarchar](150),
	@OldEventTypeID				[nvarchar](50),
	@OldEventDateTime			[datetime],
	@OldEventAddress			[nvarchar](200),
	@OldEventCity				[nvarchar](50),
	@OldEventState				[nvarchar](50),
	@OldEventZipcode			[nvarchar](15),
	@OldEventPictureFileName	[nvarchar](250),
	@OldStatus					[nvarchar](50),
	@OldDescription				[nvarchar](500),
	@NewCreatedByID				[int],
	@NewDateCreated				[datetime],
	@NewEventName				[nvarchar](150),
	@NewEventTypeID				[nvarchar](50),
	@NewEventDateTime			[datetime],
	@NewEventAddress			[nvarchar](200),
	@NewEventCity				[nvarchar](50),
	@NewEventState				[nvarchar](50),
	@NewEventZipcode			[nvarchar](15),
	@NewEventPictureFileName	[nvarchar](250),
	@NewStatus					[nvarchar](50),
	@NewDescription				[nvarchar](500)
)
AS
BEGIN
    UPDATE 	[dbo].[Event]
	SET		[CreatedByID] = @NewCreatedByID,
			[DateCreated] = @NewDateCreated,
			[EventName] = @NewEventName,
			[EventTypeID] = @NewEventTypeID,
			[EventDateTime] = @NewEventDateTime,
			[EventAddress] = @NewEventAddress,
			[EventCity] = @NewEventCity,
			[EventState] = @NewEventState,
			[EventZipcode] = @NewEventZipcode,
			[EventPictureFileName] = @NewEventPictureFileName,
			[Status] = @NewStatus,
			[Description] = @NewDescription

	WHERE 	[EventID] = @EventID
		AND	[CreatedByID] = @OldCreatedByID
		AND	[DateCreated] = @OldDateCreated
		AND	[EventName] = @OldEventName
		AND	[EventTypeID] = @OldEventTypeID
		AND	[EventDateTime] = @OldEventDateTime
		AND	[EventAddress] = @OldEventAddress
		AND	[EventCity] = @OldEventCity
		AND	[EventState] = @OldEventState
		AND	[EventZipcode] = @OldEventZipcode
		AND	[EventPictureFileName] = @OldEventPictureFileName
		AND	[Status] = @OldStatus
		AND	[Description] = @OldDescription
	RETURN	@@ROWCOUNT
END
GO

/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for retrieving an Event from the DB
*/
DROP PROCEDURE IF EXISTS [sp_select_event_by_ID]
GO
PRINT '' PRINT '*** Creating sp_select_event_by_ID'
GO
CREATE PROCEDURE [sp_select_event_by_ID]
(
	@EventID			[int]
)
AS
BEGIN
	SELECT [CreatedByID],[DateCreated],[EventName],[EventTypeID],
		   [EventDateTime],[EventAddress],[EventCity],[EventState],[EventZipcode],
		   [EventPictureFileName],[Status],[Description]
	FROM   [dbo].[Event]
	WHERE  [EventID] = @EventID
	RETURN @@ROWCOUNT
END
GO

/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for retrieving a List of All Event from the DB
*/
DROP PROCEDURE IF EXISTS [sp_select_all_events]
GO
PRINT '' PRINT '*** Creating sp_select_all_events'
GO
CREATE PROCEDURE [sp_select_all_events]
AS
BEGIN
	SELECT [EventID],[CreatedByID],[DateCreated],[EventName],[EventTypeID],
		   [EventDateTime],[EventAddress],[EventCity],[EventState],[EventZipcode],
		   [EventPictureFileName],[Status],[Description]
	FROM   [dbo].[Event]
END
GO

/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for deleting an Event from the DB
		ADMIN ONLY
*/
DROP PROCEDURE IF EXISTS [sp_delete_event]
GO
PRINT '' PRINT '*** Creating sp_delete_event'
GO
CREATE PROCEDURE [sp_delete_event]
(
	@EventID		[int]
)
AS
BEGIN
	DECLARE @requestID [int]
	SET @requestID = (SELECT 	[dbo].[EventRequest].[RequestID]
					  FROM 		[dbo].[EventRequest]
					  WHERE 	[EventID] = @EventID)

	DELETE FROM [dbo].[EventRequest] WHERE [EventID] = @EventID
	DELETE FROM [dbo].[Request] WHERE [RequestID] = @requestID
	DELETE FROM [dbo].[Event] WHERE [EventID] = @EventID
	RETURN @@ROWCOUNT
END
GO

--EventType Procedures ADMIN ONLY
/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for adding a new event type to the DB
*/
DROP PROCEDURE IF EXISTS [sp_insert_event_type]
GO
PRINT '' PRINT '*** Creating sp_insert_event_type'
GO
CREATE PROCEDURE [sp_insert_event_type]
(
	@EventTypeID				[nvarchar](50),
	@Description				[nvarchar](100)
)
AS
BEGIN
	INSERT INTO [dbo].[EventType]
		([EventTypeID],[Description])
	VALUES
		(@EventTypeID, @Description)
	RETURN @@ROWCOUNT
END
GO

/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for retrieving all event types in the DB
*/
DROP PROCEDURE IF EXISTS [sp_select_all_event_types]
GO
PRINT '' PRINT '*** Creating sp_select_all_event_types'
GO
CREATE PROCEDURE [sp_select_all_event_types]
AS
BEGIN
	SELECT  [EventTypeID],[Description]
	FROM	[dbo].[EventType]
END
GO

--EventRequest Procedures
/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for adding a new Event Request to the DB
*/
DROP PROCEDURE IF EXISTS [sp_insert_event_request]
GO
PRINT '' PRINT '*** Creating sp_insert_event_request'
GO
CREATE PROCEDURE [sp_insert_event_request]
(
	@EventID					[int],
	@RequestID					[int],
	@ReviewerID					[int],
	@DisapprovalReason			[nvarchar](500),
	@DesiredVolunteers			[int],
	@Active						[bit]
)
AS
BEGIN
	INSERT INTO [dbo].[EventRequest]
		([EventID],[RequestID],[ReviewerID],[DisapprovalReason],[DesiredVolunteers],[Active])
	VALUES
		(@EventID, @RequestID, @ReviewerID, @DisapprovalReason, @DesiredVolunteers, @Active)
	RETURN @@ROWCOUNT
END
GO

/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for adding a new Request to the DB
	
	Updated On : 2020-03-15
*/
DROP PROCEDURE IF EXISTS [sp_insert_request]
--GO
PRINT '' PRINT '*** Creating sp_insert_request'
GO
CREATE PROCEDURE [sp_insert_request]
(
	@RequestID			[int] OUTPUT,
	@DateCreated		[datetime],
	@RequestTypeID		[nvarchar](50),
	@RequestingUserID	[int],
	@Open				[bit]
)
AS
BEGIN
	INSERT INTO [dbo].[request]
		([DateCreated],[RequestTypeID],[RequestingUserID],[Open])
	VALUES
		(@DateCreated, @RequestTypeID, @RequestingUserID, @Open)
	SELECT @RequestID = SCOPE_IDENTITY()
END
GO

/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: Stored Procedure for selecting new requests associated with a DepartmentID
*/
DROP PROCEDURE IF EXISTS [sp_select_new_requests_by_departmentID]
GO
PRINT '' PRINT '*** Creating sp_select_new_requests_by_departmentID'
GO
CREATE PROCEDURE [sp_select_new_requests_by_departmentID]
(
	@DepartmentID				[nvarchar](50)
)
AS
BEGIN
	SELECT DISTINCT r.[RequestID], r.[DateCreated], r.[RequestTypeID],
		dr.[RequestingUserID], dr.[RequestGroupID], dr.[RequestedGroupID],
		dr.[RequestSubject], dr.[RequestTopic], dr.[RequestBody]
	FROM [request] AS r JOIN [DepartmentRequest] AS dr ON
		[RequestID] = [DeptRequestID]
	WHERE ([RequestGroupID] = @DepartmentID AND [DateAcknowledged] is NULL) OR
		([DateAcknowledged] is NULL AND [RequestedGroupID] = @DepartmentID)
END
GO

/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: Stored Procedure for selecting active requests associated with a DepartmentID
*/
DROP PROCEDURE IF EXISTS [sp_select_active_requests_by_departmentID]
GO
PRINT '' PRINT '*** Creating sp_select_active_requests_by_departmentID'
GO
CREATE PROCEDURE [sp_select_active_requests_by_departmentID]
(
	@DepartmentID				[nvarchar](50)
)
AS
BEGIN
	SELECT DISTINCT r.[RequestID], r.[DateCreated], r.[RequestTypeID],
		dr.[RequestingUserID], dr.[RequestGroupID], dr.[RequestedGroupID],
		dr.[DateAcknowledged], dr.[AcknowledgingUserID], dr.[RequestSubject],
		dr.[RequestTopic], dr.[RequestBody]
	FROM [request] AS r JOIN [DepartmentRequest] AS dr ON
		[RequestID] = [DeptRequestID]
	WHERE ([RequestGroupID] = @DepartmentID OR [RequestedGroupID] = @DepartmentID) AND
		([DateAcknowledged] is NOT NULL AND [DateCompleted] is NULL)
END
GO

/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: Stored Procedure for selecting completed requests associated with a DepartmentID
*/
DROP PROCEDURE IF EXISTS [sp_select_completed_requests_by_departmentID]
GO
PRINT '' PRINT '*** Creating sp_select_completed_requests_by_departmentID'
GO
CREATE PROCEDURE [sp_select_completed_requests_by_departmentID]
(
	@DepartmentID				[nvarchar](50)
)
AS
BEGIN
	SELECT DISTINCT r.[RequestID], r.[DateCreated], r.[RequestTypeID],
		dr.[RequestingUserID], dr.[RequestGroupID], dr.[RequestedGroupID],
		dr.[DateAcknowledged], dr.[AcknowledgingUserID], dr.[DateCompleted],
		dr.[CompletedUserID], dr.[RequestSubject], dr.[RequestTopic], dr.[RequestBody]
	FROM [request] AS r JOIN [DepartmentRequest] AS dr ON
		[RequestID] = [DeptRequestID]
	WHERE ([RequestGroupID] = @DepartmentID OR [RequestedGroupID] = @DepartmentID) AND
		([DateAcknowledged] is NOT NULL AND [DateCompleted] is NOT NULL)
END
GO

/*
Created by: Ryan Morganti
Date: 2020/02/18
Comment: Stored Procedure for selecting all the Request Types
*/
DROP PROCEDURE IF EXISTS [sp_select_all_request_types]
GO
PRINT '' PRINT '*** Creating sp_select_all_request_types'
GO
CREATE PROCEDURE [sp_select_all_request_types]
AS
BEGIN
	SELECT [RequestTypeID]
	FROM [RequestType]
END
GO

/*
Created by: Ryan Morganti
Date: 2020/02/18
Comment: Stored Procedure for selecting all the DepartmentIDs
*/
DROP PROCEDURE IF EXISTS [sp_select_all_departmentIDs]
GO
PRINT '' PRINT '*** Creating sp_select_all_departmentIDs'
GO
CREATE PROCEDURE [sp_select_all_departmentIDs]
AS
BEGIN
	SELECT [DepartmentID]
	FROM [Department]
END
GO

/*
Created by: Ryan Morganti
Date: 2020/02/18
Comment: Stored Procedure for selecting employee IDs and names to link data in application
*/
DROP PROCEDURE IF EXISTS [sp_select_all_employee_names]
GO
PRINT '' PRINT '*** Creating sp_select_all_employee_names'
GO
CREATE PROCEDURE [sp_select_all_employee_names]
AS
BEGIN
	SELECT [UserID], [FirstName], [LastName]
	FROM [User]
END
GO

/*
Created by: Ryan Morganti
Date: 2020/02/22
Comment: Stored Procedure for retrieving the Departments an employee is associated with
*/
DROP PROCEDURE IF EXISTS [select_all_departments_by_userID]
GO
PRINT '' PRINT '*** Creating stored procedure select_all_departments_by_userID'
GO
CREATE PROCEDURE [select_all_departments_by_userID](
	@UserID				[int]
)
AS
BEGIN
	SELECT [DepartmentID]
	FROM [EmployeeDepartment]
	WHERE [EmployeeID] = @UserID
END

/*
Created by: Brandyn T. Coverdill
Date: 2/22/2020
Comment: Stored Procedure that adds items to inventory.
*/
DROP PROCEDURE IF EXISTS [sp_add_items]
GO
PRINT '' PRINT '*** Creating sp_add_items'
GO
CREATE PROCEDURE [sp_add_items]
(
	@ItemName nvarchar(50),
	@ItemQuantity int,
	@ItemCategoryID nvarchar(50),
	@ItemDescription nvarchar(250)
)
AS
BEGIN
	INSERT INTO Item
    (
		[ItemName],
		[ItemCategoryID],
		[ItemQuantity],
		[ItemDescription]
	)
	VALUES
    (
		@ItemName,
		@ItemCategoryID,
		@ItemQuantity,
		@ItemDescription
	)
END
GO

/*
Created By: Brandyn T. Coverdill
Date: 2/22/2020
Comment: Stored Procedure that adds a new item cateGOry
*/
DROP PROCEDURE IF EXISTS [sp_add_new_cateGOry]
GO
PRINT '' PRINT '*** Creating [sp_add_new_cateGOry]'
GO
CREATE PROCEDURE [sp_add_new_cateGOry]
(
	@ItemCategoryID nvarchar(50),
    @Description nvarchar(250)
)
AS
BEGIN
	INSERT INTO [dbo].[ItemCategory](
		[ItemCategoryID],
		[Description]
	)
	VALUES(@ItemCategoryID, @Description)
END
GO

/*
Created by: Brandyn T. Coverdill
Date: 2/22/2020
Comment: Stored Procedure that gets a list of cateGOries.
*/
DROP PROCEDURE IF EXISTS [sp_list_cateGOries]
GO
PRINT '' PRINT '*** Creating sp_list_cateGOries'
GO
CREATE PROCEDURE [sp_list_cateGOries]
AS
BEGIN
	SELECT DISTINCT [ItemCategoryID]
	FROM [dbo].[ItemCategory]
END
GO

/*
Created by: Brandyn T. Coverdill
Date: 2/22/2020
Comment: Stored Procedure that gets a list of items from inventory.
Updated By: Matt Deaton
Date: 2020-03-07
Comment: Added the ShelterItem to the Select to allow Shelter Item to show up once ran.
*/
DROP PROCEDURE IF EXISTS [sp_retrieve_items]
GO
PRINT '' PRINT '*** Creating sp_retrieve_items'
GO
CREATE PROCEDURE [sp_retrieve_items]
AS
BEGIN
	SELECT 
        [i].[ItemID], 
        [i].[ItemName], 
        [i].[ItemQuantity], 
        [ic].[ItemCategoryID], 
        [i].[ItemDescription],
		[i].[ShelterItem]
	FROM [dbo].[Item] i
	INNER JOIN [dbo].[ItemCategory] ic
	ON [i].[ItemCategoryID] = [ic].[ItemCategoryID]
END
GO

DROP PROCEDURE IF EXISTS [sp_insert_volunteer]
GO
PRINT '' PRINT '*** Creating sp_insert_volunteer'
GO
CREATE PROCEDURE [sp_insert_volunteer]
(
	@FirstName	 [nvarchar](500),
	@LastName	 [nvarchar](500),
	@Email       [nvarchar](100),
	@PhoneNumber [nvarchar](12),
	@OtherNotes  [nvarchar](2000)
)
AS
BEGIN
	INSERT INTO [dbo].[Volunteer]
		([FirstName], [LastName], [Email], [PhoneNumber], [OtherNotes])
	VALUES
		(@FirstName, @LastName, @Email, @PhoneNumber, @OtherNotes)
	SELECT SCOPE_IDENTITY()
END
GO

print '' print '*** Creating sp_update_volunteer'
/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: updates an existing volunteer record
*/
go
create procedure [sp_update_volunteer]
(
	@VolunteerID	    [int],
	@OldFirstName   	[nvarchar](50),
	@OldLastName    	[nvarchar](50),
	@OldPhoneNumber 	[nvarchar](11),
	@OldEmail           [nvarchar](250),
	@OldNotes			[nvarchar](2000),
	@NewFirstName   	[nvarchar](50),
	@NewLastName    	[nvarchar](50),
	@NewPhoneNumber 	[nvarchar](11),
	@NewEmail           [nvarchar](250),
	@NewNotes			[nvarchar](2000)
)
as
begin
update [dbo].[Volunteer]
set
	[FirstName] = 	@NewFirstName,
	[LastName] = 	@NewLastName,
	[PhoneNumber] = @NewPhoneNumber,
	[Email] = 		@NewEmail,
	[OtherNotes]   = @NewNotes
where [VolunteerID] = @VolunteerID
	  AND	[FirstName] = 	@OldFirstName
	  AND	[LastName] = 	@OldLastName
	  AND	[PhoneNumber] = @OldPhoneNumber
	  AND	[Email] = 		@OldEmail
	  AND   [OtherNotes] =  @OldNotes
return @@ROWCOUNT
end
go

/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Gets Volunteers by first and last name
*/
DROP PROCEDURE IF EXISTS [sp_get_volunteer_by_name]
GO
PRINT '' PRINT '*** Creating sp_get_volunteer_by_name'
GO
CREATE PROCEDURE [sp_get_volunteer_by_name]
(
	@FirstName [nvarchar](500),
	@LastName [nvarchar](500)
)
AS
BEGIN
    SELECT
        VolunteerID, FirstName, LastName, Email, PhoneNumber, OtherNotes, Active
    FROM Volunteer
    WHERE FirstName = @FirstName
    AND LastName = @LastName
END
GO

print '' print '*** Creating sp_get_volunteer_by_first_name'
/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Gets Volunteers by first name
*/
go
create procedure [sp_get_volunteer_by_first_name]
(
	@FirstName [nvarchar](500)
)
as
begin
select
	VolunteerID, FirstName, LastName, Email, PhoneNumber, OtherNotes, Active
from Volunteer
where FirstName = @FirstName
end
go

print '' print '*** Creating sp_deactivate_volunteer'
/*
Created by: Josh Jackson
Date: 3/12/2020
Comment: changes volunteer active field to 0
*/
go
create procedure [sp_deactivate_volunteer]
(
	@VolunteerID		[int]
)
as
begin
update [dbo].[Volunteer]
set
	[Active] = 0
where [VolunteerID] = @VolunteerID
return @@ROWCOUNT
end
go

print '' print '*** Creating sp_reactivate_volunteer'
/*
Created by: Josh Jackson
Date: 3/12/2020
Comment: changes volunteer active field to 1
*/
go
create procedure [sp_reactivate_volunteer]
(
	@VolunteerID		[int]
)
as
begin
update [dbo].[Volunteer]
set
	[Active] = 1
where [VolunteerID] = @VolunteerID
return @@ROWCOUNT
end
go

/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Gets a list of all skills
*/
DROP PROCEDURE IF EXISTS [sp_select_all_skills]
GO
PRINT '' PRINT '*** Creating sp_select_all_skills'
GO
CREATE PROCEDURE [sp_select_all_skills]
AS
BEGIN
	SELECT [SkillID]
	FROM [dbo].[VolunteerSkills]
	ORDER BY [SkillID]
END
GO

/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Give a volunteer new skill
*/
DROP PROCEDURE IF EXISTS [sp_insert_volunteer_skill]
GO
PRINT '' PRINT '*** Creating sp_insert_volunteer_skill'
GO
CREATE PROCEDURE [sp_insert_volunteer_skill]
(
	@VolunteerID 			[int],
	@SkillID	 			[nvarchar](50)
)
AS
BEGIN
INSERT INTO [dbo].[VolunteerSkill]
	([VolunteerID], [SkillID])
	VALUES
	(@VolunteerID, @SkillID)
END
GO

/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Removes a volunteer's skill
*/
DROP PROCEDURE IF EXISTS [sp_delete_volunteer_skill]
GO
PRINT '' PRINT '*** Creating sp_delete_volunteer_skill'
GO
CREATE PROCEDURE [sp_delete_volunteer_skill]
(
	@VolunteerID			[int],
	@SkillID				[nvarchar](50)
)
AS
BEGIN
	DELETE FROM [dbo].[VolunteerSkill]
	WHERE [VolunteerID] =	@VolunteerID
	  AND [SkillID] = 		@SkillID
END
GO

print '' print '*** Creating sp_select_skills_by_volunteerID'
/*
Created by: Josh Jackson
Date: 3/13/2020
Comment: Gets a list all a volunteers skills by VolunteerID
*/
go
create procedure [sp_select_skills_by_volunteerID]
(
	@VolunteerID          [int]
)
as
begin
select
	[SkillID]
from [VolunteerSkill]
where [VolunteerID] = @VolunteerID
end
go

/*
Created by: Gabi Legrand
Date: 2/8/2020
Comment: Gets a list of all active volunteers
*/
DROP PROCEDURE IF EXISTS [sp_select_volunteers_by_active]
GO
PRINT '' PRINT '*** Creating sp_select_volunteers_by_active'
GO
CREATE PROCEDURE [sp_select_volunteers_by_active]
(

    @Active        [bit]

)
AS
BEGIN
    SELECT [VolunteerID], [FirstName], [LastName], [Email], [PhoneNumber], [OtherNotes], [Active]
    FROM  [dbo].[Volunteer]
    WHERE active = 1
    ORDER BY [LastName]
END
GO

/*
Created by: Zoey McDonald
Date: 2/20/2020
Comment: Insert a volunteer event.
*/
DROP PROCEDURE IF EXISTS [sp_insert_volunteer_event]
GO
PRINT '' PRINT '*** Creating sp_insert_volunteer_event'
GO
CREATE PROCEDURE [sp_insert_volunteer_event]
(
	@EventName	 		[nvarchar](500),
	@EventDescription	[nvarchar](4000),
	@Active      		[bit]
)
AS
BEGIN
	INSERT INTO [dbo].[VolunteerEvents]
		([EventName], [EventDescription], [Active])
	VALUES
		(@EventName, @EventDescription, @Active)
	SELECT SCOPE_IDENTITY()
END
GO

/*
Created by: Zoey McDonald
Date: 2/20/2020
Comment: Stored procedure for deleting a volunteer event.
*/
DROP PROCEDURE IF EXISTS [sp_delete_volunteer_event]
GO
PRINT '' PRINT '*** Creating procedure sp_delete_volunteer_event'
GO
CREATE PROCEDURE [sp_delete_volunteer_event]
(
	@VolunteerEventID [int]
)
AS
BEGIN
	DELETE FROM [dbo].[VolunteerEvents]
	WHERE [VolunteerEventID] = @VolunteerEventID
END
GO

/*
Created by: Zoey McDonald
Date: 2/20/2020
Comment: Stored procedure for updating a volunteer event.
*/
DROP PROCEDURE IF EXISTS [sp_update_volunteer_event]
GO
PRINT '' PRINT '*** Creating procedure sp_update_volunteer_event'
GO
CREATE PROCEDURE [sp_update_volunteer_event]
(
	@VolunteerEventID [int],
	@EventName [nvarchar](500),
	@EventDescription [nvarchar](4000)
)
AS
BEGIN
	UPDATE [VolunteerEvents]
	SET [EventName] = @EventName,
	[EventDescription] = @EventDescription
	WHERE [VolunteerEventID] = @VolunteerEventID
	SELECT @@ROWCOUNT
END
GO

/*
Created by: Zoey McDonald
Date: 2/20/2020
Comment: Stored procedure for selecting all volunteer events.
*/
DROP PROCEDURE IF EXISTS [sp_select_all_volunteer_events]
GO
PRINT '' PRINT '*** Creating procedure sp_select_all_volunteer_events'
GO
CREATE PROCEDURE [sp_select_all_volunteer_events]
AS 
BEGIN
	SELECT
		[VolunteerEventID],
		[EventName],
		[EventDescription]
	FROM [dbo].[VolunteerEvents]
END
GO

/*
Created by: Robert Holmes
Date: 2/18/2020
Comment: Stored procedure for selecting all products of a particular type. Updated 2020/03/17 to be compatible with new Product table sturcture.
*/
DROP PROCEDURE IF EXISTS [sp_select_products_by_type]
GO
PRINT '' PRINT '*** Creating stored procedure sp_select_products_by_type'
GO
CREATE PROCEDURE [sp_select_products_by_type]
(
	@ProductTypeID	[nvarchar](20)
)
AS
	BEGIN
	SELECT	[Product].[ProductID],
			[Product].[ItemID],
			[Item].[ItemName],
			[Item].[ItemCategoryID],
			[Product].[ProductTypeID],
			[Product].[Description],
			[Product].[Price],
			[Product].[Brand],
			[Product].[Taxable]
	FROM	[dbo].[Product]
	JOIN	[Item]	ON	[Item].[ItemID] = [Product].[ItemID]
	WHERE	[ProductTypeID] LIKE @ProductTypeID
END
GO

/*
Created by: Robert Holmes
Date: 2/18/2020
Comment: Stored procedure for selecting all products. Updated 2020/03/17 to be compatible with new Product table structure.
*/
DROP PROCEDURE IF EXISTS [sp_select_all_products]
GO
PRINT '' PRINT'*** Creating stored procedure sp_select_all_products'
GO
CREATE PROCEDURE [sp_select_all_products]
AS
	BEGIN
	SELECT	[Product].[ProductID],
			[Product].[ItemID],
			[Item].[ItemName],
			[Item].[ItemCategoryID],
			[Product].[ProductTypeID],
			[Product].[Description],
			[Product].[Price],
			[Product].[Brand],
			[Product].[Taxable]
	FROM	[dbo].[Product]
	INNER JOIN	[Item]	ON	[Item].[ItemID] = [Product].[ItemID]
END
GO



/*
Created By: Michael Thompson
Date: 2/20/2020
Comment: Stored Procedure to update the animal profiles with forward facing description and photo path
*/
DROP PROCEDURE IF EXISTS [sp_update_animal_profile]
GO
PRINT '' PRINT '*** Creating sp_update_animal_profile'
GO
CREATE PROCEDURE [sp_update_animal_profile]
(
	@AnimalID			[int],
	@ProfilePhoto		[nvarchar](50),
	@ProfileDescription	[nvarchar](500)
)
AS
BEGIN
	UPDATE [dbo].[Animal]
		SET [ProfilePhoto] = @ProfilePhoto,
			[ProfileDescription] = @ProfileDescription
	WHERE	[AnimalID] = @AnimalID
	RETURN @@ROWCOUNT
END
GO

/*
Created By: Michael Thompson
Date 2/20/2020
Comment: Stored Procedure to get the animal, profile photo path and description
*/
DROP PROCEDURE IF EXISTS [sp_select_all_animal_profiles]
GO
PRINT '' PRINT '*** Creating sp_select_all_animal_profiles'
GO
CREATE PROCEDURE [sp_select_all_animal_profiles]
AS
BEGIN
	SELECT [AnimalID],[AnimalName],[ProfilePhoto],[ProfileDescription]
	FROM [dbo].[Animal]
	ORDER BY [AnimalID]
END
GO

/*
Created by: Jaeho Kim
Date: 03/05/2020
Comment: Selects a single transaction with an TransactionID and displays all
of the product details.
*/
DROP PROCEDURE IF EXISTS [sp_select_all_products_by_transaction_id]
GO
PRINT '' PRINT '*** Creating sp_select_all_products_by_transaction_id'
GO
CREATE PROCEDURE [sp_select_all_products_by_transaction_id]
(
	@TransactionID		[int]
)
AS
BEGIN
    SELECT
        TLP.[Quantity]
        , P.[ProductID]
        , I.[ItemName]
        , I.[ItemCategoryID]
        , P.[ProductTypeID]
        , P.[Price]

    FROM 	[TransactionLineProducts] TLP
    INNER JOIN [Product] P
        ON TLP.[ProductID] = P.[ProductID]
	INNER JOIN [Item] I
        ON P.[ItemID] = I.[ItemID]
    INNER JOIN [Transaction] T
        ON TLP.[TransactionID] = T.[TransactionID]
    INNER JOIN [User] U
        ON T.[EmployeeID] = U.[UserID]
    INNER JOIN [TransactionType] TT
        ON TT.[TransactionTypeID] = T.[TransactionTypeID]
    WHERE @TransactionID = TLP.[TransactionID]
END
GO

/*
Created by: Jaeho Kim
Date: 03/05/2020
Comment: Selects a list of all transactions with a specific datetime.
*/
DROP PROCEDURE IF EXISTS [sp_select_transactions_by_datetime]
GO
PRINT '' PRINT '*** Creating sp_select_transactions_by_datetime'
GO
CREATE PROCEDURE sp_select_transactions_by_datetime
(
	@TransactionDateTime		[datetime],
	@SecondTransactionDateTime	[datetime]
)
AS
BEGIN
	
    SELECT
        T.[TransactionID],
        T.[TransactionDateTime],
        T.[EmployeeID],
        U.[FirstName],
        U.[LastName],
        T.[TransactionTypeID],
        T.[TransactionStatusID],
		T.[TaxRate],
		T.[SubTotalTaxable],
		T.[SubTotal],
		T.[Total],
		T.[CustomerEmail],
		T.[StripeChargeID]
    FROM 	[Transaction] T
    INNER JOIN [User] U
        ON T.[EmployeeID] = U.[UserID]
		
    --WHERE T.[TransactionDateTime] = @TransactionDateTime
	
	WHERE T.[TransactionDateTime] 
		BETWEEN @TransactionDateTime AND @SecondTransactionDateTime
END
GO

/*
Created by: Brandyn T. Coverdill
Date: 3/4/2020
Comment: Stored Procedure that updates the item name, item count, and item description.
*/
DROP PROCEDURE IF EXISTS [sp_update_specific_item]
GO
PRINT '' PRINT '*** Creating procedure sp_update_specific_item'
GO
CREATE PROCEDURE [sp_update_specific_item](
	@OldItemName nvarchar(50),
	@OldItemDescription nvarchar(250),
	@OldItemQuantity int,
	@NewItemName nvarchar(50),
	@NewItemDescription nvarchar(250),
	@NewItemQuantity int
)
AS
BEGIN
	UPDATE dbo.Item
	SET ItemName = @NewItemName,
		ItemDescription = @NewItemDescription,
		ItemQuantity = @NewItemQuantity
	WHERE ItemName = @OldItemName
	AND	  ItemDescription = @OldItemDescription
	AND	  ItemQuantity = @OldItemQuantity
	SELECT @@ROWCOUNT
END
GO

/*
Created by: Rasha Mohammed
Date: 2/10/2020
Comment: Sproc to delete item from transactionLine
*/
DROP PROCEDURE IF EXISTS [sp_delete_Item_from_Transaction]
GO
PRINT '' PRINT '*** creating sp_delete_item_from_transaction'
GO
CREATE PROCEDURE [sp_delete_Item_from_Transaction]
(
	@ProductID	[nvarchar](13)
)
AS
BEGIN
	DELETE FROM [dbo].[TransactionLineProducts]
	WHERE	[ProductID] = @ProductID
	select @@rowcount
END
GO

/*
Created by: Austin Gee
Date: 3/5/2020
Comment: Stored Procedure that selects all AnimalVMs by active
*/
DROP PROCEDURE IF EXISTS [sp_select_adoption_animals_by_active]
GO
PRINT '' PRINT '*** Creating sp_select_adoption_animals_by_active'
GO
CREATE PROCEDURE [sp_select_adoption_animals_by_active]
(
	@Active [bit]
)
AS
BEGIN
	SELECT
		[Animal].[AnimalID]
		,[AnimalName]
		,[Dob]
		,[AnimalBreed]
		,[ArrivalDate]
		,[CurrentlyHoused]
		,[Adoptable]
		,[Animal].[Active]
		,[AnimalSpeciesID]
		,[AnimalKennelID]
		,[AnimalKennelInfo]
		,[AnimalMedicalInfoID]
		,[SpayedNeutered]
		,[AdoptionApplicationID]
		,[Customer].[Email]
		,[Customer].[FirstName]
		,[Customer].[LastName]
		,[AnimalHandlingNotesID]
		,[AnimalHandlingNotes]
		,[TemperamentWarning]
	FROM [Animal]
	LEFT JOIN [AnimalKennel] ON [Animal].[AnimalID] = [AnimalKennel].[AnimalID]
	LEFT JOIN [AnimalHandlingNotes] ON [Animal].[AnimalID] = [AnimalHandlingNotes].[AnimalID]
	LEFT JOIN [AnimalMedicalInfo] ON [Animal].[AnimalID] = [AnimalMedicalInfo].[AnimalID]
	LEFT JOIN [AdoptionApplication] ON [Animal].[AnimalID] = [AdoptionApplication].[AnimalID]
	LEFT JOIN [Customer] ON [AdoptionApplication].[CustomerEmail] = [Customer].[Email]
	WHERE [Animal].[Active] = @Active
END
GO

/*
Created by: Jordan Lindo
Date: 2/29/2020
Comment: set the active field
*/
DROP PROCEDURE IF EXISTS [sp_deactivate_department_by_id]
GO
PRINT '' PRINT '*** Creating sp_set_department_active_by_id'
GO
CREATE PROCEDURE [sp_deactivate_department_by_id]
(
	 @DepartmentID		[nvarchar](50)
	,@Active			[bit]
)
AS
BEGIN
	UPDATE [dbo].[Department]
	SET [Active] = @Active
	WHERE [DepartmentID] = @DepartmentID
END
GO

/*
Created by: Jordan Lindo
Date: 2/29/2020
Comment: selects departments that are deactivated
*/
DROP PROCEDURE IF EXISTS [sp_select_deactivated_departments]
GO
PRINT '' PRINT '*** Creating sp_select_deactivated_departments'
GO
CREATE PROCEDURE [sp_select_deactivated_departments]
AS
BEGIN
	SELECT [DepartmentID]
	FROM [dbo].[Department]
	WHERE [Active] = 0
END
GO

/*
Created by: Chuck Baxter
Date: 3/12/2020
Comment: Stored Procedure that updates an animal
*/
DROP PROCEDURE IF EXISTS [sp_update_animal]
GO
PRINT '' PRINT '*** Creating sp_update_animal'
Go
CREATE PROCEDURE [sp_update_animal]
(
	@AnimalID				[int],
	@OldAnimalName			[nvarchar](100),
	@OldDob					[DateTime],
	@OldAnimalBreed			[nvarchar](100),
	@OldArrivalDate			[DateTime],
	@OldAnimalSpeciesID		[nvarchar](100),
	@NewAnimalName			[nvarchar](100),
	@NewDob					[DateTime],
	@NewAnimalBreed			[nvarchar](100),
	@NewArrivalDate			[DateTime],
	@NewAnimalSpeciesID		[nvarchar](100)
)
AS
BEGIN
	UPDATE	[dbo].[Animal]
	SET 	[AnimalName] 		= 	@NewAnimalName,
			[Dob]				=	@NewDob,
			[AnimalBreed]		=	@NewAnimalBreed,
			[ArrivalDate]		=	@NewArrivalDate,
			[AnimalSpeciesID]	=	@NewAnimalSpeciesID
	WHERE	[AnimalID]			=	@AnimalID
	  AND	[AnimalName]		=	@OldAnimalName
	  AND	[Dob]				=	@OldDob
	  AND	[AnimalBreed]		=	@OldAnimalBreed
 	  AND	[ArrivalDate]		=	@OldArrivalDate
	  AND	[AnimalSpeciesID]	=	@OldAnimalSpeciesID
	  RETURN @@ROWCOUNT
END
GO

/*
Created by: Dalton Reierson
Date: 03/09/2020
Comment: Select all item in inventory by active field
*/
DROP PROCEDURE IF EXISTS [sp_select_items_by_active]
GO
PRINT '' PRINT '*** Creating sp_select_items_by_active ***'
GO
CREATE PROCEDURE [sp_select_items_by_active]
(
		@Active [bit]
)
AS
BEGIN
	SELECT [ItemID],
		   [ItemName],
		   [ItemQuantity],
		   [ItemCategoryID],
		   [ItemDescription]
	FROM [dbo].[Item]
	WHERE [Active] = @Active
END
GO

/*
Created by: Dalton Reierson
Date: 03/10/2020
Comment: Select all items in inventory by active field
*/
DROP PROCEDURE IF EXISTS [sp_deactivate_item]
GO
PRINT '' PRINT '*** Creating sp_deactivate_item ***'
GO
CREATE PROCEDURE [sp_deactivate_item]
(
		@ItemID          [int],
		@ItemName        [nvarchar] (50),
		@ItemCategoryID  [nvarchar] (50),
		@ItemDescription [nvarchar] (50),
		@ItemQuantity    [int]
)
AS
BEGIN
	UPDATE [Item]
	SET    [Active] = 0
	WHERE  [ItemID] = @ItemID
	AND    [ItemName] = @ItemName
	AND	   [ItemCategoryID] = @ItemCategoryID
	AND    [ItemDescription] = @ItemDescription
	AND    [ItemQuantity] = @ItemQuantity
	SELECT @@ROWCOUNT
END
GO

/*
Created by: Robert Holmes
Date: 2020/03/10
Comment: Stored procedure to INSERT a new promotion
*/
DROP PROCEDURE IF EXISTS [sp_insert_promotion]
GO
PRINT '' PRINT '*** Creating stored procedure sp_insert_promotion'
GO
CREATE PROCEDURE [sp_insert_promotion]
(
	@PromotionID		[nvarchar](20),
	@PromotionTypeID	[nvarchar](20),
	@StartDate			[datetime],
	@EndDate			[datetime],
	@Discount			[decimal](10, 2),
	@Description		[nvarchar](500)
)
AS
BEGIN
    INSERT INTO [dbo].[Promotion]
    ([PromotionID], [PromotionTypeID], [StartDate], [EndDate], [Discount], [Description])
    VALUES
    (@PromotionID, @PromotionTypeID, @StartDate, @EndDate, @Discount, @Description)
END
GO

/*
Created by: Robert Holmes
Date: 2020/03/10
Comment: Stored procedure to return all PromotionTypes
*/
DROP PROCEDURE IF EXISTS [sp_retrieve_promotiontypes]
GO
PRINT '' PRINT '*** Creating stored procedure sp_retrieve_promotiontypes'
GO
CREATE PROCEDURE [sp_retrieve_promotiontypes]
AS
BEGIN
    SELECT 	[PromotionTypeID]
    FROM 	[dbo].[PromotionType]
END
GO

/*
Created by: Robert Holmes
Date: 2020/03/12
Comment: Relates products to a promotion.
*/
DROP PROCEDURE IF EXISTS [sp_insert_promo_product]
GO
PRINT '' PRINT '*** Creating stored procedure sp_insert_promo_product'
GO
CREATE PROCEDURE [sp_insert_promo_product]
(
		@PromotionID	NVARCHAR(20)
	,	@ProductID		NVARCHAR(13)
)
AS
BEGIN
    INSERT INTO [dbo].[PromoProductLine]
    ([PromotionID], [ProductID])
    VALUES
    (@PromotionID, @ProductID)
END
GO

/*
Created by: Austin Gee
Date: 3/4/2020
Comment: Stored Procedure that selects adoption appointment by appointment id.
*/
DROP PROCEDURE IF EXISTS [sp_select_adoption_appointment_by_appointment_id]
GO
PRINT '' PRINT '*** Creating sp_select_adoption_appointment_by_appointment_id'
GO
CREATE PROCEDURE [sp_select_adoption_appointment_by_appointment_id]
(
	@AppointmentID [int]
)
AS
BEGIN
	SELECT 
	[AppointmentID]
	,[AdoptionApplication].[AdoptionApplicationID]
	,[Appointment].[AppointmentTypeID]
	,[Appointment].[DateTime]
	,[Appointment].[Notes]
	,[Appointment].[Decision]
	,[Location].[LocationID]
	,[Appointment].[Active]
	,[Customer].[Email]
	,[Animal].[AnimalID]
	,[AdoptionApplication].[Status]
	,[AdoptionApplication].[RecievedDate]
	,[Location].[Name]
	,[Location].[Address1]
	,[Location].[Address2]
	,[Location].[City]
	,[Location].[State]
	,[Location].[Zip]
	,[Customer].[FirstName]
	,[Customer].[LastName]
	,[Customer].[PhoneNumber]
	,[Customer].[Active]
	,[Customer].[City]
	,[Customer].[State]
	,[Customer].[Zipcode]
	,[Animal].[AnimalName]
	,[Animal].[Dob]
	,[Animal].[AnimalSpeciesID]
	,[Animal].[AnimalBreed]
	,[Animal].[ArrivalDate]
	,[Animal].[CurrentlyHoused]
	,[Animal].[Adoptable]
	,[Animal].[Active]
	FROM [Appointment] JOIN [AdoptionApplication] ON [AdoptionApplication].[AdoptionApplicationID] = [Appointment].[AdoptionApplicationID]
	JOIN [Location] ON [Appointment].[LocationID] = [Location].[LocationID]
	JOIN [Customer] ON [AdoptionApplication].[CustomerEmail] = [Customer].[Email]
	JOIN [Animal] ON [AdoptionApplication].[AnimalID] = [Animal].[AnimalID]
	WHERE [Appointment].[AppointmentID] = @AppointmentID
	ORDER BY [Appointment].[DateTime] DESC
END
GO

/*
Created by: Austin Gee
Date: 3/11/2020
Comment: Sproc to create a status
*/
DROP PROCEDURE IF EXISTS [sp_insert_status]
GO
PRINT '' PRINT '*** creating sp_insert_status'
GO
CREATE PROCEDURE [sp_insert_status]
(
	@StatusID	[nvarchar](100)
)
AS
BEGIN
	INSERT INTO [dbo].[Status]
		([StatusID])
	VALUES
		(@StatusID)
	RETURN @@ROWCOUNT
END
GO	

/*
Created by: Austin Gee
Date: 3/11/2020
Comment: Sproc to select all statuses
*/
DROP PROCEDURE IF EXISTS [sp_select_all_statuses]
GO
PRINT '' PRINT '*** creating sp_select_all_statuses'
GO
CREATE PROCEDURE [sp_select_all_statuses]
AS
BEGIN
	SELECT
		[StatusID]
	FROM
		[dbo].[Status]
	ORDER BY [StatusID] ASC
END
GO	

/*
Created by: Austin Gee
Date: 3/11/2020
Comment: Sproc to INSERT an Animal status
*/
DROP PROCEDURE IF EXISTS [sp_insert_animal_status]
GO
PRINT '' PRINT '*** creating sp_insert_animal_status'
GO
CREATE PROCEDURE [sp_insert_animal_status]
(
	@StatusID	[nvarchar](100),
	@AnimalID	[int]
)
AS
BEGIN
	INSERT INTO [dbo].[AnimalStatus]
		([AnimalID], [StatusID])
	VALUES
		(@AnimalID, @StatusID)
	RETURN @@ROWCOUNT
END
GO	

/*
Created by: Austin Gee
Date: 3/11/2020
Comment: Sproc to select an animal status by animal ID
*/
DROP PROCEDURE IF EXISTS [sp_select_animal_status_ids_by_animal_id]
GO
PRINT '' PRINT '*** creating sp_select_animal_status_by_animal_id'
GO
CREATE PROCEDURE [sp_select_animal_status_ids_by_animal_id]
(
	@AnimalID	[int]
)
AS
BEGIN
	SELECT [StatusID]
	FROM [dbo].[AnimalStatus]
	WHERE [AnimalID] = @AnimalID
	ORDER BY [StatusID] ASC
END
GO	

/*
Created by: Austin Gee
Date: 3/11/2020
Comment: Sproc to delete an Animal status
*/
DROP PROCEDURE IF EXISTS [sp_delete_animal_status]
GO
PRINT '' PRINT '*** creating sp_delete_animal_status'
GO
CREATE PROCEDURE [sp_delete_animal_status]
(
	@StatusID	[nvarchar](100),
	@AnimalID	[int]
)
AS
BEGIN
	DELETE FROM [dbo].[AnimalStatus]
	WHERE [AnimalID] = @AnimalID
	AND [StatusID] = @StatusID
	RETURN @@ROWCOUNT
END
GO	

/*
Created by: Austin Gee
Date: 3/11/2020
Comment: Sproc to INSERT an appointment
*/
DROP PROCEDURE IF EXISTS [sp_insert_appointment]
GO
PRINT '' PRINT '*** creating sp_insert_appointment'
GO
CREATE PROCEDURE [sp_insert_appointment]
(
	@AdoptionApplicationID	[int],
	@AppointmentTypeID		[nvarchar](100),
	@DateTime				[datetime],
	@LocationID				[int]
)
AS
BEGIN
	INSERT INTO [dbo].[Appointment]
		([AdoptionApplicationID], [AppointmentTypeID], [DateTime], [LocationID])
	VALUES
		(@AdoptionApplicationID, @AppointmentTypeID, @DateTime, @LocationID)
	RETURN @@ROWCOUNT
END
GO	

/*
Created by: Austin Gee
Date: 3/12/2020
Comment: Sproc to INSERT a location
*/
DROP PROCEDURE IF EXISTS [sp_insert_location]
GO
PRINT '' PRINT '*** creating sp_insert_location'
GO
CREATE PROCEDURE [sp_insert_location]
(
	@Name			[nvarchar](100),
	@Address1		[nvarchar](100),
	@Address2		[nvarchar](100),
	@City			[nvarchar](100),
	@State			[nvarchar](2),
	@Zip			[nvarchar](20)
)
AS
BEGIN
	INSERT INTO [dbo].[Location]
		([Name], [Address1], [Address2], [City], [State], [Zip])
	VALUES
		(@Name, @Address1, @Address2, @City, @State, @Zip)
	RETURN @@ROWCOUNT
END
GO	

/*
Created by: Austin Gee
Date: 3/12/2020
Comment: Sproc to select all location
*/
DROP PROCEDURE IF EXISTS [sp_select_all_locations]
GO
PRINT '' PRINT '*** creating sp_select_all_locations'
GO
CREATE PROCEDURE [sp_select_all_locations]
AS
BEGIN
	SELECT
		[LocationID]
		,[Name]
		,[Address1]
		,[Address2]
		,[City]
		,[State]
		,[Zip]
	FROM [dbo].[Location]
	ORDER BY [Name] ASC
END
GO	

/*
Created by: Austin Gee
Date: 3/12/2020
Comment: Sproc to select location by location ID
*/
DROP PROCEDURE IF EXISTS [sp_select_location_by_location_id]
GO
PRINT '' PRINT '*** creating sp_select_location_by_location_id'
GO
CREATE PROCEDURE [sp_select_location_by_location_id]
(
	@LocationID [int]
)
AS
BEGIN
	SELECT
		[LocationID]
		,[Name]
		,[Address1]
		,[Address2]
		,[City]
		,[State]
		,[Zip]
	FROM [dbo].[Location]
	WHERE [LocationID] = @LocationID
END
GO	

/*
Created by: Austin Gee
Date: 3/12/2020
Comment: Sproc to update location
*/
DROP PROCEDURE IF EXISTS [sp_update_location]
GO
PRINT '' PRINT '*** creating sp_update_location'
GO
CREATE PROCEDURE [sp_update_location]
(
	@LocationID			[int],
	
	@OldName			[nvarchar](100),
	@OldAddress1		[nvarchar](100),
	@OldAddress2		[nvarchar](100),
	@OldCity			[nvarchar](100),
	@OldState			[nvarchar](2),
	@OldZip				[nvarchar](20),
	
	@NewName			[nvarchar](100),
	@NewAddress1		[nvarchar](100),
	@NewAddress2		[nvarchar](100),
	@NewCity			[nvarchar](100),
	@NewState			[nvarchar](2),
	@NewZip				[nvarchar](20)
)
AS
BEGIN
	UPDATE [dbo].[Location]
	SET 	[Name]		 = @NewName,
			[Address1]	 = @NewAddress1,
			[Address2]	 = @NewAddress2,
			[City]		 = @NewCity,
			[State]		 = @NewState,
			[Zip]		 = @NewZip
			
	WHERE	[LocationID] = @LocationID	
	AND 	[Name]		 = @OldName
	AND		[Address1]	 = @OldAddress1
	AND		[Address2]	 = @OldAddress2
	AND		[City]		 = @OldCity
	AND		[State]		 = @OldState
	AND		[Zip]		 = @OldZip
	RETURN @@ROWCOUNT
END
GO	

/*
Created by: Austin Gee
Date: 3/12/2020
Comment: Sproc to delete location
*/
DROP PROCEDURE IF EXISTS [sp_delete_location]
GO
PRINT '' PRINT '*** creating sp_delete_location'
GO
CREATE PROCEDURE [sp_delete_location]
(
	@LocationID			[int],
	
	@Name			[nvarchar](100),
	@Address1		[nvarchar](100),
	@Address2		[nvarchar](100),
	@City			[nvarchar](100),
	@State			[nvarchar](2),
	@Zip			[nvarchar](20)
)
AS
BEGIN
	DELETE FROM [dbo].[Location]
	WHERE	[LocationID] = @LocationID
	AND 	[Name]		 = @Name
	AND		[Address1]	 = @Address1
	AND		[Address2]	 = @Address2
	AND		[City]		 = @City
	AND		[State]		 = @State
	AND		[Zip]		 = @Zip
	RETURN @@ROWCOUNT
END
GO

DROP PROCEDURE IF EXISTS [sp_Select_NewAnimalCheckList_By_AnimalID]
GO
PRINT '' PRINT '*** creating sp_Select_NewAnimalCheckList_By_AnimalID'
GO
CREATE PROCEDURE [sp_Select_NewAnimalCheckList_By_AnimalID]
(
  @AnimalID [int]
)
AS
BEGIN
    SELECT 
        Animal.AnimalID,
        Animal.AnimalName,  	
        Animal.Dob,				
        Animal.AnimalSpeciesID,		
        Animal.AnimalBreed,			
        Animal.ArrivalDate,			
        Animal.CurrentlyHoused,		
        Animal.Adoptable,
        AnimalHandlingNotes.AnimalHandlingNotes,	
        AnimalHandlingNotes.TemperamentWarning,
        AnimalMedicalInfo.SpayedNeutered,				
        AnimalMedicalInfo.Vaccinations,				
        AnimalMedicalInfo.MostRecentVaccinationDate,	
        AnimalMedicalInfo.AdditionalNotes	
    FROM [dbo].[Animal] 
    INNER JOIN [dbo].[AnimalHandlingNotes]
    ON AnimalHandlingNotes.AnimalID = Animal.AnimalID
    INNER JOIN 
    AnimalMedicalInfo
    ON
    AnimalMedicalInfo.AnimalID = Animal.AnimalID

    WHERE Animal.AnimalID = @AnimalID
    AND AnimalHandlingNotes.AnimalID = @AnimalID
    AND AnimalMedicalInfo.AnimalID = @AnimalID
END
GO

DROP PROCEDURE IF EXISTS [SP_Select_Medication_By_Low_Qauntity]
GO
PRINT '' PRINT '*** creating SP_Select_Medication_By_Low_Qauntity'
GO
CREATE PROCEDURE [SP_Select_Medication_By_Low_Qauntity]
AS
BEGIN
    SELECT 
        [ItemID],
        [ItemQuantity],				
        [ItemName]			
			
    FROM [dbo].[Item] 
    WHERE[ItemCategoryID] = 'Medication'
    AND [ItemQuantity] < 5
END
GO

DROP PROCEDURE IF EXISTS [SP_Select_Medication_By_Empty_Qauntity]
GO
PRINT '' PRINT '*** creating SP_Select_Medication_By_Empty_Qauntity'
GO
CREATE PROCEDURE [SP_Select_Medication_By_Empty_Qauntity]
AS
BEGIN
    SELECT 
        [ItemID],
        [ItemQuantity],				
        [ItemName]			                
    FROM [dbo].[Item] 
    WHERE [ItemCategoryID] = 'Medication'
    AND [ItemQuantity] = 0
END
GO

DROP PROCEDURE IF EXISTS [sp_Select_Animal_Feeding_Records]
GO
PRINT '' PRINT '*** sp_Select_Animal_Feeding_Records'
GO
CREATE PROCEDURE [sp_Select_Animal_Feeding_Records]
AS
BEGIN
    SELECT 
        [AnimalActivityID],
        [AnimalID],
        [UserID],
        [AnimalActivityTypeID],
        [ActivityDateTime]
    FROM [dbo].[AnimalActivity]
END
GO

/*
Created by: Ethan Murphy
Date: 3/31/2020
Comment: Selects animal activity records by
		activity type
*/
DROP PROCEDURE IF EXISTS [sp_select_animal_activites_by_activity_type]
GO
print '' print '*** creating sp_select_animal_activites_by_activity_type'
GO
CREATE PROCEDURE [sp_select_animal_activites_by_activity_type]
(
	@ActivityTypeID		[nvarchar](100)
)
AS
BEGIN
	SELECT [AnimalActivityID], [Animal].[AnimalID], [UserID], [AnimalName],
			[AnimalActivityTypeID], [ActivityDateTime], [Description]
	FROM [dbo].[AnimalActivity]
	INNER JOIN [dbo].[Animal]
	ON [AnimalActivity].[AnimalID] = [Animal].[AnimalID]
	WHERE [AnimalActivityTypeID] = @ActivityTypeID
END
GO

/*
Created by: Ethan Murphy
Date: 4/2/2020
Comment: Inserts an animal activity record
*/
DROP PROCEDURE IF EXISTS [sp_insert_animal_activity]
GO
print '' print '*** creating sp_insert_animal_activity'
GO
CREATE PROCEDURE [sp_insert_animal_activity]
(
	@AnimalID				[int],
	@UserID					[int],
	@AnimalActivityTypeID	[nvarchar](100),
	@ActivityDateTime		[datetime],
	@Description			[nvarchar](400)
)
AS
BEGIN
	INSERT INTO [dbo].[AnimalActivity]
	([AnimalID], [UserID], [AnimalActivityTypeID],
	[ActivityDateTime], [Description])
	VALUES
	(@AnimalID, @UserID, @AnimalActivityTypeID,
	@ActivityDateTime, @Description)
	RETURN @@ROWCOUNT
END
GO

/*
Created by: Ethan Murphy
Date: 3/31/2020
Comment: Select all animal activity types
*/
DROP PROCEDURE IF EXISTS [sp_select_all_animal_activity_types]
GO
print '' print '*** creating sp_select_all_animal_activity_types'
GO
CREATE PROCEDURE [sp_select_all_animal_activity_types]
AS
BEGIN
	SELECT [AnimalActivityTypeID], [ActivityNotes]
	FROM [AnimalActivityType]
END
GO


DROP PROCEDURE IF EXISTS [sp_Select_Animal_By_AnimalID]
GO
PRINT '' PRINT '*** sp_Select_Animal_By_AnimalID'
GO
CREATE PROCEDURE [sp_Select_Animal_By_AnimalID]
(
  @AnimalID [int]
)
AS
BEGIN
    SELECT 
        [AnimalID],
        [AnimalName],  	
        [Dob],				
        [AnimalSpeciesID],		
        [AnimalBreed],			
        [ArrivalDate],			
		[CurrentlyHoused],		
        [Adoptable],
		[Active]

    FROM [Animal] 
    WHERE[AnimalID] = @AnimalID
END
GO

DROP PROCEDURE IF EXISTS [SP_Select_Items_By_ItemCategoryID]
GO
PRINT '' PRINT '*** SP_Select_Items_By_ItemCategoryID'
GO
CREATE PROCEDURE [SP_Select_Items_By_ItemCategoryID]
AS
BEGIN
    SELECT 
        [ItemID],
        [ItemQuantity],				
        [ItemName]						
    FROM [dbo].[Item] 
    WHERE[ItemCategoryID] = 'Medication'
END
GO

/*
Created by: Zach Behrensmeyer
Date: 03/02/2020
Comment: This is used to check that the email exists
*/
DROP PROCEDURE IF EXISTS [sp_check_email_exists]
GO
print '' print '*** Creating sp_check_email_exists ***'
GO
CREATE PROCEDURE [sp_check_email_exists]
(
@Email [NVARCHAR](250)
)  
AS     
BEGIN     
SELECT COUNT(*) 
FROM [dbo].[User] 
WHERE Email = @Email
END    
GO

/*
Created by: Zach Behrensmeyer
Date: 03/02/2020
Comment: This is used to check that the email exists
*/
DROP PROCEDURE IF EXISTS [sp_get_unlock_date]
GO
print '' print '*** Creating sp_get_unlock_date ***'
GO
CREATE PROCEDURE [sp_get_unlock_date]
(
@Email [NVARCHAR](250)
)  
AS     
BEGIN     
SELECT UnlockDate
FROM [dbo].[User] 
WHERE Email = @Email
END    
GO

/*
Created by: Zach Behrensmeyer
Date: 03/02/2020
Comment: This is used to check that the user is locked
*/
DROP PROCEDURE IF EXISTS [sp_check_user_is_locked]
GO
print '' print '*** Creating sp_check_user_is_locked ***'
GO
CREATE PROCEDURE [sp_check_user_is_locked]
(
@Email [NVARCHAR](250)
)  
AS     
BEGIN     
SELECT COUNT(*) 
FROM [dbo].[User] 
WHERE Email = @Email
AND Locked = 1
END    
GO

/*
Created by: Zach Behrensmeyer
Date: 03/02/2020
Comment: This is used to unlock a user if the date and time they were locked out at is ahead of that time
*/
DROP PROCEDURE IF EXISTS [sp_unlock_user_by_date]
GO
print '' print '*** Creating sp_unlock_user_by_date ***'
GO
CREATE PROCEDURE [sp_unlock_user_by_date]
(
@Email [NVARCHAR](250)
)  
AS     
BEGIN     
UPDATE [dbo].[User]
SET Locked = 0, UnlockDate = null
WHERE Email = @Email 
AND UnlockDate < GETDATE()
RETURN @@ROWCOUNT
END    
GO

/*
Created by: Zach Behrensmeyer
Date: 03/02/2020
Comment: This is used to check that the email exists
*/
DROP PROCEDURE IF EXISTS [sp_lockout_user]
GO
print '' print '*** Creating sp_lockout_user ***'
GO
Create Procedure [sp_lockout_user]
(
@Email [NVARCHAR](250),
@UnlockDate [DateTime],
@LockDate [DateTime]
)  
AS     
BEGIN     
UPDATE [dbo].[User]
	SET Locked = 1, UnlockDate = @UnlockDate, LockDate = @LockDate
	WHERE Email = @Email
	RETURN @@ROWCOUNT
END    
GO

/*
Author: Timothy Lickteig
Date: 2020/03/01
Comment: Stored Procedure for selecting all signed up shifts for a volunteer
*/
DROP PROCEDURE IF EXISTS [sp_select_shifts_for_a_volunteer]
GO
print '' print '*** Creating stored procedure sp_select_shifts_for_a_volunteer'
GO
CREATE PROCEDURE [sp_select_shifts_for_a_volunteer](
	@VolunteerID [int]
)
AS
BEGIN
	SELECT [VolunteerShift].[VolunteerShiftID], [ShiftDescription], 
		[ShiftTitle], [ShiftDate], [ShiftStartTime],
		[ShiftEndTime], [Recurrance], [IsSpecialEvent],
		[ShiftNotes], [ScheduleID]
	FROM [ShiftRecord] 
	JOIN [VolunteerShift] ON 
		([VolunteerShift].[VolunteerShiftID] = [ShiftRecord].[VolunteerShiftID])
	WHERE [ShiftRecord].[VolunteerID] = @VolunteerID
END
GO

/*
Author: Timothy Lickteig
Date: 2020/03/09
Comment: Creating procedure for checking Medicine in
*/
print '' print '*** Creating sp_select_all_medicine'
GO
CREATE PROCEDURE [sp_select_all_medicine]
AS
BEGIN
	select
		[MedicineID], [MedicineName], 
		[MedicineDosage], [MedicineDescription]
	from [dbo].[Medicine]
END
GO

/*
Author: Timothy Lickteig
Date: 2020/03/09
Comment: Creating procedure for checking Medicine in
*/
print '' print '*** Creating sp_insert_medicine'
GO
CREATE PROCEDURE [sp_insert_medicine] (

	@MedicineName [nvarchar](300),
	@MedicineDosage [nvarchar](300),
	@MedicineDescription [nvarchar](500)
)
AS
BEGIN

	insert into [dbo].[Medicine]
	([MedicineName], [MedicineDosage], [MedicineDescription])
	values
	(@MedicineName, @MedicineDosage, @MedicineDescription)
END
GO

/*
Author: Timothy Lickteig
Date: 2020/03/09
Comment: Creating procedure for checking Medicine out
*/
print '' print '*** Creating sp_delete_medicine'
GO
CREATE PROCEDURE [sp_delete_medicine] (

	@MedicineID [int]
)
AS
BEGIN

	delete from [dbo].[Medicine]
	where [MedicineID] = @MedicineID
	return @@ROWCOUNT
END
GO

/*
Created by: Chuck Baxter
Date: 3/13/2020
Comment: Sproc to insert Animal species
*/
print '' print'*** Creating sp_insert_animal_species'
GO

DROP PROCEDURE IF EXISTS [sp_insert_animal_species]
GO

CREATE PROCEDURE [sp_insert_animal_species]
(
	@AnimalSpeciesID	[nvarchar](100),
	@Description		[nvarchar](1000)
)
AS
BEGIN
	INSERT INTO [dbo].[AnimalSpecies]
		([AnimalSpeciesID],[Description])
	VALUES
		(@AnimalSpeciesID, @Description)
	RETURN SCOPE_IDENTITY()
END
GO

/*
Created by: Chuck Baxter
Date: 3/18/2020
Comment: Sproc to delete animal species
*/
DROP PROCEDURE IF EXISTS [sp_delete_animal_species]
GO
PRINT '' PRINT '*** creating sp_delete_animal_species'
GO
CREATE PROCEDURE [sp_delete_animal_species](
		@AnimalSpeciesID [nvarchar](100)
)
AS
BEGIN
	DELETE FROM [dbo].[AnimalSpecies]
	WHERE [AnimalSpeciesID] = @AnimalSpeciesID
	RETURN @@ROWCOUNT
END
GO

/*
Created by: Chuck Baxter
Date: 3/18/2020
Comment: Sproc to update animal species
*/
print '' print'*** Creating sp_update_animal_species'
GO

DROP PROCEDURE IF EXISTS [sp_update_animal_species]
GO

CREATE PROCEDURE [sp_update_animal_species]
(
	@OldAnimalSpeciesID	[nvarchar](100),
	@NewAnimalSpeciesID	[nvarchar](100),
	@NewDescription		[nvarchar](1000)
)
AS
BEGIN
	UPDATE	[dbo].[AnimalSpecies]
	SET 	[AnimalSpeciesID]	= 	@NewAnimalSpeciesID,
			[Description]		=	@NewDescription
	WHERE	[AnimalSpeciesID]	=	@OldAnimalSpeciesID
	RETURN  @@ROWCOUNT
END
GO
/*
Created by: Awaab Elamin
Date: 3/18/2020
Comment: Create SP sp_add_new_adoptionApplication
Updated By: Awaab Elamin
*/
GO
DROP PROCEDURE IF EXISTS [sp_add_new_adoptionApplication]
GO
CREATE PROCEDURE [dbo].[sp_add_new_adoptionApplication]
(
	@CustomerEmail	[nvarchar](250),
	@RecievedDate	[datetime],
	@Status		[nvarchar]	(1000),
	@AnimalID	[int]
)
AS
BEGIN
	INSERT INTO [dbo].[AdoptionApplication]
([CustomerEmail],[RecievedDate],[Status],[AnimalID])
VALUES
(@CustomerEmail,@RecievedDate,@Status,@AnimalID)
END
GO
/*
Created by: Awaab Elamin
Date: 3/18/2020
Comment: Create SP sp_get_all_General_Questions
*/
GO
print '' print '*** Creating sp_get_all_General_Questions'
GO
DROP PROCEDURE IF EXISTS [sp_get_all_General_Questions]
GO
CREATE PROCEDURE [dbo].[sp_get_all_General_Questions]
AS
BEGIN
	SELECT 	[Description]
	From 	[dbo].[GeneralQusetions]
END
GO
/*
Created by: Awaab Elamin
Date: 10/03/2020
Comment: Create SP sp_add_customer_questionnair
*/
GO
print '' print '*** Creating sp_add_customer_questionnair'
GO
DROP PROCEDURE IF EXISTS sp_add_customer_questionnair
GO
CREATE PROCEDURE [dbo].[sp_add_customer_questionnair]
(
	@AdoptionApplicationID [int], 	@CustomerEmail	[nvarchar](250),

	@Question1	[nvarchar](100),	@Question2	[nvarchar](100),
	@Question3	[nvarchar](100),	@Question4	[nvarchar](100),
	@Question5	[nvarchar](100),	@Question6	[nvarchar](100),
	@Question7	[nvarchar](100),	@Question8	[nvarchar](100),
	@Question9	[nvarchar](100),	@Question10	[nvarchar](100),

	@Answer1 [nvarchar](500),	@Answer2 [nvarchar](500),
	@Answer3 [nvarchar](500),	@Answer4 [nvarchar](500),
	@Answer5 [nvarchar](500),	@Answer6 [nvarchar](500),
	@Answer7 [nvarchar](500),	@Answer8 [nvarchar](500),
	@Answer9 [nvarchar](500),	@Answer10 [nvarchar](500)

)
AS
BEGIN
	INSERT INTO [dbo].[CustomerAnswers]
	(
		 [AdoptionApplicationID],[CustomerEmail], [QuestionDescription],[Answer]
	)
	VALUES
		(@AdoptionApplicationID,@CustomerEmail,@Question1,@Answer1),
		(@AdoptionApplicationID,@CustomerEmail,@Question2,@Answer2),
		(@AdoptionApplicationID,@CustomerEmail,@Question3,@Answer3),
		(@AdoptionApplicationID,@CustomerEmail,@Question4,@Answer4),
		(@AdoptionApplicationID,@CustomerEmail,@Question5,@Answer5),
		(@AdoptionApplicationID,@CustomerEmail,@Question6,@Answer6),
		(@AdoptionApplicationID,@CustomerEmail,@Question7,@Answer7),
		(@AdoptionApplicationID,@CustomerEmail,@Question8,@Answer8),
		(@AdoptionApplicationID,@CustomerEmail,@Question9,@Answer9),
		(@AdoptionApplicationID,@CustomerEmail,@Question10,@Answer10)
		Return @@ROWCOUNT 
END
GO


/*
    Created By: Cash Carlson
    Date: 3/01/2020
    Comment: Creating procedure to insert User
*/
print '' print '*** Creating sp_select_total_items_sold'
GO
DROP PROCEDURE IF EXISTS [sp_select_total_items_sold]
GO
CREATE PROCEDURE [sp_select_total_items_sold]
AS
BEGIN
    SELECT
        [TransactionLineProducts].[ProductID],
        [Item].[ItemName],
        [Product].[Brand],
        [Item].[ItemCategoryID],
        [Product].[ProductTypeID],
        SUM ([TransactionLineProducts].[Quantity]) AS 'Total Sales'
    FROM [dbo].[TransactionLineProducts]
    LEFT JOIN [Product] ON [TransactionLineProducts].[ProductID] = [Product].[ProductID]
	LEFT JOIN [Item] ON [Product].[ItemID] = [Item].[ItemID]
    GROUP BY
        [TransactionLineProducts].[ProductID],
        [Item].[ItemName],
        [Product].[Brand],
        [Item].[ItemCategoryID],
        [Product].[ProductTypeID]
END
GO

/*
Created by: Zach Behrensmeyer
Date: 03/16/2020
Comment: This is used to check that the email exists
*/
DROP PROCEDURE IF EXISTS [sp_select_messages_by_recipient]
GO
print '' print '*** Creating sp_select_messages_by_recipient ***'
GO
CREATE PROCEDURE [sp_select_messages_by_recipient]
(
@MessageReceiverID [INT]
)
AS
BEGIN
SELECT  [MessageID]			
        ,[MessageContent] 	
        ,[MessageTitle] 	
        ,[MessageSenderID] 	
        ,[MessageReceiverID]
        ,[MessageSeen] 		
FROM Message
WHERE MessageReceiverID = @MessageReceiverID
END 
GO

/*
Created by: Zach Behrensmeyer
Date: 03/18/2020
Comment: This is used to query departments that are like provided text in the recipient box
*/
DROP PROCEDURE IF EXISTS [sp_get_departments_like_input]
GO
print '' print '*** Creating sp_get_departments_like_input***'
GO
CREATE PROCEDURE [sp_get_departments_like_input]
(
@query NVARCHAR(50)
)
AS 
BEGIN
SELECT [DepartmentID]
FROM Department 
WHERE DepartmentID LIKE '%' + @query + '%'
END
GO		

/*
Created by: Zach Behrensmeyer
Date: 03/18/2020
Comment: This is used to query users that are like provided text in the recipient box
*/
DROP PROCEDURE IF EXISTS [sp_get_users_like_input]
GO
print '' print '*** Creating sp_get_users_like_input***'
GO
CREATE PROCEDURE [sp_get_users_like_input]
(
@query NVARCHAR(50)
)
AS 
BEGIN
SELECT [Email]
FROM [dbo].[User]
WHERE Email LIKE '%' + @query + '%'
END
GO	

/*
Created by: Zach Behrensmeyer
Date: 03/1/2020
Comment: This is used to send the message
*/
DROP PROCEDURE IF EXISTS [sp_insert_message]
GO
print '' print '*** Creating sp_insert_message***'
GO
CREATE PROCEDURE [sp_insert_message]
(
		 @MessageContent 		[NVARCHAR](4000)
		,@MessageTitle 		[NVARCHAR](100)
		,@MessageSenderID 	[INT]
		,@MessageReceiverID	[INT]
)
AS 
BEGIN
INSERT INTO [Message]
	(MessageContent, 
	MessageTitle,
	MessageSenderID,
	MessageReceiverID,
	MessageSeen
	
	)
	Values(@MessageContent 
	       ,@MessageTitle 	
	       ,@MessageSenderID
	       ,@MessageReceiverID
		   ,0
		   )
END	
GO

/*
Created by: Zach Behrensmeyer
Date: 03/19/2020
Comment: This is used to get all users in a department
*/
DROP PROCEDURE IF EXISTS [sp_get_department_users]
GO
print '' print '*** Creating sp_get_department_users***'
GO
CREATE PROCEDURE [sp_get_department_users]
(
	@DepartmentID [nvarchar](50)
)
AS 
BEGIN
SELECT UserID, FirstName, LastName, PhoneNumber, Email, addressLineOne, addressLineTwo, City, State, ZipCode
FROM [dbo].[User]
WHERE DepartmentID = @DepartmentID 
END	
GO


/*
Created by: Jordan Lindo
Date: 3/14/2020
Comment: Stored procedure for inserting baseschedule.
*/

DROP PROCEDURE IF EXISTS [sp_insert_baseschedule]
GO

print '' print'***Creating sp_insert_baseschedule'
GO

CREATE PROCEDURE [sp_insert_baseschedule]
(
	 @CreatingUserID				[int]
	,@CreationDate					[date]
)
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

	BEGIN TRY
		BEGIN TRANSACTION
		
		IF (SELECT COUNT(BaseScheduleID)
			FROM [dbo].[BaseSchedule])>0
			BEGIN
				UPDATE [dbo].[BaseSchedule]
				SET [Active] = 0
				WHERE [Active] = 1
			END
			
			
		INSERT INTO [dbo].[BaseSchedule]
		([CreatingUserID],[CreationDate],[Active])
		VALUES
		(@CreatingUserID,@CreationDate,1)
		SELECT SCOPE_IDENTITY()
		
		COMMIT
		
		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH
END
GO

/*
Created by: Jordan Lindo
Date: 3/14/2020
Comment: Stored procedure for inserting baseschedulelines.
*/

DROP PROCEDURE IF EXISTS [sp_insert_basescheduleline]
GO

print '' print'***Creating sp_insert_basescheduleline'
GO

CREATE PROCEDURE [sp_insert_basescheduleline]
(
	 @ERoleID					[nvarchar](50)
	,@BaseScheduleID			[int]
	,@ShiftTimeID				[int]
	,@Count						[int]
)
AS
BEGIN
INSERT INTO [dbo].[BaseScheduleLine]
	([ERoleID],[BaseScheduleID],[ShiftTimeID],[Count])
	VALUES
	(@ERoleID,@BaseScheduleID,@ShiftTimeID,@Count)
END
GO

/*
Created by: Jordan Lindo
Date: 3/15/2020
Comment: Stored procedure for selecting the active baseschedule.
*/

DROP PROCEDURE IF EXISTS [sp_select_active_baseschedule]
GO

print '' print'***Creating sp_select_active_baseschedule'
GO

CREATE PROCEDURE [sp_select_active_baseschedule]
AS
BEGIN
	SELECT [BaseScheduleID],[CreatingUserID],[CreationDate],[Active]
	FROM [dbo].[BaseSchedule]
	WHERE [Active] = 1
END
GO

/*
Created by: Jordan Lindo
Date: 3/15/2020
Comment: Stored procedure for selecting the all baseschedules.
*/

DROP PROCEDURE IF EXISTS [sp_select_baseschedules]
GO

print '' print'***Creating sp_select_baseschedules'
GO

CREATE PROCEDURE [sp_select_baseschedules]
AS
BEGIN
	SELECT [BaseScheduleID],[CreatingUserID],[CreationDate],[Active]
	FROM [dbo].[BaseSchedule]
END
GO

/*
Created by: Jordan Lindo
Date: 3/15/2020
Comment: Stored procedure for selecting baseschedulelines.
*/

DROP PROCEDURE IF EXISTS [sp_select_baseschedulelines_by_basescheduleid]
GO

print '' print'***Creating sp_select_baseschedulelines_by_basescheduleid'
GO

CREATE PROCEDURE [sp_select_baseschedulelines_by_basescheduleid]
(
	@BaseScheduleID				[int]
)
AS
BEGIN
	SELECT [ERoleID],[ShiftTime].[ShiftTimeID],[Count],[DepartmentID]
	FROM [dbo].[BaseScheduleLine] JOIN [dbo].[ShiftTime] ON [BaseScheduleLine].[ShiftTimeID] = [ShiftTime].[ShiftTimeID]
	WHERE [BaseScheduleID] = @BaseScheduleID
END
GO

/*
Created by: Jordan Lindo
Date: 3/15/2020
Comment: Stored procedure for selecting ERole by DepartmentID
*/

DROP PROCEDURE IF EXISTS [sp_select_erole_by_departmentid]
GO

print '' print'***Creating sp_select_erole_by_departmentid'
GO

CREATE PROCEDURE [sp_select_erole_by_departmentid]
(
	@DepartmentID			[nvarchar](50)
)
AS
BEGIN
	SELECT [ERoleID],[Description],[Active]
	FROM [dbo].[ERole]
	WHERE [DepartmentID] = @DepartmentID
END
GO

/*
Created by: Jordan Lindo
Date: 3/15/2020
Comment: Stored procedure for selecting ShiftTime by DepartmentID
*/

DROP PROCEDURE IF EXISTS [sp_select_shifttime_by_departmentid]
GO

print '' print'***Creating sp_select_shifttime_by_departmentid'
GO

CREATE PROCEDURE [sp_select_shifttime_by_departmentid]
(
	@DepartmentID				[nvarchar](50)
)
AS
BEGIN
	SELECT [ShiftTimeID],[StartTime],[EndTime]
	FROM [dbo].[ShiftTime]
	WHERE [DepartmentID] = @DepartmentID
END
GO

/*
Created by: Steven Cardona
Date: 02/06/2020
Comment: This is used to INSERT a new user into the database
with all default values used.
*/
DROP PROCEDURE IF EXISTS [sp_select_all_active_users]
GO
PRINT '' PRINT '** Create sp_select_all_active_users'
GO
CREATE PROCEDURE [sp_select_all_active_users]
AS
BEGIN
    SELECT
        [UserID],
        [FirstName],
        [LastName], 
        [PhoneNumber],
        [Email],
        [addressLineOne],
        [addressLineTwo],
        [City],
        [State],
        [Zipcode],
		[Active]
    FROM [dbo].[User]
    Where [Active] = 1
END
GO

/*
Author: Austin Gee
Date: 3/18/2020
Comment: Creating procedure for selecting a customer by email
*/
DROP PROCEDURE IF EXISTS [sp_select_customer_by_email]
GO
print '' print '*** Creating sp_select_customer_by_email'
GO
CREATE PROCEDURE [sp_select_customer_by_email] (

	@Email [nvarchar] (250)
)
AS
BEGIN
	SELECT
	[FirstName]
	,[LastName]
	,[PhoneNumber]
	,[Email]
	,[Customer].[Active]
	,[addressLineOne]
	,[addressLineTwo]
	,[City]
	,[State]
	,[Zipcode]
	FROM [Customer] 
	WHERE [Customer].[Email] = @Email
END
GO

/*
Author: Austin Gee
Date: 3/18/2020
Comment: Creating procedure for selecting all appointment types
*/
DROP PROCEDURE IF EXISTS [sp_select_all_appointment_types]
GO
print '' print '*** Creating sp_select_all_appointment_types'
GO
CREATE PROCEDURE [sp_select_all_appointment_types] 
AS
BEGIN
	SELECT
		[AppointmentTypeID]
	FROM [AppointmentType]
	
END
GO

/*
Author: Austin Gee
Date: 3/18/2020
Comment: Creating procedure for selecting an adoption application by email
*/
DROP PROCEDURE IF EXISTS [sp_select_adoption_applications_by_email_and_active]
GO
print '' print '*** Creating sp_select_adoption_applications_by_email'
GO
CREATE PROCEDURE [sp_select_adoption_applications_by_email_and_active] (

	@Email [nvarchar] (250),
	@Active [bit]
)
AS
BEGIN
	SELECT
	[AdoptionApplicationID]
	,[CustomerEmail]
	,[AdoptionApplication].[AnimalID]
	,[Status]
	,[RecievedDate]
	,[AnimalName]
	,[AnimalSpeciesID]
	,[AnimalBreed]
	,[Animal].[Active]
	,[AdoptionApplication].[Active]
	FROM [AdoptionApplication]
	JOIN [Animal] ON [Animal].[AnimalID] = [AdoptionApplication].[AnimalID]
	WHERE [CustomerEmail] = @Email
	AND [AdoptionApplication].[Active] = @Active
END
GO
 
/*
Created by: Matt Deaton
Date: 2020-03-06
Comment: Stored Procedure for selecting all shelter items, where ShelterItem field is true.
*/
PRINT '' PRINT '*** Creating sp_select_shelter_items'
GO
CREATE PROCEDURE [sp_select_shelter_items]
(
	@ShelterItem 		[bit]
)
AS
BEGIN
	SELECT [ItemName], [ItemCategory].[ItemCategoryID]
	, [ItemQuantity], [ItemDescription]
	, [ShelterItem], [ItemID], [ShelterThershold]
	FROM [Item] JOIN [ItemCategory] ON [Item].[ItemCategoryID]
		= [ItemCategory].[ItemCategoryID]
	WHERE [ShelterItem] = @ShelterItem
	ORDER BY [ItemQuantity]
END
GO

/*
Created by: Matt Deaton
Date: 2020-03-06
Comment: Strored Procedure for viewing only Shelter Items that are below the ShelterThreshold.
*/
PRINT '' PRINT '*** Creating sp_view_needed_donations'
GO
CREATE PROCEDURE [sp_view_needed_donations]
AS
BEGIN
	SELECT [ItemName], [ItemCategory].[ItemCategoryID]
	, [ItemQuantity], [ItemDescription]
	, [ShelterItem], [ItemID], [ShelterThershold]
	FROM [Item] JOIN [ItemCategory] ON [Item].[ItemCategoryID]
		= [ItemCategory].[ItemCategoryID]
	WHERE [ItemQuantity] <= [ShelterThershold]
	ORDER BY [ItemQuantity]
END
GO

/*
Created by: Matt Deaton
Date: 2020-03-06
Comment: Stored Procedure for selecting a ShelterItem by there ItemName
*/
PRINT '' PRINT '*** Creating sp_select_shelter_item_by_item_name'
GO
CREATE PROCEDURE [sp_select_shelter_item_by_item_name]
(
	@ItemName		[nvarchar](50)
)
AS
BEGIN
	SELECT [ItemName], [ItemCategory].[ItemCategoryID]
	, [ItemQuantity], [ItemDescription]
	, [ShelterItem], [ItemID], [ShelterThershold]
	FROM [Item] JOIN [ItemCategory] ON [Item].[ItemCategoryID]
		= [ItemCategory].[ItemCategoryID]
	WHERE [ItemName] = @ItemName
	ORDER BY [ItemQuantity]
END
GO

/*
Created by: Matt Deaton
Date: 2020-03-06
Comment: Stored Procedure for inserting a new ShelterItem through donations.
*/
PRINT '' PRINT '*** Creating sp_insert_new_donation'
GO
CREATE PROCEDURE [sp_insert_new_donation]
(
	@ItemName			[nvarchar](50),
	@ItemCategoryID		[nvarchar](50),
	@ItemQuantity		[int],
	@ItemDescription	[nvarchar](250),
	@ShelterItem		[bit],
	@ShelterThershold	[int]
)
AS
BEGIN
	INSERT INTO [dbo].[Item]
		([ItemName], [ItemCategoryID], [ItemQuantity]
		, [ItemDescription], [ShelterItem], [ShelterThershold])
	VALUES
		(@ItemName, @ItemCategoryID, @ItemQuantity
		, @ItemDescription, @ShelterItem, @ShelterThershold)
	SELECT SCOPE_IDENTITY()
END
GO

/*
CREATED BY: Matt Deaton
DATE: 2020-03-16
COMMENT: Stored Procedure to edit a shelter item.
*/
PRINT '' PRINT '*** Creating sp_update_shelter_item'
GO
CREATE PROCEDURE [sp_update_shelter_item]
(
	@ItemID					[int],

	@NewItemName			[nvarchar](50),
	@NewItemCategoryID		[nvarchar](50),
	@NewItemQuantity		[int],
	@NewItemDescription		[nvarchar](250),
	@NewShelterItem			[bit],
	@NewShelterThershold	[int],

	@OldItemName			[nvarchar](50),
	@OldItemCategoryID		[nvarchar](50),
	@OldItemQuantity		[int],
	@OldItemDescription		[nvarchar](250),
	@OldShelterItem			[bit],
	@OldShelterThershold	[int]
)
AS
BEGIN
	UPDATE [dbo].[Item]
	SET		[ItemName] = @NewItemName,
			[ItemCategoryID] = @NewItemCategoryID,
			[ItemQuantity] = @NewItemQuantity,
			[ItemDescription] = @NewItemDescription,
			[ShelterItem] = @NewShelterItem,
			[ShelterThershold] = @NewShelterThershold
	WHERE	[ItemID] = @ItemID
	AND 	[ItemName] = @OldItemName
	AND		[ItemCategoryID] = @OldItemCategoryID
	AND		[ItemDescription] = @OldItemDescription
	AND		[ShelterItem] = @OldShelterItem
	AND		[ShelterThershold] = @OldShelterThershold

	RETURN @@ROWCOUNT
END
GO

/*
CREATED BY: Matt Deaton
DATE: 2020-03-16
COMMENT: Stored Procedure to view all donors.
*/
PRINT '' PRINT '*** Creating sp_select_donors'
GO
CREATE PROCEDURE[sp_select_donors]
AS
BEGIN
	SELECT	[DonorID]
			, [FirstName]
			, [LastName]
			, [Active]
	FROM [Donor]
	ORDER BY[DonorID]
END
GO

/*
Created by: Lane Sandburg
Date: 3/17/2020
Comment: Sproc to Change if and employee has read
	policies and standards
*/
DROP PROCEDURE IF EXISTS [sp_change_user_has_read]
GO
PRINT '' PRINT '*** Creating sp_change_user_has_read'
GO
CREATE PROCEDURE [sp_change_user_has_read]
(
    @UserID			 [int]
)
AS
BEGIN
	UPDATE [dbo].[User]
    SET [HasViewedPoliciesAndStandards] = 1
    WHERE [UserID] = @UserID
    
    RETURN @@ROWCOUNT
END 
GO
                
/*
Created by: Ben Hanna
Date: 4/2/2020
Comment: Insert a kennel cleaning record
*/
DROP PROCEDURE IF EXISTS [sp_insert_kennel_cleaning_record]
GO                
PRINT '' PRINT '*** Creating sp_insert_kennel_cleaning_record'
GO
CREATE PROCEDURE [sp_insert_kennel_cleaning_record]
(
    @UserID           [int],
    @AnimalKennelID   [int], 
    @Date	          [date],
    @Notes            [nvarchar](250)
        
)
AS
BEGIN
   INSERT INTO [dbo].[FacilityKennelCleaning] 
        ([UserID],
         [AnimalKennelID],
         [Date],
         [Notes]
        )
   VALUES 
        (@UserID,
         @AnimalKennelID,
         @Date,
         @Notes
        )
   SELECT SCOPE_IDENTITY()
END
GO               

/*
Created by: Robert Holmes
Date: 2020/03/10
Comment: Stored procedure to return all PromotionTypes
*/
DROP PROCEDURE IF EXISTS [sp_select_promotion_types]
GO
print '' print '*** Creating stored procedure sp_select_promotion_types'
GO
CREATE PROCEDURE [sp_select_promotion_types]
AS
	BEGIN
		SELECT 	[PromotionTypeID]
		FROM 	[dbo].[PromotionType]
	END
GO

/*
Created by: Robert Holmes
Date: 2020/03/17
Comment: Adds a new product to the database.
*/
DROP PROCEDURE IF EXISTS [sp_insert_product]
print '' print '*** Creating stored procedure sp_insert_product'
GO
CREATE PROCEDURE [sp_insert_product]
(
		@ProductID		[nvarchar](13)
	,	@ItemID			[int]
	,	@ProductTypeID	[nvarchar](20)
	,	@Taxable		[bit]
	,	@Price			[decimal](10,2)
	,	@Description	[nvarchar](500)
	,	@Brand			[nvarchar](20)
)
AS
	BEGIN
		INSERT INTO [dbo].[Product]
		([ProductID], [ItemID], [ProductTypeID], [Taxable], [Price], [Description], [Brand])
		VALUES
		(@ProductID, @ItemID, @ProductTypeID, @Taxable, @Price, @Description, @Brand)
	END
GO

/*
Created by: Robert Holmes
Date: 2020/03/18
Comment: Returns all stored ProductTypeIDs
*/
DROP PROCEDURE IF EXISTS [sp_select_all_product_type_id]
GO
print '' print '*** Creating stored procedure sp_select_all_product_type_id'
GO
CREATE PROCEDURE [sp_select_all_product_type_id]
AS
	BEGIN
		SELECT 	[ProductTypeID]
		FROM	[dbo].[ProductType]
	END
GO

/*
Created by: Robert Holmes
Date: 2020/03/19
Comment: Returns all stored Promotions
*/
DROP PROCEDURE IF EXISTS [sp_select_all_promotions]
GO
print '' print '*** Creating stored procedure sp_select_all_promotions'
GO
CREATE PROCEDURE [sp_select_all_promotions]
AS
	BEGIN
		SELECT	[PromotionID],
				[PromotionTypeID],
				[StartDate],
				[EndDate],
				[Discount],
				[Description],
				[Active]
		FROM	[dbo].[Promotion]
	END
GO

/*
Created by: Robert Holmes
Date: 2020/03/19
Comment: Returns all active stored Promotions
*/
DROP PROCEDURE IF EXISTS [sp_select_all_active_promotions]
GO
print '' print '*** Creating stored procedure sp_select_all_active_promotions'
GO
CREATE PROCEDURE [sp_select_all_active_promotions]
AS
	BEGIN
		SELECT	[PromotionID],
				[PromotionTypeID],
				[StartDate],
				[EndDate],
				[Discount],
				[Description],
				[Active]
		FROM	[dbo].[Promotion]
		WHERE 	[Active] = 1
	END
GO

/*
Created by: Robert Holmes
Date: 2020/03/19
Comment: Returns all products associated with a promotion id
*/
DROP PROCEDURE IF EXISTS [sp_select_all_products_by_promotion_id]
GO
print '' print '*** Creating stored procedure sp_select_products_by_promotion_id'
GO
CREATE PROCEDURE [sp_select_all_products_by_promotion_id]
(
	@PromotionID	[nvarchar](20)
)
AS
	BEGIN
		SELECT 	[Product].[ProductID],
				[Product].[ItemID],
				[Item].[ItemName],
				[Item].[ItemCategoryID],
				[Product].[ProductTypeID],
				[Product].[Description],
				[Product].[Price],
				[Product].[Brand],
				[Product].[Taxable]
		FROM	[dbo].[PromoProductLine]
		INNER JOIN 	[dbo].[Product] ON [PromoProductLine].[ProductID] = [Product].[ProductID]
		INNER JOIN	[Item]	ON	[Item].[ItemID] = [Product].[ItemID]
		WHERE	[PromotionID] = @PromotionID
	END
GO

/*
Created by: Robert Holmes
Date: 2020/03/19
Comment: Saves edits made to promotions.
*/
DROP PROCEDURE IF EXISTS [sp_update_promotion]
GO
print '' print '*** Creating stored procdure sp_update_promotion'
GO
CREATE PROCEDURE [sp_update_promotion]
(
	@PromotionID		[nvarchar](20),
	@OldPromotionTypeID	[nvarchar](20),
	@OldStartDate		[datetime],
	@OldEndDate			[datetime],
	@OldDiscount		[decimal](10, 2),
	@OldDescription		[nvarchar](500),
	@OldActive			[bit],
	@NewPromotionTypeID	[nvarchar](20),
	@NewStartDate		[datetime],
	@NewEndDate			[datetime],
	@NewDiscount		[decimal](10, 2),
	@NewDescription		[nvarchar](500),
	@NewActive			[bit]
)
AS
	BEGIN
		UPDATE [dbo].[Promotion]
		SET		[PromotionTypeID] = @NewPromotionTypeID
			,	[StartDate] = @NewStartDate
			,	[EndDate] = @NewEndDate
			,	[Discount] = @NewDiscount
			,	[Description] = @NewDescription
		WHERE	[PromotionTypeID] = @OldPromotionTypeID
		AND		[StartDate] = @OldStartDate
		AND		[EndDate] = @OldEndDate
		AND		[Discount] = @OldDiscount
		AND		[Description] = @OldDescription
		RETURN @@ROWCOUNT
	END
GO

/*
Created by: Robert Holmes
Date: 2020/03/19
Comment: Removes old promotion product relationships.
*/
DROP PROCEDURE IF EXISTS [sp_delete_promo_products]
GO
print '' print '*** Creating stored procedure sp_delete_promo_products'
GO
CREATE PROCEDURE [sp_delete_promo_products]
(
	@PromotionID	[nvarchar](20)
)
AS
	BEGIN
		DELETE FROM [dbo].[PromoProductLine]
		WHERE [PromotionID] = @PromotionID
	END
GO

/*
Created by: Ethan Murphy
Date: 4/6/2020
Comment: Updates an animal activity record
*/
DROP PROCEDURE IF EXISTS [sp_update_animal_activity]
GO
print '' print '*** creating sp_update_animal_activity'
GO
CREATE PROCEDURE [sp_update_animal_activity]
(
	@AnimalActivityID			[int],
	@AnimalID					[int],
	@UserID						[int],
	@AnimalActivityTypeID		[nvarchar](100),
	@ActivityDateTime			[datetime],
	@Description				[nvarchar](400),
	
	@NewAnimalID				[int],
	@NewUserID					[int],
	@NewAnimalActivityTypeID	[nvarchar](100),
	@NewActivityDateTime		[datetime],
	@NewDescription				[nvarchar](400)
)
AS
BEGIN
	UPDATE [dbo].[AnimalActivity]
	SET [AnimalID] = @NewAnimalID,
		[UserID] = @NewUserID,
		[AnimalActivityTypeID] = @NewAnimalActivityTypeID,
		[ActivityDateTime] = @NewActivityDateTime,
		[Description] = @NewDescription
	WHERE [AnimalActivityID] = @AnimalActivityID
	AND	[UserID] = @UserID
	AND	[AnimalActivityTypeID] = @AnimalActivityTypeID
	AND	[ActivityDateTime] = @ActivityDateTime
	AND	[Description] = @Description
	RETURN @@ROWCOUNT
END
GO

/*
Created by: Zach Behrensmeyer
Date: 3/30/2020
Comment: Sproc to set message as seen
*/
DROP PROCEDURE IF EXISTS [sp_set_message_seen]
GO
PRINT '' PRINT '*** Creating sp_set_message_seen'
GO
CREATE PROCEDURE [sp_set_message_seen]
(
	@MessageID 			int
)
AS
BEGIN
	UPDATE Message
	SET MessageSeen = 1
	WHERE MessageID = @MessageID
END
GO

/*
Created by: Zach Behrensmeyer
Date: 3/27/2020
Comment: Sproc to find user by id
*/
DROP PROCEDURE IF EXISTS [sp_select_user_by_id]
GO
PRINT '' PRINT '*** Creating sp_select_user_by_id'
GO
CREATE PROCEDURE [sp_select_user_by_id]
(
	@UserID 			int
)
AS
BEGIN
	SELECT 	[UserID],
			[FirstName],
			[LastName], 
			[PhoneNumber],
			[Email],
			[addressLineOne],
			[addressLineTwo],
			[City],
			[State],
			[Zipcode],
			[Active]
	FROM 	[dbo].[User]
	WHERE 	[UserID] = @UserID
END
GO

/*
Created by: Ryan Morganti
Date: 2020/04/04
Comment: Stored Procedure to pull all donations over the past year
*/
DROP PROCEDURE IF EXISTS [sp_select_all_donations_from_past_year]
GO
PRINT '' PRINT '*** Creating sp_select_all_donations_from_past_year'
GO
CREATE PROCEDURE [sp_select_all_donations_from_past_year]
AS
BEGIN
	SELECT do.[DonationID], d.[DonorID], d.[FirstName], d.[LastName], do.[DateOfDonation], do.[TypeOfDonation], do.[DonationAmount]
	FROM [dbo].[Donor] AS d JOIN [dbo].[Donations] AS do ON
	d.[DonorID] = do.[DonorID]
	WHERE do.[DateOfDonation] > DATEADD(year, -1, GETDATE())
END
GO


/*
Created by: Jesse Tomash
Date: 3/10/2020
Comment: insert order sp
*/
DROP PROCEDURE IF EXISTS [sp_insert_order]
GO
print '' print '*** Creating sp_insert_order'
GO
CREATE PROCEDURE sp_insert_order
	(
        @UserID						[int],
		@Active						[bit]
	)
AS
	BEGIN
		INSERT INTO [orders]
			([UserID], [Active])
		VALUES
			(@UserID, @Active)
	  
		RETURN @@ROWCOUNT
	END
GO

/*
Created by: Jesse Tomash
Date: 3/10/2020
Comment: insert order sp
*/
DROP PROCEDURE IF EXISTS [sp_insert_special_order]
GO
print '' print '*** Creating sp_insert_special_order'
GO
CREATE PROCEDURE sp_insert_special_order
	(
        @UserID						[int],
		@Active						[bit]
	)
AS
	BEGIN
		INSERT INTO [specialorders]
			([UserID], [Active])
		VALUES
			(@UserID, @Active)
	  
		RETURN @@ROWCOUNT
	END
GO

/*
Created by: Jesse Tomash
Date: 3/10/2020
Comment: retrieves all special orders
*/
DROP PROCEDURE IF EXISTS [sp_select_all_orders]
GO
print '' print '*** Creating sp_select_orders'
GO
CREATE PROCEDURE sp_select_all_orders
AS
	BEGIN
		SELECT [OrderID], [UserID]
		FROM [orders]
		Order BY [OrderID]
	END
GO

/*
Created by: Jesse Tomash
Date: 3/10/2020
Comment: retrieves all special orders
*/
DROP PROCEDURE IF EXISTS [sp_select_all_special_orders]
GO
print '' print '*** Creating sp_select_all_special_orders'
GO
CREATE PROCEDURE sp_select_all_special_orders
AS
	BEGIN
		SELECT [SpecialOrderID], [UserID]
		FROM [specialorders]
		Order BY [SpecialOrderID]
	END
GO

/*
Created by: Jesse Tomash
Date: 3/10/2020
Comment: retrieves order by id
*/
DROP PROCEDURE IF EXISTS [sp_select_order_by_id]
GO
print '' print '*** Creating sp_select_order_by_id'
GO
CREATE PROCEDURE sp_select_order_by_id
	(
		@OrderID		[int]
	)
AS
	BEGIN
		SELECT [OrderID], [UserID]
		FROM [Orders]
		WHERE [OrderID] = @OrderID
	END
GO

/*
Created by: Jesse Tomash
Date: 3/10/2020
Comment: retrieves special order by id
*/
DROP PROCEDURE IF EXISTS [sp_select_special_order_by_id]
GO
print '' print '*** Creating sp_select_special_order_by_id'
GO
CREATE PROCEDURE sp_select_special_order_by_id
	(
		@SpecialOrderID		[int]
	)
AS
	BEGIN
		SELECT [SpecialOrderID], [UserID]
		FROM [SpecialOrders]
		WHERE [SpecialOrderID] = @SpecialOrderID
	END
GO

/*
Created by: Jesse Tomash
Date: 3/10/2020
Comment: updates an order
*/
DROP PROCEDURE IF EXISTS [sp_update_order_by_id]
GO
print '' print '*** Creating sp_update_order_by_id'
GO
CREATE PROCEDURE sp_update_order_by_id
	(
		@OrderID					[int],
        @UserID						[int],
		@Active						[bit],
		
		@OldOrderID					[int],
        @OldUserID					[int],
		@OldActive					[bit]
	)
AS
	BEGIN
		UPDATE  [orders]
		SET 	[UserID] = @UserID,
				[Active] = @Active
		WHERE 	[OrderID] = @OldOrderID
		  
		RETURN @@ROWCOUNT
	END
GO

/*
Created by: Jesse Tomash
Date: 3/10/2020
Comment: updates a special order
*/
DROP PROCEDURE IF EXISTS [sp_update_special_order_by_id]
GO
print '' print '*** Creating sp_update_order_by_id'
GO
CREATE PROCEDURE sp_update_special_order_by_id
	(
		@SpecialOrderID				[int],
        @UserID						[int],
		@Active						[bit],
		
		@OldSpecialOrderID			[int],
        @OldUserID					[int],
		@OldActive					[bit]
	)
AS
	BEGIN
		UPDATE  [specialorders]
		SET 	[UserID] = @UserID,
				[Active] = @Active
		WHERE 	[SpecialOrderID] = @SpecialOrderID
		  
		RETURN @@ROWCOUNT
	END
GO

/*
Created by: Jesse Tomash
Date: 3/10/2020
Comment: Delets an order
*/
DROP PROCEDURE IF EXISTS [sp_delete_order_by_id]
GO
print '' print '*** Creating sp_delete_order_by_id'
GO
CREATE PROCEDURE sp_delete_order_by_id
	(
		@OrderID				[int]
	)
AS
	BEGIN
		DELETE  
		FROM 	[orders]
		WHERE 	[OrderID] = @OrderID
	  
		RETURN @@ROWCOUNT
	END
GO

/*
Created by: Jesse Tomash
Date: 3/10/2020
Comment: Delets an order
*/
DROP PROCEDURE IF EXISTS [sp_delete_special_order_by_id]
GO
print '' print '*** Creating sp_delete_special_order_by_id'
GO
CREATE PROCEDURE sp_delete_special_order_by_id
	(
		@SpecialOrderID				[int]
	)
AS
	BEGIN
		DELETE  
		FROM 	[specialorders]
		WHERE 	[SpecialOrderID] = @SpecialOrderID
	  
		RETURN @@ROWCOUNT
	END
GO


/*
Created by: Jesse Tomash
Date: 3/10/2020
Comment: deactivates an order
*/
DROP PROCEDURE IF EXISTS [sp_deactivate_order_by_id]
GO
print '' print '*** Creating sp_deactivate_order_by_id'
GO
CREATE PROCEDURE sp_deactivate_order_by_id
	(
		@OrderID					[int]
	)
AS
	BEGIN
		UPDATE  [orders]  
		SET 	[Active] = 0
		WHERE 	[OrderID] = @OrderID
	  
		RETURN @@ROWCOUNT
	END
GO

/*
Created by: Jesse Tomash
Date: 3/10/2020
Comment: deactivates an order
*/
DROP PROCEDURE IF EXISTS [sp_deactivate_special_order_by_id]
GO
print '' print '*** Creating sp_deactivate_special_order_by_id'
GO
CREATE PROCEDURE sp_deactivate_special_order_by_id
	(
		@SpecialOrderID					[int]
	)
AS
	BEGIN
		UPDATE  [specialorders]  
		SET 	[Active] = 0
		WHERE 	[SpecialOrderID] = @SpecialOrderID
	  
		RETURN @@ROWCOUNT
	END
GO

/*
Created by: Jesse Tomash
Date: 3/10/2020
Comment: activates an order
*/
DROP PROCEDURE IF EXISTS [sp_activate_order_by_id]
GO
print '' print '*** Creating sp_activate_order_by_id'
GO
CREATE PROCEDURE sp_activate_order_by_id
	(
		@OrderID				[int]
	)
AS
	BEGIN
		UPDATE  [orders]  
		SET 	[Active] = 1
		WHERE 	[OrderID] = @OrderID
	  
		RETURN @@ROWCOUNT
	END
GO

/*
Created by: Jesse Tomash
Date: 3/10/2020
Comment: activates an order
*/
DROP PROCEDURE IF EXISTS [sp_activate_special_order_by_id]
GO
print '' print '*** Creating sp_activate_special_order_by_id'
GO
CREATE PROCEDURE sp_activate_special_order_by_id
	(
		@SpecialOrderID				[int]
	)
AS
	BEGIN
		UPDATE  [specialorders]  
		SET 	[Active] = 1
		WHERE 	[SpecialOrderID] = @SpecialOrderID
	  
		RETURN @@ROWCOUNT
	END
GO

/*
Created by: Jaeho Kim
Date: 03/08/2020
Comment: Selects a list of all transactions with employee name.
*/
print '' print '*** Creating sp_select_transactions_by_employee_name'
GO
CREATE PROCEDURE sp_select_transactions_by_employee_name
(
	@FirstName	[nvarchar](50),
	@LastName	[nvarchar](50)
)
AS
	BEGIN
		SELECT 	
		T.[TransactionID],
		T.[TransactionDateTime],
		U.[UserID],
		U.[FirstName],
		U.[LastName],
		T.[TransactionTypeID],
		T.[TransactionStatusID],
		T.[TaxRate],
		T.[SubTotalTaxable],
		T.[SubTotal],
		T.[Total],
		T.[CustomerEmail],
		T.[StripeChargeID]
		FROM 	[Transaction] T
		INNER JOIN [User] U
			ON T.[EmployeeID] = U.[UserID]
		WHERE U.[FirstName] = @FirstName
		And	  U.[LastName] = @LastName
	END
GO

/*
Created by: Jaeho Kim
Date: 04/13/2020
Comment: Selects a list of all transactions with transaction id.
*/
print '' print '*** Creating sp_select_transactions_by_transaction_id'
GO
CREATE PROCEDURE sp_select_transactions_by_transaction_id
(
	@TransactionID	[int]
)
AS
	BEGIN
		SELECT
        T.[TransactionID],
        T.[TransactionDateTime],
        T.[EmployeeID],
        U.[FirstName],
        U.[LastName],
        T.[TransactionTypeID],
        T.[TransactionStatusID],
		T.[TaxRate],
		T.[SubTotalTaxable],
		T.[SubTotal],
		T.[Total],
		T.[CustomerEmail],
		T.[StripeChargeID]
		FROM 	[Transaction] T
		INNER JOIN [User] U
			ON T.[EmployeeID] = U.[UserID]
		WHERE T.[TransactionID] = @TransactionID
	END
GO

/*
Created by: Jaeho Kim
Date: 03/08/2020
Comment: Inserts transaction sale product details.
*/
PRINT '' PRINT '*** Creating sp_insert_transaction_line_products'
GO
CREATE PROCEDURE [sp_insert_transaction_line_products]
(
	@TransactionID	[int],
	@ProductID		[nvarchar](13),
	@Quantity		[int],
	@PriceSold		[decimal](10,2)
)
AS
BEGIN	
	INSERT INTO [dbo].[TransactionLineProducts]
	([TransactionID],[ProductID],[Quantity],[PriceSold])
	VALUES
	(@TransactionID,@ProductID,@Quantity,@PriceSold)
	SELECT @@ROWCOUNT
END
GO

/*
Created by: Jaeho Kim
Date: 03/08/2020
Comment: Inserts the actual transaction.
*/
PRINT '' PRINT '*** Creating sp_insert_transaction'
GO
CREATE PROCEDURE [sp_insert_transaction]
(
	@TransactionDateTime	[datetime],
	@TaxRate				[decimal](10,2),
	@SubTotalTaxable		[decimal](10,2),
	@SubTotal				[decimal](10,2),
	@Total					[decimal](10,2),
	@TransactionTypeID		[nvarchar](20),
	@EmployeeID				[int],
	@TransactionStatusID	[nvarchar](20),
	@CustomerEmail			[nvarchar](250),
	@StripeChargeID			[nvarchar](30),
	@ReturnTransactionId 	[int] out  
)
AS
BEGIN
INSERT INTO [Transaction]
	([TransactionDateTime], [TaxRate], [SubTotalTaxable],
	[SubTotal], [Total], [TransactionTypeID],
	[EmployeeID], [TransactionStatusID], [CustomerEmail], [StripeChargeID])
VALUES
	(@TransactionDateTime, @TaxRate, @SubTotalTaxable,
	@SubTotal, @Total, @TransactionTypeID,
	@EmployeeID, @TransactionStatusID, @CustomerEmail, @StripeChargeID)
	SELECT SCOPE_IDENTITY()
END
GO

/*
Created by: Jaeho Kim
Date: 2020-04-13
Comment: Stored Procedure for inserting sales tax.
*/
DROP PROCEDURE IF EXISTS [sp_insert_sales_tax]
GO
print '' print '*** Creating sp_insert_sales_tax'
GO
CREATE PROCEDURE [sp_insert_sales_tax]
(
	@ZipCode			[nvarchar](50),
	@TaxRate 			[decimal](10,4),
	@SalesTaxDate		[datetime]
)
AS
BEGIN
	INSERT INTO [dbo].[SalesTaxHistory]
	([ZipCode], [TaxRate], [SalesTaxDate])
	VALUES
	(@ZipCode, @TaxRate, @SalesTaxDate)
END
GO 

/*
Created by: Jaeho Kim
Date: 03/08/2020
Comment: retrieves the latest sales tax date associated with the zip code.
*/
PRINT '' PRINT '*** Creating sp_select_latest_salesTaxDate_by_zipCode'
GO
CREATE PROCEDURE [sp_select_latest_salesTaxDate_by_zipCode]
(
	@ZipCode		[nvarchar](50)
)
AS
BEGIN
	
	SELECT MAX(SalesTaxDate) AS 'Latest Sales Date'
	FROM SalesTaxHistory
	WHERE ZipCode = @ZipCode

END
GO

PRINT '' PRINT '*** Creating sp_select_taxRate_by_salesTaxDate_and_zipCode'
GO
CREATE PROCEDURE [sp_select_taxRate_by_salesTaxDate_and_zipCode]
(
	@SalesTaxDate		[datetime],
	@ZipCode			[nvarchar](50)
)
AS
BEGIN
	
	SELECT TaxRate
	FROM SalesTaxHistory
	WHERE SalesTaxDate = @SalesTaxDate
	AND ZipCode = @ZipCode

END
GO

/*
Created by: Jaeho Kim
Date: 2020-04-14
Comment: Stored Procedure for inserting transaction type.
*/
DROP PROCEDURE IF EXISTS [sp_insert_transaction_type]
GO
print '' print '*** Creating sp_insert_transaction_type'
GO
CREATE PROCEDURE [sp_insert_transaction_type]
(
	@TransactionTypeID	[nvarchar](20),
	@Description 		[nvarchar](500),
	@DefaultInStore		[bit]
)
AS
BEGIN
	INSERT INTO [dbo].[TransactionType]
	([TransactionTypeID], [Description], [DefaultInStore])
	VALUES
	(@TransactionTypeID, @Description, @DefaultInStore)
	
	IF @DefaultInStore >= 0
		UPDATE [dbo].[TransactionType]
		SET [DefaultInStore] = 0
		WHERE [TransactionTypeID] != @TransactionTypeID
END
GO

/*
Created by: Jaeho Kim
Date: 2020-04-14
Comment: Stored Procedure for inserting transaction status.
*/
DROP PROCEDURE IF EXISTS [sp_insert_transaction_status]
GO
print '' print '*** Creating sp_insert_transaction_status'
GO
CREATE PROCEDURE [sp_insert_transaction_status]
(
	@TransactionStatusID	[nvarchar](20),
	@Description 			[nvarchar](500),
	@DefaultInStore			[bit]
)
AS
BEGIN
	INSERT INTO [dbo].[TransactionStatus]
	([TransactionStatusID], [Description], [DefaultInStore])
	VALUES
	(@TransactionStatusID, @Description, @DefaultInStore)
	
	IF @DefaultInStore >= 0
		UPDATE [dbo].[TransactionStatus]
		SET [DefaultInStore] = 0
		WHERE [TransactionStatusID] != @TransactionStatusID
END
GO

/*
Created by: Rasha Mohammed
Date: 3/16/2020
Comment: Search for an item 
*/
PRINT '' PRINT '*** Creating sp_select_product_by_id'
GO
CREATE PROCEDURE sp_select_product_by_id
(
	@ProductID				[nvarchar](13)
)
AS
BEGIN
	SELECT 
		P.[ProductID],
		I.[ItemName],
		P.[Taxable],
		P.[Price],
		I.[ItemQuantity],
		P.[Description],
		P.[Active],
		I.[ItemID],
		I.[ItemCategoryID],
		P.[ProductTypeID],
		P.[Brand]
	FROM [Item] I
	INNER JOIN [dbo].[Product] P
	ON I.[ItemID] = P.[ItemID]
	WHERE P.[ProductID] = @ProductID
	
END
GO

/*
Created by: Brandyn T. Coverdill
Date: 2020-04-07
Comment: Stored Procedure that adds a new Report to Missing / Damaged Items from the Shelf.
*/
DROP PROCEDURE IF EXISTS [sp_add_item_report]
GO
print '' print '*** Creating sp_add_item_report'
GO
CREATE PROCEDURE [sp_add_item_report]
(
	@ItemID			[int],
	@ItemQuantity 	[int],
	@Report			[nvarchar](250)
)
AS
BEGIN
	INSERT INTO [dbo].[ItemReport]
	([ItemID], [ItemQuantity], [Report])
	VALUES
	(@ItemID, @ItemQuantity, @Report)
	SELECT SCOPE_IDENTITY()
END
GO

/*
Created by: Brandyn T. Coverdill
Date: 2020-04-07
Comment: Stored Procedure that selects all Reports of Missing / Damaged Items from the Shelf.
*/
DROP PROCEDURE IF EXISTS [sp_select_all_item_reports]
GO
print '' print '*** Creating sp_select_all_item_reports'
GO
CREATE PROCEDURE [sp_select_all_item_reports]
AS
BEGIN
	SELECT [ItemReport].[ItemID],
		   [Item].[ItemName],
		   [ItemReport].[ItemQuantity],
		   [ItemReport].[Report]
	FROM [dbo].[ItemReport]
	INNER JOIN [dbo].[Item] ON [ItemReport].[ItemID] = [Item].[ItemID]
	ORDER BY [ItemReport].[ItemID]
END
GO

/*
Created by: Brandyn T. Coverdill
Date: 2020-04-07
Comment: Stored Procedure that selects a Report of a Missing / Damaged Item from the Shelf.
*/
DROP PROCEDURE IF EXISTS [sp_select_item_report_by_item_id]
GO
print '' print '*** creating sp_select_item_report_by_item_id'
GO
CREATE PROCEDURE [sp_select_item_report_by_item_id]
AS
BEGIN
	SELECT [ItemReport].[ItemID],
		   [Item].[ItemName],
		   [ItemReport].[ItemQuantity],
		   [ItemReport].[Report]
	FROM [dbo].[ItemReport]
	INNER JOIN [dbo].[Item] ON [ItemReport].[ItemID] = [Item].[ItemID]
END
GO

/*
Created by: Brandyn T. Coverdill
Date: 2020-04-07
Comment: Stored Procedure that updates a Report of a Missing / Damaged Item from the Shelf.
*/
DROP PROCEDURE IF EXISTS [sp_update_item_report]
GO
print '' print '*** Creating sp_update_item_report'
GO
CREATE PROCEDURE [sp_update_item_report]
(
	@OldItemQuantity 	[int],
	@OldReport			[nvarchar](250),
	@NewItemQuantity 	[int],
	@NewReport			[nvarchar](250),
	@ItemID				[int]
)
AS
BEGIN
	UPDATE [dbo].[ItemReport]
	SET   [ItemQuantity] = @NewItemQuantity,
		  [Report]       = @NewReport
	WHERE [ItemID]       = @ItemID
	AND   [ItemQuantity] = @OldItemQuantity
	AND	  [Report]		 = @OldReport
	RETURN @@ROWCOUNT
END
GO

/*
Created by: Brandyn T. Coverdill
Date: 2020-04-07
Comment: Stored Procedure that removes a Report of a Missing / Damaged Item from the Shelf.
*/
DROP PROCEDURE IF EXISTS [sp_delete_item_report]
GO
print '' print '*** Creating sp_delete_item_report'
GO
CREATE PROCEDURE [sp_delete_item_report]
(
	@ItemID 	  [int],
	@Report 	  [nvarchar](250),
	@ItemQuantity [int]
)
AS
BEGIN
	DELETE FROM [dbo].[ItemReport]
	WHERE [ItemID] = @ItemID
	AND [Report] = @Report
	AND [ItemQuantity] = @ItemQuantity
	RETURN @@ROWCOUNT
END
GO

                
/*
Created by: Ben Hanna
Date: 04/7/2020
Comment: Selects all of the kennel cleaning records
*/
DROP PROCEDURE IF EXISTS [sp_select_all_kennel_cleaning_records]
GO
PRINT '' PRINT '*** Creating sp_select_all_kennel_cleaning_records'
GO
CREATE PROCEDURE [sp_select_all_kennel_cleaning_records]
AS
BEGIN
	SELECT 
    [FacilityKennelCleaningID],	
	[UserID],					
	[AnimalKennelID],			
	[Date],						
	[Notes]						
 	FROM [dbo].[FacilityKennelCleaning]
END
GO
                
/*
Created by: Ben Hanna
Date: 4/8/2020
Comment: Update a kennel cleaning record
*/ 
DROP PROCEDURE IF EXISTS [sp_update_kennel_cleaning_record]
GO     
PRINT '' PRINT '*** Creating sp_update_kennel_cleaning_record'
GO
CREATE PROCEDURE [sp_update_kennel_cleaning_record]
(
    @FacilityKennelCleaningID   [int],
    
    @NewUserID                  [int],
    @NewAnimalKennelID          [int], 
    @NewDate	                [date],
    @NewNotes                   [nvarchar](250),
    
	@OldUserID                  [int],
    @OldAnimalKennelID          [int], 
    @OldDate	                [date],
    @OldNotes                   [nvarchar](250)
)
AS
BEGIN
	UPDATE [dbo].[FacilityKennelCleaning]
    SET [UserID]                              = @NewUserID, 
        [AnimalKennelID]                      = @NewAnimalKennelID,  
        [Date]                                = @NewDate,
        [Notes]                               = @NewNotes        
    WHERE   [FacilityKennelCleaningID]        = @FacilityKennelCleaningID
    AND     [UserID]                       = @OldUserID
    AND     [AnimalKennelID]               = @OldAnimalKennelID  
    AND     [Date]                         = @OldDate
    AND     [Notes]                        = @OldNotes 
    RETURN @@ROWCOUNT
END 
GO 

                
/*
Created by: Ben Hanna
Date: 4/9/2020
Comment: Deletes a kennel cleaning record
*/
DROP PROCEDURE IF EXISTS [sp_delete_kennel_cleaning_record]
GO
print '' print '*** Creating stored procedure sp_delete_kennel_cleaning_record'
GO
CREATE PROCEDURE [sp_delete_kennel_cleaning_record]
(
	@FacilityKennelCleaningID   [int],
    
    @UserID                     [int],
    @AnimalKennelID             [int], 
    @Date	                    [date],
    @Notes                      [nvarchar](250)
)
AS
	BEGIN
		DELETE FROM [dbo].[FacilityKennelCleaning]
		WHERE   [FacilityKennelCleaningID]     = @FacilityKennelCleaningID
        AND     [UserID]                       = @UserID
        AND     [AnimalKennelID]               = @AnimalKennelID  
        AND     [Date]                         = @Date
        AND     [Notes]                        = @Notes 
	END
GO     

/*
Created by: Robert Holmes
Date: 2020/04/07
Comment: Stored procedure to deactivate an active promotion.
*/
DROP PROCEDURE IF EXISTS [sp_deactivate_promotion]
GO
print '' print '*** Creating sp_deactivate_promotion'
GO
CREATE PROCEDURE [sp_deactivate_promotion]
(
	@PromotionID	[nvarchar](20)
)
AS
BEGIN
	UPDATE 	[dbo].[Promotion]
	SET		[Active] = 0
	WHERE	[PromotionID] = @PromotionID
	AND		[Active] = 1
	RETURN 	@@ROWCOUNT
END
GO

/*
Created by: Robert Holmes
Date: 2020/04/07
Comment: Stored procedure to reactivate an inactive promotion.
*/
DROP PROCEDURE IF EXISTS [sp_reactivate_promotion]
GO
print '' print '*** Creating sp_reactivate_promotion'
GO
CREATE PROCEDURE [sp_reactivate_promotion]
(
	@PromotionID	[nvarchar](20)
)
AS
BEGIN
	UPDATE	[dbo].[Promotion]
	SET		[Active] = 1
	WHERE	[PromotionID] = @PromotionID
	AND		[Active] = 0
	RETURN 	@@ROWCOUNT
END
GO           

/*
Author: Austin Gee
Date: 4/11/2020
Comment: Creating procedure for selecting an adoption application by id
*/
DROP PROCEDURE IF EXISTS [sp_select_adoption_application_by_id]
GO
print '' print '*** Creating sp_select_adoption_application_by_id'
GO
CREATE PROCEDURE [sp_select_adoption_application_by_id] 
(
	@AdoptionApplicationID [int]
)
AS
BEGIN
	SELECT
	[AdoptionApplicationID]
	,[CustomerEmail]
	,[AdoptionApplication].[AnimalID]
	,[Status]
	,[RecievedDate]
	,[AnimalName]
	,[AnimalSpeciesID]
	,[AnimalBreed]
	,[Animal].[Active]
	,[AdoptionApplication].[Active]
	FROM [AdoptionApplication]
	JOIN [Animal] ON [Animal].[AnimalID] = [AdoptionApplication].[AnimalID]
	WHERE [AdoptionApplicationID] = @AdoptionApplicationID
END
GO

/*
Created by: Ryan Morganti
Date: 2020/03/10
Comment: Stored Procedure used to select all responses associated with a particular request
*/
print '' print '*** Creating sp_select_all_responses_by_request_id'
GO
CREATE PROCEDURE [sp_select_all_responses_by_request_id]
(
	@RequestID 				[int]
)
AS
BEGIN
	SELECT [RequestResponseID], [UserID], [Response], [ResponseTimeStamp]
	FROM [RequestResponse]
	WHERE [RequestID] = @RequestID
END
GO

/*
Created by: Ryan Morganti
Date: 2020/03/16
Comment: Stored Procedure used to update a new department request to 'acknowledged'
*/
print '' print '*** Creating sp_update_department_request_acknowledged'
GO
CREATE PROCEDURE [sp_update_department_request_acknowledged]
(
	@UserID					[int],
	@DepartmentRequestID	[int]
)
AS
BEGIN
	UPDATE [DepartmentRequest]
	SET [AcknowledgingUserID] = @UserID,
		[DateAcknowledged] = GETDATE()
	WHERE [DeptRequestID] = @DepartmentRequestID
	SELECT @@ROWCOUNT
END
GO

/*
Created by: Ryan Morganti
Date: 2020/03/16
Comment: Stored Procedure used to update an acknowledged department request to 'completed'
*/
print '' print '*** Creating sp_update_department_request_complete'
GO
CREATE PROCEDURE [sp_update_department_request_complete]
(
	@UserID					[int],
	@DepartmentRequestID	[int]
)
AS
BEGIN
	UPDATE [DepartmentRequest]
	SET [CompletedUserID] = @UserID,
		[DateCompleted] = GETDATE()
	WHERE [DeptRequestID] = @DepartmentRequestID
	SELECT @@ROWCOUNT
END
GO

/*
Created by: Ryan Morganti
Date: 2020/03/18
Comment: Stored Procedure used to update a DepartmentRequest's data
*/
print '' print '*** Creating sp_update_department_request'
GO
CREATE PROCEDURE [sp_update_department_request]
(
	@UserID					[int],
	@DepartmentRequestID	[int],
	@OldRequestedGroupID    [nvarchar](50),
	@OldRequestTopic		[nvarchar](250),
	@OldRequestBody			[nvarchar](4000),
	@NewRequestedGroupID    [nvarchar](50),
	@NewRequestTopic		[nvarchar](250),
	@NewRequestBody			[nvarchar](4000)
)
AS
BEGIN
	UPDATE [DepartmentRequest]
	SET [RequestedGroupID] = @NewRequestedGroupID,
		[RequestTopic] = @NewRequestTopic,
		[RequestBody] = @NewRequestBody
	WHERE 	[DeptRequestID] = @DepartmentRequestID
	AND		[RequestingUserID] = @UserID
	AND		[RequestedGroupID] = @OldRequestedGroupID
	AND		[RequestTopic] = @OldRequestTopic
	AND		[RequestBody] = @OldRequestBody
	SELECT @@ROWCOUNT
END
GO

/*
Created by: Steven Cardona
Date: 4/8/2020
Commnet: Stored procedure to update user record
*/
DROP PROCEDURE IF EXISTS [sp_update_user]
GO
PRINT '' PRINT '*** Creating sp_update_user'
GO
CREATE PROCEDURE [sp_update_user](
	@UserID [int],
	@OldFirstName [nvarchar](50),
	@OldLastName [nvarchar](50),
	@OldPhoneNumber [nvarchar](11),
	@OldEmail [nvarchar](250),
	@OldActive [bit],
	@OldaddressLineOne [nvarchar](250),
	@OldaddressLineTwo [nvarchar](250),
	@OldCity [nvarchar] (20),
	@OldState [nvarchar] (2),
	@OldZipcode [nvarchar] (15),
	@OldHasViewedPoliciesAndStandards [bit],

	@NewFirstName [nvarchar](50),
	@NewLastName [nvarchar](50),
	@NewPhoneNumber [nvarchar](11),
	@NewEmail [nvarchar](250),
	@NewActive [bit],
	@NewaddressLineOne [nvarchar](250),
	@NewaddressLineTwo [nvarchar](250),
	@NewCity [nvarchar] (20),
	@NewState [nvarchar] (2),
	@NewZipcode [nvarchar] (15),
	@NewHasViewedPoliciesAndStandards [bit]
) 
AS
BEGIN
	UPDATE [dbo].[User]
	SET [FirstName] = @NewFirstName,
		[LastName] = @NewLastName,
		[PhoneNumber] = @NewPhoneNumber,
		[Email] = @NewEmail,
		[Active] = @NewActive,
		[addressLineOne] = @NewaddressLineOne,
		[addressLineTwo] = @NewaddressLineTwo,
		[City] = @NewCity,
		[State] = @NewState,
		[ZipCode] = @NewZipcode,
		[HasViewedPoliciesAndStandards] = @NewHasViewedPoliciesAndStandards
	WHERE [UserID] = @UserID
	AND [FirstName] = @OldFirstName
	AND [LastName] = @OldLastName
	AND [PhoneNumber] = @OldPhoneNumber
	AND [Email] = @OldEmail
	AND [Active] = @OldActive
	AND [addressLineOne] = @OldaddressLineOne
	AND [addressLineTwo] = @OldaddressLineTwo
	AND [City] = @OldCity
	AND [State] = @OldState
	AND [ZipCode] = @OldZipcode
	AND [HasViewedPoliciesAndStandards] = @OldHasViewedPoliciesAndStandards
	RETURN @@ROWCOUNT
End
GO

/*
Created by: Ryan Morganti
Date: 2020/03/19
Comment: Stored Procedure used to select all active JobListings
*/
DROP PROCEDURE IF EXISTS [sp_select_all_job_listings]
GO
print '' print '*** Creating sp_select_all_active_job_listings'
GO
CREATE PROCEDURE [sp_select_all_job_listings]
AS
BEGIN
	SELECT [JobListingID], [Position], [Benefits], [Requirements], [StartingWage], [Responsibilities], [Active]
	FROM [JobListing]
END
GO
                
/*
Created by: Chuck Baxter
Date: 4/16/2020
Comment: Updates an animal activity type record
*/
DROP PROCEDURE IF EXISTS [sp_update_animal_activity_type]
GO
print '' print '*** creating sp_update_animal_activity_type'
GO
CREATE PROCEDURE [sp_update_animal_activity_type]
(
	@OldAnimalActivityTypeID	[nvarchar](100),	
	@NewAnimalActivityTypeID	[nvarchar](100),
	@NewActivityNotes			[nvarchar](MAX)
)
AS
BEGIN
	UPDATE [dbo].[AnimalActivityType]
	SET [AnimalActivityTypeID] = @NewAnimalActivityTypeID,
		[ActivityNotes] = @NewActivityNotes
	WHERE [AnimalActivityTypeID] = @OldAnimalActivityTypeID
	RETURN @@ROWCOUNT
END
GO

/*
Created by: Chuck Baxter
Date: 3/18/2020
Comment: Sproc to delete animal activity types
*/
DROP PROCEDURE IF EXISTS [sp_delete_animal_activity_type]
GO
PRINT '' PRINT '*** creating sp_delete_animal_activity_type'
GO
CREATE PROCEDURE [sp_delete_animal_activity_type](
		@AnimalActivityTypeID [nvarchar](100)
)
AS
BEGIN
	DELETE FROM [dbo].[AnimalActivityType]
	WHERE [AnimalActivityTypeID] = @AnimalActivityTypeID
	RETURN @@ROWCOUNT
END
GO

/*
Created by: Kaleb Bachert
Date: 4/14/2020
Comment: Returns all users with specified role
*/
DROP PROCEDURE IF EXISTS [sp_select_users_by_role]
GO
PRINT '' PRINT '*** Creating sp_select_users_by_role'
GO
CREATE PROCEDURE [sp_select_users_by_role]
(
	@ERoleID		[nvarchar](50)
)
AS
BEGIN
	SELECT [User].[UserID], [Email]
	FROM [dbo].[User]
	INNER JOIN [UserERole] ON [User].[UserID] = [UserERole].[UserID]
	WHERE [ERoleID] = @ERoleID
	AND [Active] = 1
END
GO

/*
Created by: Kaleb Bachert
Date: 4/14/2020
Comment: Returns all users availability records
*/
DROP PROCEDURE IF EXISTS [sp_select_all_users_availabilities]
GO
PRINT '' PRINT '*** Creating sp_select_all_users_availabilities'
GO
CREATE PROCEDURE [sp_select_all_users_availabilities]
AS
BEGIN
	SELECT [UserID], [DayOfWeek], [StartTime], [EndTime]
	FROM [dbo].[availability]
	WHERE [Active] = 1
END
GO


/*
Created by: Chase Schulte
Date: 04/08/2020
Comment: Method to approve a specified request
*/
DROP PROCEDURE IF EXISTS [sp_approve_availability_change_request]
GO
PRINT '' PRINT '*** Creating sp_approve_availability_change_request'
GO
CREATE PROCEDURE [sp_approve_availability_change_request]
(
	@RequestID		[int],
	@UserID			[int]
)
AS
BEGIN
	UPDATE [dbo].[availabilityRequest]
	SET [ApprovingEmployeeID] = @UserID,
		[ApprovalDate] = GETDATE()
	WHERE [RequestID] = @RequestID
	AND [ApprovingEmployeeID] IS NULL
	UPDATE [dbo].[request]
	SET [Open] = 0
	WHERE [RequestID] = @RequestID
	AND [Open] = 1
	
	SELECT @@ROWCOUNT
END
GO


/*
Created by: Chase Schulte
Date: 03/28/2020
Comment: update an oldAvailability with a new Availability
*/
DROP PROCEDURE IF EXISTS [sp_update_availablity_by_id]
GO
PRINT ''  PRINT '*** Creating sp_update_availablity_by_id'
GO
CREATE PROCEDURE [sp_update_availablity_by_id]
(
	@OldAvailabilityID 	[int],
	@OldUserID			[int],
	@OldStartTime		[nvarchar](20),
	@OldEndTime			[nvarchar](20),
	@OldDayOfWeek			[nvarchar](9),

	--New rows
	@NewUserID			[int],
	@NewStartTime		[nvarchar](20),
	@NewEndTime			[nvarchar](20),
	@NewDayOfWeek			[nvarchar](9)
)
AS
BEGIN
	Update [dbo].[Availability]
	Set
	[UserID] = @NewUserID,
	[StartTime]=@NewStartTime,
	[EndTime]=@NewEndTime,
	[DayOfWeek]=@NewDayOfWeek
	Where [AvailabilityID] = @OldAvailabilityID
	And [UserID] = @OldUserID
	And [StartTime]=@OldStartTime
	And [EndTime]=@OldEndTime
	And [DayOfWeek]=@OldDayOfWeek
	Return @@ROWCOUNT
END
GO


/*
Created by: Chase Schulte
Date: 04/10/2020
Comment: deactivate a availabilities by EmpID
*/
DROP PROCEDURE IF EXISTS [sp_deactivate_availability_by_employee_id]
GO
PRINT ''  PRINT '*** Creating sp_deactivate_availability_by_employee_id '
GO
CREATE PROCEDURE [sp_deactivate_availability]
(
	@AvailabilityID	[int]
)
AS
BEGIN
	Update [dbo].[Availability]
	Set	[Active]=0
	Where [AvailabilityID] = @AvailabilityID
	Return @@ROWCOUNT
END
GO
/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: activate a eRoleID by ID
*/
DROP PROCEDURE IF EXISTS [sp_activate_availability]
GO
PRINT ''  PRINT '*** Creating sp_activate_availability '
GO
CREATE PROCEDURE [sp_activate_availability]
(
	@AvailabilityID	[int]
)
AS
BEGIN
	Update [dbo].[Availability]
	Set [Active]=1
	Where [AvailabilityID] = @AvailabilityID
	Return @@ROWCOUNT
END
GO

/*
Created by: Chase Schulte
Date: 03/27/2020
Comment: delete a availability
*/
DROP PROCEDURE IF EXISTS [sp_delete_availability]
GO
PRINT '' PRINT '*** Creating sp_delete_availability'
GO
CREATE PROCEDURE sp_delete_availability
(
    @UserID				[int]
)
AS
BEGIN
    DELETE
    FROM 	[Availability]
    WHERE 	[UserID] = @UserID
    RETURN @@ROWCOUNT
END
GO



/*
Created by: Chase Schulte
Date: 03/27/2020
Comment: select all availabilities
*/
DROP PROCEDURE IF EXISTS [sp_select_availabilties]
GO
PRINT '' PRINT '*** Creating sp_select_availabilties'
GO
GO
CREATE PROCEDURE sp_select_availabilties
(
	@UserID [int]
)
AS
BEGIN
	SELECT [AvailabilityID],[UserID],[StartTime],[EndTime],[DayOfWeek]
	FROM [dbo].[Availability]
END
GO

/*
Created by: Chase Schulte
Date: 03/27/2020
Comment: select all availabilities related to a particular user
*/
DROP PROCEDURE IF EXISTS [sp_select_availabilties_by_employee_id]
GO
PRINT '' PRINT '*** Creating sp_select_availabilties_by_employee_id'
GO
GO
CREATE PROCEDURE sp_select_availabilties_by_employee_id
(
	@UserID [int]
)
AS
BEGIN
	SELECT [AvailabilityID],[Availability].[UserID],[StartTime],[EndTime],[DayOfWeek],[FirstName],[LastName]
	FROM [dbo].[Availability]
	Join [User] On [Availability].[UserID] = [User].[UserID]
	WHERE [Availability].[UserID] = @UserID
	And [Availability].[Active] = 1
END
GO

/*
Created by: Kaleb Bachert
Date: 4/14/2020
Comment: Returns all users activeTimeOff records
*/
DROP PROCEDURE IF EXISTS [sp_select_all_users_activeTimeOff]
GO
PRINT '' PRINT '*** Creating sp_select_all_users_activeTimeOff'
GO
CREATE PROCEDURE [sp_select_all_users_activeTimeOff]
AS
BEGIN
	SELECT [UserID], [StartDate], [EndDate]
	FROM [dbo].[activeTimeOff]
END
GO

/*
Created by: Kaleb Bachert
Date: 4/14/2020
Comment: Returns all users shift records (with shiftTime information) on a specified day
*/
DROP PROCEDURE IF EXISTS [sp_select_shifts_by_day]
GO
PRINT '' PRINT '*** Creating sp_select_shifts_by_day'
GO
CREATE PROCEDURE [sp_select_shifts_by_day]
(
	@Date		[Date]
)
AS
BEGIN
	SELECT [UserID], [Date], [StartTime], [EndTime]
	FROM [dbo].[shift]
	INNER JOIN [shiftTime] ON [shift].[ShiftTimeID] = [shiftTime].[ShiftTimeID]
	WHERE [Date] = @Date
END
GO

/*
Created by: Kaleb Bachert
Date: 4/15/2020
Comment: Returns the current total hours for a User, for the week containing the specified date
*/
DROP PROCEDURE IF EXISTS [sp_select_schedule_hours_by_user_and_date]
GO
PRINT '' PRINT '*** Creating sp_select_schedule_hours_by_user_and_date'
GO
CREATE PROCEDURE [sp_select_schedule_hours_by_user_and_date]
(
	@UserID				[int],
	@DateInSchedule		[Date]
)
AS
BEGIN
	SELECT [schedule].[ScheduleID], [schedule].[StartDate], [schedule].[EndDate], [HoursFirstWeek], [HoursSecondWeek]
	FROM [dbo].[schedule]
	INNER JOIN [dbo].[ScheduleHours] ON [schedule].[ScheduleID] = [ScheduleHours].[ScheduleID]
	WHERE [ScheduleHours].[UserID] = @UserID
	AND @DateInSchedule BETWEEN [schedule].[StartDate] AND [schedule].[EndDate]
END
GO

/*
Created by: Kaleb Bachert
Date: 4/16/2020
Comment: Changes the value of the hours worked for a specified user, in a specified week, by the specified amount
*/
DROP PROCEDURE IF EXISTS [sp_update_employee_hours_worked]
GO
PRINT '' PRINT '*** Creating sp_update_employee_hours_worked'
GO
CREATE PROCEDURE [sp_update_employee_hours_worked]
(
	@UserID			[int],
	@ScheduleID		[int],
	@WeekNumber		[int],
	@ChangeAmount	[decimal]
)
AS
BEGIN
	IF (@WeekNumber = 1)
		UPDATE [ScheduleHours]
		SET [HoursFirstWeek] = [HoursFirstWeek] + @ChangeAmount
		WHERE [ScheduleID] = @ScheduleID
		AND [UserID] = @UserID
	ELSE IF (@WeekNumber = 2)
		UPDATE [ScheduleHours]
		SET [HoursSecondWeek] = [HoursSecondWeek] + @ChangeAmount
		WHERE [ScheduleID] = @ScheduleID
		AND [UserID] = @UserID
END
GO

/*
Created by: Kaleb Bachert
Date: 4/16/2020
Comment: Changes the User working on a specified shift
*/
DROP PROCEDURE IF EXISTS [sp_update_shift_user_working]
GO
PRINT '' PRINT '*** Creating sp_update_shift_user_working'
GO
CREATE PROCEDURE [sp_update_shift_user_working]
(
	@ShiftID			[int],
	@NewUserWorking		[int],
	@OldUserWorking		[int]
)
AS
BEGIN
	UPDATE [shift]
	SET [UserID] = @NewUserWorking
	WHERE [UserID] = @OldUserWorking
	AND [ShiftID] = @ShiftID
END
GO

/*
Created by: Kaleb Bachert
Date: 4/8/2020
Comment: Method to retrieve a ScheduleChangeRequest with a specified RequestID
*/
DROP PROCEDURE IF EXISTS [sp_select_schedule_change_request_by_requestid]
GO
PRINT '' PRINT '*** Creating sp_select_schedule_change_request_by_requestid'
GO
CREATE PROCEDURE [sp_select_schedule_change_request_by_requestid]
(
	@RequestID			[int]
)
AS
BEGIN
	SELECT [ScheduleChangeRequestID], [ScheduleChangeRequest].[ShiftID], [ApprovalDate], [ApprovingEmployeeID], 
		   [RequestID], [shift].[UserID], [shift].[Date], [shiftTime].[DepartmentID], 
		   [shiftTime].[StartTime], [shiftTime].[EndTime], [shift].[ERoleID]
	FROM [dbo].[scheduleChangeRequest] 
		INNER JOIN [dbo].[shift] ON [scheduleChangeRequest].[ShiftID] = [shift].[ShiftID]
		INNER JOIN [dbo].[shiftTime] ON [shift].[ShiftTimeID] = [shiftTime].[ShiftTimeID]
	WHERE [RequestID] = @RequestID
END
GO

/*
Created by: Kaleb Bachert
Date: 4/7/2020
Comment: Procedure to add a Schedule Change Request
*/
DROP PROCEDURE IF EXISTS [sp_insert_schedule_change_request]
GO
PRINT '' PRINT '*** Creating sp_insert_schedule_change_request'
GO
CREATE PROCEDURE [sp_insert_schedule_change_request]
(
	@ShiftID				[int],
	@RequestingUserID		[int]
)
AS
BEGIN
	INSERT INTO [dbo].[request]
	([RequestTypeID], [DateCreated], [RequestingUserID])
	VALUES
	('Schedule Change', GETDATE(), @RequestingUserID)

	INSERT INTO [dbo].[scheduleChangeRequest]
	([ShiftID], [RequestID])
	VALUES
	(@ShiftID, SCOPE_IDENTITY())
END
GO

/*
Created by: Kaleb Bachert
Date: 2/19/2020
Comment: Method to get all scheduled Shifts (with shiftTime information) for a User
*/
DROP PROCEDURE IF EXISTS [sp_select_shifts_by_user]
GO
PRINT '' PRINT '*** Creating sp_select_shifts_by_user'
GO
CREATE PROCEDURE [sp_select_shifts_by_user]
(
	@UserID			[int]
)
AS
BEGIN
	SELECT [ShiftID], [shift].[ShiftTimeID], [ScheduleID], 
		   [Date], [UserID], [ERoleID], 
		   [DepartmentID], [StartTime], [EndTime]
	FROM   	[dbo].[shift] INNER JOIN [dbo].[shiftTime]
	ON		[shift].[ShiftTimeID] = [shiftTime].[ShiftTimeID]
	WHERE 	[UserID] = @UserID
END
GO

/*
Created by: Kaleb Bachert
Date: 4/2/2020
Comment: Method to insert ActiveTimeOff information
*/
DROP PROCEDURE IF EXISTS [sp_insert_active_time_off]
GO
PRINT '' PRINT '*** Creating sp_insert_active_time_off'
GO
CREATE PROCEDURE [sp_insert_active_time_off]
(
	@UserID			[int],
	@StartDate		[Date],
	@EndDate		[Date]
)
AS
BEGIN
	INSERT INTO [dbo].[activeTimeOff]
	([UserID], [StartDate], [EndDate])
	VALUES
	(@UserID, @StartDate, @EndDate)
END
GO
  
/*
Created by: Kaleb Bachert
Date: 4/16/2020
Comment: Method to approve a specified request
*/
DROP PROCEDURE IF EXISTS [sp_approve_schedule_change_request]
GO
PRINT '' PRINT '*** Creating sp_approve_schedule_change_request'
GO
CREATE PROCEDURE [sp_approve_schedule_change_request]
(
	@RequestID		[int],
	@UserID			[int]
)
AS
BEGIN
	UPDATE [dbo].[scheduleChangeRequest]
	SET [ApprovingEmployeeID] = @UserID,
		[ApprovalDate] = GETDATE()
	WHERE [RequestID] = @RequestID
	AND [ApprovingEmployeeID] IS NULL

	UPDATE [dbo].[request]
	SET [Open] = 0
	WHERE [RequestID] = @RequestID
	AND [Open] = 1
	
	SELECT @@ROWCOUNT
END
GO  

/*
Created by: Thomas Dupuy
Date: 4/12/2020
Comment: Stored procedure to select all active appointments.
*/
DROP PROCEDURE IF EXISTS [sp_select_all_appointments_by_active]
GO
PRINT '' PRINT '*** Creating sp_select_all_appointments_by_active'
GO
CREATE PROCEDURE [sp_select_all_appointments_by_active]
AS
BEGIN
	SELECT
	[Appointment].[AppointmentID],
	[Appointment].[AdoptionApplicationID],
	[Appointment].[AppointmentTypeID],
	[Appointment].[DateTime],
	[Appointment].[Notes],
	[Appointment].[Decision],
	[Appointment].[LocationID],
	[Appointment].[Active],
	[Location].[Name],
	[Location].[Address1],
	[Location].[Address2],
	[Location].[City],
	[Location].[State],
	[Location].[Zip]
	FROM [Appointment]
	JOIN [Location] ON [Appointment].[LocationID] = [Location].[LocationID]
	ORDER BY [Appointment].[DateTime] DESC
END
GO

/*
Created by: Thomas Dupuy
Date: 4/12/2020
Comment: Stored procedure to select an appointment by its appointment id
*/
DROP PROCEDURE IF EXISTS [sp_select_appointment_by_appointment_id]
GO
PRINT '' PRINT '*** creating sp_select_appointment_by_appointment_id'
GO
CREATE PROCEDURE [sp_select_appointment_by_appointment_id]
(
	@AppointmentID [int]
)
AS
BEGIN
	SELECT
		[AdoptionApplicationID]
		,[AppointmentTypeID]
		,[DateTime]
		,[Notes]
		,[Decision]
		,[LocationID]
		,[Active]
	FROM [dbo].[Appointment]
	WHERE [AppointmentID] = @AppointmentID
END
GO

/*
Created by: Thomas Dupuy
Date: 4/12/2020
Comment: Stored procedure to deactivate an appointment by its id
*/
DROP PROCEDURE IF EXISTS [sp_deactivate_appointment]
GO
PRINT '' PRINT '*** creating sp_deactivate_appointment'
GO
CREATE PROCEDURE [sp_deactivate_appointment]
(
	@AppointmentID			[int]
)
AS
BEGIN
	UPDATE [dbo].[Appointment]
	SET 	[Active] = 0
			
	WHERE	[AppointmentID]	= @AppointmentID
	RETURN @@ROWCOUNT
END
GO

/*
Created by: Thomas Dupuy
Date: 4/15/2020
Comment: Stored procedure to update an appointment by its id
*/
DROP PROCEDURE IF EXISTS [sp_update_appointment]
GO
PRINT '' PRINT '*** creating sp_update_appointment'
GO
CREATE PROCEDURE [sp_update_appointment]
(
	@AppointmentID			[int],
	
	@OldAdoptionApplicationID	[int],
	@OldAppointmentTypeID		[nvarchar](100),
	@OldDateTime				[datetime],
	@OldNotes					[nvarchar](1000),
	@OldDecision				[nvarchar](50),
	@OldLocationID				[int],
	@OldActive					[bit],
	
	@NewAdoptionApplicationID	[int],
	@NewAppointmentTypeID		[nvarchar](100),
	@NewDateTime				[datetime],
	@NewNotes					[nvarchar](1000),
	@NewDecision				[nvarchar](50),
	@NewLocationID				[int],
	@NewActive					[bit]
)
AS
BEGIN
	UPDATE [dbo].[Appointment]
	SET		[AdoptionApplicationID] = @NewAdoptionApplicationID,
			[AppointmentTypeID] = @NewAppointmentTypeID,
			[DateTime] = @NewDateTime,
			[Notes] = @NewNotes,
			[LocationID] = @NewLocationID,
			[Active] = @NewActive
			
	WHERE	[AppointmentID]	= @AppointmentID
	AND		[AdoptionApplicationID] = @OldAdoptionApplicationID
	AND		[AppointmentTypeID] = @OldAppointmentTypeID
	AND		[DateTime] = @OldDateTime
	AND		[Notes] = @OldNotes
	AND		[LocationID] = @OldLocationID
	AND		[Active] = @OldActive
	RETURN @@ROWCOUNT
END
GO




/*
Created by: Daulton Schilling
Date: 4/14/2020
Comment: Stored procedure to select all the animal names
*/
CREATE PROCEDURE [sp_select_Names]

AS
BEGIN
SELECT 

[AnimalName] ,
[AnimalID]

From [Animal]

END;

GO


INSERT INTO [dbo].[Item]
	([ItemCategoryID],[ItemName],[ItemQuantity])
	VALUES
	('Medication','Medication1', 4),
	('Medication','Medication2', 0)
	
GO

/*
Created by: Daulton Schilling
Date: 4/14/2020
Comment: Stored procedure to select an animal's medical history by it's ID
*/
CREATE PROCEDURE [sp_Select_AnimalMedicalHistory_By_AnimalID]
(
  @AnimalID [int]
)
AS
BEGIN
    SELECT 
        Animal.AnimalID,
        Animal.AnimalName, 
        Animal.AnimalSpeciesID,	 			
        AnimalMedicalInfo.Vaccinations,
        AnimalMedicalInfo.SpayedNeutered,	
        AnimalMedicalInfo.MostRecentVaccinationDate,	
        AnimalMedicalInfo.AdditionalNotes	
    FROM
    [Animal] 
    INNER JOIN 
    AnimalHandlingNotes
    ON AnimalHandlingNotes.AnimalID = Animal.AnimalID
    INNER JOIN 
    AnimalMedicalInfo
    ON
    AnimalMedicalInfo.AnimalID = Animal.AnimalID

    WHERE Animal.AnimalID = @AnimalID
    AND 
    AnimalHandlingNotes.AnimalID = @AnimalID
    AND 
    AnimalMedicalInfo.AnimalID = @AnimalID
END;
GO



/*
 * Created by: Daulton Schilling
 * Date: 4/12/2020
 * Comment: SP to create a new outgoing order
 */

CREATE PROCEDURE [SP_Create_OutgoingOrder]
(
	@ItemID 						[int],
	@OrderDate						[DateTime],
	@ItemQuantity					[int],
	@ItemCategoryID					[nvarchar](4000),
	@UserID							[int]
	
)
AS
BEGIN
    INSERT INTO [OutgoingOrders]
        ([ItemID], [OrderDate], [ItemQuantity],
        [ItemCategoryID],[UserID])
    VALUES
         (@ItemID, @OrderDate, @ItemQuantity,
        @ItemCategoryID,@UserID)
	
END
GO

/*
 * Created by: Daulton Schilling
 * Date: 4/12/2020
 * Comment: SP to update animal medical history
 */

CREATE PROCEDURE [SP_Update_Animal_Medical_History]
(
		@AnimalID [int],
		
        @NewVaccinations [nvarchar](100),
        @NewSpayedNeutered [bit],	
        @NewMostRecentVaccinationDate [date],	
        @NewAdditionalNotes [nvarchar](100),
		
		@OldVaccinations [nvarchar](100),
        @OldSpayedNeutered [bit],	
        @OldMostRecentVaccinationDate [date],	
        @OldAdditionalNotes [nvarchar](100)
		
)
AS
BEGIN
	
	UPDATE [dbo].[AnimalMedicalInfo]
	
    SET   
		 Vaccinations              = @NewVaccinations,
         SpayedNeutered            = @NewSpayedNeutered,
         MostRecentVaccinationDate = @NewMostRecentVaccinationDate,
		 AdditionalNotes           = @NewAdditionalNotes
		 
 
    FROM
    [Animal] 
    INNER JOIN 
    AnimalMedicalInfo
    ON
    AnimalMedicalInfo.AnimalID = Animal.AnimalID

		
    WHERE   
	Animal.AnimalID = @AnimalID

END;
GO

/*
Created by: Ethan Holmes
Date: 04/09/2020
Comment: Table to store customer errors


*/
DROP TABLE IF EXISTS [dbo].[CustomerErrors]
GO
PRINT '' PRINT '*** Creating table CustomerErrors'
GO
CREATE TABLE [dbo].[CustomerErrors](
	[ErrorID] 			[int] IDENTITY(1000000,1) 	NOT NULL,
	[ErrorType]			[nvarchar](100)				NOT NULL,
	[Description]		[nvarchar](1000)					,
	CONSTRAINT [pk_ErrorID] PRIMARY KEY([ErrorID] ASC)
)
GO

/*
Created by: Ethan Holmes
Date: 04/09/2020
Comment: Sample CustomerErrors data
*/
print '' print '*** Inserting Sample data for CustomerErrors'
GO
INSERT INTO [dbo].[CustomerErrors]
		([ErrorType],[Description])
	VALUES
		('ErrorType1', 'THIS IS A DESCRIPTION OF AN ERROR 1'),
		('ErrorType2', 'THIS IS A DESCRIPTION OF AN ERROR 2'),
		('ErrorType3', 'THIS IS A DESCRIPTION OF AN ERROR 3')
GO

/*
Created by: Ethan Holmes
Date: 04/09/2020
Comment: Stored Procedure to insert a Customer Error intot he CustomerErrors table.
*/
print '' print '*** Creating sp_insert_customer_error'
GO
CREATE PROCEDURE [sp_insert_customer_error]
(
	@ErrorType			[nvarchar](100),
	@Description		[nvarchar](1000)
)
AS 
BEGIN
	INSERT INTO [dbo].[CustomerErrors]
			([ErrorType], [Description])
		VALUES
			(@ErrorType, @Description)
	  
		RETURN @@ROWCOUNT
END
GO

/*
Created by: Ethan Holmes
Date: 04/09/2020
Comment: Table to store customer credit cards


*/
DROP TABLE IF EXISTS [dbo].[PoSCreditCards]
GO
PRINT '' PRINT '*** Creating table PoSCreditCards'
GO
CREATE TABLE [dbo].[PoSCreditCards](
	[CCID] 				[int] IDENTITY(1000000,1) 	NOT NULL,
	[CardType]			[nvarchar](100)				NOT NULL,
	[CardNumber]		[nvarchar](100)						,
	[SecurityCode]		[nvarchar](25)						,
	CONSTRAINT [pk_CCID] PRIMARY KEY([CCID] ASC)
)
GO

/*
Created by: Ethan Holmes
Date: 04/09/2020
Comment: Sample Customer Credit Cards
*/
print '' print '*** Inserting Sample data for PoSCreditCards'
GO
INSERT INTO [dbo].[PoSCreditCards]
		([CardType],[CardNumber], [SecurityCode])
	VALUES
		('Visa', '12323232323232323', '214'),
		('MasterCard', 'XY3LL 2222 FJFJ 22K2', '442'),
		('Chase', '2345 JJJJ FFII JK23 FDFF', '123')
GO

/*
Created by: Ethan Holmes
Date: 04/09/2020
Comment: Stored Procedure to insert a Credit Card
*/
print '' print '*** Creating sp_add_credit_card'
GO
CREATE PROCEDURE [sp_add_credit_card]
(
	@CardType			[nvarchar](100),
	@CardNumber			[nvarchar](100),
	@SecurityCode		[nvarchar](25)
)
AS 
BEGIN
	INSERT INTO [dbo].[PoSCreditCards]
			([CardType],[CardNumber], [SecurityCode])
		VALUES
			(@CardType, @CardNumber, @SecurityCode)
	  
		RETURN @@ROWCOUNT
END
GO

/*
Created by: Ethan Holmes
Date: 04/09/2020
Comment: Stored Procedure to return all cards
*/
print '' print '*** Creating sp_get_all_credit_cards'
GO
CREATE PROCEDURE [sp_get_all_credit_cards]
AS 
BEGIN
	SELECT [CardType], [CardNumber]
	FROM [dbo].[PoSCreditCards]
END
GO

/*
Created by: Ethan Holmes
Date: 04/09/2020
Comment: Stored Procedure to Remove A card
*/
print '' print '*** Creating sp_delete_credit_card'
GO
CREATE PROCEDURE [sp_delete_credit_card]
(
	@CardNumber [nvarchar](100)
)
AS 
BEGIN
	DELETE FROM [dbo].[PoSCreditCards]
	WHERE @CardNumber = [CardNumber]
END
GO

/*
Created by: Zach Behrensmeyer
Date: 4/17/2020
Comment: This is used to view all customers
*/
DROP PROCEDURE IF EXISTS [sp_select_all_active_customers]
GO
PRINT '' PRINT '** Create sp_select_all_active_customers'
GO
CREATE PROCEDURE [sp_select_all_active_customers]
AS
BEGIN
    SELECT
        [Email],
        [FirstName],
        [LastName], 
        [PhoneNumber],        
        [addressLineOne],
        [addressLineTwo],
        [City],
        [State],
        [Zipcode],
		[Active]
    FROM [dbo].[Customer]
    Where [Active] = 1
END
GO

/*
Author: Lane Sandburg
Date: 04/02/2020
Comment: Creating procedure for inserting employee availability
*/
print '' print '*** Creating sp_insert_availability'
GO
CREATE PROCEDURE [sp_insert_availability] (
	
	@UserID 				[int],
	@DayOfWeek					[Nvarchar](9),
	@StartTime 					[nvarchar](300),
	@EndTime 					[nvarchar](500)
)
AS
BEGIN

	insert into [dbo].[Availability]
	([UserID], [DayOfWeek], [StartTime],[EndTime])
	values
	(@UserID, @DayOfWeek, @StartTime,@EndTime)
END
GO

/*
Author: Lane Sandburg
Date: 04/09/2020
Comment: Creating procedure for selecting the last created employeeID
*/
print '' print '*** Creating sp_Select_Last_UserID'
GO
CREATE PROCEDURE [sp_Select_Last_UserID]
AS
BEGIN

	SELECT MAX(UserID) FROM [User]
END
GO

/*
Author: Lane Sandburg
Date: 04/09/2020
Comment: Creating procedure for selecting all availability for selected user
*/
DROP PROCEDURE IF EXISTS [sp_select_all_user_availability_by_userID]
GO
PRINT '' PRINT '*** Creating sp_select_all_user_availability_by_userID'
GO
CREATE PROCEDURE [sp_select_all_user_availability_by_userID]
(
	@UserID 			[int]
)
AS
BEGIN
	SELECT	[AvailabilityID],			
			[UserID],				
			[DayOfWeek],			    
			[StartTime],				
			[EndTime],				
			[Active]			
	FROM [Availability]
	WHERE [UserID] = @UserID
	ORDER BY[DayOfWeek]
END
GO

/*
CREATED BY: Matt Deaton
DATE: 2020-04-07
COMMENT: Stored Procedure to insert a foster applicant.
*/
DROP PROCEDURE IF EXISTS [sp_insert_foster_applicant]
GO
PRINT '' PRINT '*** Creating sp_insert_foster_applicant'
GO
CREATE PROCEDURE [sp_insert_foster_applicant]
(
	@FirstName				[nvarchar](50),
	@LastName				[nvarchar](50),		
	@MiddleName				[nvarchar](50) = NULL,
	@Email					[nvarchar](250),		
	@PhoneNumber			[nvarchar](11),	
	@AddressLine1			[nvarchar](100),		
	@AddressLine2			[nvarchar](100) = NULL,		
	@City					[nvarchar](100),		
	@State					[char](2),			
	@ZipCode				[nvarchar](12),
	@Foster					[bit]			
) 
AS
BEGIN
	INSERT INTO [dbo].[Applicant]
		([FirstName], [LastName], [MiddleName],		
			[Email], [PhoneNumber], [AddressLine1], [AddressLine2],			
			[City], [State], [ZipCode], [Foster])
	VALUES
		(@FirstName, @LastName, @MiddleName,
			@Email, @PhoneNumber, @AddressLine1, @AddressLine2,
			@City, @State, @ZipCode, @Foster)
END
GO

/*
CREATED BY: Matt Deaton
DATE: 2020-04-07
COMMENT: Stored Procedure to select an applicant by the applicantID
*/
DROP PROCEDURE IF EXISTS [sp_select_applicant_by_id]
GO
PRINT '' PRINT '*** Creating sp_select_applicant_by_id'
GO
CREATE PROCEDURE [sp_select_applicant_by_id]
(
	@ApplicantID 		[int]
)
AS	
BEGIN
	SELECT 	[ApplicantID], [FirstName], [LastName], [MiddleName],
			[Email], [PhoneNumber], [AddressLine1], [AddressLine2],
			[City], [State], [ZipCode], [Foster]
	FROM	[dbo].[Applicant]
	WHERE	[ApplicantID] = @ApplicantID
END
GO

/*
CREATED BY: Matt Deaton
DATE: 2020-04-07
COMMENT: Stored Procedure to delete an applicant by the applicantID
*/

DROP PROCEDURE IF EXISTS [sp_select_applicant_for_interview]
GO
PRINT '' PRINT '*** Creating sp_select_applicant_for_interview'
GO
CREATE PROCEDURE [sp_select_applicant_for_interview]
(
	@ApplicantID			[int]
)
AS
BEGIN
	SELECT
	[Applicant].[ApplicantID],
	[Applicant].[FirstName],
	[Applicant].[LastName],
	[Applicant].[MiddleName],
	[Applicant].[Email],
	[Applicant].[PhoneNumber],
	[Applicant].[AddressLine1],
	[Applicant].[AddressLine2],
	[Applicant].[City],
	[Applicant].[State],
	[Applicant].[ZipCode],
	[JobListing].[Position],
	[ApplicationEducation].[SchoolName],
	[ApplicationEducation].[City],
	[ApplicationEducation].[State],
	[ApplicationEducation].[LevelAchieved],
	[ApplicationReference].[ReferenceID],
	[ApplicationReference].[Relationship],
	[ApplicationReference].[PhoneNumber],
	[ApplicationReference].[EmailAddress],
	[Application].[Status],
	[ApplicationResume].[FilePath],
	[Interview].[Notes],
	[ApplicationSkill].[Description],
	[PreviousExperience].[PreviousWorkName],
	[PreviousExperience].[City],
	[PreviousExperience].[State],
	[PreviousExperience].[Type],
	[Application].[ApplicationID],
	[HomeCheck].[DatePerformed]
	FROM [Applicant] JOIN [Application] ON [Application].[ApplicantID] = [Applicant].[ApplicantID]
	JOIN [JobListing] ON [Application].[JobListingID] = [JobListing].[JobListingID]
	JOIN [ApplicationEducation] ON [ApplicationEducation].[ApplicationID] = [Application].[ApplicationID]
	JOIN [ApplicationReference] ON [ApplicationReference].[ApplicationID] = [Application].[ApplicationID]
	JOIN [ApplicationResume] ON [ApplicationResume].[ApplicationID] = [Application].[ApplicationID]
	JOIN [Interview] ON [Interview].[ApplicationID] = [Application].[ApplicationID]
	JOIN [ApplicationSkill] ON [ApplicationSkill].[ApplicationID] = [Application].[ApplicationID]
	JOIN [PreviousExperience] ON [PreviousExperience].[ApplicationID] = [Application].[ApplicationID]
	JOIN [HomeCheck] ON [HomeCheck].[ApplicationID] = [Application].[ApplicationID]
	WHERE [Applicant].[ApplicantID] = @ApplicantID
END
GO

/*
CREATED BY: Matt Deaton
DATE: 2020-04-07
COMMENT: Stored Procedure to update interview using the ApplicationID
*/
DROP PROCEDURE IF EXISTS [sp_update_interview_notes]
GO
PRINT '' PRINT '*** Creating sp_update_interview_notes'
GO
CREATE PROCEDURE [sp_update_interview_notes]
(
	@ApplicationID 		[int],
	@OldNotes			[nvarchar](1000),
	@NewNotes			[nvarchar](1000)
)
AS
BEGIN
	UPDATE [dbo].[Interview]
	SET [Notes] = @NewNotes
	WHERE [ApplicationID] = @ApplicationID
	AND [Notes] = @OldNotes
	RETURN @@ROWCOUNT
END
GO

/*
CREATED BY: Matt Deaton
DATE: 2020-04-07
COMMENT: Stored Procedure to update application status using the ApplicationID
*/
DROP PROCEDURE IF EXISTS [sp_update_application_status]
GO
PRINT '' PRINT '*** Creating sp_update_application_status'
GO
CREATE PROCEDURE [sp_update_application_status]
(
	@ApplicationID 		[int],
	@OldStatus			[nvarchar](1000),
	@NewStatus			[nvarchar](1000)
)
AS
BEGIN
	UPDATE [dbo].[Application]
	SET [Status] = @NewStatus
	WHERE [ApplicationID] = @ApplicationID
	AND [Status] = @OldStatus
	RETURN @@ROWCOUNT
END
GO

/*
CREATED BY: Matt Deaton
DATE: 2020-04-07
COMMENT: Stored Procedure to update home check date using the ApplicationID
*/
DROP PROCEDURE IF EXISTS [sp_update_home_check_date]
GO
PRINT '' PRINT '*** Creating sp_update_home_check_date'
GO
CREATE PROCEDURE [sp_update_home_check_date]
(
	@ApplicationID 				[int],
	@OldHomeCheckDate			[datetime],
	@NewHomeCheckDate			[datetime]
)
AS
BEGIN
	UPDATE [dbo].[HomeCheck]
	SET [DatePerformed] = @NewHomeCheckDate
	WHERE [ApplicationID] = @ApplicationID
	AND [DatePerformed] = @OldHomeCheckDate
	RETURN @@ROWCOUNT
END
GO

/*
CREATED BY: Zach Behrensmeyer
DATE: 4/23/2020
COMMENT: Stored Procedure to update Password
*/
DROP PROCEDURE IF EXISTS [sp_update_password]
print '' print '*** Creating sp_update_password'
GO
CREATE Procedure sp_update_user_password
(
@UserID 	[int],
@OldPasswordHash	[nvarchar](100),
@NewPasswordHash	[nvarchar](100)             
)
AS
BEGIN
UPDATE [dbo].[User]
SET [PasswordHash] = @NewPasswordHash
Where [UserID] = @UserID
AND [PasswordHash] = @OldPasswordHash
Return @@ROWCOUNT
END
GO

/*
Created by: Austin Gee
Date: 4/21/2020
Comment: This deactivates an adoption application
*/
DROP PROCEDURE IF EXISTS [sp_deactivate_adoption_application]
GO
PRINT '' PRINT '** Create sp_deactivate_adoption_application'
GO
CREATE PROCEDURE [sp_deactivate_adoption_application]
(
	@AdoptionApplicationID [int]
)
AS
BEGIN
    UPDATE [dbo].[AdoptionApplication]
    SET [Active] = 0
    Where [AdoptionApplicationID] = @AdoptionApplicationID
END
GO

/*
Created By: Robert Holmes
Date: 04/29/2020
Comment: Inserts a picture
*/
print '' print '*** Creating sp_insert_picture'
GO
DROP PROCEDURE IF EXISTS [sp_insert_picture]
GO
CREATE PROCEDURE [sp_insert_picture]
(
	@ProductID 			[nvarchar](13),
	@PictureData		[varbinary](MAX),
	@PictureMimeType	[nvarchar](50)
)
AS
BEGIN
	INSERT INTO [dbo].[Picture]
	([ProductID], [PictureData], [PictureMimeType])
	VALUES
	(@ProductID, @PictureData, @PictureMimeType)
END
GO

/*
Created by: Robert Holmes
Date: 04/30/2020
Comment: Selects all pictures by product id
*/
print '' print '*** Creating sp_select_all_pictures_by_product_id'
GO
DROP PROCEDURE IF EXISTS [sp_select_all_pictures_by_product_id]
GO
CREATE PROCEDURE [sp_select_all_pictures_by_product_id]
(
	@ProductID	[nvarchar](13)
)
AS
BEGIN
	SELECT [PictureID], [ProductID], [PictureData], [PictureMimeType]
	FROM [dbo].[Picture]
	WHERE [ProductID] = @ProductID
END
GO

/*
 ******************************* Inserting Sample Data *****************************
*/
PRINT '' PRINT '******************* Inserting Sample Data *********************'
GO


print '' print '*** Creating sample Department records'
GO

/*
 * Created by: Jordan Lindo
 * Date: 2/5/2020
 * Comment: This is Sample data for the department table.
 */
INSERT INTO [dbo].[department]
([DepartmentID],[Description])
VALUES
     ('Fake1','A Description')
    ,('Fake2','Another Description')    
    ,('Fake3','Yet Another Description')
    ,('Fake4',NULL)
	,('Management','')
	,('Sales','Sales Department')
	,('Stockroom','')
GO

/*
Created by: Zach Behrensmeyer
Date: 2/3/2020
Comment: Inserts some test users
*/
PRINT '' PRINT '*** Insert Into User Table ***'
GO
INSERT INTO [dbo].[User]
	([FirstName],
	[LastName],
	[PhoneNumber],
	[Email],
	[City],
	[State],
	[Zipcode],
	[addressLineOne],
	[addressLineTwo]
)
VALUES
	('Zach', 'Behrensmeyer', '1234567890', 'zbehrens@PetUniverse.com', 'Cedar Rapids','IA','52433','J street NE','APT3'),
	('Steven', 'Cardona', '2234567890', 'scardona@PetUniverse.com', 'Cedar Rapids','IA','52433','J street NE','APT3'),
	('Thomas', 'Dupuy', '3234567890', 'tdupuy@PetUniverse.com', 'Cedar Rapids','IA','52433','J street NE','APT3'),
	('Mohamed','Elamin' ,'3198376522','moals@PetUniverse.com','Cedar Rapids','IA','52433','J street NE','APT3'),
	('Austin','Gee','1234567890','Austin@email.com','Cedar Rapids','IA','52404','J street NE','APT3'),
	('Bill','Buffalo','1234567890','Bill@email.com','Cedar Rapids','IA','52404','J street NE', null),
	('Brad','Bean','1234567890','Brad@email.com','Iowa City','IA','52404','J street NE','APT3'),
	('Barb','Brinoll','1234567890','Barb@email.com','Cedar Rapids','IA','52404','J street NE',null),
	('Awaab','Elamin','3192104964','Awaab@Awaaab.com','Cedar Rapids','IA','52404','J street NE','APT3'),
	('Ryan', 'Morganti', '5554443333', 'ryanm@PetUniverse.com', 'Cedar Rapids', 'IA', '52402','J street NE','APT3'),
	('Derek', 'Taylor', '9992234343', 'derekt@PetUniverse.com', 'Manchester', 'IA', '524404','J street NE','APT3'),
	('Steven', 'Coonrod', '9992555343', 'stevec@PetUniverse.com', 'Hiawatha', 'IA', '524409','J street NE','APT3')
GO

/*
Created by: Zach Behrensmeyer
Date: 2/3/2020
Comment: Inserts some test users
*/
PRINT '' PRINT '*** Insert Into User Table ***'
GO
INSERT INTO [dbo].[Customer]
	([FirstName],
	[LastName],
	[PhoneNumber],
	[Email],
	[City],
	[State],
	[Zipcode],
	[addressLineOne],
	[addressLineTwo]
)
VALUES
	('Zach', 'Behrensmeyer', '1234567890', 'zbehrens@PetUniverse.com', 'Cedar Rapids','IA','52433','J street NE','APT3'),
	('Steven', 'Cardona', '2234567890', 'scardona@PetUniverse.com', 'Cedar Rapids','IA','52433','J street NE','APT3'),
	('Thomas', 'Dupuy', '3234567890', 'tdupuy@PetUniverse.com', 'Cedar Rapids','IA','52433','J street NE','APT3'),
	('Mohamed','Elamin' ,'3198376522','moals@PetUniverse.com','Cedar Rapids','IA','52433','J street NE','APT3'),
	('Austin','Gee','1234567890','Austin@email.com','Cedar Rapids','IA','52404','J street NE','APT3'),
	('Bill','Buffalo','1234567890','Bill@email.com','Cedar Rapids','IA','52404','J street NE', null),
	('Brad','Bean','1234567890','Brad@email.com','Iowa City','IA','52404','J street NE','APT3'),
	('Barb','Brinoll','1234567890','Barb@email.com','Cedar Rapids','IA','52404','J street NE',null),
	('Awaab','Elamin','3192104964','Awaab@Awaaab.com','Cedar Rapids','IA','52404','J street NE','APT3'),
	('Ryan', 'Morganti', '5554443333', 'ryanm@PetUniverse.com', 'Cedar Rapids', 'IA', '52402','J street NE','APT3'),
	('Derek', 'Taylor', '9992234343', 'derekt@PetUniverse.com', 'Manchester', 'IA', '524404','J street NE','APT3'),
	('Steven', 'Coonrod', '9992555343', 'stevec@PetUniverse.com', 'Hiawatha', 'IA', '524409','J street NE','APT3')
GO



/*
Created by: Zach Behrensmeyer
Date: 2/6/2020
Comment: This is used to pair a user with their roles
*/
print '' print '*** Insert Into ERole Table ***'
GO
INSERT INTO [dbo].[ERole]
(
	[ERoleID], [DepartmentID]
)
VALUES
	('Admin', 'Management'),
	('Customer', 'Sales'),
	('Volunteer', 'Fake1')
GO

/*
Created by: Zach Behrensmeyer
Date: 2/6/2020
Comment: This is used to pair a user with their roles
*/
PRINT '' PRINT '*** Insert Into User Role Table ***'
GO
INSERT INTO [dbo].[UserERole]
([UserID],  
[ERoleID]
)
VALUES
(100000, 'Admin'),
(100001, 'Customer'), 
(100002, 'Volunteer'),
(100002, 'Admin')
GO

/*
Created by: Austin Gee
Date: 2/21/2020
Comment: This adds AnimalSpecies records to the AnimalSpecies table.
*/
print '' print '*** Creating Sample AnimalSpecies Records'
GO
INSERT INTO [dbo].[AnimalSpecies]
	([AnimalSpeciesID],[Description])
	VALUES
	('Dog','This is a dog'),
	('Cat','Your commmon house cat'),
	('Rat','The fancy rat')
GO

/*
Created by: Chuck Baxter
Date: 2/8/2020
Comment: Sample Data
*/
INSERT INTO [dbo].[Status]
	([StatusID])
	VALUES
	('A'),
	('B'),
	('C'),
	('D')
GO

/*
Created by: Chuck Baxter
Date: 2/8/2020
Comment: Sample Animal Data
*/
print '' print '*** Creating sample Animal records'
GO
INSERT INTO [dbo].[Animal]
	([AnimalName],[Dob],[AnimalBreed],[ArrivalDate],[CurrentlyHoused],[Adoptable],[Active],[AnimalSpeciesID])
	VALUES
	('Paul','12-01-2015','Pit Bull','03-20-2020',1,1,1,'Cat'),
	('Snowball II','10-05-2011','Tabby','11-24-2019',0,0,1,'Cat'),
	('Lassie','04-23-2018','Collie','02-17-2020',1,1,1,'Dog'),
	('Spot','08-14-2014','French Bulldog','05-10-2019',1,1,1,'Dog'),
	('fluffs','06-21-2012','Siamese','04-11-2020',0,1,1,'Rat'),
	('Doggo','03-06-2015','Shih Tzu','02-22-2019',1,1,0,'Dog')
GO

/*
Created by: Ethan Murphy
Date: 2/7/2020
Comment: Inserts sample animal vet appointment records
*/
print '' print '*** creating sample vet appointment records'
GO
INSERT INTO [dbo].[AnimalVetAppointment]
	([AnimalID], [AppointmentDate], [AppointmentDescription],
	[ClinicAddress], [VetName], [FollowUpDate], [UserID])
	VALUES
	(1000000, '2020-02-02 2:00PM', 'test', '1234 Test', 'test', '2020-02-02 4:00PM', 100000),
	(1000001, '2020-02-10 4:00PM', 'test2', '4321 Test2', 'test2', null, 100000),
	(1000002, '2020-02-15 1:00PM', 'test3', '1234 Test3', 'test3', '2020-02-20 1:00PM', 100000)
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Sample Data for AnimalActivityType
*/
print '' print '*** Creating sample AnimalActivityType records'
GO
INSERT INTO [dbo].[AnimalActivityType]
	  ([AnimalActivityTypeID],[ActivityNotes])
VALUES
	('Feeding','Feed the Animals'),
	('Playing', 'Record of when an animal was played with'),
	('Grooming', 'Record of when an animal was played with')
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Sample Data for AnimalActivity Records
*/
print '' print '*** Creating sample AnimalActivity records'
GO
INSERT INTO [dbo].[AnimalActivity]
	 ([AnimalID],[AnimalActivityTypeID],[ActivityDateTime],[UserID], [Description])
VALUES
    (1000000,'Feeding', '2020-02-02', 100000, 'test'),
	(1000001,'Playing', '2020-01-02', 100000, 'test2'),
	(1000000,'Playing', '2020-06-02', 100000, 'test3'),
	(1000001,'Feeding', '2020-05-02', 100000, 'test4'),
	(1000002,'Playing', '2020-04-10', 100000, 'test5')
GO

/*
Created by: Ben Hanna
Date: 2/18/2020
Comment: Sample animal handling notes record
*/                
print '' print '*** Creating Sample Animal Handling Records'
GO
INSERT INTO [dbo].[AnimalHandlingNotes]
	([AnimalID], [AnimalHandlingNotes], [TemperamentWarning], [UpdateDate], [UserID] 
    )
	VALUES
	(1000000,
     'test test test', 'hubba hubba', '2020-01-22', 
     100000)
GO

/*
Created by: Ben Hanna
Date: 3/12/2020
Comment: Sample animal kennel records
*/                
print '' print '*** Creating Sample Animal Kennel Records'
GO
INSERT INTO [dbo].[AnimalKennel]
	([AnimalID],				
	[UserID],				
	[AnimalKennelInfo],		
	[AnimalKennelDateIn],	
	[AnimalKennelDateOut]
    )
	VALUES
	(1000000, 100000, 'test test test', '2020-01-22', '2020-02-22'),
    (1000001, 100000, 'test test test 2', '2020-01-22', '2020-02-22')
GO

/*
Sample ShiftTime Data

Author: Lane Sandburg
2/5/2020

*/
print '' print '*** creating sample ShiftTime records'
GO
INSERT INTO [dbo].[ShiftTime]
([DepartmentID],[StartTime],[EndTime])
VALUES
    ('Fake1','14:00:00','22:00:00'),
    ('Fake2','08:45:00','17:45:00'),
    ('Fake3','14:00:00','22:00:00'),
    ('Fake4','08:45:00','17:45:00')
GO

/*
More shift times

Author: Jordan Lindo
3/26/2020
*/

print '' print '*** creating more sample ShiftTime records'
GO
INSERT INTO [dbo].[ShiftTime]
([DepartmentID],[StartTime],[EndTime])
VALUES
	('Management','06:00:00','12:30:00'),
	('Management','10:00:00','16:30:00'),
	('Management','14:00:00','22:30:00'),
	('Sales','06:00:00','12:30:00'),
	('Sales','10:00:00','16:30:00'),
	('Sales','14:00:00','22:30:00')
GO


/*
Created by: Awaab Elamin
Date: 3/5/2020
Comment: Adds adoption appliacation records to the AdoptionApplication table.
Note: 'Awaab' is only one who filled the questionnair!
Updated by Awaab Elamin
Date: 3/16/2020
Comment: Close sample data that conflict with customer Email
Note: update happend after customerId changed to CUstomerEmail
Updated by: Mohamed Elamin , 2020/03/30 
Comment: Add sample data. 
*/
GO
print '' print '*** Creating Sample AdoptionApplication Records'
GO
INSERT INTO [dbo].[AdoptionApplication]
	([CustomerEmail],[AnimalID],[Status],[RecievedDate])
	VALUES	
	('Awaab@Awaaab.com',(SELECT [AnimalID]FROM[dbo].[Animal]WHERE [Animal].[AnimalName] = 'Paul'),'Reviewer','2020-01-01'),
	('moals@PetUniverse.com',1000001,'InHomeInspection','2019-10-9'),
	('scardona@PetUniverse.com',1000002,'Interviewer','2019-10-9'),
	('tdupuy@PetUniverse.com',1000003,'InHomeInspection','2019-10-9'),	
	('Austin@email.com',1000004,'InHomeInspection ','2019-10-9')
GO



print '' print '*** Creating Sample Location Records'
GO
INSERT INTO [dbo].[Location]
	([Name],[Address1],[Address2],[City],[State],[Zip])
	VALUES
	('Shelter','123 here we go lane',null,'Good Town','ST','12345'),
	('Kirkwood','123 2nd St',null,'Bad City','ST','12345'),
	('Nordstorm','555 Oak St.',null,'Far Away Town','ST','12345'),
	('Iowa River','9090 Ninety Rd.','Apt # 4','Good Town','ST','12345'),
	('Iowa Hotel','9090 Ninety Rd.','Apt # 4','Good Town','ST','12345')
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Insert Sample Data into ItemCategory Table
*/
print '' print '*** Insert Into ItemCategory Table ***'
GO
INSERT INTO [dbo].[ItemCategory](
	[ItemCategoryID],
	[Description]
)
VALUES
    ('Food','Pet food'),
    ('Medical','Medical supplies')
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Insert Sample Data into Item Table
*/
print '' print '*** Insert Into Item Table ***'
GO
INSERT INTO [dbo].[Item](
	[ItemName],
	[ItemCategoryID],
	[ItemDescription],
	[ItemQuantity]
)
VALUES
    ('LoCatMein','Food','Name Brand Cat Food', 42),
    ('Scratch Be Gone','Medical','Animal Scratch Wound Healant', 35)
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Insert Sample Data into ProductCategory Table
*/
print '' print '*** Insert Into ProductCategory Table ***'
GO
INSERT INTO [dbo].[ProductCategory](
	[ProductCategoryID],
	[Description]
)
VALUES
    ('Food','Pet food'),
    ('Medical','Medical supplies')
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Insert Sample Data into ProductType Table
*/
print '' print '*** Insert Into ProductType Table ***'
GO
INSERT INTO [dbo].[ProductType](
	[ProductTypeID],
	[Description]
)
VALUES
    ('Cat','Cat supplies'),
    ('General','General supplies')
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Insert Sample Data into Product Table, Updated 2020/03/17 to be compatible with new Product table structure by Robert Holmes.
*/
print '' print '*** Insert into Product table'
GO
INSERT INTO [dbo].[Product](
	[ProductID],
	[ItemID],
	[ProductTypeID],
	[Taxable],
	[Price],
	[Description],
	[Brand]
)
VALUES
	('7084781116',100000,'Cat',1,50.0,'Name brand cat food','OnlyForCats'),
	('2500006153',100001,'General',1,100.0,'Medical Supplies to Heal Scratch Wounds','AlsoForHumans')
GO

/*
Created by: Derek Taylor
Date 2/4/2020
Comment: Inserts sample data for the application
*/
print '' print '*** Creating Sample Applicants'
GO
INSERT INTO [dbo].[Applicant]
	([FirstName], [LastName], [MiddleName], [Email], [PhoneNumber], [AddressLine1],
		[AddressLine2], [City], [State], [ZipCode])
	VALUES
	('Derek', 'Taylor', 'Joel','derek@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Ryan', 'Morganti', 'Donald Albert','ryan@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Steve', 'Coonrod', 'Marcus','steve@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Matt', 'Deaton', 'Franklin','matt@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Hassan', 'Karar', 'MiddleName','hassan@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Gabrielle', 'Legrande', 'Sue','gabrielle@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Michael', 'Thompson', 'Michael','michael@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555')
GO

/*
Created by: Chase Schulte
Date: 02/05/2020
Comment: Inserts test data for the ERole Table
*/
print ''  print '*** Insert eRoles into ERole Table'
GO

Insert INTO [dbo].[ERole]
	([ERoleID],[DepartmentID],[Description])
	Values
	('Cashier','Sales','Handles customer'),
	('Manager','Management','Handles internal operations like employee records and payment info')
Go

/*
Created by: Ethan Holmes
Date: 02/16/2020
Comment: Insert fake data into VolunteerTask table
*/
print ''  print '*** Insert fake Volunteer Tasks'
GO
Insert INTO [dbo].[VolunteerTask]
	([TaskName],[TaskType],[AssignmentGroup],[DueDate],[TaskDescription])
	Values
	('Fake Task 1','TaskType1','Group1','02/01/2021','Fake Description 1'),
	('Fake Task 2','TaskType2','Group2','02/01/2022','Fake Description 2')
GO

/*
Created by: Austin Gee
Date: 2/21/2020
Comment: Adds Animal records to the Animal table
*/
print '' print '*** Creating Sample Animal Records'
GO
INSERT INTO [dbo].[Animal]
	([AnimalName],[Dob],[AnimalSpeciesID],[AnimalBreed],[ArrivalDate])
	VALUES
	('Spot','07-12-1984','Dog','Blood Hound','10-10-2019'),
	('Spit','07-12-1984','Cat','Tabby','10-10-2019'),
	('Simon','07-12-1984','Rat','Siamese','10-10-2019')
GO

/*
Created by: Austin Gee
Date: 2/21/2020
Comment: Adds AppointmentType Records to the AppointmentType table.
*/
print '' print '*** Creating Sample AppointmentType Records'
GO
INSERT INTO [dbo].[AppointmentType]
	([AppointmentTypeID],[Description])
	VALUES
	('Meet and Greet','This is where the Adoption Customer will meet the animal while the facilitator is present'),
	('InHomeInspection','This is where the InHomeInspection will interview the Adoption Customer'),
	('Interviewer','This is where the Interviewer will interview the Adoption Customer'),
	('Reviewer','This is where the Reviewer will interview the Adoption Customer')
GO

/*
Created by: Austin Gee
Date: 2/21/2020
Comment: Adds sample Appointment records to the Appointment table.
*/
print '' print '*** Creating Sample Appointment Records'
GO
INSERT INTO [dbo].[Appointment]
	([AdoptionApplicationID],[AppointmentTypeID],[DateTime],[Notes],[Decision],[LocationID])
	VALUES
	(100000,'Reviewer','2020-2-22 10am','','',1000000),
	(100001,'Meet and Greet','2020-2-22 9am','','',1000000),
	(100002,'Interviewer','2020-2-22 12pm','','',1000000),		
	(100003,'InHomeInspection','2020-2-22 12pm','','',1000003),
	(100004,'InHomeInspection','2020-2-22 12pm','','',1000004)
	
	
GO
/*
Created by: Awaab Elamin
Date: 2/18/2020
Comment: Insert samples data in general questiones table 
*/
GO
print '' print '*** Inserting GeneralQusetions records'
GO
INSERT INTO [dbo].[GeneralQusetions]
(Description)
VALUES
('Question 1'),('Question 2'),('Question 3'),('Question 4'),('Question 5'),('Question 6'),('Question 7'),('Question 8'),('Question 9'),('Question 10')
GO

GO
/*
Created by: Awaab Elamin
Date: 2/18/2020
Comment: Insert samples of CustomerAnswers table .
*/
GO
print '' print '*** Inserting CustomerAnswer records'
GO
INSERT INTO [dbo].[CustomerAnswers]
([QuestionDescription],[Answer],[CustomerEmail],[AdoptionApplicationID])
VALUES
('Question 1','Answer1','Awaab@Awaaab.com',(SELECT [AdoptionApplicationID]FROM [dbo].[AdoptionApplication]WHERE [dbo].[AdoptionApplication].[CustomerEmail] = 'Awaab@Awaaab.com')),
('Question 2','Answer2','Awaab@Awaaab.com',(SELECT [AdoptionApplicationID]FROM [dbo].[AdoptionApplication]WHERE [dbo].[AdoptionApplication].[CustomerEmail] = 'Awaab@Awaaab.com')),
('Question 3','Answer3','Awaab@Awaaab.com',(SELECT [AdoptionApplicationID]FROM [dbo].[AdoptionApplication]WHERE [dbo].[AdoptionApplication].[CustomerEmail] = 'Awaab@Awaaab.com')),
('Question 4','Answer4','Awaab@Awaaab.com',(SELECT [AdoptionApplicationID]FROM [dbo].[AdoptionApplication]WHERE [dbo].[AdoptionApplication].[CustomerEmail] = 'Awaab@Awaaab.com')),
('Question 5','Answer5','Awaab@Awaaab.com',(SELECT [AdoptionApplicationID]FROM [dbo].[AdoptionApplication]WHERE [dbo].[AdoptionApplication].[CustomerEmail] = 'Awaab@Awaaab.com')),
('Question 6','Answer6','Awaab@Awaaab.com',(SELECT [AdoptionApplicationID]FROM [dbo].[AdoptionApplication]WHERE [dbo].[AdoptionApplication].[CustomerEmail] = 'Awaab@Awaaab.com')),
('Question 7','Answer7','Awaab@Awaaab.com',(SELECT [AdoptionApplicationID]FROM [dbo].[AdoptionApplication]WHERE [dbo].[AdoptionApplication].[CustomerEmail] = 'Awaab@Awaaab.com')),
('Question 8','Answer8','Awaab@Awaaab.com',(SELECT [AdoptionApplicationID]FROM [dbo].[AdoptionApplication]WHERE [dbo].[AdoptionApplication].[CustomerEmail] = 'Awaab@Awaaab.com')),
('Question 9','Answer9','Awaab@Awaaab.com',(SELECT [AdoptionApplicationID]FROM [dbo].[AdoptionApplication]WHERE [dbo].[AdoptionApplication].[CustomerEmail] = 'Awaab@Awaaab.com')),
('Question 10','Answer10','Awaab@Awaaab.com',(SELECT [AdoptionApplicationID]FROM [dbo].[AdoptionApplication]WHERE [dbo].[AdoptionApplication].[CustomerEmail] = 'Awaab@Awaaab.com'))
GO

/*
Created by: Jaeho Kim
Date: 02/27/2020
Comment: Inserts test data for the TransactionStatus Table
*/
print ''  print '*** Inserting sample data into TransactionStatus Table'
GO
Insert INTO [dbo].[TransactionStatus]
	([TransactionStatusID], [Description])
	Values
	('tranStatus100', 'description 100'),
	('tranStatus200', 'description 200'),
	('tranStatus500', 'description 500'),
	('tranStatus800', 'description 800'),
	('Completed', 'A completed transaction')
GO

/*
Created by: Jaeho Kim
Date: 02/27/2020
Comment: Inserts test data for the TransactionType Table
*/
print ''  print '*** Inserting sample data into TransactionType Table'
GO
Insert INTO [dbo].[TransactionType]
	([TransactionTypeID], [Description])
	Values
	('tranTYPE100', 'TYPEdescription 100'),
	('tranTYPE200', 'TYPEdescription 200'),
	('tranTYPE500', 'TYPEdescription 500'),
	('tranTYPE800', 'TYPEdescription 800'),
	('Online Sale', 'Online Sale')
GO

/*
Created by: Alex Diers
Date: 2/28/2020
Comment: Creates sample training video information
*/
print '' print '*** Creating Sample Training Video Records'
GO
INSERT INTO [dbo].[TrainingVideo]
	([TrainingVideoID], [RunTimeMinutes], [RunTimeSeconds], [Description])
	VALUES
    ('Link', 1, 25, 'Description'),
    ('AnotherLink', 2, 5, 'Another description')
GO

/*
Created by: Tener Karar
Date: 02/27/2020
Comment: inserting ItemCategory sample data
*/
print '' print '*** inserting ItemCategory sample data'
GO
INSERT INTO [dbo].[ItemCategory]
([ItemCategoryID],[Description])
VALUES
    ( 'cat',' Litter-Robot 3 is the highest-rated automatic,
    self-cleaning litter box for cats.
    Never scoop cat litter again while giving your kitty a clean
    bed of litter for each use. Litter-Robot ')
Go

/*
Created by: Tener Karar
Date: 02/27/2020
Comment: inserting Item sample data
*/
print '' print '*** inserting Item sample data'
GO
INSERT INTO [dbo].[Item]
	([ItemName], [ItemQuantity], [ItemCategoryID], [ItemDescription] )
VALUES
	('loon', 1, 'cat',' Litter-Robot 3 is the highest-rated automatic,
    self-cleaning litter box for cats.
    Never scoop cat litter again while giving your kitty a clean
    bed of litter for each use. Litter-Robot ' )
go

/*
Created by: Tener Karar
Date: 02/27/2020
Comment: inserting Item Location sample data
*/
print '' print '*** inserting ItemLocation sample data'
GO
INSERT INTO [dbo].[ItemLocation]
	( [Description]  )
VALUES
	(' in the first floor ' ),
	(' in the first floor ' ),
	(' in the first floor ' ),
	(' in the first floor ' ),
	(' in the first floor ' ),
	(' in the first floor ' )
Go

/*
Created by: Tener Karar
Date: 02/27/2020
Comment:  inserting Item Location Line table'
*/
print '' print '*** inserting ItemLocationLine sample data'
GO
INSERT INTO [dbo].[ItemLocationLine]
	([ItemID]	,[LocationID]  )
VALUES
	( 100002, 1000 )
Go

/*
Created By: Timothy Lickteig
Date: 2/07/2020
Comment: Sample data for volunteer shifts
*/
print '' print '*** Creating Volunteer Shift records'
go

insert into [dbo].[VolunteerShift]
	([ShiftDescription], [ShiftTitle], [ShiftDate],
	[ShiftStartTime], [ShiftEndTime], [Recurrance],
	[IsSpecialEvent], [ShiftNotes] ,[ScheduleID])
values
	('This is the first shift', 'Its a pretty cool shift', '2020-01-01','13:30:00', '15:00:00', 'None', 0, 'Any notes go here', 0),
	('This is the second shift', 'Its an even cooler shift', '2009-08-07','12:00:00', '13:00:00', 'None', 0, 'Any other notes go here', 0)
go

/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Sample Data for the EventType Table
*/
print '' print '*** Creating Sample Data for the EventType table'
GO
INSERT INTO [dbo].[EventType]
	([EventTypeID],[Description])
	VALUES
	('Fundraiser','An event held to raise funding for a specific cause.'),
	('Awareness','An event held to raise awareness for a specific issue.'),
	('Adoption','An event held to showcase animals who are available for adoption or sponsorship.'),
	('Training','Training class with a certified trainer for a specific animal.')
GO

/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Sample Data for the Event Table
*/
print '' print '*** Creating Sample Data for the Event table'
GO
INSERT INTO [dbo].[Event]
	([CreatedByID],[DateCreated],[EventName],[EventTypeID],[EventDateTime],[EventAddress],
	[EventCity],[EventState],[EventZipcode],[EventPictureFileName],[Status],[Description])
	VALUES
	(100002, '01/10/18 6:00:00', 'ZappyBs Animal House','Fundraiser','01/23/19 6:30:00.000','123 Doreyme Street',
		'Boulder','CO','80663','ZappyBsAnimalHouse.jpg','Completed',
		'ZappyBs Animal House is an annual event that raises funds to sponsor the ABC Animal Shelter.'),
	(100002, '01/10/18 8:00:00', 'Bluebird Animal Retreat','Adoption','05/16/20 15:30:00.000','343 A Ave',
		'Cedar Rapids','IA','52402','default.png','Approved',
		'The Bluebird Annual Animal Retreat is a great opportunity to com interact with the animals from the Bluebird Animal Shelter.'),
	(100002, '01/10/18 10:00:00', 'Canine Service Training','Training',DATEADD(MINUTE, 30, DATEADD(HOUR, 16, DATEDIFF(DAY, 0, CURRENT_TIMESTAMP))),'343 C St',
		'Cedar Rapids','IA','52408','default.png','Active',
		'Training classes for Canine Service Certification.'),
	(100002, '01/10/18 6:00:00', 'Lets Paws A Minute','Awareness','04/23/19 15:30:00.000','2424 A Street',
		'Cedar Rapids','IA','52402','default.png','PendingApproval',
		'Lets Paws A Minute is an event for raising awareness about canine diabetis.')
GO

/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Sample Data for the RequestType Table
*/
print '' print '*** Creating Sample Data for the RequestType table'
GO
INSERT INTO [dbo].[RequestType]
	([RequestTypeID],[Description])
	VALUES
	('Event','A request to host an event sponsored by Pet Universe.')
GO

/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: Sample Department Data
*/
print '' print '*** Inserting Sample Department Records'
GO
INSERT INTO [dbo].[Department]
	([DepartmentID], [Description])
	VALUES
	('Inventory', 'Inventory Description'),
	('CustomerService', 'CustomerService Description')
GO

/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: Sample RequestType Data
*/
print '' print '*** Inserting Sample RequestTpe Records'
GO
INSERT INTO [dbo].[RequestType]
	([RequestTypeID], [Description])
	VALUES
	('General', 'Multi-purpose request format'),
	('TimeOff', 'Schedule time off')
GO

/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: Sample Request Data
*/
print '' print '*** Inserting Sample Request Records'
GO
INSERT INTO [dbo].[request]
	([DateCreated], [RequestTypeID], [RequestingUserID])
	VALUES
	('20200206 11:00:00 AM', 'General',  100000),
	('20200207 12:55:01 PM', 'General',  100000),
	('20200208 01:02:03 PM', 'General',  100000),
	('20200207 12:55:01 PM', 'General',  100000),
	('20200208 01:02:03 PM', 'General',  100000),
	('20200206 03:02:03 PM', 'General',  100000)
GO 

/*
Created by: Ryan Morganti
Date: 2020/02/21
Comment: Sample EmployeeDepartment Records
*/
print '' print '*** Instering Samlple Role record Employee'
GO
INSERT INTO [dbo].[EmployeeDepartment]
	([EmployeeID], [DepartmentID])
	VALUES
	(100000, 'Management'),
	(100000, 'Inventory'),
	(100000, 'CustomerService'),
	(100003, 'Management'),
	(100003, 'Inventory'),
	(100003, 'CustomerService'),
	(100004, 'Inventory'),
	(100005, 'CustomerService')
GO

/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: Sample Request Data
*/
print '' print '*** Inserting DepartmentRequest Records'
GO
INSERT INTO [dbo].[DepartmentRequest]
	([DeptRequestID], [RequestingUserID], [RequestGroupID], [RequestedGroupID],
		[DateAcknowledged], [AcknowledgingUserID], [DateCompleted], [CompletedUserID],
		 [RequestSubject], [RequestTopic], [RequestBody])
VALUES
	(1000000, 100003, 'Management', 'CustomerService',
		NULL, NULL, NULL, NULL,
		'subject filler test', 'topic test', 'This is my body, its so testable'),
	(1000001, 100003, 'Inventory', 'Management',
		NULL, NULL, NULL, NULL,
		'subject filler test', 'topic test', 'This is my body, its so testable'),
	(1000002, 100003, 'Inventory', 'Management',
		NULL, NULL, NULL, NULL, 'subject filler test', 'topic test',
		'This is my body, its so testable'),
	(1000003, 100003, 'Inventory', 'Management',
		'20200208 01:02:03 PM', 100003, NULL, NULL,
		'subject filler test', 'topic test', 'This is my body, its so testable'),
	(1000004, 100003, 'Management', 'CustomerService',
		'20200208 02:02:03 PM', 100003, '20200209 06:04:03 PM', 100003,
		'subject filler test', 'topic test', 'This is my body, its so testable'),
	(1000005, 100003, 'Management', 'Inventory',
		'20200208 09:02:03 PM', 100003, '20200209 02:04:03 PM', 100003,

		'subject filler test', 'topic test', 'This is my body, its so testable')
GO

/*
Created By: Brandyn T. Coverdill
Date: 2/22/2020
Comment: Adding data to ItemCategory
*/
print '' print '*** Adding data to ItemCategory'
GO
INSERT INTO ItemCategory(
ItemCategoryID,
Description
)
VALUES
	('Dog Food', 'This is the description for the dog food.'),
	('Cat Toys', 'This is the description for the cat toys.')
GO

/*
Created by: Brandyn T. Coverdill
Date: 2/22/2020
Comment: Adding data to Item
*/
print '' print '*** Adding data to items'
GO
INSERT INTO Item(
	ItemName,
	ItemCategoryID,
	ItemDescription,
	ItemQuantity
)
VALUES
	('Dog Food', 'Dog Food', 'Dog Food Description', 10),
	('Cat Food', 'Dog Food', 'Cat Food Description', 20),
	('Lazer Pointer', 'Cat Toys', 'Lazer Pointer Description', 40)
GO

print '' print '*** Creating Sample Volunteer Records'
/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Sample Active Volunteer records
*/
go

insert into [dbo].[Volunteer]
	([FirstName], [LastName], [Email], [PhoneNumber], [OtherNotes])
	values
	('System', 'Admin', 'admin@petuniverse.com', '00000000000', 'Admin Volunteer'),
	('Ned', 'Flanders', 'diddlydoo@gmail.com', '13192522443', 'Volunteer Notes')
go

/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Sample Deactived Volunteer records
*/
print '' print '*** Creating Sample Deactivated Volunteer'
go
insert into [dbo].[Volunteer]
	([FirstName], [LastName], [Email], [PhoneNumber], [OtherNotes], [Active])
values
	('Homer', 'Simpson', 'doofus@gmail.com', '13194568896', 'Terrible worker', 0)
GO

/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Sample skills and description
*/
print '' print '*** Creating Sample VolunteerSkills Records'
go
insert into [dbo].[VolunteerSkills]
	([SkillID], [SkillDescription])
	values
	('Basic Volunteer', 'Standard Volunteer - no particular proficiency'),
	('Dogwalker', 'Suited to walk dogs'),
	('Groomer', 'Suited to groom animals'),
	('Trainer', 'Suited to train animals'),
	('Transporter', 'Able to transport animals to vet appointments, etc'),
	('Pet Photographer', 'Takes pictures of animals for websites, fliers, etc'),
	('Housing Management', 'Suited for managing animal housing, makes sure bedding is clean, housing has adequete food/water'),
	('Campaigner', 'Suited for promoting marketing campaigns'),
	('Greeter', 'Guide potential adopters throughout the shelter')
go


/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Sample ties between Volunteers and their skills
*/
print '' print '*** Creating Sample VolunteerSkill Records'
go
insert into [dbo].[VolunteerSkill]
	([VolunteerID], [SkillID])
	values
	(1000001, 'Greeter'),
	(1000001, 'Campaigner')
go

/*
Created by: Zoey McDonald
Date: 2/20/2020
Comment: Creates sample Volunteer Events data.
*/
print '' print '*** Creating Sample Volunteer Event'
GO
INSERT INTO [dbo].[VolunteerEvents]
	([EventName], [EventDescription], [Active])
	VALUES
	('Party For The Dawgs', 'It is just a party for the dogs.', 1),
	('Party For The Cats', 'It is just a party for the cats.', 0)
GO

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Inserting Sample Data for RequestType
*/
PRINT '' PRINT '*** Inserting sample RequestType data'
GO
INSERT INTO [dbo].[requestType]
	([RequestTypeID])
	VALUES
	('Time Off'), ('Availability Change'), ('Schedule Change')
GO

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Inserting Sample Data for Request
*/
PRINT '' PRINT '*** Inserting sample Request records'
GO
INSERT INTO [dbo].[request]
	([RequestTypeID], [RequestingUserID], [DateCreated], [Open])
	VALUES
	('Time Off', 100001, '2020-3-1 10:12:21', 1),
	('Time Off', 100000, '2020-2-11 12:33:25', 1),
	('Availability Change', 100001, GETDATE(), 0),
	('Availability Change', 100002, GETDATE(), 1)
GO

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Inserting Sample Data for Time Off Request
*/
PRINT '' PRINT '*** creating sample timeOffRequest records'
GO
INSERT INTO [dbo].[timeOffRequest]
	([EffectiveStart], [EffectiveEnd], RequestID)
	VALUES
	('2020-3-25 12:11:10', '2020-4-10 11:31:15', 1000006),
	('2020-4-6 11:10:9', '2020-4-12 11:13:51', 1000007)
GO

/*
Created by: Robert Holmes
Date: 2020/03/10
Comment: Inserting promotion types 
*/
print '' print '*** Inserting promotion types'
GO
INSERT INTO [dbo].[PromotionType]
	([PromotionTypeID], [Description])
	VALUES
	('Percent', 'Percent discount'),
	('Flat Amount', 'Dollar amount to discount')
GO

print '' print '*** Creating sample AnimalActivity records'
GO
INSERT INTO [dbo].[AnimalActivity]
	([AnimalID], [UserID], [AnimalActivityTypeID], [ActivityDateTime], [Description])
	VALUES
	(1000000, 100000, 'Feeding', '09-08-2016', '')
	
GO	

INSERT INTO [dbo].[Item]
([ItemQuantity], [ItemName], [ItemCategoryID], [ItemDescription])
	VALUES
	(4,' Medication1', 'Medical', ''),
	(4,' Medication2', 'Medical', '')	
GO

INSERT INTO [dbo].[AnimalMedicalInfo]
([AnimalID], [UserID],[SpayedNeutered], [Vaccinations], [MostRecentVaccinationDate], [AdditionalNotes])
VALUES
	(1000000,100000,1, 'Ebola', '09-08-2016', 'None'),
	(1000001,100000,0, 'None', '10-01-2012', 'None'),
	(1000002,100000,1, 'Corona', '04-15-1998', 'None'),
	(1000003,100000,1, 'Ebola', '09-08-2016', 'None'),
	(1000004,100000,0, 'None', '10-01-2012', 'None'),
	(1000005,100000,1, 'Corona', '04-15-1998', 'None'),
	(1000006,100000,1, 'Corona', '04-15-1998', 'None'),
	(1000007,100000,1, 'Corona', '04-15-1998', 'None'),
	(1000008,100000,1, 'Corona', '04-15-1998', 'None')
	
GO	

/*
Created by: Ben Hanna
Date: 2/18/2020
Comment: Sample animal handling notes record
*/                
print '' print '*** Creating Sample Animal Handling Records'
GO
INSERT INTO [dbo].[AnimalHandlingNotes]
	([AnimalID], [UserID], [AnimalHandlingNotes], [TemperamentWarning], [UpdateDate])
    
	VALUES
	(1000000,100000,'Notes', 'Warning', '2020-01-22'),
	(1000001,100000,'Notes', 'Warning', '2020-01-22'),
	(1000002,100000,'Notes', 'Warning', '2020-01-22'),
	(1000003,100000,'Notes', 'Warning', '2020-01-22'),
	(1000004,100000,'Notes', 'Warning', '2020-01-22'),
	(1000005,100000,'Notes', 'Warning', '2020-01-22'),
	(1000006,100000,'Notes', 'Warning', '2020-01-22'),
	(1000007,100000,'Notes', 'Warning', '2020-01-22'),
	(1000008,100000,'Notes', 'Warning', '2020-01-22') 
GO

/*
Created By: Timothy Lickteig
Date: 3/01/2020
Comment: Sample data for volunteer shift records
*/
print '' print '*** Creating Shift Record records'
go
insert into [dbo].[ShiftRecord]
	(VolunteerID, VolunteerShiftID)
	values
		(1000000, 1000000),
		(1000000, 1000001)
go



/*
Author: Timothy Lickteig
Date: 2020/03/09
Comment: Creating sample data for the medicine table
*/
print '' print '*** Creating Medicine table data'
GO
INSERT INTO [dbo].[Medicine]
([MedicineName], [MedicineDosage], [MedicineDescription])
VALUES
('This is the first one', 'This is the first dosage', 'This is the first description'),
('This is the second one', 'This is the second dosage', 'This is the third description')
GO

/*
Created by: Jordan Lindo
Date: 3/14/2020
Comment: BaseSchedule sample records.
*/
print '' print'***Creating BaseSchedule sample records'

INSERT INTO [dbo].[BaseSchedule]
	([CreatingUserID],[CreationDate],[Active])
	Values
	 (100000,'2020-02-14',0)
	,(100000,'2020-03-14',1)
GO


/*
Created by: Jordan Lindo
Date: 3/14/2020
Comment: BaseScheduleLine sample records
*/
print '' print'***Creating BaseScheduleLine sample records'
GO

INSERT INTO [dbo].[BaseScheduleLine]
	([ERoleID],[BaseScheduleID],[ShiftTimeID])
	VALUES
	 ('Cashier',1000001,1000007)
	,('Manager',1000001,1000004)
GO

/*
Created by: Matt Deaton
Date: 2020-03-06
Comment: Inserting sample data into the ItemCategory table that are intended for shelter use.
*/
PRINT '' PRINT '*** Insert Into ItemCategory Table ***'
GO
INSERT INTO [dbo].[ItemCategory](
	[ItemCategoryID],
	[Description]
)
VALUES
('Litter','Cat Litter'),
('Bedding','Any kind of bedding material')
GO

/*
Created by: Matt Deaton
Date: 2020-03-06
Comment: Inserting sample data into the Item table that are intended for shelter use.
*/
PRINT '' PRINT '*** Insert Sample Data For Shelter Items in Item Table'
INSERT INTO [dbo].[Item](
	[ItemName]
	,[ItemCategoryID]
	,[ItemDescription]
	,[ItemQuantity]
	,[ShelterItem]
	,[ShelterThershold]
)
VALUES
('Dog Food', 'Food', 'Food for Shelter. In pounds.', 75, 1, 100),
('Cat Litter', 'Litter', 'Cat Litter for the Shelter. In pounds', 150, 1, 100),
('Blankets', 'Bedding', 'Blankets for the Shelter animals to use as bedding', 5, 1, 10),
('Chinchilla Food', 'Food', 'Pellet food for a Chinchilla', 3, 1, 5)
GO

/*
Created by: Matt Deaton
Date: 2020-03-17
Comment: Inserting sample data into the Donor table.
*/
PRINT '' PRINT '*** Insert Sample Data into the Donor Table'
INSERT INTO [dbo].[Donor](
	[FirstName]
	, [LastName]
	, [Active]
)
VALUES
(DEFAULT, NULL, DEFAULT),
('Matt', 'Deaton', DEFAULT)
GO

/*
Created by: Jaeho Kim
Date: 02/27/2020
Comment: Inserts test data for the Transaction Table
*/
print ''  print '*** Inserting sample data into Transaction Table'
GO
Insert INTO [dbo].[Transaction]
	([TransactionDateTime],[TaxRate],[SubTotalTaxable],[SubTotal],[Total]
	,[TransactionTypeID],[EmployeeID],[TransactionStatusID],[CustomerEmail])
	Values
	('2019-10-10 10:10',0.0225,10.39,21.23,21.46,'tranTYPE100'
	, 100000, 'tranStatus100','zbehrens@PetUniverse.com'),
	('2020-02-11 9:43',0.0225,41.39,41.39,43.22,'tranTYPE100'
	, 100000, 'tranStatus100',null),
	('2018-04-13 10:13',0.014,52.39,51.39,53.22,'tranTYPE100'
	, 100001, 'tranStatus100',null)
Go

/*
Created by: Jaeho Kim
Date: 02/27/2020
Comment: Inserts test data for the TransactionLineProducts Table
*/
print ''  print '*** Inserting sample data into TransactionLineProducts Table'
GO
Insert INTO [dbo].[TransactionLineProducts]
	([TransactionID], [ProductID], [Quantity],[PriceSold])
	Values
	(1000, '7084781116', 1, 37.22),
	(1000, '2500006153', 1, 11.11),
	(1001, '7084781116', 2, 74.44)
Go

/*
Created by: Jaeho Kim
Date: 04/10/2020
Comment: Inserts test data for the SalesTaxHistory Table
*/
PRINT ''  PRINT '*** Creating sample SalesTaxHistory data'
GO
INSERT INTO [dbo].[SalesTaxHistory]
	([ZipCode], [SalesTaxDate], [TaxRate])
    
	VALUES
	('1111', '2002-10-10', 2.33),
	('1111', '2008-10-10', 3.33),
	('1111', '2010-10-10', 4.33),
	('1111', '2019-10-10', 0.0253),
	('1111', '2012-10-10', 1.33),
	('2222', '2012-10-10', 0.0345),
	('2222', '2009-10-10', 11.33)
GO

/*
Created by: Rasha Mohammed
Date: 2/29/2020
Comment: Sproc to update Product price
*/
print '' print '*** Creating sp_update_product_price'
GO
CREATE PROCEDURE [sp_update_product_price]
(
	@ProductID				[NVARCHAR](13),

	@NewItemID				[INT],
	@NewProductTypeID 		[NVARCHAR](20),
	@NewDescription  		[NVARCHAR](500),
	@NewPrice				[DECIMAL](10,2),
	@NewBrand				[NVARCHAR](20),
	@NewTaxable				[BIT],	
	
	@OldItemID				[INT],
	@OldProductTypeID 		[NVARCHAR](20),
	@OldDescription  		[NVARCHAR](500),
	@OldPrice				[DECIMAL](10,2),
	@OldBrand				[NVARCHAR](20),
	@OldTaxable				[BIT]	
)
AS
BEGIN
	UPDATE [dbo].[Product]
		SET [ItemID] 	  	  	= @NewItemID,
			[ProductTypeID] 	=	@NewProductTypeID,
			[Description]	  = @NewDescription,
			[Price]			  = @NewPrice,
			[Brand]		      = @NewBrand,
			[Taxable] 		  = @NewTaxable
			
	WHERE 	[ProductID] 	  =	@ProductID 
	  AND	[ItemID] 	  	  = @OldItemID
	  AND	[ProductTypeID]     = @OldProductTypeID
	  AND	[Description] 	  = @OldDescription
	  AND	[Price]    	      = @OldPrice
	  AND	[Brand]           = @OldBrand
	  AND	[Taxable]         = @OldTaxable
	 
	RETURN @@ROWCOUNT
END
GO




/*
Created by: Steve Coonrod
Date: 2020/03/06
Comment: Sample Request Data
*/
print '' print '*** Inserting Sample Request Records for Sample Events'
GO
INSERT INTO [dbo].[request]
	([DateCreated], [RequestTypeID], [RequestingUserID],[Open])
	VALUES
	('20200206 11:00:00 AM', 'Event', 100002, 1),
	('20200207 12:55:01 PM', 'Event', 100000, 1),
	('20200208 01:02:03 PM', 'Event', 100000, 1),
	('20200207 12:55:01 PM', 'Event', 100003, 0)
GO 

/*
Created by: Steve Coonrod
Date: 2020/03/06
Comment: Sample EventRequest Data
*/
print '' print '*** Inserting Sample EventRequest Records for Sample Events'
GO
INSERT INTO [dbo].[EventRequest]
		([EventID],[RequestID],[ReviewerID],[DisapprovalReason],[DesiredVolunteers],[Active])
	VALUES
		(1000000, 1000000, 100000, NULL, 3, 0),
		(1000001, 1000001, 100000, NULL, 2, 0),
		(1000002, 1000002, 100000, NULL, 4, 0),
		(1000003, 1000003, NULL, NULL, 0, 1)
GO


/*
Created by: Ben Hanna
Date: 4/8/2020
Comment: Sample data for the cleaning records.
*/

GO                
PRINT '' PRINT '*** Inserting Sample Kennel Cleaning records'
GO
INSERT INTO [dbo].[FacilityKennelCleaning] 
        ([UserID],
         [AnimalKennelID],
         [Date],
         [Notes]
        )
VALUES 
        (100000, 1000000, '20200207 12:55:01 PM', 'sample 1 sample 1'),
        (100001, 1000001, '20200407 12:55:00 PM', 'sample 2 sample 2')
GO          


/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for retrieving a List of Events from the DB
			 Where The status = @Status
*/
print '' print '*** Creating sp_select_events_by_status'
GO
CREATE PROCEDURE [sp_select_events_by_status]
(
	@Status						[nvarchar](50)
)
AS
BEGIN
	SELECT 	[EventID],[CreatedByID],[DateCreated],[EventName],[EventTypeID],
			[EventDateTime],[EventAddress],[EventCity],[EventState],[EventZipcode],
			[EventPictureFileName],[Status],[Description]
	FROM   	[dbo].[Event]
	WHERE  	[Status] = @Status
	ORDER BY [EventDateTime]ASC
END
GO

/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for retrieving an EventApprovalVM from the DB
*/
print '' print '*** Creating sp_select_event_request_by_eventID'
GO
CREATE PROCEDURE [sp_select_event_approval_request_by_eventID]
(
	@EventID			[int],
	@CreatedByID		[int]
)
AS 
BEGIN

	SELECT  [dbo].[User].[FirstName] + ' ' + [dbo].[User].[LastName] AS [RequestedByName],
			[DateCreated],[EventName],[EventTypeID],
			[EventDateTime],[EventAddress],[EventCity],[EventState],[EventZipcode],
			[EventPictureFileName],[Status],[Description],
			[ReviewerID],[DisapprovalReason],[DesiredVolunteers]
	FROM	[dbo].[Event] JOIN 	[dbo].[EventRequest]
	ON		[dbo].[Event].[EventID] = [dbo].[EventRequest].[EventID]
	JOIN 	[dbo].[User]
	ON		[dbo].[Event].[CreatedByID] = [dbo].[User].[UserID]
	WHERE	[dbo].[Event].[EventID] = @EventID
	AND		[dbo].[User].[UserID] = @CreatedByID
END
GO

/*
Created by: Steve Coonrod
Date: 2020/03/06
Comment: Stored Procedure to select an Event Request by the EventID
*/
print '' print '*** Creating sp_select_event_request_by_event_id'
GO
CREATE PROCEDURE [sp_select_event_request_by_event_id]
(
	@EventID				[int]
)
AS 
BEGIN
	SELECT  [RequestID],[ReviewerID],[DisapprovalReason],[DesiredVolunteers],[Active]
	FROM	[dbo].[EventRequest]
	WHERE	[EventID] = @EventID
END
GO

/*
Created by: Steve Coonrod
Date: 2020/03/06
Comment: Stored Procedure to update an Event Request
*/
print '' print '*** Creating sp_update_event_request'
GO
CREATE PROCEDURE [sp_update_event_request]
(
	@EventID				[int],
	@ReviewerID				[int],
	@DisapprovalReason		[nvarchar](500),
	@DesiredVolunteers		[int],
	@Active					[bit],
	@OldReviewerID			[int],
	@OldDisapprovalReason	[nvarchar](500),
	@OldDesiredVolunteers	[int],
	@OldActive				[bit]
)
AS 
BEGIN
	UPDATE	[dbo].[EventRequest]
	SET		[ReviewerID] = @ReviewerID,
			[DisapprovalReason] = @DisapprovalReason,
			[DesiredVolunteers] = @DesiredVolunteers,
			[Active] = @Active
	WHERE	[EventID] = @EventID
		--AND [ReviewerID] = @OldReviewerID
		--AND	[DisapprovalReason] = @OldDisapprovalReason
		AND	[DesiredVolunteers] = @OldDesiredVolunteers
		AND	[Active] = @OldActive
	RETURN @@ROWCOUNT
END
GO

/*
Created by: Steve Coonrod
Date: 2020/03/06
Comment: Stored Procedure to change the status of an Event
*/
print '' print '*** Creating sp_set_event_status'
GO
CREATE PROCEDURE [sp_set_event_status]
(
	@EventID		[int],
	@Status			[nvarchar](50)
)
AS 
BEGIN
	UPDATE 	[dbo].[Event]
	SET		[Status] = @Status
	WHERE	[EventID] = @EventID
END
GO

/*
Created by: Ryan Morganti
Date: 2020/04/03
Comment: Sample Donor Records
*/
PRINT '' PRINT '*** inserting sample donor records ***'
GO
INSERT INTO [dbo].[Donor]
(
	[FirstName],
	[LastName]
)
VALUES
	('Matt', 'Hill'),
	(DEFAULT, NULL),
	('Ryan', 'Morganti'),
	('Derek', 'Taylor'),
	(DEFAULT, NULL),
	('Ryan', 'Morganti'),
	('Emilio', 'Pena'),
	('Austin', 'Delaney'),
	('Ryan', 'Morganti')
GO

/*
Created by: Ryan Morganti
Date: 2020/04/04
Comment: Sample Donation Records
*/
PRINT '' PRINT '*** inserting sample donation records ***'
GO
INSERT INTO [dbo].[Donations]
(
	[DonorID],
	[TypeOfDonation],
	[DateOfDonation],
	[DonationAmount]
)
VALUES
	(1000, 'Monetary', '03-12-2019', 100.00),
	(1001, 'Monetary', '05-19-2019', 100.00),
	(1002, 'Supplies', '07-20-2019', NULL),
	(1003, 'Monetary', '08-13-2019', 20.00),
	(1004, 'Supplies', '09-13-2019', NULL),
	(1005, 'Monetary', '10-12-2019', 175.00),
	(1006, 'Supplies', '12-30-2019', NULL),
	(1007, 'Monetary', '01-12-2020', 10000.00),
	(1008, 'Monetary', '03-12-2020', 3000.00)
GO

/*Created by: Rasha Mohammed
Date: 3/31/2020
Comment: Insert sample data into Picture table
*/
print ''  print '*** Insert sample record to picture'
GO
/*
INSERT INTO [dbo].[Picture]
	([PictureID], [ProductID],[ImagePath])
	VALUES
	(1, '7084781116', 'LoCatMein.jpg'),
	(2, '2500006153', 'ScratchBeGone.jpg')
GO
*/


/*Created by: Rasha Mohammed
Date: 3/30/2020
Comment: Select images from picture table 
*/
print '' print '*** Creating sp_select__all_image'
GO
CREATE PROCEDURE [sp_select__all_image]
AS
BEGIN
/*
	SELECT  [Picture].[PictureID], [Product].[ProductID], [Picture].[ImagePath]	
	FROM 	[Picture]
    JOIN 	[Product] ON [Product].[ProductID] = [Picture].[ProductID]
	*/
	SELECT 	[PictureID], [ProductID], [PictureData], [PictureMimeType]
	FROM 	[Picture]
END
GO	

/*
Created by: Robert Holmes
Date: 4/13/2020
Comment: Insert sample data into Promotion table.
*/

print '' print '*** Inserting sample data to Promotion table.'
GO
INSERT INTO [dbo].[Promotion]
	([PromotionID], [PromotionTypeID], [StartDate], [EndDate], [Discount], [Description])
	VALUES
	('PROMO1', 'Flat Amount', '20200401 12:00:00 AM', '20200402 12:00:00 AM', 10.00, 'Description')
GO

/*
Created by: Robert Holmes
Date: 4/13/2020
Comment: Insert sample data into PromoProductLine table.
*/

print '' print '*** Inserting sample data to PromoProductLine table.'
GO
INSERT INTO [dbo].[PromoProductLine]
    ([PromotionID], [ProductID])
    VALUES
    ('PROMO1', '7084781116')
GO

/*
Created by: Ryan Morganti
Date: 2020/03/10
Comment: Sample Request Response Data
*/
print '' print '*** Inserting Sample Request Response Data'
GO
INSERT INTO [dbo].[RequestResponse]
	([RequestID], [UserID], [Response], [ResponseTimeStamp])
	VALUES
	(1000003, 100004, 'Hola response1', '03/10/20 8:15:00'),
	(1000003, 100005, 'Hola response for my homeboys', '03/11/20 14:33:00'),
	(1000003, 100004, 'Never!', '03/12/20 10:15:00')
GO

/*
Created by: Ryan Morganti
Date: 2020/03/19
Comment: Sample JobListing Records
*/
print '' print '*** Inserting Sample JobListing record '
GO
INSERT INTO [dbo].[JobListing]
	([Position], [Benefits], [Requirements], [StartingWage], [Responsibilities])
	VALUES
	('Volunteer', 'Free Healthcare, Horse-Dental, Jungle Gym Membership', 'Good Enough Degree', 0000.01, 'Do things without expectation of pay'),
	('Admin', 'Free Healthcare, Horse-Dental, Jungle Gym Membership', 'PHD in Astrophysics', 130000.99, 'Solve World Hunger'),
	('Customer', 'No Benefits', 'No Requirements', 0000.01, 'Give us money in exchange for merchandise'),
	('Groomer', 'Dental, Eye Care, Vision', 'Grooming Experience Recommended', 12.50, 'Groom the animals as the come in'),
	('Stocker', 'Dental, Eye Care, Vision', 'None', 10.50, 'Stock shelves'),
	('Foster', 'No Benefits', 'Home Inspection, Fenced Yard', 0.00, 'Care for the Animal as it were your own')
GO

/*
Created by: Kaleb Bachert
Date: 3/31/2020
Comment: Inserting Sample Data for Schedule
*/
PRINT '' PRINT '*** Inserting sample Schedule data'
GO
INSERT INTO [dbo].[schedule]
	([StartDate], [EndDate])
	VALUES
	('2020-3-29', '2020-4-11'),
	('2020-4-12', '2020-4-25')
GO

/*
Created by: Kaleb Bachert
Date: 3/31/2020
Comment: Inserting Sample Data for Shift
*/
PRINT '' PRINT '*** Insert Into Shift Table ***'
GO
INSERT INTO [dbo].[shift]
	([ShiftTimeID], [ScheduleID], [Date], [UserID], [ERoleID])
	VALUES
	(1000000, 1000000, '2020-4-11', 100001, 'Admin'),
	(1000001, 1000000, '2020-4-11', 100001, 'Customer'),
	(1000002, 1000000, '2020-4-14', 100001, 'Volunteer'),
	(1000003, 1000000, '2020-4-17', 100001, 'Admin'),
	(1000000, 1000000, '2020-4-13', 100002, 'Volunteer'),
	(1000000, 1000000, '2020-4-14', 100002, 'Volunteer'),
	(1000000, 1000000, '2020-4-15', 100002, 'Volunteer'),
	(1000000, 1000000, '2020-4-16', 100002, 'Volunteer'),
	(1000000, 1000000, '2020-4-18', 100002, 'Volunteer'),
	(1000003, 1000000, '2020-4-17', 100000, 'Admin'),
	(1000003, 1000000, '2020-4-25', 100001, 'Admin'),
	(1000002, 1000000, '2020-4-25', 100001, 'Admin'),
	(1000000, 1000000, '2020-5-20', 100001, 'Admin'),
	(1000001, 1000000, '2020-5-20', 100001, 'Admin')

GO

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Inserting Sample Data for ScheduleChangeRequest
*/
PRINT '' PRINT '*** Inserting Sample ScheduleChangeRequest Data'
GO
EXEC sp_insert_schedule_change_request 1000003, 100001;
GO

/*
Created by: Kaleb Bachert
Date: 3/31/2020
Comment: Inserting Sample Data for activeTimeOff
*/
PRINT '' PRINT '*** Insert Into Active Time Off Table ***'
GO
INSERT INTO [dbo].[activeTimeOff]
	([UserID], [StartDate], [EndDate])
	VALUES
	(100000, '2020-4-16', '2020-4-18'),
	(100002, '2020-5-30', '2020-6-14')
GO

/*
Created by: Chase Schulte
Date: 04/07/2020
Comment: Inserts test data for AvailabilityRequest
*/
PRINT '' PRINT '*** Insert Into AvailabilityRequest Table ***'
GO
INSERT INTO [dbo].[AvailabilityRequest]
	(
	[MondayStartTime],
	[MondayEndTime],
	[SundayStartTime],
	[SundayEndTime],
	[RequestID])

VALUES
	('00:00:00', '23:59:00', '00:00:00', '23:59:00',1000008),
	('11:00:00', '12:00:00','13:00:00', '14:00:00',1000009),
	('12:01:00', '13:59:00','14:01:00', '15:59:00',1000009)
GO

/*
Created by: Kaleb Bachert
Date: 4/10/2020
Comment: Inserting Sample Data for availability
*/
PRINT '' PRINT '*** Insert Into Availability Table ***'
GO
INSERT INTO [dbo].[availability]
	([UserID], [DayOfWeek], [StartTime], [EndTime])
	VALUES
	(100002, 'Friday', '08:00:00','22:00:00'),
	(100000, 'Friday', '14:00:00','22:00:00')
GO

/*
Created by: Kaleb Bachert
Date: 4/10/2020
Comment: Inserting Sample Data for ScheduleHours
*/
PRINT '' PRINT '*** Insert Into ScheduleHours Table ***'
GO
INSERT INTO [dbo].[ScheduleHours]
	([ScheduleID], [UserID], [HoursFirstWeek], [HoursSecondWeek])
	VALUES
	(1000000, 100002, 1, 2),
	(1000001, 100002, 40, 0)
GO

/*
Created by: Matt Deaton
Date: 2020-04-16
Comment: Sample Application Data
*/
PRINT '' PRINT '*** Inserting Sample Application Data Records'
GO
INSERT INTO [dbo].[Application]
		([ApplicantID], [JobListingID], [SubmissionDate], [Status])
	VALUES
		(100000, 100004, '20200207 08:55:01 AM', 'Pending Home Check'),
		(100001, 100003, '20200207 09:55:01 AM', 'Pending Interview'),
		(100002, 100005, '20200207 10:55:01 AM', 'Pending Interview'),
		(100003, 100001, '20200207 11:55:01 AM', 'Declined'),
		(100004, 100000, '20200207 12:55:01 PM', 'Approved'),
		(100005, 100000, '20200207 01:55:01 PM', 'Approved'),
		(100006, 100002, '20200207 02:55:01 PM', 'Check Notes')
GO

/*
Created by: Matt Deaton
Date: 2020-04-16
Comment: Sample ApplicationEducation Data
*/
PRINT '' PRINT '*** Inserting Sample ApplicationEducation Data Records'
GO
INSERT INTO [dbo].[ApplicationEducation]
		([ApplicationID], [SchoolName], [City], [State], [LevelAchieved])
	VALUES
		(100000, 'New City High', 'New City', 'NY', 'Diploma'),
		(100001, 'Kirkwood Community College', 'Iowa City', 'IA', 'Degree'),
		(100002, 'Oakland City High', 'Oakland', 'CA', 'Diploma'),
		(100003, 'Newton Senior High School', 'Newton', 'IA', 'Diploma'),
		(100004, 'New City High', 'New City', 'AL', 'Diploma'),
		(100005, 'New City High', 'New City', 'WA', 'Diploma'),
		(100006, 'Kirkwood Community College', 'Cedar Rapids', 'IA', 'Associates Degree')
GO

/*
Created by: Matt Deaton
Date: 2020-04-16
Comment: Sample ApplicationReference Data
*/
PRINT '' PRINT '*** Inserting Sample ApplicationReference Data Records'
GO
INSERT INTO [dbo].[ApplicationReference]
		([ReferenceID], [ApplicationID], [PhoneNumber], [EmailAddress], [Relationship])
	VALUES
		('Bob Trapp', 100000, '15637920291', 'bobbytrapp@infotech.com', 'Professor'),
		('Jeff Lebowski', 100001, '15637920292', 'thedude@aol.com', 'Bowling Coach'),
		('Arnold Palmer', 100002, '15637920293', 'lemonadeandtea@msn.com', 'Friend'),
		('Bill Nye', 100003, '15637920294', 'billnyethescienceguy@sciencerules.com', 'Mentor'),
		('Jim Glasgow', 100004, '15637920295', 'jim.glasgow@infotech.com', 'Professor'),
		('Derek Taylor', 100005, '15637920296', 'derektaylor@msn.com', 'Classmate'),
		('Charles Kwaitkowski', 100006, '13193920297', 'quitecowski@msn.com', 'Mentor')
GO

/*
Created by: Matt Deaton
Date: 2020-04-16
Comment: Sample ApplicationReference Data
*/
PRINT '' PRINT '*** Inserting Sample ApplicationReference Data Records'
GO
INSERT INTO [dbo].[ApplicationResume]
		([ApplicationID], [FilePath])
	VALUES
	(100000, 'derek_taylor_resume.doc'),
	(100001, 'ryan_morganti_resume.doc'),
	(100002, 'steven_coonrod_resume.doc'),
	(100003, 'matt_deaton_resume.doc'),
	(100004, 'hassan_karar_resume.doc'),
	(100005, 'gabrielle_legrande_resume.doc'),
	(100006, 'michael_thompson_resume.doc')
GO

/*
Created by: Matt Deaton
Date: 2020-04-16
Comment: Sample ApplicationSkill Data
*/
PRINT '' PRINT '*** Inserting Sample ApplicationSkill Data Records'
GO
INSERT INTO [dbo].[ApplicationSkill]
		([ApplicationSkillID], [ApplicationID], [Description])
	VALUES
	('Dog Owner', 100000, 'Already owns at least one dog'),
	('Stock Experience', 100001, 'Shelf stock experience'),
	('Groom Experience', 100002, 'Pet grooming experience'),
	('No Experience', 100003, 'No animal experience'),
	('Animal Walking Experience', 100004, 'Can walk animals'),
	('Animal Walking Experience', 100005, 'Can walk animals'),
	('Groom Experience', 100006, 'Pet grooming expert')
GO

/*
Created by: Matt Deaton
Date: 2020-04-16
Comment: Sample PreviousExperience Data
*/
PRINT '' PRINT '*** Inserting Sample PreviousExperience Data Records'
GO
INSERT INTO [dbo].[PreviousExperience]
		([ApplicationID], [PreviousWorkName], [City], [State], [Type])
	VALUES
		(100000, 'Petco', 'New City', 'NY', 'Associate'),
		(100001, 'Pioneer Coop', 'Iowa City', 'IA', 'Grocer'),
		(100002, 'Petco', 'Oakland', 'CA', 'Associate'),
		(100003, 'Student', 'Newton', 'IA', 'Student'),
		(100004, 'Student', 'New City', 'AL', 'Student'),
		(100005, 'Student', 'New City', 'WA', 'Student'),
		(100006, 'Pet Smart', 'Cedar Rapids', 'IA', 'Groomer Expert')
GO

/*
Created by: Matt Deaton
Date: 2020-04-16
Comment: Sample Home Check Data
*/
PRINT '' PRINT '*** Inserting Sample HomeCheck Data Records'
GO
INSERT INTO [dbo].[HomeCheck]
		([ApplicationID], [EmployeeID], [DatePerformed], [Notes])
	VALUES
	(100000, 100000, NULL, NULL),
	(100001, 100000, NULL, NULL),
	(100002, 100000, '20200207 01:55:01 PM', 'No Notes'),
	(100003, 100000, NULL, NULL),
	(100004, 100000, NULL, NULL),
	(100005, 100000, NULL, NULL),
	(100006, 100000, NULL, NULL)
GO

/*
Created by: Matt Deaton
Date: 2020-04-16
Comment: Sample Interview Data
*/
PRINT '' PRINT '*** Inserting Sample Interview Data Records'
GO
INSERT INTO [dbo].[Interview]
		([ApplicationID], [EmployeeID], [DatePerformed], [Notes])
	VALUES	
		(100000, 100000, '20200207 01:55:01 PM', 'Great feneced yard. One other dog.'),
		(100001, 100000, '20200207 01:55:01 PM', ''),
		(100002, 100000, '20200207 01:55:01 PM', ''),
		(100003, 100000, '20200207 01:55:01 PM', 'No Experience, wanted too much money.'),
		(100004, 100000, '20200207 01:55:01 PM', 'Great Applicant. Will Hire for walking dogs.'),
		(100005, 100000, '20200207 01:55:01 PM', 'Great Applicant. Will Hire for walking dogs.'),
		(100006, 100000, '20200207 01:55:01 PM', 'Great Applicant, but need to check references.')
GO

-- End of file