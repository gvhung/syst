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

    public partial class ProductCategory : INotifyPropertyChanged
    {
        private string m_ProductCategoryID;
        private string m_ProductCategoryName;

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


        public ProductCategory()
        {
            this.Product = new HashSet<Product>();
        }

        public string ProductCategoryID
        {
            get { return m_ProductCategoryID; }
            set { SetField(ref m_ProductCategoryID, value, "ProductCategoryID"); }
        }
        public string ProductCategoryName
        {
            get { return m_ProductCategoryName; }
            set { SetField(ref m_ProductCategoryName, value, "ProductCategoryName"); }
        }
    
        public virtual ICollection<Product> Product { get; set; }
    }
}
