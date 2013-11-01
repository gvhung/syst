﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BUPSystem.AccountGUI;
using BUPSystem.ActivityGUI;
using BUPSystem.CustomerGUI;
using BUPSystem.EmployeeGUI;
using BUPSystem.UserGUI;
using BUPSystem.ProductGUI;
using Logic_Layer;

namespace BUPSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lblDatum.Content = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void btnKundhantering_Click(object sender, RoutedEventArgs e)
        {
            CustomerRegister customerRegister = new CustomerRegister();
            customerRegister.ShowDialog();
        }

        private void btnProdukthantering_Click(object sender, RoutedEventArgs e)
        {
            ProductRegister productRegister = new ProductRegister();
            productRegister.ShowDialog();
        }

        private void btnKontohantering_Click(object sender, RoutedEventArgs e)
        {
            AccountRegister accountRegister = new AccountRegister();
            accountRegister.ShowDialog();
        }

        private void btnPersonalhantering_Click(object sender, RoutedEventArgs e)
        {
            EmployeeRegister employeeRegister = new EmployeeRegister();
            employeeRegister.ShowDialog();
        }

        private void btnAnvändarhantering_Click(object sender, RoutedEventArgs e)
        {
            UserRegister userRegister = new UserRegister();
            userRegister.ShowDialog();
        }

        private void btnUppföljning_Click(object sender, RoutedEventArgs e)
        {
            Uppföljning.FollowUpAndForecasting uppföljningOchPrognos =
                new Uppföljning.FollowUpAndForecasting();
            uppföljningOchPrognos.ShowDialog();
        }

        private void btnÅrsarbetarePerProdukt_Click(object sender, RoutedEventArgs e)
        {
            Kostnadsbudgetering.AnnualEmployeeViaProduct årsArbetarePerProduct =
                new Kostnadsbudgetering.AnnualEmployeeViaProduct();
            årsArbetarePerProduct.ShowDialog();
        }

        private void btnÅrsarbetarePerAktivitet_Click(object sender, RoutedEventArgs e)
        {
            Kostnadsbudgetering.AnnualEmployeePerActivity årsarbetarePerAktivitet =
                new Kostnadsbudgetering.AnnualEmployeePerActivity();
            årsarbetarePerAktivitet.ShowDialog();
        }

        private void btnAktivitetshantering_Click(object sender, RoutedEventArgs e)
        {
            ActivityRegister activityRegister = new ActivityRegister();
            activityRegister.ShowDialog();
        }

        private void btnDKPAA_Click(object sender, RoutedEventArgs e)
        {
            Kostnadsbudgetering.DirectCostsPerActivityDepartment dkpaa =
                new Kostnadsbudgetering.DirectCostsPerActivityDepartment();
            dkpaa.ShowDialog();
        }

        private void btnDKPPA_Click(object sender, RoutedEventArgs e)
        {
            Kostnadsbudgetering.DirectCostsPerProductDepartment dkppa =
                new Kostnadsbudgetering.DirectCostsPerProductDepartment();
            dkppa.ShowDialog();
        }

        private void btnIVK_Click(object sender, RoutedEventArgs e)
        {
            Revenue_budgeting.RevenueBudgetingViaCustomer ivk = new Revenue_budgeting.RevenueBudgetingViaCustomer();
            ivk.ShowDialog();
        }

        private void btnIVP_Click(object sender, RoutedEventArgs e)
        {
            Revenue_budgeting.RevenueBudgetingViaProduct ivp = new Revenue_budgeting.RevenueBudgetingViaProduct();
            ivp.ShowDialog();
        }

        private void btnProduktgrupp_Click(object sender, RoutedEventArgs e)
        {
            ProductGroupRegister pgr = new ProductGroupRegister();
            pgr.ShowDialog();
        }

        private void btnBudgeteratResultat_Click(object sender, RoutedEventArgs e)
        {
            Uppföljning.BudgetedResult budgetedResult = new Uppföljning.BudgetedResult();
            budgetedResult.ShowDialog();
        }

        private void btnProduktKategori_Click(object sender, RoutedEventArgs e)
        {
            ProductCategoryRegister pkr = new ProductCategoryRegister();
            pkr.ShowDialog();
        }

        private void btnUppföljningAvIntäkter_Click(object sender, RoutedEventArgs e)
        {
            Uppföljning.RevenueFollowUp uai = new Uppföljning.RevenueFollowUp();
            uai.ShowDialog();
        }

        private void btnNonBudgetedProducts_Click(object sender, RoutedEventArgs e)
        {
            Revenue_budgeting.NonBudgetedProducts nbp = new Revenue_budgeting.NonBudgetedProducts();
            nbp.ShowDialog();
        }

        /// <summary>
        /// Find user account of logged in user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (System.Threading.Thread.CurrentPrincipal.IsInRole("99"))
            {
                lblUsername.Content = "Inloggad som: " + System.Threading.Thread.CurrentPrincipal.Identity.Name;

                // Kommenterade för att testa (är korrekta)

                //btnPersonalhantering.Visibility = Visibility.Collapsed;
                //btnAnvändarhantering.Visibility = Visibility.Collapsed;
                //btnKontohantering.Visibility = Visibility.Collapsed;
                //gIntakt.Visibility = Visibility.Collapsed;
                //gKbudget.Visibility = Visibility.Collapsed;
            }
            else
            {
                Logic_Layer.UserAccount userAccount = null;

                userAccount = UserManagement.Instance.GetUserAccountByUsername(System.Threading.Thread.CurrentPrincipal.Identity.Name);

                if (userAccount == null)
                    Application.Current.Shutdown();


                lblUsername.Content = "Inloggad som: " + userAccount.Employee.EmployeeName;

                switch (userAccount.PermissionLevel)
                {
                    // Administrativchef
                    case 0:
                        btnPersonalhantering.Visibility = Visibility.Collapsed;
                        btnAnvändarhantering.Visibility = Visibility.Collapsed;
                        btnKontohantering.Visibility = Visibility.Collapsed;
                        gIntakt.Visibility = Visibility.Collapsed;
                        gKbudget.Visibility = Visibility.Collapsed;
                        break;

                    // Ekonomichef
                    case 1:
                        btnPersonalhantering.Visibility = Visibility.Collapsed;
                        btnAnvändarhantering.Visibility = Visibility.Collapsed;
                        break;

                    // Försäljningschef
                    case 2:
                        btnPersonalhantering.Visibility = Visibility.Collapsed;
                        btnAnvändarhantering.Visibility = Visibility.Collapsed;
                        btnKontohantering.Visibility = Visibility.Collapsed;
                        btnDKPAA.Visibility = Visibility.Collapsed;
                        btnÅrsarbetarePerAktivitet.Visibility = Visibility.Collapsed;
                        btnNonBudgetedProducts.Visibility = Visibility.Collapsed;
                        break;

                    // Personalchef
                    case 3:
                        btnAnvändarhantering.Visibility = Visibility.Collapsed;
                        btnKontohantering.Visibility = Visibility.Collapsed;
                        gIntakt.Visibility = Visibility.Collapsed;
                        gKbudget.Visibility = Visibility.Collapsed;
                        break;

                    // Driftschef
                    case 4:
                        btnPersonalhantering.Visibility = Visibility.Collapsed;
                        btnAnvändarhantering.Visibility = Visibility.Collapsed;
                        btnKontohantering.Visibility = Visibility.Collapsed;
                        gIntakt.Visibility = Visibility.Collapsed;
                        // DK??
                        btnDKPAA.Visibility = Visibility.Collapsed;
                        btnDKPPA.Visibility = Visibility.Collapsed;
                        break;
                   
                    // Systemadministratör
                    case 5:
                        // Kan göra allt?
                        break;
                    
                    // Säljare
                    case 6:
                        btnPersonalhantering.Visibility = Visibility.Collapsed;
                        btnAnvändarhantering.Visibility = Visibility.Collapsed;
                        btnKontohantering.Visibility = Visibility.Collapsed;
                        btnNonBudgetedProducts.Visibility = Visibility.Collapsed;
                        gKbudget.Visibility = Visibility.Collapsed;
                        break;

                    // Utvecklingschef
                    case 7:
                        btnPersonalhantering.Visibility = Visibility.Collapsed;
                        btnAnvändarhantering.Visibility = Visibility.Collapsed;
                        btnKontohantering.Visibility = Visibility.Collapsed;
                        gIntakt.Visibility = Visibility.Collapsed;
                        break;

                }

            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }

        private void Authorize()
        {

        }
    }
}
