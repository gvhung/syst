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
    
    public partial class ForecastMonitor
    {
        public string IeProductID { get; set; }
        public string IeProductName { get; set; }
        public int OutcomeAcc { get; set; }
        public Nullable<int> Reprocessed { get; set; }
        public Nullable<int> Forecast { get; set; }
        public string ForecastBudget { get; set; }
        public string ForecastMonitorMonthID { get; set; }
    
        public virtual ForecastMonth ForecastMonth { get; set; }
    }
}
