/*
All the scripts generated from SQL Server Management Studio

Modifications:
1. Replace . with empty string
2. Replace '`' with '`'
3. Replace '`' with '`'
4. Replace '--  ' with '--   '
5. Add "OR REPLACE" after "CREATE"
*/



CREATE OR REPLACE View `V_Latest_Report_by_Fault` as 
SELECT `Report`.`FK_FaultId`
      ,max( `Report`.`Report_Date`) as `Latest_Report_Date_by_Fault`
	  ,1 as `IsLatestReport` 
	  ,`Fault`.`Status`

  FROM `DEV_ClientProject`.`Report` 
  left join `Fault` on 
	`Fault`.`PK_FaultId` = `Report`.`FK_FaultId`
  where `Report`.`FK_ReportStageId` = 4 --     Released
  and `Report`.`Report_IsActive` = 1 --      Active report
  and `Fault`.`Fault_IsActive` = 1 --      Active report
--       and `Fault`.`Status` = 'Open' 
  group by 
		`Report`.`FK_FaultId`
	  ,`Fault`.`Status`
;
      


CREATE OR REPLACE VIEW `V_Report_Summary` as


SELECT `Fault`.`PK_FaultId` as `FaultId`
	  ,`Area`.`PK_AreaId` as `AreaId`
	  ,`Area`.`Greater_Area`
	  ,`Area`.`Unit_Reference`
	  ,`Area`.`Area`
	  ,`Driven_Unit_Type`.`PK_DrivenUnitTypeId` as `DrivenUnitTypeId`
	  ,`Driven_Unit_Type`.`Driven_Unit_Type`
      ,`Fault`.`FK_MachineTrainId` as `MachineTrainId`
	  ,`Machine_Train`.`Machine_Train`
	  ,`Machine_Train`.`Machine_Train_Long_Name`
	  ,`Route`.`Route`
	  ,`Route`.`Cycle_Days`
      ,`Primary_Component_Type`.`PK_PrimaryComponentTypeId` as `PrimaryComponentTypeId`
	  ,`Primary_Component_Type`.`Primary_Component_Type`
      ,`Primary_Component_Subtype`.`PK_PrimaryComponentSubtypeId` as `PrimaryComponentSubtypeId`
	  ,`Primary_Component_Subtype`.`Primary_Component_Subtype`
      ,`Fault`.`FK_FaultTypeId` as `FaultTypeId`
	  ,`Fault_Type`.`Fault_Type`
      ,`Fault_Subtype`.`Fault_Subtype`
	  ,`Fault`.`Create_Date`
      ,`Fault`.`Close_Date`
      ,`Fault`.`Fault_Location`
      ,`Fault`.`Production_Impact_Cost`
      ,`Fault_IsActive`
	  ,`Fault`.`Status`
	  ,`Report`.`PK_ReportId` as `ReportId`
      ,`Report`.`Report_Date`
      ,`Report`.`Measurement_Date`
      --   ,`Report`.`FK_ConditionId`
      ,`Condition`.`Condition`
	  ,`Condition`.`Condition_Magnitude`
      --   ,`Report`.`FK_ReportTypeId`
	  ,`Report_Type`.`Report_Type`
      --   ,`Report`.`FK_ReportStageId`
	  ,`Report_Stage`.`Report_Stage`
      ,`Report`.`Observations`
      ,`Report`.`Actions`
      ,`Report`.`Analyst_Notes`
      ,`Report`.`External_Notes`
      ,`Report`.`Notification_No`
      ,`Report`.`Work_Order_No`
      ,`Report`.`Review_Comments`
      ,`Report`.`Analyst_Name`
      ,`Report`.`Reviewer_Name`
      ,`Report`.`Report_IsActive`
	, FK_ConditionId - (LAG(FK_ConditionId, 1, NULL)  OVER 
    (PARTITION BY `Report`.`FK_FaultId` ORDER BY `Report_Date` ASC))  AS Condition_Difference
	, case 
		when `Report_Date` is NULL then 'In Progress'
		when FK_ConditionId - (LAG(FK_ConditionId, 1, NULL)  OVER 
		(PARTITION BY `Report`.`FK_FaultId` ORDER BY `Report_Date` ASC)) is NULL then 'New' 
		when FK_ConditionId - (LAG(FK_ConditionId, 1, NULL)  OVER 
		(PARTITION BY `Report`.`FK_FaultId` ORDER BY `Report_Date` ASC)) =0 then 'Unchanged'
		when FK_ConditionId - (LAG(FK_ConditionId, 1, NULL)  OVER 
		(PARTITION BY `Report`.`FK_FaultId` ORDER BY `Report_Date` ASC)) >0 then 'Increased'	
		when FK_ConditionId - (LAG(FK_ConditionId, 1, NULL)  OVER 
		(PARTITION BY `Report`.`FK_FaultId` ORDER BY `Report_Date` ASC)) <0 then 'Improved'				
		else '??' End as Change_In_Condition
	,case when `Fault`.`Status` = 'Open' and `V_Latest_Report_by_Fault`.`IsLatestReport` = 1 then 1 else null end as `IsLatestReport`
	,`V_Latest_Report_by_Fault`.`IsLatestReport` as `IsLastRecord` --    Includes both open and closed
  FROM ((((((((((((`Fault` as `Fault`
  LEFT JOIN `Report` as `Report` on 
	`Report`.`FK_FaultId` = `Fault`.`PK_FaultId`)
  LEFT JOIN `Machine_Train` on 
	`Machine_Train`.`PK_MachineTrainId` = `Fault`.`FK_MachineTrainId`)
  LEFT JOIN `Route` on 
	`Route`.`PK_RouteId` = `Machine_Train`.`FK_RouteId`)
  LEFT JOIN `Primary_Component_Type` on 
	`Primary_Component_Type`.`PK_PrimaryComponentTypeId` = `Fault`.`FK_PrimaryComponentTypeId`)
  LEFT JOIN `Primary_Component_Subtype` on 
	`Primary_Component_Subtype`.`PK_PrimaryComponentSubtypeId` = `Fault`.`FK_PrimaryComponentSubtypeId`)
  LEFT JOIN `Fault_Type` on 
	`Fault_Type`.`PK_FaultTypeId` = `Fault`.`FK_FaultTypeId`)
  LEFT JOIN `Fault_Subtype` on 
	`Fault_Subtype`.`PK_FaultSubtypeId` = `Fault`.`FK_FaultSubtypeId`)
  LEFT JOIN `Condition` on 
	`Condition`.`PK_ConditionId` = `Report`.`FK_ConditionId`)
  LEFT JOIN `Report_Type` on 
	`Report_Type`.PK_ReportTypeId = `Report`.`FK_ReportTypeId`)
  LEFT JOIN `Area` on 
	`Area`.PK_AreaId = `Machine_Train`.`FK_AreaId`)
  LEFT JOIN `Driven_Unit_Type` on 
	`Driven_Unit_Type`.PK_DrivenUnitTypeId = `Machine_Train`.`FK_DrivenUnitTypeId`)
  LEFT JOIN `Report_Stage` on 
	`Report_Stage`.PK_ReportStageId = `Report`.`FK_ReportStageId`)
  LEFT JOIN `V_Latest_Report_by_Fault` on 
	 `V_Latest_Report_by_Fault`.`Latest_Report_Date_by_Fault` = `Report`.`Report_Date` 
	 and `V_Latest_Report_by_Fault`.`FK_FaultId` = `Report`.`FK_FaultId` 

