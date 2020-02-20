# This is an auto-generated Django model module.
# You'll have to do the following manually to clean this up:
#   * Rearrange models' order
#   * Make sure each model has one field with primary_key=True
#   * Make sure each ForeignKey has `on_delete` set to the desired behavior.
#   * Remove `managed = False` lines if you wish to allow Django to create, modify, and delete the table
# Feel free to rename the models, but don't rename db_table values or field names.
from django.db import models


class Action(models.Model):
    pk_actionid = models.IntegerField(db_column='PK_ActionId', primary_key=True)  # Field name made lowercase.
    action = models.CharField(db_column='Action', max_length=100)  # Field name made lowercase.
    fk_faulttypeid = models.IntegerField(db_column='FK_FaultTypeId')  # Field name made lowercase.
    action_isactive = models.IntegerField(db_column='Action_IsActive')  # Field name made lowercase.
    action_order = models.IntegerField(db_column='Action_Order')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'action'


class Area(models.Model):
    pk_areaid = models.IntegerField(db_column='PK_AreaId', primary_key=True)  # Field name made lowercase.
    area = models.CharField(db_column='Area', max_length=64)  # Field name made lowercase.
    unit_reference = models.CharField(db_column='Unit_Reference', max_length=4, blank=True, null=True)  # Field name made lowercase.
    greater_area = models.CharField(db_column='Greater_Area', max_length=32)  # Field name made lowercase.
    area_isactive = models.IntegerField(db_column='Area_IsActive')  # Field name made lowercase.
    fk_siteid = models.IntegerField(db_column='FK_SiteId')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'area'


