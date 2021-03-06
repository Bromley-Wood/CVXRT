USE [TestDb]
GO

/****** Report Characteristics ******/
/****** ************************************/

/****** Object:  Table [dbo].[Technology]    Script Date: 20/11/2019 7:24:46 AM ******/

CREATE TABLE [dbo].[Technology](
	[PK_TechnologyId] [int] IDENTITY(1,1) NOT NULL,
	[Technology] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Technology] PRIMARY KEY CLUSTERED 
(
	[PK_TechnologyId] ASC)
) 
GO


/****** Object:  Table [dbo].[Fault_Type]    Script Date: 20/11/2019 7:24:46 AM ******/

CREATE TABLE [dbo].[Fault_Type](
	[PK_FaultTypeId] [int] IDENTITY(1,1) NOT NULL,
	[FaultType] [nvarchar](50) NOT NULL,
	--[FaultType_IsActive] [bit] NOT NULL,
	[FK_TechnologyId] [int] NOT NULL,
 CONSTRAINT [PK_Fault_Type] PRIMARY KEY CLUSTERED 
(
	[PK_FaultTypeId] ASC)
) 
GO


/****** Object:  Table [dbo].[Fault_Subtype]    Script Date: 20/11/2019 7:24:46 AM ******/

CREATE TABLE [dbo].[Fault_Subtype](
	[PK_FaultSubtypeId] [int] IDENTITY(1,1) NOT NULL,
	[Fault_Subtype] [nvarchar](200) NOT NULL,
	[FK_FaultTypeId] [int] NOT NULL,
	--[FaultSubtype_IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_FaultSubtypeId] PRIMARY KEY CLUSTERED 
(
	[PK_FaultSubtypeId] ASC)
) 
GO


/****** Object:  Table [dbo].[Action]    Script Date: 20/11/2019 7:24:45 AM ******/

CREATE TABLE [dbo].[Action](
	[PK_ActionId] [int] IDENTITY(1,1) NOT NULL,
	[Action] [nvarchar](100) NOT NULL,
	[Action_Order] [int] NOT NULL,	
	[FK_FaultTypeId] [int] NOT NULL,
	[Action_IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Action] PRIMARY KEY CLUSTERED 
(
	[PK_ActionId] ASC)
) 
GO


/****** Object:  Table [dbo].[Observation_Type]    Script Date: 20/11/2019 7:24:46 AM ******/

CREATE TABLE [dbo].[Observation_Type](
	[FK_ObservationTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Observation_Type] [nvarchar](80) NOT NULL,
	--[ObservType_IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Observation_Type] PRIMARY KEY CLUSTERED 
(
	[FK_ObservationTypeId] ASC)
) 
GO


/****** Object:  Table [dbo].[Observation]    Script Date: 20/11/2019 7:24:46 AM ******/

CREATE TABLE [dbo].[Observation](
	[PK_ObservationId] [int] IDENTITY(1,1) NOT NULL,
	[Observation] [nvarchar](255) NOT NULL,
	[FK_ObservationTypeId] [int] NOT NULL,
	--[Observation_IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Observation] PRIMARY KEY CLUSTERED 
(
	[PK_ObservationId] ASC)
) 
GO



/****** Object:  Table [dbo].[Condition]    Script Date: 20/11/2019 7:24:46 AM ******/

CREATE TABLE [dbo].[Condition](
	[PK_ConditionId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Condition] [nvarchar](32) NOT NULL,
	[Condition_Magnitude] [tinyint] NOT NULL,
	[Condition_Alt_Label] [nvarchar](32) NULL,
 CONSTRAINT [PK_Condition] PRIMARY KEY CLUSTERED 
(
	[PK_ConditionId] ASC)
) 
GO

/****** Object:  Table [dbo].[Report_Type]    Script Date: 20/11/2019 7:24:46 AM ******/

CREATE TABLE [dbo].[Report_Type](
	[PK_ReportTypeId] [tinyint]  IDENTITY(1,1) NOT NULL,
	[Report_Type] [nvarchar](50) NOT NULL,
	--[ReportType_IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Report_Type] PRIMARY KEY CLUSTERED 
(
	[PK_ReportTypeId] ASC)
) 
GO

/****** Object:  Table [dbo].[Report_Stage]    Script Date: 20/11/2019 7:24:46 AM ******/

CREATE TABLE [dbo].[Report_Stage](
	[PK_ReportStageId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Report_Stage] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Report_Stage] PRIMARY KEY CLUSTERED 
(
	[PK_ReportStageId] ASC)
) 
GO

/****** Asset Hierarchy Related ******/
/*******************************************/

CREATE TABLE [dbo].[Site](
	[PK_SiteId] [int] IDENTITY(1,1) NOT NULL,
	[Site] [nvarchar](50) NOT NULL,
	[Site_IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED 
(
	[PK_SiteId] ASC)
) 
GO


/****** Object:  Table [dbo].[Driven_Unit_Type]    Script Date: 20/11/2019 7:24:46 AM ******/

CREATE TABLE [dbo].[Driven_Unit_Type](
	[PK_DrivenUnitTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Driven_Unit_Type] [nvarchar](50) NOT NULL,
	[DrivenUnitType_IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Driven_Unit_Type] PRIMARY KEY CLUSTERED 
(
	[PK_DrivenUnitTypeId] ASC)
) 
GO


/****** Object:  Table [dbo].[Area]    Script Date: 20/11/2019 7:24:45 AM ******/

CREATE TABLE [dbo].[Area](
	[PK_AreaId] [int] IDENTITY(1,1) NOT NULL,
	[Area] [nvarchar](64) NOT NULL,
	[Unit_Reference] [nvarchar](4),	
	[Greater_Area] [nvarchar](32) NOT NULL,	
	[Area_IsActive] [bit] NOT NULL,
	[FK_SiteId] [int] NOT NULL,	
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[PK_AreaId] ASC)
) 
GO


/****** Object:  Table [dbo].[Machine_Train]    Script Date: 20/11/2019 7:24:46 AM ******/

CREATE TABLE [dbo].[Machine_Train](
	[PK_MachineTrainId] [int] IDENTITY(1,1) NOT NULL,
	[Machine_Train] [nvarchar](32) NOT NULL,
	[Machine_Train_Long_Name] [nvarchar](255) NOT NULL,	
	[FK_DrivenUnitTypeId] [int] NOT NULL,	
	[FK_AreaId] [int] NOT NULL,
	[FK_RouteId] [int], -- A Machine Train doesn't have to be allocated to a Route
	[MachineTrain_IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_MachineTrain] PRIMARY KEY CLUSTERED 
(
	[PK_MachineTrainId] ASC)
) 
GO