where 
	`Area_IsActive` = 1  
	and `MachineTrain_IsActive` = 1
	and `Fault_IsActive` = 1
	and `Report_IsActive` = 1
    
;

CREATE OR REPLACE view `V_Route_Machines` as 
SELECT `PK_MachineTrainId`
      ,`Machine_Train`.`Machine_Train`
      ,`Machine_Train`.`Machine_Train_Long_Name`
      ,`Driven_Unit_Type`.`Driven_Unit_Type`
      ,`MachineTrain_IsActive`
	  ,`RepSum`.`FaultId`
      ,`RepSum`.`Primary_Component_Type`
      ,`RepSum`.`Fault_Type`
      ,`RepSum`.`Create_Date`
      ,`RepSum`.`Fault_Location`
      ,`RepSum`.`ReportId`
      ,`RepSum`.`Report_Date`
      ,`RepSum`.`Measurement_Date`
      ,`RepSum`.`Condition`
      ,`RepSum`.`Actions`
      ,`RepSum`.`Condition_Difference`
      ,`RepSum`.`Change_In_Condition`
      ,`Machine_Train`.`FK_RouteId` as `RouteId`
	  ,`Route`.`Route`
      ,`Route`.`Module_Code`
      ,`Route`.`Unit`
      ,`Route`.`Cycle_Days`
      ,`Route`.`Labour_Hours`
	  ,`Route`.`First_Call_Date`
      ,`Route_IsActive`

  FROM `DEV_ClientProject`.`Machine_Train`
 left join `DEV_ClientProject`.`Route` on 
 `Route`.`PK_RouteId` = `Machine_Train`.`FK_RouteId`
 left join `Driven_Unit_Type` on 
	`Machine_Train`.`FK_DrivenUnitTypeId` = `Driven_Unit_Type`.`PK_DrivenUnitTypeId`
 left join 
	(select * from `V_Report_Summary`  where `IsLatestReport` = 1) RepSum on 
	`RepSum`.`MachineTrainId`  = `Machine_Train`.`PK_MachineTrainId`
