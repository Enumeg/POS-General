using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System;

namespace POS
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        Products Projects_Page;
        Outcome_Page Pages_Page;
        Propertiess Tasks_Page;
        Transactions Users_Page;
        string Selected_Button = "";
        DoubleAnimation ani;

        public Main()
        {
            InitializeComponent();
            ani = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 700));
        }

        private void Initialize_Pages()
        {
            try
            {
                Projects_Page = new Products();
                Pages_Page = new Outcome_Page();
                Tasks_Page = new Propertiess();
                Users_Page = new Transactions(TransactionsTypes.Buy);
            }
            catch
            {

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Set_Selected((Button)sender);
                Frame.Navigate(new Bank_Page());
            }
            catch
            {

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Set_Selected((Button)sender);
                Frame.Navigate(new Income());
            }
            catch
            {

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                Set_Selected((Button)sender);
                Frame.Navigate(Tasks_Page);
            }
            catch
            {

            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                Set_Selected((Button)sender);
                Frame.Navigate(Users_Page);

            }
            catch
            {

            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                Set_Selected((Button)sender);
                Frame.Navigate(null);
                Initialize_Pages();
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
            }
            catch
            {

            }
        }

        private void Set_Selected(Button button)
        {
            try
            {
                if(Selected_Button != "")
                {
                    ((Button)FindName(Selected_Button)).Style = FindResource("Tabs") as Style;
                }
                button.Style = FindResource("Selected") as Style;
                Selected_Button = button.Content.ToString();
            }
            catch
            {

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Initialize_Pages();
            }
            catch
            {

            }
        }
    }
}