/****** Object:  Table [dbo].[Primary_Component_Type]    Script Date: 20/11/2019 7:24:46 AM ******/


CREATE TABLE [dbo].[Primary_Component_Type](
	[PK_PrimaryComponentTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Primary_Component_Type] [nvarchar](50) NOT NULL,
	[PrimaryComponentType_IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Primary_Component_Type] PRIMARY KEY CLUSTERED 
(
	[PK_PrimaryComponentTypeId] ASC)
) 
GO


/****** Object:  Table [dbo].[Primary_Component_Subtype]    Script Date: 20/11/2019 7:24:46 AM ******/


CREATE TABLE [dbo].[Primary_Component_Subtype](
	[PK_PrimaryComponentSubtypeId] [int] IDENTITY(1,1) NOT NULL,
	[Primary_Component_Subtype] [nvarchar](50) NOT NULL,
	[PrimaryComponentSubtype_IsActive] [bit] NOT NULL,
	[FK_PrimaryComponentTypeId] [int]  NOT NULL,	
	
	
 CONSTRAINT [PK_Primary_Component_Subtype] PRIMARY KEY CLUSTERED 
(
	[PK_PrimaryComponentSubtypeId] ASC)
) 
GO




/****** Object:  Table [dbo].[Primary_Component]    Script Date: 20/11/2019 7:24:46 AM ******/

/* ---- Not implemented at this stage
CREATE TABLE [dbo].[Primary_Component](
	[PK_PrimCompId] [int] IDENTITY(1,1) NOT NULL,
	[Primary_Component] [nvarchar](50) NOT NULL,
	[PrimComp_IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Primary_Component] PRIMARY KEY CLUSTERED 
(
	[PK_PrimCompId] ASC)
) 
GO
*/ 



/****** Scheduled Routes ******/
/****** ************************************/

/****** Object:  Table [dbo].[Route]    Script Date: 20/11/2019 7:24:45 AM ******/

