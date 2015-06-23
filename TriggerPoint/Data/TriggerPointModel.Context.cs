﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TriggerPoint.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TriggerPointContext : DbContext
    {
        public TriggerPointContext()
            : base(Properties.Settings.Default.ConnectionString)
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_Average> Tbl_Average { get; set; }
        public virtual DbSet<Tbl_AverageParameters> Tbl_AverageParameters { get; set; }
        public virtual DbSet<Tbl_BollingerBand> Tbl_BollingerBand { get; set; }
        public virtual DbSet<Tbl_config_ColumnMapings> Tbl_config_ColumnMapings { get; set; }
        public virtual DbSet<Tbl_config_ColumnMapings_EOD> Tbl_config_ColumnMapings_EOD { get; set; }
        public virtual DbSet<Tbl_EODData> Tbl_EODData { get; set; }
        public virtual DbSet<Tbl_ErrorDetail> Tbl_ErrorDetail { get; set; }
        public virtual DbSet<Tbl_FormulaPortfolio> Tbl_FormulaPortfolio { get; set; }
        public virtual DbSet<Tbl_MACD> Tbl_MACD { get; set; }
        public virtual DbSet<Tbl_MACDFilters> Tbl_MACDFilters { get; set; }
        public virtual DbSet<Tbl_MACDParameters> Tbl_MACDParameters { get; set; }
        public virtual DbSet<Tbl_Master> Tbl_Master { get; set; }
        public virtual DbSet<Tbl_Pivote> Tbl_Pivote { get; set; }
        public virtual DbSet<Tbl_Portfolio> Tbl_Portfolio { get; set; }
        public virtual DbSet<Tbl_RSI> Tbl_RSI { get; set; }
        public virtual DbSet<Tbl_RSIParameters> Tbl_RSIParameters { get; set; }
        public virtual DbSet<Tbl_Script_archive> Tbl_Script_archive { get; set; }
        public virtual DbSet<Tbl_ScriptMaster> Tbl_ScriptMaster { get; set; }
        public virtual DbSet<Tbl_ScriptPortfolio> Tbl_ScriptPortfolio { get; set; }
        public virtual DbSet<Tbl_ScriptUpload> Tbl_ScriptUpload { get; set; }
        public virtual DbSet<Tbl_ScriptUploadMaster> Tbl_ScriptUploadMaster { get; set; }
        public virtual DbSet<Tbl_SplitMergeHistory> Tbl_SplitMergeHistory { get; set; }
        public virtual DbSet<Tbl_Stochastic> Tbl_Stochastic { get; set; }
        public virtual DbSet<Tbl_SystemSetting> Tbl_SystemSetting { get; set; }
        public virtual DbSet<Tbl_User> Tbl_User { get; set; }
        public virtual DbSet<Tbl_UserDefineFormula> Tbl_UserDefineFormula { get; set; }
        public virtual DbSet<Tbl_UserType> Tbl_UserType { get; set; }
        public virtual DbSet<Tbl_Volatility> Tbl_Volatility { get; set; }
        public virtual DbSet<Tbl_config_Settings> Tbl_config_Settings { get; set; }
        public virtual DbSet<Tbl_Script> Tbl_Script { get; set; }
        public virtual DbSet<Tbl_Script_Ami> Tbl_Script_Ami { get; set; }
        public virtual DbSet<Tbl_Script10Min> Tbl_Script10Min { get; set; }
        public virtual DbSet<Tbl_Script120Min> Tbl_Script120Min { get; set; }
        public virtual DbSet<Tbl_Script15Min> Tbl_Script15Min { get; set; }
        public virtual DbSet<Tbl_Script1Min> Tbl_Script1Min { get; set; }
        public virtual DbSet<Tbl_Script20Min> Tbl_Script20Min { get; set; }
        public virtual DbSet<Tbl_Script30Min> Tbl_Script30Min { get; set; }
        public virtual DbSet<Tbl_Script45Min> Tbl_Script45Min { get; set; }
        public virtual DbSet<Tbl_Script5Min> Tbl_Script5Min { get; set; }
        public virtual DbSet<Tbl_Script60Min> Tbl_Script60Min { get; set; }
        public virtual DbSet<Tbl_Script885Min> Tbl_Script885Min { get; set; }
        public virtual DbSet<Tbl_Script90Min> Tbl_Script90Min { get; set; }
        public virtual DbSet<Tbl_ScriptEOD> Tbl_ScriptEOD { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tbl_Swing> Tbl_Swing { get; set; }
        public virtual DbSet<Tbl_SwingParameters> Tbl_SwingParameters { get; set; }
    
        public virtual int Delete_Scrap_Data()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Delete_Scrap_Data");
        }
    
        public virtual int DeleteData(Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate, Nullable<int> script, string table, ObjectParameter result)
        {
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(System.DateTime));
    
            var scriptParameter = script.HasValue ?
                new ObjectParameter("Script", script) :
                new ObjectParameter("Script", typeof(int));
    
            var tableParameter = table != null ?
                new ObjectParameter("Table", table) :
                new ObjectParameter("Table", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteData", fromDateParameter, toDateParameter, scriptParameter, tableParameter, result);
        }
    
        public virtual int DeleteData_AsPerDate(Nullable<System.DateTime> startDate, Nullable<System.DateTime> toDate)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteData_AsPerDate", startDateParameter, toDateParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> DeleteData_AsPerID(Nullable<int> scriptId)
        {
            var scriptIdParameter = scriptId.HasValue ?
                new ObjectParameter("ScriptId", scriptId) :
                new ObjectParameter("ScriptId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("DeleteData_AsPerID", scriptIdParameter);
        }
    
        public virtual int DeleteScriptDatabyDateRange(Nullable<int> scriptId, Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate)
        {
            var scriptIdParameter = scriptId.HasValue ?
                new ObjectParameter("ScriptId", scriptId) :
                new ObjectParameter("ScriptId", typeof(int));
    
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("fromDate", fromDate) :
                new ObjectParameter("fromDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("toDate", toDate) :
                new ObjectParameter("toDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteScriptDatabyDateRange", scriptIdParameter, fromDateParameter, toDateParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> DeleteScriptDatabyId(Nullable<int> scriptId)
        {
            var scriptIdParameter = scriptId.HasValue ?
                new ObjectParameter("ScriptId", scriptId) :
                new ObjectParameter("ScriptId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("DeleteScriptDatabyId", scriptIdParameter);
        }
    
        public virtual int GeneratePivoteData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GeneratePivoteData");
        }
    
        [DbFunction("TriggerPointContext", "GetFrom_And_To_Time")]
        public virtual IQueryable<GetFrom_And_To_Time_Result> GetFrom_And_To_Time(Nullable<int> interval, Nullable<System.TimeSpan> actTime, Nullable<System.DateTime> sysTime)
        {
            var intervalParameter = interval.HasValue ?
                new ObjectParameter("Interval", interval) :
                new ObjectParameter("Interval", typeof(int));
    
            var actTimeParameter = actTime.HasValue ?
                new ObjectParameter("ActTime", actTime) :
                new ObjectParameter("ActTime", typeof(System.TimeSpan));
    
            var sysTimeParameter = sysTime.HasValue ?
                new ObjectParameter("SysTime", sysTime) :
                new ObjectParameter("SysTime", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<GetFrom_And_To_Time_Result>("[TriggerPointContext].[GetFrom_And_To_Time](@Interval, @ActTime, @SysTime)", intervalParameter, actTimeParameter, sysTimeParameter);
        }
    
        public virtual ObjectResult<SelectData_AsPerDate_Result> SelectData_AsPerDate(Nullable<System.DateTime> startDate, Nullable<System.DateTime> toDate)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectData_AsPerDate_Result>("SelectData_AsPerDate", startDateParameter, toDateParameter);
        }
    
        public virtual ObjectResult<SelectData_AsPerTimeSlot_Result> SelectData_AsPerTimeSlot(Nullable<int> time_Interval)
        {
            var time_IntervalParameter = time_Interval.HasValue ?
                new ObjectParameter("Time_Interval", time_Interval) :
                new ObjectParameter("Time_Interval", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectData_AsPerTimeSlot_Result>("SelectData_AsPerTimeSlot", time_IntervalParameter);
        }
    
        public virtual ObjectResult<SelectData_AsPerTimeSlot1_Result> SelectData_AsPerTimeSlot1(Nullable<int> time_Interval)
        {
            var time_IntervalParameter = time_Interval.HasValue ?
                new ObjectParameter("Time_Interval", time_Interval) :
                new ObjectParameter("Time_Interval", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectData_AsPerTimeSlot1_Result>("SelectData_AsPerTimeSlot1", time_IntervalParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int Sp_Tbl_ScriptUplod_To_Insert_ScriptRecord()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sp_Tbl_ScriptUplod_To_Insert_ScriptRecord");
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int spGetScriptDataFiltered(Nullable<int> companyScriptId, Nullable<int> recordMinutes)
        {
            var companyScriptIdParameter = companyScriptId.HasValue ?
                new ObjectParameter("companyScriptId", companyScriptId) :
                new ObjectParameter("companyScriptId", typeof(int));
    
            var recordMinutesParameter = recordMinutes.HasValue ?
                new ObjectParameter("recordMinutes", recordMinutes) :
                new ObjectParameter("recordMinutes", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spGetScriptDataFiltered", companyScriptIdParameter, recordMinutesParameter);
        }
    
        public virtual int MergeData(Nullable<int> fromScript, Nullable<int> toScript, ObjectParameter result)
        {
            var fromScriptParameter = fromScript.HasValue ?
                new ObjectParameter("FromScript", fromScript) :
                new ObjectParameter("FromScript", typeof(int));
    
            var toScriptParameter = toScript.HasValue ?
                new ObjectParameter("ToScript", toScript) :
                new ObjectParameter("ToScript", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MergeData", fromScriptParameter, toScriptParameter, result);
        }
    
        public virtual int SplitData(Nullable<int> script, Nullable<System.DateTime> effectiveDate, Nullable<decimal> factor, ObjectParameter result)
        {
            var scriptParameter = script.HasValue ?
                new ObjectParameter("Script", script) :
                new ObjectParameter("Script", typeof(int));
    
            var effectiveDateParameter = effectiveDate.HasValue ?
                new ObjectParameter("EffectiveDate", effectiveDate) :
                new ObjectParameter("EffectiveDate", typeof(System.DateTime));
    
            var factorParameter = factor.HasValue ?
                new ObjectParameter("Factor", factor) :
                new ObjectParameter("Factor", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SplitData", scriptParameter, effectiveDateParameter, factorParameter, result);
        }
    }
}