class Condition(models.Model):
    pk_conditionid = models.PositiveIntegerField(db_column='PK_ConditionId', primary_key=True)  # Field name made lowercase.
    condition = models.CharField(db_column='Condition', max_length=32)  # Field name made lowercase.
    condition_magnitude = models.PositiveIntegerField(db_column='Condition_Magnitude')  # Field name made lowercase.
    condition_alt_label = models.CharField(db_column='Condition_Alt_Label', max_length=32, blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'condition'


class DimDate(models.Model):
    datekey = models.IntegerField(db_column='DateKey', primary_key=True)  # Field name made lowercase.
    date = models.DateField(db_column='Date')  # Field name made lowercase.
    day = models.PositiveIntegerField(db_column='Day')  # Field name made lowercase.
    daysuffix = models.CharField(db_column='DaySuffix', max_length=2)  # Field name made lowercase.
    weekday = models.PositiveIntegerField(db_column='Weekday')  # Field name made lowercase.
    weekdayname = models.CharField(db_column='WeekDayName', max_length=10)  # Field name made lowercase.
    isoweekofyear = models.PositiveIntegerField(db_column='ISOWeekOfYear')  # Field name made lowercase.
    month = models.PositiveIntegerField(db_column='Month')  # Field name made lowercase.
    monthname = models.CharField(db_column='MonthName', max_length=10)  # Field name made lowercase.
    quarter = models.PositiveIntegerField(db_column='Quarter')  # Field name made lowercase.
    year = models.IntegerField(db_column='Year')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'dim_date'


class DrivenUnitType(models.Model):
    pk_drivenunittypeid = models.IntegerField(db_column='PK_DrivenUnitTypeId', primary_key=True)  # Field name made lowercase.
    driven_unit_type = models.CharField(db_column='Driven_Unit_Type', max_length=50)  # Field name made lowercase.
    drivenunittype_isactive = models.IntegerField(db_column='DrivenUnitType_IsActive')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'driven_unit_type'


class Fault(models.Model):
    pk_faultid = models.IntegerField(db_column='PK_FaultId', primary_key=True)  # Field name made lowercase.
    fk_machinetrainid = models.IntegerField(db_column='FK_MachineTrainId')  # Field name made lowercase.
    fk_primarycomponenttypeid = models.IntegerField(db_column='FK_PrimaryComponentTypeId', blank=True, null=True)  # Field name made lowercase.
    fk_primarycomponentsubtypeid = models.IntegerField(db_column='FK_PrimaryComponentSubtypeId', blank=True, null=True)  # Field name made lowercase.
    fk_technologyid = models.IntegerField(db_column='FK_TechnologyId')  # Field name made lowercase.
    fk_faulttypeid = models.IntegerField(db_column='FK_FaultTypeId', blank=True, null=True)  # Field name made lowercase.
    fk_faultsubtypeid = models.IntegerField(db_column='FK_FaultSubtypeId', blank=True, null=True)  # Field name made lowercase.
    create_date = models.DateTimeField(db_column='Create_Date')  # Field name made lowercase.
    close_date = models.DateTimeField(db_column='Close_Date', blank=True, null=True)  # Field name made lowercase.
    fault_location = models.CharField(db_column='Fault_Location', max_length=50, blank=True, null=True)  # Field name made lowercase.
    production_impact_cost = models.FloatField(db_column='Production_Impact_Cost', blank=True, null=True)  # Field name made lowercase.
    fault_isactive = models.IntegerField(db_column='Fault_IsActive')  # Field name made lowercase.
    status = models.CharField(db_column='Status', max_length=6, blank=True, null=True)  # Field name made lowercase.
    closure_comment = models.CharField(db_column='Closure_Comment', max_length=255, blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'fault'


class FaultSubtype(models.Model):
    pk_faultsubtypeid = models.IntegerField(db_column='PK_FaultSubtypeId', primary_key=True)  # Field name made lowercase.
    fault_subtype = models.CharField(db_column='Fault_Subtype', max_length=200)  # Field name made lowercase.
    fk_faulttypeid = models.IntegerField(db_column='FK_FaultTypeId')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'fault_subtype'


class FaultType(models.Model):
    pk_faulttypeid = models.IntegerField(db_column='PK_FaultTypeId', primary_key=True)  # Field name made lowercase.
    fault_type = models.CharField(db_column='Fault_Type', max_length=50)  # Field name made lowercase.
    fk_technologyid = models.IntegerField(db_column='FK_TechnologyId')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'fault_type'


class MachineTrain(models.Model):
    pk_machinetrainid = models.IntegerField(db_column='PK_MachineTrainId', primary_key=True)  # Field name made lowercase.
    machine_train = models.CharField(db_column='Machine_Train', max_length=32)  # Field name made lowercase.
    machine_train_long_name = models.CharField(db_column='Machine_Train_Long_Name', max_length=255)  # Field name made lowercase.
    fk_drivenunittypeid = models.IntegerField(db_column='FK_DrivenUnitTypeId')  # Field name made lowercase.
    fk_areaid = models.IntegerField(db_column='FK_AreaId')  # Field name made lowercase.
    fk_routeid = models.IntegerField(db_column='FK_RouteId', blank=True, null=True)  # Field name made lowercase.
    machinetrain_isactive = models.IntegerField(db_column='MachineTrain_IsActive')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'machine_train'


class MachineTrainFiles(models.Model):
    pk_filepathid = models.IntegerField(db_column='PK_FilePathId', primary_key=True)  # Field name made lowercase.
    fk_machinetrainid = models.IntegerField(db_column='FK_MachineTrainId')  # Field name made lowercase.
    filename = models.TextField(db_column='FileName')  # Field name made lowercase.
    upload_date = models.DateTimeField(db_column='Upload_Date')  # Field name made lowercase.
    uploaded_by = models.CharField(db_column='Uploaded_By', max_length=50)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'machine_train_files'


class MachineTrainNotes(models.Model):
    pk_machinetrainnoteid = models.IntegerField(db_column='PK_MachineTrainNoteId', primary_key=True)  # Field name made lowercase.
    machinetrain_note = models.TextField(db_column='MachineTrain_Note')  # Field name made lowercase.
    note_date = models.DateTimeField(db_column='Note_Date')  # Field name made lowercase.
    machinetrainnote_isactive = models.IntegerField(db_column='MachineTrainNote_IsActive')  # Field name made lowercase.
    fk_machinetrainid = models.IntegerField(db_column='FK_MachineTrainId')  # Field name made lowercase.
    machinetrainnote_showonreport = models.IntegerField(db_column='MachineTrainNote_ShowOnReport')  # Field name made lowercase.
    analyst_name = models.CharField(db_column='Analyst_Name', max_length=50)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'machine_train_notes'


class MissedSurvey(models.Model):
    pk_missedsurveyid = models.IntegerField(db_column='PK_MissedSurveyId', primary_key=True)  # Field name made lowercase.
    fk_machinetrainid = models.IntegerField(db_column='FK_MachineTrainId')  # Field name made lowercase.
    reason = models.CharField(db_column='Reason', max_length=255)  # Field name made lowercase.
    comments = models.CharField(db_column='Comments', max_length=500, blank=True, null=True)  # Field name made lowercase.
    reported_missed_date = models.DateField(db_column='Reported_Missed_Date', blank=True, null=True)  # Field name made lowercase.
    reported_missed_by = models.CharField(db_column='Reported_Missed_By', max_length=100)  # Field name made lowercase.
    origin_callid = models.IntegerField(db_column='Origin_CallId', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'missed_survey'


class Observation(models.Model):
    pk_observationid = models.IntegerField(db_column='PK_ObservationId', primary_key=True)  # Field name made lowercase.
    observation = models.CharField(db_column='Observation', max_length=255)  # Field name made lowercase.
    fk_observationtypeid = models.IntegerField(db_column='FK_ObservationTypeId')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'observation'


class ObservationType(models.Model):
    pk_observationtypeid = models.IntegerField(db_column='PK_ObservationTypeId', primary_key=True)  # Field name made lowercase.
    observation_type = models.CharField(db_column='Observation_Type', max_length=80)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'observation_type'


class PrimaryComponentSubtype(models.Model):
    pk_primarycomponentsubtypeid = models.IntegerField(db_column='PK_PrimaryComponentSubtypeId', primary_key=True)  # Field name made lowercase.
    primary_component_subtype = models.CharField(db_column='Primary_Component_Subtype', max_length=50)  # Field name made lowercase.
    primarycomponentsubtype_isactive = models.IntegerField(db_column='PrimaryComponentSubtype_IsActive')  # Field name made lowercase.
    fk_primarycomponenttypeid = models.IntegerField(db_column='FK_PrimaryComponentTypeId')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'primary_component_subtype'


class PrimaryComponentType(models.Model):
    pk_primarycomponenttypeid = models.IntegerField(db_column='PK_PrimaryComponentTypeId', primary_key=True)  # Field name made lowercase.
    primary_component_type = models.CharField(db_column='Primary_Component_Type', max_length=50)  # Field name made lowercase.
    primarycomponenttype_isactive = models.IntegerField(db_column='PrimaryComponentType_IsActive')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'primary_component_type'


class Report(models.Model):
    pk_reportid = models.IntegerField(db_column='PK_ReportId', primary_key=True)  # Field name made lowercase.
    fk_faultid = models.IntegerField(db_column='FK_FaultId')  # Field name made lowercase.
    report_date = models.DateField(db_column='Report_Date', blank=True, null=True)  # Field name made lowercase.
    measurement_date = models.DateField(db_column='Measurement_Date', blank=True, null=True)  # Field name made lowercase.
    fk_conditionid = models.IntegerField(db_column='FK_ConditionId')  # Field name made lowercase.
    fk_reporttypeid = models.IntegerField(db_column='FK_ReportTypeId')  # Field name made lowercase.
    fk_reportstageid = models.IntegerField(db_column='FK_ReportStageId', blank=True, null=True)  # Field name made lowercase.
    observations = models.CharField(db_column='Observations', max_length=2500, blank=True, null=True)  # Field name made lowercase.
    actions = models.CharField(db_column='Actions', max_length=2500, blank=True, null=True)  # Field name made lowercase.
    analyst_notes = models.TextField(db_column='Analyst_Notes', blank=True, null=True)  # Field name made lowercase.
    external_notes = models.CharField(db_column='External_Notes', max_length=1000, blank=True, null=True)  # Field name made lowercase.
    notification_no = models.IntegerField(db_column='Notification_No', blank=True, null=True)  # Field name made lowercase.
    work_order_no = models.IntegerField(db_column='Work_Order_No', blank=True, null=True)  # Field name made lowercase.
    review_comments = models.CharField(db_column='Review_Comments', max_length=2500, blank=True, null=True)  # Field name made lowercase.
    analyst_name = models.CharField(db_column='Analyst_Name', max_length=100, blank=True, null=True)  # Field name made lowercase.
    reviewer_name = models.CharField(db_column='Reviewer_Name', max_length=100, blank=True, null=True)  # Field name made lowercase.
    report_isactive = models.IntegerField(db_column='Report_IsActive')  # Field name made lowercase.
    origin_callid = models.IntegerField(db_column='Origin_CallId', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'report'


class ReportFiles(models.Model):
    pk_filepathid = models.IntegerField(db_column='PK_FilePathId', primary_key=True)  # Field name made lowercase.
    fk_reportid = models.IntegerField(db_column='FK_ReportId')  # Field name made lowercase.
    filename = models.TextField(db_column='FileName')  # Field name made lowercase.
    upload_date = models.DateTimeField(db_column='Upload_Date')  # Field name made lowercase.
    uploaded_by = models.CharField(db_column='Uploaded_By', max_length=50)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'report_files'


class ReportStage(models.Model):
    pk_reportstageid = models.PositiveIntegerField(db_column='PK_ReportStageId', primary_key=True)  # Field name made lowercase.
    report_stage = models.CharField(db_column='Report_Stage', max_length=50)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'report_stage'


class ReportType(models.Model):
    pk_reporttypeid = models.PositiveIntegerField(db_column='PK_ReportTypeId', primary_key=True)  # Field name made lowercase.
    report_type = models.CharField(db_column='Report_Type', max_length=50)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'report_type'


class Route(models.Model):
    pk_routeid = models.IntegerField(db_column='PK_RouteId', primary_key=True)  # Field name made lowercase.
    route = models.CharField(db_column='Route', max_length=255)  # Field name made lowercase.
    module_code = models.CharField(db_column='Module_Code', max_length=16, blank=True, null=True)  # Field name made lowercase.
    unit = models.CharField(db_column='Unit', max_length=16, blank=True, null=True)  # Field name made lowercase.
    cycle_days = models.FloatField(db_column='Cycle_Days', blank=True, null=True)  # Field name made lowercase.
    labour_hours = models.FloatField(db_column='Labour_Hours', blank=True, null=True)  # Field name made lowercase.
    first_call_date = models.DateField(db_column='First_Call_Date', blank=True, null=True)  # Field name made lowercase.
    fk_areaid = models.IntegerField(db_column='FK_AreaId')  # Field name made lowercase.
    route_isactive = models.IntegerField(db_column='Route_IsActive')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'route'


class RouteCall(models.Model):
    pk_callid = models.IntegerField(db_column='PK_CallId', primary_key=True)  # Field name made lowercase.
    call_no = models.IntegerField(db_column='Call_No')  # Field name made lowercase.
    fk_routeid = models.IntegerField(db_column='FK_RouteId')  # Field name made lowercase.
    labour_hours = models.FloatField(db_column='Labour_Hours')  # Field name made lowercase.
    plan_date = models.DateField(db_column='Plan_Date')  # Field name made lowercase.
    schedule_date = models.DateField(db_column='Schedule_Date')  # Field name made lowercase.
    modified_date = models.DateTimeField(db_column='Modified_Date', blank=True, null=True)  # Field name made lowercase.
    modified_by = models.CharField(db_column='Modified_By', max_length=32, blank=True, null=True)  # Field name made lowercase.
    complete_date = models.DateTimeField(db_column='Complete_Date', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'route_call'


class Site(models.Model):
    pk_siteid = models.IntegerField(db_column='PK_SiteId', primary_key=True)  # Field name made lowercase.
    site = models.CharField(db_column='Site', max_length=50)  # Field name made lowercase.
    site_isactive = models.IntegerField(db_column='Site_IsActive')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'site'


class Technology(models.Model):
    pk_technologyid = models.IntegerField(db_column='PK_TechnologyId', primary_key=True)  # Field name made lowercase.
    technology = models.CharField(db_column='Technology', max_length=50)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'technology'


class TempReports(models.Model):
    greater_area = models.CharField(db_column='Greater_Area', max_length=32, blank=True, null=True)  # Field name made lowercase.
    area = models.CharField(db_column='Area', max_length=64, blank=True, null=True)  # Field name made lowercase.
    driven_unit_type = models.CharField(db_column='Driven_Unit_Type', max_length=50, blank=True, null=True)  # Field name made lowercase.
    condition = models.CharField(db_column='Condition', max_length=32, blank=True, null=True)  # Field name made lowercase.
    condition_magnitude = models.PositiveIntegerField(db_column='Condition_Magnitude', blank=True, null=True)  # Field name made lowercase.
    actions = models.CharField(db_column='Actions', max_length=2500, blank=True, null=True)  # Field name made lowercase.
    analyst_notes = models.TextField(db_column='Analyst_Notes', blank=True, null=True)  # Field name made lowercase.
    external_notes = models.CharField(db_column='External_Notes', max_length=1000, blank=True, null=True)  # Field name made lowercase.
    machine_train = models.CharField(db_column='Machine_Train', max_length=32, blank=True, null=True)  # Field name made lowercase.
    machine_train_long_name = models.CharField(db_column='Machine_Train_Long_Name', max_length=255, blank=True, null=True)  # Field name made lowercase.
    route = models.CharField(db_column='Route', max_length=255, blank=True, null=True)  # Field name made lowercase.
    cycle_days = models.FloatField(db_column='Cycle_Days', blank=True, null=True)  # Field name made lowercase.
    faulttypeid = models.IntegerField(db_column='FaultTypeId')  # Field name made lowercase.
    fault_type = models.CharField(db_column='Fault_Type', max_length=50, blank=True, null=True)  # Field name made lowercase.
    fault_isactive = models.IntegerField(db_column='Fault_IsActive')  # Field name made lowercase.
    status = models.CharField(db_column='Status', max_length=6)  # Field name made lowercase.
    reportid = models.IntegerField(db_column='ReportId', blank=True, null=True)  # Field name made lowercase.
    report_date = models.DateField(db_column='Report_Date', blank=True, null=True)  # Field name made lowercase.
    measurement_date = models.DateField(db_column='Measurement_Date', blank=True, null=True)  # Field name made lowercase.
    report_type = models.CharField(db_column='Report_Type', max_length=50, blank=True, null=True)  # Field name made lowercase.
    report_stage = models.CharField(db_column='Report_Stage', max_length=50, blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'temp_reports'


class TstFault(models.Model):
    pk_faultid = models.IntegerField(db_column='PK_FaultId', primary_key=True)  # Field name made lowercase.
    fk_machinetrainid = models.IntegerField(db_column='FK_MachineTrainId')  # Field name made lowercase.
    fk_primarycomponenttypeid = models.IntegerField(db_column='FK_PrimaryComponentTypeId', blank=True, null=True)  # Field name made lowercase.
    fk_primarycomponentsubtypeid = models.IntegerField(db_column='FK_PrimaryComponentSubtypeId', blank=True, null=True)  # Field name made lowercase.
    fk_technologyid = models.IntegerField(db_column='FK_TechnologyId')  # Field name made lowercase.
    fk_faulttypeid = models.IntegerField(db_column='FK_FaultTypeId', blank=True, null=True)  # Field name made lowercase.
    fk_faultsubtypeid = models.IntegerField(db_column='FK_FaultSubtypeId', blank=True, null=True)  # Field name made lowercase.
    create_date = models.DateTimeField(db_column='Create_Date')  # Field name made lowercase.
    close_date = models.DateTimeField(db_column='Close_Date', blank=True, null=True)  # Field name made lowercase.
    fault_location = models.CharField(db_column='Fault_Location', max_length=50, blank=True, null=True)  # Field name made lowercase.
    production_impact_cost = models.FloatField(db_column='Production_Impact_Cost', blank=True, null=True)  # Field name made lowercase.
    fault_isactive = models.IntegerField(db_column='Fault_IsActive')  # Field name made lowercase.
    status = models.CharField(db_column='Status', max_length=6)  # Field name made lowercase.
    closure_comment = models.CharField(db_column='Closure_Comment', max_length=255, blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'tst_fault'


class TstReport(models.Model):
    pk_reportid = models.IntegerField(db_column='PK_ReportId', primary_key=True)  # Field name made lowercase.
    fk_faultid = models.IntegerField(db_column='FK_FaultId')  # Field name made lowercase.
    report_date = models.DateField(db_column='Report_Date', blank=True, null=True)  # Field name made lowercase.
    measurement_date = models.DateField(db_column='Measurement_Date', blank=True, null=True)  # Field name made lowercase.
    fk_conditionid = models.IntegerField(db_column='FK_ConditionId')  # Field name made lowercase.
    fk_reporttypeid = models.IntegerField(db_column='FK_ReportTypeId')  # Field name made lowercase.
    fk_reportstageid = models.IntegerField(db_column='FK_ReportStageId', blank=True, null=True)  # Field name made lowercase.
    observations = models.CharField(db_column='Observations', max_length=2500, blank=True, null=True)  # Field name made lowercase.
    actions = models.CharField(db_column='Actions', max_length=2500, blank=True, null=True)  # Field name made lowercase.
    analyst_notes = models.TextField(db_column='Analyst_Notes', blank=True, null=True)  # Field name made lowercase.
    external_notes = models.CharField(db_column='External_Notes', max_length=1000, blank=True, null=True)  # Field name made lowercase.
    notification_no = models.IntegerField(db_column='Notification_No', blank=True, null=True)  # Field name made lowercase.
    work_order_no = models.IntegerField(db_column='Work_Order_No', blank=True, null=True)  # Field name made lowercase.
    review_comments = models.CharField(db_column='Review_Comments', max_length=2500, blank=True, null=True)  # Field name made lowercase.
    analyst_name = models.CharField(db_column='Analyst_Name', max_length=100, blank=True, null=True)  # Field name made lowercase.
    reviewer_name = models.CharField(db_column='Reviewer_Name', max_length=100, blank=True, null=True)  # Field name made lowercase.
    report_isactive = models.IntegerField(db_column='Report_IsActive')  # Field name made lowercase.
    origin_callid = models.IntegerField(db_column='Origin_CallId', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'tst_report'


class TstRouteCall(models.Model):
    pk_callid = models.IntegerField(db_column='PK_CallId', primary_key=True)  # Field name made lowercase.
    call_no = models.IntegerField(db_column='Call_No')  # Field name made lowercase.
    fk_routeid = models.IntegerField(db_column='FK_RouteId')  # Field name made lowercase.
    labour_hours = models.FloatField(db_column='Labour_Hours')  # Field name made lowercase.
    plan_date = models.DateField(db_column='Plan_Date')  # Field name made lowercase.
    schedule_date = models.DateField(db_column='Schedule_Date')  # Field name made lowercase.
    modified_date = models.DateTimeField(db_column='Modified_Date', blank=True, null=True)  # Field name made lowercase.
    modified_by = models.CharField(db_column='Modified_By', max_length=32, blank=True, null=True)  # Field name made lowercase.
    complete_date = models.DateTimeField(db_column='Complete_Date', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'tst_route_call'
