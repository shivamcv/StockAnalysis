//------------------------------------------------------------------------------
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
    using System.Collections.ObjectModel;
    
    public partial class Tbl_ScriptMaster
    {
        public Tbl_ScriptMaster()
        {
            this.Tbl_Pivote = new ObservableCollection<Tbl_Pivote>();
            this.Tbl_Script = new ObservableCollection<Tbl_Script>();
        }
    
        public int ID { get; set; }
        public string ScriptName { get; set; }
        public bool IsDelete { get; set; }
        public string Exchange { get; set; }
        public Nullable<double> ScripCod { get; set; }
    
        public virtual ObservableCollection<Tbl_Pivote> Tbl_Pivote { get; set; }
        public virtual ObservableCollection<Tbl_Script> Tbl_Script { get; set; }
    }
}
