using System.Configuration;
using System.Windows;
using Source;
using System.Globalization;

namespace POS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public enum Bank_Types { إيداع = 9, سحب = 10 };
    public enum Transactions_Types { Buy = 1, Buy_Back = 2, Transfer = 3, Depreciation = 4, Sell = 5, Sell_Back = 6, Cust = 7, Sup = 8 };
    public partial class App : Application
    {
        public static object User_Id;
        public static object Group_ID = 1;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            CultureInfo c = new CultureInfo("ar-EG");
            NumberFormatInfo n = new NumberFormatInfo();
            n.DigitSubstitution = DigitShapes.NativeNational;
            c.NumberFormat = n;
            System.Threading.Thread.CurrentThread.CurrentCulture = c;
            DB.ConnectionString = ConfigurationManager.ConnectionStrings["POS.Properties.Settings.Con"];
            try
            {
                DB.OpenConnection();
                //if(System.DateTime.Now < new System.DateTime(2013, 9, 15))
                //{
                //   
                //   
                //}
                //else
                //{
                //    Application.Current.Shutdown();
                //}
                Window w = new Login();
                w.ShowDialog();
            }
            catch
            {

            }

        }
    }
}
