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

    public partial class UserAccount : INotifyPropertyChanged
    {
        private long? m_EmployeeID;
        private string m_Password;
        private string m_UserName;
        private int m_PermissionLevel;

        public Nullable<long> EmployeeID
        {
            get { return m_EmployeeID; }
            set { SetField(ref m_EmployeeID, value, "EmployeeID"); }
        }

        public string Password
        {
            get { return m_Password; }
            set { SetField(ref m_Password, value, "Password"); }
        }
        public string UserName
        {
            get { return m_UserName; }
            set { SetField(ref m_UserName, value, "UserName"); }
        }

        public int PermissionLevel
        {
            get { return m_PermissionLevel; }
            set { SetField(ref m_PermissionLevel, value, "PermissionLevel"); }
        }
    
        public virtual Employee Employee { get; set; }

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
    }
}
