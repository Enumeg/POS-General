using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace POS
{
    /// <summary>
    /// Interaction logic for Cashier_Window.xaml
    /// </summary>
    public partial class Cashier_Window : Window
    {
        Transactions Sell_Page;
        Transactions Sell_Back_Page;
        Outcome_Page Outcome_Page;
        string Selected_Button = "";
        DoubleAnimation ani;

        public Cashier_Window()
        {
            InitializeComponent();
            ani = new DoubleAnimation(0, 1, new System.TimeSpan(0, 0, 0, 0, 700));
        }

        private void Initialize_Pages()
        {
            try
            {
                Sell_Page = new Transactions(TransactionsTypes.Sell);
                Sell_Back_Page = new Transactions(TransactionsTypes.SellBack); ;
                Outcome_Page = new Outcome_Page();
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
                Frame.Navigate(Sell_Page);
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
                Frame.Navigate(Sell_Back_Page);
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
                Frame.Navigate(Outcome_Page);
            }
            catch
            {

            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                
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
                Selected_Button = button.Name.ToString();
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
