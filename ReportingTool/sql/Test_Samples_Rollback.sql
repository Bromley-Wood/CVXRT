/* Rollback TstFaults*/

UPDATE [tst_Fault] SET			
FK_MachineTrainId	=	60	,
FK_PrimaryComponentTypeId	=	1	,
FK_PrimaryComponentSubtypeId	=	NULL	,
FK_TechnologyId	=	1	,
FK_FaultTypeId	=	15	,
FK_FaultSubtypeId	=	NULL	,
Create_Date	=	'2017-02-01 0:00:00'	,
Close_Date	=	NULL	,
Fault_Location	=	NULL	,
Production_Impact_Cost	=	50000	,
Fault_IsActive	=	1	
where PK_FaultId	=	46	;
			
UPDATE [tst_Fault] SET			
FK_MachineTrainId	=	574	,
FK_PrimaryComponentTypeId	=	1	,
FK_PrimaryComponentSubtypeId	=	NULL	,
FK_TechnologyId	=	1	,
FK_FaultTypeId	=	2	,
FK_FaultSubtypeId	=	NULL	,
Create_Date	=	'2019-09-01 0:00:00'	,
Close_Date	=	NULL	,
Fault_Location	=	NULL	,
Production_Impact_Cost	=	500000	,
Fault_IsActive	=	1	
where PK_FaultId	=	619	;
			
UPDATE [tst_Fault] SET			
FK_MachineTrainId	=	575	,
FK_PrimaryComponentTypeId	=	1	,
FK_PrimaryComponentSubtypeId	=	NULL	,
FK_TechnologyId	=	1	,
FK_FaultTypeId	=	5	,
FK_FaultSubtypeId	=	NULL	,
Create_Date	=	'2018-06-30 0:00:00'	,
Close_Date	=	NULL	,
Fault_Location	=	NULL	,
Production_Impact_Cost	=	500000	,
Fault_IsActive	=	1	
where PK_FaultId	=	621	;
			
UPDATE [tst_Fault] SET			
FK_MachineTrainId	=	1373	,
FK_PrimaryComponentTypeId	=	NULL	,
FK_PrimaryComponentSubtypeId	=	NULL	,
FK_TechnologyId	=	1	,
FK_FaultTypeId	=	NULL	,
FK_FaultSubtypeId	=	NULL	,
Create_Date	=	'2019-12-31 15:23:35'	,
Close_Date	=	NULL	,
Fault_Location	=	NULL	,
Production_Impact_Cost	=	NULL	,
Fault_IsActive	=	1	
where PK_FaultId	=	3213	;

/* Rollback TstReports*/
UPDATE [tst_Report] SET				
FK_FaultId		=	619	,
Report_Date		=	'2019-12-31'	,
Measurement_Date		=	'2019-12-31'	,
FK_ConditionId		=	2	,
FK_ReportTypeId		=	1	,
FK_ReportStageId		=	1	,
Observations		=	NULL	,
Actions		=	'Trend - fix if belt signals come up in august survey'	,
Analyst_Notes		=	NULL	,
External_Notes		=	NULL	,
Notification_No		=	NULL	,
Work_Order_No		=	NULL	,
Review_Comments		=	NULL	,
Analyst_Name		=	'Shu'	,
Reviewer_Name		=	NULL	,
Report_IsActive		=	1	,
Origin_CallId		=	NULL	
where PK_ReportId		=	47322	;
				
UPDATE [tst_Report] SET				
FK_FaultId		=	621	,
Report_Date		=	'2019-12-31'	,
Measurement_Date		=	'2019-12-31'	,
FK_ConditionId		=	2	,
FK_ReportTypeId		=	1	,
FK_ReportStageId		=	1	,
Observations		=	NULL	,
Actions		=	'Trend - fix if belt signals come up in august survey'	,
Analyst_Notes		=	NULL	,
External_Notes		=	NULL	,
Notification_No		=	NULL	,
Work_Order_No		=	NULL	,
Review_Comments		=	NULL	,
Analyst_Name		=	'Shu'	,
Reviewer_Name		=	NULL	,
Report_IsActive		=	1	,
Origin_CallId		=	NULL	
where PK_ReportId		=	47323	;
				
UPDATE [tst_Report] SET				
FK_FaultId		=	46	,
Report_Date		=	'2019-12-31'	,
Measurement_Date		=	'2019-12-31'	,
FK_ConditionId		=	3	,
FK_ReportTypeId		=	1	,
FK_ReportStageId		=	1	,
Observations		=	NULL	,
Actions		=	'WO awaiting action, returned to cond 4 as they will replace at next opportunity.'	,
Analyst_Notes		=	NULL	,
External_Notes		=	'There is history with these pumps being a bad actor. This work order is to change the pump only. There is a long lead time on the motor associated with this equipment ''therefore a seperate work order to replace the motor is in place. (WO326543)'	,
Notification_No		=	NULL	,
Work_Order_No		=	326543	,
Review_Comments		=	NULL	,
Analyst_Name		=	'Shu'	,
Reviewer_Name		=	NULL	,
Report_IsActive		=	1	,
Origin_CallId		=	NULL	
where PK_ReportId		=	47324	;
				
UPDATE [tst_Report] SET				
FK_FaultId		=	3213	,
Report_Date		=	'2019-12-31'	,
Measurement_Date		=	'2019-12-31'	,
FK_ConditionId		=	3	,
FK_ReportTypeId		=	2	,
FK_ReportStageId		=	1	,
Observations		=	NULL	,
Actions		=	NULL	,
Analyst_Notes		=	NULL	,
External_Notes		=	NULL	,
Notification_No		=	NULL	,
Work_Order_No		=	NULL	,
Review_Comments		=	NULL	,
Analyst_Name		=	'Shu'	,
Reviewer_Name		=	NULL	,
Report_IsActive		=	1	,
Origin_CallId		=	NULL	
where PK_ReportId		=	47326	;