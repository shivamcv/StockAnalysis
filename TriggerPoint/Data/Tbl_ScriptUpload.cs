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
    
    public partial class Tbl_ScriptUpload
    {
        public int ID { get; set; }
        public string Exchange { get; set; }
        public string SCRIPNAME { get; set; }
        public Nullable<double> LastTradedPrice { get; set; }
        public Nullable<System.DateTime> LastTradedDate { get; set; }
        public Nullable<System.DateTime> LastTradedTime { get; set; }
        public Nullable<double> Volume { get; set; }
        public Nullable<double> TurnOver { get; set; }
        public Nullable<double> OpenInterest { get; set; }
        public Nullable<System.DateTime> LastTradedDateTime { get; set; }
        public Nullable<double> ScripCod { get; set; }
    }
}
