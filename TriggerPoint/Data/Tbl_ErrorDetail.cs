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
    
    public partial class Tbl_ErrorDetail
    {
        public int ErrorID { get; set; }
        public string URL { get; set; }
        public string Error { get; set; }
        public Nullable<System.DateTime> ErrorDate { get; set; }
        public bool IsDelete { get; set; }
        public Nullable<int> Status { get; set; }
    }
}
