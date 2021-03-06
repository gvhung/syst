﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;


namespace Logic_Layer
{
    /// <summary>
    /// Class for management of products
    /// </summary>
    public class ProductManagement
    {
        public ObservableCollection<Product> Products { get; set; }


        /// <summary>
        /// Lazy Instance of ProductManagement singelton
        /// </summary>
        private static readonly Lazy<ProductManagement> instance = new Lazy<ProductManagement>(() => new ProductManagement());

        /// <summary>
        /// Database context
        /// </summary>
        private readonly DatabaseConnection db = new DatabaseConnection();

        /// <summary>
        /// The instance property
        /// </summary>
        public static ProductManagement Instance
        {
            get { return instance.Value; }
        }

        /// <summary>
        /// Constructor with initialization of products list
        /// </summary>
        public ProductManagement()
        {
            Products = new ObservableCollection<Product>(GetProducts());
        }

        public void FillProductList(string departmentID)
        {
            switch (departmentID)
            {
                case "DA":

                    Products = new ObservableCollection<Product>(GetProductsByDepartment("DA"));
                    break;
                case "UF":
                    Products = new ObservableCollection<Product>(GetProductsByDepartment("UF"));
                    break;

                default:
                    Products = new ObservableCollection<Product>(GetProducts());
                    break;
            }
        }

        /// <summary>
        /// Get a list of all products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            try
            {
                return db.Product.OrderBy(p => p.ProductName);
            }
            catch
            {
                return Products;
            }
        }

        /// <summary>
        /// Returns products in autocompletebox for ProductID
        /// </summary>
        /// <param name="prodID">written text in box for autocomplete</param>
        /// <returns></returns>
        public Product GetProductByID(string prodID)
        {
            return Products.FirstOrDefault(p => p.ProductID.Equals(prodID));
        }

        /// <summary>
        /// Returns products in autocompletebox for ProductName
        /// </summary>
        /// <param name="productName">written text in box for autocomplete</param>
        /// <returns></returns>
        public Product GetProductByName(string productName)
        {
            return db.Product.FirstOrDefault(p => p.ProductName.Equals(productName));
        }

        public IEnumerable<string> GetProductDepartments()
        {
            return from d in db.Department
                   orderby d.DepartmentID
                   where d.DepartmentID == "DA"
                   || d.DepartmentID == "UF"
                   select d.DepartmentID;
        }

        public IEnumerable<Product> GetProductsByProductGroup(string groupID)
        {
            return db.Product.Where(p => p.ProductGroupID.Equals(groupID));
        }

        public IEnumerable<Product> GetProductsByDepartment(string departmentID)
        {
            return db.Product.Where(p => p.DepartmentID.Equals(departmentID));
        }

        /// <summary>
        /// Check if a product is connected to a DirectProductCost
        /// </summary>
        /// <returns></returns>
        public bool IsConnectedToDirectProductCost(Product product)
        {
            var query = db.DirectProductCost.Where(d => d.ProductID.Equals(product.ProductID));
            return query.Any();
        }

        /// <summary>
        /// Check if a product is connected to a FinancialIncome
        /// </summary>
        /// <returns></returns>
        public bool IsConnectedToFinancialIncome(Product product)
        {
            var query = db.FinancialIncome.Where(f => f.ProductID.Equals(product.ProductID));
            return query.Any();
        }

        /// <summary>
        /// Check if a product is connected to a FinancialIncome
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool IsConnectedToEmployee(Product product)
        {
            var query = db.ProductPlacement.Where(f => f.ProductID.Equals(product.ProductID));
            return query.Any();
        }

        /// <summary>
        /// Add created product to databse
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            Products.Add(product);
            db.Product.Add(product);
            db.SaveChanges();
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        public void DeleteProduct(Product product)
        {
            db.Product.Remove(product);
            db.SaveChanges();
            Products.Remove(product);
        }

        /// <summary>
        /// Update a product
        /// </summary>
        public void Update()
        {
            db.SaveChanges();
        }

        public void ResetProduct(Product productObj)
        {
            db.Entry(productObj).State = EntityState.Unchanged;
        }

        /// <summary>
        /// Check if a specific customer exists
        /// </summary>
        public bool ProductExist(string id)
        {
            return db.Product.Any(p => p.ProductID == id);
        }

        /// <summary>
        /// Method that returns a list of all non budgeted products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetNonBudgetedProducts(string department)
        {
            var budgetedProducts = from p in db.FinancialIncome
                                   where p.Product.DepartmentID == department
                                   select p.ProductID;

            var allProducts = from p in db.Product
                              where p.DepartmentID == department
                              select p;

            return allProducts.Where(product => !budgetedProducts.Contains(product.ProductID));
        }

        //---------------------------------------------------------------------

        public void AddProductPlacement(ProductPlacement productPlacement)
        {
            productPlacement.ExpenseBudgetID = Cost_Budgeting_Logic.ExpenseBudgetManagement.Instance.GetExpenseBudgetID();
            db.ProductPlacement.Add(productPlacement);
            db.SaveChanges();
        }

        public IEnumerable<ProductPlacement> GetProductPlacementsByEmployee(Employee employee)
        {
            return from p in db.ProductPlacement
                   where p.EmployeeID == employee.EmployeeID
                   select p;
        }

        public IEnumerable<ProductPlacement> GetProductPlacementsByEmployeeAndDepartment(Employee employee, string department)
        {
            return from p in db.ProductPlacement
                   where p.EmployeeID == employee.EmployeeID
                   where p.Product.DepartmentID == department
                   where p.ExpenseBudgetID == DateTime.Now.Year
                   select p;
        }

        public void ResetProductPlacement(ProductPlacement ppObj)
        {
            try
            {
                db.Entry(ppObj).State = EntityState.Unchanged;
            }
            catch
            { }
        }
    }
}
