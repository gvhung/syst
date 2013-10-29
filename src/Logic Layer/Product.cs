//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.ComponentModel;

namespace Logic_Layer
{
    using System;
    using System.Collections.Generic;

    public partial class Product : INotifyPropertyChanged
    {
        private string m_ProductID;
        private string m_ProductName;
        private string m_ProductGroupID;
        private string m_ProductCategoryID;
        private string m_DepartmentID;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public string ProductID
        {
            get { return m_ProductID; }
            set { SetField(ref m_ProductID, value, "ProductID"); }
        }
        public string ProductName
        {
            get { return m_ProductName; }
            set { SetField(ref m_ProductName, value, "ProductName"); }
        }
        public string ProductGroupID
        {
            get { return m_ProductGroupID; }
            set { SetField(ref m_ProductGroupID, value, "ProductGroupID"); }
        }
        public string ProductCategoryID
        {
            get { return m_ProductCategoryID; }
            set { SetField(ref m_ProductCategoryID, value, "ProductCategoryID"); }
        }
        public string DepartmentID
        {
            get { return m_DepartmentID; }
            set { SetField(ref m_DepartmentID, value, "DepartmentID"); }
        }

        public Product()
        {
            this.DirectProductCost = new HashSet<DirectProductCost>();
            this.FinancialIncome = new HashSet<FinancialIncome>();
            this.ProductPlacement = new HashSet<ProductPlacement>();
        }
    
    
        public virtual Department Department { get; set; }
        public virtual ICollection<DirectProductCost> DirectProductCost { get; set; }
        public virtual ICollection<FinancialIncome> FinancialIncome { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public virtual ICollection<ProductPlacement> ProductPlacement { get; set; }
    }
}
