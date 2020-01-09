-- No Fault 

-- Check 1 : Are there in progress reports?

SELECT [FaultId]
      ,[MachineTrainId]
      ,[ReportId]
  FROM [DEV_ClientProject].[dbo].[V_Report_Summary]
  where [Report].[ReportStageId] = 1 -- In Progress
  and [Fault].[Status] = 'Open' 
  and [MachineTrainId] = <machine train row id>
  
  -- if result is null then there are no in progress reports.  Go to the next check (2)
  -- if result is not null then .. exit.. and add to warning list (tbc) (I probably need to build this in the html)

-- Check 2: What is the latest report for this machine?

Select [Fault_ID]
      ,[Condition]
From [DEV_ClientProject].[dbo].[V_Report_Summary]
where [MachineTrainId] = <machine train row id> and 
	[IsLatestReport]=1 -- note that LatestReport criteria [Report is released, report is active, fault is open, report date is the max out of a group of faultids]

-- If the above returns a report that is condition 2 then raise a no action report and release it.  go to (3)
-- if result is null then that means there are no open faults on this machine.  we need to raise a new fault and then a report.  go to (4).


-- Action 3: 
-- Retrieve the latest report on this machine 
-- Get the fault id of this report
-- Create a new report on the same fault.
-- Set this report to no fault, routine and released
-- No Fault - Existing Report
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
      ,[Review_Comments]
      ,[Analyst_Name]
      ,[Reviewer_Name]
      ,[Report_IsActive])
SELECT [FK_FaultId]
      ,sysdatetime()
      ,sysdatetime()
      ,1 -- aka. No Action (cond 2)
      ,1 -- aka. Routine
      ,4 -- aka. Released 
      ,NULL
      ,NULL
      ,NULL
      ,NULL
      ,NULL
      ,NULL
      ,NULL
      ,<current user>
      ,NULL
      ,1
  FROM [DEV_ClientProject].[dbo].[Report]
where [PK_ReportId] = <latest release report id>


-- Action 4: 
-- create a new fault on this machine
-- set the fault type to no fault
-- Create a new report on the new fault.
-- Set this report to no fault, routine and released


INSERT INTO [DEV_ClientProject].[dbo].[Fault] (
      [FK_MachineTrainId]
      ,[FK_PrimaryComponentTypeId]
      ,[FK_PrimaryComponentSubtypeId]
      ,[FK_TechnologyId]
      ,[FK_FaultTypeId]
      ,[FK_FaultSubtypeId]
      ,[Create_Date]
      ,[Close_Date]
      ,[Fault_Location]
      ,[Production_Impact_Cost]
      ,[Fault_IsActive])
VALUES (<this machine id>
	  ,1 -- aka. parent
      ,NULL
      ,1 -- aka. Vibes
      ,1 -- aka. No vib Fault
      ,NULL
      ,SYSDATETIME()
      ,NULL
      ,NULL
      ,NULL
      ,1) ; 
	  
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
      ,[Review_Comments]
      ,[Analyst_Name]
      ,[Reviewer_Name]
      ,[Report_IsActive])
SELECT <Fault_ID from above>
      ,sysdatetime()
      ,sysdatetime()
      ,1 -- aka. No Action (cond 2)
      ,1 -- aka. Routine
      ,4 -- aka. Released 
      ,NULL
      ,NULL
      ,NULL
      ,NULL
      ,NULL
      ,NULL
      ,NULL
      ,<current user>
      ,NULL
      ,1
  FROM [DEV_ClientProject].[dbo].[Report]
where [PK_ReportId] = <latest release report id>
	  


-- Anomoly -- 
-- IN PROGRESS ---- 	
	  
--Anomaly -- Existing Report
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



-- Anomaly - No Existing Report

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