CREATE TABLE [dbo].[Route](
	[PK_RouteId] [int] IDENTITY(1,1) NOT NULL,
	[Route] [nvarchar](255) NOT NULL,
	[Module_Code] [nvarchar](16),	
	[Unit] [nvarchar](16),	
	[Cycle_Days] [float],
	[Labour_Hours] [float],
	[First_Call_Date] [date],	
	[FK_AreaId] [int] NOT NULL,	
	[Route_IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED 
(
	[PK_RouteId] ASC)
) 
GO

/****** Object:  Table [dbo].[Route_Calls]    Script Date: 20/11/2019 7:24:45 AM ******/

CREATE TABLE [dbo].[Route_Call](
	[PK_CallId] [int] IDENTITY(1,1) NOT NULL,
	[Call_No] [int] NOT NULL,
	[FK_RouteId] [int] NOT NULL,
	[Labour_Hours] [float]  NOT NULL,
	[Plan_Date] [date]  NOT NULL,
	[Schedule_Date] [date]  NOT NULL,
	[Modified_Date] [datetime] NULL,
	[Modified_By] [nvarchar](32) NULL,
	[Complete_Date] [datetime] NULL,
 CONSTRAINT [PK_Route_Call] PRIMARY KEY CLUSTERED 
(
	[PK_CallId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** EXECUTABLE:  Generate Calls ******/
use DEV_ClientProject 
go

DECLARE @i int = 0

WHILE @i < 20
BEGIN
	  insert into [Route_Call] (Call_No, FK_RouteID, Labour_Hours,Plan_Date, Schedule_Date)
  	  SELECT 
			@i as [Call_No] 
		  ,[PK_RouteId] as [FK_RouteId]
		  ,[Labour_Hours]
		  ,DATEADD(day, [Cycle_Days]*@i, [First_Call_Date]) AS [Plan_Date]
		  ,DATEADD(day, [Cycle_Days]*@i, [First_Call_Date]) AS [Schedule_Date]		  
	  FROM [DEV_ClientProject].[dbo].[Route]
	  where [Route_IsActive] = 1 
      SET @i = @i + 1
END




/****** Reports ******/
/*******************************************/


CREATE TABLE [dbo].[Fault](
	[PK_FaultId] [int] IDENTITY(1,1) NOT NULL,
	[FK_MachineTrainId] [int] NOT NULL,
	[FK_PrimaryComponentTypeId] [int] NULL, -- allow nulls for fault creation
	[FK_PrimaryComponentSubtypeId] [int], -- allow nulls on subtype
	[FK_TechnologyId] [int] NOT NULL,		
	[FK_FaultTypeId] [int] NULL, -- allow nulls for fault creation
	[FK_FaultSubtypeId] [int],	 -- allow nulls on subtype
	[Create_Date] [datetime] NOT NULL,
	[Close_Date] [datetime] NULL,
	[Fault_Location] [nvarchar](50) NULL,	
	[Production_Impact_Cost] [float] null,
	[Closure_Comment] [NVARCHAR] (255) NULL,
	[Fault_IsActive] [bit] NOT NULL,
	[Status]  AS (case when [Close_Date] IS NOT NULL then 'Closed' else 'Open' end),
 CONSTRAINT [PK_Fault] PRIMARY KEY CLUSTERED 
(
	[PK_FaultId] ASC)
) 
GO


/****** Object:  Table [dbo].[Report]    Script Date: 20/11/2019 7:24:46 AM ******/


CREATE TABLE [dbo].[Report](
	[PK_ReportId] [int] IDENTITY(1,1) NOT NULL,
	[FK_FaultId] [int] NOT NULL,
	[Report_Date] [date] NULL,
	[Measurement_Date] [date] NULL,	
	[FK_ConditionId] [int] NOT NULL,
	[FK_ReportTypeId] [int] NOT NULL,
	[FK_ReportStageId] [int] NULL,	
	[Observations] [nvarchar](2500) NULL,	
	[Actions] [nvarchar](2500) NULL,
	[Analyst_Notes] [nvarchar](max) NULL,	
	[External_Notes] [nvarchar](1000) NULL,	
	[Notification_No] [int] NULL,
	[Work_Order_No] [int] NULL,
	[Review_Comments] [nvarchar](2500) NULL,
	[Analyst_Name] [nvarchar](100) NULL,
	[Reviewer_Name] [nvarchar](100) NULL,
	[Report_IsActive] [bit] NOT NULL
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[PK_ReportId] ASC)
)  
GO


/****** Other Functions ******/
/*******************************************/

/****** Object:  Table [dbo].[Machine_Notes]    Script Date: 20/11/2019 7:24:46 AM ******/


CREATE TABLE [dbo].[Machine_Train_Notes](
	[PK_MachineTrainNoteId] [int] IDENTITY(1,1) NOT NULL,
	[MachineTrain_Note] [nvarchar](max) NOT NULL,
	[Note_Date] [datetime] NOT NULL,
	[MachineTrainNote_IsActive] [bit] NOT NULL,
	[FK_MachineTrainId] [int] NOT NULL,
	[MachineTrainNote_ShowOnReport] [bit] NOT NULL,
	[Analyst_Name] [nvarchar](50) NOT NULL,
	[Production_Impact_Code] null,
 CONSTRAINT [PK_Machine_Train_Notes] PRIMARY KEY CLUSTERED 
(
	[PK_MachineNoteId] ASC)
)  
GO


/****** Object:  Table [dbo].[Missed_Survey]    Script Date: 20/11/2019 7:24:46 AM ******/


CREATE TABLE [dbo].[Missed_Survey](
	[PK_MissedSurveyId] [int] IDENTITY(1,1) NOT NULL,
	[FK_MachineTrainId] [int] NOT NULL,	
	[Reason] [nvarchar](255) NOT NULL,	
	[Comments] [nvarchar](500) NULL,
	[Reported_Missed_Date] [date] NULL,
	[Reported_Missed_By] [nvarchar](100) NOT NULL
 CONSTRAINT [PK_MissedSurveyId] PRIMARY KEY CLUSTERED 
(
	[PK_MissedSurveyId] ASC)
)  
GO



/****** EXECUTABLE:  Generate Calendar 
	this is used to generate the calendar for any trend plots ******/

Use DEV_ClientProject
Go

SET DATEFIRST 1;
GO
--SET DATEFORMAT ymd;
--SET LANGUAGE UK_ENGLISH;

-- create interim table 

CREATE TABLE dbo.dim_date_interim
(
  [date]       DATE PRIMARY KEY, 
  [day]        AS DATEPART(DAY,      [date]),
  [month]      AS DATEPART(MONTH,    [date]),
  FirstOfMonth AS CONVERT(DATE, DATEADD(MONTH, DATEDIFF(MONTH, 0, [date]), 0)),
  [MonthName]  AS DATENAME(MONTH,    [date]),
  [week]       AS DATEPART(WEEK,     [date]),
  [ISOweek]    AS DATEPART(ISO_WEEK, [date]),
  [DayOfWeek]  AS DATEPART(WEEKDAY,  [date]),
  [quarter]    AS DATEPART(QUARTER,  [date]),
  [year]       AS DATEPART(YEAR,     [date]),
  FirstOfYear  AS CONVERT(DATE, DATEADD(YEAR,  DATEDIFF(YEAR,  0, [date]), 0)),
  Style112     AS CONVERT(CHAR(8),   [date], 112),
  Style103     AS CONVERT(CHAR(10),  [date], 103)
);

DECLARE @StartDate DATE = '20100101', @NumberOfYears INT = 25;
DECLARE @CutoffDate DATE = DATEADD(YEAR, @NumberOfYears, @StartDate);

INSERT dim_date_interim([date]) 
  SELECT d = DATEADD(DAY, rn - 1, @StartDate)
  FROM 
  (
    SELECT TOP (DATEDIFF(DAY, @StartDate, @CutoffDate)) 
      rn = ROW_NUMBER() OVER (ORDER BY s1.[object_id])
    FROM sys.all_objects AS s1
    CROSS JOIN sys.all_objects AS s2
    -- generate many days
    ORDER BY s1.[object_id]
  ) AS x;


-- create calendar table 
CREATE TABLE [dbo].[dim_Date](
	[DateKey] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Day] [tinyint] NOT NULL,
	[DaySuffix] [char](2) NOT NULL,
	[Weekday] [tinyint] NOT NULL,
	[WeekDayName] [varchar](10) NOT NULL,
	[ISOWeekOfYear] [tinyint] NOT NULL,
	[Month] [tinyint] NOT NULL,
	[MonthName] [varchar](10) NOT NULL,
	[Quarter] [tinyint] NOT NULL,
	[Year] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DateKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Populate the calendar table 
INSERT dbo.dim_Date WITH (TABLOCKX)
SELECT
  DateKey     = CONVERT(INT, Style112),
  [Date]        = [date],
  [Day]         = CONVERT(TINYINT, [day]),
  DaySuffix     = CONVERT(CHAR(2), CASE WHEN [day] / 10 = 1 THEN 'th' ELSE 
                  CASE RIGHT([day], 1) WHEN '1' THEN 'st' WHEN '2' THEN 'nd' 
	              WHEN '3' THEN 'rd' ELSE 'th' END END),
  [Weekday]     = CONVERT(TINYINT, [DayOfWeek]),
  [WeekDayName] = CONVERT(VARCHAR(10), DATENAME(WEEKDAY, [date])),
 -- [IsWeekend]   = CONVERT(BIT, CASE WHEN [DayOfWeek] IN (1,7) THEN 1 ELSE 0 END),
  --[DOWInMonth]  = CONVERT(TINYINT, ROW_NUMBER() OVER (PARTITION BY FirstOfMonth, [DayOfWeek] ORDER BY [date])),
  --[DayOfYear]   = CONVERT(SMALLINT, DATEPART(DAYOFYEAR, [date])),
 -- WeekOfMonth   = CONVERT(TINYINT, DENSE_RANK() OVER  (PARTITION BY [year], [month] ORDER BY [week])),
  --WeekOfYear    = CONVERT(TINYINT, [week]),
  ISOWeekOfYear = CONVERT(TINYINT, ISOWeek),
  [Month]       = CONVERT(TINYINT, [month]),
  [MonthName]   = CONVERT(VARCHAR(10), [MonthName]),
  [Quarter]     = CONVERT(TINYINT, [quarter]),
  [Year]        = [year]
  --MMYYYY        = CONVERT(CHAR(6), LEFT(Style101, 2)    + LEFT(Style112, 4))
 -- MonthYear     = CONVERT(CHAR(7), LEFT([MonthName], 3) + LEFT(Style112, 4)),
 -- FirstDayOfMonth     = FirstOfMonth,
  --LastDayOfMonth      = MAX([date]) OVER (PARTITION BY [year], [month]),
  --FirstDayOfQuarter   = MIN([date]) OVER (PARTITION BY [year], [quarter]),
  --LastDayOfQuarter    = MAX([date]) OVER (PARTITION BY [year], [quarter]),
  --FirstDayOfYear      = FirstOfYear,
  --LastDayOfYear       = MAX([date]) OVER (PARTITION BY [year]),
 -- FirstDayOfNextMonth = DATEADD(MONTH, 1, FirstOfMonth),
  --FirstDayOfNextYear  = DATEADD(YEAR,  1, FirstOfYear)
FROM dim_date_interim
OPTION (MAXDOP 1);






/******------------------------------------------------- ******/
/******------------------------------------------------- ******/
/******------------------------------------------------- ******/

/****** View Creation ******/

/****** View to check what the latest report is ******/

create View [dbo].[V_Latest_Report_by_Fault] as 
SELECT [Report].[FK_FaultId]
      ,max( [Report].[Report_Date]) as [Latest_Report_Date_by_Fault]
	  ,1 as [IsLatestReport] 

  FROM [DEV_ClientProject].[dbo].[Report] 
  left join [Fault] on 
	[Fault].[PK_FaultId] = [Report].[FK_FaultId]
  where [Report].[FK_ReportStageId] = 4 --Released
  and [Report].[Report_IsActive] = 1 -- Active report
  and [Fault].[Fault_IsActive] = 1 -- Active report
  and [Fault].[Status] = 'Open' 
  group by 
		[Report].[FK_FaultId]


/****** Summary table for reports ******/
USE [DEV_ClientProject]
GO

/****** Object:  View [dbo].[V_Report_Summary]    Script Date: 31/01/2020 3:08:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





ALTER VIEW [dbo].[V_Report_Summary] as


SELECT [Fault].[PK_FaultId] as [FaultId]
	  ,[Area].[PK_AreaId] as [AreaId]
	  ,[Area].[Greater_Area]
	  ,[Area].[Unit_Reference]
	  ,[Area].[Area]
	  ,[Driven_Unit_Type].[PK_DrivenUnitTypeId] as [DrivenUnitTypeId]
	  ,[Driven_Unit_Type].[Driven_Unit_Type]
      ,[Fault].[FK_MachineTrainId] as [MachineTrainId]
	  ,[Machine_Train].[Machine_Train]
	  ,[Machine_Train].[Machine_Train_Long_Name]
	  ,[Route].[Route]
	  ,[Route].[Cycle_Days]
      ,[Primary_Component_Type].[PK_PrimaryComponentTypeId] as [PrimaryComponentTypeId]
	  ,[Primary_Component_Type].[Primary_Component_Type]
      ,[Primary_Component_Subtype].[PK_PrimaryComponentSubtypeId] as [PrimaryComponentSubtypeId]
	  ,[Primary_Component_Subtype].[Primary_Component_Subtype]
      ,[Fault].[FK_FaultTypeId] as [FaultTypeId]
	  ,[Fault_Type].[Fault_Type]
      ,[Fault_Subtype].[Fault_Subtype]
	  ,[Fault].[Create_Date]
      ,[Fault].[Close_Date]
      ,[Fault].[Fault_Location]
      ,[Fault].[Production_Impact_Cost]
      ,[Fault_IsActive]
	  ,[Fault].[Status]
	  ,[Report].[PK_ReportId] as [ReportId]
      ,[Report].[Report_Date]
      ,[Report].[Measurement_Date]
      --,[Report].[FK_ConditionId]
      ,[Condition].[Condition]
	  ,[Condition].[Condition_Magnitude]
      --,[Report].[FK_ReportTypeId]
	  ,[Report_Type].[Report_Type]
      --,[Report].[FK_ReportStageId]
	  ,[Report_Stage].[Report_Stage]
      ,[Report].[Observations]
      ,[Report].[Actions]
      ,[Report].[Analyst_Notes]
      ,[Report].[External_Notes]
      ,[Report].[Notification_No]
      ,[Report].[Work_Order_No]
      ,[Report].[Review_Comments]
      ,[Report].[Analyst_Name]
      ,[Report].[Reviewer_Name]
      ,[Report].[Report_IsActive]
	, FK_ConditionId - (LAG(FK_ConditionId, 1, NULL)  OVER 
    (PARTITION BY [Report].[FK_FaultId] ORDER BY [Report_Date] ASC))  AS Condition_Difference
	, case 
		when [Report_Date] is NULL then 'In Progress'
		when FK_ConditionId - (LAG(FK_ConditionId, 1, NULL)  OVER 
		(PARTITION BY [Report].[FK_FaultId] ORDER BY [Report_Date] ASC)) is NULL then 'New' 
		when FK_ConditionId - (LAG(FK_ConditionId, 1, NULL)  OVER 
		(PARTITION BY [Report].[FK_FaultId] ORDER BY [Report_Date] ASC)) =0 then 'Unchanged'
		when FK_ConditionId - (LAG(FK_ConditionId, 1, NULL)  OVER 
		(PARTITION BY [Report].[FK_FaultId] ORDER BY [Report_Date] ASC)) >0 then 'Increased'	
		when FK_ConditionId - (LAG(FK_ConditionId, 1, NULL)  OVER 
		(PARTITION BY [Report].[FK_FaultId] ORDER BY [Report_Date] ASC)) <0 then 'Improved'				
		else '??' End as Change_In_Condition
	,case when [Fault].[Status] = 'Open' and [V_Latest_Report_by_Fault].[IsLatestReport] = 1 then 1 else null end as [IsLatestReport]
	,[V_Latest_Report_by_Fault].[IsLatestReport] as [IsLastRecord] -- Includes both open and closed
  FROM (((((((((((([Fault] as [Fault]
  LEFT JOIN [Report] as [Report] on 
	[Report].[FK_FaultId] = [Fault].[PK_FaultId])
  LEFT JOIN [Machine_Train] on 
	[Machine_Train].[PK_MachineTrainId] = [Fault].[FK_MachineTrainId])
  LEFT JOIN [Route] on 
	[Route].[PK_RouteId] = [Machine_Train].[FK_RouteId])
  LEFT JOIN [Primary_Component_Type] on 
	[Primary_Component_Type].[PK_PrimaryComponentTypeId] = [Fault].[FK_PrimaryComponentTypeId])
  LEFT JOIN [Primary_Component_Subtype] on 
	[Primary_Component_Subtype].[PK_PrimaryComponentSubtypeId] = [Fault].[FK_PrimaryComponentSubtypeId])
  LEFT JOIN [Fault_Type] on 
	[Fault_Type].[PK_FaultTypeId] = [Fault].[FK_FaultTypeId])
  LEFT JOIN [Fault_Subtype] on 
	[Fault_Subtype].[PK_FaultSubtypeId] = [Fault].[FK_FaultSubtypeId])
  LEFT JOIN [Condition] on 
	[Condition].[PK_ConditionId] = [Report].[FK_ConditionId])
  LEFT JOIN [Report_Type] on 
	[Report_Type].PK_ReportTypeId = [Report].[FK_ReportTypeId])
  LEFT JOIN [Area] on 
	[Area].PK_AreaId = [Machine_Train].[FK_AreaId])
  LEFT JOIN [Driven_Unit_Type] on 
	[Driven_Unit_Type].PK_DrivenUnitTypeId = [Machine_Train].[FK_DrivenUnitTypeId])
  LEFT JOIN [Report_Stage] on 
	[Report_Stage].PK_ReportStageId = [Report].[FK_ReportStageId])
  LEFT JOIN [V_Latest_Report_by_Fault] on 
	 [V_Latest_Report_by_Fault].[Latest_Report_Date_by_Fault] = [Report].[Report_Date] 
	 and [V_Latest_Report_by_Fault].[FK_FaultId] = [Report].[FK_FaultId] 

where 
	[Area_IsActive] = 1  
	and [MachineTrain_IsActive] = 1
	and [Fault_IsActive] = 1
	and [Report_IsActive] = 1

GO





USE [DEV_ClientProject]
GO

/****** Object:  View [dbo].[V_Create_Reports]    Script Date: 29/01/2020 1:40:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








ALTER view [dbo].[V_Create_Reports] as

with Has_Record as (
select FK_MachineTrainId, PK_ReportId, null as PK_MissedSurveyId, Origin_CallId, 'Report' as Record 
from tst_Report rp
left join tst_Fault ft
	on ft.PK_FaultId = rp.FK_FaultId

union 
select FK_MachineTrainId, null as PK_ReportId,  PK_MissedSurveyId, Origin_CallId, 'Missed' as Record 
from Missed_Survey )

SELECT 
		[PK_RouteId]
      ,[Route].[Route]
      ,[Route].[Module_Code]
      ,[Route].[Unit]
      ,[Route].[Cycle_Days]
	  ,[Route_Call].[PK_CallId]
      ,[Route_Call].[Call_No]
      ,[Route_Call].[Labour_Hours]
      ,[Route_Call].[Plan_Date]
      ,[Route_Call].[Schedule_Date]
      ,[Route_Call].[Modified_Date]
      ,[Route_Call].[Modified_By]
	  ,[Route_Call].[Complete_Date]
	  ,[Machine_Train].[PK_MachineTrainId]
	  ,[Machine_Train].[Machine_Train]
	  ,[Machine_Train].[Machine_Train_Long_Name]
	  ,[Has_Record].Record
	  ,[RepSum].[FaultId]
      ,[RepSum].[Primary_Component_Type]
      ,[RepSum].[Fault_Type]
      ,[RepSum].[Create_Date]
      ,[RepSum].[Fault_Location]
      ,[RepSum].[ReportId]
      ,[RepSum].[Report_Date]
      ,[RepSum].[Measurement_Date]
      ,[RepSum].[Condition]
      ,[RepSum].[Actions]
      ,[RepSum].[Condition_Difference]
      ,[RepSum].[Change_In_Condition]
	  ,[RepSum].[Report_Stage]
	  ,[RepSum].Status
	  ,case when exists(select * from [V_tst_Report_Summary] where [V_tst_Report_Summary].Report_Stage = 'in progress' and [Machine_Train].[PK_MachineTrainId] = [V_tst_Report_Summary].MachineTrainId) then 1 else 0 end as HasReportInProgress

  FROM [DEV_ClientProject].[dbo].[tst_Route_Call] Route_Call
  left join [Route] on 
	[Route].[PK_RouteId] = [Route_Call].[FK_RouteId]
  left join  [Machine_Train]  on 
	[Route_Call].[FK_RouteId] = [Machine_Train].[FK_RouteId] 
 left join 
	(select * from [V_tst_Report_Summary]  where [IsLatestReport] = 1) RepSum on 
	[RepSum].[MachineTrainId]  = [Machine_Train].[PK_MachineTrainId]
left join Has_Record on
	Has_Record.Origin_CallId = [Route_Call].[PK_CallId] and 
	Has_Record.FK_MachineTrainId = [Machine_Train].[PK_MachineTrainId]  


	where [Complete_Date] is not null 
	and [Record] is null
GO






/****** Summary table for routes against machines.  
	Also returns the latest condition ******/
ALTER view [dbo].[V_Route_Machines] as 
SELECT [PK_MachineTrainId]
      ,[Machine_Train].[Machine_Train]
      ,[Machine_Train].[Machine_Train_Long_Name]
      ,[Driven_Unit_Type].[Driven_Unit_Type]
      ,[MachineTrain_IsActive]
	  ,[RepSum].[FaultId]
      ,[RepSum].[Primary_Component_Type]
      ,[RepSum].[Fault_Type]
      ,[RepSum].[Create_Date]
      ,[RepSum].[Fault_Location]
      ,[RepSum].[ReportId]
      ,[RepSum].[Report_Date]
      ,[RepSum].[Measurement_Date]
      ,[RepSum].[Condition]
      ,[RepSum].[Actions]
      ,[RepSum].[Condition_Difference]
      ,[RepSum].[Change_In_Condition]
      ,[Machine_Train].[FK_RouteId] as [RouteId]
	  ,[Route].[Route]
      ,[Route].[Module_Code]
      ,[Route].[Unit]
      ,[Route].[Cycle_Days]
      ,[Route].[Labour_Hours]
      ,[Route_IsActive]

  FROM [DEV_ClientProject].[dbo].[Machine_Train]
 left join [DEV_ClientProject].[dbo].[Route] on 
 [Route].[PK_RouteId] = [Machine_Train].[FK_RouteId]
 left join [Driven_Unit_Type] on 
	[Machine_Train].[FK_DrivenUnitTypeId] = [Driven_Unit_Type].[PK_DrivenUnitTypeId]
 left join 
	(select * from [V_Report_Summary]  where [IsLatestReport] = 1) RepSum on 
	[RepSum].[MachineTrainId]  = [Machine_Train].[PK_MachineTrainId]
;

/****** Summary table for routes against machines.  
	Also returns the latest condition ******/

create view [dbo].[V_Routes] as

with No_Machines as (

select  [FK_RouteId], count([PK_MachineTrainId]) as [No_Machines_On_Route]
from [Machine_Train] 
group by [FK_RouteId])

SELECT 
		[PK_RouteId]
      ,[Route].[Route]
      ,[Route].[Module_Code]
      ,[Route].[Unit]
      ,[Route].[Cycle_Days]
	  ,[Route_Call].[PK_CallId]
      ,[Route_Call].[Call_No]
	  ,[No_Machines].[No_Machines_On_Route]
      ,[Route_Call].[Labour_Hours]
      ,[Route_Call].[Plan_Date]
      ,[Route_Call].[Schedule_Date]
      ,[Route_Call].[Modified_Date]
      ,[Route_Call].[Modified_By]
  FROM [DEV_ClientProject].[dbo].[Route_Call]
  left join [Route] on 
	[Route].[PK_RouteId] = [Route_Call].[FK_RouteId]
	left join [No_Machines] on 
	[No_Machines].[FK_RouteId] = [Route_Call].[FK_RouteId]	


/****** Trend table for condition and missed surveys ******/

create view [dbo].[V_Condition_Weekly] as 
with Rep_Sum as (
	select 
	 Machine_Train
	,MachineTrainId
	,ReportId
	,Report_Date
	,DATEADD(DAY,Cycle_Days*2,Report_Date) as Two_Missed_Surveys_Date
	,LEAD(Report_Date ,1 ,SYSDATETIME()) 
		OVER ( partition by MachineTrainId
		ORDER BY Report_Date ASC ) as Next_Report_Date
	,Condition_Magnitude

	from DEV_ClientProject.dbo.V_Report_Summary

	where Report_Stage = 'Released' and Report_Type in ('Routine','Baseline')
 )

, Rep_Sum_Miss as (
	select 
	Rep_Sum.*
	,case when Two_Missed_Surveys_Date  <  Next_Report_Date then 1 	
		else 0 end	as Contains_Missed_Dates
	from Rep_Sum
)

    SELECT 
	 rsm.*
	,dt.Date
	,dt.DateKey
	,dt.ISOWeekOfYear
	,dt.Month
	,dt.Year
	,case when	rsm.Two_Missed_Surveys_Date <= dt.Date and 
	rsm.Next_Report_Date > dt.Date then 1 else 0 end as [IsMissed]
	from Rep_Sum_Miss rsm
    left join dim_Date dt on 
	rsm.Report_Date <= dt.Date and 
	rsm.Next_Report_Date > dt.Date
	where dt.WeekDayName = 'Wednesday' 


	USE [DEV_ClientProject]
GO

USE [DEV_ClientProject]
GO

/****** Object:  View [dbo].[V_Generate_Reports]    Script Date: 21/01/2020 2:04:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create view [dbo].[V_Generate_Reports] as 
with hasReportsInProgress  as (
	SELECT [MachineTrainId]
      ,[ReportId]
  FROM [DEV_ClientProject].[dbo].[V_tst_Report_Summary]
  where [Report_Stage] = 'In Progress' 
  and [Status] = 'Open' ) 

select mt.*
		,rs.[FaultId]
		,rs.[ReportId]
		,rip.[ReportId] as [ReportInProgress]
		,case 
			when rip.[ReportId] is not null then 'Report in progress - no action'
			when rs.[FaultId] is null then 'No open reports - create a new fault and report'
			when rs.[FaultId] is not null then 'Existing reports - raise a new report on this fault'
			else null end as Action --[dbo].[V_Condition_Weekly]
from [DEV_ClientProject].[dbo].V_Machine_Train_Hierarchy mt
left join (select * from [DEV_ClientProject].[dbo].V_tst_Report_Summary where IsLatestReport = 1) rs  on 
	rs.MachineTrainId = mt.MachineTrainId
left join hasReportsInProgress rip on 
	rip.MachineTrainId = mt.MachineTrainId 

GO







/****** Object:  View [dbo].[Vw_FaultSummary]    Script Date: 20/11/2019 7:24:46 AM ******/
/****** Object:  View [dbo].[Vw_FaultSummary]    Script Date: 20/11/2019 7:24:46 AM ******/
/****** Object:  View [dbo].[Vw_FaultSummary]    Script Date: 20/11/2019 7:24:46 AM ******/
/****** Object:  View [dbo].[Vw_FaultSummary]    Script Date: 20/11/2019 7:24:46 AM ******/



CREATE VIEW [dbo].[Vw_FaultSummary] as

SELECT [Fault].[PK_FaultId]
	  ,[Machine].[FK_AreaId]
	  ,[Area].[Area_Name]
	  ,[Machine].[FK_DrivenUnitTypeId]
	  ,[Driven_Unit_Type].[Driven_Unit_Type]
      ,[Fault].[FK_MachineId]
      ,[Fault].[FK_PrimCompId]
      ,[Fault].[FK_FaultLocId]
      ,[Fault].[FK_FaultTypeId]
      ,[Fault].[FK_FaultDetailId]
	  ,[Fault].[Create_Date]
      ,[Fault].[Close_Date]
	  ,[Fault].[Status]
      ,[Fault_IsActive]
      ,[Machine].[Machine_Name]
      ,[Primary_Component].[Primary_Component]
      ,[Fault_Location].[Fault_Location]
      ,[Fault_Type].[FaultType]
      ,[Fault_Detail].[Fault_Detail]


  FROM ((((((([dbo].[Fault]
  LEFT JOIN [dbo].[Machine] on [Machine].[PK_MachineId] = [Fault].[FK_MachineId])
  LEFT JOIN [dbo].[Primary_Component] on [Primary_Component].[PK_PrimCompId] = [Fault].[FK_PrimCompId])
  LEFT JOIN [dbo].[Fault_Location] on [Fault_Location].[PK_FaultLocId] = [Fault].[FK_FaultLocId])
  LEFT JOIN [dbo].[Fault_Type] on [Fault_Type].[PK_FaultTypeId] = [Fault].[FK_FaultTypeId])
  LEFT JOIN [dbo].[Fault_Detail] on [Fault_Detail].[PK_FaultDetId] = [Fault].[FK_FaultDetailId])
  LEFT JOIN [dbo].[Area] on [Area].PK_AreaId = [Machine].[FK_AreaId])
  LEFT JOIN [dbo].[Driven_Unit_Type] on [Driven_Unit_Type].PK_DrivenUnitTypeId = [Machine].[FK_DrivenUnitTypeId])
where [dbo].[Fault].[Fault_IsActive] = 1
  AND [dbo].[Machine].[Machine_IsActive]=1
  AND [dbo].[Primary_Component].[PrimComp_IsActive]=1
  AND [dbo].[Fault_Location].[FaultLoc_IsActive]=1
  AND [dbo].[Fault_Type].[FaultType_IsActive]=1
  AND [dbo].[Fault_Detail].[FaultDet_IsActive]=1 
  AND [dbo].[Area].[Area_IsActive]=1
  AND [dbo].[Driven_Unit_Type].[DrivenUnitType_IsActive]=1
GO
/****** Object:  View [dbo].[Vw_LocationChar]    Script Date: 20/11/2019 7:24:46 AM ******/



CREATE VIEW [dbo].[Vw_LocationChar] as
SELECT
Machine.PK_MachineId,
Machine.Machine_Name,
Area.PK_AreaId,
Area.Area_Name,
Driven_Unit_Type.PK_DrivenUnitTypeId,
Driven_Unit_Type.Driven_Unit_Type,
Machine_IsActive
FROM (Machine
left Join Area on Area.PK_AreaId = Machine.FK_AreaId)
left join Driven_Unit_Type on Driven_Unit_Type.PK_DrivenUnitTypeId = Machine.FK_DrivenUnitTypeId

GO
/****** Object:  View [dbo].[Vw_MachNoteSummary]    Script Date: 20/11/2019 7:24:46 AM ******/



CREATE VIEW [dbo].[Vw_MachNoteSummary] as

SELECT [Machine_Notes].[PK_MachineNoteId]
      ,[Machine_Notes].[Machine_Note]
	  ,[Machine_Notes].Analyst_Name
      ,[Machine_Notes].[Note_Date]
      ,[Machine_Notes].[MachNote_IsActive]
      ,[Machine_Notes].[FK_MachineId]
      ,[Machine_Notes].[MachNote_ShowOnReport]
	,[Machine].Machine_Name
FROM ([Machine_Notes]
left Join Machine on Machine_Notes.FK_MachineId = Machine.PK_MachineId)

GO
ALTER TABLE [dbo].[Action] ADD  CONSTRAINT [DF_Action_Action_IsActive]  DEFAULT ((1)) FOR [Action_IsActive]
GO
ALTER TABLE [dbo].[Area] ADD  CONSTRAINT [DF_Area_Area_IsActive]  DEFAULT ((1)) FOR [Area_IsActive]
GO
ALTER TABLE [dbo].[Fault] ADD  CONSTRAINT [DF_Fault_Fault_IsArchived]  DEFAULT ((1)) FOR [Fault_IsActive]
GO
ALTER TABLE [dbo].[Fault_Detail] ADD  CONSTRAINT [DF_Fault_Detail_FaultDet_IsActive]  DEFAULT ((1)) FOR [FaultDet_IsActive]
GO
ALTER TABLE [dbo].[Fault_Location] ADD  CONSTRAINT [DF_Fault_Location_FaultLoc_IsActive]  DEFAULT ((1)) FOR [FaultLoc_IsActive]
GO
ALTER TABLE [dbo].[Fault_Type] ADD  CONSTRAINT [DF_Fault_Type_FaultType_IsActive]  DEFAULT ((1)) FOR [FaultType_IsActive]
GO
ALTER TABLE [dbo].[Machine] ADD  CONSTRAINT [DF_Machine_Machine_IsArchived]  DEFAULT ((1)) FOR [Machine_IsActive]
GO
ALTER TABLE [dbo].[Machine_Notes] ADD  CONSTRAINT [DF_Machine_Notes_MachNoteIsActive]  DEFAULT ((1)) FOR [MachNote_IsActive]
GO
ALTER TABLE [dbo].[Machine_Notes] ADD  CONSTRAINT [DF_Machine_Notes_MachNote_ShowOnReport]  DEFAULT ((0)) FOR [MachNote_ShowOnReport]
GO
ALTER TABLE [dbo].[Driven_Unit_Type] ADD  CONSTRAINT [DF_Driven_Unit_Type_DrivenUnitType_IsActive]  DEFAULT ((1)) FOR [DrivenUnitType_IsActive]
GO
ALTER TABLE [dbo].[Observation] ADD  CONSTRAINT [DF_Observation_Observation_IsActive]  DEFAULT ((1)) FOR [Observation_IsActive]
GO
ALTER TABLE [dbo].[Observation_Type] ADD  CONSTRAINT [DF_Observation_Type_ObservType_IsActive]  DEFAULT ((1)) FOR [ObservType_IsActive]
GO
ALTER TABLE [dbo].[Primary_Component] ADD  CONSTRAINT [DF_Primary_Component_PrimComp_IsActive]  DEFAULT ((1)) FOR [PrimComp_IsActive]
GO
ALTER TABLE [dbo].[Report] ADD  CONSTRAINT [DF_Report_Report_IsArchived]  DEFAULT ((1)) FOR [Report_IsActive]
GO
ALTER TABLE [dbo].[Report] ADD  CONSTRAINT [DF_Report_QACondition]  DEFAULT ((0)) FOR [QA_Condition]
GO
ALTER TABLE [dbo].[Report] ADD  CONSTRAINT [DF_Report_QAImage]  DEFAULT ((0)) FOR [QA_Image]
GO
ALTER TABLE [dbo].[Report] ADD  CONSTRAINT [DF_Report_QARecommendation]  DEFAULT ((0)) FOR [QA_Recommendation]
GO
ALTER TABLE [dbo].[Report_Type] ADD  CONSTRAINT [DF_ReportType_SurvType_IsActive]  DEFAULT ((1)) FOR [SurvType_IsActive]
GO
ALTER TABLE [dbo].[Action]  WITH CHECK ADD  CONSTRAINT [FK_Action_Fault_Type] FOREIGN KEY([FK_FaultTypeId])
REFERENCES [dbo].[Fault_Type] ([PK_FaultTypeId])
GO
ALTER TABLE [dbo].[Action] CHECK CONSTRAINT [FK_Action_Fault_Type]
GO
ALTER TABLE [dbo].[Fault]  WITH CHECK ADD  CONSTRAINT [FK_Fault_Fault_Detail] FOREIGN KEY([FK_FaultDetailId])
REFERENCES [dbo].[Fault_Detail] ([PK_FaultDetId])
GO
ALTER TABLE [dbo].[Fault] CHECK CONSTRAINT [FK_Fault_Fault_Detail]
GO
ALTER TABLE [dbo].[Fault]  WITH CHECK ADD  CONSTRAINT [FK_Fault_Fault_Location] FOREIGN KEY([FK_FaultLocId])
REFERENCES [dbo].[Fault_Location] ([PK_FaultLocId])
GO
ALTER TABLE [dbo].[Fault] CHECK CONSTRAINT [FK_Fault_Fault_Location]
GO
ALTER TABLE [dbo].[Fault]  WITH CHECK ADD  CONSTRAINT [FK_Fault_Fault_Type] FOREIGN KEY([FK_FaultTypeId])
REFERENCES [dbo].[Fault_Type] ([PK_FaultTypeId])
GO
ALTER TABLE [dbo].[Fault] CHECK CONSTRAINT [FK_Fault_Fault_Type]
GO
ALTER TABLE [dbo].[Fault]  WITH CHECK ADD  CONSTRAINT [FK_Fault_Machine] FOREIGN KEY([FK_MachineId])
REFERENCES [dbo].[Machine] ([PK_MachineId])
GO
ALTER TABLE [dbo].[Fault] CHECK CONSTRAINT [FK_Fault_Machine]
GO
ALTER TABLE [dbo].[Fault]  WITH CHECK ADD  CONSTRAINT [FK_Fault_Primary_Component] FOREIGN KEY([FK_PrimCompId])
REFERENCES [dbo].[Primary_Component] ([PK_PrimCompId])
GO
ALTER TABLE [dbo].[Fault] CHECK CONSTRAINT [FK_Fault_Primary_Component]
GO
ALTER TABLE [dbo].[Fault_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Fault_Detail_Fault_Type] FOREIGN KEY([FK_FaultTypeId])
REFERENCES [dbo].[Fault_Type] ([PK_FaultTypeId])
GO
ALTER TABLE [dbo].[Fault_Detail] CHECK CONSTRAINT [FK_Fault_Detail_Fault_Type]
GO
ALTER TABLE [dbo].[Machine]  WITH CHECK ADD  CONSTRAINT [RS_Mach_Area] FOREIGN KEY([FK_AreaId])
REFERENCES [dbo].[Area] ([PK_AreaId])
GO
ALTER TABLE [dbo].[Machine] CHECK CONSTRAINT [RS_Mach_Area]
GO
ALTER TABLE [dbo].[Machine]  WITH CHECK ADD  CONSTRAINT [RS_Mach_DrivenUnitType] FOREIGN KEY([FK_DrivenUnitTypeId])
REFERENCES [dbo].[Driven_Unit_Type] ([PK_DrivenUnitTypeId])
GO
ALTER TABLE [dbo].[Machine] CHECK CONSTRAINT [RS_Mach_DrivenUnitType]
GO
ALTER TABLE [dbo].[Machine_Notes]  WITH CHECK ADD  CONSTRAINT [RS_MachNotes_Mach] FOREIGN KEY([FK_MachineId])
REFERENCES [dbo].[Machine] ([PK_MachineId])
GO
ALTER TABLE [dbo].[Machine_Notes] CHECK CONSTRAINT [RS_MachNotes_Mach]
GO
ALTER TABLE [dbo].[Observation]  WITH CHECK ADD  CONSTRAINT [RS_Obs_ObsType] FOREIGN KEY([FK_ObservTypeId])
REFERENCES [dbo].[Observation_Type] ([PK_ObservTypeId])
GO
ALTER TABLE [dbo].[Observation] CHECK CONSTRAINT [RS_Obs_ObsType]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_Fault] FOREIGN KEY([FK_FaultId])
REFERENCES [dbo].[Fault] ([PK_FaultId])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_Fault]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_Report_Stage] FOREIGN KEY([FK_ReportStageId])
REFERENCES [dbo].[Report_Stage] ([PK_ReportStageId])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_Report_Stage]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_Condition] FOREIGN KEY([FK_ConditionId])
REFERENCES [dbo].[Condition] ([PK_ConditionId])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_Condition]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_Report_Type] FOREIGN KEY([FK_ReportTypeId])
REFERENCES [dbo].[Report_Type] ([PK_ReportTypeId])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_Report_Type]
GO
/****** Object:  StoredProcedure [dbo].[WipeData]    Script Date: 20/11/2019 7:24:46 AM ******/



