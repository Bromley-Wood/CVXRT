-- Script Date: 18/02/2020 4:22 PM  - ErikEJ.SqlCeScripting version 3.5.2.80
SELECT 1;
PRAGMA foreign_keys=OFF;
-- BEGIN TRANSACTION;
CREATE TABLE [tst_Route_Call] (
  [PK_CallId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Call_No] int NOT NULL
, [FK_RouteId] int NOT NULL
, [Labour_Hours] float NOT NULL
, [Plan_Date] datetime NOT NULL
, [Schedule_Date] datetime NOT NULL
, [Modified_Date] datetime NULL
, [Modified_By] nvarchar(32) NULL COLLATE NOCASE
, [Complete_Date] datetime NULL
);
CREATE TABLE [tst_Report] (
  [PK_ReportId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [FK_FaultId] int NOT NULL
, [Report_Date] datetime NULL
, [Measurement_Date] datetime NULL
, [FK_ConditionId] int NOT NULL
, [FK_ReportTypeId] int NOT NULL
, [FK_ReportStageId] int NULL
, [Observations] nvarchar(2500) NULL COLLATE NOCASE
, [Actions] nvarchar(2500) NULL COLLATE NOCASE
, [Analyst_Notes] ntext NULL
, [External_Notes] nvarchar(1000) NULL COLLATE NOCASE
, [Notification_No] int NULL
, [Work_Order_No] int NULL
, [Review_Comments] nvarchar(2500) NULL COLLATE NOCASE
, [Analyst_Name] nvarchar(100) NULL COLLATE NOCASE
, [Reviewer_Name] nvarchar(100) NULL COLLATE NOCASE
, [Report_IsActive] bit NOT NULL
, [Origin_CallId] int NULL
);
CREATE TABLE [tst_Fault] (
  [PK_FaultId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [FK_MachineTrainId] int NOT NULL
, [FK_PrimaryComponentTypeId] int NULL
, [FK_PrimaryComponentSubtypeId] int NULL
, [FK_TechnologyId] int NOT NULL
, [FK_FaultTypeId] int NULL
, [FK_FaultSubtypeId] int NULL
, [Create_Date] datetime NOT NULL
, [Close_Date] datetime NULL
, [Fault_Location] nvarchar(50) NULL COLLATE NOCASE
, [Production_Impact_Cost] float NULL
, [Fault_IsActive] bit NOT NULL
, [Closure_Comment] nvarchar(255) NULL COLLATE NOCASE
);
CREATE TABLE [temp_Reports] (
  [Greater_Area] nvarchar(32) NULL
, [Area] nvarchar(64) NULL COLLATE NOCASE
, [Driven_Unit_Type] nvarchar(50) NULL COLLATE NOCASE
, [Condition] nvarchar(32) NULL COLLATE NOCASE
, [Condition_Magnitude] tinyint NULL
, [Actions] nvarchar(2500) NULL COLLATE NOCASE
, [Analyst_Notes] ntext NULL
, [External_Notes] nvarchar(1000) NULL COLLATE NOCASE
, [Machine_Train] nvarchar(32) NULL COLLATE NOCASE
, [Machine_Train_Long_Name] nvarchar(255) NULL COLLATE NOCASE
, [Route] nvarchar(255) NULL COLLATE NOCASE
, [Cycle_Days] float NULL
, [FaultTypeId] int NOT NULL
, [Fault_Type] nvarchar(50) NULL COLLATE NOCASE
, [Fault_IsActive] bit NOT NULL
, [Status] nvarchar(6) NOT NULL COLLATE NOCASE
, [ReportId] int NULL
, [Report_Date] datetime NULL
, [Measurement_Date] datetime NULL
, [Report_Type] nvarchar(50) NULL COLLATE NOCASE
, [Report_Stage] nvarchar(50) NULL COLLATE NOCASE
);
CREATE TABLE [Technology] (
  [PK_TechnologyId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Technology] nvarchar(50) NOT NULL COLLATE NOCASE
);
CREATE TABLE [Site] (
  [PK_SiteId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Site] nvarchar(50) NOT NULL COLLATE NOCASE
, [Site_IsActive] bit NOT NULL
);
CREATE TABLE [Route_Call] (
  [PK_CallId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Call_No] int NOT NULL
, [FK_RouteId] int NOT NULL
, [Labour_Hours] float NOT NULL
, [Plan_Date] datetime NOT NULL
, [Schedule_Date] datetime NOT NULL
, [Modified_Date] datetime NULL
, [Modified_By] nvarchar(32) NULL COLLATE NOCASE
, [Complete_Date] datetime NULL
);
CREATE TABLE [Route] (
  [PK_RouteId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Route] nvarchar(255) NOT NULL COLLATE NOCASE
, [Module_Code] nvarchar(16) NULL COLLATE NOCASE
, [Unit] nvarchar(16) NULL COLLATE NOCASE
, [Cycle_Days] float NULL
, [Labour_Hours] float NULL
, [First_Call_Date] datetime NULL
, [FK_AreaId] int NOT NULL
, [Route_IsActive] bit NOT NULL
);
CREATE TABLE [Report_Type] (
  [PK_ReportTypeId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Report_Type] nvarchar(50) NOT NULL COLLATE NOCASE
);
CREATE TABLE [Report_Stage] (
  [PK_ReportStageId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Report_Stage] nvarchar(50) NOT NULL COLLATE NOCASE
);
CREATE TABLE [Report_Files] (
  [PK_FilePathId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [FK_ReportId] int NOT NULL
, [FileName] ntext NOT NULL
, [Upload_Date] datetime NOT NULL
, [Uploaded_By] nvarchar(50) NOT NULL COLLATE NOCASE
);
CREATE TABLE [Report] (
  [PK_ReportId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [FK_FaultId] int NOT NULL
, [Report_Date] datetime NULL
, [Measurement_Date] datetime NULL
, [FK_ConditionId] int NOT NULL
, [FK_ReportTypeId] int NOT NULL
, [FK_ReportStageId] int NULL
, [Observations] nvarchar(2500) NULL COLLATE NOCASE
, [Actions] nvarchar(2500) NULL COLLATE NOCASE
, [Analyst_Notes] ntext NULL
, [External_Notes] nvarchar(1000) NULL COLLATE NOCASE
, [Notification_No] int NULL
, [Work_Order_No] int NULL
, [Review_Comments] nvarchar(2500) NULL COLLATE NOCASE
, [Analyst_Name] nvarchar(100) NULL COLLATE NOCASE
, [Reviewer_Name] nvarchar(100) NULL COLLATE NOCASE
, [Report_IsActive] bit DEFAULT 1 NOT NULL
, [Origin_CallId] int NULL
);
CREATE TABLE [Primary_Component_Type] (
  [PK_PrimaryComponentTypeId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Primary_Component_Type] nvarchar(50) NOT NULL COLLATE NOCASE
, [PrimaryComponentType_IsActive] bit NOT NULL
);
CREATE TABLE [Primary_Component_Subtype] (
  [PK_PrimaryComponentSubtypeId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Primary_Component_Subtype] nvarchar(50) NOT NULL COLLATE NOCASE
, [PrimaryComponentSubtype_IsActive] bit NOT NULL
, [FK_PrimaryComponentTypeId] int NOT NULL
);
CREATE TABLE [Observation_Type] (
  [PK_ObservationTypeId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Observation_Type] nvarchar(80) NOT NULL COLLATE NOCASE
);
CREATE TABLE [Observation] (
  [PK_ObservationId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Observation] nvarchar(255) NOT NULL COLLATE NOCASE
, [FK_ObservationTypeId] int NOT NULL
);
CREATE TABLE [Missed_Survey] (
  [PK_MissedSurveyId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [FK_MachineTrainId] int NOT NULL
, [Reason] nvarchar(255) NOT NULL COLLATE NOCASE
, [Comments] nvarchar(500) NULL COLLATE NOCASE
, [Reported_Missed_Date] datetime NULL
, [Reported_Missed_By] nvarchar(100) NOT NULL COLLATE NOCASE
, [Origin_CallId] int NULL
);
CREATE TABLE [Machine_Train_Notes] (
  [PK_MachineTrainNoteId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [MachineTrain_Note] ntext NOT NULL
, [Note_Date] datetime NOT NULL
, [MachineTrainNote_IsActive] bit NOT NULL
, [FK_MachineTrainId] int NOT NULL
, [MachineTrainNote_ShowOnReport] bit NOT NULL
, [Analyst_Name] nvarchar(50) NOT NULL COLLATE NOCASE
);
CREATE TABLE [Machine_Train_Files] (
  [PK_FilePathId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [FK_MachineTrainId] int NOT NULL
, [FileName] ntext NOT NULL
, [Upload_Date] datetime NOT NULL
, [Uploaded_By] nvarchar(50) NOT NULL COLLATE NOCASE
);
CREATE TABLE [Machine_Train] (
  [PK_MachineTrainId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Machine_Train] nvarchar(32) NOT NULL COLLATE NOCASE
, [Machine_Train_Long_Name] nvarchar(255) NOT NULL COLLATE NOCASE
, [FK_DrivenUnitTypeId] int NOT NULL
, [FK_AreaId] int NOT NULL
, [FK_RouteId] int NULL
, [MachineTrain_IsActive] bit NOT NULL
);
CREATE TABLE [Fault_Type] (
  [PK_FaultTypeId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Fault_Type] nvarchar(50) NOT NULL COLLATE NOCASE
, [FK_TechnologyId] int NOT NULL
);
CREATE TABLE [Fault_Subtype] (
  [PK_FaultSubtypeId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Fault_Subtype] nvarchar(200) NOT NULL COLLATE NOCASE
, [FK_FaultTypeId] int NOT NULL
);
CREATE TABLE [Fault] (
  [PK_FaultId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [FK_MachineTrainId] int NOT NULL
, [FK_PrimaryComponentTypeId] int NULL
, [FK_PrimaryComponentSubtypeId] int NULL
, [FK_TechnologyId] int NOT NULL
, [FK_FaultTypeId] int NULL
, [FK_FaultSubtypeId] int NULL
, [Create_Date] datetime NOT NULL
, [Close_Date] datetime NULL
, [Fault_Location] nvarchar(50) NULL COLLATE NOCASE
, [Production_Impact_Cost] float NULL
, [Fault_IsActive] bit NOT NULL
, [Closure_Comment] nvarchar(255) NULL COLLATE NOCASE
);
CREATE TABLE [Driven_Unit_Type] (
  [PK_DrivenUnitTypeId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Driven_Unit_Type] nvarchar(50) NOT NULL COLLATE NOCASE
, [DrivenUnitType_IsActive] bit NOT NULL
);
CREATE TABLE [dim_Date] (
  [DateKey] int NOT NULL
, [Date] datetime NOT NULL
, [Day] tinyint NOT NULL
, [DaySuffix] nchar(2) NOT NULL COLLATE NOCASE
, [Weekday] tinyint NOT NULL
, [WeekDayName] nvarchar(10) NOT NULL COLLATE NOCASE
, [ISOWeekOfYear] tinyint NOT NULL
, [Month] tinyint NOT NULL
, [MonthName] nvarchar(10) NOT NULL COLLATE NOCASE
, [Quarter] tinyint NOT NULL
, [Year] int NOT NULL
, CONSTRAINT [PK__dim_Date__40DF45E356BE0DBF] PRIMARY KEY ([DateKey])
);
CREATE TABLE [Condition] (
  [PK_ConditionId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Condition] nvarchar(32) NOT NULL COLLATE NOCASE
, [Condition_Magnitude] tinyint NOT NULL
, [Condition_Alt_Label] nvarchar(32) NULL COLLATE NOCASE
);
CREATE TABLE [Area] (
  [PK_AreaId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Area] nvarchar(64) NOT NULL COLLATE NOCASE
, [Unit_Reference] nvarchar(4) NULL COLLATE NOCASE
, [Greater_Area] nvarchar(32) NOT NULL COLLATE NOCASE
, [Area_IsActive] bit NOT NULL
, [FK_SiteId] int NOT NULL
);
CREATE TABLE [Action] (
  [PK_ActionId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Action] nvarchar(100) NOT NULL COLLATE NOCASE
, [FK_FaultTypeId] int NOT NULL
, [Action_IsActive] bit DEFAULT 1 NOT NULL
, [Action_Order] int NOT NULL
);
COMMIT;

