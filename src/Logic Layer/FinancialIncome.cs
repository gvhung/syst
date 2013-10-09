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
    
    public partial class FinancialIncome
    {
        public string ProductID { get; set; }
        public string CustomerID { get; set; }
        public Nullable<int> Agreement { get; set; }
        public bool GradeT { get; set; }
        public bool GradeA { get; set; }
        public Nullable<int> Addition { get; set; }
        public Nullable<int> Hours { get; set; }
        public string Comments { get; set; }
        public string FinancialIncomeID { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual FinancialIncomeYear FinancialIncomeYear { get; set; }
        public virtual Product Product { get; set; }
    }
}
