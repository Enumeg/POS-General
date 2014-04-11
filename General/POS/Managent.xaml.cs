using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System;
using System.Linq;
using Source;

namespace POS
{
    /// <summary>
    /// Interaction logic for Managent.xaml
    /// </summary>
    public partial class Managent : Window
    {
        //Data
        Products Products_Page;
        Points Points_Page;
        Customers Customers_Page;
        Customers Suppliers_Page;
        Employees Employees_Page;
        Users Users_Page;
        //Accounts
        Outcome_Page Outcome_Page;
        Income Income_Page;
        Bank_Page Bank_Page;
        Loans Loans_Page;
        //Transactions
        Transactions Buy_Page;
        Transactions Buy_Back_Page;
        Transactions Sell_Page;
        Transactions Sell_Back_Page;
        Transactions Transfer_Page;
        Transactions Depreciation_Page;

        string Selected_Button = "";      
        DoubleAnimation ani;
        System.Collections.Generic.List<object> pages;

        public Managent()
        {
            InitializeComponent();
            ani = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 700));
            Tab_Panel.Children.Clear();
            pages = new System.Collections.Generic.List<object>();
            if(App.Group_ID.ToString() == "3")
            {
                Data_EXP.Visibility = Accounts_EXP.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
                                 
        private void Set_Selected(Button button)
        {
            try
            {

                if(Selected_Button != "")
                {
                    ((Button)FindName(Selected_Button)).Style = FindResource("Side") as Style;
                    ((Button)FindName("Tab_" + Selected_Button)).Style = FindResource("Closed_Tab") as Style;
                }
                if(button.Name.StartsWith("Tab_"))
                {
                    button.Style = FindResource("Selected_Closed_Tab") as Style;                    
                    Selected_Button = button.Name.Replace("Tab_", "");
                    Button btn1 = ((Button)FindName(button.Name.Replace("Tab_", "")));
                    btn1.Style = FindResource("Selected_Side") as Style;
                }
                else
                {
                    button.Style = FindResource("Selected_Side") as Style;                    
                    Selected_Button = button.Name;
                    Button btn1 = ((Button)FindName("Tab_" + button.Name));
                    if(!Tab_Panel.Children.Contains(btn1)) { Tab_Panel.Children.Add(btn1); }
                    btn1.Style = FindResource("Selected_Closed_Tab") as Style;
                }
            }
            catch
            {

            }
        }

        private void Close_Page(Button btn)
        {
            try
            {

                if(btn.Name.Replace("Tab_", "") == Selected_Button)
                {
                    pages.Remove(Frame.Content);
                    if(Tab_Panel.Children.Count > 0)
                    {
                        Frame.Navigate(pages[int.Parse(Tab_Panel.Tag.ToString()) - 1]);
                        Set_Selected((Button)Tab_Panel.Children[int.Parse(Tab_Panel.Tag.ToString()) - 1]);
                    }
                    else
                    {
                        Frame.Navigate(null);
                        Set_Selected(new Button());
                    }

                }
                else
                {
                    ((Button)FindName(btn.Name.Replace("Tab_", ""))).Style = FindResource("Side") as Style;
                    pages.Remove(pages[int.Parse(Tab_Panel.Tag.ToString())]);
                }
            }
            catch
            {

            }
        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            try
            {
                Page page = Frame.Content as Page;
                page.BeginAnimation(Page.OpacityProperty, ani);
                if(!pages.Contains(Frame.Content)) { pages.Add(Frame.Content); }

            }
            catch
            {

            }
        }


        #region Data

        private void BTN_1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;

                if(btn.Name.StartsWith("Tab_") && !Tab_Panel.Children.Contains(btn))
                {
                    Close_Page(btn);
                }
                else if(btn.Name != Selected_Button && btn.Name.Replace("Tab_", "") != Selected_Button)
                {
                    { Products_Page = new Products(); }
                    Frame.Navigate(Products_Page);
                    Set_Selected(btn);
                }
            }
            catch
            {

            }
        }

        
        private void BTN_3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if(btn.Name.StartsWith("Tab_") && !Tab_Panel.Children.Contains(btn))
                {
                    Close_Page(btn);
                }
                else if(btn.Name != Selected_Button && btn.Name.Replace("Tab_", "") != Selected_Button)
                {
                    if(Suppliers_Page == null) { Suppliers_Page = new Customers("suppliers"); }
                    Frame.Navigate(Suppliers_Page);
                    Set_Selected(btn);
                }
            }
            catch
            {

            }
        }

        private void BTN_4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if(btn.Name.StartsWith("Tab_") && !Tab_Panel.Children.Contains(btn))
                {
                    Close_Page(btn);
                }
                else if(btn.Name != Selected_Button && btn.Name.Replace("Tab_", "") != Selected_Button)
                {
                    if(Customers_Page == null) { Customers_Page = new Customers("customers"); }
                    Frame.Navigate(Customers_Page);
                    Set_Selected(btn);
                }
            }
            catch
            {

            }

        }

       
        private void BTN_6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if(btn.Name.StartsWith("Tab_") && !Tab_Panel.Children.Contains(btn))
                {
                    Close_Page(btn);
                }
                else if(btn.Name != Selected_Button && btn.Name.Replace("Tab_", "") != Selected_Button)
                {
                    if(Users_Page == null) { Users_Page = new Users(); }
                    Frame.Navigate(Users_Page);
                    Set_Selected(btn);
                }
            }
            catch
            {

            }
        }

        #endregion

        #region Accounts
        private void BTN_10_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if(btn.Name.StartsWith("Tab_") && !Tab_Panel.Children.Contains(btn))
                {
                    Close_Page(btn);
                }
                else if(btn.Name != Selected_Button && btn.Name.Replace("Tab_", "") != Selected_Button)
                {
                    if(Income_Page == null) { Income_Page = new Income(); }
                    Frame.Navigate(Income_Page);
                    Set_Selected(btn);
                }
            }
            catch
            {

            }
        }

        private void BTN_11_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if(btn.Name.StartsWith("Tab_") && !Tab_Panel.Children.Contains(btn))
                {
                    Close_Page(btn);
                }
                else if(btn.Name != Selected_Button && btn.Name.Replace("Tab_", "") != Selected_Button)
                {
                    if(Outcome_Page == null) { Outcome_Page = new Outcome_Page(); }
                    Frame.Navigate(Outcome_Page);
                    Set_Selected(btn);
                }
            }
            catch
            {

            }
        }


        private void BTN_13_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if(btn.Name.StartsWith("Tab_") && !Tab_Panel.Children.Contains(btn))
                {
                    Close_Page(btn);
                }
                else if(btn.Name != Selected_Button && btn.Name.Replace("Tab_", "") != Selected_Button)
                {
                    if(Loans_Page == null) { Loans_Page = new Loans(); }
                    Frame.Navigate(Loans_Page);
                    Set_Selected(btn);
                }
            }
            catch
            {

            }
        }

        #endregion

        #region Transactions
        private void BTN_14_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if(btn.Name.StartsWith("Tab_") && !Tab_Panel.Children.Contains(btn))
                {
                    Close_Page(btn);
                }
                else if(btn.Name != Selected_Button && btn.Name.Replace("Tab_", "") != Selected_Button)
                {
                    if(Buy_Page == null) { Buy_Page = new Transactions(Transactions_Types.Buy); }
                    Frame.Navigate(Buy_Page);
                    Set_Selected(btn);
                }
            }
            catch
            {

            }
        }

        private void BTN_15_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if(btn.Name.StartsWith("Tab_") && !Tab_Panel.Children.Contains(btn))
                {
                    Close_Page(btn);
                }
                else if(btn.Name != Selected_Button && btn.Name.Replace("Tab_", "") != Selected_Button)
                {
                    if(Buy_Back_Page == null) { Buy_Back_Page = new Transactions(Transactions_Types.Buy_Back); }
                    Frame.Navigate(Buy_Back_Page);
                    Set_Selected(btn);
                }
            }
            catch
            {

            }
        }

        private void BTN_16_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if(btn.Name.StartsWith("Tab_") && !Tab_Panel.Children.Contains(btn))
                {
                    Close_Page(btn);
                }
                else if(btn.Name != Selected_Button && btn.Name.Replace("Tab_", "") != Selected_Button)
                {
                    if(Sell_Page == null) { Sell_Page = new Transactions(Transactions_Types.Sell); }
                    Frame.Navigate(Sell_Page);
                    Set_Selected(btn);
                }
            }
            catch
            {

            }
        }

        private void BTN_17_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if(btn.Name.StartsWith("Tab_") && !Tab_Panel.Children.Contains(btn))
                {
                    Close_Page(btn);
                }
                else if(btn.Name != Selected_Button && btn.Name.Replace("Tab_", "") != Selected_Button)
                {
                    if(Sell_Back_Page == null) { Sell_Back_Page = new Transactions(Transactions_Types.Sell_Back); }
                    Frame.Navigate(Sell_Back_Page);
                    Set_Selected(btn);
                }
            }
            catch
            {

            }
        }

        private void BTN_18_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if(btn.Name.StartsWith("Tab_") && !Tab_Panel.Children.Contains(btn))
                {
                    Close_Page(btn);
                }
                else if(btn.Name != Selected_Button && btn.Name.Replace("Tab_", "") != Selected_Button)
                {
                    if(Transfer_Page == null) { Transfer_Page = new Transactions(Transactions_Types.Transfer); }
                    Frame.Navigate(Transfer_Page);
                    Set_Selected(btn);
                }
            }
            catch
            {

            }
        }

        private void BTN_19_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if(btn.Name.StartsWith("Tab_") && !Tab_Panel.Children.Contains(btn))
                {
                    Close_Page(btn);
                }
                else if(btn.Name != Selected_Button && btn.Name.Replace("Tab_", "") != Selected_Button)
                {
                    if(Depreciation_Page == null) { Depreciation_Page = new Transactions(Transactions_Types.Depreciation); }
                    Frame.Navigate(Depreciation_Page);
                    Set_Selected(btn);
                }
            }
            catch
            {

            }
        }

        #endregion






    }
}