CREATE PROCEDURE [dbo].[WipeData]

as 

DELETE FROM [dbo].[Report]
      WHERE [PK_ReportId]>=0; 


DELETE FROM [dbo].[Fault]
      WHERE [PK_FaultId]>=0; 

GO



CREATE FUNCTION [dbo].[fnParseList]
(
	@Delimiter CHAR,
	@Text TEXT
)
RETURNS @Result TABLE (RowID SMALLINT IDENTITY(1, 1) PRIMARY KEY, Data VARCHAR(8000))
AS

BEGIN
	DECLARE	@NextPos INT,
		@LastPos INT

	SELECT	@NextPos = CHARINDEX(@Delimiter, @Text, 1),
		@LastPos = 0

	WHILE @NextPos > 0
		BEGIN
			INSERT	@Result
				(
					Data
				)
			SELECT	SUBSTRING(@Text, @LastPos + 1, @NextPos - @LastPos - 1)

			SELECT	@LastPos = @NextPos,
				@NextPos = CHARINDEX(@Delimiter, @Text, @NextPos + 1)
		END

	IF @NextPos <= @LastPos
		INSERT	@Result
			(
				Data
			)
		SELECT	SUBSTRING(@Text, @LastPos + 1, DATALENGTH(@Text) - @LastPos)

	RETURN
END

GO
/****** Object:  UserDefinedFunction [dbo].[intlist_to_tbl]    Script Date: 20/11/2019 7:24:45 AM ******/


CREATE FUNCTION [dbo].[intlist_to_tbl] (@list nvarchar(MAX))
   RETURNS @tbl TABLE (number int NOT NULL) AS
BEGIN
   DECLARE @pos        int,
           @nextpos    int,
           @valuelen   int

   SELECT @pos = 0, @nextpos = 1

   WHILE @nextpos > 0
   BEGIN
      SELECT @nextpos = charindex(',', @list, @pos + 1)
      SELECT @valuelen = CASE WHEN @nextpos > 0
                              THEN @nextpos
                              ELSE len(@list) + 1
                         END - @pos - 1
      INSERT @tbl (number)
         VALUES (convert(int, substring(@list, @pos + 1, @valuelen)))
      SELECT @pos = @nextpos
   END
   RETURN
END
GO


