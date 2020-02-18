# This is an auto-generated Django model module.
# You'll have to do the following manually to clean this up:
#   * Rearrange models' order
#   * Make sure each model has one field with primary_key=True
#   * Make sure each ForeignKey has `on_delete` set to the desired behavior.
#   * Remove `managed = False` lines if you wish to allow Django to create, modify, and delete the table
# Feel free to rename the models, but don't rename db_table values or field names.
from django.db import models


class Action(models.Model):
    pk_actionid = models.AutoField(db_column='PK_ActionId', primary_key=True)  # Field name made lowercase.
    action = models.TextField(db_column='Action')  # Field name made lowercase. This field type is a guess.
    fk_faulttypeid = models.IntegerField(db_column='FK_FaultTypeId')  # Field name made lowercase.
    action_isactive = models.TextField(db_column='Action_IsActive')  # Field name made lowercase. This field type is a guess.
    action_order = models.IntegerField(db_column='Action_Order')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'Action'


class Area(models.Model):
    pk_areaid = models.AutoField(db_column='PK_AreaId', primary_key=True)  # Field name made lowercase.
    area = models.TextField(db_column='Area')  # Field name made lowercase. This field type is a guess.
    unit_reference = models.TextField(db_column='Unit_Reference', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    greater_area = models.TextField(db_column='Greater_Area')  # Field name made lowercase. This field type is a guess.
    area_isactive = models.TextField(db_column='Area_IsActive')  # Field name made lowercase. This field type is a guess.
    fk_siteid = models.IntegerField(db_column='FK_SiteId')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'Area'


class Condition(models.Model):
    pk_conditionid = models.AutoField(db_column='PK_ConditionId', primary_key=True)  # Field name made lowercase.
    condition = models.TextField(db_column='Condition')  # Field name made lowercase. This field type is a guess.
    condition_magnitude = models.TextField(db_column='Condition_Magnitude')  # Field name made lowercase. This field type is a guess.
    condition_alt_label = models.TextField(db_column='Condition_Alt_Label', blank=True, null=True)  # Field name made lowercase. This field type is a guess.

    class Meta:
        managed = False
        db_table = 'Condition'


class DrivenUnitType(models.Model):
    pk_drivenunittypeid = models.AutoField(db_column='PK_DrivenUnitTypeId', primary_key=True)  # Field name made lowercase.
    driven_unit_type = models.TextField(db_column='Driven_Unit_Type')  # Field name made lowercase. This field type is a guess.
    drivenunittype_isactive = models.TextField(db_column='DrivenUnitType_IsActive')  # Field name made lowercase. This field type is a guess.

    class Meta:
        managed = False
        db_table = 'Driven_Unit_Type'


class Fault(models.Model):
    pk_faultid = models.AutoField(db_column='PK_FaultId', primary_key=True)  # Field name made lowercase.
    fk_machinetrainid = models.IntegerField(db_column='FK_MachineTrainId')  # Field name made lowercase.
    fk_primarycomponenttypeid = models.IntegerField(db_column='FK_PrimaryComponentTypeId', blank=True, null=True)  # Field name made lowercase.
    fk_primarycomponentsubtypeid = models.IntegerField(db_column='FK_PrimaryComponentSubtypeId', blank=True, null=True)  # Field name made lowercase.
    fk_technologyid = models.IntegerField(db_column='FK_TechnologyId')  # Field name made lowercase.
    fk_faulttypeid = models.IntegerField(db_column='FK_FaultTypeId', blank=True, null=True)  # Field name made lowercase.
    fk_faultsubtypeid = models.IntegerField(db_column='FK_FaultSubtypeId', blank=True, null=True)  # Field name made lowercase.
    create_date = models.DateTimeField(db_column='Create_Date')  # Field name made lowercase.
    close_date = models.DateTimeField(db_column='Close_Date', blank=True, null=True)  # Field name made lowercase.
    fault_location = models.TextField(db_column='Fault_Location', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    production_impact_cost = models.TextField(db_column='Production_Impact_Cost', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    fault_isactive = models.TextField(db_column='Fault_IsActive')  # Field name made lowercase. This field type is a guess.
    closure_comment = models.TextField(db_column='Closure_Comment', blank=True, null=True)  # Field name made lowercase. This field type is a guess.

    class Meta:
        managed = False
        db_table = 'Fault'


class FaultSubtype(models.Model):
    pk_faultsubtypeid = models.AutoField(db_column='PK_FaultSubtypeId', primary_key=True)  # Field name made lowercase.
    fault_subtype = models.TextField(db_column='Fault_Subtype')  # Field name made lowercase. This field type is a guess.
    fk_faulttypeid = models.IntegerField(db_column='FK_FaultTypeId')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'Fault_Subtype'


class FaultType(models.Model):
    pk_faulttypeid = models.AutoField(db_column='PK_FaultTypeId', primary_key=True)  # Field name made lowercase.
    fault_type = models.TextField(db_column='Fault_Type')  # Field name made lowercase. This field type is a guess.
    fk_technologyid = models.IntegerField(db_column='FK_TechnologyId')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'Fault_Type'


class MachineTrain(models.Model):
    pk_machinetrainid = models.AutoField(db_column='PK_MachineTrainId', primary_key=True)  # Field name made lowercase.
    machine_train = models.TextField(db_column='Machine_Train')  # Field name made lowercase. This field type is a guess.
    machine_train_long_name = models.TextField(db_column='Machine_Train_Long_Name')  # Field name made lowercase. This field type is a guess.
    fk_drivenunittypeid = models.IntegerField(db_column='FK_DrivenUnitTypeId')  # Field name made lowercase.
    fk_areaid = models.IntegerField(db_column='FK_AreaId')  # Field name made lowercase.
    fk_routeid = models.IntegerField(db_column='FK_RouteId', blank=True, null=True)  # Field name made lowercase.
    machinetrain_isactive = models.TextField(db_column='MachineTrain_IsActive')  # Field name made lowercase. This field type is a guess.

    class Meta:
        managed = False
        db_table = 'Machine_Train'


class MachineTrainFiles(models.Model):
    pk_filepathid = models.AutoField(db_column='PK_FilePathId', primary_key=True)  # Field name made lowercase.
    fk_machinetrainid = models.IntegerField(db_column='FK_MachineTrainId')  # Field name made lowercase.
    filename = models.TextField(db_column='FileName')  # Field name made lowercase. This field type is a guess.
    upload_date = models.DateTimeField(db_column='Upload_Date')  # Field name made lowercase.
    uploaded_by = models.TextField(db_column='Uploaded_By')  # Field name made lowercase. This field type is a guess.

    class Meta:
        managed = False
        db_table = 'Machine_Train_Files'


class MachineTrainNotes(models.Model):
    pk_machinetrainnoteid = models.AutoField(db_column='PK_MachineTrainNoteId', primary_key=True)  # Field name made lowercase.
    machinetrain_note = models.TextField(db_column='MachineTrain_Note')  # Field name made lowercase. This field type is a guess.
    note_date = models.DateTimeField(db_column='Note_Date')  # Field name made lowercase.
    machinetrainnote_isactive = models.TextField(db_column='MachineTrainNote_IsActive')  # Field name made lowercase. This field type is a guess.
    fk_machinetrainid = models.IntegerField(db_column='FK_MachineTrainId')  # Field name made lowercase.
    machinetrainnote_showonreport = models.TextField(db_column='MachineTrainNote_ShowOnReport')  # Field name made lowercase. This field type is a guess.
    analyst_name = models.TextField(db_column='Analyst_Name')  # Field name made lowercase. This field type is a guess.

    class Meta:
        managed = False
        db_table = 'Machine_Train_Notes'


class MissedSurvey(models.Model):
    pk_missedsurveyid = models.AutoField(db_column='PK_MissedSurveyId', primary_key=True)  # Field name made lowercase.
    fk_machinetrainid = models.IntegerField(db_column='FK_MachineTrainId')  # Field name made lowercase.
    reason = models.TextField(db_column='Reason')  # Field name made lowercase. This field type is a guess.
    comments = models.TextField(db_column='Comments', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    reported_missed_date = models.DateTimeField(db_column='Reported_Missed_Date', blank=True, null=True)  # Field name made lowercase.
    reported_missed_by = models.TextField(db_column='Reported_Missed_By')  # Field name made lowercase. This field type is a guess.
    origin_callid = models.IntegerField(db_column='Origin_CallId', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'Missed_Survey'


class Observation(models.Model):
    pk_observationid = models.AutoField(db_column='PK_ObservationId', primary_key=True)  # Field name made lowercase.
    observation = models.TextField(db_column='Observation')  # Field name made lowercase. This field type is a guess.
    fk_observationtypeid = models.IntegerField(db_column='FK_ObservationTypeId')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'Observation'


class ObservationType(models.Model):
    pk_observationtypeid = models.AutoField(db_column='PK_ObservationTypeId', primary_key=True)  # Field name made lowercase.
    observation_type = models.TextField(db_column='Observation_Type')  # Field name made lowercase. This field type is a guess.

    class Meta:
        managed = False
        db_table = 'Observation_Type'


class PrimaryComponentSubtype(models.Model):
    pk_primarycomponentsubtypeid = models.AutoField(db_column='PK_PrimaryComponentSubtypeId', primary_key=True)  # Field name made lowercase.
    primary_component_subtype = models.TextField(db_column='Primary_Component_Subtype')  # Field name made lowercase. This field type is a guess.
    primarycomponentsubtype_isactive = models.TextField(db_column='PrimaryComponentSubtype_IsActive')  # Field name made lowercase. This field type is a guess.
    fk_primarycomponenttypeid = models.IntegerField(db_column='FK_PrimaryComponentTypeId')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'Primary_Component_Subtype'


class PrimaryComponentType(models.Model):
    pk_primarycomponenttypeid = models.AutoField(db_column='PK_PrimaryComponentTypeId', primary_key=True)  # Field name made lowercase.
    primary_component_type = models.TextField(db_column='Primary_Component_Type')  # Field name made lowercase. This field type is a guess.
    primarycomponenttype_isactive = models.TextField(db_column='PrimaryComponentType_IsActive')  # Field name made lowercase. This field type is a guess.

    class Meta:
        managed = False
        db_table = 'Primary_Component_Type'


class Report(models.Model):
    pk_reportid = models.AutoField(db_column='PK_ReportId', primary_key=True)  # Field name made lowercase.
    fk_faultid = models.IntegerField(db_column='FK_FaultId')  # Field name made lowercase.
    report_date = models.DateTimeField(db_column='Report_Date', blank=True, null=True)  # Field name made lowercase.
    measurement_date = models.DateTimeField(db_column='Measurement_Date', blank=True, null=True)  # Field name made lowercase.
    fk_conditionid = models.IntegerField(db_column='FK_ConditionId')  # Field name made lowercase.
    fk_reporttypeid = models.IntegerField(db_column='FK_ReportTypeId')  # Field name made lowercase.
    fk_reportstageid = models.IntegerField(db_column='FK_ReportStageId', blank=True, null=True)  # Field name made lowercase.
    observations = models.TextField(db_column='Observations', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    actions = models.TextField(db_column='Actions', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    analyst_notes = models.TextField(db_column='Analyst_Notes', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    external_notes = models.TextField(db_column='External_Notes', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    notification_no = models.IntegerField(db_column='Notification_No', blank=True, null=True)  # Field name made lowercase.
    work_order_no = models.IntegerField(db_column='Work_Order_No', blank=True, null=True)  # Field name made lowercase.
    review_comments = models.TextField(db_column='Review_Comments', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    analyst_name = models.TextField(db_column='Analyst_Name', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    reviewer_name = models.TextField(db_column='Reviewer_Name', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    report_isactive = models.TextField(db_column='Report_IsActive')  # Field name made lowercase. This field type is a guess.
    origin_callid = models.IntegerField(db_column='Origin_CallId', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'Report'


class ReportFiles(models.Model):
    pk_filepathid = models.AutoField(db_column='PK_FilePathId', primary_key=True)  # Field name made lowercase.
    fk_reportid = models.IntegerField(db_column='FK_ReportId')  # Field name made lowercase.
    filename = models.TextField(db_column='FileName')  # Field name made lowercase. This field type is a guess.
    upload_date = models.DateTimeField(db_column='Upload_Date')  # Field name made lowercase.
    uploaded_by = models.TextField(db_column='Uploaded_By')  # Field name made lowercase. This field type is a guess.

    class Meta:
        managed = False
        db_table = 'Report_Files'


class ReportStage(models.Model):
    pk_reportstageid = models.AutoField(db_column='PK_ReportStageId', primary_key=True)  # Field name made lowercase.
    report_stage = models.TextField(db_column='Report_Stage')  # Field name made lowercase. This field type is a guess.

    class Meta:
        managed = False
        db_table = 'Report_Stage'


class ReportType(models.Model):
    pk_reporttypeid = models.AutoField(db_column='PK_ReportTypeId', primary_key=True)  # Field name made lowercase.
    report_type = models.TextField(db_column='Report_Type')  # Field name made lowercase. This field type is a guess.

    class Meta:
        managed = False
        db_table = 'Report_Type'


class Route(models.Model):
    pk_routeid = models.AutoField(db_column='PK_RouteId', primary_key=True)  # Field name made lowercase.
    route = models.TextField(db_column='Route')  # Field name made lowercase. This field type is a guess.
    module_code = models.TextField(db_column='Module_Code', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    unit = models.TextField(db_column='Unit', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    cycle_days = models.TextField(db_column='Cycle_Days', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    labour_hours = models.TextField(db_column='Labour_Hours', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    first_call_date = models.DateTimeField(db_column='First_Call_Date', blank=True, null=True)  # Field name made lowercase.
    fk_areaid = models.IntegerField(db_column='FK_AreaId')  # Field name made lowercase.
    route_isactive = models.TextField(db_column='Route_IsActive')  # Field name made lowercase. This field type is a guess.

    class Meta:
        managed = False
        db_table = 'Route'


class RouteCall(models.Model):
    pk_callid = models.AutoField(db_column='PK_CallId', primary_key=True)  # Field name made lowercase.
    call_no = models.IntegerField(db_column='Call_No')  # Field name made lowercase.
    fk_routeid = models.IntegerField(db_column='FK_RouteId')  # Field name made lowercase.
    labour_hours = models.TextField(db_column='Labour_Hours')  # Field name made lowercase. This field type is a guess.
    plan_date = models.DateTimeField(db_column='Plan_Date')  # Field name made lowercase.
    schedule_date = models.DateTimeField(db_column='Schedule_Date')  # Field name made lowercase.
    modified_date = models.DateTimeField(db_column='Modified_Date', blank=True, null=True)  # Field name made lowercase.
    modified_by = models.TextField(db_column='Modified_By', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    complete_date = models.DateTimeField(db_column='Complete_Date', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'Route_Call'


class Site(models.Model):
    pk_siteid = models.AutoField(db_column='PK_SiteId', primary_key=True)  # Field name made lowercase.
    site = models.TextField(db_column='Site')  # Field name made lowercase. This field type is a guess.
    site_isactive = models.TextField(db_column='Site_IsActive')  # Field name made lowercase. This field type is a guess.

    class Meta:
        managed = False
        db_table = 'Site'


class Technology(models.Model):
    pk_technologyid = models.AutoField(db_column='PK_TechnologyId', primary_key=True)  # Field name made lowercase.
    technology = models.TextField(db_column='Technology')  # Field name made lowercase. This field type is a guess.

    class Meta:
        managed = False
        db_table = 'Technology'


class DimDate(models.Model):
    datekey = models.AutoField(db_column='DateKey')  # Field name made lowercase.
    date = models.DateTimeField(db_column='Date')  # Field name made lowercase.
    day = models.TextField(db_column='Day')  # Field name made lowercase. This field type is a guess.
    daysuffix = models.TextField(db_column='DaySuffix')  # Field name made lowercase. This field type is a guess.
    weekday = models.TextField(db_column='Weekday')  # Field name made lowercase. This field type is a guess.
    weekdayname = models.TextField(db_column='WeekDayName')  # Field name made lowercase. This field type is a guess.
    isoweekofyear = models.TextField(db_column='ISOWeekOfYear')  # Field name made lowercase. This field type is a guess.
    month = models.TextField(db_column='Month')  # Field name made lowercase. This field type is a guess.
    monthname = models.TextField(db_column='MonthName')  # Field name made lowercase. This field type is a guess.
    quarter = models.TextField(db_column='Quarter')  # Field name made lowercase. This field type is a guess.
    year = models.IntegerField(db_column='Year')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'dim_Date'


class TempReports(models.Model):
    greater_area = models.TextField(db_column='Greater_Area', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    area = models.TextField(db_column='Area', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    driven_unit_type = models.TextField(db_column='Driven_Unit_Type', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    condition = models.TextField(db_column='Condition', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    condition_magnitude = models.TextField(db_column='Condition_Magnitude', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    actions = models.TextField(db_column='Actions', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    analyst_notes = models.TextField(db_column='Analyst_Notes', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    external_notes = models.TextField(db_column='External_Notes', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    machine_train = models.TextField(db_column='Machine_Train', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    machine_train_long_name = models.TextField(db_column='Machine_Train_Long_Name', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    route = models.TextField(db_column='Route', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    cycle_days = models.TextField(db_column='Cycle_Days', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    faulttypeid = models.IntegerField(db_column='FaultTypeId')  # Field name made lowercase.
    fault_type = models.TextField(db_column='Fault_Type', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    fault_isactive = models.TextField(db_column='Fault_IsActive')  # Field name made lowercase. This field type is a guess.
    status = models.TextField(db_column='Status')  # Field name made lowercase. This field type is a guess.
    reportid = models.IntegerField(db_column='ReportId', blank=True, null=True)  # Field name made lowercase.
    report_date = models.DateTimeField(db_column='Report_Date', blank=True, null=True)  # Field name made lowercase.
    measurement_date = models.DateTimeField(db_column='Measurement_Date', blank=True, null=True)  # Field name made lowercase.
    report_type = models.TextField(db_column='Report_Type', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    report_stage = models.TextField(db_column='Report_Stage', blank=True, null=True)  # Field name made lowercase. This field type is a guess.

    class Meta:
        managed = False
        db_table = 'temp_Reports'


class TstFault(models.Model):
    pk_faultid = models.AutoField(db_column='PK_FaultId', primary_key=True)  # Field name made lowercase.
    fk_machinetrainid = models.IntegerField(db_column='FK_MachineTrainId')  # Field name made lowercase.
    fk_primarycomponenttypeid = models.IntegerField(db_column='FK_PrimaryComponentTypeId', blank=True, null=True)  # Field name made lowercase.
    fk_primarycomponentsubtypeid = models.IntegerField(db_column='FK_PrimaryComponentSubtypeId', blank=True, null=True)  # Field name made lowercase.
    fk_technologyid = models.IntegerField(db_column='FK_TechnologyId')  # Field name made lowercase.
    fk_faulttypeid = models.IntegerField(db_column='FK_FaultTypeId', blank=True, null=True)  # Field name made lowercase.
    fk_faultsubtypeid = models.IntegerField(db_column='FK_FaultSubtypeId', blank=True, null=True)  # Field name made lowercase.
    create_date = models.DateTimeField(db_column='Create_Date')  # Field name made lowercase.
    close_date = models.DateTimeField(db_column='Close_Date', blank=True, null=True)  # Field name made lowercase.
    fault_location = models.TextField(db_column='Fault_Location', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    production_impact_cost = models.TextField(db_column='Production_Impact_Cost', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    fault_isactive = models.TextField(db_column='Fault_IsActive')  # Field name made lowercase. This field type is a guess.
    closure_comment = models.TextField(db_column='Closure_Comment', blank=True, null=True)  # Field name made lowercase. This field type is a guess.

    class Meta:
        managed = False
        db_table = 'tst_Fault'


class TstReport(models.Model):
    pk_reportid = models.AutoField(db_column='PK_ReportId', primary_key=True)  # Field name made lowercase.
    fk_faultid = models.IntegerField(db_column='FK_FaultId')  # Field name made lowercase.
    report_date = models.DateTimeField(db_column='Report_Date', blank=True, null=True)  # Field name made lowercase.
    measurement_date = models.DateTimeField(db_column='Measurement_Date', blank=True, null=True)  # Field name made lowercase.
    fk_conditionid = models.IntegerField(db_column='FK_ConditionId')  # Field name made lowercase.
    fk_reporttypeid = models.IntegerField(db_column='FK_ReportTypeId')  # Field name made lowercase.
    fk_reportstageid = models.IntegerField(db_column='FK_ReportStageId', blank=True, null=True)  # Field name made lowercase.
    observations = models.TextField(db_column='Observations', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    actions = models.TextField(db_column='Actions', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    analyst_notes = models.TextField(db_column='Analyst_Notes', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    external_notes = models.TextField(db_column='External_Notes', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    notification_no = models.IntegerField(db_column='Notification_No', blank=True, null=True)  # Field name made lowercase.
    work_order_no = models.IntegerField(db_column='Work_Order_No', blank=True, null=True)  # Field name made lowercase.
    review_comments = models.TextField(db_column='Review_Comments', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    analyst_name = models.TextField(db_column='Analyst_Name', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    reviewer_name = models.TextField(db_column='Reviewer_Name', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    report_isactive = models.TextField(db_column='Report_IsActive')  # Field name made lowercase. This field type is a guess.
    origin_callid = models.IntegerField(db_column='Origin_CallId', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'tst_Report'


class TstRouteCall(models.Model):
    pk_callid = models.AutoField(db_column='PK_CallId', primary_key=True)  # Field name made lowercase.
    call_no = models.IntegerField(db_column='Call_No')  # Field name made lowercase.
    fk_routeid = models.IntegerField(db_column='FK_RouteId')  # Field name made lowercase.
    labour_hours = models.TextField(db_column='Labour_Hours')  # Field name made lowercase. This field type is a guess.
    plan_date = models.DateTimeField(db_column='Plan_Date')  # Field name made lowercase.
    schedule_date = models.DateTimeField(db_column='Schedule_Date')  # Field name made lowercase.
    modified_date = models.DateTimeField(db_column='Modified_Date', blank=True, null=True)  # Field name made lowercase.
    modified_by = models.TextField(db_column='Modified_By', blank=True, null=True)  # Field name made lowercase. This field type is a guess.
    complete_date = models.DateTimeField(db_column='Complete_Date', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'tst_Route_Call'
