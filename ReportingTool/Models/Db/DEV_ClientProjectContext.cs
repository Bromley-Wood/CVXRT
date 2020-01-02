using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Reportingtool.Models.Db
{
    public partial class DEV_ClientProjectContext : DbContext
    {
        public DEV_ClientProjectContext()
        {
        }

        public DEV_ClientProjectContext(DbContextOptions<DEV_ClientProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Action> Action { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Condition> Condition { get; set; }
        public virtual DbSet<DimDate> DimDate { get; set; }
        public virtual DbSet<DrivenUnitType> DrivenUnitType { get; set; }
        public virtual DbSet<Fault> Fault { get; set; }
        public virtual DbSet<FaultSubtype> FaultSubtype { get; set; }
        public virtual DbSet<FaultType> FaultType { get; set; }
        public virtual DbSet<MachineTrain> MachineTrain { get; set; }
        public virtual DbSet<MachineTrainFiles> MachineTrainFiles { get; set; }
        public virtual DbSet<MachineTrainNotes> MachineTrainNotes { get; set; }
        public virtual DbSet<MissedSurvey> MissedSurvey { get; set; }
        public virtual DbSet<Observation> Observation { get; set; }
        public virtual DbSet<ObservationType> ObservationType { get; set; }
        public virtual DbSet<PrimaryComponentSubtype> PrimaryComponentSubtype { get; set; }
        public virtual DbSet<PrimaryComponentType> PrimaryComponentType { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<ReportStage> ReportStage { get; set; }
        public virtual DbSet<ReportType> ReportType { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<RouteCall> RouteCall { get; set; }
        public virtual DbSet<Site> Site { get; set; }
        public virtual DbSet<Technology> Technology { get; set; }
        public virtual DbSet<TempReports> TempReports { get; set; }
        public virtual DbSet<TstFault> TstFault { get; set; }
        public virtual DbSet<TstReport> TstReport { get; set; }
        public virtual DbSet<TstRouteCall> TstRouteCall { get; set; }
        public virtual DbSet<VConditionDaily> VConditionDaily { get; set; }
        public virtual DbSet<VConditionWeekly> VConditionWeekly { get; set; }
        public virtual DbSet<VCreateReports> VCreateReports { get; set; }
        public virtual DbSet<VLatestReportByFault> VLatestReportByFault { get; set; }
        public virtual DbSet<VMachinesLastMeasured> VMachinesLastMeasured { get; set; }
        public virtual DbSet<VReportSummary> VReportSummary { get; set; }
        public virtual DbSet<VRouteMachines> VRouteMachines { get; set; }
        public virtual DbSet<VRoutes> VRoutes { get; set; }
        public virtual DbSet<VTstReportSummary> VTstReportSummary { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>(entity =>
            {
                entity.HasKey(e => e.PkActionId);

                entity.Property(e => e.PkActionId).HasColumnName("PK_ActionId");

                entity.Property(e => e.Action1)
                    .IsRequired()
                    .HasColumnName("Action")
                    .HasMaxLength(100);

                entity.Property(e => e.ActionIsActive).HasColumnName("Action_IsActive");

                entity.Property(e => e.ActionOrder).HasColumnName("Action_Order");

                entity.Property(e => e.FkFaultTypeId).HasColumnName("FK_FaultTypeId");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.PkAreaId);

                entity.Property(e => e.PkAreaId).HasColumnName("PK_AreaId");

                entity.Property(e => e.Area1)
                    .IsRequired()
                    .HasColumnName("Area")
                    .HasMaxLength(64);

                entity.Property(e => e.AreaIsActive).HasColumnName("Area_IsActive");

                entity.Property(e => e.FkSiteId).HasColumnName("FK_SiteId");

                entity.Property(e => e.GreaterArea)
                    .IsRequired()
                    .HasColumnName("Greater_Area")
                    .HasMaxLength(32);

                entity.Property(e => e.UnitReference)
                    .HasColumnName("Unit_Reference")
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<Condition>(entity =>
            {
                entity.HasKey(e => e.PkConditionId);

                entity.Property(e => e.PkConditionId)
                    .HasColumnName("PK_ConditionId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Condition1)
                    .IsRequired()
                    .HasColumnName("Condition")
                    .HasMaxLength(32);

                entity.Property(e => e.ConditionAltLabel)
                    .HasColumnName("Condition_Alt_Label")
                    .HasMaxLength(32);

                entity.Property(e => e.ConditionMagnitude).HasColumnName("Condition_Magnitude");
            });

            modelBuilder.Entity<DimDate>(entity =>
            {
                entity.HasKey(e => e.DateKey)
                    .HasName("PK__dim_Date__40DF45E356BE0DBF");

                entity.ToTable("dim_Date");

                entity.Property(e => e.DateKey).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DaySuffix)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IsoweekOfYear).HasColumnName("ISOWeekOfYear");

                entity.Property(e => e.MonthName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WeekDayName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DrivenUnitType>(entity =>
            {
                entity.HasKey(e => e.PkDrivenUnitTypeId);

                entity.ToTable("Driven_Unit_Type");

                entity.Property(e => e.PkDrivenUnitTypeId).HasColumnName("PK_DrivenUnitTypeId");

                entity.Property(e => e.DrivenUnitType1)
                    .IsRequired()
                    .HasColumnName("Driven_Unit_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.DrivenUnitTypeIsActive).HasColumnName("DrivenUnitType_IsActive");
            });

            modelBuilder.Entity<Fault>(entity =>
            {
                entity.HasKey(e => e.PkFaultId);

                entity.Property(e => e.PkFaultId).HasColumnName("PK_FaultId");

                entity.Property(e => e.CloseDate)
                    .HasColumnName("Close_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FaultIsActive).HasColumnName("Fault_IsActive");

                entity.Property(e => e.FaultLocation)
                    .HasColumnName("Fault_Location")
                    .HasMaxLength(50);

                entity.Property(e => e.FkFaultSubtypeId).HasColumnName("FK_FaultSubtypeId");

                entity.Property(e => e.FkFaultTypeId).HasColumnName("FK_FaultTypeId");

                entity.Property(e => e.FkMachineTrainId).HasColumnName("FK_MachineTrainId");

                entity.Property(e => e.FkPrimaryComponentSubtypeId).HasColumnName("FK_PrimaryComponentSubtypeId");

                entity.Property(e => e.FkPrimaryComponentTypeId).HasColumnName("FK_PrimaryComponentTypeId");

                entity.Property(e => e.FkTechnologyId).HasColumnName("FK_TechnologyId");

                entity.Property(e => e.ProductionImpactCost).HasColumnName("Production_Impact_Cost");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FaultSubtype>(entity =>
            {
                entity.HasKey(e => e.PkFaultSubtypeId)
                    .HasName("PK_FaultSubtypeId");

                entity.ToTable("Fault_Subtype");

                entity.Property(e => e.PkFaultSubtypeId).HasColumnName("PK_FaultSubtypeId");

                entity.Property(e => e.FaultSubtype1)
                    .IsRequired()
                    .HasColumnName("Fault_Subtype")
                    .HasMaxLength(200);

                entity.Property(e => e.FkFaultTypeId).HasColumnName("FK_FaultTypeId");
            });

            modelBuilder.Entity<FaultType>(entity =>
            {
                entity.HasKey(e => e.PkFaultTypeId);

                entity.ToTable("Fault_Type");

                entity.Property(e => e.PkFaultTypeId).HasColumnName("PK_FaultTypeId");

                entity.Property(e => e.FaultType1)
                    .IsRequired()
                    .HasColumnName("Fault_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.FkTechnologyId).HasColumnName("FK_TechnologyId");
            });

            modelBuilder.Entity<MachineTrain>(entity =>
            {
                entity.HasKey(e => e.PkMachineTrainId)
                    .HasName("PK_MachineTrain");

                entity.ToTable("Machine_Train");

                entity.Property(e => e.PkMachineTrainId).HasColumnName("PK_MachineTrainId");

                entity.Property(e => e.FkAreaId).HasColumnName("FK_AreaId");

                entity.Property(e => e.FkDrivenUnitTypeId).HasColumnName("FK_DrivenUnitTypeId");

                entity.Property(e => e.FkRouteId).HasColumnName("FK_RouteId");

                entity.Property(e => e.MachineTrain1)
                    .IsRequired()
                    .HasColumnName("Machine_Train")
                    .HasMaxLength(32);

                entity.Property(e => e.MachineTrainIsActive).HasColumnName("MachineTrain_IsActive");

                entity.Property(e => e.MachineTrainLongName)
                    .IsRequired()
                    .HasColumnName("Machine_Train_Long_Name")
                    .HasMaxLength(255);

                entity.HasMany(e => e.Machine_Train_Notes).WithOne().HasForeignKey(FK => FK.FkMachineTrainId);

            });

            modelBuilder.Entity<MachineTrainFiles>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Machine_Train_Files");

                entity.Property(e => e.FileName).IsRequired();

                entity.Property(e => e.FkMachineTrainId).HasColumnName("FK_MachineTrainId");

                entity.Property(e => e.PkFilePathId)
                    .HasColumnName("PK_FilePathId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UploadDate)
                    .HasColumnName("Upload_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UploadedBy)
                    .IsRequired()
                    .HasColumnName("Uploaded_By")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MachineTrainNotes>(entity =>
            {
                entity.HasKey(e => e.PkMachineTrainNoteId);

                entity.ToTable("Machine_Train_Notes");

                entity.Property(e => e.PkMachineTrainNoteId).HasColumnName("PK_MachineTrainNoteId");

                entity.Property(e => e.AnalystName)
                    .IsRequired()
                    .HasColumnName("Analyst_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.FkMachineTrainId).HasColumnName("FK_MachineTrainId");

                entity.Property(e => e.MachineTrainNote)
                    .IsRequired()
                    .HasColumnName("MachineTrain_Note");

                entity.Property(e => e.MachineTrainNoteIsActive).HasColumnName("MachineTrainNote_IsActive");

                entity.Property(e => e.MachineTrainNoteShowOnReport).HasColumnName("MachineTrainNote_ShowOnReport");

                entity.Property(e => e.NoteDate)
                    .HasColumnName("Note_Date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MissedSurvey>(entity =>
            {
                entity.HasKey(e => e.PkMissedSurveyId)
                    .HasName("PK_MissedSurveyId");

                entity.ToTable("Missed_Survey");

                entity.Property(e => e.PkMissedSurveyId).HasColumnName("PK_MissedSurveyId");

                entity.Property(e => e.Comments).HasMaxLength(500);

                entity.Property(e => e.FkMachineTrainId).HasColumnName("FK_MachineTrainId");

                entity.Property(e => e.OriginCallId).HasColumnName("Origin_CallId");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ReportedMissedBy)
                    .IsRequired()
                    .HasColumnName("Reported_Missed_By")
                    .HasMaxLength(100);

                entity.Property(e => e.ReportedMissedDate)
                    .HasColumnName("Reported_Missed_Date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Observation>(entity =>
            {
                entity.HasKey(e => e.PkObservationId);

                entity.Property(e => e.PkObservationId).HasColumnName("PK_ObservationId");

                entity.Property(e => e.FkObservationTypeId).HasColumnName("FK_ObservationTypeId");

                entity.Property(e => e.Observation1)
                    .IsRequired()
                    .HasColumnName("Observation")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ObservationType>(entity =>
            {
                entity.HasKey(e => e.PkObservationTypeId);

                entity.ToTable("Observation_Type");

                entity.Property(e => e.PkObservationTypeId).HasColumnName("PK_ObservationTypeId");

                entity.Property(e => e.ObservationType1)
                    .IsRequired()
                    .HasColumnName("Observation_Type")
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<PrimaryComponentSubtype>(entity =>
            {
                entity.HasKey(e => e.PkPrimaryComponentSubtypeId);

                entity.ToTable("Primary_Component_Subtype");

                entity.Property(e => e.PkPrimaryComponentSubtypeId).HasColumnName("PK_PrimaryComponentSubtypeId");

                entity.Property(e => e.FkPrimaryComponentTypeId).HasColumnName("FK_PrimaryComponentTypeId");

                entity.Property(e => e.PrimaryComponentSubtype1)
                    .IsRequired()
                    .HasColumnName("Primary_Component_Subtype")
                    .HasMaxLength(50);

                entity.Property(e => e.PrimaryComponentSubtypeIsActive).HasColumnName("PrimaryComponentSubtype_IsActive");
            });

            modelBuilder.Entity<PrimaryComponentType>(entity =>
            {
                entity.HasKey(e => e.PkPrimaryComponentTypeId);

                entity.ToTable("Primary_Component_Type");

                entity.Property(e => e.PkPrimaryComponentTypeId).HasColumnName("PK_PrimaryComponentTypeId");

                entity.Property(e => e.PrimaryComponentType1)
                    .IsRequired()
                    .HasColumnName("Primary_Component_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.PrimaryComponentTypeIsActive).HasColumnName("PrimaryComponentType_IsActive");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => e.PkReportId);

                entity.Property(e => e.PkReportId).HasColumnName("PK_ReportId");

                entity.Property(e => e.Actions).HasMaxLength(2500);

                entity.Property(e => e.AnalystName)
                    .HasColumnName("Analyst_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.AnalystNotes).HasColumnName("Analyst_Notes");

                entity.Property(e => e.ExternalNotes)
                    .HasColumnName("External_Notes")
                    .HasMaxLength(1000);

                entity.Property(e => e.FkConditionId).HasColumnName("FK_ConditionId");

                entity.Property(e => e.FkFaultId).HasColumnName("FK_FaultId");

                entity.Property(e => e.FkReportStageId).HasColumnName("FK_ReportStageId");

                entity.Property(e => e.FkReportTypeId).HasColumnName("FK_ReportTypeId");

                entity.Property(e => e.MeasurementDate)
                    .HasColumnName("Measurement_Date")
                    .HasColumnType("date");

                entity.Property(e => e.NotificationNo).HasColumnName("Notification_No");

                entity.Property(e => e.Observations).HasMaxLength(2500);

                entity.Property(e => e.ReportDate)
                    .HasColumnName("Report_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ReportIsActive).HasColumnName("Report_IsActive");

                entity.Property(e => e.ReviewComments)
                    .HasColumnName("Review_Comments")
                    .HasMaxLength(2500);

                entity.Property(e => e.ReviewerName)
                    .HasColumnName("Reviewer_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.WorkOrderNo).HasColumnName("Work_Order_No");
            });

            modelBuilder.Entity<ReportStage>(entity =>
            {
                entity.HasKey(e => e.PkReportStageId);

                entity.ToTable("Report_Stage");

                entity.Property(e => e.PkReportStageId)
                    .HasColumnName("PK_ReportStageId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ReportStage1)
                    .IsRequired()
                    .HasColumnName("Report_Stage")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ReportType>(entity =>
            {
                entity.HasKey(e => e.PkReportTypeId);

                entity.ToTable("Report_Type");

                entity.Property(e => e.PkReportTypeId)
                    .HasColumnName("PK_ReportTypeId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ReportType1)
                    .IsRequired()
                    .HasColumnName("Report_Type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => e.PkRouteId);

                entity.Property(e => e.PkRouteId).HasColumnName("PK_RouteId");

                entity.Property(e => e.CycleDays).HasColumnName("Cycle_Days");

                entity.Property(e => e.FirstCallDate)
                    .HasColumnName("First_Call_Date")
                    .HasColumnType("date");

                entity.Property(e => e.FkAreaId).HasColumnName("FK_AreaId");

                entity.Property(e => e.LabourHours).HasColumnName("Labour_Hours");

                entity.Property(e => e.ModuleCode)
                    .HasColumnName("Module_Code")
                    .HasMaxLength(16);

                entity.Property(e => e.Route1)
                    .IsRequired()
                    .HasColumnName("Route")
                    .HasMaxLength(255);

                entity.Property(e => e.RouteIsActive).HasColumnName("Route_IsActive");

                entity.Property(e => e.Unit).HasMaxLength(16);
            });

            modelBuilder.Entity<RouteCall>(entity =>
            {
                entity.HasKey(e => e.PkCallId);

                entity.ToTable("Route_Call");

                entity.Property(e => e.PkCallId).HasColumnName("PK_CallId");

                entity.Property(e => e.CallNo).HasColumnName("Call_No");

                entity.Property(e => e.CompleteDate)
                    .HasColumnName("Complete_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FkRouteId).HasColumnName("FK_RouteId");

                entity.Property(e => e.LabourHours).HasColumnName("Labour_Hours");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("Modified_By")
                    .HasMaxLength(32);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("Modified_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PlanDate)
                    .HasColumnName("Plan_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ScheduleDate)
                    .HasColumnName("Schedule_Date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.HasKey(e => e.PkSiteId);

                entity.Property(e => e.PkSiteId).HasColumnName("PK_SiteId");

                entity.Property(e => e.Site1)
                    .IsRequired()
                    .HasColumnName("Site")
                    .HasMaxLength(50);

                entity.Property(e => e.SiteIsActive).HasColumnName("Site_IsActive");
            });

            modelBuilder.Entity<Technology>(entity =>
            {
                entity.HasKey(e => e.PkTechnologyId);

                entity.Property(e => e.PkTechnologyId).HasColumnName("PK_TechnologyId");

                entity.Property(e => e.Technology1)
                    .IsRequired()
                    .HasColumnName("Technology")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TempReports>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("temp_Reports");

                entity.Property(e => e.Actions).HasMaxLength(2500);

                entity.Property(e => e.AnalystNotes).HasColumnName("Analyst_Notes");

                entity.Property(e => e.Area).HasMaxLength(64);

                entity.Property(e => e.Condition).HasMaxLength(32);

                entity.Property(e => e.ConditionMagnitude).HasColumnName("Condition_Magnitude");

                entity.Property(e => e.CycleDays).HasColumnName("Cycle_Days");

                entity.Property(e => e.DrivenUnitType)
                    .HasColumnName("Driven_Unit_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.ExternalNotes)
                    .HasColumnName("External_Notes")
                    .HasMaxLength(1000);

                entity.Property(e => e.FaultIsActive).HasColumnName("Fault_IsActive");

                entity.Property(e => e.FaultType)
                    .HasColumnName("Fault_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.GreaterArea)
                    .HasColumnName("Greater_Area")
                    .HasMaxLength(32);

                entity.Property(e => e.MachineTrain)
                    .HasColumnName("Machine_Train")
                    .HasMaxLength(32);

                entity.Property(e => e.MachineTrainLongName)
                    .HasColumnName("Machine_Train_Long_Name")
                    .HasMaxLength(255);

                entity.Property(e => e.MeasurementDate)
                    .HasColumnName("Measurement_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ReportDate)
                    .HasColumnName("Report_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ReportStage)
                    .HasColumnName("Report_Stage")
                    .HasMaxLength(50);

                entity.Property(e => e.ReportType)
                    .HasColumnName("Report_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.Route).HasMaxLength(255);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TstFault>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tst_Fault");

                entity.Property(e => e.CloseDate)
                    .HasColumnName("Close_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FaultIsActive).HasColumnName("Fault_IsActive");

                entity.Property(e => e.FaultLocation)
                    .HasColumnName("Fault_Location")
                    .HasMaxLength(50);

                entity.Property(e => e.FkFaultSubtypeId).HasColumnName("FK_FaultSubtypeId");

                entity.Property(e => e.FkFaultTypeId).HasColumnName("FK_FaultTypeId");

                entity.Property(e => e.FkMachineTrainId).HasColumnName("FK_MachineTrainId");

                entity.Property(e => e.FkPrimaryComponentSubtypeId).HasColumnName("FK_PrimaryComponentSubtypeId");

                entity.Property(e => e.FkPrimaryComponentTypeId).HasColumnName("FK_PrimaryComponentTypeId");

                entity.Property(e => e.FkTechnologyId).HasColumnName("FK_TechnologyId");

                entity.Property(e => e.PkFaultId)
                    .HasColumnName("PK_FaultId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ProductionImpactCost).HasColumnName("Production_Impact_Cost");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TstReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tst_Report");

                entity.Property(e => e.Actions).HasMaxLength(2500);

                entity.Property(e => e.AnalystName)
                    .HasColumnName("Analyst_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.AnalystNotes).HasColumnName("Analyst_Notes");

                entity.Property(e => e.ExternalNotes)
                    .HasColumnName("External_Notes")
                    .HasMaxLength(1000);

                entity.Property(e => e.FkConditionId).HasColumnName("FK_ConditionId");

                entity.Property(e => e.FkFaultId).HasColumnName("FK_FaultId");

                entity.Property(e => e.FkReportStageId).HasColumnName("FK_ReportStageId");

                entity.Property(e => e.FkReportTypeId).HasColumnName("FK_ReportTypeId");

                entity.Property(e => e.MeasurementDate)
                    .HasColumnName("Measurement_Date")
                    .HasColumnType("date");

                entity.Property(e => e.NotificationNo).HasColumnName("Notification_No");

                entity.Property(e => e.Observations).HasMaxLength(2500);

                entity.Property(e => e.OriginCallId).HasColumnName("Origin_CallId");

                entity.Property(e => e.PkReportId)
                    .HasColumnName("PK_ReportId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ReportDate)
                    .HasColumnName("Report_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ReportIsActive).HasColumnName("Report_IsActive");

                entity.Property(e => e.ReviewComments)
                    .HasColumnName("Review_Comments")
                    .HasMaxLength(2500);

                entity.Property(e => e.ReviewerName)
                    .HasColumnName("Reviewer_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.WorkOrderNo).HasColumnName("Work_Order_No");
            });

            modelBuilder.Entity<TstRouteCall>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tst_Route_Call");

                entity.Property(e => e.CallNo).HasColumnName("Call_No");

                entity.Property(e => e.CompleteDate)
                    .HasColumnName("Complete_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FkRouteId).HasColumnName("FK_RouteId");

                entity.Property(e => e.LabourHours).HasColumnName("Labour_Hours");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("Modified_By")
                    .HasMaxLength(32);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("Modified_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PkCallId)
                    .HasColumnName("PK_CallId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PlanDate)
                    .HasColumnName("Plan_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ScheduleDate)
                    .HasColumnName("Schedule_Date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<VConditionDaily>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Condition_Daily");

                entity.Property(e => e.ConditionMagnitude).HasColumnName("Condition_Magnitude");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.IsoweekOfYear).HasColumnName("ISOWeekOfYear");

                entity.Property(e => e.MachineTrain)
                    .HasColumnName("Machine_Train")
                    .HasMaxLength(32);

                entity.Property(e => e.NextReportDate).HasColumnType("date");

                entity.Property(e => e.ReportDate)
                    .HasColumnName("Report_Date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<VConditionWeekly>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Condition_Weekly");

                entity.Property(e => e.Area).HasMaxLength(64);

                entity.Property(e => e.ConditionMagnitude).HasColumnName("Condition_Magnitude");

                entity.Property(e => e.ContainsMissedDates).HasColumnName("Contains_Missed_Dates");

                entity.Property(e => e.CycleDays).HasColumnName("Cycle_Days");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.GreaterArea)
                    .HasColumnName("Greater_Area")
                    .HasMaxLength(32);

                entity.Property(e => e.IsoweekOfYear).HasColumnName("ISOWeekOfYear");

                entity.Property(e => e.MachineTrain)
                    .HasColumnName("Machine_Train")
                    .HasMaxLength(32);

                entity.Property(e => e.NextReportDate)
                    .HasColumnName("Next_Report_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ReportDate)
                    .HasColumnName("Report_Date")
                    .HasColumnType("date");

                entity.Property(e => e.Route).HasMaxLength(255);

                entity.Property(e => e.TwoMissedSurveysDate)
                    .HasColumnName("Two_Missed_Surveys_Date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<VCreateReports>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Create_Reports");

                entity.Property(e => e.Actions).HasMaxLength(2500);

                entity.Property(e => e.CallNo).HasColumnName("Call_No");

                entity.Property(e => e.ChangeInCondition)
                    .HasColumnName("Change_In_Condition")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CompleteDate)
                    .HasColumnName("Complete_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Condition).HasMaxLength(32);

                entity.Property(e => e.ConditionDifference).HasColumnName("Condition_Difference");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CycleDays).HasColumnName("Cycle_Days");

                entity.Property(e => e.FaultLocation)
                    .HasColumnName("Fault_Location")
                    .HasMaxLength(50);

                entity.Property(e => e.FaultType)
                    .HasColumnName("Fault_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.LabourHours).HasColumnName("Labour_Hours");

                entity.Property(e => e.MachineTrain)
                    .HasColumnName("Machine_Train")
                    .HasMaxLength(32);

                entity.Property(e => e.MachineTrainLongName)
                    .HasColumnName("Machine_Train_Long_Name")
                    .HasMaxLength(255);

                entity.Property(e => e.MeasurementDate)
                    .HasColumnName("Measurement_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("Modified_By")
                    .HasMaxLength(32);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("Modified_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModuleCode)
                    .HasColumnName("Module_Code")
                    .HasMaxLength(16);

                entity.Property(e => e.PkCallId).HasColumnName("PK_CallId");

                entity.Property(e => e.PkMachineTrainId).HasColumnName("PK_MachineTrainId");

                entity.Property(e => e.PkRouteId).HasColumnName("PK_RouteId");

                entity.Property(e => e.PlanDate)
                    .HasColumnName("Plan_Date")
                    .HasColumnType("date");

                entity.Property(e => e.PrimaryComponentType)
                    .HasColumnName("Primary_Component_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.Record)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.ReportDate)
                    .HasColumnName("Report_Date")
                    .HasColumnType("date");

                entity.Property(e => e.Route).HasMaxLength(255);

                entity.Property(e => e.ScheduleDate)
                    .HasColumnName("Schedule_Date")
                    .HasColumnType("date");

                entity.Property(e => e.Unit).HasMaxLength(16);
            });

            modelBuilder.Entity<VLatestReportByFault>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Latest_Report_by_Fault");

                entity.Property(e => e.FkFaultId).HasColumnName("FK_FaultId");

                entity.Property(e => e.LatestReportDateByFault)
                    .HasColumnName("Latest_Report_Date_by_Fault")
                    .HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VMachinesLastMeasured>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Machines_Last_Measured");

                entity.Property(e => e.Area).HasMaxLength(64);

                entity.Property(e => e.CycleDays).HasColumnName("Cycle_Days");

                entity.Property(e => e.DaysSinceMeasured).HasColumnName("Days_Since_Measured");

                entity.Property(e => e.DrivenUnitType)
                    .HasColumnName("Driven_Unit_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.GreaterArea)
                    .HasColumnName("Greater_Area")
                    .HasMaxLength(32);

                entity.Property(e => e.LatestReportDate)
                    .HasColumnName("Latest_Report_Date")
                    .HasColumnType("date");

                entity.Property(e => e.MachineTrain)
                    .HasColumnName("Machine_Train")
                    .HasMaxLength(32);

                entity.Property(e => e.MachineTrainLongName)
                    .HasColumnName("Machine_Train_Long_Name")
                    .HasMaxLength(255);

                entity.Property(e => e.Route).HasMaxLength(255);
            });

            modelBuilder.Entity<VReportSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Report_Summary");

                entity.Property(e => e.Actions).HasMaxLength(2500);

                entity.Property(e => e.AnalystName)
                    .HasColumnName("Analyst_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.AnalystNotes).HasColumnName("Analyst_Notes");

                entity.Property(e => e.Area).HasMaxLength(64);

                entity.Property(e => e.ChangeInCondition)
                    .IsRequired()
                    .HasColumnName("Change_In_Condition")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CloseDate)
                    .HasColumnName("Close_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Condition).HasMaxLength(32);

                entity.Property(e => e.ConditionDifference).HasColumnName("Condition_Difference");

                entity.Property(e => e.ConditionMagnitude).HasColumnName("Condition_Magnitude");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CycleDays).HasColumnName("Cycle_Days");

                entity.Property(e => e.DrivenUnitType)
                    .HasColumnName("Driven_Unit_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.ExternalNotes)
                    .HasColumnName("External_Notes")
                    .HasMaxLength(1000);

                entity.Property(e => e.FaultIsActive).HasColumnName("Fault_IsActive");

                entity.Property(e => e.FaultLocation)
                    .HasColumnName("Fault_Location")
                    .HasMaxLength(50);

                entity.Property(e => e.FaultSubtype)
                    .HasColumnName("Fault_Subtype")
                    .HasMaxLength(200);

                entity.Property(e => e.FaultType)
                    .HasColumnName("Fault_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.GreaterArea)
                    .HasColumnName("Greater_Area")
                    .HasMaxLength(32);

                entity.Property(e => e.MachineTrain)
                    .HasColumnName("Machine_Train")
                    .HasMaxLength(32);

                entity.Property(e => e.MachineTrainLongName)
                    .HasColumnName("Machine_Train_Long_Name")
                    .HasMaxLength(255);

                entity.Property(e => e.MeasurementDate)
                    .HasColumnName("Measurement_Date")
                    .HasColumnType("date");

                entity.Property(e => e.NotificationNo).HasColumnName("Notification_No");

                entity.Property(e => e.Observations).HasMaxLength(2500);

                entity.Property(e => e.PrimaryComponentSubtype)
                    .HasColumnName("Primary_Component_Subtype")
                    .HasMaxLength(50);

                entity.Property(e => e.PrimaryComponentType)
                    .HasColumnName("Primary_Component_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductionImpactCost).HasColumnName("Production_Impact_Cost");

                entity.Property(e => e.ReportDate)
                    .HasColumnName("Report_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ReportIsActive).HasColumnName("Report_IsActive");

                entity.Property(e => e.ReportStage)
                    .HasColumnName("Report_Stage")
                    .HasMaxLength(50);

                entity.Property(e => e.ReportType)
                    .HasColumnName("Report_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.ReviewComments)
                    .HasColumnName("Review_Comments")
                    .HasMaxLength(2500);

                entity.Property(e => e.ReviewerName)
                    .HasColumnName("Reviewer_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.Route).HasMaxLength(255);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.WorkOrderNo).HasColumnName("Work_Order_No");
            });

            modelBuilder.Entity<VRouteMachines>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Route_Machines");

                entity.Property(e => e.Actions).HasMaxLength(2500);

                entity.Property(e => e.ChangeInCondition)
                    .HasColumnName("Change_In_Condition")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Condition).HasMaxLength(32);

                entity.Property(e => e.ConditionDifference).HasColumnName("Condition_Difference");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CycleDays).HasColumnName("Cycle_Days");

                entity.Property(e => e.DrivenUnitType)
                    .HasColumnName("Driven_Unit_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.FaultLocation)
                    .HasColumnName("Fault_Location")
                    .HasMaxLength(50);

                entity.Property(e => e.FaultType)
                    .HasColumnName("Fault_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstCallDate)
                    .HasColumnName("First_Call_Date")
                    .HasColumnType("date");

                entity.Property(e => e.LabourHours).HasColumnName("Labour_Hours");

                entity.Property(e => e.MachineTrain)
                    .IsRequired()
                    .HasColumnName("Machine_Train")
                    .HasMaxLength(32);

                entity.Property(e => e.MachineTrainIsActive).HasColumnName("MachineTrain_IsActive");

                entity.Property(e => e.MachineTrainLongName)
                    .IsRequired()
                    .HasColumnName("Machine_Train_Long_Name")
                    .HasMaxLength(255);

                entity.Property(e => e.MeasurementDate)
                    .HasColumnName("Measurement_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ModuleCode)
                    .HasColumnName("Module_Code")
                    .HasMaxLength(16);

                entity.Property(e => e.PkMachineTrainId).HasColumnName("PK_MachineTrainId");

                entity.Property(e => e.PrimaryComponentType)
                    .HasColumnName("Primary_Component_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.ReportDate)
                    .HasColumnName("Report_Date")
                    .HasColumnType("date");

                entity.Property(e => e.Route).HasMaxLength(255);

                entity.Property(e => e.RouteIsActive).HasColumnName("Route_IsActive");

                entity.Property(e => e.Unit).HasMaxLength(16);
            });

            modelBuilder.Entity<VRoutes>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Routes");

                entity.Property(e => e.CallNo).HasColumnName("Call_No");

                entity.Property(e => e.CycleDays).HasColumnName("Cycle_Days");

                entity.Property(e => e.LabourHours).HasColumnName("Labour_Hours");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("Modified_By")
                    .HasMaxLength(32);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("Modified_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModuleCode)
                    .HasColumnName("Module_Code")
                    .HasMaxLength(16);

                entity.Property(e => e.NoMachinesOnRoute).HasColumnName("No_Machines_On_Route");

                entity.Property(e => e.PkCallId).HasColumnName("PK_CallId");

                entity.Property(e => e.PkRouteId).HasColumnName("PK_RouteId");

                entity.Property(e => e.PlanDate)
                    .HasColumnName("Plan_Date")
                    .HasColumnType("date");

                entity.Property(e => e.Route).HasMaxLength(255);

                entity.Property(e => e.ScheduleDate)
                    .HasColumnName("Schedule_Date")
                    .HasColumnType("date");

                entity.Property(e => e.Unit).HasMaxLength(16);
            });

            modelBuilder.Entity<VTstReportSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_tst_Report_Summary");

                entity.Property(e => e.Actions).HasMaxLength(2500);

                entity.Property(e => e.AnalystName)
                    .HasColumnName("Analyst_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.AnalystNotes).HasColumnName("Analyst_Notes");

                entity.Property(e => e.Area).HasMaxLength(64);

                entity.Property(e => e.ChangeInCondition)
                    .IsRequired()
                    .HasColumnName("Change_In_Condition")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CloseDate)
                    .HasColumnName("Close_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Condition).HasMaxLength(32);

                entity.Property(e => e.ConditionDifference).HasColumnName("Condition_Difference");

                entity.Property(e => e.ConditionMagnitude).HasColumnName("Condition_Magnitude");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CycleDays).HasColumnName("Cycle_Days");

                entity.Property(e => e.DrivenUnitType)
                    .HasColumnName("Driven_Unit_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.ExternalNotes)
                    .HasColumnName("External_Notes")
                    .HasMaxLength(1000);

                entity.Property(e => e.FaultIsActive).HasColumnName("Fault_IsActive");

                entity.Property(e => e.FaultLocation)
                    .HasColumnName("Fault_Location")
                    .HasMaxLength(50);

                entity.Property(e => e.FaultSubtype)
                    .HasColumnName("Fault_Subtype")
                    .HasMaxLength(200);

                entity.Property(e => e.FaultType)
                    .HasColumnName("Fault_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.GreaterArea)
                    .HasColumnName("Greater_Area")
                    .HasMaxLength(32);

                entity.Property(e => e.MachineTrain)
                    .HasColumnName("Machine_Train")
                    .HasMaxLength(32);

                entity.Property(e => e.MachineTrainLongName)
                    .HasColumnName("Machine_Train_Long_Name")
                    .HasMaxLength(255);

                entity.Property(e => e.MeasurementDate)
                    .HasColumnName("Measurement_Date")
                    .HasColumnType("date");

                entity.Property(e => e.NotificationNo).HasColumnName("Notification_No");

                entity.Property(e => e.Observations).HasMaxLength(2500);

                entity.Property(e => e.PrimaryComponentSubtype)
                    .HasColumnName("Primary_Component_Subtype")
                    .HasMaxLength(50);

                entity.Property(e => e.PrimaryComponentType)
                    .HasColumnName("Primary_Component_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductionImpactCost).HasColumnName("Production_Impact_Cost");

                entity.Property(e => e.ReportDate)
                    .HasColumnName("Report_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ReportIsActive).HasColumnName("Report_IsActive");

                entity.Property(e => e.ReportStage)
                    .HasColumnName("Report_Stage")
                    .HasMaxLength(50);

                entity.Property(e => e.ReportType)
                    .HasColumnName("Report_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.ReviewComments)
                    .HasColumnName("Review_Comments")
                    .HasMaxLength(2500);

                entity.Property(e => e.ReviewerName)
                    .HasColumnName("Reviewer_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.Route).HasMaxLength(255);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UnitReference)
                    .HasColumnName("Unit_Reference")
                    .HasMaxLength(4);

                entity.Property(e => e.WorkOrderNo).HasColumnName("Work_Order_No");

                entity.HasOne(e => e.Machine_Train_Entry).WithMany().HasForeignKey(FK => FK.MachineTrainId);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