;





CREATE OR REPLACE view `V_Create_Reports` as

with Has_Record as (
select FK_MachineTrainId, PK_ReportId, null as PK_MissedSurveyId, Origin_CallId, 'Report' as Record 
from Report rp
left join Fault ft
	on ft.PK_FaultId = rp.FK_FaultId

union 
select FK_MachineTrainId, null as PK_ReportId,  PK_MissedSurveyId, Origin_CallId, 'Missed' as Record 
from Missed_Survey )

SELECT 
		`PK_RouteId`
      ,`Route`.`Route`
      ,`Route`.`Module_Code`
      ,`Route`.`Unit`
      ,`Route`.`Cycle_Days`
	  ,`Route_Call`.`PK_CallId`
      ,`Route_Call`.`Call_No`
      ,`Route_Call`.`Labour_Hours`
      ,`Route_Call`.`Plan_Date`
      ,`Route_Call`.`Schedule_Date`
      ,`Route_Call`.`Modified_Date`
      ,`Route_Call`.`Modified_By`
	  ,`Route_Call`.`Complete_Date`
	  ,`Machine_Train`.`PK_MachineTrainId`
	  ,`Machine_Train`.`Machine_Train`
	  ,`Machine_Train`.`Machine_Train_Long_Name`
	  ,`Has_Record`.Record
	  ,`RepSum`.`FaultId`
      ,`RepSum`.`Primary_Component_Type`
      ,`RepSum`.`Fault_Type`
      ,`RepSum`.`Create_Date`
      ,`RepSum`.`Fault_Location`
      ,`RepSum`.`ReportId`
      ,`RepSum`.`Report_Date`
      ,`RepSum`.`Measurement_Date`
      ,`RepSum`.`Condition`
      ,`RepSum`.`Actions`
      ,`RepSum`.`Condition_Difference`
      ,`RepSum`.`Change_In_Condition`
	  ,`RepSum`.`Report_Stage`
	  ,`RepSum`.Status
	  ,case when exists(select * from `V_Report_Summary` where `V_Report_Summary`.Report_Stage = 'in progress' and `Machine_Train`.`PK_MachineTrainId` = `V_Report_Summary`.MachineTrainId) then 1 else 0 end as HasReportInProgress

  FROM `DEV_ClientProject`.`Route_Call` Route_Call
  left join `Route` on 
	`Route`.`PK_RouteId` = `Route_Call`.`FK_RouteId`
  left join  `Machine_Train`  on 
	`Route_Call`.`FK_RouteId` = `Machine_Train`.`FK_RouteId` 
 left join 
	(select * from `V_Report_Summary`  where `IsLatestReport` = 1) RepSum on 
	`RepSum`.`MachineTrainId`  = `Machine_Train`.`PK_MachineTrainId`
left join Has_Record on
	Has_Record.Origin_CallId = `Route_Call`.`PK_CallId` and 
	Has_Record.FK_MachineTrainId = `Machine_Train`.`PK_MachineTrainId`  


	where `Complete_Date` is not null 
	and `Record` is null