//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Logic_Layer
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeePlacement
    {
        public long EmployeeID { get; set; }
        public string DepartmentID { get; set; }
        public decimal EmployeeAllocate { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
