
-------- No Action Condition 2:  Existing Report --------
-- Retrieve the latest report on this machine 
-- Get the fault id of this report
-- Create a new report on the same fault.
-- Set this report to no fault, routine and released

INSERT INTO report([FK_FaultId] 
      ,[Report_Date]
      ,[Measurement_Date]
      ,[FK_ConditionId]
      ,[FK_ReportTypeId]
      ,[FK_ReportStageId]
      ,[Analyst_Name]
      ,[Report_IsActive])
SELECT [FK_FaultId]
      ,sysdatetime()
      ,sysdatetime()
      ,1 -- aka. No Action (cond 2)
      ,1 -- aka. Routine
      ,4 -- aka. Released 
      ,<current user>
      ,1
  FROM [DEV_ClientProject].[dbo].[Report]
where [PK_ReportId] = <latest release report id>


-------- No Action Condition 2: New Fault Required -------------
-- create a new fault on this machine
-- set the fault type to no fault
-- Create a new report on the new fault.
-- Set this report to no fault, routine and released

INSERT INTO [DEV_ClientProject].[dbo].[Fault] (
      [FK_MachineTrainId]
      ,[FK_PrimaryComponentTypeId]
      ,[FK_TechnologyId]
      ,[FK_FaultTypeId]
      ,[Create_Date]
      ,[Fault_IsActive])
VALUES (<this machine id>
	  ,1 -- aka. parent
      ,1 -- aka. Vibes
      ,1 -- aka. No vib Fault
      ,SYSDATETIME()
      ,1) ; 
	  
INSERT INTO report([FK_FaultId] 
      ,[Report_Date]
      ,[Measurement_Date]
      ,[FK_ConditionId]
      ,[FK_ReportTypeId]
      ,[FK_ReportStageId]
      ,[Analyst_Name]
      ,[Report_IsActive])
SELECT SCOPE_IDENTITY() -- aka get Fault Id from above
      ,sysdatetime()
      ,sysdatetime()
      ,1 -- aka. No Action (cond 2)
      ,1 -- aka. Routine
      ,4 -- aka. Released 
      ,<current user>
      ,1
  FROM [DEV_ClientProject].[dbo].[Report]
where [PK_ReportId] = <latest release report id>
	  


-- Anomoly -- 
	  
--Anomaly Condition 3+ -- Existing Report
INSERT INTO report([FK_FaultId] 
      ,[Report_Date]
      ,[Measurement_Date]
      ,[FK_ConditionId]
      ,[FK_ReportTypeId]
      ,[FK_ReportStageId]
      ,[Observations]
      ,[Actions]
      ,[Analyst_Notes]
      ,[External_Notes]
      ,[Notification_No]
      ,[Work_Order_No]
      ,[Analyst_Name]
      ,[Report_IsActive])
SELECT [FK_FaultId]
      ,sysdatetime()
      ,sysdatetime()
      ,[FK_ConditionId]  -- whatever the last condition was
      ,1 -- aka. Routine
      ,1 -- aka. In progress 
      ,[Observations]
      ,[Actions]
      ,[Analyst_Notes]
      ,[External_Notes]
      ,[Notification_No]
      ,[Work_Order_No]
      ,<current user>
      ,[Report_IsActive]
  FROM [DEV_ClientProject].[dbo].[Report]
where [PK_ReportId] = <latest release report id>



-- Anomaly Condition 3+  New Fault Required -------------

INSERT INTO [DEV_ClientProject].[dbo].[Fault] (
      [FK_MachineTrainId]
      ,[FK_TechnologyId]
      ,[Create_Date]
      ,[Fault_IsActive])
VALUES (<this machine id>
      ,1 -- aka. Initialise as Vibes
      ,SYSDATETIME()
      ,1) ; 
	  
INSERT INTO report([FK_FaultId] 
      ,[Report_Date]
      ,[Measurement_Date]
      ,[FK_ConditionId]
      ,[FK_ReportTypeId]
      ,[FK_ReportStageId]
      ,[Analyst_Name]
      ,[Report_IsActive])
values ( SCOPE_IDENTITY() -- aka get Fault Id from above
      ,sysdatetime()
      ,sysdatetime()
      ,3 -- aka. Initialise as Trending
      ,2 -- aka. Initialise as Baseline
      ,1 -- aka. In progress 
      ,<current user>
      ,1);

