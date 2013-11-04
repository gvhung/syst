﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
        private readonly DatabaseConnection db = new DatabaseConnection();

        public ObservableCollection<Activity> Activities { get; set; }

        /// <summary>
        /// Standard constructor with initialization of activties list
        /// </summary>
        public ActivityManagement()
        {
            Activities = new ObservableCollection<Activity>(GetActivities());
        }

        /// <summary>
        /// Get department names for use in ActivityGUI
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetDepartmentNames()
        {
            return from d in db.Department
                   where d.DepartmentID == "FO" || d.DepartmentID == "AO"
                   orderby d.DepartmentID
                   select d.DepartmentID;
        }

        /// <summary>
        /// Check if a specific activity exists
        /// </summary>
        public bool ActivityExist(string id)
        {
            return db.Activity.Any(a => a.ActivityID == id);
        }

        /// <summary>
        /// Get a list of all activitys
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Activity> GetActivities()
        {
            return db.Activity.OrderBy(a => a.ActivityName);
        }

        /// <summary>
        /// Add new activity
        /// </summary>
        /// <param name="activity"></param>
        public void AddActicity(Activity activity)
        {
            db.Activity.Add(activity);
            db.SaveChanges();
            Activities.Add(activity);
        }

        /// <summary>
        /// Check if an activity is connected to an employee
        /// </summary>
        /// <param name="productGroup"></param>
        /// <returns></returns>
        public bool IsConnectedToEmployee(Activity activity)
        {
            var query = db.ActivityPlacement.Where(f => f.ActivityID.Equals(activity.ActivityID));
            return query.Any();
        }


        /// <summary>
        /// Check if an activity is connected to an directactivitycost
        /// </summary>
        /// <param name="productGroup"></param>
        /// <returns></returns>
        public bool IsConnectedToDirectActivityCost(Activity activity)
        {
            var query = db.DirectActivityCost.Where(d => d.ActivityID.Equals(activity.ActivityID));
            return query.Any();
        }

        /// <summary>
        /// Delete an activity
        /// </summary>
        /// <param name="activity"></param>
        public void DeleteActivity(Activity activity)
        {
            Activities.Remove(activity);
            db.Activity.Remove(activity);
            db.SaveChanges();
        }

        /// <summary>
        /// Update an activity
        /// </summary>
        public void Update()
        {
            db.SaveChanges();
        }

        public void ResetActivity(Activity activity)
        {
            db.Entry(activity).State = EntityState.Unchanged;
        }

        //--------------------------------------------------------------------------------

        public void AddActivityPlacement(ActivityPlacement activityPlacement)
        {
            activityPlacement.ExpenseBudgetID = Cost_Budgeting_Logic.ExpenseBudgetManagement.Instance.GetExpenseBudgetID();
            db.ActivityPlacement.Add(activityPlacement);
            db.SaveChanges();
        }

        public IEnumerable<ActivityPlacement> GetActivityPlacementsByEmployee(Employee employee)
        {
            var activityplacements = from a in db.ActivityPlacement
                                    where a.EmployeeID == employee.EmployeeID
                                    select a;

            return activityplacements;
        }

    }
}
