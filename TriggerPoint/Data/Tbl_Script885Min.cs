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
    
    public partial class Tbl_Script885Min
    {
        public int ID { get; set; }
        public Nullable<int> Company { get; set; }
        public Nullable<System.DateTime> Datetime { get; set; }
        public Nullable<decimal> OpenReadings { get; set; }
        public Nullable<decimal> HighReadings { get; set; }
        public Nullable<decimal> LowReadings { get; set; }
        public Nullable<decimal> CloseReadings { get; set; }
        public Nullable<int> Volume { get; set; }
        public Nullable<decimal> TurnOver { get; set; }
        public Nullable<int> OpenInterest { get; set; }
        public Nullable<System.TimeSpan> Track_Time { get; set; }
        public Nullable<System.TimeSpan> Entry_Time { get; set; }
    }
}
