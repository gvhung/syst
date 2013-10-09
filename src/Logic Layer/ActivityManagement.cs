﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Logic_Layer
{
    public enum ActivityDepartments
    {
        AO,
        FO
    }

    public class ActivityManagement
    {
        /// <summary>
        /// Lazy Instance of ActivityManagement Singelton
        /// </summary>
        private static readonly Lazy<ActivityManagement> instance = new Lazy<ActivityManagement>(() => new ActivityManagement());

        /// <summary>
        /// The instance property
        /// </summary>
        /// <remarks></remarks>
        public static ActivityManagement Instance
        {
            get { return instance.Value; }
        }

        /// <summary>
        /// Database context
        /// </summary>
        private DatabaseConnection db = new DatabaseConnection();

        public ObservableCollection<Activity> ActivityList { get; set; }

        /// <summary>
        /// Get department names for use in ActivityGUI
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetDepartmentNames()
        {
            IEnumerable<string> departments = from d in db.Department
                                              orderby d.DepartmentID
                                              select d.DepartmentID;
            return departments;
        }

        /// <summary>
        /// Get a list of all activitys
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Activity> GetActivities()
        {
            IEnumerable<Activity> activity = from a in db.Activity
                                              orderby a.ActivityName
                                              select a;

            return activity;
        }

        public void CreateActivity(string id, string name, string activityDepartments)
        {
            string activityID = id.ToUpper();

            if (activityDepartments.Equals("AO"))          
                activityID += "AO";
            
            else
                activityID += "FO";

            Activity activity = new Activity { ActivityID = activityID, ActivityName = name, DepartmentID = activityDepartments };
            db.Activity.Add(activity);
            db.SaveChanges();
        }
    }
}
